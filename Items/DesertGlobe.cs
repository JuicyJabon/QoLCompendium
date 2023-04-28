using System;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace QoLCompendium.Items
{
    // Token: 0x0200001F RID: 31
    public class DesertGlobe : ModItem
    {
        // Token: 0x060000C3 RID: 195 RVA: 0x0000F3CD File Offset: 0x0000D5CD
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<QoLCConfig>().Globes;
        }

        // Token: 0x060000C4 RID: 196 RVA: 0x0000F850 File Offset: 0x0000DA50
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Favorite this item to always be in the desert biome");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        // Token: 0x060000C5 RID: 197 RVA: 0x0000F878 File Offset: 0x0000DA78
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

        // Token: 0x060000C6 RID: 198 RVA: 0x0000F8DC File Offset: 0x0000DADC
        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<DesertGlobe>(), 1).AddIngredient(ItemID.Glass, 15).AddIngredient(ItemID.SandBlock, 5).AddIngredient(ItemID.Cactus, 5).AddTile(TileID.Anvils).Register();
        }

        // Token: 0x060000C7 RID: 199 RVA: 0x0000F918 File Offset: 0x0000DB18
        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.ZoneDesert = true;
            }
        }
    }
}
