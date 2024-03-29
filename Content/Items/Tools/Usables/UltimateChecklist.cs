using QoLCompendium.Core;
using Terraria.GameContent.Creative;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class UltimateChecklist : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 15;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.rare = ItemRarityID.Gray;
            Item.UseSound = new SoundStyle?(SoundID.Item29);
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.value = Item.sellPrice(gold: 2);
        }

        public override bool? UseItem(Player player)
        {
            for (int i = 0; i < ItemLoader.ItemCount; i++)
            {
                CreativeUI.ResearchItem(i);
            }
            return true;
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.UltimateChecklist, Type);
            r.AddIngredient(ItemID.LunarBar, 12);
            r.AddIngredient(ItemID.Silk, 6);
            r.AddIngredient(ItemID.BlackInk, 1);
            r.AddTile(TileID.LunarCraftingStation);
            r.Register();
        }
    }
}
