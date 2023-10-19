using Microsoft.Xna.Framework;
using QoLCompendium.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items.MobileStorages
{
    public class AllInOneAccess : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(4, 8));
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            /*
            Item.width = 16;
            Item.height = 22;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = new SoundStyle?(SoundID.MenuTick);
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.value = Item.sellPrice(gold: 1);
            */
            Item.CloneDefaults(ItemID.MoneyTrough);
            Item.shoot = ModContent.ProjectileType<WeightlessSafeProj>();
        }

        public override void UpdateInventory(Player player)
        {
            player.IsVoidVaultEnabled = true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo s, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
        {
            Projectile.NewProjectile(player.GetSource_ItemUse(Item, "AllInOneAccessUsed"), player.Center.X - 48f, player.Center.Y - 24f, 0f, 0f, ModContent.ProjectileType<DefendersCatalystProj>(), 0, 0f, player.whoAmI, 0f, 0f, 0f);
            Projectile.NewProjectile(player.GetSource_ItemUse(Item, "AllInOneAccessUsed"), player.Center.X + 96f, player.Center.Y - 24f, 0f, 0f, 525, 0, 0f, player.whoAmI, 0f, 0f, 0f);
            Projectile.NewProjectile(player.GetSource_ItemUse(Item, "AllInOneAccessUsed"), player.Center.X + 48f, player.Center.Y - 24f, 0f, 0f, ModContent.ProjectileType<WeightlessSafeProj>(), 0, 0f, player.whoAmI, 0f, 0f, 0f);
            Projectile.NewProjectile(player.GetSource_ItemUse(Item, "AllInOneAccessUsed"), player.Center.X - 96f, player.Center.Y - 24f, 0f, 0f, 734, 0, 0f, player.whoAmI, 0f, 0f, 0f);
            return false;
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.MobileStorages)
            {
                CreateRecipe()
                .AddIngredient(ItemID.MoneyTrough, 1)
                .AddIngredient<DefendersCatalyst>(1)
                .AddIngredient<WeightlessSafe>(1)
                .AddIngredient(ItemID.VoidLens, 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
            }
        }
    }
}
