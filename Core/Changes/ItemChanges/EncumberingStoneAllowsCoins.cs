﻿namespace QoLCompendium.Core.Changes.ItemChanges
{
    public class EncumberingStoneAllowsCoins : ModPlayer
    {
        public override void PostUpdateMiscEffects()
        {
            for (int i = 0; i < Common.CoinIDs.Count; i++)
                ItemID.Sets.IgnoresEncumberingStone[i] = QoLCompendium.mainConfig.EncumberingStoneAllowsCoins;
        }
    }
}
