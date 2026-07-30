using QoLCompendium.Core.UI;
using Terraria.GameContent.Events;

namespace QoLCompendium.Core.QoLCUtils
{
    public static class NPCsUtils
    {
        public static Color BossPurple = new(175, 75, 255);
        public static Color EventGreen = new(50, 255, 130);

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

        public static void StartEvent(Player player, int type)
        {
            switch (type)
            {
                case (int)UIEnums.EventTypes.Party:
                    BirthdayParty.PartyDaysOnCooldown = 0;

                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            if (BirthdayParty.PartyIsUp)
                                break;
                            BirthdayParty.CheckMorning();
                        }
                    }

                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.WorldData);
                    break;
                case (int)UIEnums.EventTypes.LanternNight:
                    LanternNight.NextNightIsLanternNight = true;
                    LanternNight.GenuineLanterns = true;
                    TextHelper.PrintText(Language.GetTextValue("Mods.QoLCompendium.Messages.EventLanternNight"), EventGreen);
                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.WorldData);
                    break;
                case (int)UIEnums.EventTypes.Rain:
                    LanternNight.GenuineLanterns = false;
                    LanternNight.ManualLanterns = false;

                    //sets rain time to 12 hours
                    int day = 86400;
                    int hour = day / 24;
                    Main.rainTime = hour * 12;
                    Main.raining = true;
                    Main.maxRaining = Main.cloudAlpha = 0.9f;

                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.WorldData);
                        Main.SyncRain();
                    }
                    TextHelper.PrintText(Language.GetTextValue("Mods.QoLCompendium.Messages.EventRain"), EventGreen);
                    SoundEngine.PlaySound(SoundID.Roar, player.position);
                    break;
                case (int)UIEnums.EventTypes.Sandstorm:
                    Sandstorm.StartSandstorm();

                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.WorldData);
                    TextHelper.PrintText(Language.GetTextValue("Mods.QoLCompendium.Messages.EventSandstorm"), EventGreen);
                    SoundEngine.PlaySound(SoundID.Roar, player.position);
                    break;
                case (int)UIEnums.EventTypes.WindyDay:
                    Main.windSpeedTarget = Main.windSpeedCurrent = 0.8f;

                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.WorldData);
                    TextHelper.PrintText(Language.GetTextValue("Mods.QoLCompendium.Messages.EventWind"), EventGreen);
                    SoundEngine.PlaySound(SoundID.Roar, player.position);
                    break;
                case 5:
                    if (!Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        SoundEngine.PlaySound(SoundID.Roar, player.position);
                        TextHelper.PrintText(Language.GetTextValue("Mods.QoLCompendium.Messages.EventBloodMoon"), EventGreen);
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.WorldData);
                    }
                    break;
                case (int)UIEnums.EventTypes.SlimeRain:
                    Main.StartSlimeRain(true);
                    Main.slimeWarningDelay = 1;
                    Main.slimeWarningTime = 1;
                    SoundEngine.PlaySound(SoundID.Roar, player.position);

                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.WorldData);
                    break;
                case (int)UIEnums.EventTypes.GoblinArmy:
                    Main.StartInvasion(InvasionID.GoblinArmy);
                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.WorldData);
                    break;
                case (int)UIEnums.EventTypes.FrostLegion:
                    Main.StartInvasion(InvasionID.SnowLegion);
                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.WorldData);
                    break;
                case (int)UIEnums.EventTypes.PirateInvasion:
                    Main.StartInvasion(InvasionID.PirateInvasion);
                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.WorldData);
                    break;
                case (int)UIEnums.EventTypes.SolarEclipse:
                    if (Main.dayTime)
                    {
                        Main.eclipse = true;
                        SoundEngine.PlaySound(SoundID.Roar, player.position);
                        TextHelper.PrintText(Language.GetTextValue("Mods.QoLCompendium.Messages.EventEclipse"), EventGreen);
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.WorldData);
                    }
                    break;
                case (int)UIEnums.EventTypes.PumpkinMoon:
                    if (!Main.dayTime)
                    {
                        Main.startPumpkinMoon();
                        TextHelper.PrintText(Language.GetTextValue("Mods.QoLCompendium.Messages.EventPumpkinMoon"), EventGreen);
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.WorldData);
                    }
                    break;
                case (int)UIEnums.EventTypes.FrostMoon:
                    if (!Main.dayTime)
                    {
                        Main.startSnowMoon();
                        TextHelper.PrintText(Language.GetTextValue("Mods.QoLCompendium.Messages.EventFrostMoon"), EventGreen);
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.WorldData);
                    }
                    break;
                case (int)UIEnums.EventTypes.MartianMadness:
                    Main.StartInvasion(InvasionID.MartianMadness);
                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.WorldData);
                    break;
                case (int)UIEnums.EventTypes.LunarEvent:
                    WorldGen.TriggerLunarApocalypse();
                    NPC.LunarApocalypseIsUp = true;
                    break;
                default:
                    break;
            }
        }

        public static void HideFromBestiary(this ModNPC npc)
        {
            NPCID.Sets.NPCBestiaryDrawModifiers hide = new()
            {
                Hide = true
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(npc.Type, hide);
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
