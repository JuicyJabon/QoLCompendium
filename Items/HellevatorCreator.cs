using QoLCompendium.Projectiles;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class HellevatorCreator : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 13;
            Item.height = 31;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = new SoundStyle?(SoundID.Item1);
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<HellevatorCreatorProj>();
            Item.shootSpeed = 5f;
        }

        public override void AddRecipes()
        {
            if (ModContent.GetInstance<ItemConfig>().AutoStructures)
            {
                CreateRecipe()
                .AddIngredient(ItemID.Dynamite, 25)
                .AddIngredient(ItemID.Diamond, 5)
                .AddIngredient(ItemID.IronBar, 2)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }
    }
}
