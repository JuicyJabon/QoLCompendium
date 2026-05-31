using QoLCompendium.Core.Changes.ModChanges.ModItemChanges;
using Terraria.Enums;

namespace QoLCompendium.Core.QoLCUtils
{
    public static class ItemUtils
    {
        public static ulong CalculateCoinValue(int type, uint stack)
        {
            return type switch
            {
                ItemID.CopperCoin => stack * Constants.CopperValue,
                ItemID.SilverCoin => stack * Constants.SilverValue,
                ItemID.GoldCoin => stack * Constants.GoldValue,
                ItemID.PlatinumCoin => stack * Constants.PlatinumValue,
                _ => 0,
            };
        }

        public static List<Item> ConvertCopperValueToCoins(ulong value)
        {
            (ulong plat, ulong plat_rem) = Math.DivRem(value, Constants.PlatinumValue);
            (ulong gold, ulong gold_rem) = Math.DivRem(plat_rem, Constants.GoldValue);
            (ulong silver, ulong copper) = Math.DivRem(gold_rem, Constants.SilverValue);

            var toReturn = new List<Item>();

            while (plat > 0)
            {
                toReturn.Add(new Item(ItemID.PlatinumCoin, Math.Min((int)plat, Constants.PlatinumMaxStack)));
                plat -= Math.Min(plat, (ulong)Constants.PlatinumMaxStack);
            }

            toReturn.Add(new Item(ItemID.GoldCoin, (int)gold));
            toReturn.Add(new Item(ItemID.SilverCoin, (int)silver));
            toReturn.Add(new Item(ItemID.CopperCoin, (int)copper));

            return toReturn;
        }

        public static bool IsACoin(this Item item)
        {
            return item.type is >= 71 and <= 74;
        }

        public static bool IsATool(this Item item)
        {
            return item.pick > 0 || item.axe > 0 || item.hammer > 0 || item.fishingPole > 0 || (item.createTile > -1 || item.createWall > -1) && item.damage > -1;
        }

        public static bool IsArmor(this Item item)
        {
            if (item.headSlot != -1 || item.bodySlot != -1 || item.legSlot != -1)
                return !item.vanity;
            return false;
        }

        public static bool IsAnEquippable(this Item item)
        {
            /* 
             * item.accessory
             * item.IsArmor()
             * item.vanity
             * (item.buffType != 0 && Main.vanityPet[item.buffType])
             * (item.buffType != 0 && Main.lightPet[item.buffType])
             * item.mountType > -1
             * (item.shoot != ProjectileID.None && Main.projHook[item.shoot])
            */
            if (item.accessory || item.IsArmor() || item.vanity || item.mountType > -1 || item.buffType != 0 && Main.vanityPet[item.buffType] || item.buffType != 0 && Main.lightPet[item.buffType] || item.shoot != ProjectileID.None && Main.projHook[item.shoot])
                return true;
            return false;
        }

        public static bool IsAWeapon(this Item item)
        {
            /*
             * item.DamageType != null
             * !item.IsAnEquippable()
             * !item.IsATool()
             * !item.IsCurrency
            */
            if (item.DamageType != null && !item.IsAnEquippable() && !item.IsATool() && !item.IsCurrency)
                return true;
            return false;
        }

        public static void SetDefaultsToPermanentBuff(Item item)
        {
            item.width = item.height = 16;
            item.consumable = false;
            item.maxStack = 1;
            item.SetShopValues(ItemRarityColor.StrongRed10, 0);
        }

        public static void ItemDisabledTooltip(Item item, List<TooltipLine> tooltips, bool configOn)
        {
            TooltipLine name = tooltips.Find(l => l.Name == "ItemName");
            if (!configOn)
            {
                name.Text += " " + Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.ItemDisabled");
                name.OverrideColor = Color.Red;
            }

        }

        public static int GetSlotItemIsIn(Item lookForThis, Item[] inventory)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].type == lookForThis.type)
                    return i;
            }
            return -1;
        }

        public static bool CheckToActivateGlintEffect(Item item)
        {
            if (Main.gameMenu || !Main.LocalPlayer.active)
                return false;

            if (QoLCompendium.mainClientConfig.ActiveBuffsHaveEnchantedEffects && !item.IsAir && QoLCPlayer.Get(Main.LocalPlayer).activeBuffItems.Contains(item.type))
                return true;
            if (QoLCompendium.mainClientConfig.ActiveBannersHaveEnchantedEffects && !item.IsAir && QoLCPlayer.Get(Main.LocalPlayer).activeBannerItems.Contains(item.type))
                return true;
            else if (QoLCompendium.mainClientConfig.GoodPrefixesHaveEnchantedEffects && !item.IsAir && Constants.Prefixes.Contains(item.prefix))
                return true;
            else if (CrossModSupport.CalamityEntropy.Loaded && QoLCompendium.mainClientConfig.CalamityEntropyArmorPrefixesHaveEnchantedEffects)
            {
                if (!item.IsAir && CalamityEntropyArmorGlint.ArmorHasEntropyPrefix(item))
                    return true;
            }

            return false;
        }

        public static List<Item> GetAllInventoryItemsList(Player player, string ignores = "", int estimatedCapacity = 80)
        {
            ignores = ignores.Replace("portable", "inv piggy safe forge void", StringComparison.Ordinal);
            var itemList = new List<Item>(estimatedCapacity);
            var items = GetAllInventoryItems(player);
            foreach ((string name, Item[] itemArray) in items)
            {
                if (ignores.Contains(name, StringComparison.Ordinal))
                    continue;
                itemList.AddRange(itemArray);
            }

            return itemList;
        }

        public static Dictionary<string, Item[]> GetAllInventoryItems(Player player)
        {
            var items = new Dictionary<string, Item[]>
            {
                {"inv", player.inventory},
                {"piggy", player.bank.item},
                {"safe", player.bank2.item},
                {"forge", player.bank3.item},
                {"void", player.bank4.item}
            };

            return items;
        }
    }
}
