using Terraria;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    // Token: 0x0200000C RID: 12
    public class CoinGItem : GlobalItem
    {
        // Token: 0x06000057 RID: 87 RVA: 0x000050AD File Offset: 0x000032AD
        public override void UpdateInventory(Item item, Player player)
        {
            if (CoinStacker.CoinTypes.Contains(item.type) && ModContent.GetInstance<QoLCConfig>().AutoMoneyStack)
            {
                CoinStacker.Pig(player.inventory, player.bank.item);
            }
        }
    }
}
