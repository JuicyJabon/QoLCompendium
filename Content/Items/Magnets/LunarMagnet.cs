using QoLCompendium.Core;
using QoLCompendium.Core.Changes;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Magnets
{
    public class LunarMagnet : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 13;
            Item.height = 13;
            Item.maxStack = 1;

            Item.SetShopValues(ItemRarityColor.StrongRed10, Item.buyPrice(0, 8, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipChanges.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.Magnets);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.Magnets, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<SpectreMagnet>());
            r.AddIngredient(ItemID.LunarBar, 10);
            r.AddTile(TileID.LunarCraftingStation);
            r.Register();
        }

        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.GetModPlayer<QoLCPlayer>().activeItems.Add(Item.type);
                player.GetModPlayer<MagnetPlayer>().LunarMagnet = true;
            }
        }
    }
}
