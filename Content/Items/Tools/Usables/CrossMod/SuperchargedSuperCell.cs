using CalamityMod;
using CalamityMod.Rarities;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Usables.CrossMod
{
    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public class SuperchargedSuperCell : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.CrossModItems;

        public new string LocalizationCategory => "Items.Tools.Usables";

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 11;
            Item.consumable = false;
            Item.maxStack = 1;
            Item.SetShopValues(ItemRarityColor.Orange3, Item.buyPrice(0, 1, 0, 0));
            Item.rare = ModContent.RarityType<DarkOrange>();
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.CrossModItems);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.CrossModItems, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(CrossModSupport.Calamity.Mod, "DraedonPowerCell"), 999);
            r.AddTile(Common.GetModTile(CrossModSupport.Calamity.Mod, "ChargingStation"));
            r.Register();
        }
    }

    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public class SuperchargedSuperCellPlayer : ModPlayer
    {
        public override void PostUpdateEquips()
        {
            if (Player.HasItemInAnyInventory(ModContent.ItemType<SuperchargedSuperCell>()))
                ChargeItems(Common.GetAllInventoryItemsList(Player).ToArray());
        }

        public void ChargeItems(Item[] inventory)
        {
            foreach (Item item in inventory)
            {
                if (!item.IsAir && item.Calamity().UsesCharge && item.Calamity().Charge < item.Calamity().MaxCharge)
                    item.Calamity().Charge = item.Calamity().MaxCharge;
            }
        }
    }
}