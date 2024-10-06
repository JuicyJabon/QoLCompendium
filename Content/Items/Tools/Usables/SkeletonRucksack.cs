using QoLCompendium.Core;
using QoLCompendium.Core.Changes;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class SkeletonRucksack : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 13;
            Item.height = 17;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item4;
            Item.useAnimation = 20;
            Item.useTime = 20;

            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 0, 75, 0));
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.SkeletonRucksack, Type);
            r.AddIngredient(ItemID.Leather, 8);
            r.AddTile(TileID.Loom);
            r.Register();
        }

        public override bool? UseItem(Player player)
        {
            if (NPC.CountNPCS(NPCID.SkeletonMerchant) < 1)
            {
                NetcodeBossSpawn.SpawnBossNetcoded(player, NPCID.SkeletonMerchant);
            }
            return true;
        }
    }
}
