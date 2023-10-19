using QoLCompendium.Tweaks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace QoLCompendium.Items.BossAndEventSummons
{
    public class DarkMageSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 6;
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 13;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Orange;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(NPCID.DD2DarkMageT1);
        }

        public override bool? UseItem(Player player)
        {
            NetcodeBossSpawn.SpawnBossNetcoded(player, NPCID.DD2DarkMageT1);
            return true;
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.BossSummoners)
            {
                CreateRecipe()
                .AddIngredient(ItemID.DD2ElderCrystal, 1)
                .AddIngredient(ItemID.DefenderMedal, 1)
                .AddCondition(Condition.DownedOldOnesArmyT1)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }
    }
}
