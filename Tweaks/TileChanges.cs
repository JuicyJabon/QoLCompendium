using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;
using tModPorter;

namespace QoLCompendium.Tweaks
{
    public class RegrowthStaffAutoPlant : ModSystem
    {
        public override void Load()
        {
            if (ModContent.GetInstance<QoLCConfig>().RegrowthAutoReplant)
            {
                On_Player.PlaceThing_Tiles_BlockPlacementForAssortedThings += new On_Player.hook_PlaceThing_Tiles_BlockPlacementForAssortedThings(Player_PlaceThing_Tiles_BlockPlacementForAssortedThings);
                On_WorldGen.KillTile_GetItemDrops += new On_WorldGen.hook_KillTile_GetItemDrops(WorldGen_KillTile_GetItemDrops);
            }
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
    }

    public class DontBreakHive : ModSystem
    {
        private static bool oldBreak;

        public override void Load()
        {
            oldBreak = Main.tileCut[231];
            if (ModContent.GetInstance<QoLCConfig>().NoLittering)
            {
                Main.tileCut[231] = false;
            }
        }

        public override void Unload()
        {
            Main.tileCut[231] = oldBreak;
        }
    }

    public class FastTreeGrowth : GlobalTile
    {
        public override void RandomUpdate(int i, int j, int type)
        {
            if (!ModContent.GetInstance<QoLCConfig>().FastTrees || !Main.tile[i, j].HasTile)
            {
                return;
            }
            for (int time = 0; time < 4; time++)
            {
                switch (type)
                {
                    case TileID.Saplings:
                        if ((Main.tile[i, j].TileFrameX < 324 || Main.tile[i, j].TileFrameX >= 540) ? WorldGen.GrowTree(i, j) : WorldGen.GrowPalmTree(i, j) && WorldGen.PlayerLOS(i, j))
                            WorldGen.TreeGrowFXCheck(i, j);
                        return;
                    case TileID.VanityTreeSakuraSaplings:
                    case TileID.VanityTreeWillowSaplings:
                        if (WorldGen.genRand.NextBool(5) && WorldGen.TryGrowingTreeByType(type + 1, i, j) && WorldGen.PlayerLOS(i, j))
                            WorldGen.TreeGrowFXCheck(i, j);
                        return;
                    case TileID.GemSaplings:
                        if (WorldGen.genRand.NextBool(5))
                        {
                            int style = Main.tile[i, j].TileFrameX / 54;
                            int treeTileType = TileID.TreeTopaz + style;

                            if (WorldGen.TryGrowingTreeByType(treeTileType, i, j) && WorldGen.PlayerLOS(i, j))
                                WorldGen.TreeGrowFXCheck(i, j);
                        }
                        return;
                }
                if (TileID.Sets.TreeSapling[type])
                {
                    TileLoader.GetTile(type)?.RandomUpdate(i, j);
                }
            }
        }
    }

    public class FastHerbGrowth : ModSystem
    {
        public override void Load()
        {
            if (ModContent.GetInstance<QoLCConfig>().FastHerbs)
            {
                On_TileDrawing.IsAlchemyPlantHarvestable += TileDrawing_IsAlchemyPlantHarvestable;
                On_WorldGen.IsHarvestableHerbWithSeed += WorldGen_IsHarvestableHerbWithSeed;
            }
        }

        private bool TileDrawing_IsAlchemyPlantHarvestable(On_TileDrawing.orig_IsAlchemyPlantHarvestable orig, TileDrawing self, int style)
        {
            if (ModContent.GetInstance<QoLCConfig>().FastHerbs)
            {
                return true;
            }
            else
            {
                return orig.Invoke(self, style);
            }
        }

        private bool WorldGen_IsHarvestableHerbWithSeed(On_WorldGen.orig_IsHarvestableHerbWithSeed orig, int type, int style)
        {
            if (ModContent.GetInstance<QoLCConfig>().FastHerbs)
            {
                return true;
            }
            else
            {
                return orig.Invoke(type, style);
            }
        }
    }
}
