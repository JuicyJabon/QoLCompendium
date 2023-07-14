using Microsoft.Xna.Framework;
using QoLCompendium.Tweaks;
using Terraria;
using Terraria.ModLoader;

namespace QoLCompendium.UI
{
    // Token: 0x02000006 RID: 6
    public class SentryInfoDisplay : InfoDisplay
    {
        // Token: 0x0600003F RID: 63 RVA: 0x0000235E File Offset: 0x0000055E
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sentry Slots");
        }

        // Token: 0x06000040 RID: 64 RVA: 0x00002301 File Offset: 0x00000501
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<QoLCPlayer>().headCounter;
        }

        // Token: 0x06000041 RID: 65 RVA: 0x00002370 File Offset: 0x00000570
        public override string DisplayValue(ref Color displayColor)/* tModPorter Suggestion: Set displayColor to InactiveInfoTextColor if your display value is "zero"/shows no valuable information */
        {
            Player localPlayer = Main.LocalPlayer;
            int num;
            UIElementsAndLayers.GetSentryNameToCount(out num, true);
            return num.ToString() + " / " + localPlayer.maxTurrets.ToString() + " Sentry Slots";
        }
    }
}
