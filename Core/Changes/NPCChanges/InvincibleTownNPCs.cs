namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class InvincibleTownNPCs : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public override void SetDefaults(NPC npc)
        {
            bool dontTakeDamageFromHostiles = npc.dontTakeDamageFromHostiles;
            if (npc.type == NPCID.DD2EterniaCrystal && QoLCompendium.mainConfig.TownNPCsDontDie)
            {
                npc.dontTakeDamageFromHostiles = false;
                return;
            }
            npc.dontTakeDamageFromHostiles = dontTakeDamageFromHostiles;
            if (npc.friendly && QoLCompendium.mainConfig.TownNPCsDontDie)
            {
                npc.dontTakeDamageFromHostiles = true;
                return;
            }
            npc.dontTakeDamageFromHostiles = dontTakeDamageFromHostiles;
        }
    }

}
