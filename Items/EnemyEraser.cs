using QoLCompendium.Tweaks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class EnemyEraser : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<ItemConfig>().Erasers;
        }

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 21;
            Item.height = 20;
            Item.noUseGraphic = true;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.HiddenAnimation;
            Item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<EnemyEraser>(), 1).AddIngredient(ItemID.VilePowder, 5).AddIngredient(ItemID.RubyGemsparkBlock, 20).AddTile(TileID.Anvils).Register();
            Recipe.Create(ModContent.ItemType<EnemyEraser>(), 1).AddIngredient(ItemID.ViciousPowder, 5).AddIngredient(ItemID.RubyGemsparkBlock, 20).AddTile(TileID.Anvils).Register();
        }

        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.GetModPlayer<QoLCPlayer>().enemyEraser = true;
            }
        }
    }
}
