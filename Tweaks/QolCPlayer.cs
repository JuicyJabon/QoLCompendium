using QoLCompendium.Items.Dedicated;
using QoLCompendium.Items.InformationAccessories;
using QoLCompendium.Items.Mirrors;
using QoLCompendium.Items.Tools;
using QoLCompendium.Projectiles;
using QoLCompendium.UI;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Tweaks
{
    public class QoLCPlayer : ModPlayer
    {
        public bool battalionLog = false;

        public bool bloodIdol = false;

        public bool eclipseIdol = false;

        public bool enemyAggressor = false;

        public bool enemyCalmer = false;

        public bool enemyEraser = false;

        public bool harmInducer = false;

        public bool headCounter = false;

        public bool kettlebell = false;

        public bool luckyDie = false;

        public bool metallicClover = false;

        public bool plateCracker = false;

        public bool regenerator = false;

        public bool reinforcedPanel = false;

        public bool replenisher = false;

        public bool sillySlapper = false;

        public bool trackingDevice = false;

        public bool wingTimer = false;

        public int respawnFullHPTimer = 0;

        public int selectedBiome = 0;

        public int selectedSpawnModifier = 5;

        public int spawnRate;
        public int spawnRateUpdateTimer;
        static FieldInfo spawnRateFieldInfo;

        internal bool chests;
        internal int safe = -1;
        internal int defenders = -1;

        public bool joinedTeam = false;

        public override void ResetEffects()
        {
            Reset();
        }

        public override void UpdateDead()
        {
            Reset();
        }

        public override void SaveData(TagCompound tag)
        {
            tag.Add("SelectedBiome", selectedBiome);
            tag.Add("SelectedSpawnModifier", selectedSpawnModifier);
        }

        public override void LoadData(TagCompound tag)
        {
            selectedBiome = tag.GetInt("SelectedBiome");
            selectedSpawnModifier = tag.GetInt("SelectedSpawnModifier");
        }

        public override void PreUpdate()
        {
            if (spawnRateUpdateTimer > 0)
            {
                spawnRateUpdateTimer--;
            }
        }

        public override void PreUpdateBuffs()
        {
            if (Player.HeldItem.type == ModContent.ItemType<SillySlapper>())
            {
                Player.GetDamage(DamageClass.Generic) *= 2;
                sillySlapper = true;
            }

            if (QoLCompendium.mainConfig.ToggleHappiness)
            {
                Player.currentShoppingSettings.PriceAdjustment = QoLCompendium.mainConfig.HappinessPriceChange;
            }
        }

        public override void PostUpdate()
        {
            if (ModConditions.reforgedLoaded && ModAccessorySlot.Player.equippedWings.social != true)
            {
                ModConditions.reforgedMod.Call("PostUpdateModPlayer", Main.LocalPlayer.whoAmI, ModAccessorySlot.Player.equippedWings);
            }

            if (QoLCompendium.mainConfig.FullHPRespawn && respawnFullHPTimer == 0)
            {
                respawnFullHPTimer = -1;
                Player.statLife = Player.statLifeMax2;
                Player.statMana = Player.statManaMax2;
            }
            respawnFullHPTimer--;
        }

        public override void PostUpdateEquips()
        {
            if (ModContent.GetInstance<QoLCConfig>().NoChilled && Player.wet && Player.ZoneSnow && Main.expertMode)
            {
                Player.buffImmune[BuffID.Chilled] = true;
            }
        }

        public override void PostUpdateMiscEffects()
        {
            Player.tileSpeed -= QoLCompendium.mainConfig.IncreasePlaceSpeed;
            Player.wallSpeed -= QoLCompendium.mainConfig.IncreasePlaceSpeed;

            Player.tileRangeX += QoLCompendium.mainConfig.IncreasePlaceRange;
            Player.tileRangeY += QoLCompendium.mainConfig.IncreasePlaceRange;

            if (spawnRateUpdateTimer <= 0)
            {
                spawnRateUpdateTimer = 60;

                spawnRateFieldInfo = typeof(NPC).GetField("spawnRate", BindingFlags.Static | BindingFlags.NonPublic);

                spawnRate = (int)spawnRateFieldInfo.GetValue(null);
            }
        }

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            if (QoLCompendium.mainConfig.InstantRespawn && Main.netMode == NetmodeID.SinglePlayer)
            {
                for (int k = 0; k < Main.maxNPCs; k++)
                {
                    if (Main.npc[k].boss && Main.npc[k].active)
                    {
                        DespawnNPC(k);
                    }
                    Player.respawnTimer = 60;
                }
            }
        }

        public override void OnHurt(Player.HurtInfo info)
        {
            if (sillySlapper)
            {
                Player.KillMe(PlayerDeathReason.ByCustomReason(Player.name + " was slapped too silly"), 666666, 0);
            }
        }

        public static void DespawnNPC(int npc)
        {
            Main.npc[npc].life = 0;
            Main.npc[npc].active = false;
            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, npc, 0f, 0f, 0f, 0, 0, 0);
            }
        }

        public override void OnRespawn()
        {
            if (QoLCompendium.mainConfig.FullHPRespawn)
            {
                respawnFullHPTimer = 1;
            }
        }

        public override void SetControls()
        {
            if (Player.whoAmI == Main.myPlayer && chests)
            {
                Main.SmartCursorShowing = false;
                Player.tileRangeX = 9999;
                Player.tileRangeY = 5000;
                if (Player.chest >= -1)
                {
                    safe = -1;
                    defenders = -1;
                    chests = false;
                }
                if (safe != -1 && Main.projectile[safe].type != ModContent.ProjectileType<WeightlessSafeProj>())
                {
                    safe = -1;
                    chests = false;
                }
                if (defenders != -1 && Main.projectile[defenders].type != ModContent.ProjectileType<DefendersCatalystProj>())
                {
                    defenders = -1;
                    chests = false;
                }
            }
        }

        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (Player != Main.player[Main.myPlayer])
            {
                return;
            }

            if (QoLCompendium.mainConfig.AutoTeams > 0 && joinedTeam == false)
            {
                Main.player[Main.myPlayer].team = QoLCompendium.mainConfig.AutoTeams;
                joinedTeam = true;
                NetMessage.SendData(MessageID.PlayerTeam, -1, -1, null, Main.myPlayer, QoLCompendium.mainConfig.AutoTeams, 0f, 0f, 0, 0, 0);
            }
        }

        public override void UpdateEquips()
        {
            if (QoLCompendium.mainConfig.InformationBanks)
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
            }
            if (itemType == ItemID.LuckyCoin)
            {
                Player.hasLuckyCoin = true;
            }
            if (itemType == ItemID.GoldRing)
            {
                Player.goldRing = true;
            }
            if (itemType == ItemID.CoinRing)
            {
                Player.discountAvailable = true;
                Player.hasLuckyCoin = true;
                Player.luck += 0.05f;
            }
            if (itemType == ItemID.GreedyRing)
            {
                Player.discountAvailable = true;
                Player.hasLuckyCoin = true;
                Player.goldRing = true;
                Player.luck += 0.05f;
            }
            if (itemType == ItemID.MechanicalLens)
            {
                Player.InfoAccMechShowWires = true;
            }
            if (itemType == ItemID.LaserRuler)
            {
                Player.rulerGrid = true;
            }
            if (itemType == ItemID.WireKite)
            {
                Player.InfoAccMechShowWires = true;
                Player.rulerGrid = true;
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
            }
            if (itemType == ItemID.GPS)
            {
                Player.accWatch = 3;
                Player.accDepthMeter = 1;
                Player.accCompass = 1;
            }
            if (itemType == ItemID.REK)
            {
                Player.accThirdEye = true;
                Player.accCritterGuide = true;
                Player.accJarOfSouls = true;
            }
            if (itemType == ItemID.GoblinTech)
            {
                Player.accOreFinder = true;
                Player.accStopwatch = true;
                Player.accDreamCatcher = true;
            }
            if (itemType == ItemID.FishFinder)
            {
                Player.accFishFinder = true;
                Player.accWeatherRadio = true;
                Player.accCalendar = true;
            }
            if ((itemType == ItemID.CopperWatch || itemType == ItemID.TinWatch) && Player.accWatch < 1)
            {
                Player.accWatch = 1;
            }
            if ((itemType == ItemID.SilverWatch || itemType == ItemID.TungstenWatch) && Player.accWatch < 2)
            {
                Player.accWatch = 2;
            }
            if (itemType == ItemID.GoldWatch || itemType == ItemID.PlatinumWatch)
            {
                Player.accWatch = 3;
            }
            if (itemType == ItemID.DepthMeter)
            {
                Player.accDepthMeter = 1;
            }
            if (itemType == ItemID.Compass)
            {
                Player.accCompass = 1;
            }
            if (itemType == ItemID.Radar)
            {
                Player.accThirdEye = true;
            }
            if (itemType == ItemID.LifeformAnalyzer)
            {
                Player.accCritterGuide = true;
            }
            if (itemType == ItemID.TallyCounter)
            {
                Player.accJarOfSouls = true;
            }
            if (itemType == ItemID.MetalDetector)
            {
                Player.accOreFinder = true;
            }
            if (itemType == ItemID.Stopwatch)
            {
                Player.accStopwatch = true;
            }
            if (itemType == ItemID.DPSMeter)
            {
                Player.accDreamCatcher = true;
            }
            if (itemType == ItemID.FishermansGuide)
            {
                Player.accFishFinder = true;
            }
            if (itemType == ItemID.WeatherRadio)
            {
                Player.accWeatherRadio = true;
            }
            if (itemType == ItemID.Sextant)
            {
                Player.accCalendar = true;
            }
            if (itemType == ItemID.AncientChisel)
            {
                Player.pickSpeed -= 0.25f;
            }
            if (itemType == ItemID.Toolbelt)
            {
                Player.blockRange += 1;
            }
            if (itemType == ItemID.Toolbox)
            {
                Player.blockRange += 1;
                Player.tileRangeX += 1;
                Player.tileRangeY += 1;
            }
            if (itemType == ItemID.ExtendoGrip)
            {
                Player.blockRange += 3;
                Player.tileRangeX += 3;
                Player.tileRangeY += 3;
            }
            if (itemType == ItemID.PortableCementMixer)
            {
                Player.wallSpeed += 0.5f;
            }
            if (itemType == ItemID.PaintSprayer)
            {
                Player.autoPaint = true;
            }
            if (itemType == ItemID.BrickLayer)
            {
                Player.tileSpeed += 0.5f;
            }
            if (itemType == ItemID.ArchitectGizmoPack)
            {
                Player.autoPaint = true;
                Player.wallSpeed += 0.5f;
                Player.tileSpeed += 0.5f;
                Player.blockRange += 3;
                Player.tileRangeX += 3;
                Player.tileRangeY += 3;
            }
            if (itemType == ItemID.HandOfCreation)
            {
                Player.autoPaint = true;
                Player.wallSpeed += 0.5f;
                Player.tileSpeed += 0.5f;
                Player.blockRange += 3;
                Player.tileRangeX += 3;
                Player.tileRangeY += 3;
                Player.pickSpeed -= 0.25f;
                Player.treasureMagnet = true;
            }
            if (itemType == ItemID.ActuationAccessory)
            {
                Player.autoActuator = true;
            }
            if (itemType == ItemID.HighTestFishingLine)
            {
                Player.accFishingLine = true;
            }
            if (itemType == ItemID.AnglerEarring)
            {
                Player.fishingSkill += 10;
            }
            if (itemType == ItemID.TackleBox)
            {
                Player.accTackleBox = true;
            }
            if (itemType == ItemID.LavaFishingHook)
            {
                Player.accLavaFishing = true;
            }
            if (itemType == ItemID.AnglerTackleBag)
            {
                Player.accFishingLine = true;
                Player.fishingSkill += 10;
                Player.accTackleBox = true;
            }
            if (itemType == ItemID.LavaproofTackleBag)
            {
                Player.accLavaFishing = true;
                Player.accFishingLine = true;
                Player.fishingSkill += 10;
                Player.accTackleBox = true;
            }
            if (itemType == ItemID.FishingBobber || itemType == ItemID.FishingBobberGlowingStar || itemType == ItemID.FishingBobberGlowingLava || itemType == ItemID.FishingBobberGlowingKrypton || itemType == ItemID.FishingBobberGlowingXenon || itemType == ItemID.FishingBobberGlowingArgon || itemType == ItemID.FishingBobberGlowingViolet || itemType == ItemID.FishingBobberGlowingRainbow)
            {
                Player.fishingSkill += 10;
            }
            if (itemType == ItemID.TreasureMagnet)
            {
                Player.treasureMagnet = true;
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
            }
            if (itemType == ItemID.SpectreGoggles)
            {
                Player.CanSeeInvisibleBlocks = true;
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
            if (itemType == ModContent.ItemType<BattalionLog>())
            {
                battalionLog = true;
            }
            if (itemType == ModContent.ItemType<HarmInducer>())
            {
                harmInducer = true;
            }
            if (itemType == ModContent.ItemType<HeadCounter>())
            {
                headCounter = true;
            }
            if (itemType == ModContent.ItemType<Kettlebell>())
            {
                kettlebell = true;
            }
            if (itemType == ModContent.ItemType<LuckyDie>())
            {
                luckyDie = true;
            }
            if (itemType == ModContent.ItemType<MetallicClover>())
            {
                metallicClover = true;
            }
            if (itemType == ModContent.ItemType<PlateCracker>())
            {
                plateCracker = true;
            }
            if (itemType == ModContent.ItemType<Regenerator>())
            {
                regenerator = true;
            }
            if (itemType == ModContent.ItemType<ReinforcedPanel>())
            {
                reinforcedPanel = true;
            }
            if (itemType == ModContent.ItemType<Replenisher>())
            {
                replenisher = true;
            }
            if (itemType == ModContent.ItemType<TrackingDevice>())
            {
                trackingDevice = true;
            }
            if (itemType == ModContent.ItemType<WingTimer>())
            {
                wingTimer = true;
            }
            if (itemType == ModContent.ItemType<Fitbit>())
            {
                kettlebell = true;
                reinforcedPanel = true;
                wingTimer = true;
            }
            if (itemType == ModContent.ItemType<HeartbeatSensor>())
            {
                battalionLog = true;
                headCounter = true;
                trackingDevice = true;
            }
            if (itemType == ModContent.ItemType<ToleranceDetector>())
            {
                harmInducer = true;
                luckyDie = true;
                plateCracker = true;
            }
            if (itemType == ModContent.ItemType<VitalDisplay>())
            {
                metallicClover = true;
                regenerator = true;
                replenisher = true;
            }
            if (itemType == ModContent.ItemType<IAH>() || itemType == ModContent.ItemType<MosaicMirror>())
            {
                battalionLog = true;
                harmInducer = true;
                headCounter = true;
                kettlebell = true;
                luckyDie = true;
                metallicClover = true;
                plateCracker = true;
                regenerator = true;
                reinforcedPanel = true;
                replenisher = true;
                trackingDevice = true;
                wingTimer = true;
            }
        }

        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
            if (QoLCompendium.itemConfig.StarterBag)
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

        public void Reset()
        {
            battalionLog = false;
            bloodIdol = false;
            eclipseIdol = false;
            enemyAggressor = false;
            enemyCalmer = false;
            enemyEraser = false;
            harmInducer = false;
            headCounter = false;
            kettlebell = false;
            luckyDie = false;
            metallicClover = false;
            plateCracker = false;
            regenerator = false;
            reinforcedPanel = false;
            replenisher = false;
            sillySlapper = false;
            trackingDevice = false;
            wingTimer = false;

            if (Main.netMode != NetmodeID.Server)
            {
                if (Main.player[Main.myPlayer].talkNPC == -1)
                {
                    if (ModLoader.TryGetMod("terraguardians", out Mod terraguardians))
                    {
                        if (!(bool)terraguardians.Call("IsPC", Main.LocalPlayer))
                        {
                            return;
                        }
                    }
                    BMNPCUI.visible = false;
                    ECNPCUI.visible = false;
                }
            }
        }
    }
}
