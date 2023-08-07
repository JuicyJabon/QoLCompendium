using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class Forwarper : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<ItemConfig>().Forwarper;
        }

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
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
        }

        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<Forwarper>(), 1).AddIngredient(ItemID.Obsidian, 4).AddIngredient(ItemID.Sapphire, 2).AddIngredient(ItemID.Amber, 2).AddTile(TileID.Anvils).Register();
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
