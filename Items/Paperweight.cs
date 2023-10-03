using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class Paperweight : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 13;
            Item.height = 11;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(gold: 1);
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.Paperweight)
            {
                CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.IronBar, 1)
                .AddIngredient(ItemID.Glass, 5)
                .AddTile(TileID.GlassKiln)
                .Register();
            }
        }

        public override void UpdateInventory(Player player)
        {
            if (Item.favorited && !Main.playerInventory)
            {
                player.controlUseItem = true;
            }
        }
    }
}
