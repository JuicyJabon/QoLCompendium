using QoLCompendium.Core.Changes.NPCChanges;
using Terraria.DataStructures;

namespace QoLCompendium.Content.NPCs
{
    public class SuperDummy : ModNPC
    {
        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.TargetDummy);
            NPC.lifeMax = int.MaxValue;
            NPC.aiStyle = -1;
            NPC.width = 28;
            NPC.height = 50;
            NPC.immortal = false;
            NPC.npcSlots = 0;
            NPC.dontCountMe = true;
            NPC.noGravity = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position) => false;
        public override void OnSpawn(IEntitySource source)
        {
            NPC.life = NPC.lifeMax = int.MaxValue;
        }
        public override void AI()
        {
            NPC.life = NPC.lifeMax = int.MaxValue;

            if (SpawnRateEdits.AnyBossAlive())
            {
                NPC.life = 0;
                NPC.HitEffect();
                NPC.SimpleStrikeNPC(int.MaxValue, 0, false, 0, null, false, 0, true);
            }
        }

        public override bool CheckDead() => false;
    }
}