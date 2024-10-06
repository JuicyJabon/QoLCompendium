using QoLCompendium.Core;
using QoLCompendium.Core.UI.Panels;
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
            if (player.GetModPlayer<QoLCPlayer>().selectedBiome == 0)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.DestinationGlobe.NoModifier"));

            if (player.GetModPlayer<QoLCPlayer>().selectedBiome == 1)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.DestinationGlobe.Desert"));

            if (player.GetModPlayer<QoLCPlayer>().selectedBiome == 2)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.DestinationGlobe.Snow"));

            if (player.GetModPlayer<QoLCPlayer>().selectedBiome == 3)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.DestinationGlobe.Jungle"));

            if (player.GetModPlayer<QoLCPlayer>().selectedBiome == 4)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.DestinationGlobe.GlowingMushroom"));

            if (player.GetModPlayer<QoLCPlayer>().selectedBiome == 5)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.DestinationGlobe.Corruption"));

            if (player.GetModPlayer<QoLCPlayer>().selectedBiome == 6)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.DestinationGlobe.Crimson"));

            if (player.GetModPlayer<QoLCPlayer>().selectedBiome == 7 && Main.hardMode)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.DestinationGlobe.Hallow"));

            if (player.GetModPlayer<QoLCPlayer>().selectedBiome == 8)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.DestinationGlobe.Purity"));

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
