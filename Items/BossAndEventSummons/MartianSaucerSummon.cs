using QoLCompendium.Tweaks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace QoLCompendium.Items.BossAndEventSummons
{
    public class MartianSaucerSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 16;
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 15;
            Item.height = 12;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Yellow;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(NPCID.MartianSaucerCore);
        }

        public override bool? UseItem(Player player)
        {
            NetcodeBossSpawn.SpawnBossNetcoded(player, NPCID.MartianSaucerCore);
            return true;
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.BossSummoners)
            {
                CreateRecipe()
                .AddIngredient(ItemID.Wire, 5)
                .AddRecipeGroup(RecipeGroupID.IronBar, 3)
                .AddCondition(Condition.DownedMartians)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }
    }
}
