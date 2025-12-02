using Terraria.DataStructures;

namespace QoLCompendium.Core.Changes.ModChanges.ModTileChanges
{
    public class AFKPetsReplacePlants : ModPlayer
    {
        public const int GrowthSize = 18;

        public override void PostItemCheck()
        {
            if (QoLCompendium.crossModConfig.AFKPetsRegrowthReplant && Player.controlUseItem)
            {
                if (Player.HeldItem.type == ItemID.StaffofRegrowth || Player.HeldItem.type == ItemID.AcornAxe || Main.mouseItem != null && (Main.mouseItem.type == ItemID.StaffofRegrowth || Main.mouseItem.type == ItemID.AcornAxe))
                {
                    Tile tile = Main.tile[Player.tileTargetX, Player.tileTargetY];
                    if (tile.TileType == Common.GetModTile(ModConditions.afkpetsMod, "Plants"))
                        GetPlantDrops(tile);
                }
            }
        }

        public static void GetPlantDrops(Tile tile)
        {
            if (!tile.HasTile)
                return;

            int stage = tile.TileFrameY / GrowthSize;
            switch (tile.TileFrameX / 18)
            {
                case 1:
                    DropItems(stage, Common.GetModItem(ModConditions.afkpetsMod, "Carrot"), Common.GetModItem(ModConditions.afkpetsMod, "CarrotSeedBag"));
                    ResetTileFrame(tile);
                    break;
                case 2:
                    DropItems(stage, Common.GetModItem(ModConditions.afkpetsMod, "Potato"), Common.GetModItem(ModConditions.afkpetsMod, "SeedPotatoBag"));
                    ResetTileFrame(tile);
                    break;
                case 3:
                    DropItems(stage, Common.GetModItem(ModConditions.afkpetsMod, "GlowBerry"), Common.GetModItem(ModConditions.afkpetsMod, "GlowberrySeedBag"));
                    ResetTileFrame(tile);
                    break;
                case 4:
                    DropItems(stage, Common.GetModItem(ModConditions.afkpetsMod, "Flax"), Common.GetModItem(ModConditions.afkpetsMod, "FlaxSeedBag"));
                    ResetTileFrame(tile);
                    break;
                case 5:
                    DropItems(stage, Common.GetModItem(ModConditions.afkpetsMod, "Beet"), Common.GetModItem(ModConditions.afkpetsMod, "BeetSeedBag"));
                    ResetTileFrame(tile);
                    break;
                case 6:
                    DropItems(stage, Common.GetModItem(ModConditions.afkpetsMod, "MiracleFruit"), Common.GetModItem(ModConditions.afkpetsMod, "MiracleFruitSeedBag"));
                    ResetTileFrame(tile);
                    break;
            }
        }

        public static void DropItems(int stage, int herbID, int seedID)
        {
            if (stage < 1)
                return;

            int herbDropCount = 0;
            int seedDropCount = 0;

            if (stage == 1)
            {
                herbDropCount = 1;
                seedDropCount = Main.rand.Next(1, 3);
            }

            Item.NewItem(new EntitySource_TileBreak(Player.tileTargetX, Player.tileTargetY), new Vector2(Player.tileTargetX * 16, Player.tileTargetY * 16), 8, 8, herbID, herbDropCount);
            Item.NewItem(new EntitySource_TileBreak(Player.tileTargetX, Player.tileTargetY), new Vector2(Player.tileTargetX * 16, Player.tileTargetY * 16), 8, 8, seedID, seedDropCount);
        }

        public static void ResetTileFrame(Tile tile)
        {
            tile.TileFrameY = 0;
            NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 1, Player.tileTargetX, Player.tileTargetY, tile.TileType, 0);
        }
    }

    public class AFKPetsFailBreak : GlobalTile
    {
        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (QoLCompendium.crossModConfig.AFKPetsRegrowthReplant)
            {
                if (Main.LocalPlayer.HeldItem.type == ItemID.StaffofRegrowth || Main.LocalPlayer.HeldItem.type == ItemID.AcornAxe || Main.mouseItem != null && (Main.mouseItem.type == ItemID.StaffofRegrowth || Main.mouseItem.type == ItemID.AcornAxe))
                {
                    if (type == Common.GetModTile(ModConditions.afkpetsMod, "Plants"))
                        fail = true;
                }
            }
        }
    }
}
