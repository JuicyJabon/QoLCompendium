using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    // Token: 0x02000012 RID: 18
    public class OtherNPCStuff : GlobalNPC
    {
        // Token: 0x1700001C RID: 28
        // (get) Token: 0x06000071 RID: 113 RVA: 0x00005A8B File Offset: 0x00003C8B
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        // Token: 0x06000072 RID: 114 RVA: 0x00005A90 File Offset: 0x00003C90
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
}
