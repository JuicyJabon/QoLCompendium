using QoLCompendium.UI;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class MoonPhaser : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 8;
            Item.height = 23;
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
            if (ModContent.GetInstance<ItemConfig>().MoonPedestals)
            {
                CreateRecipe()
                .AddIngredient(ItemID.StoneBlock, 5)
                .AddIngredient(ItemID.Diamond, 2)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }

        public override bool? UseItem(Player player)
        {
            if (!MoonChangeUI.visible) MoonChangeUI.timeStart = Main.GameUpdateCount;
            MoonChangeUI.visible = true;

            return base.UseItem(player);
        }
    }
}
