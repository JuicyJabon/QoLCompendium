using QoLCompendium.Tweaks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class DukeSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 17;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 17;
            Item.height = 16;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Yellow;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return player.ZoneBeach && !NPC.AnyNPCs(NPCID.DukeFishron);
        }

        public override bool? UseItem(Player player)
        {
            NetcodeBossSpawn.SpawnBossNetcoded(player, NPCID.DukeFishron);
            return true;
        }

        public override void AddRecipes()
        {
            if (ModContent.GetInstance<ItemConfig>().BossSummoners)
            {
                CreateRecipe()
                .AddIngredient(ItemID.TruffleWorm, 1)
                .AddRecipeGroup(RecipeGroupID.IronBar, 3)
                .AddTile(TileID.Bottles)
                .Register();
            }
        }
    }
}
