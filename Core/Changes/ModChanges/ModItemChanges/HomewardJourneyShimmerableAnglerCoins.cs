namespace QoLCompendium.Core.Changes.ModChanges.ModItemChanges
{
    [ExtendsFromMod(ModConditions.homewardJourneyName)]
    [JITWhenModsEnabled(ModConditions.homewardJourneyName)]
    public class HomewardJourneyShimmerableAnglerCoins : GlobalItem
    {
        public override void SetStaticDefaults()
        {
            if (QoLCompendium.crossModConfig.ShimmerableAnglerCoins)
                ItemID.Sets.ShimmerTransformToItem[Common.GetModItem(ModConditions.homewardJourneyMod, "AnglerGoldCoin")] = Common.GetModItem(ModConditions.homewardJourneyMod, "AnglerCoin");
        }
    }
}
