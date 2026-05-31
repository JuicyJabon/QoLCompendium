using Terraria.GameContent.Events;

namespace QoLCompendium.Core.QoLCUtils
{
    public static class NPCsUtils
    {
        public static void DisableEvents()
        {
            if (Main.invasionType != 0)
                Main.invasionType = 0;
            if (Main.pumpkinMoon)
                Main.pumpkinMoon = false;
            if (Main.snowMoon)
                Main.snowMoon = false;
            if (Main.eclipse)
                Main.eclipse = false;
            if (Main.bloodMoon)
                Main.bloodMoon = false;
            if (Main.WindyEnoughForKiteDrops)
            {
                Main.windSpeedTarget = 0f;
                Main.windSpeedCurrent = 0f;
            }
            if (Main.slimeRain)
            {
                Main.StopSlimeRain(true);
                Main.slimeWarningDelay = 1;
                Main.slimeWarningTime = 1;
            }
            if (BirthdayParty.PartyIsUp)
                BirthdayParty.CheckNight();
            if (DD2Event.Ongoing && Main.netMode != NetmodeID.MultiplayerClient)
                DD2Event.StopInvasion(false);
            if (Sandstorm.Happening)
            {
                Sandstorm.Happening = false;
                Sandstorm.TimeLeft = 0.0;
                Sandstorm.IntendedSeverity = 0f;
            }
            if (NPC.downedTowers && (NPC.LunarApocalypseIsUp || NPC.ShieldStrengthTowerNebula > 0 || NPC.ShieldStrengthTowerSolar > 0 || NPC.ShieldStrengthTowerStardust > 0 || NPC.ShieldStrengthTowerVortex > 0))
            {
                NPC.LunarApocalypseIsUp = false;
                NPC.ShieldStrengthTowerNebula = 0;
                NPC.ShieldStrengthTowerSolar = 0;
                NPC.ShieldStrengthTowerStardust = 0;
                NPC.ShieldStrengthTowerVortex = 0;
                for (int i = 0; i < 200; i++)
                {
                    if (Main.npc[i].active && (Main.npc[i].type == NPCID.LunarTowerNebula || Main.npc[i].type == NPCID.LunarTowerSolar || Main.npc[i].type == NPCID.LunarTowerStardust || Main.npc[i].type == NPCID.LunarTowerVortex))
                    {
                        Main.npc[i].dontTakeDamage = false;
                        Main.npc[i].StrikeInstantKill();
                    }
                }
            }
            if (Main.IsItRaining || Main.IsItStorming)
            {
                Main.StopRain();
                Main.cloudAlpha = 0f;
                if (Main.netMode == NetmodeID.Server)
                    Main.SyncRain();
            }
        }

        public static bool IsABoss(this NPC npc)
        {
            if (npc == null || !npc.active)
                return false;

            if (npc.boss && npc.type != NPCID.MartianSaucerCore)
                return true;

            if (npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsTail)
                return true;

            return false;
        }
    }
}
