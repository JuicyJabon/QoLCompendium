using QoLCompendium.Content.Projectiles.MobileStorages;

namespace QoLCompendium.Content.Items.MobileStorages
{
    public class FlyingSafe : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MoneyTrough);
            Item.shoot = ModContent.ProjectileType<FlyingSafeProj>();
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.MobileStorages)
            {
                CreateRecipe()
                .AddIngredient(ItemID.Safe, 1)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }
    }
}
