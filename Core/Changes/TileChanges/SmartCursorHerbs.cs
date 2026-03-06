using Terraria.ObjectData;

namespace QoLCompendium.Core.Changes.TileChanges
{
    public class SmartCursorHerbs : GlobalTile
    {
        public override bool AutoSelect(int i, int j, int type, Item item)
        {
            if (!QoLCompendium.mainConfig.HerbSmartCursor)
                return base.AutoSelect(i, j, type, item);

            Player player = Main.LocalPlayer;
            Tile tile = Framing.GetTileSafely(i, j);
            if (Common.IsTileWithinPlayerReach(player) && tile.IsHarvestableHerb())
            {
                if (item.type == ItemID.StaffofRegrowth || item.type == ItemID.AcornAxe)
                    return true;
                if (!player.HasItem(ItemID.StaffofRegrowth) && !player.HasItem(ItemID.AcornAxe) && item.pick > 0)
                    return true;
                return base.AutoSelect(i, j, type, item);
            }
            return base.AutoSelect(i, j, type, item);
        }
    }

    public class SmartCursorHerbsPlayer : ModPlayer
    {
        public override bool PreItemCheck()
        {
            if (!QoLCompendium.mainConfig.HerbSmartCursor)
                return base.PreItemCheck();
            
            if ((Player.HeldItem.type == ItemID.StaffofRegrowth || Player.HeldItem.type == ItemID.AcornAxe) && !Player.CCed)
                SmartCursor();
            return base.PreItemCheck();
        }

        public void SmartCursor()
        {
            if (!QoLCompendium.mainConfig.HerbSmartCursor)
                return;

            if (Player.whoAmI != Main.myPlayer || !Main.SmartCursorIsUsed)
                return;

            Main.SmartCursorShowing = false;
            Item item = Player.inventory[Player.selectedItem];
            Vector2 playerTileTarget = new(Player.tileTargetX, Player.tileTargetY);
            Tile targetTile = Main.tile[(int)playerTileTarget.X, (int)playerTileTarget.Y];
            bool disableCursor = TileID.Sets.DisableSmartCursor[targetTile.TileType];

            if (!Common.IsTileWithinPlayerReach(Player) || disableCursor)
                return;

            int maxLeft = (int)(Player.position.X / 16f) - Player.tileRangeX - item.tileBoost + 1;
            int maxRight = (int)(Player.position.X + Player.width / 16f) + Player.tileRangeX + item.tileBoost - 1;
            int maxUp = (int)(Player.position.Y / 16f) - Player.tileRangeY - item.tileBoost + 1;
            int maxDown = (int)((Player.position.Y + Player.height) / 16f) + Player.tileRangeY + item.tileBoost - 2;
            maxLeft = Utils.Clamp(maxLeft, 10, Main.maxTilesX - 10);
            maxRight = Utils.Clamp(maxRight, 10, Main.maxTilesX - 10);
            maxDown = Utils.Clamp(maxDown, 10, Main.maxTilesY - 10);
            maxUp = Utils.Clamp(maxUp, 10, Main.maxTilesY - 10);

            List<Tuple<int, int>> potentialTargetTiles = [];
            for (int xCheck = maxLeft; xCheck <= maxRight; xCheck++)
            {
                for (int yCheck = maxUp; yCheck <= maxDown; yCheck++)
                {
                    Tile checkTile = Main.tile[xCheck, yCheck];
                    if (checkTile.IsHarvestableHerb() && TileObjectData.GetTileStyle(checkTile) != -1)
                        potentialTargetTiles.Add(new Tuple<int, int>(xCheck, yCheck));
                }
            }

            if (potentialTargetTiles.Count <= 0)
                return;

            float distanceToMouse = -1f;
            Tuple<int, int> currentTileCoords = potentialTargetTiles[0];
            for (int target = 0; target < potentialTargetTiles.Count; target++)
            {
                float distanceNew = Vector2.Distance(new Vector2(potentialTargetTiles[target].Item1, potentialTargetTiles[target].Item2) * 16f + Vector2.One * 8f, Main.MouseWorld);
                if (distanceToMouse == -1f || distanceNew < distanceToMouse)
                {
                    distanceToMouse = distanceNew;
                    currentTileCoords = potentialTargetTiles[target];
                }
            }

            if (Collision.InTileBounds(currentTileCoords.Item1, currentTileCoords.Item2, maxLeft, maxUp, maxRight, maxDown))
            {
                Main.SmartCursorX = Player.tileTargetX = currentTileCoords.Item1;
                Main.SmartCursorY = Player.tileTargetY = currentTileCoords.Item2;
                Main.SmartCursorShowing = true;
            }

            potentialTargetTiles.Clear();
        }
    }

    public static class HarvestableHerb
    {
        public static bool IsHarvestableHerb(this Tile tile)
        {
            int stage = tile.TileFrameX / 18;
            if (Common.HerbTiles.Contains(tile.TileType) && tile.TileType <= TileID.Count)
                return true;
            if (Common.HerbTiles.Contains(tile.TileType) && tile.TileType > TileID.Count && stage > 0)
                return true;

            return false;
        }
    }
}