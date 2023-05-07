using QoLCompendium.Tweaks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    // Token: 0x02000021 RID: 33
    public class EnemyEraser : ModItem
    {
        // Token: 0x060000CF RID: 207 RVA: 0x0000F92E File Offset: 0x0000DB2E
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<QoLCConfig>().Erasers;
        }

        // Token: 0x060000D0 RID: 208 RVA: 0x0000FA1F File Offset: 0x0000DC1F
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Favorite this item to disable enemy spawns");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        // Token: 0x060000D1 RID: 209 RVA: 0x0000FA48 File Offset: 0x0000DC48
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

        // Token: 0x060000D2 RID: 210 RVA: 0x0000FAAC File Offset: 0x0000DCAC
        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<EnemyEraser>(), 1).AddIngredient(ItemID.VilePowder, 5).AddIngredient(ItemID.RubyGemsparkBlock, 20).AddTile(TileID.Anvils).Register();
            Recipe.Create(ModContent.ItemType<EnemyEraser>(), 1).AddIngredient(ItemID.ViciousPowder, 5).AddIngredient(ItemID.RubyGemsparkBlock, 20).AddTile(TileID.Anvils).Register();
        }

        // Token: 0x060000D3 RID: 211 RVA: 0x0000FADA File Offset: 0x0000DCDA
        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.GetModPlayer<QolCPlayer>().enemyEraser = true;
            }
        }
    }
}
