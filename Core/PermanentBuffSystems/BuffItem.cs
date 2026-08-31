namespace QoLCompendium.Core.PermanentBuffSystems
{
    [Autoload(false)]
    class BuffItem(string name, BuffEffect effect, int itemID, int ingredientCount) : ModItem, ILocalizedModType
    {
        public int BuffType;
        public BuffEffect Effect => effect;
        protected override bool CloneNewInstances => true;
        public override string Texture => BuffUtils.BuffAsset(effect.buff);
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
            BuffType = effect.buff;
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
            TooltipLine text = new(Mod, "BuffDescription", Main.GetBuffTooltip(Main.LocalPlayer, effect.buff));
            if (material != null)
                tooltips.AddAfter(material, text);
        }
    }
}
