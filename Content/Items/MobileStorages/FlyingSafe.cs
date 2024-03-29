using QoLCompendium.Content.Projectiles.MobileStorages;
using QoLCompendium.Core;

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
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.MobileStorages, Type);
            r.AddIngredient(ItemID.Safe);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
