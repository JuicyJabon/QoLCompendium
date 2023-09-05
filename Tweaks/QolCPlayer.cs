using QoLCompendium.Items;
using QoLCompendium.UI;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    public class QoLCPlayer : ModPlayer
    {
        public bool magnetActive = false;

        public bool enemyEraser = false;

        public bool enemyAggressor = false;

        public bool enemyCalmer = false;

        public bool bloodIdol = false;

        public bool eclipseIdol = false;

        public bool headCounter = false;

        public bool metallicClover = false;

        public bool trackingDevice = false;

        public bool battalionLog = false;

        public int respawnFullHPTimer = 0;

        public int selectedBiome = 0;

        public int selectedSpawnModifier = 5;

        public int spawnRateUpdateTimer;
        public int spawnRate;
        static FieldInfo spawnRateFieldInfo;

        public override void PreUpdate()
        {
            if (spawnRateUpdateTimer > 0)
            {
                spawnRateUpdateTimer--;
            }
        }

        public override void PreUpdateBuffs()
        {
            if (ModContent.GetInstance<QoLCConfig>().ToggleHappiness)
            {
                Player.currentShoppingSettings.PriceAdjustment = ModContent.GetInstance<QoLCConfig>().HappinessPriceChange;
            }
        }

        public override void PostUpdate()
        {
            if (ModContent.GetInstance<QoLCConfig>().FullHPRespawn && respawnFullHPTimer == 0)
            {
                respawnFullHPTimer = -1;
                Player.statLife = Player.statLifeMax2;
                Player.statMana = Player.statManaMax2;
            }
            respawnFullHPTimer--;
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

            if (spawnRateUpdateTimer <= 0)
            {
                spawnRateUpdateTimer = 60;

                spawnRateFieldInfo = typeof(NPC).GetField("spawnRate", BindingFlags.Static | BindingFlags.NonPublic);

                spawnRate = (int)spawnRateFieldInfo.GetValue(null);
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

        public override void OnRespawn()
        {
            if (ModContent.GetInstance<QoLCConfig>().FullHPRespawn)
            {
                respawnFullHPTimer = 1;
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
            if (itemType == ItemID.DiscountCard)
            {
                Player.discountAvailable = true;
                return;
            }
            if (itemType == ItemID.LuckyCoin)
            {
                Player.hasLuckyCoin = true;
                return;
            }
            if (itemType == ItemID.GoldRing)
            {
                Player.goldRing = true;
                return;
            }
            if (itemType == ItemID.CoinRing)
            {
                Player.discountAvailable = true;
                Player.hasLuckyCoin = true;
                Player.luck += 0.05f;
                return;
            }
            if (itemType == ItemID.GreedyRing)
            {
                Player.discountAvailable = true;
                Player.hasLuckyCoin = true;
                Player.goldRing = true;
                Player.luck += 0.05f;
                return;
            }
            if (itemType == ItemID.MechanicalLens)
            {
                Player.InfoAccMechShowWires = true;
                return;
            }
            if (itemType == ItemID.LaserRuler)
            {
                Player.rulerGrid = true;
                return;
            }
            if (itemType == ItemID.WireKite)
            {
                Player.InfoAccMechShowWires = true;
                Player.rulerGrid = true;
                return;
            }
            if (itemType == ItemID.PDA || itemType == ItemID.CellPhone || itemType == ItemID.ShellphoneDummy || itemType == ItemID.Shellphone || itemType == ItemID.ShellphoneSpawn || itemType == ItemID.ShellphoneOcean || itemType == ItemID.ShellphoneHell)
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
            if (itemType == ItemID.GPS)
            {
                Player.accWatch = 3;
                Player.accDepthMeter = 1;
                Player.accCompass = 1;
                return;
            }
            if (itemType == ItemID.REK)
            {
                Player.accThirdEye = true;
                Player.accCritterGuide = true;
                Player.accJarOfSouls = true;
                return;
            }
            if (itemType == ItemID.GoblinTech)
            {
                Player.accOreFinder = true;
                Player.accStopwatch = true;
                Player.accDreamCatcher = true;
                return;
            }
            if (itemType == ItemID.FishFinder)
            {
                Player.accFishFinder = true;
                Player.accWeatherRadio = true;
                Player.accCalendar = true;
                return;
            }
            if ((itemType == ItemID.CopperWatch || itemType == ItemID.TinWatch) && Player.accWatch < 1)
            {
                Player.accWatch = 1;
                return;
            }
            if ((itemType == ItemID.SilverWatch || itemType == ItemID.TungstenWatch) && Player.accWatch < 2)
            {
                Player.accWatch = 2;
                return;
            }
            if (itemType == ItemID.GoldWatch || itemType == ItemID.PlatinumWatch)
            {
                Player.accWatch = 3;
                return;
            }
            if (itemType == ItemID.DepthMeter)
            {
                Player.accDepthMeter = 1;
                return;
            }
            if (itemType == ItemID.Compass)
            {
                Player.accCompass = 1;
                return;
            }
            if (itemType == ItemID.Radar)
            {
                Player.accThirdEye = true;
                return;
            }
            if (itemType == ItemID.LifeformAnalyzer)
            {
                Player.accCritterGuide = true;
                return;
            }
            if (itemType == ItemID.TallyCounter)
            {
                Player.accJarOfSouls = true;
                return;
            }
            if (itemType == ItemID.MetalDetector)
            {
                Player.accOreFinder = true;
                return;
            }
            if (itemType == ItemID.Stopwatch)
            {
                Player.accStopwatch = true;
                return;
            }
            if (itemType == ItemID.DPSMeter)
            {
                Player.accDreamCatcher = true;
                return;
            }
            if (itemType == ItemID.FishermansGuide)
            {
                Player.accFishFinder = true;
                return;
            }
            if (itemType == ItemID.WeatherRadio)
            {
                Player.accWeatherRadio = true;
                return;
            }
            if (itemType == ItemID.Sextant)
            {
                Player.accCalendar = true;
                return;
            }
            if (itemType == ItemID.AncientChisel)
            {
                Player.pickSpeed -= 0.25f;
                return;
            }
            if (itemType == ItemID.Toolbelt)
            {
                Player.blockRange += 1;
                return;
            }
            if (itemType == ItemID.Toolbox)
            {
                Player.blockRange += 1;
                Player.tileRangeX += 1;
                Player.tileRangeY += 1;
                return;
            }
            if (itemType == ItemID.ExtendoGrip)
            {
                Player.blockRange += 3;
                Player.tileRangeX += 3;
                Player.tileRangeY += 3;
                return;
            }
            if (itemType == ItemID.PortableCementMixer)
            {
                Player.wallSpeed -= 0.5f;
                return;
            }
            if (itemType == ItemID.PaintSprayer)
            {
                Player.autoPaint = true;
                return;
            }
            if (itemType == ItemID.BrickLayer)
            {
                Player.tileSpeed -= 0.5f;
                return;
            }
            if (itemType == ItemID.ArchitectGizmoPack)
            {
                Player.autoPaint = true;
                Player.wallSpeed -= 0.5f;
                Player.tileSpeed -= 0.5f;
                Player.blockRange += 3;
                Player.tileRangeX += 3;
                Player.tileRangeY += 3;
                return;
            }
            if (itemType == ItemID.HandOfCreation)
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
            if (itemType == ItemID.ActuationAccessory)
            {
                Player.autoActuator = true;
                return;
            }
            if (itemType == ItemID.HighTestFishingLine)
            {
                Player.accFishingLine = true;
                return;
            }
            if (itemType == ItemID.AnglerEarring)
            {
                Player.fishingSkill += 10;
                return;
            }
            if (itemType == ItemID.TackleBox)
            {
                Player.accTackleBox = true;
                return;
            }
            if (itemType == ItemID.LavaFishingHook)
            {
                Player.accLavaFishing = true;
                return;
            }
            if (itemType == ItemID.AnglerTackleBag)
            {
                Player.accFishingLine = true;
                Player.fishingSkill += 10;
                Player.accTackleBox = true;
                return;
            }
            if (itemType == ItemID.LavaproofTackleBag)
            {
                Player.accLavaFishing = true;
                Player.accFishingLine = true;
                Player.fishingSkill += 10;
                Player.accTackleBox = true;
                return;
            }
            if (itemType == ItemID.FishingBobber || itemType == ItemID.FishingBobberGlowingStar || itemType == ItemID.FishingBobberGlowingLava || itemType == ItemID.FishingBobberGlowingKrypton || itemType == ItemID.FishingBobberGlowingXenon || itemType == ItemID.FishingBobberGlowingArgon || itemType == ItemID.FishingBobberGlowingViolet || itemType == ItemID.FishingBobberGlowingRainbow)
            {
                Player.fishingSkill += 10;
                return;
            }
            if (itemType == ItemID.TreasureMagnet)
            {
                Player.treasureMagnet = true;
                return;
            }
            if (itemType == ItemID.RoyalGel)
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
            if (itemType == ItemID.SpectreGoggles)
            {
                Player.CanSeeInvisibleBlocks = true;
                return;
            }
            if (itemType == ItemID.CordageGuide)
            {
                Player.cordage = true;
            }
            if (itemType == ItemID.DontHurtCrittersBook)
            {
                Player.dontHurtCritters = true;
            }
            if (itemType == ItemID.DontHurtNatureBook)
            {
                Player.dontHurtNature = true;
            }
            if (itemType == ItemID.DontHurtComboBook)
            {
                Player.dontHurtCritters = true;
                Player.dontHurtNature = true;
            }
            if (itemType == ModContent.ItemType<HeadCounter>())
            {
                headCounter = true;
                return;
            }
            if (itemType == ModContent.ItemType<MetallicClover>())
            {
                metallicClover = true;
                return;
            }
            if (itemType == ModContent.ItemType<TrackingDevice>())
            {
                trackingDevice = true;
                return;
            }
            if (itemType == ModContent.ItemType<BattalionLog>())
            {
                battalionLog = true;
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

        public override void ResetEffects()
        {
            Reset();
        }

        public override void UpdateDead()
        {
            Reset();
        }

        public void Reset()
        {
            magnetActive = false;
            enemyEraser = false;
            enemyAggressor = false;
            enemyCalmer = false;
            bloodIdol = false;
            eclipseIdol = false;
            headCounter = false;
            metallicClover = false;
            trackingDevice = false;
            battalionLog = false;

            if (Main.netMode != NetmodeID.Server)
            {
                if (Main.player[Main.myPlayer].talkNPC == -1)
                {
                    BMNPCUI.visible = false;
                    ECNPCUI.visible = false;
                }
            }
        }
    }
}
