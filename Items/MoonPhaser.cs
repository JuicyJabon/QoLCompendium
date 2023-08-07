using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class MoonPhaser : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<ItemConfig>().MoonPhaser;
        }

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
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
            Recipe.Create(ModContent.ItemType<MoonPhaser>(), 1).AddIngredient(ItemID.StoneBlock, 5).AddIngredient(ItemID.Diamond, 2).AddTile(TileID.Anvils).Register();
        }

        public override bool? UseItem(Player player)
        {
            Main.moonPhase++;
            if (Main.moonPhase >= 8)
            {
                Main.moonPhase = 0;
            }
            return true;
        }
    }
}
