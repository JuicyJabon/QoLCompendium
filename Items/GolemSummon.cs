using QoLCompendium.Tweaks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class GolemSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 15;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 12;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Lime;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(NPCID.Golem);
        }

        public override bool? UseItem(Player player)
        {
            NetcodeBossSpawn.SpawnBossNetcoded(player, NPCID.Golem);
            return true;
        }

        public override void AddRecipes()
        {
            if (ModContent.GetInstance<ItemConfig>().BossSummoners)
            {
                CreateRecipe()
                .AddIngredient(ItemID.LunarTabletFragment, 4)
                .AddIngredient(ItemID.ChlorophyteBar, 2)
                .AddTile(TileID.LihzahrdFurnace)
                .Register();
            }
        }
    }
}
