using System;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace QoLCompendium.Items
{
    // Token: 0x02000024 RID: 36
    public class HallowGlobe : ModItem
    {
        // Token: 0x060000E1 RID: 225 RVA: 0x0000F3CD File Offset: 0x0000D5CD
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<QoLCConfig>().Globes;
        }

        // Token: 0x060000E2 RID: 226 RVA: 0x0000FF0C File Offset: 0x0000E10C
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Favorite this item to always be in the hallow biome");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        // Token: 0x060000E3 RID: 227 RVA: 0x0000FF34 File Offset: 0x0000E134
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.noUseGraphic = true;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.HiddenAnimation;
            Item.rare = ItemRarityID.Blue;
        }

        // Token: 0x060000E4 RID: 228 RVA: 0x0000FF98 File Offset: 0x0000E198
        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<HallowGlobe>(), 1).AddIngredient(ItemID.Glass, 15).AddIngredient(ItemID.PearlstoneBlock, 5).AddIngredient(ItemID.Pearlwood, 5).AddTile(TileID.Anvils).Register();
        }

        // Token: 0x060000E5 RID: 229 RVA: 0x0000FFD4 File Offset: 0x0000E1D4
        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.ZoneHallow = true;
            }
        }
    }
}
