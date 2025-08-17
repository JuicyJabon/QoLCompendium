using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.HomewardJourney;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.HomewardJourney
{
    public class HomewardJourneyArenaEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.homewardJourneyLoaded)
                return;

            new BushOfLifeEffect().ApplyEffect(player);
            new LifeLanternEffect().ApplyEffect(player);
        }
    }
}
