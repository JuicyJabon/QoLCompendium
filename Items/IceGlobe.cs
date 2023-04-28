using System;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace QoLCompendium.Items
{
    // Token: 0x02000027 RID: 39
    public class IceGlobe : ModItem
    {
        // Token: 0x060000F2 RID: 242 RVA: 0x0000F3CD File Offset: 0x0000D5CD
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<QoLCConfig>().Globes;
        }

        // Token: 0x060000F3 RID: 243 RVA: 0x000101DE File Offset: 0x0000E3DE
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Favorite this item to always be in the ice biome");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        // Token: 0x060000F4 RID: 244 RVA: 0x00010208 File Offset: 0x0000E408
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

        // Token: 0x060000F5 RID: 245 RVA: 0x0001026C File Offset: 0x0000E46C
        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<IceGlobe>(), 1).AddIngredient(ItemID.Glass, 15).AddIngredient(ItemID.SnowBlock, 5).AddIngredient(ItemID.IceBlock, 5).AddTile(TileID.Anvils).Register();
        }

        // Token: 0x060000F6 RID: 246 RVA: 0x000102A8 File Offset: 0x0000E4A8
        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.ZoneSnow = true;
            }
        }
    }
}
