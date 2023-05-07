using QoLCompendium.Tweaks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    // Token: 0x02000029 RID: 41
    public class Magnet : ModItem
    {
        // Token: 0x060000FE RID: 254 RVA: 0x0001039E File Offset: 0x0000E59E
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<QoLCConfig>().Magnet;
        }

        // Token: 0x060000FF RID: 255 RVA: 0x000103AA File Offset: 0x0000E5AA
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Favorite this item to have infinite item grab range");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        // Token: 0x06000100 RID: 256 RVA: 0x000103D4 File Offset: 0x0000E5D4
        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.noUseGraphic = true;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.HiddenAnimation;
            Item.rare = ItemRarityID.Green;
        }

        // Token: 0x06000101 RID: 257 RVA: 0x00010438 File Offset: 0x0000E638
        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<Magnet>(), 1).AddRecipeGroup(RecipeGroupID.IronBar, 7).AddIngredient(ItemID.Sapphire, 1).AddIngredient(ItemID.Ruby, 1).AddTile(TileID.Anvils).Register();
        }

        // Token: 0x06000102 RID: 258 RVA: 0x00010473 File Offset: 0x0000E673
        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.GetModPlayer<QolCPlayer>().magnetActive = true;
            }
        }
    }
}
