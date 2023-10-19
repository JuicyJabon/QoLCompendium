using QoLCompendium.Tweaks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace QoLCompendium.Items.BossAndEventSummons
{
    public class MothronSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 14;
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 21;
            Item.height = 11;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Yellow;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(NPCID.Mothron);
        }

        public override bool? UseItem(Player player)
        {
            NetcodeBossSpawn.SpawnBossNetcoded(player, NPCID.Mothron);
            return true;
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.BossSummoners)
            {
                CreateRecipe()
                .AddIngredient(ItemID.LunarTabletFragment, 5)
                .AddCondition(Condition.DownedPlantera)
                .AddTile(TileID.MythrilAnvil)
                .Register();
            }
        }
    }
}
