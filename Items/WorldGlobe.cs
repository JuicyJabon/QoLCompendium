using QoLCompendium.Tweaks;
using QoLCompendium.UI;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class WorldGlobe : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<QoLCConfig>().Globes;
        }

        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Favorite this item to always be in the selected biome");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = new SoundStyle?(SoundID.MenuTick);
            Item.useAnimation = 20;
            Item.useTime = 20;
        }

        public override bool? UseItem(Player player)
        {
            if (!GlobeUI.visible) GlobeUI.timeStart = Main.GameUpdateCount;
            GlobeUI.visible = true;

            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<WorldGlobe>(), 1).AddIngredient(ItemID.Glass, 15).AddIngredient(ItemID.DirtBlock, 5).AddIngredient(ItemID.GrassSeeds, 5).AddTile(TileID.Anvils).AddIngredient(ItemID.WaterBucket, 1).Register();
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
            }
        }
    }
}
