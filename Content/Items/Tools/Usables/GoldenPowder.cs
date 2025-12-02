using QoLCompendium.Content.Projectiles.Other;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class GoldenPowder : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.GoldenPowder;

        public new string LocalizationCategory => "Items.Tools.Usables";

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.consumable = true;
            Item.maxStack = Item.CommonMaxStack;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.shootSpeed = 4f;
            Item.shoot = ModContent.ProjectileType<GoldenPowderProjectile>();
            Item.useStyle = ItemUseStyleID.Swing;
            Item.width = 11;
            Item.height = 26;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = true;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.SetShopValues(ItemRarityColor.White0, Item.sellPrice(0, 0, 10, 0));
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.GoldenPowder, Type, 10, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.PurificationPowder, 10);
            r.AddIngredient(ItemID.GoldCoin);
            r.AddTile(TileID.Bottles);
            r.Register();
        }
    }
}
