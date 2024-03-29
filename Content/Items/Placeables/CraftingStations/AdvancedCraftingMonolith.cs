using QoLCompendium.Content.Tiles.CraftingStations;
using QoLCompendium.Core;

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
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.CraftingStations, Type);
            r.AddIngredient(ItemID.BoneWelder);
            r.AddIngredient(ItemID.GlassKiln);
            r.AddIngredient(ItemID.HoneyDispenser);
            r.AddIngredient(ItemID.IceMachine);
            r.AddIngredient(ItemID.LivingLoom);
            r.AddIngredient(ItemID.SkyMill);
            r.AddIngredient(ItemID.Solidifier);
            r.AddIngredient(ItemID.TeaKettle);
            r.AddIngredient(ItemID.AlchemyTable);
            r.AddIngredient(ItemID.TinkerersWorkshop);
            r.AddIngredient(ItemID.ImbuingStation);
            r.AddIngredient(ItemID.DyeVat);
            r.AddIngredient(ItemID.Hellforge);
            r.AddIngredient(ItemID.LavaBucket);
            r.AddIngredient(ItemID.HoneyBucket);
            r.AddRecipeGroup(nameof(ItemID.Tombstone));
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
