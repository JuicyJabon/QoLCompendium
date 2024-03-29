﻿using QoLCompendium.Core;
using QoLCompendium.Core.UI;

namespace QoLCompendium.Content.Items.InformationAccessories
{
    public class Fitbit : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 10;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
            Item.value = Item.sellPrice(gold: 6);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.InformationAccessories, Type);
            r.AddIngredient(ModContent.ItemType<Kettlebell>());
            r.AddIngredient(ModContent.ItemType<ReinforcedPanel>());
            r.AddIngredient(ModContent.ItemType<WingTimer>());
            r.AddTile(TileID.TinkerersWorkbench);
            r.Register();
        }

        public override void UpdateInfoAccessory(Player player)
        {
            player.GetModPlayer<InfoPlayer>().kettlebell = true;
            player.GetModPlayer<InfoPlayer>().reinforcedPanel = true;
            player.GetModPlayer<InfoPlayer>().wingTimer = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<InfoPlayer>().kettlebell = true;
            player.GetModPlayer<InfoPlayer>().reinforcedPanel = true;
            player.GetModPlayer<InfoPlayer>().wingTimer = true;
        }
    }
}
