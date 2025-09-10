using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Thorium;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.ThoriumBossRework;
using ThoriumRework;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.Thorium
{
    public class ThoriumBardEffect : IPermanentModdedBuff
    {
        [JITWhenModsEnabled(ModConditions.thoriumBossReworkName)]
        public static bool ThoriumReworkPotionsEnabled => ModContent.GetInstance<CompatConfig>().extraPotions;

        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.thoriumLoaded)
                return;

            new CreativityEffect().ApplyEffect(player);
            new EarwormEffect().ApplyEffect(player);
            new InspirationalReachEffect().ApplyEffect(player);

            if (!ModConditions.thoriumBossReworkLoaded)
                return;
            if (!ThoriumReworkPotionsEnabled)
                return;

            new DeathsingerEffect().ApplyEffect(player);
            new InspirationRegenerationEffect().ApplyEffect(player);
        }
    }
}
