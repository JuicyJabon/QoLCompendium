using Terraria;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    public class SeasonalActivation : ModSystem
    {
        public override void PostUpdateWorld()
        {
            if (ModContent.GetInstance<QoLCConfig>().Halloween)
            {
                Main.halloween = true;
            }

            if (ModContent.GetInstance<QoLCConfig>().Christmas)
            {
                Main.xMas = true;
            }
        }
    }
}
