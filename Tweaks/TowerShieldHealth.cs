using Terraria;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    public class TowerShieldHealth : ModSystem
    {
        public override void PreUpdateWorld()
        {
            if (NPC.ShieldStrengthTowerVortex > ModContent.GetInstance<QoLCConfig>().TowerShield)
            {
                NPC.ShieldStrengthTowerVortex = ModContent.GetInstance<QoLCConfig>().TowerShield;
            }

            if (NPC.ShieldStrengthTowerSolar > ModContent.GetInstance<QoLCConfig>().TowerShield)
            {
                NPC.ShieldStrengthTowerSolar = ModContent.GetInstance<QoLCConfig>().TowerShield;
            }

            if (NPC.ShieldStrengthTowerNebula > ModContent.GetInstance<QoLCConfig>().TowerShield)
            {
                NPC.ShieldStrengthTowerNebula = ModContent.GetInstance<QoLCConfig>().TowerShield;
            }

            if (NPC.ShieldStrengthTowerStardust > ModContent.GetInstance<QoLCConfig>().TowerShield)
            {
                NPC.ShieldStrengthTowerStardust = ModContent.GetInstance<QoLCConfig>().TowerShield;
            }
        }
    }
}
