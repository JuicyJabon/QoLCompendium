﻿using QoLCompendium.Core;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Staves
{
    public class StaffOfOvergrownHemorrhaging : ModItem
    {
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
            Item.createTile = TileID.CrimsonJungleGrass;
            Item.UseSound = SoundID.Item1;
            Item.knockBack = 3f;
            Item.rare = ItemRarityID.Orange;
            Item.SetShopValues(ItemRarityColor.Orange3, Item.sellPrice(0, 0, 50));
            Item.DamageType = DamageClass.Melee;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine placeable = tooltips.Find(l => l.Name == "Placeable");
            TooltipLine text = new(Mod, "StaffOfOvergrownHemorrhagingEffect", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.StaffOfOvergrownHemorrhagingPlaceable"));
            tooltips.Insert(tooltips.IndexOf(placeable), text);
            tooltips.RemoveAll((x) => x.Name == "Placeable" && x.Mod == "Terraria");
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.RegrowthStaves, Type);
            r.AddIngredient(ItemID.MudBlock, 12);
            r.AddIngredient(ItemID.Vertebrae, 3);
            r.AddIngredient(ItemID.CrimsonSeeds, 1);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
