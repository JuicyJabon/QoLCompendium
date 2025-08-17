using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.HomewardJourney;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.HomewardJourney
{
    public class HomewardJourneyMovementEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.homewardJourneyLoaded)
                return;

            new FlightEffect().ApplyEffect(player);
            new HasteEffect().ApplyEffect(player);
        }
    }
}
