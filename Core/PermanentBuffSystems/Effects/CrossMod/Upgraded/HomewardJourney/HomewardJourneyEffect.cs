namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.HomewardJourney
{
    public class HomewardJourneyEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.homewardJourneyLoaded)
                return;

            new HomewardJourneyArenaEffect().ApplyEffect(player);
            new HomewardJourneyFarmingEffect().ApplyEffect(player);
            new HomewardJourneyMovementEffect().ApplyEffect(player);
        }
    }
}
