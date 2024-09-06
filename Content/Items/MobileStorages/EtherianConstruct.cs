using QoLCompendium.Content.Projectiles.MobileStorages;
using QoLCompendium.Core;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.MobileStorages
{
    public class EtherianConstruct : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MoneyTrough);
            Item.shoot = ModContent.ProjectileType<EtherianConstructProjectile>();

            Item.SetShopValues(ItemRarityColor.Orange3, Item.buyPrice(0, 2, 0, 0));
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.MobileStorages, Type);
            r.AddIngredient(ItemID.DefendersForge);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
