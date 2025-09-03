using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using QoLCompendium.Core.UI.Panels;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.FavoriteEffect
{
    public class DestinationGlobe : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.DestinationGlobe;

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

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.DestinationGlobe);
        }

        public override bool? UseItem(Player player)
        {
            if (!DestinationGlobeUI.visible) DestinationGlobeUI.timeStart = Main.GameUpdateCount;
            DestinationGlobeUI.visible = true;

            return base.UseItem(player);
        }

        public override bool CanUseItem(Player player)
        {
            if (DestinationGlobeUI.visible)
                return false;
            else
                return true;
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.DestinationGlobe, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.Glass, 15);
            r.AddIngredient(ItemID.DirtBlock, 5);
            r.AddIngredient(ItemID.GrassSeeds, 5);
            r.AddIngredient(ItemID.WaterBucket, 1);
            r.AddTile(TileID.Anvils);
            r.Register();
        }

        public override void UpdateInventory(Player player)
        {
            Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.DestinationGlobe.Biome" + player.GetModPlayer<QoLCPlayer>().selectedBiome.ToString()));

            if (Item.favorited)
            {
                player.GetModPlayer<QoLCPlayer>().activeItems.Add(Item.type);

                if (player.GetModPlayer<QoLCPlayer>().selectedBiome == 1)
                    player.ZoneDesert = true;

                if (player.GetModPlayer<QoLCPlayer>().selectedBiome == 2)
                    player.ZoneSnow = true;

                if (player.GetModPlayer<QoLCPlayer>().selectedBiome == 3)
                    player.ZoneJungle = true;

                if (player.GetModPlayer<QoLCPlayer>().selectedBiome == 4)
                    player.ZoneGlowshroom = true;

                if (player.GetModPlayer<QoLCPlayer>().selectedBiome == 5)
                    player.ZoneCorrupt = true;

                if (player.GetModPlayer<QoLCPlayer>().selectedBiome == 6)
                    player.ZoneCrimson = true;

                if (player.GetModPlayer<QoLCPlayer>().selectedBiome == 7 && Main.hardMode)
                    player.ZoneHallow = true;

                if (player.GetModPlayer<QoLCPlayer>().selectedBiome == 8)
                    player.ZonePurity = true;
            }
        }
    }
}
