using QoLCompendium.Tweaks;
using QoLCompendium.UI;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.NPCs
{
    [AutoloadHead]
    public class BMDealerNPC : ModNPC
    {
        public static int shopNum = 0;

        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<QoLCConfig>().BMNPC;
        }

        public override string Texture
        {
            get
            {
                return "QoLCompendium/NPCs/BMDealerNPC";
            }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Black Market Dealer");
            Main.npcFrameCount[NPC.type] = 26;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
            NPCID.Sets.AttackFrameCount[NPC.type] = 5;
            NPCID.Sets.DangerDetectRange[NPC.type] = 800;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 90;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = 4;
            NPC.Happiness.SetBiomeAffection<SnowBiome>((AffectionLevel)100).SetBiomeAffection<OceanBiome>((AffectionLevel)50).SetBiomeAffection<DesertBiome>((AffectionLevel)(-50)).SetNPCAffection(19, (AffectionLevel)100).SetNPCAffection(17, (AffectionLevel)50).SetNPCAffection(108, (AffectionLevel)(-50)).SetNPCAffection(441, (AffectionLevel)(-100));
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("He hails from a far away land to sell items that are difficult to get, but how did he even obtain them...")
            });
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 48;
            NPC.aiStyle = 7;
            NPC.damage = 15;
            NPC.defense = 25;
            NPC.lifeMax = 500;
            NPC.HitSound = new SoundStyle?(SoundID.NPCHit1);
            NPC.DeathSound = new SoundStyle?(SoundID.NPCDeath1);
            NPC.knockBackResist = 0.5f;
            AnimationType = 22;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            return true;
        }

        public override List<string> SetNPCNameList()
        {
            List<string> list = new()
            {
                "Bon",
                "Ned",
                "Jay",
                "Jack",
                "Jabon"
            };
            return list;
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            if (!Main.hardMode)
            {
                damage = 10;
            }
            if (!NPC.downedMoonlord && Main.hardMode)
            {
                damage = 25;
            }
            if (NPC.downedMoonlord)
            {
                damage = 100;
            }
            knockback = 8f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 15;
            randExtraCooldown = 5;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = 30;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 1f;
        }

        public override string GetChat()
        {
            string result = Main.rand.Next(4) switch
            {
                0 => "Illegal items are my specialty",
                1 => "Hand over some money, and I'll hook you up",
                2 => "Don't ask where I got these",
                _ => "Hey kid, want some items?",
            };
            return result;
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            if (shopNum == 0)
            {
                button = "Potions";
            }
            else if (shopNum == 1)
            {
                button = "Materials";
            }
            else if (shopNum == 2)
            {
                button = "Rare Materials";
            }
            else if (shopNum == 3)
            {
                button = "Movement Accessories";
            }
            else if (shopNum == 4)
            {
                button = "Combat Accessories";
            }
            else if (shopNum == 5)
            {
                button = "Informative/Building Gear";
            }
            else if (shopNum == 6)
            {
                button = "Treasure Bags & Crates";
            }
            else if (shopNum == 7)
            {
                button = "Natural Blocks";
            }
            else if (shopNum == 8)
            {
                button = "Building Blocks";
            }
            else if (shopNum == 9)
            {
                button = "Herbs & Plants";
            }
            else if (shopNum == 10)
            {
                button = "Station Buffs & Foods";
            }
            button2 = "Shop Changer";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
                BMNPCUI.visible = false;
            }
            else
            {
                if (!BMNPCUI.visible) BMNPCUI.timeStart = Main.GameUpdateCount;
                BMNPCUI.visible = true;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            if (shopNum == 0)
            {
                shop.item[nextSlot].SetDefaults(2344);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(303);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(300);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2325);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2324);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2356);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2329);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2346);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(295);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2354);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2327);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(291);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(305);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(4479);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2323);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(304);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2348);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(297);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(292);
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(2345);
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(294);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(293);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2322);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(299);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(288);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2347);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(289);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(298);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2355);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(296);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2328);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(290);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(301);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2326);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2359);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(302);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2349);
                nextSlot++;
            }
            if (shopNum == 1)
            {
                shop.item[nextSlot].SetDefaults(323);
                nextSlot++;
                if (NPC.downedQueenBee)
                {
                    shop.item[nextSlot].SetDefaults(2431);
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(1119);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(236);
                nextSlot++;
                if (NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults(154);
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(150);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1116);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(320);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(5070);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(23);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(118);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(331);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(259);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(38);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3111);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1118);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1115);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(68);
                nextSlot++;
                if (NPC.downedBoss2)
                {
                    shop.item[nextSlot].SetDefaults(86);
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(319);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(225);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(209);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(362);
                nextSlot++;
                if (NPC.downedBoss2)
                {
                    shop.item[nextSlot].SetDefaults(1329);
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(1330);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(210);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1117);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(69);
                nextSlot++;
            }
            if (shopNum == 2)
            {
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(3794);
                    nextSlot++;
                }
                if (NPC.downedGolemBoss)
                {
                    shop.item[nextSlot].SetDefaults(2218);
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(4413);
                nextSlot++;
                if (NPC.downedPlantBoss)
                {
                    shop.item[nextSlot].SetDefaults(1570);
                    nextSlot++;
                }
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(522);
                    nextSlot++;
                }
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(527);
                    nextSlot++;
                }
                if (NPC.downedPlantBoss)
                {
                    shop.item[nextSlot].SetDefaults(1508);
                    nextSlot++;
                }
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(3783);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(2161);
                    nextSlot++;
                }
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(1332);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(528);
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(4414);
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(501);
                    nextSlot++;
                }
                if (NPC.downedPlantBoss)
                {
                    shop.item[nextSlot].SetDefaults(2766);
                    nextSlot++;
                }
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(2607);
                    nextSlot++;
                }
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(1328);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(526);
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(4412);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(215);
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(575);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(520);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(521);
                    nextSlot++;
                }
                if (NPC.downedMechBoss1)
                {
                    shop.item[nextSlot].SetDefaults(548);
                    nextSlot++;
                }
                if (NPC.downedMechBoss2)
                {
                    shop.item[nextSlot].SetDefaults(549);
                    nextSlot++;
                }
                if (NPC.downedMechBoss3)
                {
                    shop.item[nextSlot].SetDefaults(547);
                    nextSlot++;
                }
                if (NPC.downedAncientCultist)
                {
                    shop.item[nextSlot].SetDefaults(3457);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(3458);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(3459);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(3456);
                    nextSlot++;
                }
            }
            if (shopNum == 3)
            {
                shop.item[nextSlot].SetDefaults(285);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(212);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3225);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(987);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(953);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(53);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(268);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(187);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(4978);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(934);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2423);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(54);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(950);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1303);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(906);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(158);
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(485);
                    nextSlot++;
                }
                if (NPC.downedMechBossAny)
                {
                    shop.item[nextSlot].SetDefaults(497);
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(857);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(159);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(975);
                nextSlot++;
                if (NPC.downedPlantBoss)
                {
                    shop.item[nextSlot].SetDefaults(977);
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(3201);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(863);
                nextSlot++;
            }
            if (shopNum == 4)
            {
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(1612);
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(49);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(111);
                nextSlot++;
                if (NPC.downedPlantBoss)
                {
                    shop.item[nextSlot].SetDefaults(963);
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(2219);
                nextSlot++;
                if (NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults(156);
                    nextSlot++;
                }
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(554);
                    nextSlot++;
                }
                if (NPC.downedGolemBoss)
                {
                    shop.item[nextSlot].SetDefaults(1248);
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(211);
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(3016);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(1253);
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(1921);
                nextSlot++;
                if (NPC.downedQueenBee)
                {
                    shop.item[nextSlot].SetDefaults(1132);
                    nextSlot++;
                }
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(1321);
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(1322);
                nextSlot++;
                if (NPC.downedMechBossAny)
                {
                    shop.item[nextSlot].SetDefaults(900);
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(223);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1323);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(193);
                nextSlot++;
                if (NPC.downedPlantBoss)
                {
                    shop.item[nextSlot].SetDefaults(938);
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(1290);
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(535);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(3781);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(3015);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(491);
                    nextSlot++;
                }
                if (NPC.downedPlantBoss)
                {
                    shop.item[nextSlot].SetDefaults(1300);
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(216);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3212);
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(489);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(532);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(2998);
                    nextSlot++;
                }
                if (NPC.downedGolemBoss)
                {
                    shop.item[nextSlot].SetDefaults(899);
                    nextSlot++;
                }
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(536);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(490);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(3809);
                    nextSlot++;
                }
                if (NPC.downedPlantBoss)
                {
                    shop.item[nextSlot].SetDefaults(1167);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(1845);
                    nextSlot++;
                }
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(3334);
                    nextSlot++;
                }
            }
            if (shopNum == 5)
            {
                shop.item[nextSlot].SetDefaults(407);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1923);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3061);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3624);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(4056);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(4341);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(4008);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(410);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(411);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(5064);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2367);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2368);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2369);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2294);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3183);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2676);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3124);
                nextSlot++;
                if (NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults(3611);
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(5043);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3213);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(4263);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(4819);
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(1326);
                    nextSlot++;
                }
            }
            if (shopNum == 6)
            {
                if (NPC.downedSlimeKing)
                {
                    shop.item[nextSlot].SetDefaults(3318);
                    shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                    nextSlot++;
                }
                if (NPC.downedBoss1)
                {
                    shop.item[nextSlot].SetDefaults(3319);
                    shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                    nextSlot++;
                }
                if (NPC.downedBoss2)
                {
                    shop.item[nextSlot].SetDefaults(3320);
                    shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(3321);
                    shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                    nextSlot++;
                }
                if (NPC.downedQueenBee)
                {
                    shop.item[nextSlot].SetDefaults(3322);
                    shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                    nextSlot++;
                }
                if (NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults(3323);
                    shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                    nextSlot++;
                }
                if (NPC.downedDeerclops)
                {
                    shop.item[nextSlot].SetDefaults(5111);
                    shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                    nextSlot++;
                }
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(3324);
                    shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                    nextSlot++;
                }
                if (NPC.downedQueenSlime)
                {
                    shop.item[nextSlot].SetDefaults(4957);
                    shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                    nextSlot++;
                }
                if (NPC.downedMechBoss1)
                {
                    shop.item[nextSlot].SetDefaults(3325);
                    shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                    nextSlot++;
                }
                if (NPC.downedMechBoss2)
                {
                    shop.item[nextSlot].SetDefaults(3326);
                    shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                    nextSlot++;
                }
                if (NPC.downedMechBoss3)
                {
                    shop.item[nextSlot].SetDefaults(3327);
                    shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                    nextSlot++;
                }
                if (NPC.downedPlantBoss)
                {
                    shop.item[nextSlot].SetDefaults(3328);
                    shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                    nextSlot++;
                }
                if (NPC.downedGolemBoss)
                {
                    shop.item[nextSlot].SetDefaults(3329);
                    shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(3860);
                    shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                    nextSlot++;
                }
                if (NPC.downedFishron)
                {
                    shop.item[nextSlot].SetDefaults(3330);
                    shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                    nextSlot++;
                }
                if (NPC.downedEmpressOfLight)
                {
                    shop.item[nextSlot].SetDefaults(4782);
                    shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                    nextSlot++;
                }
                if (NPC.downedMoonlord)
                {
                    shop.item[nextSlot].SetDefaults(3332);
                    shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                    nextSlot++;
                }
                if (CheckDowned.downedDarkMage || CheckDowned.downedOgre || CheckDowned.downedBetsy)
                {
                    shop.item[nextSlot].SetDefaults(3817);
                    shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 2, 0, 0));
                    nextSlot++;
                }
                if (!Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(2334);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(2335);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(2336);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(3208);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(3206);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(3203);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(3204);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(3207);
                    nextSlot++;
                    if (NPC.downedBoss3)
                    {
                        shop.item[nextSlot].SetDefaults(3205);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(4405);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(4407);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(4877);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(5002);
                    nextSlot++;
                }
                else
                {
                    shop.item[nextSlot].SetDefaults(3979);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(3980);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(3981);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(3987);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(3985);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(3982);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(3983);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(3986);
                    nextSlot++;
                    if (NPC.downedBoss3)
                    {
                        shop.item[nextSlot].SetDefaults(3984);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(4406);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(4408);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(4878);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(5003);
                    nextSlot++;
                }
            }
            if (shopNum == 7)
            {
                shop.item[nextSlot].SetDefaults(2);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3086);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3081);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(169);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3271);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3272);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3347);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(133);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(176);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(172);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(424);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(593);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(664);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1103);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(751);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(765);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(61);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(836);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(409);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1124);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1125);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1127);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(9);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2503);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2504);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(620);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(619);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(911);
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(621);
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(2260);
                nextSlot++;
                if (NPC.downedPlantBoss)
                {
                    shop.item[nextSlot].SetDefaults(1729);
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(183);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1727);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(276);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1725);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(4564);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(173);
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(502);
                    nextSlot++;
                }
            }
            if (shopNum == 8)
            {
                shop.item[nextSlot].SetDefaults(129);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(131);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(607);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(594);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(883);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(414);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(413);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(145);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2173);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(717);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2692);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3951);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3953);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(143);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(718);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(141);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(719);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(609);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(4050);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(577);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2793);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3100);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(192);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(214);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(412);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(415);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1589);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(416);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1591);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(604);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1593);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2792);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3461);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(134);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(137);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(139);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1101);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2435);
                nextSlot++;
                if (NPC.downedGolemBoss)
                {
                    shop.item[nextSlot].SetDefaults(2860);
                    nextSlot++;
                }
            }
            if (shopNum == 9)
            {
                shop.item[nextSlot].SetDefaults(3093);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(315);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(313);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(316);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(318);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(314);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2358);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(317);
                nextSlot++;
                if (NPC.downedBoss1)
                {
                    shop.item[nextSlot].SetDefaults(1828);
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(1107);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1108);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1109);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1110);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1111);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1112);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1113);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1114);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(60);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2887);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(5);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(4349);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(4350);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(4351);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(4352);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(4353);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(4354);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(4377);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(4378);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(4389);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(62);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(195);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(194);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(59);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2171);
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(369);
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(27);
                nextSlot++;
            }

            if (shopNum == 10)
            {
                shop.item[nextSlot].SetDefaults(4624);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(4403);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(4022);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(63);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(966);
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(487);
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(2177);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3198);
                nextSlot++;
                if (NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults(2999);
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(4276);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3750);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1431);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1859);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(4609);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3117);
                nextSlot++;
                if (NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults(148);
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(206);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(207);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1128);
                nextSlot++;
            }
        }
    }
}
