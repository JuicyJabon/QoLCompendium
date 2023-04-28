using System;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace QoLCompendium.Items
{
    // Token: 0x02000028 RID: 40
    public class JungleGlobe : ModItem
    {
        // Token: 0x060000F8 RID: 248 RVA: 0x0000F3CD File Offset: 0x0000D5CD
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<QoLCConfig>().Globes;
        }

        // Token: 0x060000F9 RID: 249 RVA: 0x000102BE File Offset: 0x0000E4BE
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Favorite this item to always be in the jungle biome");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        // Token: 0x060000FA RID: 250 RVA: 0x000102E8 File Offset: 0x0000E4E8
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

        // Token: 0x060000FB RID: 251 RVA: 0x0001034C File Offset: 0x0000E54C
        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<JungleGlobe>(), 1).AddIngredient(ItemID.Glass, 15).AddIngredient(ItemID.MudBlock, 5).AddIngredient(ItemID.RichMahogany, 5).AddTile(TileID.Anvils).Register();
        }

        // Token: 0x060000FC RID: 252 RVA: 0x00010388 File Offset: 0x0000E588
        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.ZoneJungle = true;
            }
        }
    }
}
