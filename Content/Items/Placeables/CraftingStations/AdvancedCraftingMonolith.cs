using QoLCompendium.Content.Tiles.CraftingStations;

namespace QoLCompendium.Content.Items.Placeables.CraftingStations
{
    public class AdvancedCraftingMonolith : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 10;
            Item.height = 16;
            Item.maxStack = Item.CommonMaxStack;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = Item.buyPrice(gold: 30);
            Item.createTile = ModContent.TileType<AdvancedCraftingMonolithTile>();
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.CraftingStations)
            {
                CreateRecipe()
                .AddIngredient(ItemID.BoneWelder)
                .AddIngredient(ItemID.GlassKiln)
                .AddIngredient(ItemID.HoneyDispenser)
                .AddIngredient(ItemID.IceMachine)
                .AddIngredient(ItemID.LivingLoom)
                .AddIngredient(ItemID.SkyMill)
                .AddIngredient(ItemID.Solidifier)
                .AddIngredient(ItemID.TeaKettle)
                .AddIngredient(ItemID.AlchemyTable)
                .AddIngredient(ItemID.TinkerersWorkshop)
                .AddIngredient(ItemID.ImbuingStation)
                .AddIngredient(ItemID.DyeVat)
                .AddIngredient(ItemID.Hellforge)
                .AddIngredient(ItemID.LavaBucket)
                .AddIngredient(ItemID.HoneyBucket)
                .AddRecipeGroup(nameof(ItemID.Tombstone))
                .AddTile(TileID.Anvils)
                .Register();
            }
        }
    }
}
