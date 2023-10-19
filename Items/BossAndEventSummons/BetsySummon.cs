using QoLCompendium.Tweaks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace QoLCompendium.Items.BossAndEventSummons
{
    public class BetsySummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 16;
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Yellow;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(NPCID.DD2Betsy);
        }

        public override bool? UseItem(Player player)
        {
            NetcodeBossSpawn.SpawnBossNetcoded(player, NPCID.DD2Betsy);
            return true;
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.BossSummoners)
            {
                CreateRecipe()
                .AddIngredient(ItemID.DD2ElderCrystal, 1)
                .AddIngredient(ItemID.DefenderMedal, 3)
                .AddCondition(Condition.DownedOldOnesArmyT3)
                .AddTile(TileID.MythrilAnvil)
                .Register();
            }
        }
    }
}
