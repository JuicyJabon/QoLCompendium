using QoLCompendium.Tweaks;

namespace QoLCompendium.Items.Mirrors
{
    public class TempleMirror : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MagicMirror);
            Item.rare = ItemRarityID.Yellow;
        }

        public override bool? UseItem(Player player)
        {
            if (Main.myPlayer == player.whoAmI)
            {
                TeleportClass.HandleTeleport(1);
                return true;
            }
            return false;
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.Mirrors)
            {
                CreateRecipe()
                .AddIngredient(ItemID.Glass, 3)
                .AddIngredient(ItemID.LunarTabletFragment, 2)
                .AddRecipeGroup(RecipeGroupID.IronBar, 4)
                .AddTile(TileID.Tombstones)
                .Register();
            }
        }
    }
}
