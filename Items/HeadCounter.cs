using QoLCompendium.Tweaks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class HeadCounter : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<ItemConfig>().HeadCounter;
        }

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 16;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
        }

        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<HeadCounter>(), 1).AddIngredient(ItemID.Glass, 5).AddRecipeGroup(RecipeGroupID.IronBar, 5).AddTile(TileID.Anvils).Register();
        }

        public override void UpdateInventory(Player player)
        {
            player.GetModPlayer<QoLCPlayer>().headCounter = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<QoLCPlayer>().headCounter = true;
        }
    }
}
