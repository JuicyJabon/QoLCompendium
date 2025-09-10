using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.Calamity;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.HomewardJourney;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.MartinsOrder;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.SOTS;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.SpiritClassic;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.Thorium;
using QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Upgraded;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.All
{
    public class EverythingEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            new VanillaEffect().ApplyEffect(player);

            if (ModConditions.calamityLoaded)
                new CalamityEffect().ApplyEffect(player);

            if (ModConditions.homewardJourneyLoaded)
                new HomewardJourneyEffect().ApplyEffect(player);

            if (ModConditions.martainsOrderLoaded)
                new MartinsOrderEffect().ApplyEffect(player);

            if (ModConditions.secretsOfTheShadowsLoaded)
                new SecretsOfTheShadowsEffect().ApplyEffect(player);

            if (ModConditions.spiritClassicLoaded)
                new SpiritClassicEffect().ApplyEffect(player);

            if (ModConditions.thoriumLoaded)
                new ThoriumEffect().ApplyEffect(player);
        }
    }
}
