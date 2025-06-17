using Terraria.DataStructures;

namespace QoLCompendium.Core.Changes.ModChanges
{
    public class RedemptionReplaceHerbs : ModPlayer
    {
        public int GrowthSize = 18;

        public override void PostItemCheck()
        {
            if (!Player.controlUseItem)
                return;

            if (!ModConditions.redemptionLoaded)
                return;

            if ((Player.HeldItem.type == ItemID.StaffofRegrowth || Player.HeldItem.type == ItemID.AcornAxe) || (Main.mouseItem != null && (Main.mouseItem.type == ItemID.StaffofRegrowth || Main.mouseItem.type == ItemID.AcornAxe)))
            {
                Tile tile = Main.tile[Player.tileTargetX, Player.tileTargetY];
                if (tile.HasTile && tile.TileType == Common.GetModTile(ModConditions.redemptionMod, "NightshadeTile") && (tile.TileFrameX / GrowthSize == 1 || tile.TileFrameX / GrowthSize == 2))
                {
                    if (tile.TileFrameX / GrowthSize == 1)
                    {
                        Item.NewItem(new EntitySource_TileBreak(Player.tileTargetX, Player.tileTargetY), new Vector2(Player.tileTargetX * 16, Player.tileTargetY * 16), 8, 8, Common.GetModItem(ModConditions.redemptionMod, "Nightshade"), 1);
                        Item.NewItem(new EntitySource_TileBreak(Player.tileTargetX, Player.tileTargetY), new Vector2(Player.tileTargetX * 16, Player.tileTargetY * 16), 8, 8, Common.GetModItem(ModConditions.redemptionMod, "NightshadeSeeds"), Main.rand.Next(1, 3));
                    }
                    if (tile.TileFrameX / GrowthSize == 2)
                    {
                        Item.NewItem(new EntitySource_TileBreak(Player.tileTargetX, Player.tileTargetY), new Vector2(Player.tileTargetX * 16, Player.tileTargetY * 16), 8, 8, Common.GetModItem(ModConditions.redemptionMod, "Nightshade"), Main.rand.Next(1, 3));
                        Item.NewItem(new EntitySource_TileBreak(Player.tileTargetX, Player.tileTargetY), new Vector2(Player.tileTargetX * 16, Player.tileTargetY * 16), 8, 8, Common.GetModItem(ModConditions.redemptionMod, "NightshadeSeeds"), Main.rand.Next(1, 6));
                    }
                    tile.TileFrameX = 0;
                    NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 1, Player.tileTargetX, Player.tileTargetY, Common.GetModTile(ModConditions.redemptionMod, "NightshadeTile"), 0);
                }
            }
        }
    }
}
