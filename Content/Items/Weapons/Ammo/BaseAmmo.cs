using QoLCompendium.Content.Items.Weapons.Ammo.Rockets;

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
            if (QoLCompendium.itemConfig.EndlessAmmo)
            {
                int amount = Item.type == ModContent.ItemType<EndlessMiniNukeIPouch>() || Item.type == ModContent.ItemType<EndlessMiniNukeIIPouch>() ? 2 : 1;
                CreateRecipe(amount)
                    .AddIngredient(AmmunitionItem, 3996)
                    .AddTile(TileID.CrystalBall)
                    .Register();
            }
        }
    }
}
