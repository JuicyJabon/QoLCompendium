using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Mirrors
{
    public class WormholeMirror : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.Mirrors;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MagicMirror);
            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 2, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipChanges.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.Mirrors);
        }

        public override bool CanUseItem(Player player) => false;

        public override void Load()
        {
            On_Player.HasUnityPotion += Player_HasUnityPotion;
            On_Player.TakeUnityPotion += Player_TakeUnityPotion;
        }

        private static void Player_TakeUnityPotion(On_Player.orig_TakeUnityPotion orig, Player self)
        {
            if (self.HasItem(ModContent.ItemType<WormholeMirror>()) || self.HasItem(ModContent.ItemType<MosaicMirror>()))
                return;
            orig(self);
        }

        private static bool Player_HasUnityPotion(On_Player.orig_HasUnityPotion orig, Player self)
        {
            if (self.HasItem(ModContent.ItemType<WormholeMirror>()) || self.HasItem(ModContent.ItemType<MosaicMirror>()))
                return true;
            return orig(self);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.Mirrors, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.Glass, 10);
            r.AddRecipeGroup("QoLCompendium:GoldBars", 8);
            r.AddIngredient(ItemID.WormholePotion, 3);
            r.AddTile(TileID.Furnaces);
            r.Register();
        }
    }
}
