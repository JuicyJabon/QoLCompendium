﻿using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Staves
{
    public class StaffOfAshing : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.RegrowthStaves;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 25;
            Item.useTime = 13;
            Item.autoReuse = true;
            Item.width = 24;
            Item.height = 28;
            Item.damage = 7;
            Item.createTile = TileID.AshGrass;
            Item.UseSound = SoundID.Item1;
            Item.knockBack = 3f;
            Item.SetShopValues(ItemRarityColor.Orange3, Item.sellPrice(0, 0, 50));
            Item.DamageType = DamageClass.Melee;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine placeable = tooltips.Find(l => l.Name == "Placeable");
            TooltipLine text = new(Mod, "StaffOfAshingEffect", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.StaffOfAshingPlaceable"));
            tooltips.Insert(tooltips.IndexOf(placeable), text);
            tooltips.RemoveAll((x) => x.Name == "Placeable" && x.Mod == "Terraria");

            TooltipChanges.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.RegrowthStaves);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.RegrowthStaves, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.AshWood, 12);
            r.AddIngredient(ItemID.AshBlock, 3);
            r.AddIngredient(ItemID.AshGrassSeeds, 1);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
