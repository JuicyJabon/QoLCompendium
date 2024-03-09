using QoLCompendium.Content.Projectiles.MobileStorages;

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
            Item.shoot = ModContent.ProjectileType<EtherianConstructProj>();
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
