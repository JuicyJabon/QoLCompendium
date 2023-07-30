using Terraria;
using Terraria.GameContent.Events;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    public class SkipDD2Wave : GlobalTile
    {
        public override void RightClick(int i, int j, int type)
        {
            if (ModContent.GetInstance<QoLCConfig>().SkipWave)
            {
                if (type == 466 && DD2Event.Ongoing && NPC.waveNumber > 1 && DD2Event.TimeLeftBetweenWaves > 1)
                {
                    DD2Event.TimeLeftBetweenWaves = 1;
                }
            }
        }
    }
}
