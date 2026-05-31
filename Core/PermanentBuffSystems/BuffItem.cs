namespace QoLCompendium.Core.PermanentBuffSystems
{
    [Autoload(false)]
    class BuffItem(string name, int buffID, BuffEffect effect, int itemID, int ingredientCount, string displayName) : ModItem, ILocalizedModType
    {
        private int buffID = buffID;
        private int itemID = itemID;
        private int ingredientCount = ingredientCount;
        public BuffEffect effect = effect;
        private string name = name;
        private readonly string displayName = displayName;

        public int BuffType;

        protected override bool CloneNewInstances => true;
        public override string Texture => BuffUtils.BuffAsset(buffID);
        public override LocalizedText Tooltip => LocalizedText.Empty;
        public override string Name => name;

        public new string LocalizationCategory => "Items.PermanentBuffs";

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            ItemUtils.SetDefaultsToPermanentBuff(Item);
            BuffType = buffID;
        }

        public override void AddRecipes()
        {
            Recipe r = RecipeUtils.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(itemID, ingredientCount);
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            //if (!Item.IsBuffItemFromSupportedMod())
                //Item.SetNameOverride(displayName);

            ItemUtils.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.PermanentBuffs);
            TooltipLine material = tooltips.Find(l => l.Name == "Material");
            TooltipLine text = new(Mod, "BuffDescription", Main.GetBuffTooltip(Main.LocalPlayer, buffID));
            if (material != null)
                tooltips.AddAfter(material, text);
        }
    }
}
