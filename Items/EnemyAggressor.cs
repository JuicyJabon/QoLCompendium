using QoLCompendium.Tweaks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    // Token: 0x02000020 RID: 32
    public class EnemyAggressor : ModItem
    {
        // Token: 0x060000C9 RID: 201 RVA: 0x0000F92E File Offset: 0x0000DB2E
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<QoLCConfig>().Erasers;
        }

        // Token: 0x060000CA RID: 202 RVA: 0x0000F93A File Offset: 0x0000DB3A
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Favorite this item to increase enemy spawns by 10x");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        // Token: 0x060000CB RID: 203 RVA: 0x0000F964 File Offset: 0x0000DB64
        public override void SetDefaults()
        {
            Item.width = 27;
            Item.height = 27;
            Item.noUseGraphic = true;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.HiddenAnimation;
            Item.rare = ItemRarityID.Blue;
        }

        // Token: 0x060000CC RID: 204 RVA: 0x0000F9C8 File Offset: 0x0000DBC8
        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<EnemyAggressor>(), 1).AddIngredient(ItemID.FlinxFur, 2).AddIngredient(ItemID.Hay, 4).AddIngredient(ItemID.RubyGemsparkBlock, 20).AddTile(TileID.Anvils).Register();
        }

        // Token: 0x060000CD RID: 205 RVA: 0x0000FA04 File Offset: 0x0000DC04
        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.GetModPlayer<QolCPlayer>().enemyAggressor = true;
            }
        }
    }
}
