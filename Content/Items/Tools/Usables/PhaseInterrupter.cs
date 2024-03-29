using QoLCompendium.Core;
using QoLCompendium.Core.UI;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class PhaseInterrupter : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 7;
            Item.height = 15;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = new SoundStyle?(SoundID.MenuTick);
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.value = Item.sellPrice(silver: 90);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.PhaseInterrupter, Type);
            r.AddRecipeGroup(RecipeGroupID.IronBar, 7);
            r.AddIngredient(ItemID.Diamond, 3);
            r.AddIngredient(ItemID.BlackLens, 1);
            r.AddTile(TileID.Anvils);
            r.Register();
        }

        public override bool? UseItem(Player player)
        {
            if (!MoonChangeUI.visible) MoonChangeUI.timeStart = Main.GameUpdateCount;
            MoonChangeUI.visible = true;

            return base.UseItem(player);
        }
    }
}
