using QoLCompendium.NPCs;
using System.ComponentModel;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
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

    public class SpawnSystem : ModSystem
    {
        public override void PreUpdateWorld()
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

            NPCsSpawnAtNight.UpdateTime_SpawnTownNPCs();
        }
    }

    internal class NPCsSpawnAtNight
    {
        public static IEntitySource GetSpawnSourceForTownSpawn()
        {
            return new EntitySource_SpawnNPC(null);
        }

        public static void UpdateTime_SpawnTownNPCs()
        {
            double desiredWorldTilesUpdateRate = Main.desiredWorldTilesUpdateRate * ModContent.GetInstance<QoLCConfig>().TownieSpawnRate;

            if (Main.netMode == NetmodeID.MultiplayerClient || desiredWorldTilesUpdateRate <= 0.0)
            {
                return;
            }
            Main.checkForSpawns++;
            if (Main.checkForSpawns < 7200.0 / desiredWorldTilesUpdateRate)
            {
                return;
            }
            Main.checkForSpawns = 0;
            int num = 0;
            for (int i = 0; i < 255; i++)
            {
                if (Main.player[i].active)
                {
                    num++;
                }
            }
            for (int j = 0; j < 670; j++)
            {
                Main.townNPCCanSpawn[j] = false;
            }
            WorldGen.prioritizedTownNPCType = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            int num9 = 0;
            int num10 = 0;
            int num11 = 0;
            int num12 = 0;
            int num13 = 0;
            int num14 = 0;
            int num15 = 0;
            int num16 = 0;
            int num17 = 0;
            int num18 = 0;
            int num19 = 0;
            int num20 = 0;
            int num21 = 0;
            int num22 = 0;
            int num23 = 0;
            int num24 = 0;
            int num25 = 0;
            int num26 = 0;
            int num27 = 0;
            int num28 = 0;
            int num29 = 0;
            int num30 = 0;
            int num31 = 0;
            int num32 = 0;
            int numbm = 0;
            int numec = 0;
            for (int k = 0; k < 200; k++)
            {
                if (Main.npc[k].active && Main.npc[k].townNPC)
                {
                    if (Main.npc[k].type != NPCID.TravellingMerchant && Main.npc[k].type != NPCID.OldMan && Main.npc[k].type != NPCID.SkeletonMerchant && !Main.npc[k].homeless)
                    {
                        WorldGen.QuickFindHome(k);
                    }
                    if (Main.npc[k].type == NPCID.OldMan)
                    {
                        num7++;
                    }
                    if (Main.npc[k].type == NPCID.Merchant)
                    {
                        num2++;
                    }
                    if (Main.npc[k].type == NPCID.Nurse)
                    {
                        num3++;
                    }
                    if (Main.npc[k].type == NPCID.ArmsDealer)
                    {
                        num5++;
                    }
                    if (Main.npc[k].type == NPCID.Dryad)
                    {
                        num4++;
                    }
                    if (Main.npc[k].type == NPCID.Guide)
                    {
                        num6++;
                    }
                    if (Main.npc[k].type == NPCID.Demolitionist)
                    {
                        num8++;
                    }
                    if (Main.npc[k].type == NPCID.Clothier)
                    {
                        num9++;
                    }
                    if (Main.npc[k].type == NPCID.GoblinTinkerer)
                    {
                        num11++;
                    }
                    if (Main.npc[k].type == NPCID.Wizard)
                    {
                        num10++;
                    }
                    if (Main.npc[k].type == NPCID.Mechanic)
                    {
                        num12++;
                    }
                    if (Main.npc[k].type == NPCID.SantaClaus)
                    {
                        num13++;
                    }
                    if (Main.npc[k].type == NPCID.Truffle)
                    {
                        num14++;
                    }
                    if (Main.npc[k].type == NPCID.Steampunker)
                    {
                        num15++;
                    }
                    if (Main.npc[k].type == NPCID.DyeTrader)
                    {
                        num16++;
                    }
                    if (Main.npc[k].type == NPCID.PartyGirl)
                    {
                        num17++;
                    }
                    if (Main.npc[k].type == NPCID.Cyborg)
                    {
                        num18++;
                    }
                    if (Main.npc[k].type == NPCID.Painter)
                    {
                        num19++;
                    }
                    if (Main.npc[k].type == NPCID.WitchDoctor)
                    {
                        num20++;
                    }
                    if (Main.npc[k].type == NPCID.Pirate)
                    {
                        num21++;
                    }
                    if (Main.npc[k].type == NPCID.Stylist)
                    {
                        num22++;
                    }
                    if (Main.npc[k].type == NPCID.Angler)
                    {
                        num23++;
                    }
                    if (Main.npc[k].type == NPCID.TaxCollector)
                    {
                        num24++;
                    }
                    if (Main.npc[k].type == NPCID.DD2Bartender)
                    {
                        num25++;
                    }
                    if (Main.npc[k].type == NPCID.Golfer)
                    {
                        num26++;
                    }
                    if (Main.npc[k].type == NPCID.BestiaryGirl)
                    {
                        num27++;
                    }
                    if (Main.npc[k].type == NPCID.TownCat)
                    {
                        num28++;
                    }
                    if (Main.npc[k].type == NPCID.TownDog)
                    {
                        num29++;
                    }
                    if (Main.npc[k].type == NPCID.TownBunny)
                    {
                        num30++;
                    }
                    if (Main.npc[k].type == NPCID.Princess)
                    {
                        num31++;
                    }
                    if (Main.npc[k].type == ModContent.NPCType<BMDealerNPC>())
                    {
                        numbm++;
                    }
                    if (Main.npc[k].type == ModContent.NPCType<EtherealCollectorNPC>())
                    {
                        numec++;
                    }
                    num32++;
                }
            }
            if (WorldGen.prioritizedTownNPCType != 0)
            {
                return;
            }
            int num33 = 0;
            bool flag = false;
            int num34 = 0;
            bool flag2 = false;
            bool flag3 = false;
            bool flag4 = false;
            BestiaryUnlockProgressReport bestiaryProgressReport = Main.GetBestiaryProgressReport();
            for (int l = 0; l < 255; l++)
            {
                if (Main.player[l].active)
                {
                    for (int m = 0; m < 58; m++)
                    {
                        if (Main.player[l].inventory[m] != null && Main.player[l].inventory[m].stack > 0)
                        {
                            if (num33 < 2000000000)
                            {
                                if (Main.player[l].inventory[m].type == ItemID.CopperCoin)
                                {
                                    num33 += Main.player[l].inventory[m].stack;
                                }
                                if (Main.player[l].inventory[m].type == ItemID.SilverCoin)
                                {
                                    num33 += Main.player[l].inventory[m].stack * 100;
                                }
                                if (Main.player[l].inventory[m].type == ItemID.GoldCoin)
                                {
                                    num33 += Main.player[l].inventory[m].stack * 10000;
                                }
                                if (Main.player[l].inventory[m].type == ItemID.PlatinumCoin)
                                {
                                    num33 += Main.player[l].inventory[m].stack * 1000000;
                                }
                            }
                            if (Main.player[l].inventory[m].ammo == AmmoID.Bullet || Main.player[l].inventory[m].useAmmo == AmmoID.Bullet)
                            {
                                flag2 = true;
                            }
                            if (ItemID.Sets.ItemsThatCountAsBombsForDemolitionistToSpawn[Main.player[l].inventory[m].type])
                            {
                                flag3 = true;
                            }
                            if (Main.player[l].inventory[m].dye > 0 || (Main.player[l].inventory[m].type >= ItemID.TealMushroom && Main.player[l].inventory[m].type <= ItemID.DyeVat) || (Main.player[l].inventory[m].type >= ItemID.StrangePlant1 && Main.player[l].inventory[m].type <= ItemID.StrangePlant4))
                            {
                                flag4 = true;
                            }
                        }
                    }
                    int num35 = Main.player[l].statLifeMax / 20;
                    if (num35 > 5)
                    {
                        flag = true;
                    }
                    num34 += num35;
                    if (!flag4)
                    {
                        for (int n = 0; n < 3; n++)
                        {
                            if (Main.player[l].dye[n] != null && Main.player[l].dye[n].stack > 0 && Main.player[l].dye[n].dye > 0)
                            {
                                flag4 = true;
                            }
                        }
                    }
                }
            }
            if (!NPC.downedBoss3 && num7 == 0)
            {
                int num36 = NPC.NewNPC(GetSpawnSourceForTownSpawn(), Main.dungeonX * 16 + 8, Main.dungeonY * 16, 37, 0, 0f, 0f, 0f, 0f, 255);
                Main.npc[num36].homeless = false;
                Main.npc[num36].homeTileX = Main.dungeonX;
                Main.npc[num36].homeTileY = Main.dungeonY;
            }
            bool flag5 = false;
            if (Utils.NextBool(Main.rand, 40))
            {
                flag5 = true;
            }
            if (num6 < 1)
            {
                Main.townNPCCanSpawn[22] = true;
            }
            if (num33 > 5000.0 && num2 < 1)
            {
                Main.townNPCCanSpawn[17] = true;
            }
            if (flag && num3 < 1 && num2 > 0)
            {
                Main.townNPCCanSpawn[18] = true;
            }
            if (flag2 && num5 < 1)
            {
                Main.townNPCCanSpawn[19] = true;
            }
            if ((NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3) && num4 < 1)
            {
                Main.townNPCCanSpawn[20] = true;
            }
            if (flag3 && num2 > 0 && num8 < 1)
            {
                Main.townNPCCanSpawn[38] = true;
            }
            if (NPC.savedStylist && num22 < 1)
            {
                Main.townNPCCanSpawn[353] = true;
            }
            if (NPC.savedAngler && num23 < 1)
            {
                Main.townNPCCanSpawn[369] = true;
            }
            if (NPC.downedBoss3 && num9 < 1)
            {
                Main.townNPCCanSpawn[54] = true;
            }
            if (NPC.savedGoblin && num11 < 1)
            {
                Main.townNPCCanSpawn[107] = true;
            }
            if (NPC.savedTaxCollector && num24 < 1)
            {
                Main.townNPCCanSpawn[441] = true;
            }
            if (NPC.savedWizard && num10 < 1)
            {
                Main.townNPCCanSpawn[108] = true;
            }
            if (NPC.downedBoss3 && num12 < 1)
            {
                Main.townNPCCanSpawn[124] = true;
            }
            if (NPC.downedFrost && num13 < 1 && Main.xMas)
            {
                Main.townNPCCanSpawn[142] = true;
            }
            if ((Main.tenthAnniversaryWorld || NPC.downedMechBossAny) && num15 < 1)
            {
                Main.townNPCCanSpawn[178] = true;
            }
            if (flag4 && num16 < 1 && num32 >= 4)
            {
                Main.townNPCCanSpawn[207] = true;
            }
            if (NPC.downedQueenBee && num20 < 1)
            {
                Main.townNPCCanSpawn[228] = true;
            }
            if (NPC.downedPirates && num21 < 1)
            {
                Main.townNPCCanSpawn[229] = true;
            }
            if (num14 < 1 && Main.hardMode)
            {
                Main.townNPCCanSpawn[160] = true;
            }
            if (Main.hardMode && NPC.downedPlantBoss && num18 < 1)
            {
                Main.townNPCCanSpawn[209] = true;
            }
            if (num32 >= 8 && num19 < 1)
            {
                Main.townNPCCanSpawn[227] = true;
            }
            if (flag5 && num17 < 1 && num32 >= 14)
            {
                Main.townNPCCanSpawn[208] = true;
            }
            if (NPC.savedBartender && num25 < 1)
            {
                Main.townNPCCanSpawn[550] = true;
            }
            if (NPC.savedGolfer && num26 < 1)
            {
                Main.townNPCCanSpawn[588] = true;
            }
            if (bestiaryProgressReport.CompletionPercent >= 0.1f && num27 < 1)
            {
                Main.townNPCCanSpawn[633] = true;
            }
            if (numbm < 1)
            {
                Main.townNPCCanSpawn[ModContent.NPCType<BMDealerNPC>()] = true;
            }
            if (numec < 1)
            {
                Main.townNPCCanSpawn[ModContent.NPCType<EtherealCollectorNPC>()] = true;
            }
            if (NPC.boughtCat && num28 < 1)
            {
                Main.townNPCCanSpawn[637] = true;
            }
            if (NPC.boughtDog && num29 < 1)
            {
                Main.townNPCCanSpawn[638] = true;
            }
            if (NPC.boughtBunny && num30 < 1)
            {
                Main.townNPCCanSpawn[656] = true;
            }
            bool flag6 = num2 > 0 && num3 > 0 && num4 > 0 && num5 > 0 && num6 > 0 && num8 > 0 && num9 > 0 && num10 > 0 && num11 > 0 && num12 > 0 && num14 > 0 && num15 > 0 && num16 > 0 && num17 > 0 && num18 > 0 && num19 > 0 && num20 > 0 && num21 > 0 && num22 > 0 && num23 > 0 && num24 > 0 && num25 > 0 && num26 > 0 && num27 > 0;
            if (Main.tenthAnniversaryWorld)
            {
                flag6 = true;
            }
            if (flag6 && num31 < 1)
            {
                Main.townNPCCanSpawn[663] = true;
            }
            int num37 = WorldGen.prioritizedTownNPCType;
            if (num37 == 0 && NPC.boughtCat && num28 < 1)
            {
                num37 = 637;
            }
            if (num37 == 0 && NPC.boughtDog && num29 < 1)
            {
                num37 = 638;
            }
            if (num37 == 0 && NPC.boughtBunny && num30 < 1)
            {
                num37 = 656;
            }
            if (num37 == 0 && num6 < 1)
            {
                num37 = 22;
            }
            if (num37 == 0 && num33 > 5000.0 && num2 < 1)
            {
                num37 = 17;
            }
            if (num37 == 0 && flag && num3 < 1 && num2 > 0)
            {
                num37 = 18;
            }
            if (num37 == 0 && flag2 && num5 < 1)
            {
                num37 = 19;
            }
            if (num37 == 0 && NPC.savedGoblin && num11 < 1)
            {
                num37 = 107;
            }
            if (num37 == 0 && NPC.savedTaxCollector && num24 < 1)
            {
                num37 = 441;
            }
            if (num37 == 0 && NPC.savedWizard && num10 < 1)
            {
                num37 = 108;
            }
            if (num37 == 0 && Main.hardMode && num14 < 1)
            {
                num37 = 160;
            }
            if (num37 == 0 && (NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3) && num4 < 1)
            {
                num37 = 20;
            }
            if (num37 == 0 && flag3 && num2 > 0 && num8 < 1)
            {
                num37 = 38;
            }
            if (num37 == 0 && NPC.downedQueenBee && num20 < 1)
            {
                num37 = 228;
            }
            if (num37 == 0 && NPC.downedMechBossAny && num15 < 1)
            {
                num37 = 178;
            }
            if (num37 == 0 && NPC.savedMech && num12 < 1)
            {
                num37 = 124;
            }
            if (num37 == 0 && NPC.savedAngler && num23 < 1)
            {
                num37 = 369;
            }
            if (num37 == 0 && Main.hardMode && NPC.downedPlantBoss && num18 < 1)
            {
                num37 = 209;
            }
            if (num37 == 0 && NPC.downedPirates && num21 < 1)
            {
                num37 = 229;
            }
            if (num37 == 0 && NPC.downedBoss3 && num9 < 1)
            {
                num37 = 54;
            }
            if (num37 == 0 && NPC.savedStylist && num22 < 1)
            {
                num37 = 353;
            }
            if (num37 == 0 && num32 >= 4 && flag4 && num16 < 1)
            {
                num37 = 207;
            }
            if (num37 == 0 && num32 >= 8 && num19 < 1)
            {
                num37 = 227;
            }
            if (num37 == 0 && flag5 && num32 >= 14 && num17 < 1)
            {
                num37 = 208;
            }
            if (num37 == 0 && NPC.downedFrost && num13 < 1 && Main.xMas)
            {
                num37 = 142;
            }
            if (num37 == 0 && NPC.savedBartender && num25 < 1)
            {
                num37 = 550;
            }
            if (num37 == 0 && NPC.savedGolfer && num26 < 1)
            {
                num37 = 588;
            }
            if (num37 == 0 && bestiaryProgressReport.CompletionPercent >= 0.1f && num27 < 1)
            {
                num37 = 633;
            }
            if (num37 == 0 && flag6 && num31 < 1)
            {
                num37 = 663;
            }
            if (num37 == 0 && numbm < 1)
            {
                num37 = ModContent.NPCType<BMDealerNPC>();
            }
            if (num37 == 0 && numec < 1)
            {
                num37 = ModContent.NPCType<EtherealCollectorNPC>();
            }
            WorldGen.prioritizedTownNPCType = num37;
        }
    }
}
