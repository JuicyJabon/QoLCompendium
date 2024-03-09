using QoLCompendium.Content.Projectiles.Explosives;

namespace QoLCompendium.Content.Items.Tools.Explosives
{
    public class Lakemaker : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 19;
            Item.height = 31;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = new SoundStyle?(SoundID.Item1);
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<LakemakerProj>();
            Item.shootSpeed = 5f;
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.AutoStructures)
            {
                CreateRecipe()
                .AddIngredient(ItemID.Dynamite, 25)
                .AddIngredient(ItemID.WaterBucket, 10)
                .AddIngredient(ItemID.Diamond, 5)
                .AddRecipeGroup(RecipeGroupID.IronBar, 3)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }
    }
}
