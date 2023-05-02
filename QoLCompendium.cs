using MonoMod.Cil;
using QoLCompendium.NPCs;
using QoLCompendium.UI;
using QoLCompendium.UI.ShopExpander;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria.UI;

namespace QoLCompendium
{
    public class QoLCompendium : Mod
    {
        internal BMNPCUI bmShopUI;
        private UserInterface bmInterface;
        internal ECNPCUI ecShopUI;
        private UserInterface ecInterface;
        internal GlobeUI globeUI;
        private UserInterface globeInterface;
        public override uint ExtraPlayerBuffSlots => ModContent.GetInstance<QoLCConfig>().ExtraBuffSlots;

        public static readonly LazyObjectConfig<int> ProvisionOverrides = new(40);
        public static readonly LazyObjectConfig<bool> ModifierOverrides = new();
        public static readonly LazyObjectConfig<bool> NoDistinctOverrides = new();
        public static readonly LazyObjectConfig<bool> IgnoreErrors = new();
        public static readonly LazyObjectConfig<bool> VanillaCopyOverrrides = new(true);
        public static readonly LazyObjectConfig<(string name, int priority, Action setup)[]> LegacyMultipageSetupMethods = new();

        private static bool textureSetupDone;

        public static QoLCompendium Instance => ModContent.GetInstance<QoLCompendium>();

        public static CircularBufferProvider Buyback { get; private set; }

        public static ModItem ArrowLeft { get; private set; }
        public static ModItem ArrowRight { get; private set; }

        public static ShopAggregator ActiveShop { get; private set; }

        public static void ResetAndBindShop()
        {
            ActiveShop = new ShopAggregator();
            ActiveShop.AddPage(Buyback = new("Buyback", ProviderPriority.Buyback));
            Main.instance.shop[Main.npcShop].item = ActiveShop.CurrentFrame;
        }

        public override void Load()
        {
            ArrowLeft = new ArrowItem("ArrowLeft");
            AddContent(ArrowLeft);

            ArrowRight = new ArrowItem("ArrowRight");
            AddContent(ArrowRight);

            if (!Main.dedServ)
            {
                bmShopUI = new BMNPCUI();
                bmShopUI.Activate();
                bmInterface = new UserInterface();
                bmInterface.SetState(bmShopUI);

                ecShopUI = new ECNPCUI();
                ecShopUI.Activate();
                ecInterface = new UserInterface();
                ecInterface.SetState(ecShopUI);

                globeUI = new GlobeUI();
                globeUI.Activate();
                globeInterface = new UserInterface();
                globeInterface.SetState(globeUI);
            }

            IL.Terraria.Chest.SetupShop += il =>
            {
                ILCursor c = new(il);

                if (!c.TryGotoNext(MoveType.Before, x => x.MatchStloc(0)))
                {
                    return;
                }
                c.EmitDelegate((bool flag) => flag || ModContent.GetInstance<QoLCConfig>().ToggleHappiness);
            };

            IL.Terraria.Main.DrawNPCChatButtons += il =>
            {
                ILCursor c = new(il);

                if (!c.TryGotoNext(MoveType.After, x => x.MatchLdstr("UI.NPCCheckHappiness")))
                {
                    return;
                }
                c.EmitDelegate((string text) => !ModContent.GetInstance<QoLCConfig>().ToggleHappiness ? text : "");
            };
        }

        public override void PostSetupContent()
        {
            SetupShopPatch.Load();
            AddShopPatch.Load();
            LeftRightClickPatch.Load();

            ArrowLeft.DisplayName.SetDefault("Previous page");
            ArrowRight.DisplayName.SetDefault("Next page");

            if (!Main.dedServ)
            {
                Main.RunOnMainThread(() =>
                {
                    TextureAssets.Item[ArrowLeft.Item.type] = TextureAsset(CropTexture(TextureAssets.TextGlyph[0].Value, new Rectangle(4 * 28, 0, 28, 28)));
                    TextureAssets.Item[ArrowRight.Item.type] = TextureAsset(CropTexture(TextureAssets.TextGlyph[0].Value, new Rectangle(5 * 28, 0, 28, 28)));
                    textureSetupDone = true;
                })
                    .GetAwaiter()
                    .GetResult();
            }

            if (ModLoader.TryGetMod("Census", out Mod mod) && ModContent.GetInstance<QoLCConfig>().BMNPC)
            {
                mod.Call(new object[]
                {
                    "TownNPCCondition",
                    ModContent.NPCType<BMDealerNPC>(),
                    "No condition"
                });
            }

            if (ModLoader.TryGetMod("Census", out Mod mod2) && ModContent.GetInstance<QoLCConfig>().ECNPC)
            {
                mod2.Call(new object[]
                {
                    "TownNPCCondition",
                    ModContent.NPCType<EtherealCollectorNPC>(),
                    "No condition"
                });
            }
        }

        public override void Unload()
        {
            SetupShopPatch.Unload();

            if (textureSetupDone)
            {
                Main.RunOnMainThread(() =>
                {
                    TextureAssets.Item[ArrowLeft.Item.type].Value.Dispose();
                    TextureAssets.Item[ArrowRight.Item.type].Value.Dispose();
                })
                    .GetAwaiter()
                    .GetResult(); // Use this instead of 'Wait()' so stack trace is more useful
            }
        }

