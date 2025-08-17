using Mono.Cecil.Cil;
using MonoMod.Cil;

namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class TownNPCsCanLiveInEvil : ModSystem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            ModLoader.TryGetMod("VanillaQoL", out Mod VanillaQoL);
            return VanillaQoL == null;
        }

        public override void Load()
        {
            IL_WorldGen.ScoreRoom += LiveInCorrupt;
        }

        public override void Unload()
        {
            IL_WorldGen.ScoreRoom -= LiveInCorrupt;
        }

        private void LiveInCorrupt(ILContext il)
        {
            var c = new ILCursor(il);
            if (!c.TryGotoNext(
                    MoveType.After,
                    i => i.MatchCall(typeof(WorldGen).GetMethod("GetTileTypeCountByCategory")),
                    i => i.Match(OpCodes.Neg),
                    i => i.Match(OpCodes.Stloc_S),
                    i => i.Match(OpCodes.Ldloc_S),
                    i => i.Match(OpCodes.Ldc_I4_S)))
                return;
            c.EmitDelegate<Func<int, int>>((returnValue) => QoLCompendium.mainConfig.TownNPCsLiveInEvil ? 114514 : returnValue);
        }
    }

}
