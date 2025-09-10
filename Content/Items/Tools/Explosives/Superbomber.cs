using QoLCompendium.Content.Projectiles.Explosives;
using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Explosives
{
    public class Superbomber : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.AutoStructures;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 29;
            Item.height = 29;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.UseSound = new SoundStyle?(SoundID.Item1);
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<SuperbomberProj>();
            Item.shootSpeed = 5f;

            Item.SetShopValues(ItemRarityColor.Green2, Item.buyPrice(0, 5, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.AutoStructures);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.AutoStructures, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.Bomb, 50);
            r.AddIngredient(ItemID.Diamond, 5);
            r.AddRecipeGroup(RecipeGroupID.IronBar, 10);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
