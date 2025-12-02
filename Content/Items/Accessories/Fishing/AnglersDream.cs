using QoLCompendium.Core.UI.Other;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Accessories.Fishing
{
    public class AnglersDream : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.FishingAccessories;

        public new string LocalizationCategory => "Items.Accessories.Fishing";

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

            //Duplication Bobber
            player.GetModPlayer<QoLCPlayer>().duplicationBobber = true;
        }

        public override void UpdateInfoAccessory(Player player)
        {
            player.GetModPlayer<InfoPlayer>().anglerRadar = true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.FishingAccessories);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.FishingAccessories, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.LavaproofTackleBag);
            r.AddRecipeGroup("QoLCompendium:FishingBobbers");
            r.AddIngredient(ModContent.ItemType<SonarDevice>());
            r.AddIngredient(ModContent.ItemType<AnglerRadar>());
            r.AddIngredient(ModContent.ItemType<DuplicationBobber>());
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
