using QoLCompendium.Core;

namespace QoLCompendium.Content.Items.Weapons.Ammo
{
    public abstract class BaseAmmo : ModItem
    {
        public abstract int AmmunitionItem { get; }

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(AmmunitionItem);
            Item.width = 26;
            Item.height = 26;
            Item.consumable = false;
            Item.maxStack = 1;
            Item.value *= 3996;
            Item.rare += 1;
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.EndlessAmmo, Type);
            r.AddIngredient(AmmunitionItem, 3996);
            r.AddTile(TileID.CrystalBall);
            r.Register();
        }
    }
}
