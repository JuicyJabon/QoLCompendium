namespace QoLCompendium.Content.Items.Dedicated
{
    public class GlassCannon : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.DedicatedItems;

        public new string LocalizationCategory => "Items.Dedicated";

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 11;
            Item.maxStack = 1;
            Item.accessory = true;
            Item.vanity = true;
            Item.SetShopValues(Terraria.Enums.ItemRarityColor.StrongRed10, Item.sellPrice(gold: 5));
        }

        public override void UpdateVanity(Player player)
        {
            QoLCPlayer.Get(player).glassCannon = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            QoLCPlayer.Get(player).glassCannon = true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine dedicated = new(Mod, "Dedicated", Language.GetTextValue("Mods.QoLCompendium.DedicatedTooltips.Yardis"))
            {
                OverrideColor = Common.ColorSwap(Color.Orange, Color.Yellow, 3)
            };
            tooltips.Add(dedicated);

            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.DedicatedItems);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.DedicatedItems, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.Glass, 8);
            r.AddIngredient(ItemID.Cannon);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
