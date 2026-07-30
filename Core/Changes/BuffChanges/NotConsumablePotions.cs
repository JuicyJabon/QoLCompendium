namespace QoLCompendium.Core.Changes.BuffChanges
{
    public class NotConsumablePotions : GlobalItem
    {
        public override bool ConsumeItem(Item item, Player player)
        {
            if (QoLCompendium.mainConfig.EndlessPotionBuffs)
            {
                bool isBuff = item.buffTime > 0;
                bool isSpecialBuffItem = item.type is ItemID.RecallPotion or ItemID.TeleportationPotion or ItemID.WormholePotion or ItemID.PotionOfReturn or ItemID.GenderChangePotion or ItemID.RedPotion;
                bool isModdedSpecialBuffItem = item.type == Common.GetModItem(CrossModSupport.Calamity.Mod, "TheElixir");

                if ((isBuff || isSpecialBuffItem || isModdedSpecialBuffItem) && item.stack >= QoLCompendium.mainConfig.EndlessBuffAmount)
                    return false;
            }

            if (QoLCompendium.mainConfig.EndlessHealing)
            {
                bool isHealing = item.healLife > 0 || item.healMana > 0;

                if (isHealing && item.stack >= QoLCompendium.mainConfig.EndlessHealingAmount)
                    return false;
            }

            return base.ConsumeItem(item, player);
        }
    }
}
