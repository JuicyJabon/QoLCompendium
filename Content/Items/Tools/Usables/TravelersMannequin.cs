using QoLCompendium.Core;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class TravelersMannequin : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 15;
            Item.height = 23;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = new SoundStyle?(SoundID.MenuTick);
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.value = Item.sellPrice(silver: 75);
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.TravelersMannequin)
            {
                CreateRecipe()
                .AddIngredient(ItemID.Silk, 6)
                .AddIngredient(ItemID.Ruby, 2)
                .AddIngredient(ItemID.Feather, 1)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }

        public override bool? UseItem(Player player)
        {
            if (NPC.CountNPCS(NPCID.TravellingMerchant) < 1)
            {
                NetcodeBossSpawn.SpawnBossNetcoded(player, NPCID.TravellingMerchant);
            }
            return true;
        }
    }
}
