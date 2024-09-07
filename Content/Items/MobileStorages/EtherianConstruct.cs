using QoLCompendium.Content.Projectiles.MobileStorages;
using QoLCompendium.Core;

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
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.MobileStorages, Type);
            r.AddIngredient(ItemID.DefendersForge);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
