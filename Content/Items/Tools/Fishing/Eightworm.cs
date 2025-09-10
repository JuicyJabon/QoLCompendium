using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Fishing
{
    public class Eightworm : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.Eightworm;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 9;
            Item.bait = 100;
            Item.consumable = false;
            Item.SetShopValues(ItemRarityColor.StrongRed10, Item.buyPrice(0, 5, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.Eightworm);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.Eightworm, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.Worm, 8);
            r.AddIngredient(ItemID.PlatinumCoin, 1);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }

    public class NoBaitUse : GlobalItem
    {
        public override bool? CanConsumeBait(Player player, Item bait)
        {
            if ((player.HeldItem.type == ModContent.ItemType<LegendaryCatcher>() && bait.bait > 0) || bait.type == ModContent.ItemType<Eightworm>())
                return false;
            return base.CanConsumeBait(player, bait);
        }

        public override bool ConsumeItem(Item item, Player player)
        {
            if ((player.HeldItem.type == ModContent.ItemType<LegendaryCatcher>() && item.bait > 0) || item.type == ModContent.ItemType<Eightworm>())
                return false;
            return base.ConsumeItem(item, player);
        }
    }
}
