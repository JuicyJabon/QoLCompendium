using QoLCompendium.Projectiles;

namespace QoLCompendium.Items.MobileStorages
{
    public class DefendersCatalyst : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MoneyTrough);
            Item.shoot = ModContent.ProjectileType<DefendersCatalystProj>();
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.MobileStorages)
            {
                CreateRecipe()
                .AddIngredient(ItemID.DefendersForge, 1)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }
    }
}
