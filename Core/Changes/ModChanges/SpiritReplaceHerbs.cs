using Terraria.DataStructures;

namespace QoLCompendium.Core.Changes.ModChanges
{
    public class SpiritReplaceHerbs : GlobalTile
    {
        public int GrowthSize = 18;

        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (!QoLCompendium.mainConfig.RegrowthAutoReplant)
                return;

            if (!ModConditions.spiritLoaded)
                return;

            if (type == Common.GetModTile(ModConditions.spiritMod, "Cloudstalk") && (Main.tile[i, j].TileFrameX / GrowthSize == 1 || Main.tile[i, j].TileFrameX / GrowthSize == 2))
            {
                if (((Main.LocalPlayer.HeldItem.type == ItemID.StaffofRegrowth || Main.LocalPlayer.HeldItem.type == ItemID.AcornAxe) || (Main.mouseItem != null && (Main.mouseItem.type == ItemID.StaffofRegrowth || Main.mouseItem.type == ItemID.AcornAxe))))
                {
                    if (Main.tile[i, j].TileFrameX / GrowthSize == 1)
                    {
                        Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i * 16, j * 16), 8, 8, Common.GetModItem(ModConditions.spiritMod, "CloudstalkItem"), 1);
                        Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i * 16, j * 16), 8, 8, Common.GetModItem(ModConditions.spiritMod, "CloudstalkSeed"), Main.rand.Next(1, 3));
                    }
                    if (Main.tile[i, j].TileFrameX / GrowthSize == 2)
                    {
                        Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i * 16, j * 16), 8, 8, Common.GetModItem(ModConditions.spiritMod, "CloudstalkItem"), Main.rand.Next(1, 3));
                        Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i * 16, j * 16), 8, 8, Common.GetModItem(ModConditions.spiritMod, "CloudstalkSeed"), Main.rand.Next(1, 6));
                    }

                    Main.tile[i, j].TileFrameX = 0;
                    fail = true;
                    NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 1, i, j, Common.GetModTile(ModConditions.spiritMod, "Cloudstalk"), 0);
                }
            }

            if (type == Common.GetModTile(ModConditions.spiritMod, "SoulBloomTile") && (Main.tile[i, j].TileFrameX / GrowthSize == 1 || Main.tile[i, j].TileFrameX / GrowthSize == 2))
            {
                if (((Main.LocalPlayer.HeldItem.type == ItemID.StaffofRegrowth || Main.LocalPlayer.HeldItem.type == ItemID.AcornAxe) || (Main.mouseItem != null && (Main.mouseItem.type == ItemID.StaffofRegrowth || Main.mouseItem.type == ItemID.AcornAxe))))
                {
                    if (Main.tile[i, j].TileFrameX / GrowthSize == 1)
                    {
                        Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i * 16, j * 16), 8, 8, Common.GetModItem(ModConditions.spiritMod, "SoulBloom"), 1);
                        Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i * 16, j * 16), 8, 8, Common.GetModItem(ModConditions.spiritMod, "SoulSeeds"), Main.rand.Next(1, 3));
                    }
                    if (Main.tile[i, j].TileFrameX / GrowthSize == 2)
                    {
                        Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i * 16, j * 16), 8, 8, Common.GetModItem(ModConditions.spiritMod, "SoulBloom"), Main.rand.Next(1, 3));
                        Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i * 16, j * 16), 8, 8, Common.GetModItem(ModConditions.spiritMod, "SoulSeeds"), Main.rand.Next(1, 6));
                    }

                    Main.tile[i, j].TileFrameX = 0;
                    fail = true;
                    NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 1, i, j, Common.GetModTile(ModConditions.spiritMod, "SoulBloomTile"), 0);
                }
            }
        }
    }
}
