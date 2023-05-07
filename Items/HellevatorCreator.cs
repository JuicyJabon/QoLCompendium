using QoLCompendium.Projectiles;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    // Token: 0x02000026 RID: 38
    public class HellevatorCreator : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<QoLCConfig>().HCreator;
        }

        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Creates a drill bomb that carves a hellevator \nWill destroy anything in it's path directly below the impact");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        // Token: 0x060000EF RID: 239 RVA: 0x000100E8 File Offset: 0x0000E2E8
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

        // Token: 0x060000F0 RID: 240 RVA: 0x000101A6 File Offset: 0x0000E3A6
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.Dynamite, 25).AddIngredient(ItemID.Diamond, 5).AddRecipeGroup(RecipeGroupID.IronBar, 5).AddTile(TileID.Anvils).Register();
        }
    }
}
