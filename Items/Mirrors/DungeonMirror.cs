using QoLCompendium.Tweaks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items.Mirrors
{
    public class DungeonMirror : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MagicMirror);
            Item.rare = ItemRarityID.Green;
        }

        public override bool? UseItem(Player player)
        {
            if (Main.myPlayer == player.whoAmI)
            {
                TeleportClass.HandleTeleport(0);
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
                .AddIngredient(ItemID.WaterCandle, 1)
                .AddRecipeGroup(RecipeGroupID.IronBar, 4)
                .AddTile(TileID.Tombstones)
                .Register();
            }
        }
    }
}
