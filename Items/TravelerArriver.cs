using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class TravelerArriver : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<ItemConfig>().TArriver;
        }

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 21;
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
            Recipe.Create(ModContent.ItemType<TravelerArriver>(), 1).AddIngredient(ItemID.GraniteBlock, 4).AddIngredient(ItemID.Ruby, 2).AddIngredient(ItemID.Feather, 1).AddTile(TileID.Anvils).Register();
        }

        public override bool? UseItem(Player player)
        {
            NPC.SpawnOnPlayer(Main.myPlayer, NPCID.TravellingMerchant);
            return NPC.CountNPCS(NPCID.TravellingMerchant) < 5;
        }
    }
}
