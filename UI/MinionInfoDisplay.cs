using Microsoft.Xna.Framework;
using QoLCompendium.Tweaks;
using System;
using Terraria;
using Terraria.ModLoader;

namespace QoLCompendium.UI
{
    // Token: 0x02000005 RID: 5
    public class MinionInfoDisplay : InfoDisplay
    {
        // Token: 0x0600003B RID: 59 RVA: 0x000022EF File Offset: 0x000004EF
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Minion Slots");
        }

        // Token: 0x0600003C RID: 60 RVA: 0x00002301 File Offset: 0x00000501
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<QolCPlayer>().headCounter;
        }

        // Token: 0x0600003D RID: 61 RVA: 0x00002314 File Offset: 0x00000514
        public override string DisplayValue(ref Color displayColor)/* tModPorter Suggestion: Set displayColor to InactiveInfoTextColor if your display value is "zero"/shows no valuable information */
        {
            Player localPlayer = Main.LocalPlayer;
            return Math.Round((double)localPlayer.slotsMinions, 2).ToString() + " / " + localPlayer.maxMinions.ToString() + " Minion Slots";
        }
    }
}
