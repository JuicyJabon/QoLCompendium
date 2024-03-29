using QoLCompendium.Content.Projectiles.Explosives;
using QoLCompendium.Core;

namespace QoLCompendium.Content.Items.Tools.Explosives
{
    public class HellevatorCreator : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 13;
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
            Item.shoot = ModContent.ProjectileType<HellevatorCreatorProj>();
            Item.shootSpeed = 5f;
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.AutoStructures, Type);
            r.AddIngredient(ItemID.Dynamite, 25);
            r.AddIngredient(ItemID.Diamond, 5);
            r.AddRecipeGroup(RecipeGroupID.IronBar, 3);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
