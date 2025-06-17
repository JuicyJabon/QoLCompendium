using Mono.Cecil.Cil;
using MonoMod.Cil;

namespace QoLCompendium.Core.Changes.WorldChanges
{
    public class DisableWorldEvilSpread : ModSystem
    {
        public static bool CorruptionSpreadDisabled;

        public override void Load()
        {
            IL_WorldGen.UpdateWorld_Inner += new ILContext.Manipulator(WorldGen_UpdateWorld_Inner);
        }

        public override void Unload()
        {
            IL_WorldGen.UpdateWorld_Inner -= WorldGen_UpdateWorld_Inner;
        }

        private void WorldGen_UpdateWorld_Inner(ILContext il)
        {
            ILCursor ilcursor = new(il);
            Func<Instruction, bool>[] array = [(i) => i.MatchLdcI4(3), (i) => i.MatchStloc(1)];
            ilcursor.GotoNext(0, array);
            ilcursor.MoveAfterLabels();
            ilcursor.EmitDelegate(delegate ()
            {
                if (CorruptionSpreadDisabled)
                {
                    WorldGen.AllowedToSpreadInfections = false;
                }
            });
        }

        public override void ClearWorld()
        {
            CorruptionSpreadDisabled = QoLCompendium.mainConfig.DisableEvilBiomeSpread;
        }
    }
}
