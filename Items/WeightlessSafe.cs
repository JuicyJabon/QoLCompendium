using QoLCompendium.Projectiles;
using QoLCompendium.Tweaks;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class WeightlessSafe : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MoneyTrough);
            Item.shoot = ModContent.ProjectileType<WeightlessSafeProj>();
        }

        public override void AddRecipes()
        {
            if (ModContent.GetInstance<ItemConfig>().MobileStorages)
            {
                CreateRecipe()
                .AddIngredient(ItemID.Safe, 1)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }
    }
}
