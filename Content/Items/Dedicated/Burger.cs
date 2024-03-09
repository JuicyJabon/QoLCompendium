using QoLCompendium.Content.Tiles.Dedicated;

namespace QoLCompendium.Content.Items.Dedicated
{
    public class Burger : ModItem
    {
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new(Mod, "Dedicated", "Dedicated - BladeBurger")
            {
                OverrideColor = new Color(255, 0, 0)
            };
            tooltips.Add(line);
        }

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.width = 8;
            Item.height = 8;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.UseSound = SoundID.Item2;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.Green;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.noMelee = true;
            Item.value = Item.sellPrice(gold: 1);
            Item.createTile = ModContent.TileType<BurgerTile>();
        }
    }
}
