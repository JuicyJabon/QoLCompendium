using QoLCompendium.Core;
using QoLCompendium.Core.UI;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.FavoriteEffect
{
    public class DestinationGlobe : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.MenuOpen;
            Item.useAnimation = 20;
            Item.useTime = 20;

            Item.SetShopValues(ItemRarityColor.Green2, Item.buyPrice(0, 2, 0, 0));
        }

        public override bool? UseItem(Player player)
        {
            if (!DestinationGlobeUI.visible)
                DestinationGlobeUI.visible = true;

            return base.UseItem(player);
        }

        public override bool CanUseItem(Player player)
        {
            if (DestinationGlobeUI.visible)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.DestinationGlobe, Type);
            r.AddIngredient(ItemID.Glass, 15);
            r.AddIngredient(ItemID.DirtBlock, 5);
            r.AddIngredient(ItemID.GrassSeeds, 5);
            r.AddIngredient(ItemID.WaterBucket, 1);
            r.AddTile(TileID.Anvils);
            r.Register();
        }

        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                if (player.GetQoLCPlayer().selectedBiome == 1)
                {
                    player.ZoneDesert = true;
                }

                if (player.GetQoLCPlayer().selectedBiome == 2)
                {
                    player.ZoneSnow = true;
                }

                if (player.GetQoLCPlayer().selectedBiome == 3)
                {
                    player.ZoneJungle = true;
                }

                if (player.GetQoLCPlayer().selectedBiome == 4)
                {
                    player.ZoneGlowshroom = true;
                }

                if (player.GetQoLCPlayer().selectedBiome == 5)
                {
                    player.ZoneCorrupt = true;
                }

                if (player.GetQoLCPlayer().selectedBiome == 6)
                {
                    player.ZoneCrimson = true;
                }

                if (player.GetQoLCPlayer().selectedBiome == 7 && Main.hardMode)
                {
                    player.ZoneHallow = true;
                }

                if (player.GetQoLCPlayer().selectedBiome == 8)
                {
                    player.ZonePurity = true;
                }
            }
        }
    }
}