        public override object Call(params object[] args)
        {
            var command = args[0] as string;
            if (command == null)
            {
                throw new ArgumentException("first argument must be string");
            }

            switch (command)
            {
                case CallApi.SetProvisionSize:
                    ProvisionOverrides.SetValue(args[1], AssertAndCast<int>(args, 2, CallApi.SetProvisionSize));
                    break;

                case CallApi.SetModifier:
                    ModifierOverrides.SetValue(args[1], true);
                    break;

                case CallApi.SetNoDistinct:
                    NoDistinctOverrides.SetValue(args[1], true);
                    break;

                case CallApi.SetVanillaNoCopy:
                    VanillaCopyOverrrides.SetValue(args[1], false);
                    break;

                case CallApi.AddLegacyMultipageSetupMethods:
                    if (args.Length % 3 != 2)
                    {
                        throw new ArgumentException("The number of arguments is incorrect (args.Length % 3 != 1) for " + CallApi.AddLegacyMultipageSetupMethods);
                    }

                    var methods = new (string name, int priority, Action setup)[args.Length / 3];
                    for (var i = 0; i < methods.Length; i++)
                    {
                        var offset = (i * 3) + 2;
                        methods[i].name = AssertAndCast<string>(args, offset, CallApi.AddLegacyMultipageSetupMethods);
                        methods[i].priority = AssertAndCast<int>(args, offset + 1, CallApi.AddLegacyMultipageSetupMethods);
                        methods[i].setup = AssertAndCast<Action>(args, offset + 2, CallApi.AddLegacyMultipageSetupMethods);
                    }

                    LegacyMultipageSetupMethods.SetValue(args[1], methods);
                    break;

                case CallApi.AddPageFromArray:
                    if (ActiveShop == null)
                    {
                        throw new InvalidOperationException($"No active shop, try calling {CallApi.ResetAndBindShop} first");
                    }

                    ActiveShop.AddPage(new ArrayProvider(AssertAndCast<string>(args, 1, CallApi.AddPageFromArray),
                        AssertAndCast<int>(args, 2, CallApi.AddPageFromArray),
                        AssertAndCast<Item[]>(args, 3, CallApi.AddPageFromArray)));
                    break;

                case CallApi.ResetAndBindShop:
                    ResetAndBindShop();
                    break;

                case CallApi.GetLastShopExpanded:
                    if (ActiveShop != null)
                    {
                        return ActiveShop.GetAllItems().ToArray();
                    }

                    break;

                default:
                    throw new ArgumentException($"Unknown command: {command}");
            }

            return null;
        }

        private static T AssertAndCast<T>(object[] args, int index, string site, bool checkForNull = false)
        {
            if (checkForNull && args[index] == null)
            {
                throw new ArgumentNullException($"args[{index}] cannot be null for {site}");
            }

            if (args[index] is not T casted)
            {
                throw new ArgumentException($"args[{index}] must be {typeof(T).Name} for {site}");
            }

            return casted;
        }

        private static Texture2D CropTexture(Texture2D texture, Rectangle newBounds)
        {
            var newTexture = new Texture2D(Main.graphics.GraphicsDevice, newBounds.Width, newBounds.Height);
            var area = newBounds.Width * newBounds.Height;
            var data = new Color[area];

            texture.GetData(0, newBounds, data, 0, area);
            newTexture.SetData(data);

            return newTexture;
        }

        private Asset<Texture2D> TextureAsset(Texture2D texture)
        {
            using MemoryStream stream = new(texture.Width * texture.Height);

            texture.SaveAsPng(stream, texture.Width, texture.Height);
            stream.Position = 0;

            return Assets.CreateUntracked<Texture2D>(stream, ".png");
        }
    }

    public class UISystem : ModSystem
    {
        internal BMNPCUI bmShopUI;
        private UserInterface bmInterface;
        internal ECNPCUI ecShopUI;
        private UserInterface ecInterface;
        internal GlobeUI globeUI;
        private UserInterface globeInterface;
        public override void OnWorldLoad()
        {
            if (!Main.dedServ)
            {
                bmShopUI = new BMNPCUI();
                bmShopUI.Activate();
                bmInterface = new UserInterface();
                bmInterface.SetState(bmShopUI);

                ecShopUI = new ECNPCUI();
                ecShopUI.Activate();
                ecInterface = new UserInterface();
                ecInterface.SetState(ecShopUI);

                globeUI = new GlobeUI();
                globeUI.Activate();
                globeInterface = new UserInterface();
                globeInterface.SetState(globeUI);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (MouseTextIndex != -1)
            {
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "QoLC: Shop Selector",
                    delegate
                    {
                        if (BMNPCUI.visible)
                        {
                            bmShopUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
            if (MouseTextIndex != -1)
            {
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "QoLC: Shop Selector",
                    delegate
                    {
                        if (ECNPCUI.visible)
                        {
                            ecShopUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
            if (MouseTextIndex != -1)
            {
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "QoLC: Globe Selector",
                    delegate
                    {
                        if (GlobeUI.visible)
                        {
                            globeUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }

        public override void UpdateUI(GameTime gameTime)
        {
            if (bmInterface != null && BMNPCUI.visible)
            {
                bmInterface.Update(gameTime);
            }

            if (ecInterface != null && ECNPCUI.visible)
            {
                ecInterface.Update(gameTime);
            }

            if (globeInterface != null && GlobeUI.visible)
            {
                globeInterface.Update(gameTime);
            }
        }
    }
}
