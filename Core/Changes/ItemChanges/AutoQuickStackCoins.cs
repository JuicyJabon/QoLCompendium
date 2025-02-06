namespace QoLCompendium.Core.Changes.ItemChanges
{
    public class AutoQuickStackCoins : GlobalItem
    {
        public override bool OnPickup(Item item, Player player)
        {
            if (!QoLCompendium.mainConfig.AutoMoneyQuickStack)
                return base.OnPickup(item, player);
            return !TryDepositACoin(item, player);
        }

        public static bool TryDepositACoin(Item item, Player player)
        {
            if (!player.bank.item.Any(i =>
            {
                if (item.type is ItemID.PlatinumCoin)
                {
                    if (item.type == i.type && i.stack < i.maxStack)
                        return true;
                }
                else if (item.IsACoin)
                {
                    if (item.type == i.type)
                        return true;
                }
                return i.IsAir;
            }))
                return false;

            int type = item.type;

            if (!item.IsACoin)
                return false;

            ulong totalMoney = Common.CalculateCoinValue(type, (uint)item.stack);
            totalMoney = player.bank.item.Aggregate(totalMoney,
                (current, bItem) => current + Common.CalculateCoinValue(bItem.type, (uint)bItem.stack));

            List<Item> toPlace = Common.ConvertCopperValueToCoins(totalMoney);
            ReplaceOrPlaceIntoChest(player.bank, toPlace);

            toPlace.ForEach(coinLeft =>
            {
                if (coinLeft.IsAir) return;
                player.QuickSpawnItem(player.GetSource_DropAsItem(), coinLeft, coinLeft.stack);
            });

            PopupText.NewText(PopupTextContext.RegularItemPickup, item, item.stack);
            SoundEngine.PlaySound(SoundID.CoinPickup, player.position);
            return true;
        }

        public static void ReplaceOrPlaceIntoChest(Chest chest, List<Item> items)
        {
            var toIgnore = new List<int>();

            foreach (Item item in items)
            {
                for (int i = 0; i < chest.item.Length; i++)
                {
                    if (toIgnore.Contains(i)) continue;

                    if (chest.item[i].type == item.type)
                    {
                        chest.item[i] = item.Clone();
                        item.TurnToAir();
                        toIgnore.Add(i);
                        goto outer_end;
                    }
                }

                for (int i = 0; i < chest.item.Length; i++)
                {
                    if (toIgnore.Contains(i)) continue;

                    if (chest.item[i].stack == 0)
                    {
                        chest.item[i] = item.Clone();
                        item.TurnToAir();
                        toIgnore.Add(i);
                        goto outer_end;
                    }
                }
            outer_end:;
            }
        }
    }

    public class AutoQuickStackCoinsPlayer : ModPlayer
    {
        private int cooldown;

        public override void PostUpdate()
        {
            cooldown++;

            if (Main.myPlayer != Player.whoAmI)
                return;

            if (!QoLCompendium.mainConfig.AutoMoneyQuickStack)
                return;

            if (cooldown % 10 == 0)
                DetectCoins();
            if (cooldown % 30 == 0)
                Common.PlatinumMaxStack = new Item(ItemID.PlatinumCoin).maxStack;
        }

        private void DetectCoins()
        {
            bool isDepositSucceed = false;
            for (var i = 50; i <= 53; i++)
            {
                var item = Player.inventory[i];
                if (!item.IsAir && item.IsACoin && AutoQuickStackCoins.TryDepositACoin(item, Player))
                {
                    isDepositSucceed = true;
                    item.TurnToAir();
                }
            }

            if (isDepositSucceed)
                Recipe.FindRecipes();
        }
    }
}
