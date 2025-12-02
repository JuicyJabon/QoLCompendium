using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.FavoriteEffect
{
    public class EclipsePedestal : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.MoonPedestals;

        public new string LocalizationCategory => "Items.Tools.FavoriteEffect";

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 20;
            Item.maxStack = 1;
            Item.consumable = false;

            Item.SetShopValues(ItemRarityColor.Pink5, Item.buyPrice(0, 2, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.MoonPedestals);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.MoonPedestals, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.GrayBrick, 10);
            r.AddIngredient(ItemID.StoneBlock, 4);
            r.AddIngredient(ItemID.SunplateBlock, 4);
            r.AddIngredient(ItemID.HallowedBar, 5);
            r.AddTile(TileID.MythrilAnvil);
            r.Register();
        }

        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.GetModPlayer<QoLCPlayer>().activeItems.Add(Item.type);
                player.GetModPlayer<QoLCPlayer>().eclipsePedestal = true;
            }
        }
    }
}
