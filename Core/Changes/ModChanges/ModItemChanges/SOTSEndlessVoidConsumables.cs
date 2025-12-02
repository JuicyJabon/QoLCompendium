using MonoMod.RuntimeDetour;
using SOTS.Items.Void;
using System.Reflection;

namespace QoLCompendium.Core.Changes.ModChanges.ModItemChanges
{
    [JITWhenModsEnabled(ModConditions.secretsOfTheShadowsName)]
    [ExtendsFromMod(ModConditions.secretsOfTheShadowsName)]
    public class SOTSEndlessVoidConsumables : GlobalItem
    {
        public delegate bool Orig_VoidConsumable(VoidConsumable self);

        private static readonly MethodInfo VoidConsumableConsumeMethod = typeof(VoidConsumable).GetMethod("ConsumeStack", Common.UniversalBindingFlags);

        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.ModItem is VoidConsumable;
        }

        public override void Load()
        {
            Hook voidConsumable = new(VoidConsumableConsumeMethod, new Func<Orig_VoidConsumable, VoidConsumable, bool>(ConsumeStack_Detour));
            voidConsumable.Apply();
            Common.detours.Add(voidConsumable);
        }

        internal static bool ConsumeStack_Detour(Orig_VoidConsumable orig, VoidConsumable self)
        {
            if (self.Item.consumable == true && self.Item.stack >= QoLCompendium.crossModConfig.EndlessVoidConsumablesAmount && QoLCompendium.crossModConfig.EndlessVoidConsumables)
                return false;
            return true;
        }
    }
}
