using SOTS.Items.Void;

namespace QoLCompendium.Core.Changes.ItemChanges
{
    public class ItemChanges : GlobalItem
    {
        public override void Load()
        {
            On_Player.ItemCheck_UseMiningTools_TryHittingWall += (orig, player, item, x, y) =>
            {
                orig.Invoke(player, item, x, y);
                if (player.itemTime == item.useTime / 2)
                    player.itemTime = (int)Math.Max(1, (1f - QoLCompendium.mainConfig.IncreaseToolSpeed) * (item.useTime / 2f));
            };
        }

        public override void SetDefaults(Item item)
        {
            if (QoLCompendium.mainConfig.NoDeveloperSetsFromBossBags && ItemID.Sets.BossBag[item.type])
                ItemID.Sets.PreHardmodeLikeBossBag[item.type] = true;

            if (QoLCompendium.mainConfig.IncreaseMaxStack > 0 && item.maxStack > 10 && item.maxStack != 100 && !item.IsACoin())
                item.maxStack = QoLCompendium.mainConfig.IncreaseMaxStack;

            if (QoLCompendium.mainConfig.StackableQuestItems && item.questItem && QoLCompendium.mainConfig.IncreaseMaxStack > 0)
                item.maxStack = QoLCompendium.mainConfig.IncreaseMaxStack;

            if (QoLCompendium.mainConfig.AutoReuseUpgrades && Common.PermanentMultiUseUpgrades.Contains(item.type))
                item.autoReuse = true;
        }

        public override void ExtractinatorUse(int extractType, int extractinatorBlockType, ref int resultType, ref int resultStack)
        {
            if (QoLCompendium.mainConfig.FasterExtractinator)
            {
                Main.LocalPlayer.itemAnimation = 1;
                Main.LocalPlayer.itemTime = 1;
                Main.LocalPlayer.itemTimeMax = 1;
            }
        }

        public override float UseTimeMultiplier(Item item, Player player)
        {
            if (item.pick > 0 || item.hammer > 0 || item.axe > 0 || item.type == ItemID.WireCutter)
                return 1f - QoLCompendium.mainConfig.IncreaseToolSpeed;
            return base.UseTimeMultiplier(item, player);
        }

        public override bool ReforgePrice(Item item, ref int reforgePrice, ref bool canApplyDiscount)
        {
            reforgePrice = (int)(reforgePrice * (1f - QoLCompendium.mainConfig.ReforgePriceChange * 0.01f));
            return true;
        }

        public override bool ConsumeItem(Item item, Player player)
        {
            if (CrossModSupport.SecretsOfTheShadows.Loaded)
                if (item.IsAVoidConsumable())
                    return base.ConsumeItem(item, player);

            if (item.consumable == true && item.damage == -1 && item.stack >= QoLCompendium.mainConfig.EndlessItemAmount && QoLCompendium.mainConfig.EndlessConsumables)
                return false;

            if (item.consumable == true && item.damage > 0 && item.stack >= QoLCompendium.mainConfig.EndlessWeaponAmount && QoLCompendium.mainConfig.EndlessWeapons)
                return false;

            return base.ConsumeItem(item, player);
        }

        public override bool CanBeConsumedAsAmmo(Item ammo, Item weapon, Player player)
        {
            if (ammo.ammo > AmmoID.None && ammo.stack >= QoLCompendium.mainConfig.EndlessAmmoAmount && QoLCompendium.mainConfig.EndlessAmmo)
                return false;

            return base.CanBeConsumedAsAmmo(ammo, weapon, player);
        }

        public override bool? CanConsumeBait(Player player, Item bait)
        {
            if (bait.bait > 0 && bait.stack >= QoLCompendium.mainConfig.EndlessBaitAmount && QoLCompendium.mainConfig.EndlessBait)
                return false;

            return base.CanConsumeBait(player, bait);
        }
    }

    [JITWhenModsEnabled(CrossModSupport.SecretsOfTheShadows.Name)]
    [ExtendsFromMod(CrossModSupport.SecretsOfTheShadows.Name)]
    public static class IsVoidConsumable
    {
        public static bool IsAVoidConsumable(this Item item)
        {
            return item.ModItem is VoidConsumable;
        }
    }
}