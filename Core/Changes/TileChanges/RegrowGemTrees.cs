using Terraria.ObjectData;

namespace QoLCompendium.Core.Changes.TileChanges
{
    public class RegrowGemTrees : ModSystem
    {
        public enum GemTreeStyle
        {
            Topaz = 0,
            Amethyst = 1,
            Sapphire = 2,
            Emerald = 3,
            Ruby = 4,
            Diamond = 5,
            Amber = 6
        }

        public override void Load()
        {
            On_Player.ItemCheck_UseMiningTools_ActuallyUseMiningTool += OnPlayerMiningToolUse;
        }

        private void OnPlayerMiningToolUse(On_Player.orig_ItemCheck_UseMiningTools_ActuallyUseMiningTool orig, Player self, Item sItem, out bool canHitWalls, int x, int y)
        {
            if (!QoLCompendium.mainConfig.RegrowthAutoReplant)
            {
                orig.Invoke(self, sItem, out canHitWalls, x, y);
                return;
            }

            Tile tile = Main.tile[x, y];
            int cachedTileType = tile.TileType;

            WorldGen.GetTreeBottom(x, y, out var treeX, out var treeY);

            orig.Invoke(self, sItem, out canHitWalls, x, y);

            if (x != treeX || y != treeY - 1) return; // only try to replant in the tree bottom.
            if (tile.TileType != TileID.Dirt) return; // only if tile was removed.

            var player = GetPlayerForTile(x, y);
            var shouldReplantGemcorn = ShouldReplantGemcorn(cachedTileType, player);

            if (shouldReplantGemcorn)
            {
                var gemSeed = GetSeedItemFromGemTile(cachedTileType);

                int gemStyle = GetGemTreeStyleFromTile(cachedTileType);

                TryReplantingGemTree(self, x, y, gemStyle);
            }
        }

        private static void TryReplantingGemTree(Player player, int x, int y, int gemStyle = 0)
        {
            // This is a copy from terraria code, I needed to use but it was privated.
            int type = TileID.GemSaplings;
            int style = gemStyle;

            PlantLoader.CheckAndInjectModSapling(x, y, ref type, ref style);
            if (!TileObject.CanPlace(Player.tileTargetX, Player.tileTargetY, type, style, player.direction, out var objectData))
            {
                return;
            }
            bool num = TileObject.Place(objectData);
            WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY);
            if (num)
            {
                TileObjectData.CallPostPlacementPlayerHook(Player.tileTargetX, Player.tileTargetY, type, style, player.direction, objectData.alternate, objectData);
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    NetMessage.SendObjectPlacement(-1, Player.tileTargetX, Player.tileTargetY, objectData.type, objectData.style, objectData.alternate, objectData.random, player.direction);
                }
            }
        }

        public static bool ShouldReplantGemcorn(int tileType, Player player)
        {
            if (player == null) return false;
            if (!QoLCompendium.mainConfig.RegrowthAutoReplant) return false;

            if (player.inventory[player.selectedItem].type != ItemID.AcornAxe) return false;
            if (!TileID.Sets.CountsAsGemTree[tileType]) return false;

            return true;
        }

        // This is the same as the Terraria.Worldgen.GetPlayerForTile, but inaccessible for being private.
        private static Player GetPlayerForTile(int x, int y) => Main.player[Player.FindClosest(new Vector2(x, y) * 16f, 16, 16)];

        private static int GetGemTreeStyleFromTile(int tileType)
        {
            switch (tileType)
            {
                case TileID.TreeTopaz:
                    return (int)GemTreeStyle.Topaz;
                case TileID.TreeAmethyst:
                    return (int)GemTreeStyle.Amethyst;
                case TileID.TreeSapphire:
                    return (int)GemTreeStyle.Sapphire;
                case TileID.TreeEmerald:
                    return (int)GemTreeStyle.Emerald;
                case TileID.TreeRuby:
                    return (int)GemTreeStyle.Ruby;
                case TileID.TreeDiamond:
                    return (int)GemTreeStyle.Diamond;
                case TileID.TreeAmber:
                    return (int)GemTreeStyle.Amber;
                default:
                    return -1;
            }
        }

        public static int GetSeedItemFromGemTile(int tileType)
        {
            switch (tileType)
            {
                case TileID.TreeTopaz: return ItemID.GemTreeTopazSeed;
                case TileID.TreeAmethyst: return ItemID.GemTreeAmethystSeed;
                case TileID.TreeSapphire: return ItemID.GemTreeSapphireSeed;
                case TileID.TreeEmerald: return ItemID.GemTreeEmeraldSeed;
                case TileID.TreeRuby: return ItemID.GemTreeRubySeed;
                case TileID.TreeDiamond: return ItemID.GemTreeDiamondSeed;
                case TileID.TreeAmber: return ItemID.GemTreeAmberSeed;
                default: return -1;
            }
        }
    }
}
