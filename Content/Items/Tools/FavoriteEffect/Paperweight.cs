using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.FavoriteEffect
{
    public class Paperweight : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.Paperweight;

        public new string LocalizationCategory => "Items.Tools.FavoriteEffect";

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 11;
            Item.height = 8;
            Item.maxStack = 1;

            Item.SetShopValues(ItemRarityColor.Green2, Item.buyPrice(0, 1, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.Paperweight);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.Paperweight, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddRecipeGroup(RecipeGroupID.IronBar, 6);
            r.AddIngredient(ItemID.Glass, 5);
            r.AddTile(TileID.Anvils);
            r.Register();
        }

        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.GetModPlayer<QoLCPlayer>().activeItems.Add(Item.type);
                if (!Main.playerInventory)
                    player.controlUseItem = true;
            }
        }
    }
}
