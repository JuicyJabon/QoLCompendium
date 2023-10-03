using QoLCompendium.Tweaks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class TempleMirror : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
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
