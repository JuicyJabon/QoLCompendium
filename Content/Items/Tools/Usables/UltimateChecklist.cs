using QoLCompendium.Core;
using Terraria.Enums;
using Terraria.GameContent.Creative;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class UltimateChecklist : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 15;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item4;
            Item.useAnimation = 20;
            Item.useTime = 20;

            Item.SetShopValues(ItemRarityColor.TrashMinus1, Item.buyPrice(0, 0, 0, 0));
        }

        public override bool? UseItem(Player player)
        {
            for (int i = 0; i < ItemLoader.ItemCount; i++)
                CreativeUI.ResearchItem(i);
            return true;
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.UltimateChecklist, Type);
            r.AddIngredient(ItemID.LunarBar, 12);
            r.AddIngredient(ItemID.Silk, 8);
            r.AddIngredient(ItemID.BlackDye, 1);
            r.AddTile(TileID.LunarCraftingStation);
            r.Register();
        }
    }
}
