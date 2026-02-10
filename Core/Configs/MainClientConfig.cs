using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace QoLCompendium.Core.Configs
{
    public class MainClientConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("$Mods.QoLCompendium.ConfigHeaders.Player")]
        [DefaultValue(true)]
        public bool FavoriteResearching { get; set; }

        [DefaultValue(false)]
        public bool NoAuraVisuals { get; set; }

        [DefaultValue(false)]
        public bool DisableDashDoubleTap { get; set; }

        [DefaultValue(100)]
        [Range(1, 100000)]
        [ReloadRequired]
        public int CombatTextLimit { get; set; }

        [DefaultValue(0)]
        [DrawTicks]
        public ConfigGlintID GlintColor { get; set; }

        public enum ConfigGlintID
        {
            Rainbow,
            Red,
            Orange,
            Yellow,
            Green,
            Lime,
            Teal,
            Cyan,
            SkyBlue,
            Blue,
            Purple,
            Magenta,
            Pink,
            Black,
            White
        }

        public override void OnLoaded()
        {
            QoLCompendium.mainClientConfig = this;
        }
    }
}
