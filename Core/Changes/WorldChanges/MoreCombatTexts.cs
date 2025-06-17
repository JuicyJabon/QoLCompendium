using Mono.Cecil.Cil;
using MonoMod.Cil;

namespace QoLCompendium.Core.Changes.WorldChanges
{
    public class MoreCombatTexts : ModSystem
    {
        public override void Load()
        {
            int maximumTexts = QoLCompendium.mainClientConfig.CombatTextLimit;
            Array.Resize(ref Main.combatText, maximumTexts);
            for (int i = 0; i < maximumTexts; i++)
            {
                Main.combatText[i] = new CombatText();
            }
            On_CombatText.UpdateCombatText += delegate
            {
                for (int k = 0; k < maximumTexts; k++)
                {
                    if (Main.combatText[k].active)
                    {
                        Main.combatText[k].Update();
                    }
                }
            };
            On_CombatText.clearAll += delegate
            {
                for (int j = 0; j < maximumTexts; j++)
                {
                    Main.combatText[j].active = false;
                }
            };
            IL_CombatText.NewText_Rectangle_Color_string_bool_bool += delegate (ILContext il)
            {
                ILCursor val2 = new(il);
                while (val2.TryGotoNext((MoveType)2,
                [
                (x) => x.Match<sbyte>(OpCodes.Ldc_I4_S, 100)
                ]))
                {
                    val2.EmitDelegate((int _) => maximumTexts);
                }
            };
            IL_Main.DoDraw += delegate (ILContext il)
            {
                ILCursor val = new(il);
                while (val.TryGotoNext((MoveType)2,
                [
                (x) => x.Match<sbyte>(OpCodes.Ldc_I4_S, 100)
                ]))
                {
                    val.EmitDelegate((int _) => maximumTexts);
                }
            };
        }
    }
}
