using QoLCompendium.Tweaks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class BattalionLog : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<ItemConfig>().InformationAccessories;
        }

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
            Item.value = Item.sellPrice(gold: 3);
        }

        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<BattalionLog>(), 1).AddIngredient(ItemID.BambooBlock, 4).AddIngredient(ItemID.Wood, 2).AddRecipeGroup(RecipeGroupID.IronBar, 2).AddTile(TileID.Anvils).Register();
        }

        public override void UpdateInventory(Player player)
        {
            player.GetModPlayer<QoLCPlayer>().battalionLog = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<QoLCPlayer>().battalionLog = true;
        }
    }
}
