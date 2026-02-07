namespace QoLCompendium.Core.PermanentBuffSystems
{
    [Autoload(false)]
    class BuffItem(string name, int buffID, BuffEffect effect, int itemID, int ingredientCount, string displayName, string texturePath) : ModItem, ILocalizedModType
    {
        private int buffID = buffID;
        private int itemID = itemID;
        private int ingredientCount = ingredientCount;
        public BuffEffect effect = effect;
        private string name = name;
        private string displayName = displayName;
        private string texturePath = texturePath;

        public int BuffType;

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
            Common.SetDefaultsToPermanentBuff(Item);
            BuffType = buffID;
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(itemID, ingredientCount);
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            //if (!Item.IsBuffItemFromSupportedMod())
                //Item.SetNameOverride(displayName);

            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.PermanentBuffs);
            TooltipLine material = tooltips.Find(l => l.Name == "Material");

            if (buffID < BuffID.Count)
            {
                TooltipLine text = new(Mod, "BuffDescription", Lang.GetBuffDescription(buffID));
                
                if (material != null)
                    tooltips.AddAfter(material, text);
            }
            else
            {
                TooltipLine text = new(Mod, "BuffDescription", BuffLoader.GetBuff(buffID).Description.ToString());
                
                if (material != null)
                    tooltips.AddAfter(material, text);
            }
        }
    }
}
