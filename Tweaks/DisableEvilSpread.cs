using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    public class DisableEvilSpread : ModSystem
    {
        public override void Load()
        {
            IL_WorldGen.UpdateWorld_Inner += new ILContext.Manipulator(WorldGen_UpdateWorld_Inner);
        }

        private void WorldGen_UpdateWorld_Inner(ILContext il)
        {
            ILCursor ilcursor = new(il);
            ILCursor ilcursor2 = ilcursor;
            MoveType moveType = 0;
            Func<Instruction, bool>[] array = new Func<Instruction, bool>[2];
            array[0] = ((Instruction i) => ILPatternMatchingExt.MatchLdcI4(i, 3));
            array[1] = ((Instruction i) => ILPatternMatchingExt.MatchStloc(i, 1));
            ilcursor2.GotoNext(moveType, array);
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
            CorruptionSpreadDisabled = ModContent.GetInstance<QoLCConfig>().DisableEvilSpread;
        }

        public static bool CorruptionSpreadDisabled;
    }
}
