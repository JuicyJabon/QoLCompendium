namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class LunarPillarShieldHealthEdit : ModSystem
    {
        public override void PreUpdateWorld()
        {
            if (NPC.ShieldStrengthTowerVortex > QoLCompendium.mainConfig.LunarPillarShieldHeath)
                NPC.ShieldStrengthTowerVortex = QoLCompendium.mainConfig.LunarPillarShieldHeath;

            if (NPC.ShieldStrengthTowerSolar > QoLCompendium.mainConfig.LunarPillarShieldHeath)
                NPC.ShieldStrengthTowerSolar = QoLCompendium.mainConfig.LunarPillarShieldHeath;

            if (NPC.ShieldStrengthTowerNebula > QoLCompendium.mainConfig.LunarPillarShieldHeath)
                NPC.ShieldStrengthTowerNebula = QoLCompendium.mainConfig.LunarPillarShieldHeath;

            if (NPC.ShieldStrengthTowerStardust > QoLCompendium.mainConfig.LunarPillarShieldHeath)
                NPC.ShieldStrengthTowerStardust = QoLCompendium.mainConfig.LunarPillarShieldHeath;
        }
    }
}
