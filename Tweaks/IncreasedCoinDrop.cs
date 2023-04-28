using Terraria;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    public class IncreasedCoinDrop : GlobalNPC
    {
        public override void SetDefaults(NPC npc)
        {
            npc.value *= ModContent.GetInstance<QoLCConfig>().MoreCoins;
        }
    }
}
