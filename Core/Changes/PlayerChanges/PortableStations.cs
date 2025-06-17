using Mono.Cecil.Cil;
using MonoMod.Cil;

namespace QoLCompendium.Core.Changes.PlayerChanges
{
    public class PortableStations : ModSystem
    {
        /*
        public override void Load()
        {
            IL_Player.AdjTiles += AddPortableStations;
        }

        private void AddPortableStations(ILContext il)
        {
            var c = new ILCursor(il);
            if (!c.TryGotoNext(MoveType.Before, i => i.MatchLdsfld<Main>(nameof(Main.playerInventory))))
                return;
            c.Emit(OpCodes.Ldarg_0);
            c.EmitDelegate<Action<Player>>(player =>
            {
                if (!QoLCompendium.mainConfig.PortableCraftingStations)
                    return;

                CheckStations(player.inventory);
            });
        }

        private static void CheckStations(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                int tileType = item.createTile;
                if (tileType > -1 && tileType < TileLoader.TileCount)
                {
                    CheckChainedStations(tileType, Main.LocalPlayer);
                }

                if (item.type is ItemID.WaterBucket or ItemID.BottomlessBucket)
                {
                    Main.LocalPlayer.adjWater = true;
                }

                if (item.type is ItemID.LavaBucket or ItemID.BottomlessLavaBucket)
                {
                    Main.LocalPlayer.adjLava = true;
                }

                if (item.type is ItemID.HoneyBucket or ItemID.BottomlessHoneyBucket)
                {
                    Main.LocalPlayer.adjHoney = true;
                }

                for (int i = 0; i < Main.recipe.Length; i++)
                {
                    if (tileType > -1 && Main.recipe[i].HasTile(tileType))
                    {
                        Main.LocalPlayer.adjTile[tileType] = true;
                    }
                }
            }
        }

        private static void CheckChainedStations(int tileType, Player player)
        {
            player.adjTile[tileType] = true;
            if (TileID.Sets.CountsAsWaterSource[tileType])
            {
                player.adjWater = true;
            }

            if (TileID.Sets.CountsAsLavaSource[tileType])
            {
                player.adjLava = true;
            }

            if (TileID.Sets.CountsAsHoneySource[tileType])
            {
                player.adjHoney = true;
            }

            if (TileID.Sets.CountsAsShimmerSource[tileType])
            {
                player.adjShimmer = true;
            }

            switch (tileType)
            {
                case TileID.Hellforge:
                case TileID.GlassKiln:
                    player.adjTile[TileID.Furnaces] = true;
                    break;
                case TileID.AdamantiteForge:
                    player.adjTile[TileID.Furnaces] = true;
                    player.adjTile[TileID.Hellforge] = true;
                    break;
                case TileID.MythrilAnvil:
                    player.adjTile[TileID.Anvils] = true;
                    break;
                case TileID.BewitchingTable:
                case TileID.Tables2:
                case TileID.PicnicTable:
                    player.adjTile[TileID.Tables] = true;
                    break;
                case TileID.AlchemyTable:
                    player.adjTile[TileID.Bottles] = true;
                    player.adjTile[TileID.Tables] = true;
                    player.alchemyTable = true;
                    break;
            }

            TileLoader.AdjTiles(player, tileType);
        }
        */
    }
}
