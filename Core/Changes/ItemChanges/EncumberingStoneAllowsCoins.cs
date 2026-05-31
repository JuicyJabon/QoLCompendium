namespace QoLCompendium.Core.Changes.ItemChanges
{
    public class EncumberingStoneAllowsCoins : ModPlayer
    {
        public override void PostUpdateMiscEffects()
        {
            for (int i = 0; i < Constants.CoinIDs.Count; i++)
                ItemID.Sets.IgnoresEncumberingStone[Constants.CoinIDs.ElementAt(i)] = QoLCompendium.mainConfig.EncumberingStoneAllowsCoins;
        }
    }
}
