namespace QoLCompendium.Core.PermanentBuffSystems
{
    [Autoload(false)]
    class CombinedBuffItem(string name, string texturePath, List<BuffEffect> buffs, List<int> ingredients) : ModItem, ILocalizedModType
    {
        public List<BuffEffect> BuffTypes;
        protected override bool CloneNewInstances => true;
        public override string Texture => texturePath;
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
            BuffTypes = buffs;
        }

        public override void AddRecipes()
        {
            Recipe r = RecipeUtils.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            foreach (var item in ingredients)
                if (item > ItemID.None)
                    r.AddIngredient(item, 1);
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            ItemUtils.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.PermanentBuffs);
        }
    }
}
