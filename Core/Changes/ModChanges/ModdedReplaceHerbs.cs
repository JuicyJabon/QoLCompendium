using Terraria.DataStructures;

namespace QoLCompendium.Core.Changes.ModChanges
{
    public class ModdedReplaceHerbs : ModPlayer
    {
        public const int GrowthSize = 18;

        public override void PostItemCheck()
        {
            if (QoLCompendium.mainConfig.RegrowthAutoReplant && Player.controlUseItem)
            {
                if (Player.HeldItem.type == ItemID.StaffofRegrowth || Player.HeldItem.type == ItemID.AcornAxe || (Main.mouseItem != null && (Main.mouseItem.type == ItemID.StaffofRegrowth || Main.mouseItem.type == ItemID.AcornAxe)))
                {
                    Tile tile = Main.tile[Player.tileTargetX, Player.tileTargetY];
                    GetHerbDrops(tile);
                }
            }
        }

        public static void GetHerbDrops(Tile tile)
        {
            if (!tile.HasTile)
                return;

            int stage = tile.TileFrameX / GrowthSize;

            #region Depths
            if (ModConditions.depthsLoaded && tile.TileType == Common.GetModTile(ModConditions.depthsMod, "ShadowShrub"))
            {
                DropItems(stage, Common.GetModItem(ModConditions.depthsMod, "ShadowShrub"), Common.GetModItem(ModConditions.depthsMod, "ShadowShrubSeeds"));
                ResetTileFrame(tile);
            }
            #endregion

            #region Redemption
            if (ModConditions.redemptionLoaded && tile.TileType == Common.GetModTile(ModConditions.redemptionMod, "NightshadeTile"))
            {
                DropItems(stage, Common.GetModItem(ModConditions.redemptionMod, "Nightshade"), Common.GetModItem(ModConditions.redemptionMod, "NightshadeSeeds"));
                ResetTileFrame(tile);
            }
            #endregion

            #region Shadows of Abaddon
            if (ModConditions.shadowsOfAbaddonLoaded)
            {
                if (tile.TileType == Common.GetModTile(ModConditions.shadowsOfAbaddonMod, "Welkinbell"))
                {
                    DropItems(stage, Common.GetModItem(ModConditions.shadowsOfAbaddonMod, "Welkinbell"), Common.GetModItem(ModConditions.shadowsOfAbaddonMod, "WelkinbellSeeds"));
                    ResetTileFrame(tile);
                }
                if (tile.TileType == Common.GetModTile(ModConditions.shadowsOfAbaddonMod, "Illumifern"))
                {
                    DropItems(stage, Common.GetModItem(ModConditions.shadowsOfAbaddonMod, "Illumifern"), Common.GetModItem(ModConditions.shadowsOfAbaddonMod, "IllumifernSeeds"));
                    ResetTileFrame(tile);
                }
                if (tile.TileType == Common.GetModTile(ModConditions.shadowsOfAbaddonMod, "Enduflora"))
                {
                    DropItems(stage, Common.GetModItem(ModConditions.shadowsOfAbaddonMod, "Enduflora"), Common.GetModItem(ModConditions.shadowsOfAbaddonMod, "EndufloraSeeds"));
                    ResetTileFrame(tile);
                }
            }
            #endregion

            #region Spirit
            if (ModConditions.spiritLoaded)
            {
                if (tile.TileType == Common.GetModTile(ModConditions.spiritMod, "Cloudstalk"))
                {
                    DropItems(stage, Common.GetModItem(ModConditions.spiritMod, "CloudstalkItem"), Common.GetModItem(ModConditions.spiritMod, "CloudstalkSeed"));
                    ResetTileFrame(tile);
                }
                if (tile.TileType == Common.GetModTile(ModConditions.spiritMod, "SoulBloomTile"))
                {
                    DropItems(stage, Common.GetModItem(ModConditions.spiritMod, "SoulBloom"), Common.GetModItem(ModConditions.spiritMod, "SoulSeeds"));
                    ResetTileFrame(tile);
                }
            }
            #endregion

            #region Thorium
            if (ModConditions.thoriumLoaded && tile.TileType == Common.GetModTile(ModConditions.thoriumMod, "MarineKelp2"))
            {
                DropItems(stage, Common.GetModItem(ModConditions.thoriumMod, "MarineKelp"), Common.GetModItem(ModConditions.thoriumMod, "MarineKelpSeeds"));
                ResetTileFrame(tile);
            }
            #endregion
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

            if (stage == 2)
            {
                herbDropCount = Main.rand.Next(1, 3);
                seedDropCount = Main.rand.Next(1, 6);
            }

            Item.NewItem(new EntitySource_TileBreak(Player.tileTargetX, Player.tileTargetY), new Vector2(Player.tileTargetX * 16, Player.tileTargetY * 16), 8, 8, herbID, herbDropCount);
            Item.NewItem(new EntitySource_TileBreak(Player.tileTargetX, Player.tileTargetY), new Vector2(Player.tileTargetX * 16, Player.tileTargetY * 16), 8, 8, seedID, seedDropCount);
        }

        public static void ResetTileFrame(Tile tile)
        {
            tile.TileFrameX = 0;
            NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 1, Player.tileTargetX, Player.tileTargetY, tile.TileType, 0);
        }
    }

    public class ModFailBreak : GlobalTile
    {
        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (QoLCompendium.mainConfig.RegrowthAutoReplant)
            {
                if (Main.LocalPlayer.HeldItem.type == ItemID.StaffofRegrowth || Main.LocalPlayer.HeldItem.type == ItemID.AcornAxe || (Main.mouseItem != null && (Main.mouseItem.type == ItemID.StaffofRegrowth || Main.mouseItem.type == ItemID.AcornAxe)))
                {
                    HashSet<int> herbTiles = new()
                    {
                        Common.GetModTile(ModConditions.depthsMod, "ShadowShrub"),
                        Common.GetModTile(ModConditions.redemptionMod, "NightshadeTile"),
                        Common.GetModTile(ModConditions.shadowsOfAbaddonMod, "Welkinbell"),
                        Common.GetModTile(ModConditions.shadowsOfAbaddonMod, "Illumifern"),
                        Common.GetModTile(ModConditions.shadowsOfAbaddonMod, "Enduflora"),
                        Common.GetModTile(ModConditions.spiritMod, "Cloudstalk"),
                        Common.GetModTile(ModConditions.spiritMod, "SoulBloomTile"),
                        Common.GetModTile(ModConditions.thoriumMod, "MarineKelp2")
                    };

                    if (herbTiles.Contains(type))
                        fail = true;
                }
            }
        }
    }
}
