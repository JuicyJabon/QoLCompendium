using Mono.Cecil.Cil;
using MonoMod.Cil;
using System.Reflection;
using Terraria.DataStructures;
using VanillaQoL.Config;

namespace QoLCompendium.Core.Changes.PlayerChanges
{
    public class VeinMiningPlayer : ModPlayer
    {
        public int ctr;
        private bool _canMine;
        private int cd;
        private int mcd;

        public static int MiningSpeed = QoLCompendium.veinminerConfig.VeinMinerSpeed;

        private readonly PriorityQueue<Point16, double> picks = new();

        public int pickPower;

        public override void Initialize()
        {
            CanMine = true;
        }

        public bool CanMine
        {
            get => _canMine;
            set
            {
                cd = 60;
                _canMine = value;
            }
        }


        public override void PreUpdate()
        {
            MiningSpeed = QoLCompendium.veinminerConfig.VeinMinerSpeed;

            var GetPickaxeDamage =
                typeof(Player).GetMethod("GetPickaxeDamage", BindingFlags.Instance | BindingFlags.NonPublic)!;
            cd--;
            mcd--;
            if (cd == 0)
            {
                CanMine = true;
            }

            if (mcd <= 0)
            {
                var success = picks.TryDequeue(out var tile, out var _);
                if (success)
                {
                    var x = tile.X;
                    var y = tile.Y;

                    int dmg = (int)GetPickaxeDamage.Invoke(Player, [x, y, pickPower, 0, Main.tile[x, y]])!;
                    if (!WorldGen.CanKillTile(x, y))
                    {
                        dmg = 0;
                    }

                    if (dmg != 0)
                    {
                        WorldGen.KillTile(tile.X, tile.Y);
                        if (Main.netMode == NetmodeID.MultiplayerClient)
                        {
                            NetMessage.SendData(MessageID.TileManipulation, number2: tile.X, number3: tile.Y);
                        }

                        mcd = MiningSpeed;
                    }
                }
            }
        }

        public void QueueTile(int x, int y)
        {
            var prio = Player.Distance(new Vector2(x * 16, y * 16));
            picks.Enqueue(new Point16(x, y), prio);
        }

        public bool NotInQueue(int x, int y)
        {
            return !Contains(picks, new Point16(x, y));
        }

        private static bool Contains<T, U>(PriorityQueue<T, U> priorityQueue, T item)
        {
            return priorityQueue.UnorderedItems.Any(el => el.Element!.Equals(item));
        }
    }

    public class VeinMiningSystem : ModSystem
    {
        public static int threshold = QoLCompendium.veinminerConfig.VeinMinerTileLimit;

        [JITWhenModsEnabled(ModConditions.vanillaQoLName)]
        public static bool VanillaQoLVeinminer => QoLConfig.Instance.veinMining;

        public override void Load()
        {
            IL_Player.PickTile += PickTilePatch;
        }

        public override void Unload()
        {
            IL_Player.PickTile -= PickTilePatch;
        }

        public override void PreUpdateWorld()
        {
            threshold = QoLCompendium.veinminerConfig.VeinMinerTileLimit;
        }

        public static void PickTilePatch(ILContext il)
        {
            var ilCursor = new ILCursor(il);
            if (!ilCursor.TryGotoNext(MoveType.Before, i => i.MatchLdarg1(),
                    i => i.MatchLdarg2(),
                    i => i.MatchLdcI4(0),
                    i => i.MatchLdcI4(0),
                    i => i.MatchLdcI4(0),
                    i => i.MatchCall<WorldGen>("KillTile")))
            {
                return;
            }

            ilCursor.EmitLdarg0();
            ilCursor.EmitCall<VeinMiningSystem>("ClearCD");
            ilCursor.EmitLdarg0();
            ilCursor.EmitLdarg1();
            ilCursor.EmitLdarg2();
            ilCursor.EmitLdarg3();
            ilCursor.EmitCall<VeinMiningSystem>("VeinMine");
        }

        public static void ClearCD(Player player)
        {
            var modPlayer = player.GetModPlayer<VeinMiningPlayer>();
            modPlayer.ctr = 0;
        }

        public static void VeinMine(Player player, int x, int y, int pickPower)
        {
            var tile = Framing.GetTileSafely(x, y);
            var modPlayer = player.GetModPlayer<VeinMiningPlayer>();

            if (tile.HasTile && CanVeinMine(tile) && modPlayer.CanMine)
            {
                modPlayer.pickPower = pickPower;
                foreach (var coords in TileRot(x, y))
                {
                    var tile2 = Framing.GetTileSafely(coords.x, coords.y);

                    bool notInQueue = modPlayer.NotInQueue(coords.x, coords.y);

                    if (tile2.HasTile && CanVeinMine(tile2) && notInQueue)
                    {
                        modPlayer.ctr++;
                        if (modPlayer.ctr > threshold)
                        {
                            modPlayer.ctr = 0;
                            modPlayer.CanMine = false;
                        }

                        modPlayer.QueueTile(coords.x, coords.y);
                        VeinMine(player, coords.x, coords.y, pickPower);
                    }
                }
            }
        }

        public static bool CanVeinMine(Tile tile)
        {
            if (VanillaQoLLoaded() || !QoLCompendium.veinminerConfig.VeinMiner)
                return false;

            if (KeybindSystem.Veinmine.Current && QoLCompendium.veinminerConfig.VeinMinerTileWhitelist != null)
            {
                string fullName = Common.GetFullNameById(tile.TileType);
                if (fullName == null)
                    return false;
                else
                {
                    if (QoLCompendium.veinminerConfig.VeinMinerTileWhitelist.Contains(fullName))
                        return true;
                }
            }
            return false;
        }

        public static IEnumerable<(int x, int y)> TileRot(int x, int y)
        {
            for (int i = x - 1; i <= x + 1; ++i)
            {
                for (int j = y - 1; j <= y + 1; ++j)
                {
                    if (i != x || j != y)
                    {
                        yield return (i, j);
                    }
                }
            }
        }

        public static bool VanillaQoLLoaded()
        {
            if (ModConditions.vanillaQoLLoaded)
            {
                if (VanillaQoLVeinminer)
                    return true;
            }
            return false;
        }
    }

    public static class VeinMinerExtension
    {
        public static ILCursor EmitCall<T>(this ILCursor ilCursor, string memberName) => ilCursor.Emit<T>(OpCodes.Call, memberName);
    }
}
