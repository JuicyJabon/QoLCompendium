using QoLCompendium.Content.Projectiles.MobileStorages;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.MobileStorages
{
    public class FlyingSafe : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.MobileStorages;

        public new string LocalizationCategory => "Items.Tools.MobileStorages";

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MoneyTrough);
            Item.shoot = ModContent.ProjectileType<FlyingSafeProjectile>();

            Item.SetShopValues(ItemRarityColor.Orange3, Item.buyPrice(0, 2, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.MobileStorages);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.MobileStorages, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.Safe);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
