using QoLCompendium.Content.Items.InformationAccessories;
using QoLCompendium.Core;
using QoLCompendium.Core.Changes;
using QoLCompendium.Core.UI.Other;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Accessories
{
    public class AnglersDream : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 17;
            Item.maxStack = 1;
            Item.SetShopValues(ItemRarityColor.Yellow8, Item.buyPrice(0, 8, 0, 0));
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //Lavaproof Tackle Bag
            player.accFishingLine = true;
            player.accTackleBox = true;
            player.fishingSkill += 10;
            player.accLavaFishing = true;

            //Bobbers
            player.accFishingBobber = true;

            //Sonar Device
            player.sonarPotion = true;

            //Angler Radar
            player.GetModPlayer<InfoPlayer>().anglerRadar = true;
        }

        public override void UpdateInfoAccessory(Player player)
        {
            player.GetModPlayer<InfoPlayer>().anglerRadar = true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipChanges.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.FishingAccessories);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.FishingAccessories, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.LavaproofTackleBag);
            r.AddRecipeGroup("QoLCompendium:FishingBobbers");
            r.AddIngredient(ModContent.ItemType<SonarDevice>());
            r.AddIngredient(ModContent.ItemType<AnglerRadar>());
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
