using Split.Content.Bosses.Seth;

namespace QoLCompendium.Core.Changes.ModChanges.ModNPCChanges
{
    [JITWhenModsEnabled(CrossModSupport.Split.Name)]
    [ExtendsFromMod(CrossModSupport.Split.Name)]
    public class SplitUltimateSethDownedFlag : GlobalNPC
    {
        public override void OnKill(NPC npc)
        {
            if (npc.ModNPC is Seth seth && seth.ultimateForm)
                NPC.SetEventFlagCleared(ref ModConditions.DownedBoss[(int)ModConditions.Downed.UltimateSeth], -1);
        }
    }
}
