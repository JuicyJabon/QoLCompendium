using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Catalyst;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.CalamityEntropy;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.Clamity;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.Calamity
{
    public class CalamityEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.calamityLoaded)
                return;

            new CalamityAbyssEffect().ApplyEffect(player);
            new CalamityArenaEffect().ApplyEffect(player);
            new CalamityDamageEffect().ApplyEffect(player);
            new CalamityDefenseEffect().ApplyEffect(player);
            new CalamityFarmingEffect().ApplyEffect(player);
            new CalamityMovementEffect().ApplyEffect(player);

            if (ModConditions.catalystLoaded)
                new AstracolaEffect().ApplyEffect(player);

            if (ModConditions.clamityAddonLoaded)
                new ClamityEffect().ApplyEffect(player);

            if (ModConditions.calamityEntropyLoaded)
                new CalamityEntropyEffect().ApplyEffect(player);
        }
    }
}
