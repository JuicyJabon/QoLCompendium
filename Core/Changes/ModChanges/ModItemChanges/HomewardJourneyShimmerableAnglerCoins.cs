namespace QoLCompendium.Core.Changes.ModChanges.ModItemChanges
{
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    public class HomewardJourneyShimmerableAnglerCoins : GlobalItem
    {
        public override void SetStaticDefaults()
        {
            if (QoLCompendium.crossModConfig.ShimmerableAnglerCoins)
                ItemID.Sets.ShimmerTransformToItem[Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "AnglerGoldCoin")] = Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "AnglerCoin");
        }
    }
}
