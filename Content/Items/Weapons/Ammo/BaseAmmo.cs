using QoLCompendium.Content.Items.Weapons.Ammo.Rockets;
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
            int amount = Item.type == ModContent.ItemType<EndlessMiniNukeIPouch>() || Item.type == ModContent.ItemType<EndlessMiniNukeIIPouch>() ? 2 : 1;
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.EndlessAmmo, Type, amount);
            r.AddIngredient(AmmunitionItem, 3996);
            r.AddTile(TileID.CrystalBall);
            r.Register();
        }
    }
}
