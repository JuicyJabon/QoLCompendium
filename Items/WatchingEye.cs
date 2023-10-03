﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class WatchingEye : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 9;
            Item.height = 14;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = new SoundStyle?(SoundID.MenuTick);
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.value = Item.sellPrice(silver: 80);
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.WatchingEye)
            {
                CreateRecipe()
                .AddIngredient(ItemID.Lens, 4)
                .AddIngredient(ItemID.Emerald, 1)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }

        public override bool? UseItem(Player player)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                for (int i = 0; i < Main.maxTilesX; i++)
                {
                    for (int j = 0; j < Main.maxTilesY; j++)
                    {
                        if (WorldGen.InWorld(i, j))
                        {
                            Main.Map.Update(i, j, 255);
                        }
                    }
                }
                Main.refreshMap = true;
            }
            else
            {
                Point center = Main.LocalPlayer.Center.ToTileCoordinates();
                int range = 300;
                for (int i = center.X - range / 2; i < center.X + range / 2; i++)
                {
                    for (int j = center.Y - range / 2; j < center.Y + range / 2; j++)
                    {
                        if (WorldGen.InWorld(i, j))
                        {
                            Main.Map.Update(i, j, 255);
                        }
                    }
                }

                Main.refreshMap = true;
            }
            return true;
        }
    }
}
