using Terraria.GameContent.ItemDropRules;

namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class PillarEnemiesDropFragments : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if ((npc.type == NPCID.NebulaHeadcrab || npc.type == NPCID.NebulaBeast || npc.type == NPCID.NebulaBrain || npc.type == NPCID.NebulaSoldier) && QoLCompendium.mainConfig.LunarEnemiesDropFragments)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.FragmentNebula, 1, 1, 3));
            }

            if ((npc.type == NPCID.SolarCorite || npc.type == NPCID.SolarCrawltipedeHead || npc.type == NPCID.SolarSpearman || npc.type == NPCID.SolarDrakomire || npc.type == NPCID.SolarDrakomireRider || npc.type == NPCID.SolarSolenian || npc.type == NPCID.SolarSroller) && QoLCompendium.mainConfig.LunarEnemiesDropFragments)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.FragmentSolar, 1, 1, 3));
            }

            if ((npc.type == NPCID.StardustJellyfishBig || npc.type == NPCID.StardustWormHead || npc.type == NPCID.StardustCellBig || npc.type == NPCID.StardustSoldier || npc.type == NPCID.StardustSpiderBig) && QoLCompendium.mainConfig.LunarEnemiesDropFragments)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.FragmentStardust, 1, 1, 3));
            }

            if ((npc.type == NPCID.VortexHornet || npc.type == NPCID.VortexHornetQueen || npc.type == NPCID.VortexRifleman || npc.type == NPCID.VortexSoldier) && QoLCompendium.mainConfig.LunarEnemiesDropFragments)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.FragmentVortex, 1, 1, 3));
            }
        }
    }
}
