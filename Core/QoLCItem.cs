using QoLCompendium.Core.ShopData;

namespace QoLCompendium.Core
{
    public class QoLCItem : GlobalItem
    {
        public override void UpdateInventory(Item item, Player player)
        {
            if (item.type > ItemID.Count)
            {
                if (ShopCreation.AllShops.Any(shop => shop.Value.Any(category => category.Value.Contains(item.ModItem.Name))))
                {
                    QoLCPlayer.Get(player).ItemHasBeenOwned[item.type] = true;
                    //if (item.stack >= item.ResearchUnlockCount)
                }
            }
        }
    }
}
