using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace QoLCompendium.Core.Configs
{
    public class TooltipConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("$Mods.QoLCompendium.ConfigHeaders.Tooltips")]

        [DefaultValue(true)]
        public bool NoFavoriteTooltip { get; set; }

        [DefaultValue(true)]
        public bool ShimmerableTooltip { get; set; }

        [DefaultValue(true)]
        public bool WorksInBanksTooltip { get; set; }

        [DefaultValue(true)]
        public bool UsedPermanentUpgradeTooltip { get; set; }

        [DefaultValue(true)]
        public bool WingStatsTooltips { get; set; }

        [DefaultValue(true)]
        public bool HookStatsTooltips { get; set; }

        [DefaultValue(true)]
        public bool AmmoTooltip { get; set; }

        [DefaultValue(true)]
        public bool ActiveTooltip { get; set; }

        [DefaultValue(true)]
        public bool NoYoyoTooltip { get; set; }

        [DefaultValue(false)]
        public bool FromModTooltip { get; set; }

        [DefaultValue(true)]
        public bool ClassTagTooltip { get; set; }

        public override void OnLoaded()
        {
            QoLCompendium.tooltipConfig = this;
        }
    }
}
