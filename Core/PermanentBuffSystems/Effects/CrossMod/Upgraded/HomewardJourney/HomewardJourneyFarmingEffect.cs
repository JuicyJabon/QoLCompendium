using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.HomewardJourney;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.HomewardJourney
{
    public class HomewardJourneyFarmingEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.homewardJourneyLoaded)
                return;

            new FluorescentBerryEffect().ApplyEffect(player);
            new ReanimationEffect().ApplyEffect(player);
            new YangEffect().ApplyEffect(player);
            new YinEffect().ApplyEffect(player);
        }
    }
}
