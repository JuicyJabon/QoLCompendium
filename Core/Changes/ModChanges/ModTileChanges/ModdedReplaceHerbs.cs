using Terraria.DataStructures;

namespace QoLCompendium.Core.Changes.ModChanges.ModTileChanges
{
    public class ModdedReplaceHerbs : ModPlayer
    {
        public const int GrowthSize = 18;

        public override void PostItemCheck()
        {
            if (QoLCompendium.mainConfig.RegrowthAutoReplant && Player.controlUseItem)
            {
                if (Player.HeldItem.type == ItemID.StaffofRegrowth || Player.HeldItem.type == ItemID.AcornAxe || Main.mouseItem != null && (Main.mouseItem.type == ItemID.StaffofRegrowth || Main.mouseItem.type == ItemID.AcornAxe))
                {
                    Tile tile = Main.tile[Player.tileTargetX, Player.tileTargetY];
                    if (Common.IsTileWithinPlayerReach(Player))
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
            if (CrossModSupport.Depths.Loaded && tile.TileType == Common.GetModTile(CrossModSupport.Depths.Mod, "ShadowShrub"))
            {
                DropItems(stage, Common.GetModItem(CrossModSupport.Depths.Mod, "ShadowShrub"), Common.GetModItem(CrossModSupport.Depths.Mod, "ShadowShrubSeeds"));
                ResetTileFrame(tile);
            }
            #endregion

            #region Redemption
            if (CrossModSupport.Redemption.Loaded && tile.TileType == Common.GetModTile(CrossModSupport.Redemption.Mod, "NightshadeTile"))
            {
                DropItems(stage, Common.GetModItem(CrossModSupport.Redemption.Mod, "Nightshade"), Common.GetModItem(CrossModSupport.Redemption.Mod, "NightshadeSeeds"));
                ResetTileFrame(tile);
            }
            #endregion

            #region Shadows of Abaddon
            if (CrossModSupport.ShadowsOfAbaddon.Loaded)
            {
                if (tile.TileType == Common.GetModTile(CrossModSupport.ShadowsOfAbaddon.Mod, "Welkinbell"))
                {
                    DropItems(stage, Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "Welkinbell"), Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "WelkinbellSeeds"));
                    ResetTileFrame(tile);
                }
                if (tile.TileType == Common.GetModTile(CrossModSupport.ShadowsOfAbaddon.Mod, "Illumifern"))
                {
                    DropItems(stage, Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "Illumifern"), Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "IllumifernSeeds"));
                    ResetTileFrame(tile);
                }
                if (tile.TileType == Common.GetModTile(CrossModSupport.ShadowsOfAbaddon.Mod, "Enduflora"))
                {
                    DropItems(stage, Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "Enduflora"), Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "EndufloraSeeds"));
                    ResetTileFrame(tile);
                }
            }
            #endregion

            #region Spirit Classic
            if (CrossModSupport.SpiritClassic.Loaded)
            {
                if (tile.TileType == Common.GetModTile(CrossModSupport.SpiritClassic.Mod, "Cloudstalk"))
                {
                    DropItems(stage, Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "CloudstalkItem"), Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "CloudstalkSeed"));
                    ResetTileFrame(tile);
                }
                if (tile.TileType == Common.GetModTile(CrossModSupport.SpiritClassic.Mod, "SoulBloomTile"))
                {
                    DropItems(stage, Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "SoulBloom"), Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "SoulSeeds"));
                    ResetTileFrame(tile);
                }
            }
            #endregion

            #region Spirit Reforged
            if (CrossModSupport.SpiritReforged.Loaded)
            {
                if (tile.TileType == Common.GetModTile(CrossModSupport.SpiritReforged.Mod, "CloudstalkTile"))
                {
                    DropItems(stage, Common.GetModItem(CrossModSupport.SpiritReforged.Mod, "Cloudstalk"), Common.GetModItem(CrossModSupport.SpiritReforged.Mod, "CloudstalkSeed"));
                    ResetTileFrame(tile);
                }
            }
            #endregion

            #region Thorium
            if (CrossModSupport.Thorium.Loaded && tile.TileType == Common.GetModTile(CrossModSupport.Thorium.Mod, "MarineKelp"))
            {
                DropItems(stage, Common.GetModItem(CrossModSupport.Thorium.Mod, "MarineKelp"), Common.GetModItem(CrossModSupport.Thorium.Mod, "MarineKelpSeeds"));
                ResetTileFrame(tile);
            }
            if (CrossModSupport.Thorium.Loaded && tile.TileType == Common.GetModTile(CrossModSupport.Thorium.Mod, "MarineKelp2"))
            {
                DropItems(stage, Common.GetModItem(CrossModSupport.Thorium.Mod, "MarineKelp"), Common.GetModItem(CrossModSupport.Thorium.Mod, "MarineKelpSeeds"));
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
                if (Main.LocalPlayer.HeldItem.type == ItemID.StaffofRegrowth || Main.LocalPlayer.HeldItem.type == ItemID.AcornAxe || Main.mouseItem != null && (Main.mouseItem.type == ItemID.StaffofRegrowth || Main.mouseItem.type == ItemID.AcornAxe))
                {
                    HashSet<int> herbTiles = new()
                    {
                        Common.GetModTile(CrossModSupport.Depths.Mod, "ShadowShrub"),
                        Common.GetModTile(CrossModSupport.Redemption.Mod, "NightshadeTile"),
                        Common.GetModTile(CrossModSupport.ShadowsOfAbaddon.Mod, "Welkinbell"),
                        Common.GetModTile(CrossModSupport.ShadowsOfAbaddon.Mod, "Illumifern"),
                        Common.GetModTile(CrossModSupport.ShadowsOfAbaddon.Mod, "Enduflora"),
                        Common.GetModTile(CrossModSupport.SpiritClassic.Mod, "Cloudstalk"),
                        Common.GetModTile(CrossModSupport.SpiritClassic.Mod, "SoulBloomTile"),
                        Common.GetModTile(CrossModSupport.SpiritReforged.Mod, "CloudstalkTile"),
                        Common.GetModTile(CrossModSupport.Thorium.Mod, "MarineKelp"),
                        Common.GetModTile(CrossModSupport.Thorium.Mod, "MarineKelp2")
                    };

                    if (herbTiles.Contains(type))
                        fail = true;
                }
            }
        }
    }
}
