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
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.TravelersMannequin, Type);
            r.AddIngredient(ItemID.Silk, 6);
            r.AddIngredient(ItemID.Ruby, 2);
            r.AddIngredient(ItemID.Feather);
            r.AddTile(TileID.Anvils);
            r.Register();
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
