using QoLCompendium.Tweaks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items.BossAndEventSummons
{
    public class TravelerArriver : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 0;
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 15;
            Item.height = 23;
            Item.maxStack = 1;
            Item.consumable = true;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = new SoundStyle?(SoundID.MenuTick);
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.value = Item.sellPrice(silver: 75);
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.BossSummoners)
            {
                CreateRecipe()
                .AddIngredient(ItemID.GraniteBlock, 4)
                .AddIngredient(ItemID.Ruby, 2)
                .AddIngredient(ItemID.Feather, 1)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }

        public override bool? UseItem(Player player)
        {
            NetcodeBossSpawn.SpawnBossNetcoded(player, NPCID.TravellingMerchant);
            return NPC.CountNPCS(NPCID.TravellingMerchant) < 5;
        }
    }
}
