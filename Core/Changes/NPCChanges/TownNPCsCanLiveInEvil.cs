using MonoMod.Cil;

namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class TownNPCsCanLiveInEvil : ModSystem
    {
        public override bool IsLoadingEnabled(Mod mod) => QoLCompendium.mainConfig.TownNPCsLiveInEvil;

        public override void Load()
        {
            if (ModConditions.vanillaQoLLoaded)
                return;

            IL_WorldGen.ScoreRoom += LiveInCorrupt;
        }

        public override void Unload()
        {
            IL_WorldGen.ScoreRoom -= LiveInCorrupt;
        }

        public static void LiveInCorrupt(ILContext il)
        {
            var ilCursor = new ILCursor(il);
            if (!ilCursor.TryGotoNext(MoveType.After, i => i.MatchCall<WorldGen>("GetTileTypeCountByCategory")))
                return;

            ilCursor.Index++;
            ilCursor.EmitPop();
            ilCursor.Remove();
        }
    }
}
