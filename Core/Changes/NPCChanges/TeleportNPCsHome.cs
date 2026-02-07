using System.Reflection;

namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class TeleportNPCsHome : ModSystem
    {
        public override void Load()
        {
            On_WorldGen.moveRoom += WorldGen_moveRoom;
        }

        public override void Unload()
        {
            On_WorldGen.moveRoom -= WorldGen_moveRoom;
        }

        public void WorldGen_moveRoom(On_WorldGen.orig_moveRoom orig, int x, int y, int n)
        {
            orig.Invoke(x, y, n);
            if (Main.npc.IndexInRange(n) && Main.npc[n] is not null)
                TownEntitiesTeleportToHome(Main.npc[n], Main.npc[n].homeTileX, Main.npc[n].homeTileY);
        }

        public static void TownEntitiesTeleportToHome(NPC npc, int homeFloorX, int homeFloorY)
        {
            npc?.GetType().GetMethod("AI_007_TownEntities_TeleportToHome",
                BindingFlags.Instance | BindingFlags.NonPublic,
                new[] { typeof(int), typeof(int) })?
                .Invoke(npc, new object[] { homeFloorX, homeFloorY });
        }
    }
}
