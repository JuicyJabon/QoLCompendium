using QoLCompendium.Content.Tiles.CraftingStations;
using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.CraftingStations
{
    public class SpecializedCraftingMonolith : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.CraftingStations;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<SpecializedMonolithTile>());
            Item.SetShopValues(ItemRarityColor.Orange3, Item.buyPrice(0, 10, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipChanges.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.CraftingStations);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.CraftingStations, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
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
            r.AddIngredient(ItemID.WaterBucket);
            r.AddIngredient(ItemID.LavaBucket);
            r.AddIngredient(ItemID.HoneyBucket);
            r.AddRecipeGroup("QoLCompendium:AnyTombstone");
            r.Register();
        }
    }
}
