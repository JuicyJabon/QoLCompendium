using Terraria.DataStructures;

namespace QoLCompendium.Core.Changes.TileChanges
{
    public class ReplaceHerbs : ModPlayer
    {
        public override void PostItemCheck()
        {
            if (QoLCompendium.mainConfig.RegrowthAutoReplant && Player.controlUseItem)
            {
                if (Player.HeldItem.type == ItemID.StaffofRegrowth || Player.HeldItem.type == ItemID.AcornAxe || (Main.mouseItem != null && (Main.mouseItem.type == ItemID.StaffofRegrowth || Main.mouseItem.type == ItemID.AcornAxe)))
                {
                    Tile tile = Main.tile[Player.tileTargetX, Player.tileTargetY];
                    if (Common.IsTileWithinPlayerReach(Player))
                        GetHerbDrops(tile);
                }
            }
        }

        public static void GetHerbDrops(Tile tile)
        {
            if (!tile.HasTile || tile.TileType == TileID.ImmatureHerbs)
                return;

            if (tile.TileType == TileID.MatureHerbs || tile.TileType == TileID.BloomingHerbs)
            {
                int herbStyle = tile.TileFrameX / 18;

                if (herbStyle == (int)Common.AlchemyHerbStyles.Daybloom)
                {
                    DropItems(tile, ItemID.Daybloom, ItemID.DaybloomSeeds);
                    ResetTileFrame(tile, herbStyle);
                }

                if (herbStyle == (int)Common.AlchemyHerbStyles.Moonglow)
                {
                    DropItems(tile, ItemID.Moonglow, ItemID.MoonglowSeeds);
                    ResetTileFrame(tile, herbStyle);
                }

                if (herbStyle == (int)Common.AlchemyHerbStyles.Blinkroot)
                {
                    DropItems(tile, ItemID.Blinkroot, ItemID.BlinkrootSeeds);
                    ResetTileFrame(tile, herbStyle);
                }

                if (herbStyle == (int)Common.AlchemyHerbStyles.Deathweed)
                {
                    DropItems(tile, ItemID.Deathweed, ItemID.DeathweedSeeds);
                    ResetTileFrame(tile, herbStyle);
                }

                if (herbStyle == (int)Common.AlchemyHerbStyles.Waterleaf)
                {
                    DropItems(tile, ItemID.Waterleaf, ItemID.WaterleafSeeds);
                    ResetTileFrame(tile, herbStyle);
                }

                if (herbStyle == (int)Common.AlchemyHerbStyles.Fireblossom)
                {
                    DropItems(tile, ItemID.Fireblossom, ItemID.FireblossomSeeds);
                    ResetTileFrame(tile, herbStyle);
                }

                if (herbStyle == (int)Common.AlchemyHerbStyles.Shiverthorn)
                {
                    DropItems(tile, ItemID.Shiverthorn, ItemID.ShiverthornSeeds);
                    ResetTileFrame(tile, herbStyle);
                }
            }
        }

        public static void DropItems(Tile tile, int herbID, int seedID)
        {
            int herbDropCount = 0;
            int seedDropCount = 0;

            if (tile.TileType == TileID.MatureHerbs)
            {
                herbDropCount = 1;
                seedDropCount = Main.rand.Next(1, 3);
            }

            if (tile.TileType == TileID.BloomingHerbs)
            {
                herbDropCount = Main.rand.Next(1, 3);
                seedDropCount = Main.rand.Next(1, 6);
            }

            Item.NewItem(new EntitySource_TileBreak(Player.tileTargetX, Player.tileTargetY), new Vector2(Player.tileTargetX * 16, Player.tileTargetY * 16), 8, 8, herbID, herbDropCount);
            Item.NewItem(new EntitySource_TileBreak(Player.tileTargetX, Player.tileTargetY), new Vector2(Player.tileTargetX * 16, Player.tileTargetY * 16), 8, 8, seedID, seedDropCount);
        }

        public static void ResetTileFrame(Tile tile, int style)
        {
            tile.TileType = TileID.ImmatureHerbs;
            tile.TileFrameX = (short)(18 * style);
            NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 1, Player.tileTargetX, Player.tileTargetY, TileID.ImmatureHerbs, style);
        }
    }

    public class FailBreak : GlobalTile
    {
        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (QoLCompendium.mainConfig.RegrowthAutoReplant)
            {
                if (Main.LocalPlayer.HeldItem.type == ItemID.StaffofRegrowth || Main.LocalPlayer.HeldItem.type == ItemID.AcornAxe || (Main.mouseItem != null && (Main.mouseItem.type == ItemID.StaffofRegrowth || Main.mouseItem.type == ItemID.AcornAxe)))
                {
                    if (type == TileID.ImmatureHerbs || type == TileID.MatureHerbs || type == TileID.BloomingHerbs)
                        fail = true;
                }
            }
        }
    }
}
