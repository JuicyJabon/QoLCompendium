namespace QoLCompendium.Content.Items.Tools.Magnets
{
    public abstract class BaseMagnet : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.Magnets;

        public new string LocalizationCategory => "Items.Tools.Magnets";
        
        public abstract bool Enabled { get; set; }

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 13;
            Item.height = 13;
            Item.maxStack = 1;
        }

        public override void OnConsumeItem(Player player) => Item.stack++;

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            SoundEngine.PlaySound(SoundID.Unlock, player.Center);
            Enabled = !Enabled;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Enabled)
            {
                var tooltipActive = new TooltipLine(Mod, "Active", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.Active")) { OverrideColor = Common.ColorSwap(Color.Lime, Color.YellowGreen, 3) };
                Common.AddLastTooltip(tooltips, tooltipActive);
            }
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.Magnets);
        }
    }
}
