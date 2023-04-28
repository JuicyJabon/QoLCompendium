using System;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace QoLCompendium.Items
{
    // Token: 0x0200001D RID: 29
    public class CrimsonGlobe : ModItem
    {
        // Token: 0x060000B7 RID: 183 RVA: 0x0000F3CD File Offset: 0x0000D5CD
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<QoLCConfig>().Globes;
        }

        // Token: 0x060000B8 RID: 184 RVA: 0x0000F4BF File Offset: 0x0000D6BF
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Favorite this item to always be in the crimson biome");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        // Token: 0x060000B9 RID: 185 RVA: 0x0000F4E8 File Offset: 0x0000D6E8
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

        // Token: 0x060000BA RID: 186 RVA: 0x0000F54C File Offset: 0x0000D74C
        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<CrimsonGlobe>(), 1).AddIngredient(ItemID.Glass, 15).AddIngredient(ItemID.CrimstoneBlock, 5).AddIngredient(ItemID.Shadewood, 5).AddTile(TileID.Anvils).Register();
        }

        // Token: 0x060000BB RID: 187 RVA: 0x0000F588 File Offset: 0x0000D788
        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.ZoneCrimson = true;
            }
        }
    }
}
