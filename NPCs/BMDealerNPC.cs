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
        #pragma warning disable CA2211
        public static int shopNum = 0;
        public static string ShopName;
        #pragma warning restore CA2211

        public override string Texture
        {
            get
            {
                return "QoLCompendium/NPCs/BMDealerNPC";
            }
        }

        public override void SetStaticDefaults()
        {
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

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            if (ModContent.GetInstance<QoLCConfig>().BMNPC)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override List<string> SetNPCNameList()
        {
            List<string> list = new()
            {
                "Bon",
                "Ned",
                "Jay",
                "Jack",
                "Nathan",
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
                2 => "Don't ask where I got this stuff",
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
                button = "Flasks, Stations & Foods";
                ShopName = "Flasks, Stations & Foods";
            }
            else if (shopNum == 2)
            {
                button = "Materials";
                ShopName = "Materials";
            }
            else if (shopNum == 3)
            {
                button = "Hardmode Materials";
                ShopName = "Hardmode Materials";
            }
            else if (shopNum == 4)
            {
                button = "Movement Accessories";
                ShopName = "Movement Accessories";
            }
            else if (shopNum == 5)
            {
                button = "Combat Accessories";
                ShopName = "Combat Accessories";
            }
            else if (shopNum == 6)
            {
                button = "Informative/Building Gear";
                ShopName = "Informative/Building Gear";
            }
            else if (shopNum == 7)
            {
                button = "Treasure Bags";
                ShopName = "Treasure Bags";
            }
            else if (shopNum == 8)
            {
                button = "Crates & Grab Bags";
                ShopName = "Crates & Grab Bags";
            }
            else if (shopNum == 9)
            {
                button = "Ores & Bars";
                ShopName = "Ores & Bars";
            }
            else if (shopNum == 10)
            {
                button = "Natural Blocks";
                ShopName = "Natural Blocks";
            }
            else if (shopNum == 11)
            {
                button = "Building Blocks";
                ShopName = "Building Blocks";
            }
            else if (shopNum == 12)
            {
                button = "Herbs & Plants";
                ShopName = "Herbs & Plants";
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
                    .Add(ItemID.AmmoReservationPotion)
                    .Add(ItemID.ArcheryPotion)
                    .Add(ItemID.BattlePotion)
                    .Add(ItemID.BiomeSightPotion, Condition.DownedEyeOfCthulhu)
                    .Add(ItemID.BuilderPotion)
                    .Add(ItemID.CalmingPotion)
                    .Add(ItemID.CratePotion)
                    .Add(ItemID.TrapsightPotion)
                    .Add(ItemID.EndurancePotion)
                    .Add(ItemID.FeatherfallPotion)
                    .Add(ItemID.FishingPotion)
                    .Add(ItemID.FlipperPotion)
                    .Add(ItemID.GillsPotion)
                    .Add(ItemID.GravitationPotion)
                    .Add(ItemID.LuckPotionGreater)
                    .Add(ItemID.HeartreachPotion)
                    .Add(ItemID.HunterPotion)
                    .Add(ItemID.InfernoPotion)
                    .Add(ItemID.InvisibilityPotion)
                    .Add(ItemID.IronskinPotion)
                    .Add(ItemID.LifeforcePotion, Condition.Hardmode)
                    .Add(ItemID.MagicPowerPotion)
                    .Add(ItemID.ManaRegenerationPotion)
                    .Add(ItemID.MiningPotion)
                    .Add(ItemID.NightOwlPotion)
                    .Add(ItemID.ObsidianSkinPotion)
                    .Add(ItemID.RagePotion)
                    .Add(ItemID.RegenerationPotion)
                    .Add(ItemID.ShinePotion)
                    .Add(ItemID.SonarPotion)
                    .Add(ItemID.SpelunkerPotion)
                    .Add(ItemID.SummoningPotion)
                    .Add(ItemID.SwiftnessPotion)
                    .Add(ItemID.ThornsPotion)
                    .Add(ItemID.TitanPotion)
                    .Add(ItemID.WarmthPotion)
                    .Add(ItemID.WaterWalkingPotion)
                    .Add(ItemID.WrathPotion);
            potShop.Register();

            var flaskShop = new NPCShop(Type, "Flasks, Stations & Foods")
                    .Add(ItemID.FruitJuice)
                    .Add(ItemID.LobsterTail)
                    .Add(ItemID.GoldenDelight)
                    .Add(ItemID.FlaskofCursedFlames, Condition.Hardmode, Condition.DownedQueenBee)
                    .Add(ItemID.FlaskofFire, Condition.DownedQueenBee)
                    .Add(ItemID.FlaskofGold, Condition.Hardmode, Condition.DownedQueenBee)
                    .Add(ItemID.FlaskofIchor, Condition.Hardmode, Condition.DownedQueenBee)
                    .Add(ItemID.FlaskofNanites, Condition.DownedPlantera, Condition.DownedQueenBee)
                    .Add(ItemID.FlaskofParty, Condition.DownedQueenBee)
                    .Add(ItemID.FlaskofPoison, Condition.DownedQueenBee)
                    .Add(ItemID.FlaskofVenom, Condition.DownedPlantera, Condition.DownedQueenBee)
                    .Add(ItemID.GenderChangePotion)
                    .Add(ItemID.PotionOfReturn, Condition.DownedEowOrBoc)
                    .Add(ItemID.RecallPotion)
                    .Add(ItemID.TeleportationPotion, Condition.Hardmode)
                    .Add(ItemID.WormholePotion)
                    .Add(ItemID.RedPotion, Condition.ForTheWorthyWorld)
                    .Add(ItemID.Sunflower)
                    .Add(ItemID.Campfire)
                    .Add(ItemID.CrystalBall, Condition.Hardmode)
                    .Add(ItemID.AmmoBox)
                    .Add(ItemID.SharpeningStation)
                    .Add(ItemID.BewitchingTable, Condition.DownedSkeletron)
                    .Add(ItemID.WarTable, Condition.DownedOldOnesArmyAny)
                    .Add(ItemID.CatBast)
                    .Add(ItemID.SliceOfCake)
                    .Add(ItemID.StarinaBottle)
                    .Add(ItemID.HeartLantern)
                    .Add(ItemID.GardenGnome)
                    .Add(ItemID.PeaceCandle)
                    .Add(ItemID.WaterCandle, Condition.DownedSkeletron)
                    .Add(ItemID.ShadowCandle)
                    .Add(ItemID.WaterBucket)
                    .Add(ItemID.LavaBucket)
                    .Add(ItemID.HoneyBucket)
                    .Add(ItemID.LifeCrystal)
                    .Add(ItemID.LifeFruit, Condition.DownedMechBossAny)
                    .Add(ItemID.ManaCrystal);
            flaskShop.Register();

            var matShop = new NPCShop(Type, "Materials")
                    .Add(ItemID.AntlionMandible)
                    .Add(ItemID.BeeWax, Condition.DownedQueenBee)
                    .Add(ItemID.BlackInk)
                    .Add(ItemID.BlackLens)
                    .Add(ItemID.BlackPearl)
                    .Add(ItemID.Bone, Condition.DownedSkeletron)
                    .Add(ItemID.CyanHusk)
                    .Add(ItemID.Feather)
                    .Add(ItemID.FlinxFur)
                    .Add(ItemID.Gel)
                    .Add(ItemID.Hook)
                    .Add(ItemID.JungleSpores)
                    .Add(ItemID.Leather)
                    .Add(ItemID.Lens)
                    .Add(ItemID.PinkGel)
                    .Add(ItemID.PinkPearl)
                    .Add(ItemID.PurpleMucos)
                    .Add(ItemID.RedHusk)
                    .Add(ItemID.RottenChunk)
                    .Add(ItemID.ShadowScale, Condition.DownedEowOrBoc)
                    .Add(ItemID.SharkFin)
                    .Add(ItemID.Silk)
                    .Add(ItemID.Stinger)
                    .Add(ItemID.TatteredCloth)
                    .Add(ItemID.TissueSample, Condition.DownedEowOrBoc)
                    .Add(ItemID.Vertebrae)
                    .Add(ItemID.Vine)
                    .Add(ItemID.VioletHusk)
                    .Add(ItemID.WhitePearl)
                    .Add(ItemID.WhoopieCushion)
                    .Add(ItemID.WormTooth);
            matShop.Register();

            var hmMatShop = new NPCShop(Type, "Hardmode Materials")
                    .Add(ItemID.AncientCloth, Condition.Hardmode)
                    .Add(ItemID.BeetleHusk, Condition.DownedGolem)
                    .Add(ItemID.BrokenHeroSword, Condition.DownedPlantera)
                    .Add(ItemID.CrystalShard, Condition.Hardmode)
                    .Add(ItemID.CursedFlame, Condition.Hardmode)
                    .Add(ItemID.DarkShard, Condition.Hardmode)
                    .Add(ItemID.Ectoplasm, Condition.DownedPlantera)
                    .Add(ItemID.AncientBattleArmorMaterial, Condition.Hardmode)
                    .Add(ItemID.FrostCore, Condition.Hardmode)
                    .Add(ItemID.Ichor, Condition.Hardmode)
                    .Add(ItemID.LightShard, Condition.Hardmode)
                    .Add(ItemID.PixieDust, Condition.Hardmode)
                    .Add(ItemID.LunarTabletFragment, Condition.DownedPlantera)
                    .Add(ItemID.SpiderFang, Condition.Hardmode)
                    .Add(ItemID.TurtleShell, Condition.Hardmode)
                    .Add(ItemID.UnicornHorn, Condition.Hardmode)
                    .Add(ItemID.SoulofFlight, Condition.Hardmode)
                    .Add(ItemID.SoulofLight, Condition.Hardmode)
                    .Add(ItemID.SoulofNight, Condition.Hardmode)
                    .Add(ItemID.SoulofMight, Condition.DownedDestroyer)
                    .Add(ItemID.SoulofSight, Condition.DownedTwins)
                    .Add(ItemID.SoulofFright, Condition.DownedSkeletronPrime)
                    .Add(ItemID.FragmentNebula, Condition.DownedCultist)
                    .Add(ItemID.FragmentSolar, Condition.DownedCultist)
                    .Add(ItemID.FragmentStardust, Condition.DownedCultist)
                    .Add(ItemID.FragmentVortex, Condition.DownedCultist);
            hmMatShop.Register();

            var moveAccsShop = new NPCShop(Type, "Movement Accessories")
                   .Add(ItemID.Aglet)
                   .Add(ItemID.AnkletoftheWind)
                   .Add(ItemID.BalloonPufferfish)
                   .Add(ItemID.BlizzardinaBottle)
                   .Add(ItemID.ClimbingClaws)
                   .Add(ItemID.CloudinaBottle)
                   .Add(ItemID.Flipper)
                   .Add(ItemID.CreativeWings)
                   .Add(ItemID.FlyingCarpet)
                   .Add(ItemID.FrogLeg)
                   .Add(ItemID.HermesBoots)
                   .Add(ItemID.IceSkates)
                   .Add(ItemID.LavaCharm)
                   .Add(ItemID.LuckyHorseshoe)
                   .Add(ItemID.MoonCharm, Condition.Hardmode)
                   .Add(ItemID.NeptunesShell, Condition.DownedMechBossAny)
                   .Add(ItemID.SandstorminaBottle)
                   .Add(ItemID.ShinyRedBalloon)
                   .Add(ItemID.ShoeSpikes)
                   .Add(ItemID.Tabi, Condition.DownedPlantera)
                   .Add(ItemID.TsunamiInABottle)
                   .Add(ItemID.WaterWalkingBoots);
            moveAccsShop.Register();

            var combatAccsShop = new NPCShop(Type, "Combat Accessories")
                    .Add(ItemID.AnkhCharm, Condition.Hardmode)
                    .Add(ItemID.ApprenticeScarf, Condition.Hardmode)
                    .Add(ItemID.BandofRegeneration)
                    .Add(ItemID.BandofStarpower)
                    .Add(ItemID.BlackBelt, Condition.DownedPlantera)
                    .Add(ItemID.CelestialMagnet)
                    .Add(ItemID.CobaltShield, Condition.DownedSkeletron)
                    .Add(ItemID.CrossNecklace, Condition.Hardmode)
                    .Add(ItemID.EyeoftheGolem, Condition.DownedGolem)
                    .Add(ItemID.FeralClaws)
                    .Add(ItemID.FleshKnuckles, Condition.Hardmode)
                    .Add(ItemID.FrozenTurtleShell, Condition.Hardmode)
                    .Add(ItemID.HandWarmer)
                    .Add(ItemID.HerculesBeetle, Condition.DownedPlantera)
                    .Add(ItemID.HoneyComb, Condition.DownedQueenBee)
                    .Add(ItemID.MagicQuiver, Condition.Hardmode)
                    .Add(ItemID.MagmaStone)
                    .Add(ItemID.MoonStone, Condition.DownedMechBossAny)
                    .Add(ItemID.NaturesGift)
                    .Add(ItemID.NecromanticScroll, Condition.DownedPlantera)
                    .Add(ItemID.ObsidianRose)
                    .Add(ItemID.ObsidianSkull)
                    .Add(ItemID.PaladinsShield, Condition.DownedPlantera)
                    .Add(ItemID.PanicNecklace)
                    .Add(ItemID.PhilosophersStone, Condition.Hardmode)
                    .Add(ItemID.PutridScent, Condition.Hardmode)
                    .Add(ItemID.RangerEmblem, Condition.Hardmode)
                    .Add(ItemID.RifleScope, Condition.DownedPlantera)
                    .Add(ItemID.Shackle)
                    .Add(ItemID.SharkToothNecklace, CheckDowned.bloodMoon)
                    .Add(ItemID.SorcererEmblem, Condition.Hardmode)
                    .Add(ItemID.StarCloak, Condition.Hardmode)
                    .Add(ItemID.SummonerEmblem, Condition.Hardmode)
                    .Add(ItemID.SunStone, Condition.DownedGolem)
                    .Add(ItemID.TitanGlove, Condition.Hardmode)
                    .Add(ItemID.WarriorEmblem, Condition.Hardmode)
                    .Add(ItemID.YoYoGlove, Condition.Hardmode);
            combatAccsShop.Register();

            var infoShop = new NPCShop(Type, "Informative/Building Gear")
                    .Add(ItemID.Toolbelt)
                    .Add(ItemID.Toolbox)
                    .Add(ItemID.ArchitectGizmoPack, Condition.NotDownedSkeletron)
                    .Add(ItemID.AncientChisel, Condition.NotDownedSkeletron)
                    .Add(ItemID.HandOfCreation, Condition.DownedSkeletron)
                    .Add(ItemID.ActuationAccessory, Condition.DownedSkeletron)
                    .Add(ItemID.Paintbrush, Condition.NotDownedPlantera)
                    .Add(ItemID.PaintRoller, Condition.NotDownedPlantera)
                    .Add(ItemID.PaintScraper, Condition.NotDownedPlantera)
                    .Add(ItemID.SpectrePaintbrush, Condition.DownedPlantera)
                    .Add(ItemID.SpectrePaintRoller, Condition.DownedPlantera)
                    .Add(ItemID.SpectrePaintScraper, Condition.DownedPlantera)
                    .Add(ItemID.UltrabrightHelmet)
                    .Add(ItemID.MiningShirt)
                    .Add(ItemID.MiningPants)
                    .Add(ItemID.AnglerTackleBag, Condition.NotDownedEowOrBoc, Condition.AnglerQuestsFinishedOver(1))
                    .Add(ItemID.LavaproofTackleBag, Condition.DownedEowOrBoc, Condition.AnglerQuestsFinishedOver(1))
                    .Add(ItemID.FishingBobber, Condition.AnglerQuestsFinishedOver(1))
                    .Add(ItemID.AnglerHat, Condition.AnglerQuestsFinishedOver(1))
                    .Add(ItemID.AnglerVest, Condition.AnglerQuestsFinishedOver(1))
                    .Add(ItemID.AnglerPants, Condition.AnglerQuestsFinishedOver(1))
                    .Add(ItemID.GoldenFishingRod, Condition.AnglerQuestsFinishedOver(1))
                    .Add(ItemID.GoldenBugNet, Condition.AnglerQuestsFinishedOver(1))
                    .Add(ItemID.MasterBait, Condition.AnglerQuestsFinishedOver(1))
                    .Add(ItemID.PlatinumWatch)
                    .Add(ItemID.DepthMeter)
                    .Add(ItemID.Compass)
                    .Add(ItemID.Radar)
                    .Add(ItemID.TallyCounter, Condition.DownedSkeletron)
                    .Add(ItemID.MetalDetector)
                    .Add(ItemID.Stopwatch)
                    .Add(ItemID.DPSMeter)
                    .Add(ItemID.FishermansGuide)
                    .Add(ItemID.WeatherRadio)
                    .Add(ItemID.Sextant)
                    .Add(ItemID.MagicMirror)
                    .Add(ItemID.MagicConch)
                    .Add(ItemID.DemonConch, Condition.DownedEowOrBoc)
                    .Add(ItemID.Shellphone, Condition.Hardmode)
                    .Add(ItemID.ArcticDivingGear)
                    .Add(ItemID.DiscountCard, Condition.DownedPirates)
                    .Add(ItemID.LuckyCoin, Condition.DownedPirates)
                    .Add(ItemID.GoldRing, Condition.DownedPirates)
                    .Add(ItemID.WireKite, Condition.DownedSkeletron)
                    .Add(ItemID.MoneyTrough)
                    .Add(ItemID.CordageGuide)
                    .Add(ItemID.DontHurtComboBook)
                    .Add(ItemID.RoyalGel, Condition.DownedKingSlime)
                    .Add(ItemID.TorchGodsFavor)
                    .Add(ItemID.RodofDiscord, Condition.Hardmode);
            if (CheckDowned.calamityLoaded)
            {
                infoShop.Add(ItemID.RodOfHarmony, CheckDowned.scalamitas, CheckDowned.exomechs);
            }
            else
            {
                infoShop.Add(ItemID.RodOfHarmony, Condition.DownedMoonLord);
            }
            infoShop.Register();

            var bossShop = new NPCShop(Type, "Treasure Bags")
                    .Add(new Item(ItemID.KingSlimeBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedKingSlime, CheckDowned.expertOrMaster)
                    .Add(new Item(ItemID.EyeOfCthulhuBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedEyeOfCthulhu, CheckDowned.expertOrMaster)
                    .Add(new Item(ItemID.EaterOfWorldsBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedEowOrBoc, CheckDowned.expertOrMaster)
                    .Add(new Item(ItemID.BrainOfCthulhuBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedEowOrBoc, CheckDowned.expertOrMaster)
                    .Add(new Item(ItemID.QueenBeeBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedQueenBee, CheckDowned.expertOrMaster)
                    .Add(new Item(ItemID.SkeletronBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedSkeletron, CheckDowned.expertOrMaster)
                    .Add(new Item(ItemID.DeerclopsBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedDeerclops, CheckDowned.expertOrMaster)
                    .Add(new Item(ItemID.WallOfFleshBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.Hardmode, CheckDowned.expertOrMaster)
                    .Add(new Item(ItemID.QueenSlimeBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedQueenSlime, CheckDowned.expertOrMaster)
                    .Add(new Item(ItemID.DestroyerBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedDestroyer, CheckDowned.expertOrMaster)
                    .Add(new Item(ItemID.TwinsBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedTwins, CheckDowned.expertOrMaster)
                    .Add(new Item(ItemID.SkeletronPrimeBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedSkeletronPrime, CheckDowned.expertOrMaster)
                    .Add(new Item(ItemID.PlanteraBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedPlantera, CheckDowned.expertOrMaster)
                    .Add(new Item(ItemID.GolemBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedGolem, CheckDowned.expertOrMaster)
                    .Add(new Item(ItemID.BossBagBetsy) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedOldOnesArmyT3, CheckDowned.expertOrMaster)
                    .Add(new Item(ItemID.FishronBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedDukeFishron, CheckDowned.expertOrMaster)
                    .Add(new Item(ItemID.FairyQueenBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedEmpressOfLight, CheckDowned.expertOrMaster)
                    .Add(new Item(ItemID.MoonLordBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedMoonLord, CheckDowned.expertOrMaster)
                    .Add(ItemID.DefenderMedal, Condition.DownedOldOnesArmyAny);
            bossShop.Register();

            var crateShop = new NPCShop(Type, "Crates & Grab Bags")
                    .Add(ItemID.WoodenCrate)
                    .Add(ItemID.IronCrate)
                    .Add(ItemID.GoldenCrate)
                    .Add(ItemID.JungleFishingCrate)
                    .Add(ItemID.FloatingIslandFishingCrate)
                    .Add(ItemID.CorruptFishingCrate)
                    .Add(ItemID.CrimsonFishingCrate)
                    .Add(ItemID.HallowedFishingCrate)
                    .Add(ItemID.DungeonFishingCrate, Condition.DownedSkeletron)
                    .Add(ItemID.FrozenCrate)
                    .Add(ItemID.OasisCrate)
                    .Add(ItemID.LavaCrate)
                    .Add(ItemID.OceanCrate)
                    .Add(ItemID.WoodenCrateHard, Condition.Hardmode)
                    .Add(ItemID.IronCrateHard, Condition.Hardmode)
                    .Add(ItemID.GoldenCrateHard, Condition.Hardmode)
                    .Add(ItemID.JungleFishingCrateHard, Condition.Hardmode)
                    .Add(ItemID.FloatingIslandFishingCrateHard, Condition.Hardmode)
                    .Add(ItemID.CorruptFishingCrateHard, Condition.Hardmode)
                    .Add(ItemID.CrimsonFishingCrateHard, Condition.Hardmode)
                    .Add(ItemID.HallowedFishingCrateHard, Condition.Hardmode)
                    .Add(ItemID.DungeonFishingCrateHard, Condition.Hardmode, Condition.DownedSkeletron)
                    .Add(ItemID.FrozenCrateHard, Condition.Hardmode)
                    .Add(ItemID.OasisCrateHard, Condition.Hardmode)
                    .Add(ItemID.LavaCrateHard, Condition.Hardmode)
                    .Add(ItemID.OceanCrateHard, Condition.Hardmode)
                    .Add(ItemID.GoodieBag)
                    .Add(ItemID.Present);
            crateShop.Register();

            var oreShop = new NPCShop(Type, "Ores & Bars")
                    .Add(ItemID.CopperOre)
                    .Add(ItemID.TinOre)
                    .Add(ItemID.IronOre)
                    .Add(ItemID.LeadOre)
                    .Add(ItemID.SilverOre)
                    .Add(ItemID.TungstenOre)
                    .Add(ItemID.GoldOre)
                    .Add(ItemID.PlatinumOre)
                    .Add(ItemID.Meteorite, Condition.DownedEowOrBoc)
                    .Add(ItemID.DemoniteOre, Condition.DownedEowOrBoc)
                    .Add(ItemID.CrimtaneOre, Condition.DownedEowOrBoc)
                    .Add(ItemID.Hellstone, Condition.DownedEowOrBoc)
                    .Add(ItemID.CobaltOre, Condition.Hardmode)
                    .Add(ItemID.PalladiumOre, Condition.Hardmode)
                    .Add(ItemID.MythrilOre, Condition.Hardmode)
                    .Add(ItemID.OrichalcumOre, Condition.Hardmode)
                    .Add(ItemID.AdamantiteOre, Condition.Hardmode)
                    .Add(ItemID.TitaniumOre, Condition.Hardmode)
                    .Add(ItemID.ChlorophyteOre, Condition.DownedMechBossAll)
                    .Add(ItemID.LunarOre, Condition.DownedMoonLord)
                    .Add(ItemID.CopperBar)
                    .Add(ItemID.TinBar)
                    .Add(ItemID.IronBar)
                    .Add(ItemID.LeadBar)
                    .Add(ItemID.SilverBar)
                    .Add(ItemID.TungstenBar)
                    .Add(ItemID.GoldBar)
                    .Add(ItemID.PlatinumBar)
                    .Add(ItemID.MeteoriteBar, Condition.DownedEowOrBoc)
                    .Add(ItemID.DemoniteBar, Condition.DownedEowOrBoc)
                    .Add(ItemID.CrimtaneBar, Condition.DownedEowOrBoc)
                    .Add(ItemID.HellstoneBar, Condition.DownedEowOrBoc)
                    .Add(ItemID.CobaltBar, Condition.Hardmode)
                    .Add(ItemID.PalladiumBar, Condition.Hardmode)
                    .Add(ItemID.MythrilBar, Condition.Hardmode)
                    .Add(ItemID.OrichalcumBar, Condition.Hardmode)
                    .Add(ItemID.AdamantiteBar, Condition.Hardmode)
                    .Add(ItemID.TitaniumBar, Condition.Hardmode)
                    .Add(ItemID.HallowedBar, Condition.DownedMechBossAny)
                    .Add(ItemID.ChlorophyteBar, Condition.DownedMechBossAll)
                    .Add(ItemID.LunarBar, Condition.DownedMoonLord)
                    .Add(ItemID.Amber)
                    .Add(ItemID.Amethyst)
                    .Add(ItemID.Diamond)
                    .Add(ItemID.Emerald)
                    .Add(ItemID.Ruby)
                    .Add(ItemID.Sapphire)
                    .Add(ItemID.Topaz);
            oreShop.Register();

            var naturalBlockShop = new NPCShop(Type, "Natural Blocks")
                    .Add(ItemID.Wood)
                    .Add(ItemID.BorealWood)
                    .Add(ItemID.PalmWood)
                    .Add(ItemID.RichMahogany)
                    .Add(ItemID.Ebonwood)
                    .Add(ItemID.Shadewood)
                    .Add(ItemID.AshWood)
                    .Add(ItemID.Pearlwood, Condition.Hardmode)
                    .Add(ItemID.SpookyWood, Condition.DownedPlantera)
                    .Add(ItemID.DynastyWood)
                    .Add(ItemID.BambooBlock)
                    .Add(ItemID.LargeBambooBlock)
                    .Add(ItemID.Cactus)
                    .Add(ItemID.Pumpkin)
                    .Add(ItemID.PineTreeBlock)
                    .Add(ItemID.DirtBlock)
                    .Add(ItemID.ClayBlock)
                    .Add(ItemID.MudBlock)
                    .Add(ItemID.AshBlock)
                    .Add(ItemID.SiltBlock)
                    .Add(ItemID.SlushBlock)
                    .Add(ItemID.SnowBlock)
                    .Add(ItemID.SandBlock)
                    .Add(ItemID.EbonsandBlock)
                    .Add(ItemID.CrimsandBlock)
                    .Add(ItemID.PearlsandBlock, Condition.Hardmode)
                    .Add(ItemID.StoneBlock)
                    .Add(ItemID.EbonstoneBlock)
                    .Add(ItemID.CrimstoneBlock)
                    .Add(ItemID.PearlstoneBlock, Condition.Hardmode)
                    .Add(ItemID.IceBlock)
                    .Add(ItemID.PurpleIceBlock)
                    .Add(ItemID.RedIceBlock)
                    .Add(ItemID.PinkIceBlock, Condition.Hardmode)
                    .Add(ItemID.Granite)
                    .Add(ItemID.Marble)
                    .Add(ItemID.Obsidian)
                    .Add(ItemID.ShimmerBlock)
                    .Add(ItemID.HardenedSand)
                    .Add(ItemID.CorruptHardenedSand)
                    .Add(ItemID.CrimsonHardenedSand)
                    .Add(ItemID.HallowHardenedSand, Condition.Hardmode)
                    .Add(ItemID.Sandstone)
                    .Add(ItemID.CorruptSandstone)
                    .Add(ItemID.CrimsonSandstone)
                    .Add(ItemID.HallowSandstone, Condition.Hardmode)
                    .Add(ItemID.DesertFossil)
                    .Add(ItemID.ShellPileBlock)
                    .Add(ItemID.Cloud)
                    .Add(ItemID.RainCloud)
                    .Add(ItemID.Hive)
                    .Add(ItemID.HoneyBlock)
                    .Add(ItemID.CrispyHoneyBlock)
                    .Add(ItemID.Hay)
                    .Add(ItemID.Cobweb);
            naturalBlockShop.Register();

            var buildingBlockShop = new NPCShop(Type, "Building Blocks")
                    .Add(ItemID.GrayBrick)
                    .Add(ItemID.StoneSlab)
                    .Add(ItemID.RedBrick)
                    .Add(ItemID.SandstoneBrick)
                    .Add(ItemID.SnowBrick)
                    .Add(ItemID.IceBrick)
                    .Add(ItemID.MudstoneBlock)
                    .Add(ItemID.IridescentBrick)
                    .Add(ItemID.ObsidianBrick)
                    .Add(ItemID.EbonstoneBrick)
                    .Add(ItemID.CrimstoneBrick)
                    .Add(ItemID.PearlstoneBrick, Condition.Hardmode)
                    .Add(ItemID.RainbowBrick, Condition.Hardmode)
                    .Add(ItemID.CopperBrick)
                    .Add(ItemID.TinBrick)
                    .Add(ItemID.IronBrick)
                    .Add(ItemID.LeadBrick)
                    .Add(ItemID.SilverBrick)
                    .Add(ItemID.TungstenBrick)
                    .Add(ItemID.GoldBrick)
                    .Add(ItemID.PlatinumBrick)
                    .Add(ItemID.DemoniteBrick, Condition.DownedEyeOfCthulhu)
                    .Add(ItemID.CrimtaneBrick, Condition.DownedEyeOfCthulhu)
                    .Add(ItemID.MeteoriteBrick, Condition.DownedEowOrBoc)
                    .Add(ItemID.HellstoneBrick, Condition.DownedEowOrBoc)
                    .Add(ItemID.CobaltBrick, Condition.Hardmode)
                    .Add(ItemID.PalladiumColumn, Condition.Hardmode)
                    .Add(ItemID.MythrilBrick, Condition.Hardmode)
                    .Add(ItemID.BubblegumBlock, Condition.Hardmode)
                    .Add(ItemID.AdamantiteBeam, Condition.Hardmode)
                    .Add(ItemID.TitanstoneBlock, Condition.Hardmode)
                    .Add(ItemID.ChlorophyteBrick, Condition.DownedMechBossAll)
                    .Add(ItemID.ShroomitePlating, Condition.DownedPlantera)
                    .Add(ItemID.LunarBrick, Condition.DownedMoonLord)
                    .Add(ItemID.ShimmerBrick)
                    .Add(ItemID.LavaMossBlock)
                    .Add(ItemID.KryptonMossBlock)
                    .Add(ItemID.XenonMossBlock)
                    .Add(ItemID.ArgonMossBlock)
                    .Add(ItemID.VioletMossBlock)
                    .Add(ItemID.RainbowMossBlock)
                    .Add(ItemID.BlueBrick, Condition.DownedSkeletron)
                    .Add(ItemID.GreenBrick, Condition.DownedSkeletron)
                    .Add(ItemID.PinkBrick, Condition.DownedSkeletron)
                    .Add(ItemID.LihzahrdBrick, Condition.DownedGolem)
                    .Add(ItemID.SolarBrick, Condition.DownedCultist)
                    .Add(ItemID.NebulaBrick, Condition.DownedCultist)
                    .Add(ItemID.StardustBrick, Condition.DownedCultist)
                    .Add(ItemID.VortexBrick, Condition.DownedCultist)
                    .Add(ItemID.GrayStucco)
                    .Add(ItemID.GreenStucco)
                    .Add(ItemID.RedStucco)
                    .Add(ItemID.YellowStucco)
                    .Add(ItemID.GraniteBlock)
                    .Add(ItemID.MarbleBlock)
                    .Add(ItemID.SunplateBlock)
                    .Add(ItemID.MartianConduitPlating, Condition.DownedMartians)
                    .Add(ItemID.AmberGemsparkBlock)
                    .Add(ItemID.AmethystGemsparkBlock)
                    .Add(ItemID.DiamondGemsparkBlock)
                    .Add(ItemID.EmeraldGemsparkBlock)
                    .Add(ItemID.RubyGemsparkBlock)
                    .Add(ItemID.SapphireGemsparkBlock)
                    .Add(ItemID.TopazGemsparkBlock)
                    .Add(ItemID.TeamBlockRed)
                    .Add(ItemID.TeamBlockGreen)
                    .Add(ItemID.TeamBlockBlue)
                    .Add(ItemID.TeamBlockYellow)
                    .Add(ItemID.TeamBlockPink)
                    .Add(ItemID.TeamBlockWhite)
                    .Add(ItemID.LunarBlockSolar)
                    .Add(ItemID.LunarBlockNebula)
                    .Add(ItemID.LunarBlockStardust)
                    .Add(ItemID.LunarBlockVortex)
                    .Add(ItemID.RedDynastyShingles)
                    .Add(ItemID.BlueDynastyShingles)
                    .Add(ItemID.CandyCaneBlock)
                    .Add(ItemID.GreenCandyCaneBlock)
                    .Add(ItemID.AsphaltBlock, Condition.DownedMechBossAny)
                    .Add(ItemID.CoralstoneBlock)
                    .Add(ItemID.FleshBlock, Condition.Hardmode)
                    .Add(ItemID.LesionBlock, Condition.Hardmode)
                    .Add(ItemID.SpiderBlock, Condition.Hardmode)
                    .Add(ItemID.SlimeBlock, Condition.DownedKingSlime)
                    .Add(ItemID.PinkSlimeBlock, Condition.DownedKingSlime);
            buildingBlockShop.Register();

            var plantShop = new NPCShop(Type, "Herbs & Plants")
                    .Add(ItemID.HerbBag)
                    .Add(ItemID.Blinkroot)
                    .Add(ItemID.BlinkrootSeeds)
                    .Add(ItemID.Daybloom)
                    .Add(ItemID.DaybloomSeeds)
                    .Add(ItemID.Deathweed)
                    .Add(ItemID.DeathweedSeeds)
                    .Add(ItemID.Fireblossom)
                    .Add(ItemID.FireblossomSeeds)
                    .Add(ItemID.Moonglow)
                    .Add(ItemID.MoonglowSeeds)
                    .Add(ItemID.Shiverthorn)
                    .Add(ItemID.ShiverthornSeeds)
                    .Add(ItemID.Waterleaf)
                    .Add(ItemID.WaterleafSeeds)
                    .Add(ItemID.PumpkinSeed, Condition.DownedEyeOfCthulhu)
                    .Add(ItemID.TealMushroom)
                    .Add(ItemID.GreenMushroom)
                    .Add(ItemID.SkyBlueFlower)
                    .Add(ItemID.YellowMarigold)
                    .Add(ItemID.BlueBerries)
                    .Add(ItemID.LimeKelp)
                    .Add(ItemID.PinkPricklyPear)
                    .Add(ItemID.OrangeBloodroot)
                    .Add(ItemID.VileMushroom)
                    .Add(ItemID.ViciousMushroom)
                    .Add(ItemID.Mushroom)
                    .Add(ItemID.GlowingMushroom)
                    .Add(ItemID.GrassSeeds)
                    .Add(ItemID.JungleGrassSeeds)
                    .Add(ItemID.MushroomGrassSeeds)
                    .Add(ItemID.CorruptSeeds)
                    .Add(ItemID.CrimsonSeeds)
                    .Add(ItemID.AshGrassSeeds)
                    .Add(ItemID.HallowedSeeds, Condition.Hardmode)
                    .Add(ItemID.Acorn)
                    .Add(ItemID.Fertilizer);
            plantShop.Register();
        }
    }
}
