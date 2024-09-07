﻿using QoLCompendium.Core;

namespace QoLCompendium.Content.Items.Tools.FavoriteEffect
{
    public class PausePedestal : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 10;
            Item.height = 18;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(silver: 90);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.MoonPedestals, Type);
            r.AddIngredient(ItemID.GrayBrick, 10);
            r.AddIngredient(ItemID.Ruby, 4);
            r.AddTile(TileID.Anvils);
            r.Register();
        }

        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.GetModPlayer<QoLCPlayer>().pausePedestal = true;
            }
        }
    }
}
