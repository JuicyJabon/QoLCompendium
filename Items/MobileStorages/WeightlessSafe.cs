using QoLCompendium.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items.MobileStorages
{
    public class WeightlessSafe : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MoneyTrough);
            Item.shoot = ModContent.ProjectileType<WeightlessSafeProj>();
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
