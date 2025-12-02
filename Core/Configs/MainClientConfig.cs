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
            White = 0,
            Red = 1,
            Orange = 2,
            Yellow = 3,
            Green = 4,
            Lime = 5,
            Blue = 6,
            Cyan = 7,
            SkyBlue = 8,
            Purple = 9,
            Magenta = 10,
            Pink = 11,
            Rainbow = 12
        }

        public override void OnLoaded()
        {
            QoLCompendium.mainClientConfig = this;
        }
    }
}
