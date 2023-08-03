using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    public class InvincibleTownies : GlobalNPC
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public override void SetDefaults(NPC npc)
        {
            bool dontTakeDamageFromHostiles = npc.dontTakeDamageFromHostiles;
            if (npc.type == NPCID.DD2EterniaCrystal && ModContent.GetInstance<QoLCConfig>().FriendliesDontDie)
            {
                npc.dontTakeDamageFromHostiles = false;
                return;
            }
            npc.dontTakeDamageFromHostiles = dontTakeDamageFromHostiles;
            if (npc.friendly && ModContent.GetInstance<QoLCConfig>().FriendliesDontDie)
            {
                npc.dontTakeDamageFromHostiles = true;
                return;
            }
            npc.dontTakeDamageFromHostiles = dontTakeDamageFromHostiles;
        }
    }

    public class TownieSpawns : ModSystem
    {
        public override void PreUpdateWorld()
        {
            if (ModContent.GetInstance<QoLCConfig>().TownieSpawn)
            {
                NPC.savedStylist = true;
                NPC.savedAngler = true;
                NPC.savedGolfer = true;
                if (NPC.downedGoblins)
                {
                    NPC.savedGoblin = true;
                }
                if (NPC.downedBoss2)
                {
                    NPC.savedBartender = true;
                }
                if (NPC.downedBoss3)
                {
                    NPC.savedMech = true;
                }
                if (Main.hardMode)
                {
                    NPC.savedWizard = true;
                    NPC.savedTaxCollector = true;
                }
            }
        }
    }
}
