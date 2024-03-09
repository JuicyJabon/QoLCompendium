using QoLCompendium.Content.Tiles.CraftingStations;

namespace QoLCompendium.Content.Items.Placeables.CraftingStations
{
    public class AetherAltar : ModItem
    {
        public override void SetStaticDefaults()
        {
            if (WorldGen.crimson)
            {
                ItemID.Sets.ShimmerTransformToItem[Item.type] = ModContent.ItemType<CrimsonAltar>();
            }
            else
            {
                ItemID.Sets.ShimmerTransformToItem[Item.type] = ModContent.ItemType<DemonAltar>();
            }
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<AetherAltarTile>(), 0);
            Item.rare = ItemRarityID.Blue;
        }
    }
}
