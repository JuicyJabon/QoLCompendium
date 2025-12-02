namespace QoLCompendium.Core.PermanentBuffSystems
{
    [Autoload(false)]
    class CombinedBuffItem(string name, Dictionary<BuffEffect, int> buffs, string displayName, string texturePath) : ModItem, ILocalizedModType
    {
        public Dictionary<BuffEffect, int> buffs = buffs;
        private string name = name;
        private string displayName = displayName;
        private string texturePath = texturePath;

        public Dictionary<BuffEffect, int> BuffTypes;

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
            BuffTypes = buffs;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.PermanentBuffs);
        }
    }
}
