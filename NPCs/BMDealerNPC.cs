using QoLCompendium.UI;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Golf;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.NPCs
{
    [AutoloadHead]
    public class BMDealerNPC : ModNPC
    {
        public static int shopNum = 0;
        public static string ShopName;

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
            // DisplayName.SetDefault("Black Market Dealer");
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

        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
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
                ShopName = "Potions";
            }
            else if (shopNum == 1)
            {
                button = "Materials";
                ShopName = "Materials";
            }
            else if (shopNum == 2)
            {
                button = "Rare Materials";
                ShopName = "Rare Materials";
            }
            else if (shopNum == 3)
            {
                button = "Movement Accessories";
                ShopName = "Movement Accessories";
            }
            else if (shopNum == 4)
            {
                button = "Combat Accessories";
                ShopName = "Combat Accessories";
            }
            else if (shopNum == 5)
            {
                button = "Informative/Building Gear";
                ShopName = "Informative/Building Gear";
            }
            else if (shopNum == 6)
            {
                button = "Treasure Bags & Crates";
                ShopName = "Treasure Bags & Crates";
            }
            else if (shopNum == 7)
            {
                button = "Natural Blocks";
                ShopName = "Natural Blocks";
            }
            else if (shopNum == 8)
            {
                button = "Building Blocks";
                ShopName = "Building Blocks";
            }
            else if (shopNum == 9)
            {
                button = "Herbs & Plants";
                ShopName = "Herbs & Plants";
            }
            else if (shopNum == 10)
            {
                button = "Station Buffs & Foods";
                ShopName = "Station Buffs & Foods";
            }
            button2 = "Shop Changer";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = ShopName;
                BMNPCUI.visible = false;
            }
            else
            {
                if (!BMNPCUI.visible) BMNPCUI.timeStart = Main.GameUpdateCount;
                BMNPCUI.visible = true;
            }
        }

        public override void AddShops()
        {
            var potShop = new NPCShop(Type, "Potions")
                    .Add(2344)
                    .Add(303)
                    .Add(300)
                    .Add(2325)
                    .Add(2324)
                    .Add(2356)
                    .Add(2329)
                    .Add(2346)
                    .Add(295)
                    .Add(2354)
                    .Add(2327)
                    .Add(291)
                    .Add(305)
                    .Add(4479)
                    .Add(2323)
                    .Add(304)
                    .Add(2348)
                    .Add(297)
                    .Add(292)
                    .Add(2345, Condition.Hardmode)
                    .Add(294)
                    .Add(293)
                    .Add(2322)
                    .Add(299)
                    .Add(288)
                    .Add(2347)
                    .Add(289)
                    .Add(298)
                    .Add(2355)
                    .Add(296)
                    .Add(2328)
                    .Add(290)
                    .Add(301)
                    .Add(2326)
                    .Add(2359)
                    .Add(302)
                    .Add(2349);
            potShop.Register();

            var matShop = new NPCShop(Type, "Materials")
                    .Add(323)
                    .Add(2431, Condition.DownedQueenBee)
                    .Add(1119)
                    .Add(236)
                    .Add(154, Condition.DownedSkeletron)
                    .Add(150)
                    .Add(1116)
                    .Add(320)
                    .Add(5070)
                    .Add(23)
                    .Add(118)
                    .Add(331)
                    .Add(259)
                    .Add(38)
                    .Add(3111)
                    .Add(1118)
                    .Add(1115)
                    .Add(68)
                    .Add(86, Condition.DownedEowOrBoc)
                    .Add(319)
                    .Add(225)
                    .Add(209)
                    .Add(362)
                    .Add(1329, Condition.DownedEowOrBoc)
                    .Add(1330)
                    .Add(210)
                    .Add(1117)
                    .Add(69);
            matShop.Register();

            var rMatShop = new NPCShop(Type, "Rare Materials")
                    .Add(3794, Condition.Hardmode)
                    .Add(2218, Condition.DownedGolem)
                    .Add(4413)
                    .Add(1570, Condition.DownedPlantera)
                    .Add(522, Condition.Hardmode)
                    .Add(527, Condition.Hardmode)
                    .Add(1508, Condition.DownedPlantera)
                    .Add(3783, Condition.Hardmode)
                    .Add(2161, Condition.Hardmode)
                    .Add(1332, Condition.Hardmode)
                    .Add(528, Condition.Hardmode)
                    .Add(4414)
                    .Add(501, Condition.Hardmode)
                    .Add(2766, Condition.DownedPlantera)
                    .Add(2607, Condition.Hardmode)
                    .Add(1328, Condition.Hardmode)
                    .Add(526, Condition.Hardmode)
                    .Add(4412)
                    .Add(215)
                    .Add(575, Condition.Hardmode)
                    .Add(520, Condition.Hardmode)
                    .Add(521, Condition.Hardmode)
                    .Add(548, Condition.DownedDestroyer)
                    .Add(549, Condition.DownedTwins)
                    .Add(547, Condition.DownedSkeletronPrime)
                    .Add(547, Condition.DownedSkeletronPrime)
                    .Add(3457, Condition.DownedCultist)
                    .Add(3458, Condition.DownedCultist)
                    .Add(3459, Condition.DownedCultist)
                    .Add(3456, Condition.DownedCultist);
            rMatShop.Register();

            var moveAccsShop = new NPCShop(Type, "Movement Accessories")
                   .Add(285)
                   .Add(212)
                   .Add(3225)
                   .Add(987)
                   .Add(953)
                   .Add(53)
                   .Add(268)
                   .Add(187)
                   .Add(4978)
                   .Add(934)
                   .Add(2423)
                   .Add(54)
                   .Add(950)
                   .Add(1303)
                   .Add(906)
                   .Add(158)
                   .Add(485, Condition.Hardmode)
                   .Add(497, Condition.DownedMechBossAny)
                   .Add(857)
                   .Add(159)
                   .Add(975)
                   .Add(977, Condition.DownedPlantera)
                   .Add(3201)
                   .Add(863);
            moveAccsShop.Register();

            var combatAccsShop = new NPCShop(Type, "Combat Accessories")
                    .Add(1612, Condition.Hardmode)
                    .Add(49)
                    .Add(111)
                    .Add(963, Condition.DownedPlantera)
                    .Add(2219)
                    .Add(156, Condition.DownedSkeletron)
                    .Add(554, Condition.Hardmode)
                    .Add(1248, Condition.DownedGolem)
                    .Add(211)
                    .Add(3016, Condition.Hardmode)
                    .Add(1253, Condition.Hardmode)
                    .Add(1921)
                    .Add(1132, Condition.DownedQueenBee)
                    .Add(1321, Condition.Hardmode)
                    .Add(1322)
                    .Add(900, Condition.DownedMechBossAny)
                    .Add(223)
                    .Add(1323)
                    .Add(193)
                    .Add(938, Condition.DownedPlantera)
                    .Add(1290)
                    .Add(535, Condition.Hardmode)
                    .Add(3781, Condition.Hardmode)
                    .Add(3015, Condition.Hardmode)
                    .Add(491, Condition.Hardmode)
                    .Add(1300, Condition.DownedPlantera)
                    .Add(216)
                    .Add(3212)
                    .Add(489, Condition.Hardmode)
                    .Add(532, Condition.Hardmode)
                    .Add(2998, Condition.Hardmode)
                    .Add(899, Condition.DownedGolem)
                    .Add(536, Condition.Hardmode)
                    .Add(490, Condition.Hardmode)
                    .Add(3809, Condition.Hardmode)
                    .Add(1167, Condition.DownedPlantera)
                    .Add(1845, Condition.DownedPlantera)
                    .Add(3334, Condition.Hardmode);
            combatAccsShop.Register();

            var infoShop = new NPCShop(Type, "Informative/Building Gear")
                    .Add(407)
                    .Add(1923)
                    .Add(3061)
                    .Add(3624)
                    .Add(4056)
                    .Add(4341)
                    .Add(4008)
                    .Add(410)
                    .Add(411)
                    .Add(5064)
                    .Add(2367)
                    .Add(2368)
                    .Add(2369)
                    .Add(2294)
                    .Add(3183)
                    .Add(2676)
                    .Add(3124)
                    .Add(3611, Condition.DownedSkeletron)
                    .Add(5043)
                    .Add(3213)
                    .Add(4263)
                    .Add(4819)
                    .Add(1326, Condition.Hardmode);
            infoShop.Register();

            var bossShop = new NPCShop(Type, "Treasure Bags & Crates")
                    .Add(3318, Condition.DownedKingSlime)
                    .Add(3319, Condition.DownedEyeOfCthulhu)
                    .Add(3320, Condition.DownedEowOrBoc)
                    .Add(3321, Condition.DownedEowOrBoc)
                    .Add(3322, Condition.DownedQueenBee)
                    .Add(3323, Condition.DownedSkeletron)
                    .Add(5111, Condition.DownedDeerclops)
                    .Add(3324, Condition.Hardmode)
                    .Add(4957, Condition.DownedQueenSlime)
                    .Add(3325, Condition.DownedDestroyer)
                    .Add(3326, Condition.DownedTwins)
                    .Add(3327, Condition.DownedSkeletronPrime)
                    .Add(3328, Condition.DownedPlantera)
                    .Add(3329, Condition.DownedGolem)
                    .Add(3860, Condition.DownedOldOnesArmyT3)
                    .Add(3330, Condition.DownedDukeFishron)
                    .Add(4782, Condition.DownedEmpressOfLight)
                    .Add(3332, Condition.DownedMoonLord)
                    .Add(3817, Condition.DownedOldOnesArmyAny)
                    .Add(2334, Condition.PreHardmode)
                    .Add(2335, Condition.PreHardmode)
                    .Add(2336, Condition.PreHardmode)
                    .Add(3208, Condition.PreHardmode)
                    .Add(3206, Condition.PreHardmode)
                    .Add(3203, Condition.PreHardmode)
                    .Add(3204, Condition.PreHardmode)
                    .Add(3207, Condition.PreHardmode)
                    .Add(3205, Condition.PreHardmode, Condition.DownedSkeletron)
                    .Add(4405, Condition.PreHardmode)
                    .Add(4407, Condition.PreHardmode)
                    .Add(4877, Condition.PreHardmode)
                    .Add(5002, Condition.PreHardmode)
                    .Add(3979, Condition.Hardmode)
                    .Add(3980, Condition.Hardmode)
                    .Add(3981, Condition.Hardmode)
                    .Add(3987, Condition.Hardmode)
                    .Add(3985, Condition.Hardmode)
                    .Add(3982, Condition.Hardmode)
                    .Add(3983, Condition.Hardmode)
                    .Add(3986, Condition.Hardmode)
                    .Add(3984, Condition.Hardmode, Condition.DownedSkeletron)
                    .Add(4406, Condition.Hardmode)
                    .Add(4408, Condition.Hardmode)
                    .Add(4878, Condition.Hardmode)
                    .Add(5003, Condition.Hardmode);
            bossShop.Register();

            var naturalBlockShop = new NPCShop(Type, "Natural Blocks")
                    .Add(2)
                    .Add(3)
                    .Add(3086)
                    .Add(3081)
                    .Add(169)
                    .Add(3271)
                    .Add(3272)
                    .Add(3347)
                    .Add(133)
                    .Add(176)
                    .Add(172)
                    .Add(424)
                    .Add(593)
                    .Add(664)
                    .Add(1103)
                    .Add(751)
                    .Add(765)
                    .Add(61)
                    .Add(836)
                    .Add(409)
                    .Add(1124)
                    .Add(1125)
                    .Add(1127)
                    .Add(9)
                    .Add(2503)
                    .Add(2504)
                    .Add(620)
                    .Add(619)
                    .Add(911)
                    .Add(621, Condition.Hardmode)
                    .Add(2260)
                    .Add(1729, Condition.DownedPlantera)
                    .Add(183)
                    .Add(1727)
                    .Add(276)
                    .Add(1725)
                    .Add(4564)
                    .Add(173)
                    .Add(502, Condition.Hardmode);
            naturalBlockShop.Register();

            var buildingBlockShop = new NPCShop(Type, "Building Blocks")
                    .Add(129)
                    .Add(131)
                    .Add(607)
                    .Add(594)
                    .Add(883)
                    .Add(414)
                    .Add(413)
                    .Add(145)
                    .Add(2173)
                    .Add(717)
                    .Add(2692)
                    .Add(3951)
                    .Add(3953)
                    .Add(143)
                    .Add(718)
                    .Add(141)
                    .Add(719)
                    .Add(609)
                    .Add(4050)
                    .Add(577)
                    .Add(2793)
                    .Add(3100)
                    .Add(192)
                    .Add(214)
                    .Add(412)
                    .Add(415)
                    .Add(1589)
                    .Add(416)
                    .Add(1591)
                    .Add(604)
                    .Add(1593)
                    .Add(2792)
                    .Add(3461)
                    .Add(134)
                    .Add(137)
                    .Add(139)
                    .Add(1101)
                    .Add(2435)
                    .Add(2860, Condition.DownedGolem);
            buildingBlockShop.Register();

            var plantShop = new NPCShop(Type, "Herbs & Plants")
                    .Add(3093)
                    .Add(315)
                    .Add(313)
                    .Add(316)
                    .Add(318)
                    .Add(314)
                    .Add(2358)
                    .Add(317)
                    .Add(1828, Condition.DownedEyeOfCthulhu)
                    .Add(1107)
                    .Add(1108)
                    .Add(1109)
                    .Add(1110)
                    .Add(1111)
                    .Add(1112)
                    .Add(1113)
                    .Add(1114)
                    .Add(60)
                    .Add(2887)
                    .Add(5)
                    .Add(4349)
                    .Add(4350)
                    .Add(4351)
                    .Add(4352)
                    .Add(4353)
                    .Add(4354)
                    .Add(4377)
                    .Add(4378)
                    .Add(4389)
                    .Add(62)
                    .Add(195)
                    .Add(194)
                    .Add(59)
                    .Add(2171)
                    .Add(369, Condition.Hardmode)
                    .Add(27);
            plantShop.Register();

            var stationShop = new NPCShop(Type, "Station Buffs & Foods")
                    .Add(4624)
                    .Add(4403)
                    .Add(4022)
                    .Add(63)
                    .Add(966)
                    .Add(487, Condition.Hardmode)
                    .Add(2177)
                    .Add(3198)
                    .Add(2999, Condition.DownedSkeletron)
                    .Add(4276)
                    .Add(3750)
                    .Add(1431)
                    .Add(1859)
                    .Add(4609)
                    .Add(3117)
                    .Add(148, Condition.DownedSkeletron)
                    .Add(206)
                    .Add(207)
                    .Add(1128);
            stationShop.Register();
        }
    }
}
