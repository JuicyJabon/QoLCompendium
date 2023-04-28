using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Projectiles
{
    public class CheckDestruction : GlobalProjectile
    {
        public static bool OkayToDestroyTile(Tile tile)
        {
            bool noDungeon = !NPC.downedBoss3 &&
                (tile.TileType == TileID.BlueDungeonBrick || tile.TileType == TileID.GreenDungeonBrick || tile.TileType == TileID.PinkDungeonBrick
                || tile.WallType == WallID.BlueDungeonSlabUnsafe || tile.WallType == WallID.BlueDungeonTileUnsafe || tile.WallType == WallID.BlueDungeonUnsafe
                || tile.WallType == WallID.GreenDungeonSlabUnsafe || tile.WallType == WallID.GreenDungeonTileUnsafe || tile.WallType == WallID.GreenDungeonUnsafe
                || tile.WallType == WallID.PinkDungeonSlabUnsafe || tile.WallType == WallID.PinkDungeonTileUnsafe || tile.WallType == WallID.PinkDungeonUnsafe
            );
            bool noHMOre = (tile.TileType == TileID.Cobalt || tile.TileType == TileID.Palladium || tile.TileType == TileID.Mythril || tile.TileType == TileID.Orichalcum || tile.TileType == TileID.Adamantite || tile.TileType == TileID.Titanium) && !NPC.downedMechBossAny;
            bool noChloro = tile.TileType == TileID.Chlorophyte && !(NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3);
            bool noLihzahrd = (tile.TileType == TileID.LihzahrdBrick || tile.WallType == WallID.LihzahrdBrickUnsafe) && !NPC.downedGolemBoss;

            if (noDungeon || noHMOre || noChloro || noLihzahrd || TileBelongsToMagicStorage(tile))
                return false;

            return true;
        }

        public static bool TileBelongsToMagicStorage(Tile tile)
        {
            ModLoader.TryGetMod("MagicStorage", out Mod mod);
            return mod != null && TileLoader.GetTile(tile.TileType)?.Mod == ModLoader.GetMod("MagicStorage");
        }
    }
}
