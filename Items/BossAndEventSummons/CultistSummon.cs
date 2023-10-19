using QoLCompendium.Tweaks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items.BossAndEventSummons
{
    public class CultistSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 18;
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 21;
            Item.height = 21;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Red;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(NPCID.CultistBoss);
        }

        public override bool? UseItem(Player player)
        {
            NetcodeBossSpawn.SpawnBossNetcoded(player, NPCID.CultistBoss);
            return true;
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.BossSummoners)
            {
                CreateRecipe()
                .AddIngredient(ItemID.LihzahrdBrick, 3)
                .AddIngredient(ItemID.Sapphire, 4)
                .AddTile(TileID.LihzahrdFurnace)
                .Register();
            }
        }
    }
}
