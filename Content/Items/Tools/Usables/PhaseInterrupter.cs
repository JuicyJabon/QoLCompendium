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
            if (QoLCompendium.itemConfig.PhaseInterrupter)
            {
                CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.IronBar, 7)
                .AddIngredient(ItemID.Diamond, 3)
                .AddIngredient(ItemID.BlackLens, 1)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }

        public override bool? UseItem(Player player)
        {
            if (!MoonChangeUI.visible) MoonChangeUI.timeStart = Main.GameUpdateCount;
            MoonChangeUI.visible = true;

            return base.UseItem(player);
        }
    }
}
