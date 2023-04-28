using System;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace QoLCompendium.Items
{
    // Token: 0x0200001C RID: 28
    public class CorruptionGlobe : ModItem
    {
        // Token: 0x060000B1 RID: 177 RVA: 0x0000F3CD File Offset: 0x0000D5CD
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<QoLCConfig>().Globes;
        }

        // Token: 0x060000B2 RID: 178 RVA: 0x0000F3D9 File Offset: 0x0000D5D9
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Favorite this item to always be in the corruption biome");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        // Token: 0x060000B3 RID: 179 RVA: 0x0000F404 File Offset: 0x0000D604
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

        // Token: 0x060000B4 RID: 180 RVA: 0x0000F468 File Offset: 0x0000D668
        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<CorruptionGlobe>(), 1).AddIngredient(ItemID.Glass, 15).AddIngredient(ItemID.EbonstoneBlock, 5).AddIngredient(ItemID.Ebonwood, 5).AddTile(TileID.Anvils).Register();
        }

        // Token: 0x060000B5 RID: 181 RVA: 0x0000F4A1 File Offset: 0x0000D6A1
        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.ZoneCorrupt = true;
            }
        }
    }
}
