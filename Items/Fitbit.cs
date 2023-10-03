﻿using QoLCompendium.Tweaks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class Fitbit : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
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
            if (QoLCompendium.itemConfig.InformationAccessories)
            {
                CreateRecipe()
                .AddIngredient(ModContent.ItemType<Kettlebell>(), 1)
                .AddIngredient(ModContent.ItemType<ReinforcedPanel>(), 1)
                .AddIngredient(ModContent.ItemType<WingTimer>(), 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
            }
        }

        public override void UpdateInfoAccessory(Player player)
        {
            player.GetModPlayer<QoLCPlayer>().kettlebell = true;
            player.GetModPlayer<QoLCPlayer>().reinforcedPanel = true;
            player.GetModPlayer<QoLCPlayer>().wingTimer = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<QoLCPlayer>().kettlebell = true;
            player.GetModPlayer<QoLCPlayer>().reinforcedPanel = true;
            player.GetModPlayer<QoLCPlayer>().wingTimer = true;
        }
    }
}
