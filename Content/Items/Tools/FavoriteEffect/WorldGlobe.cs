using QoLCompendium.Core;
using QoLCompendium.Core.UI;

namespace QoLCompendium.Content.Items.Tools.FavoriteEffect
{
    public class WorldGlobe : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = new SoundStyle?(SoundID.MenuOpen);
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.value = Item.sellPrice(gold: 2);
        }

        public override bool? UseItem(Player player)
        {
            if (!WorldGlobeUI.visible)
                WorldGlobeUI.visible = true;

            return base.UseItem(player);
        }

        public override bool CanUseItem(Player player)
        {
            if (WorldGlobeUI.visible)
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
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.WorldGlobe, Type);
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
                if (player.GetModPlayer<QoLCPlayer>().selectedBiome == 1)
                {
                    player.ZoneDesert = true;
                }

                if (player.GetModPlayer<QoLCPlayer>().selectedBiome == 2)
                {
                    player.ZoneSnow = true;
                }

                if (player.GetModPlayer<QoLCPlayer>().selectedBiome == 3)
                {
                    player.ZoneJungle = true;
                }

                if (player.GetModPlayer<QoLCPlayer>().selectedBiome == 4)
                {
                    player.ZoneGlowshroom = true;
                }

                if (player.GetModPlayer<QoLCPlayer>().selectedBiome == 5)
                {
                    player.ZoneCorrupt = true;
                }

                if (player.GetModPlayer<QoLCPlayer>().selectedBiome == 6)
                {
                    player.ZoneCrimson = true;
                }

                if (player.GetModPlayer<QoLCPlayer>().selectedBiome == 7 && Main.hardMode)
                {
                    player.ZoneHallow = true;
                }

                if (player.GetModPlayer<QoLCPlayer>().selectedBiome == 8)
                {
                    player.ZonePurity = true;
                }
            }
        }
    }
}
