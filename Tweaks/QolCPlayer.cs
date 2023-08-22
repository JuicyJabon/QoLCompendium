using QoLCompendium.Items;
using QoLCompendium.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    public class QoLCPlayer : ModPlayer
    {
        public bool magnetActive = false;

        public Dictionary<int, EndlessBuffSource> EndlessBuffSources = new();

        public List<ValueTuple<Item, string>> ItemsToCountForEndlessBuffs = new();

        public int InventoryItemsStart;

        public int PiggyBankItemsStart;

        public int SafeItemsStart;

        public int DefendersForgeItemsStart;

        public bool enemyEraser = false;

        public bool enemyAggressor = false;

        public bool headCounter = false;

        public int respawnFullHPTimer;

        public int selectedBiome = 0;

        public bool bloodIdol = false;

        public bool eclipseIdol = false;

        public override void ResetEffects()
        {
            magnetActive = false;
            enemyEraser = false;
            enemyAggressor = false;
            headCounter = false;
            bloodIdol = false;
            eclipseIdol = false;

            if (Main.netMode != NetmodeID.Server)
            {
                if (Main.player[Main.myPlayer].talkNPC == -1)
                {
                    BMNPCUI.visible = false;
                    ECNPCUI.visible = false;
                }
            }
        }

        public override void UpdateDead()
        {
            magnetActive = false;
            enemyEraser = false;
            enemyAggressor = false;
            headCounter = false;
            bloodIdol = false;
            eclipseIdol = false;

            if (Main.netMode != NetmodeID.Server)
            {
                if (Main.player[Main.myPlayer].talkNPC == -1)
                {
                    BMNPCUI.visible = false;
                    ECNPCUI.visible = false;
                }
            }
        }

        public override void PostUpdateMiscEffects()
        {
            if (ModContent.GetInstance<QoLCConfig>().IncreasePlaceSpeed)
            {
                Player.tileSpeed -= 3f;
                Player.wallSpeed -= 3f;
            }

            Player.tileRangeX += ModContent.GetInstance<QoLCConfig>().IncreasePlaceRange;
            Player.tileRangeY += ModContent.GetInstance<QoLCConfig>().IncreasePlaceRange;
        }

        public override void OnRespawn()
        {
            if (ModContent.GetInstance<QoLCConfig>().FullHPRespawn)
            {
                respawnFullHPTimer = 1;
            }
        }

        public override void PostUpdate()
        {
            if (ModContent.GetInstance<QoLCConfig>().FullHPRespawn)
            {
                if (respawnFullHPTimer == 0)
                {
                    respawnFullHPTimer = -1;
                    Player.statLife = Player.statLifeMax2;
                    Player.statMana = Player.statManaMax2;
                }
                respawnFullHPTimer--;
            }
        }

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            if (ModContent.GetInstance<QoLCConfig>().InstantRespawn && Main.netMode != NetmodeID.MultiplayerClient)
            {
                for (int i = 0; i < Main.npc.Length; i++)
                {
                    if (Main.npc[i].active && Main.npc[i].boss)
                    {
                        Main.npc[i].active = false;
                    }
                }
                Player.respawnTimer = 60;
            }
        }

        public override void PreUpdateBuffs()
        {
            if (ModContent.GetInstance<QoLCConfig>().ToggleHappiness)
            {
                Player.currentShoppingSettings.PriceAdjustment = 0.75;
            }
        }

        public override void UpdateEquips()
        {
            if (ModContent.GetInstance<QoLCConfig>().InformationBanks)
            {
                Item[] item = Player.bank.item;
                Item[] item2 = Player.bank2.item;
                Item[] item3 = Player.bank3.item;
                Item[] item4 = Player.bank4.item;
                for (int i = 0; i < item.Length; i++)
                {
                    CheckTrinkets(item[i].type);
                }
                for (int j = 0; j < item2.Length; j++)
                {
                    CheckTrinkets(item2[j].type);
                }
                for (int k = 0; k < item3.Length; k++)
                {
                    CheckTrinkets(item3[k].type);
                }
                for (int l = 0; l < item4.Length; l++)
                {
                    CheckTrinkets(item4[l].type);
                }
            }
        }

        private void CheckTrinkets(int itemType)
        {
            if (itemType == 854)
            {
                Player.discountAvailable = true;
                return;
            }
            if (itemType == 855)
            {
                Player.hasLuckyCoin = true;
                return;
            }
            if (itemType == 3033)
            {
                Player.goldRing = true;
                return;
            }
            if (itemType == 3034)
            {
                Player.discountAvailable = true;
                Player.hasLuckyCoin = true;
                Player.luck += 0.05f;
                return;
            }
            if (itemType == 3035)
            {
                Player.discountAvailable = true;
                Player.hasLuckyCoin = true;
                Player.goldRing = true;
                Player.luck += 0.05f;
                return;
            }
            if (itemType == 3619)
            {
                Player.InfoAccMechShowWires = true;
                return;
            }
            if (itemType == 3611)
            {
                Player.InfoAccMechShowWires = true;
                Player.rulerGrid = true;
                return;
            }
            if (itemType == 2799)
            {
                Player.rulerGrid = true;
                return;
            }
            if (itemType == 3624)
            {
                Player.autoActuator = true;
                return;
            }
            if (itemType == 2216 || itemType == 3061)
            {
                Player.autoPaint = true;
                return;
            }
            if (itemType == 3123 || itemType == 3124 || itemType == 5437 || itemType == 5358 || itemType == 5359 || itemType == 5360 || itemType == 5361)
            {
                Player.accWatch = 3;
                Player.accDepthMeter = 1;
                Player.accCompass = 1;
                Player.accThirdEye = true;
                Player.accCritterGuide = true;
                Player.accJarOfSouls = true;
                Player.accOreFinder = true;
                Player.accStopwatch = true;
                Player.accDreamCatcher = true;
                Player.accFishFinder = true;
                Player.accWeatherRadio = true;
                Player.accCalendar = true;
                return;
            }
            if (itemType == 395)
            {
                Player.accWatch = 3;
                Player.accDepthMeter = 1;
                Player.accCompass = 1;
                return;
            }
            if (itemType == 3122)
            {
                Player.accThirdEye = true;
                Player.accCritterGuide = true;
                Player.accJarOfSouls = true;
                return;
            }
            if (itemType == 3121)
            {
                Player.accOreFinder = true;
                Player.accStopwatch = true;
                Player.accDreamCatcher = true;
                return;
            }
            if (itemType == 3036)
            {
                Player.accFishFinder = true;
                Player.accWeatherRadio = true;
                Player.accCalendar = true;
                return;
            }
            if ((itemType == 15 || itemType == 707) && Player.accWatch < 1)
            {
                Player.accWatch = 1;
                return;
            }
            if ((itemType == 16 || itemType == 708) && Player.accWatch < 2)
            {
                Player.accWatch = 2;
                return;
            }
            if (itemType == 17 || itemType == 709)
            {
                Player.accWatch = 3;
                return;
            }
            if (itemType == 18)
            {
                Player.accDepthMeter = 1;
                return;
            }
            if (itemType == 393)
            {
                Player.accCompass = 1;
                return;
            }
            if (itemType == 3084)
            {
                Player.accThirdEye = true;
                return;
            }
            if (itemType == 3118)
            {
                Player.accCritterGuide = true;
                return;
            }
            if (itemType == 3095)
            {
                Player.accJarOfSouls = true;
                return;
            }
            if (itemType == 3102)
            {
                Player.accOreFinder = true;
                return;
            }
            if (itemType == 3099)
            {
                Player.accStopwatch = true;
                return;
            }
            if (itemType == 3119)
            {
                Player.accDreamCatcher = true;
                return;
            }
            if (itemType == 3120)
            {
                Player.accFishFinder = true;
                return;
            }
            if (itemType == 3037)
            {
                Player.accWeatherRadio = true;
                return;
            }
            if (itemType == 3096)
            {
                Player.accCalendar = true;
                return;
            }
            if (itemType == 407)
            {
                Player.blockRange += 1;
                return;
            }
            if (itemType == 1923)
            {
                Player.blockRange += 1;
                Player.tileRangeX += 1;
                Player.tileRangeY += 1;
                return;
            }
            if (itemType == 2215)
            {
                Player.blockRange += 3;
                Player.tileRangeX += 3;
                Player.tileRangeY += 3;
                return;
            }
            if (itemType == 2217)
            {
                Player.wallSpeed -= 0.5f;
                return;
            }
            if (itemType == 2214)
            {
                Player.tileSpeed -= 0.5f;
                return;
            }
            if (itemType == 3061)
            {
                Player.autoPaint = true;
                Player.wallSpeed -= 0.5f;
                Player.tileSpeed -= 0.5f;
                Player.blockRange += 3;
                Player.tileRangeX += 3;
                Player.tileRangeY += 3;
                return;
            }
            if (itemType == 5126)
            {
                Player.autoPaint = true;
                Player.wallSpeed -= 0.5f;
                Player.tileSpeed -= 0.5f;
                Player.blockRange += 3;
                Player.tileRangeX += 3;
                Player.tileRangeY += 3;
                Player.pickSpeed -= 0.25f;
                Player.treasureMagnet = true;
                return;
            }
            if (itemType == 4056)
            {
                Player.pickSpeed -= 0.25f;
                return;
            }
            if (itemType == 2373)
            {
                Player.accFishingLine = true;
                return;
            }
            if (itemType == 2374)
            {
                Player.fishingSkill += 10;
                return;
            }
            if (itemType == 2375)
            {
                Player.accTackleBox = true;
                return;
            }
            if (itemType == 4881)
            {
                Player.accLavaFishing = true;
                return;
            }
            if (itemType == 3721)
            {
                Player.accFishingLine = true;
                Player.fishingSkill += 10;
                Player.accTackleBox = true;
                return;
            }
            if (itemType == 5064)
            {
                Player.accLavaFishing = true;
                Player.accFishingLine = true;
                Player.fishingSkill += 10;
                Player.accTackleBox = true;
                return;
            }
            if (itemType == 5139 || itemType == 5140 || itemType == 5141 || itemType == 5142 || itemType == 5143 || itemType == 5144 || itemType == 5145 || itemType == 5146)
            {
                Player.fishingSkill += 10;
                return;
            }
            if (itemType == 5010)
            {
                Player.treasureMagnet = true;
                return;
            }
            if (itemType == 3090)
            {
                Player.npcTypeNoAggro[1] = true;
                Player.npcTypeNoAggro[16] = true;
                Player.npcTypeNoAggro[59] = true;
                Player.npcTypeNoAggro[71] = true;
                Player.npcTypeNoAggro[81] = true;
                Player.npcTypeNoAggro[138] = true;
                Player.npcTypeNoAggro[121] = true;
                Player.npcTypeNoAggro[122] = true;
                Player.npcTypeNoAggro[141] = true;
                Player.npcTypeNoAggro[147] = true;
                Player.npcTypeNoAggro[183] = true;
                Player.npcTypeNoAggro[184] = true;
                Player.npcTypeNoAggro[204] = true;
                Player.npcTypeNoAggro[225] = true;
                Player.npcTypeNoAggro[244] = true;
                Player.npcTypeNoAggro[302] = true;
                Player.npcTypeNoAggro[333] = true;
                Player.npcTypeNoAggro[335] = true;
                Player.npcTypeNoAggro[334] = true;
                Player.npcTypeNoAggro[336] = true;
                Player.npcTypeNoAggro[537] = true;
                return;
            }
            if (itemType == 4409)
            {
                Player.CanSeeInvisibleBlocks = true;
                return;
            }
            if (itemType == 3068)
            {
                Player.cordage = true;
            }
            if (itemType == 4767)
            {
                Player.dontHurtCritters = true;
            }
            if (itemType == 5309)
            {
                Player.dontHurtNature = true;
            }
            if (itemType == 5323)
            {
                Player.dontHurtCritters = true;
                Player.dontHurtNature = true;
            }
            if (itemType == ModContent.ItemType<HeadCounter>())
            {
                headCounter = true;
                return;
            }
        }

        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
            if (ModContent.GetInstance<ItemConfig>().StarterBag)
            {
                return new[] {
                new Item(ModContent.ItemType<StarterBag>())
                };
            }
            else
            {
                return Enumerable.Empty<Item>();
            }
        }
    }
}
