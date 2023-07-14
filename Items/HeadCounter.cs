using QoLCompendium.Tweaks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    // Token: 0x02000025 RID: 37
    public class HeadCounter : ModItem
    {
        // Token: 0x060000E7 RID: 231 RVA: 0x0000FFEA File Offset: 0x0000E1EA
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<QoLCConfig>().HeadCounter;
        }

        // Token: 0x060000E8 RID: 232 RVA: 0x0000FFF6 File Offset: 0x0000E1F6
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Displays available minion and sentry slots");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        // Token: 0x060000E9 RID: 233 RVA: 0x00010020 File Offset: 0x0000E220
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 16;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
        }

        // Token: 0x060000EA RID: 234 RVA: 0x0001007F File Offset: 0x0000E27F
        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<HeadCounter>(), 1).AddIngredient(ItemID.Glass, 5).AddRecipeGroup(RecipeGroupID.IronBar, 5).AddTile(TileID.Anvils).Register();
        }

        // Token: 0x060000EB RID: 235 RVA: 0x000100AF File Offset: 0x0000E2AF
        public override void UpdateInventory(Player player)
        {
            player.GetModPlayer<QoLCPlayer>().headCounter = true;
        }

        // Token: 0x060000EC RID: 236 RVA: 0x000100AF File Offset: 0x0000E2AF
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<QoLCPlayer>().headCounter = true;
        }
    }
}
