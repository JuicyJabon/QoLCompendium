namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class NoTownSlimes : GlobalNPC
    {
        public override void AI(NPC npc)
        {
            if (QoLCompendium.mainConfig.NoTownSlimes)
            {
                if (npc.active && Common.TownSlimeIDs.Contains(npc.type))
                {
                    npc.timeLeft = 0;
                    npc.active = false;
                }
            }
        }
    }

    public class NoTownSlimesSystem : ModSystem
    {
        public override void PreUpdateWorld()
        {
            if (QoLCompendium.mainConfig.NoTownSlimes)
            {
                NPC.unlockedSlimeBlueSpawn = false;
                NPC.unlockedSlimeCopperSpawn = false;
                NPC.unlockedSlimeGreenSpawn = false;
                NPC.unlockedSlimeOldSpawn = false;
                NPC.unlockedSlimePurpleSpawn = false;
                NPC.unlockedSlimeRainbowSpawn = false;
                NPC.unlockedSlimeRedSpawn = false;
                NPC.unlockedSlimeYellowSpawn = false;

                Main.townNPCCanSpawn[NPCID.TownSlimeBlue] = false;
                Main.townNPCCanSpawn[NPCID.TownSlimeGreen] = false;
                Main.townNPCCanSpawn[NPCID.TownSlimeOld] = false;
                Main.townNPCCanSpawn[NPCID.TownSlimePurple] = false;
                Main.townNPCCanSpawn[NPCID.TownSlimeRainbow] = false;
                Main.townNPCCanSpawn[NPCID.TownSlimeRed] = false;
                Main.townNPCCanSpawn[NPCID.TownSlimeYellow] = false;
                Main.townNPCCanSpawn[NPCID.TownSlimeCopper] = false;
            }
        }
    }
}
