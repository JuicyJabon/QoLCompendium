﻿using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using QoLCompendium.Core.UI.Other;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Accessories.InformationAccessories
{
    public class Replenisher : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.InformationAccessories;
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 9;
            Item.height = 15;
            Item.maxStack = 1;
            Item.accessory = true;

            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 3, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipChanges.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.InformationAccessories);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.InformationAccessories, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.ManaCrystal, 1);
            r.AddRecipeGroup(RecipeGroupID.IronBar, 8);
            r.AddIngredient(ItemID.Glass, 5);
            r.Register();
            r.AddTile(TileID.Anvils);
        }

        public override void UpdateInfoAccessory(Player player)
        {
            player.GetModPlayer<InfoPlayer>().replenisher = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<InfoPlayer>().replenisher = true;
        }
    }
}
