using QoLCompendium.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    public class RecipeChanges : ModSystem
    {
        public override void PostAddRecipes()
        {
            if (!QoLCompendium.mainConfig.ExtraPhoneInfo)
            {
                return;
            }
            // Disables PDA recipes
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (recipe.HasIngredient(ItemID.GPS) && recipe.HasIngredient(ItemID.FishFinder)
                    && recipe.HasIngredient(ItemID.GoblinTech) && recipe.HasIngredient(ItemID.REK)
                    && (!recipe.HasIngredient<Fitbit>() || !recipe.HasIngredient<HeartbeatSensor>() || !recipe.HasIngredient<ToleranceDetector>() || !recipe.HasIngredient<VitalDisplay>())
                    && recipe.HasTile(TileID.TinkerersWorkbench)
                    && recipe.HasResult(ItemID.PDA))
                {
                    recipe.DisableRecipe();
                }
            }
        }

        public override void AddRecipes()
        {
            if (!QoLCompendium.mainConfig.ExtraPhoneInfo)
            {
                return;
            }

            // Re-ads PDA recipe with new info accessories
            Recipe pda = Recipe.Create(ItemID.PDA);
            pda.AddIngredient(ItemID.GPS);
            pda.AddIngredient(ItemID.FishFinder);
            pda.AddIngredient(ItemID.GoblinTech);
            pda.AddIngredient(ItemID.REK);
            pda.AddIngredient<Fitbit>();
            pda.AddIngredient<HeartbeatSensor>();
            pda.AddIngredient<ToleranceDetector>();
            pda.AddIngredient<VitalDisplay>();
            pda.AddTile(TileID.TinkerersWorkbench);
            pda.Register();
        }
    }
}
