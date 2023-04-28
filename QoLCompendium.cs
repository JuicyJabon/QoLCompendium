using Microsoft.Xna.Framework;
using MonoMod.Cil;
using QoLCompendium.NPCs;
using QoLCompendium.UI;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace QoLCompendium
{
    public class QoLCompendium : Mod
    {
        internal BMNPCUI bmShopUI;
        private UserInterface bmInterface;
        internal ECNPCUI ecShopUI;
        private UserInterface ecInterface;
        public override uint ExtraPlayerBuffSlots => ModContent.GetInstance<QoLCConfig>().ExtraBuffSlots;

        public override void Load()
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
    }

    public class UISystem : ModSystem
    {
        internal BMNPCUI bmShopUI;
        private UserInterface bmInterface;
        internal ECNPCUI ecShopUI;
        private UserInterface ecInterface;
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
        }
    }
}
