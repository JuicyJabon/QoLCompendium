using Terraria.GameContent.Events;

namespace QoLCompendium.Items.Tools
{
    public class Forwarper : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 13;
            Item.height = 12;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = new SoundStyle?(SoundID.MenuTick);
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.value = Item.sellPrice(silver: 90);
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.Forwarper)
            {
                CreateRecipe()
                .AddIngredient(ItemID.Obsidian, 4)
                .AddIngredient(ItemID.Sapphire, 2)
                .AddIngredient(ItemID.Amber, 2)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }

        public override bool? UseItem(Player player)
        {
            if (Main.dayTime)
            {
                Main.dayTime = false;
                Main.time = 0.0;
                BirthdayParty.CheckMorning();
                Chest.SetupTravelShop();
            }
            else
            {
                Main.dayTime = true;
                Main.time = 0.0;
                BirthdayParty.CheckNight();
                if (!Main.dayTime && ++Main.moonPhase > 7)
                {
                    Main.moonPhase = 0;
                }
            }
            return new bool?(true);
        }
    }
}
