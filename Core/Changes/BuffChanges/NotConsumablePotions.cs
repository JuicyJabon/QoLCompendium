namespace QoLCompendium.Core.Changes.BuffChanges
{
    public class NotConsumablePotions : GlobalItem
    {
        public override bool ConsumeItem(Item item, Player player)
        {
            if (QoLCompendium.mainConfig.EndlessBuffs)
            {
                if (item.buffTime > 0 && item.stack >= QoLCompendium.mainConfig.EndlessBuffAmount)
                {
                    return false;
                }
                else if ((item.type == ItemID.RecallPotion || item.type == ItemID.TeleportationPotion || item.type == ItemID.WormholePotion || item.type == ItemID.PotionOfReturn || item.type == ItemID.GenderChangePotion || item.type == ItemID.RedPotion) && item.stack >= QoLCompendium.mainConfig.EndlessBuffAmount)
                {
                    return false;
                }
            }

            if (QoLCompendium.mainConfig.EndlessHealing)
            {
                if ((item.healLife > 0 || item.healMana > 0) && item.stack >= QoLCompendium.mainConfig.EndlessHealingAmount)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
