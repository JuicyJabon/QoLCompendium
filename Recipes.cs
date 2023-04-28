using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace QoLCompendium
{
    public class Recipes : ModSystem
    {
        public override void AddRecipes()
        {
            Recipe.Create(1291, 1).AddIngredient(ItemID.ChlorophyteBar, 1).AddTile(TileID.AlchemyTable).Register();
        }
    }
}
