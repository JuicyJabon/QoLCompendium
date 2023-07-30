using Microsoft.Xna.Framework;
using MonoMod.Cil;
using QoLCompendium.NPCs;
using QoLCompendium.UI;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
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
        internal GlobeUI globeUI;
        private UserInterface globeInterface;

        private static bool oldBreak;

        public override uint ExtraPlayerBuffSlots => ModContent.GetInstance<QoLCConfig>().ExtraBuffSlots;

        public override void Load()
        {
            if (ModContent.GetInstance<QoLCConfig>().RegrowthAutoReplant)
            {
                On_Player.PlaceThing_Tiles_BlockPlacementForAssortedThings += new On_Player.hook_PlaceThing_Tiles_BlockPlacementForAssortedThings(Player_PlaceThing_Tiles_BlockPlacementForAssortedThings);
                On_WorldGen.KillTile_GetItemDrops += new On_WorldGen.hook_KillTile_GetItemDrops(WorldGen_KillTile_GetItemDrops);
            }

            oldBreak = Main.tileCut[231];
            if (ModContent.GetInstance<QoLCConfig>().NoLittering)
            {
                Main.tileCut[231] = false;
            }

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

            IL_Chest.VanillaSetupShop += il =>
            {
                ILCursor c = new(il);

                if (!c.TryGotoNext(MoveType.Before, x => x.MatchStloc(0)))
                {
                    return;
                }
                c.EmitDelegate((bool flag) => flag || ModContent.GetInstance<QoLCConfig>().ToggleHappiness);
            };

            IL_Main.DrawNPCChatButtons += il =>
            {
                ILCursor c = new(il);

                if (!c.TryGotoNext(MoveType.After, x => x.MatchLdstr("UI.NPCCheckHappiness")))
                {
                    return;
                }
                c.EmitDelegate((string text) => !ModContent.GetInstance<QoLCConfig>().ToggleHappiness ? text : "");
            };
        }

        public override void Unload()
        {
            Main.tileCut[231] = oldBreak;
        }

        private void WorldGen_KillTile_GetItemDrops(On_WorldGen.orig_KillTile_GetItemDrops orig, int x, int y, Tile tileCache, out int dropItem, out int dropItemStack, out int secondaryItem, out int secondaryItemStack, bool includeLargeObjectDrops)
        {
            secondaryItem = 0;
            secondaryItemStack = 1;
            Player playerForTile = GetPlayerForTile(x, y);
            if (IsHarvestable(tileCache, playerForTile))
            {
                int num = tileCache.TileFrameX / 18;
                dropItem = 313 + num;
                int num2 = 307 + num;
                if (num == 6)
                {
                    dropItem = 2358;
                    num2 = 2357;
                }
                dropItemStack = Main.rand.Next(1, 3);
                int num3 = Main.rand.Next(0, 5);
                if (num3 > 0)
                {
                    secondaryItem = num2;
                    secondaryItemStack = num3;
                    return;
                }
            }
            else
            {
                orig.Invoke(x, y, tileCache, out dropItem, out dropItemStack, out secondaryItem, out secondaryItemStack, includeLargeObjectDrops);
            }
        }

        private bool Player_PlaceThing_Tiles_BlockPlacementForAssortedThings(On_Player.orig_PlaceThing_Tiles_BlockPlacementForAssortedThings orig, Player self, bool canPlace)
        {
            int tileTargetX = Player.tileTargetX;
            int tileTargetY = Player.tileTargetY;
            Tile tile = Main.tile[tileTargetX, tileTargetY];
            int num = tile.TileFrameX / 18;
            if (tile.TileType == 82 && self.inventory[self.selectedItem].type == ItemID.StaffofRegrowth)
            {
                return false;
            }
            bool flag = IsHarvestable(tile, self);
            canPlace = orig.Invoke(self, canPlace);
            if (!canPlace && flag)
            {
                WorldGen.PlaceTile(tileTargetX, tileTargetY, 82, false, false, -1, num);
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    NetMessage.SendTileSquare(-1, tileTargetX, tileTargetY, 0);
                }
            }
            return canPlace;
        }

        public static bool IsHarvestable(Tile tile, Player player)
        {
            if (tile == null)
            {
                return false;
            }
            if (player == null)
            {
                return false;
            }
            int num = tile.TileFrameX / 18;
            return player.inventory[player.selectedItem].type == ItemID.StaffofRegrowth && (tile.TileType == 83 || tile.TileType == 84) && WorldGen.IsHarvestableHerbWithSeed(tile.TileType, num);
        }

        private static Player GetPlayerForTile(int x, int y)
        {
            return Main.player[Player.FindClosest(new Vector2(x, y) * 16f, 16, 16)];
        }

        public enum HerbStyle
        {
            Daybloom,
            Moonglow,
            Blinkroot,
            Deathweed,
            Waterleaf,
            Fireblossom,
            Shiverthorn
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
