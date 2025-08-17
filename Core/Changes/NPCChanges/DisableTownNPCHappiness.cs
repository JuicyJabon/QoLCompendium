using Mono.Cecil;
using MonoMod.Cil;
using MonoMod.RuntimeDetour;
using MonoMod.Utils;

namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class DisableTownNPCHappiness : ModSystem
    {
        private Hook hook;
        private Hook hook2;

        public override void Load()
        {
            IL_Condition.cctor += il =>
            {
                var c = new ILCursor(il);
                MethodReference method = null;
                c.GotoNext(x => x.MatchLdstr("Conditions.HappyEnoughForPylons"));
                c.GotoNext(x => x.MatchLdftn(out method));
                hook = new Hook(method.ResolveReflection(), IgnoreIfUnhappy);

                c.GotoNext(x => x.MatchLdstr("Conditions.AnotherTownNPCNearby"));
                c.GotoNext(x => x.MatchLdftn(out method));
                hook2 = new Hook(method.ResolveReflection(), IgnoreIfUnhappy);
            };

            IL_Main.DrawNPCChatButtons += il =>
            {
                ILCursor c = new(il);

                if (!c.TryGotoNext(MoveType.After, x => x.MatchLdstr("UI.NPCCheckHappiness")))
                {
                    return;
                }
                c.EmitDelegate((string text) => !QoLCompendium.mainConfig.DisableHappiness ? text : "");
            };
        }

        public override void Unload()
        {
            hook?.Dispose();
            hook = null;
            hook2?.Dispose();
            hook2 = null;
        }

        private static bool IgnoreIfUnhappy(Func<object, bool> orig, object self)
        {
            return orig(self) || QoLCompendium.mainConfig.OverridePylonSales;
        }
    }

}
