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
            NPC.Happiness.SetBiomeAffection<SnowBiome>((AffectionLevel)100)
                .SetBiomeAffection<OceanBiome>((AffectionLevel)50)
                .SetBiomeAffection<DesertBiome>((AffectionLevel)(-50))
                .SetNPCAffection(NPCID.DD2Bartender, (AffectionLevel)100)
                .SetNPCAffection(NPCID.ArmsDealer, (AffectionLevel)50)
                .SetNPCAffection(NPCID.PartyGirl, (AffectionLevel)(-50))
                .SetNPCAffection(NPCID.TaxCollector, (AffectionLevel)(-100));
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
            if (QoLCompendium.mainConfig.BMNPC)
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
                button = "Treasure Bags";
                ShopName = "Treasure Bags";
            }
            else if (shopNum == 7)
            {
                button = "Crates & Grab Bags";
                ShopName = "Crates & Grab Bags";
            }
            else if (shopNum == 8)
            {
                button = "Ores & Bars";
                ShopName = "Ores & Bars";
            }
            else if (shopNum == 9)
            {
                button = "Natural Blocks";
                ShopName = "Natural Blocks";
            }
            else if (shopNum == 10)
            {
                button = "Building Blocks";
                ShopName = "Building Blocks";
            }
            else if (shopNum == 11)
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
                    .Add(ItemID.AmmoReservationPotion, ModConditions.HasBeenToJungle)
                    .Add(ItemID.ArcheryPotion, ModConditions.HasBeenToPurity)
                    .Add(ItemID.BattlePotion, ModConditions.HasBeenToEvil)
                    .Add(ItemID.BiomeSightPotion, Condition.DownedEyeOfCthulhu, ModConditions.HasBeenToUnderworld)
                    .Add(ItemID.BuilderPotion, ModConditions.HasBeenToSnow)
                    .Add(ItemID.CalmingPotion, ModConditions.HasBeenToSky)
                    .Add(ItemID.CratePotion, ModConditions.HasBeenToDesert)
                    .Add(ItemID.TrapsightPotion, ModConditions.HasBeenToSnow)
                    .Add(ItemID.EndurancePotion, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.FeatherfallPotion, ModConditions.HasBeenToSky)
                    .Add(ItemID.FishingPotion, ModConditions.HasBeenToJungle)
                    .Add(ItemID.FlipperPotion, ModConditions.HasBeenToSnow)
                    .Add(ItemID.GillsPotion, ModConditions.HasBeenToOcean)
                    .Add(ItemID.GravitationPotion, ModConditions.HasBeenToSky)
                    .Add(ItemID.LuckPotionGreater, ModConditions.HasBeenToDesert)
                    .Add(ItemID.HeartreachPotion, ModConditions.HasBeenToEvil)
                    .Add(ItemID.HunterPotion, ModConditions.HasBeenToOcean)
                    .Add(ItemID.InfernoPotion, ModConditions.HasBeenToUnderworld)
                    .Add(ItemID.InvisibilityPotion, ModConditions.HasBeenToJungle)
                    .Add(ItemID.IronskinPotion, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.LifeforcePotion, Condition.Hardmode, ModConditions.HasBeenToHallow)
                    .Add(ItemID.MagicPowerPotion, ModConditions.HasBeenToJungle)
                    .Add(ItemID.ManaRegenerationPotion, ModConditions.HasBeenToJungle)
                    .Add(ItemID.MiningPotion, ModConditions.HasBeenToDesert)
                    .Add(ItemID.NightOwlPotion, ModConditions.HasBeenToPurity)
                    .Add(ItemID.ObsidianSkinPotion, ModConditions.HasBeenToUnderworld)
                    .Add(ItemID.RagePotion, ModConditions.HasBeenToEvil)
                    .Add(ItemID.RegenerationPotion, ModConditions.HasBeenToPurity)
                    .Add(ItemID.ShinePotion, ModConditions.HasBeenToMushroom)
                    .Add(ItemID.SonarPotion, ModConditions.HasBeenToOcean)
                    .Add(ItemID.SpelunkerPotion, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.SummoningPotion, ModConditions.HasBeenToJungle)
                    .Add(ItemID.SwiftnessPotion, ModConditions.HasBeenToDesert)
                    .Add(ItemID.ThornsPotion, ModConditions.HasBeenToDesert)
                    .Add(ItemID.TitanPotion, ModConditions.HasBeenToDungeon)
                    .Add(ItemID.WarmthPotion, ModConditions.HasBeenToSnow)
                    .Add(ItemID.WaterWalkingPotion, ModConditions.HasBeenToOcean)
                    .Add(ItemID.WrathPotion, ModConditions.HasBeenToEvil);
            potShop.Register();

            var flaskShop = new NPCShop(Type, "Flasks, Stations & Foods")
                    .Add(ItemID.FruitJuice)
                    .Add(ItemID.LobsterTail)
                    .Add(ItemID.GoldenDelight)
                    .Add(ItemID.FlaskofCursedFlames, Condition.Hardmode, Condition.DownedQueenBee, ModConditions.HasBeenToEvil)
                    .Add(ItemID.FlaskofFire, Condition.DownedQueenBee, ModConditions.HasBeenToUnderworld)
                    .Add(ItemID.FlaskofGold, Condition.Hardmode, Condition.DownedQueenBee)
                    .Add(ItemID.FlaskofIchor, Condition.Hardmode, Condition.DownedQueenBee, ModConditions.HasBeenToEvil)
                    .Add(ItemID.FlaskofNanites, Condition.DownedPlantera, Condition.DownedQueenBee)
                    .Add(ItemID.FlaskofParty, Condition.DownedQueenBee)
                    .Add(ItemID.FlaskofPoison, Condition.DownedQueenBee, ModConditions.HasBeenToJungle)
                    .Add(ItemID.FlaskofVenom, Condition.DownedPlantera, Condition.DownedQueenBee, ModConditions.HasBeenToJungle)
                    .Add(ItemID.GenderChangePotion)
                    .Add(ItemID.PotionOfReturn, Condition.DownedEowOrBoc, ModConditions.HasBeenToUnderworld)
                    .Add(ItemID.RecallPotion)
                    .Add(ItemID.TeleportationPotion, Condition.Hardmode, ModConditions.HasBeenToHallow)
                    .Add(ItemID.WormholePotion)
                    .Add(ItemID.RedPotion, Condition.ForTheWorthyWorld)
                    .Add(ItemID.Sunflower, ModConditions.HasBeenToPurity)
                    .Add(ItemID.Campfire, ModConditions.HasBeenToPurity)
                    .Add(ItemID.CrystalBall, Condition.Hardmode, ModConditions.HasBeenToHallow)
                    .Add(ItemID.AmmoBox, ModConditions.HasBeenToPurity)
                    .Add(ItemID.SharpeningStation, ModConditions.HasBeenToJungle)
                    .Add(ItemID.BewitchingTable, Condition.DownedSkeletron, ModConditions.HasBeenToDungeon)
                    .Add(ItemID.WarTable, Condition.DownedOldOnesArmyAny)
                    .Add(ItemID.CatBast, ModConditions.HasBeenToDesert)
                    .Add(ItemID.SliceOfCake, ModConditions.HasBeenToPurity)
                    .Add(ItemID.StarinaBottle, ModConditions.HasBeenThroughNight)
                    .Add(ItemID.HeartLantern, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.GardenGnome, ModConditions.HasBeenToPurity)
                    .Add(ItemID.PeaceCandle, ModConditions.HasBeenToPurity)
                    .Add(ItemID.WaterCandle, Condition.DownedSkeletron, ModConditions.HasBeenToDungeon)
                    .Add(ItemID.ShadowCandle, ModConditions.HasBeenToEvil)
                    .Add(ItemID.WaterBucket, ModConditions.HasBeenToOcean)
                    .Add(ItemID.LavaBucket, ModConditions.HasBeenToUnderworld)
                    .Add(ItemID.HoneyBucket, ModConditions.HasBeenToJungle)
                    .Add(ItemID.LifeCrystal, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.LifeFruit, Condition.DownedMechBossAny, ModConditions.HasBeenToJungle)
                    .Add(ItemID.ManaCrystal, ModConditions.HasBeenThroughNight)
                    .Add(ItemID.AegisCrystal, ModConditions.HasBeenToAether)
                    .Add(ItemID.ArcaneCrystal, ModConditions.HasBeenToAether)
                    .Add(ItemID.AegisFruit, Condition.DownedMechBossAny, ModConditions.HasBeenToAether)
                    .Add(ItemID.Ambrosia, ModConditions.HasBeenToAether)
                    .Add(ItemID.GummyWorm, ModConditions.HasBeenToAether)
                    .Add(ItemID.GalaxyPearl, ModConditions.HasBeenToAether)
                    .Add(ItemID.PeddlersSatchel, ModConditions.HasBeenToAether)
                    .Add(ItemID.CombatBook, ModConditions.DownedBloodMoon)
                    .Add(ItemID.CombatBookVolumeTwo, Condition.Hardmode, ModConditions.HasBeenToAether);
            flaskShop.Register();

            var matShop = new NPCShop(Type, "Materials")
                    .Add(ItemID.AncientCloth, Condition.Hardmode, ModConditions.HasBeenToDesert)
                    .Add(ItemID.AntlionMandible, ModConditions.HasBeenToDesert)
                    .Add(ItemID.BeetleHusk, Condition.DownedGolem, ModConditions.HasBeenToTemple)
                    .Add(ItemID.BeeWax, Condition.DownedQueenBee, ModConditions.HasBeenToJungle)
                    .Add(ItemID.BlackFairyDust, Condition.DownedPumpking)
                    .Add(ItemID.BlackInk, ModConditions.HasBeenToOcean)
                    .Add(ItemID.BlackLens, ModConditions.HasBeenThroughNight)
                    .Add(ItemID.BlackPearl, ModConditions.HasBeenToDesert)
                    .Add(ItemID.BlackThread, Condition.DownedSkeletron)
                    .Add(ItemID.Bone, Condition.DownedSkeletron, ModConditions.HasBeenToDungeon)
                    .Add(ItemID.BoneFeather, Condition.DownedPlantera, ModConditions.HasBeenToDungeon)
                    .Add(ItemID.BrokenBatWing, Condition.Hardmode, ModConditions.DownedEclipse)
                    .Add(ItemID.BrokenHeroSword, Condition.DownedPlantera, ModConditions.DownedEclipse)
                    .Add(ItemID.ButterflyDust, Condition.Hardmode, ModConditions.HasBeenToJungle)
                    .Add(ItemID.CursedFlame, Condition.Hardmode, ModConditions.HasBeenToEvil)
                    .Add(ItemID.CyanHusk, ModConditions.HasBeenToSnow)
                    .Add(ItemID.DarkShard, Condition.Hardmode, ModConditions.HasBeenToEvil, ModConditions.HasBeenToDesert)
                    .Add(ItemID.Ectoplasm, Condition.DownedPlantera, ModConditions.HasBeenToDungeon)
                    .Add(ItemID.ExplosivePowder, Condition.Hardmode)
                    .Add(ItemID.FallenStar, ModConditions.HasBeenThroughNight)
                    .Add(ItemID.Feather, ModConditions.HasBeenToSky)
                    .Add(ItemID.FireFeather, Condition.DownedMechBossAny, ModConditions.HasBeenToUnderworld)
                    .Add(ItemID.FlinxFur, ModConditions.HasBeenToSnow)
                    .Add(ItemID.AncientBattleArmorMaterial, Condition.Hardmode, ModConditions.HasBeenToDesert)
                    .Add(ItemID.FrostCore, Condition.Hardmode, ModConditions.HasBeenToSnow)
                    .Add(ItemID.Gel, ModConditions.HasBeenToPurity)
                    .Add(ItemID.GiantHarpyFeather, Condition.Hardmode, ModConditions.HasBeenToSky)
                    .Add(ItemID.GoldDust, Condition.Hardmode)
                    .Add(ItemID.GreenThread, ModConditions.HasBeenToJungle)
                    .Add(ItemID.Hook, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.IceFeather, Condition.Hardmode, ModConditions.HasBeenToSnow)
                    .Add(ItemID.Ichor, Condition.Hardmode, ModConditions.HasBeenToEvil)
                    .Add(ItemID.IllegalGunParts, ModConditions.HasBeenThroughNight)
                    .Add(ItemID.JungleSpores, ModConditions.HasBeenToJungle)
                    .Add(ItemID.Leather, ModConditions.HasBeenToEvil)
                    .Add(ItemID.Lens, ModConditions.HasBeenThroughNight)
                    .Add(ItemID.LightShard, Condition.Hardmode, ModConditions.HasBeenToHallow, ModConditions.HasBeenToDesert)
                    .Add(ItemID.MechanicalBatteryPiece, Condition.DownedSkeletronPrime)
                    .Add(ItemID.MechanicalWagonPiece, Condition.DownedDestroyer)
                    .Add(ItemID.MechanicalWheelPiece, Condition.DownedTwins)
                    .Add(ItemID.Nanites, Condition.DownedPlantera)
                    .Add(ItemID.FragmentNebula, Condition.DownedNebulaPillar)
                    .Add(ItemID.PinkGel, ModConditions.HasBeenToPurity)
                    .Add(ItemID.PinkPearl, ModConditions.HasBeenToDesert)
                    .Add(ItemID.PinkThread, Condition.DownedSkeletron)
                    .Add(ItemID.PixieDust, Condition.Hardmode, ModConditions.HasBeenToHallow)
                    .Add(ItemID.PurpleMucos, ModConditions.HasBeenToOcean)
                    .Add(ItemID.RedHusk, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.RottenChunk, ModConditions.HasBeenToEvil)
                    .Add(ItemID.ShadowScale, Condition.DownedEowOrBoc, ModConditions.HasBeenToEvil)
                    .Add(ItemID.SharkFin, ModConditions.HasBeenToOcean)
                    .Add(ItemID.Silk, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.LunarTabletFragment, Condition.DownedPlantera, ModConditions.HasBeenToTemple)
                    .Add(ItemID.FragmentSolar, Condition.DownedSolarPillar)
                    .Add(ItemID.SoulofFlight, Condition.Hardmode, ModConditions.HasBeenToSky)
                    .Add(ItemID.SoulofLight, Condition.Hardmode, ModConditions.HasBeenToHallow, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.SoulofNight, Condition.Hardmode, ModConditions.HasBeenToEvil, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.SoulofMight, Condition.DownedDestroyer)
                    .Add(ItemID.SoulofSight, Condition.DownedTwins)
                    .Add(ItemID.SoulofFright, Condition.DownedSkeletronPrime)
                    .Add(ItemID.SpiderFang, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.SpookyTwig, Condition.DownedMourningWood)
                    .Add(ItemID.FragmentStardust, Condition.DownedStardustPillar)
                    .Add(ItemID.Stinger, ModConditions.HasBeenToJungle)
                    .Add(ItemID.TatteredBeeWing, Condition.DownedMechBossAny, ModConditions.HasBeenToJungle)
                    .Add(ItemID.TatteredCloth, ModConditions.HasBeenToOcean)
                    .Add(ItemID.TissueSample, Condition.DownedEowOrBoc, ModConditions.HasBeenToEvil)
                    .Add(ItemID.TurtleShell, Condition.Hardmode, ModConditions.HasBeenToJungle)
                    .Add(ItemID.UnicornHorn, Condition.Hardmode, ModConditions.HasBeenToHallow)
                    .Add(ItemID.Vertebrae, ModConditions.HasBeenToEvil)
                    .Add(ItemID.VialofVenom, Condition.DownedPlantera)
                    .Add(ItemID.Vine, ModConditions.HasBeenToJungle)
                    .Add(ItemID.VioletHusk, ModConditions.HasBeenToJungle)
                    .Add(ItemID.FragmentVortex, Condition.DownedVortexPillar)
                    .Add(ItemID.WhitePearl, ModConditions.HasBeenToDesert)
                    .Add(ItemID.WhoopieCushion, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.WormTooth, ModConditions.HasBeenToEvil);
            matShop.Register();

            var moveAccsShop = new NPCShop(Type, "Movement Accessories")
                   .Add(ItemID.Aglet, ModConditions.HasBeenToPurity)
                   .Add(ItemID.AnkletoftheWind, ModConditions.HasBeenToJungle)
                   .Add(ItemID.BalloonPufferfish, ModConditions.HasBeenToOcean)
                   .Add(ItemID.BlizzardinaBottle, ModConditions.HasBeenToSnow)
                   .Add(ItemID.ClimbingClaws, ModConditions.HasBeenToPurity)
                   .Add(ItemID.CloudinaBottle, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(ItemID.Flipper, ModConditions.HasBeenToOcean)
                   .Add(ItemID.CreativeWings, ModConditions.HasBeenToSky)
                   .Add(ItemID.FlowerBoots, ModConditions.HasBeenToJungle)
                   .Add(ItemID.FlyingCarpet, ModConditions.HasBeenToDesert)
                   .Add(ItemID.FrogLeg, ModConditions.HasBeenToOcean)
                   .Add(ItemID.HermesBoots, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(ItemID.IceSkates, ModConditions.HasBeenToSnow)
                   .Add(ItemID.FloatingTube, ModConditions.HasBeenToOcean)
                   .Add(ItemID.JellyfishNecklace, ModConditions.HasBeenToOcean)
                   .Add(ItemID.LavaCharm, ModConditions.HasBeenToUnderworld)
                   .Add(ItemID.LuckyHorseshoe, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(ItemID.Magiluminescence, ModConditions.HasBeenToEvil)
                   .Add(ItemID.MoonCharm, Condition.Hardmode, ModConditions.DownedBloodMoon)
                   .Add(ItemID.NeptunesShell, Condition.DownedMechBossAny, ModConditions.DownedEclipse)
                   .Add(ItemID.RocketBoots, Condition.DownedGoblinArmy)
                   .Add(ItemID.SandstorminaBottle, ModConditions.HasBeenToDesert)
                   .Add(ItemID.ShinyRedBalloon, ModConditions.HasBeenToSky)
                   .Add(ItemID.ShoeSpikes, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(ItemID.Tabi, Condition.DownedPlantera, ModConditions.HasBeenToDungeon)
                   .Add(ItemID.TsunamiInABottle, ModConditions.HasBeenToOcean)
                   .Add(ItemID.WaterWalkingBoots, ModConditions.HasBeenToOcean);
            moveAccsShop.Register();

            var combatAccsShop = new NPCShop(Type, "Combat Accessories")
                    .Add(ItemID.AdhesiveBandage, Condition.Hardmode)
                    .Add(ItemID.ApprenticeScarf, Condition.DownedOldOnesArmyAny)
                    .Add(ItemID.ArmorPolish, Condition.Hardmode)
                    .Add(ItemID.AvengerEmblem, Condition.DownedMechBossAll)
                    .Add(ItemID.BandofRegeneration, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.BandofStarpower, ModConditions.HasBeenToEvil)
                    .Add(ItemID.Bezoar, ModConditions.HasBeenToJungle)
                    .Add(ItemID.BlackBelt, Condition.DownedPlantera, ModConditions.HasBeenToDungeon)
                    .Add(ItemID.BlackCounterweight)
                    .Add(ItemID.Blindfold, Condition.Hardmode)
                    .Add(ItemID.CelestialMagnet, ModConditions.HasBeenToSky)
                    .Add(ItemID.CobaltShield, Condition.DownedSkeletron, ModConditions.HasBeenToDungeon)
                    .Add(ItemID.CrossNecklace, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.DestroyerEmblem, Condition.DownedGolem)
                    .Add(ItemID.EyeoftheGolem, Condition.DownedGolem, ModConditions.HasBeenToTemple)
                    .Add(ItemID.FastClock, Condition.Hardmode)
                    .Add(ItemID.FeralClaws, ModConditions.HasBeenToJungle)
                    .Add(ItemID.FleshKnuckles, Condition.Hardmode, ModConditions.HasBeenToEvil)
                    .Add(ItemID.FrozenTurtleShell, Condition.Hardmode, ModConditions.HasBeenToSnow)
                    .Add(ItemID.HandWarmer, ModConditions.HasBeenToSnow)
                    .Add(ItemID.HerculesBeetle, Condition.DownedPlantera, ModConditions.HasBeenToJungle)
                    .Add(ItemID.HoneyComb, Condition.DownedQueenBee, ModConditions.HasBeenToJungle)
                    .Add(ItemID.HuntressBuckler, Condition.DownedOldOnesArmyT2)
                    .Add(ItemID.MagicQuiver, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.MagmaStone, ModConditions.HasBeenToUnderworld)
                    .Add(ItemID.Megaphone, Condition.Hardmode)
                    .Add(ItemID.MonkBelt, Condition.DownedOldOnesArmyT2)
                    .Add(ItemID.MoonStone, Condition.DownedMechBossAny, ModConditions.DownedEclipse)
                    .Add(ItemID.NaturesGift, ModConditions.HasBeenToJungle)
                    .Add(ItemID.Nazar, Condition.DownedSkeletron, ModConditions.HasBeenToDungeon)
                    .Add(ItemID.NecromanticScroll, Condition.DownedPlantera)
                    .Add(ItemID.ObsidianRose, ModConditions.HasBeenToUnderworld)
                    .Add(ItemID.ObsidianSkull, ModConditions.HasBeenToUnderworld)
                    .Add(ItemID.PaladinsShield, Condition.DownedPlantera, ModConditions.HasBeenToDungeon)
                    .Add(ItemID.PanicNecklace, ModConditions.HasBeenToEvil)
                    .Add(ItemID.PhilosophersStone, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.PocketMirror, Condition.Hardmode)
                    .Add(ItemID.PutridScent, Condition.Hardmode, ModConditions.HasBeenToEvil)
                    .Add(ItemID.PygmyNecklace, Condition.DownedQueenBee)
                    .Add(ItemID.RangerEmblem, Condition.Hardmode, ModConditions.HasBeenToUnderworld)
                    .Add(ItemID.RifleScope, Condition.DownedPlantera, ModConditions.HasBeenToDungeon)
                    .Add(ItemID.Shackle, ModConditions.HasBeenThroughNight)
                    .Add(ItemID.SharkToothNecklace, ModConditions.DownedBloodMoon, ModConditions.HasBeenToOcean)
                    .Add(ItemID.SorcererEmblem, Condition.Hardmode, ModConditions.HasBeenToUnderworld)
                    .Add(ItemID.SquireShield, Condition.DownedOldOnesArmyAny)
                    .Add(ItemID.StarCloak, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.SummonerEmblem, Condition.Hardmode, ModConditions.HasBeenToUnderworld)
                    .Add(ItemID.SunStone, Condition.DownedGolem, ModConditions.HasBeenToTemple)
                    .Add(ItemID.TitanGlove, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.TrifoldMap, Condition.Hardmode)
                    .Add(ItemID.Vitamins, Condition.Hardmode)
                    .Add(ItemID.WarriorEmblem, Condition.Hardmode, ModConditions.HasBeenToUnderworld)
                    .Add(ItemID.WhiteString, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.YoYoGlove, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground);
            combatAccsShop.Register();

            var infoShop = new NPCShop(Type, "Informative/Building Gear")
                    .Add(ItemID.Toolbelt)
                    .Add(ItemID.Toolbox)
                    .Add(ItemID.ArchitectGizmoPack, Condition.NotDownedSkeletron)
                    .Add(ItemID.AncientChisel, Condition.NotDownedSkeletron, ModConditions.HasBeenToDesert)
                    .Add(ItemID.HandOfCreation, Condition.DownedSkeletron)
                    .Add(ItemID.ActuationAccessory, Condition.DownedSkeletron, ModConditions.HasBeenToDungeon)
                    .Add(ItemID.Paintbrush, Condition.NotDownedPlantera)
                    .Add(ItemID.PaintRoller, Condition.NotDownedPlantera)
                    .Add(ItemID.PaintScraper, Condition.NotDownedPlantera)
                    .Add(ItemID.SpectrePaintbrush, Condition.DownedPlantera)
                    .Add(ItemID.SpectrePaintRoller, Condition.DownedPlantera)
                    .Add(ItemID.SpectrePaintScraper, Condition.DownedPlantera)
                    .Add(ItemID.UltrabrightHelmet, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.MiningShirt, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.MiningPants, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.AnglerTackleBag, Condition.NotDownedEowOrBoc, Condition.AnglerQuestsFinishedOver(0), ModConditions.HasBeenToOcean)
                    .Add(ItemID.LavaproofTackleBag, Condition.DownedEowOrBoc, Condition.AnglerQuestsFinishedOver(0), ModConditions.HasBeenToOcean)
                    .Add(ItemID.FishingBobber, Condition.AnglerQuestsFinishedOver(0), ModConditions.HasBeenToOcean)
                    .Add(ItemID.AnglerHat, Condition.AnglerQuestsFinishedOver(0), ModConditions.HasBeenToOcean)
                    .Add(ItemID.AnglerVest, Condition.AnglerQuestsFinishedOver(0), ModConditions.HasBeenToOcean)
                    .Add(ItemID.AnglerPants, Condition.AnglerQuestsFinishedOver(0), ModConditions.HasBeenToOcean)
                    .Add(ItemID.GoldenFishingRod, Condition.AnglerQuestsFinishedOver(0), ModConditions.HasBeenToOcean)
                    .Add(ItemID.GoldenBugNet, Condition.AnglerQuestsFinishedOver(0), ModConditions.HasBeenToOcean)
                    .Add(ItemID.MasterBait, Condition.AnglerQuestsFinishedOver(0), ModConditions.HasBeenToOcean)
                    .Add(ItemID.PlatinumWatch, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.DepthMeter, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.Compass, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.Radar, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.TallyCounter, Condition.DownedSkeletron, ModConditions.HasBeenToDungeon)
                    .Add(ItemID.LifeformAnalyzer)
                    .Add(ItemID.DPSMeter)
                    .Add(ItemID.Stopwatch)
                    .Add(ItemID.MetalDetector, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.FishermansGuide, ModConditions.HasBeenToOcean)
                    .Add(ItemID.WeatherRadio, ModConditions.HasBeenToOcean)
                    .Add(ItemID.Sextant, ModConditions.HasBeenToOcean)
                    .Add(ItemID.MagicMirror, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.MagicConch, ModConditions.HasBeenToOcean)
                    .Add(ItemID.DemonConch, Condition.DownedEowOrBoc, ModConditions.HasBeenToUnderworld)
                    .Add(ItemID.Shellphone, Condition.Hardmode)
                    .Add(ItemID.ArcticDivingGear, ModConditions.HasBeenToSnow)
                    .Add(ItemID.DiscountCard, Condition.DownedPirates)
                    .Add(ItemID.LuckyCoin, Condition.DownedPirates)
                    .Add(ItemID.GoldRing, Condition.DownedPirates)
                    .Add(ItemID.WireKite, Condition.DownedSkeletron, ModConditions.HasBeenToDungeon)
                    .Add(ItemID.MoneyTrough, ModConditions.DownedBloodMoon)
                    .Add(ItemID.CordageGuide)
                    .Add(ItemID.DontHurtComboBook)
                    .Add(ItemID.RoyalGel, Condition.DownedKingSlime)
                    .Add(ItemID.TorchGodsFavor, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.BottomlessBucket, Condition.AnglerQuestsFinishedOver(0))
                    .Add(ItemID.BottomlessHoneyBucket, Condition.AnglerQuestsFinishedOver(0))
                    .Add(ItemID.BottomlessLavaBucket, Condition.AnglerQuestsFinishedOver(0))
                    .Add(ItemID.BottomlessShimmerBucket, Condition.AnglerQuestsFinishedOver(0), Condition.DownedMoonLord)
                    .Add(ItemID.SuperAbsorbantSponge, Condition.AnglerQuestsFinishedOver(0))
                    .Add(ItemID.HoneyAbsorbantSponge, Condition.AnglerQuestsFinishedOver(0))
                    .Add(ItemID.LavaAbsorbantSponge, Condition.AnglerQuestsFinishedOver(0))
                    .Add(ItemID.Binoculars, Condition.DownedEyeOfCthulhu)
                    .Add(ItemID.EncumberingStone, ModConditions.HasBeenToDesert)
                    .Add(ItemID.PortalGun, Condition.DownedMoonLord)
                    .Add(ItemID.RodofDiscord, Condition.Hardmode, ModConditions.HasBeenToHallow);
            if (ModConditions.calamityLoaded)
            {
                infoShop.Add(ItemID.RodOfHarmony, ModConditions.DownedSupremeCalamitas, ModConditions.DownedExoMechs, ModConditions.HasBeenToAether);
            }
            else
            {
                infoShop.Add(ItemID.RodOfHarmony, Condition.DownedMoonLord, ModConditions.HasBeenToAether);
            }
            infoShop.Register();

            var bossShop = new NPCShop(Type, "Treasure Bags")
                    .Add(new Item(ItemID.KingSlimeBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedKingSlime, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.EyeOfCthulhuBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedEyeOfCthulhu, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.EaterOfWorldsBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedEowOrBoc, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.BrainOfCthulhuBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedEowOrBoc, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.QueenBeeBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedQueenBee, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.SkeletronBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedSkeletron, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.DeerclopsBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedDeerclops, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.WallOfFleshBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.Hardmode, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.QueenSlimeBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedQueenSlime, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.DestroyerBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedDestroyer, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.TwinsBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedTwins, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.SkeletronPrimeBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedSkeletronPrime, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.PlanteraBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedPlantera, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.GolemBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedGolem, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.BossBagBetsy) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedOldOnesArmyT3, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.FishronBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedDukeFishron, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.FairyQueenBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedEmpressOfLight, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.MoonLordBossBag) { shopCustomPrice = Item.buyPrice(platinum: 2) }, Condition.DownedMoonLord, ModConditions.expertOrMaster)
                    .Add(ItemID.DefenderMedal, Condition.DownedOldOnesArmyAny);
            bossShop.Register();

            var crateShop = new NPCShop(Type, "Crates & Grab Bags")
                    .Add(ItemID.WoodenCrate, ModConditions.HasBeenToOcean)
                    .Add(ItemID.IronCrate, ModConditions.HasBeenToOcean)
                    .Add(ItemID.GoldenCrate, ModConditions.HasBeenToOcean)
                    .Add(ItemID.JungleFishingCrate, ModConditions.HasBeenToJungle)
                    .Add(ItemID.FloatingIslandFishingCrate, ModConditions.HasBeenToSky)
                    .Add(ItemID.CorruptFishingCrate, ModConditions.HasBeenToEvil)
                    .Add(ItemID.CrimsonFishingCrate, ModConditions.HasBeenToEvil)
                    .Add(ItemID.HallowedFishingCrate, ModConditions.HasBeenToHallow)
                    .Add(ItemID.DungeonFishingCrate, Condition.DownedSkeletron, ModConditions.HasBeenToDungeon)
                    .Add(ItemID.FrozenCrate, ModConditions.HasBeenToSnow)
                    .Add(ItemID.OasisCrate, ModConditions.HasBeenToDesert)
                    .Add(ItemID.LavaCrate, ModConditions.HasBeenToUnderworld)
                    .Add(ItemID.OceanCrate, ModConditions.HasBeenToOcean)
                    .Add(ItemID.WoodenCrateHard, Condition.Hardmode, ModConditions.HasBeenToOcean)
                    .Add(ItemID.IronCrateHard, Condition.Hardmode, ModConditions.HasBeenToOcean)
                    .Add(ItemID.GoldenCrateHard, Condition.Hardmode, ModConditions.HasBeenToOcean)
                    .Add(ItemID.JungleFishingCrateHard, Condition.Hardmode, ModConditions.HasBeenToJungle)
                    .Add(ItemID.FloatingIslandFishingCrateHard, Condition.Hardmode, ModConditions.HasBeenToSky)
                    .Add(ItemID.CorruptFishingCrateHard, Condition.Hardmode, ModConditions.HasBeenToEvil)
                    .Add(ItemID.CrimsonFishingCrateHard, Condition.Hardmode, ModConditions.HasBeenToEvil)
                    .Add(ItemID.HallowedFishingCrateHard, Condition.Hardmode, ModConditions.HasBeenToHallow)
                    .Add(ItemID.DungeonFishingCrateHard, Condition.Hardmode, Condition.DownedSkeletron, ModConditions.HasBeenToDungeon)
                    .Add(ItemID.FrozenCrateHard, Condition.Hardmode, ModConditions.HasBeenToSnow)
                    .Add(ItemID.OasisCrateHard, Condition.Hardmode, ModConditions.HasBeenToDesert)
                    .Add(ItemID.LavaCrateHard, Condition.Hardmode, ModConditions.HasBeenToUnderworld)
                    .Add(ItemID.OceanCrateHard, Condition.Hardmode, ModConditions.HasBeenToOcean)
                    .Add(ItemID.GoodieBag)
                    .Add(ItemID.Present);
            crateShop.Register();

            var oreShop = new NPCShop(Type, "Ores & Bars")
                    .Add(ItemID.CopperOre, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.TinOre, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.IronOre, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.LeadOre, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.SilverOre, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.TungstenOre, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.GoldOre, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.PlatinumOre, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.Meteorite, Condition.DownedEowOrBoc)
                    .Add(ItemID.DemoniteOre, Condition.DownedEowOrBoc, ModConditions.HasBeenToEvil)
                    .Add(ItemID.CrimtaneOre, Condition.DownedEowOrBoc, ModConditions.HasBeenToEvil)
                    .Add(ItemID.Hellstone, Condition.DownedEowOrBoc, ModConditions.HasBeenToUnderworld)
                    .Add(ItemID.CobaltOre, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.PalladiumOre, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.MythrilOre, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.OrichalcumOre, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.AdamantiteOre, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.TitaniumOre, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.ChlorophyteOre, Condition.DownedMechBossAll, ModConditions.HasBeenToJungle)
                    .Add(ItemID.LunarOre, Condition.DownedMoonLord)
                    .Add(ItemID.CopperBar, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.TinBar, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.IronBar, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.LeadBar, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.SilverBar, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.TungstenBar, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.GoldBar, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.PlatinumBar, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.MeteoriteBar, Condition.DownedEowOrBoc)
                    .Add(ItemID.DemoniteBar, Condition.DownedEowOrBoc, ModConditions.HasBeenToEvil)
                    .Add(ItemID.CrimtaneBar, Condition.DownedEowOrBoc, ModConditions.HasBeenToEvil)
                    .Add(ItemID.HellstoneBar, Condition.DownedEowOrBoc, ModConditions.HasBeenToUnderworld)
                    .Add(ItemID.CobaltBar, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.PalladiumBar, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.MythrilBar, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.OrichalcumBar, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.AdamantiteBar, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.TitaniumBar, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.HallowedBar, Condition.DownedMechBossAny)
                    .Add(ItemID.ChlorophyteBar, Condition.DownedMechBossAll, ModConditions.HasBeenToJungle)
                    .Add(ItemID.LunarBar, Condition.DownedMoonLord)
                    .Add(ItemID.CrystalShard, Condition.Hardmode, ModConditions.HasBeenToHallow)
                    .Add(ItemID.Amber, ModConditions.HasBeenToDesert)
                    .Add(ItemID.Amethyst, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.Diamond, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.Emerald, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.Ruby, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.Sapphire, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.Topaz, ModConditions.HasBeenToCavernsOrUnderground);
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
                    .Add(ItemID.NebulaBrick, Condition.DownedNebulaPillar)
                    .Add(ItemID.SolarBrick, Condition.DownedSolarPillar)
                    .Add(ItemID.StardustBrick, Condition.DownedStardustPillar)
                    .Add(ItemID.VortexBrick, Condition.DownedVortexPillar)
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
                    .Add(ItemID.LunarBlockNebula, Condition.DownedNebulaPillar)
                    .Add(ItemID.LunarBlockSolar, Condition.DownedSolarPillar)
                    .Add(ItemID.LunarBlockStardust, Condition.DownedStardustPillar)
                    .Add(ItemID.LunarBlockVortex, Condition.DownedVortexPillar)
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
                    .Add(ItemID.Blinkroot, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.BlinkrootSeeds, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.Daybloom, ModConditions.HasBeenToPurity)
                    .Add(ItemID.DaybloomSeeds, ModConditions.HasBeenToPurity)
                    .Add(ItemID.Deathweed, ModConditions.HasBeenToEvil)
                    .Add(ItemID.DeathweedSeeds, ModConditions.HasBeenToEvil)
                    .Add(ItemID.Fireblossom, ModConditions.HasBeenToUnderworld)
                    .Add(ItemID.FireblossomSeeds, ModConditions.HasBeenToUnderworld)
                    .Add(ItemID.Moonglow, ModConditions.HasBeenToJungle)
                    .Add(ItemID.MoonglowSeeds, ModConditions.HasBeenToJungle)
                    .Add(ItemID.Shiverthorn, ModConditions.HasBeenToSnow)
                    .Add(ItemID.ShiverthornSeeds, ModConditions.HasBeenToSnow)
                    .Add(ItemID.Waterleaf, ModConditions.HasBeenToDesert)
                    .Add(ItemID.WaterleafSeeds, ModConditions.HasBeenToDesert)
                    .Add(ItemID.PumpkinSeed, Condition.DownedEyeOfCthulhu)
                    .Add(ItemID.TealMushroom, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.GreenMushroom, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.SkyBlueFlower, ModConditions.HasBeenToJungle)
                    .Add(ItemID.YellowMarigold)
                    .Add(ItemID.BlueBerries)
                    .Add(ItemID.LimeKelp, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.PinkPricklyPear, ModConditions.HasBeenToDesert)
                    .Add(ItemID.OrangeBloodroot, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(ItemID.VileMushroom, ModConditions.HasBeenToEvil)
                    .Add(ItemID.ViciousMushroom, ModConditions.HasBeenToEvil)
                    .Add(ItemID.Mushroom)
                    .Add(ItemID.GlowingMushroom, ModConditions.HasBeenToMushroom)
                    .Add(ItemID.GrassSeeds, Condition.DownedEyeOfCthulhu, ModConditions.HasBeenToPurity)
                    .Add(ItemID.JungleGrassSeeds, ModConditions.HasBeenToJungle)
                    .Add(ItemID.MushroomGrassSeeds, ModConditions.HasBeenToMushroom)
                    .Add(ItemID.CorruptSeeds, Condition.DownedEyeOfCthulhu, ModConditions.HasBeenToEvil, ModConditions.DownedBloodMoon)
                    .Add(ItemID.CrimsonSeeds, Condition.DownedEyeOfCthulhu, ModConditions.HasBeenToEvil, ModConditions.DownedBloodMoon)
                    .Add(ItemID.AshGrassSeeds, ModConditions.HasBeenToUnderworld)
                    .Add(ItemID.HallowedSeeds, Condition.Hardmode, ModConditions.HasBeenToHallow)
                    .Add(ItemID.Acorn)
                    .Add(ItemID.Fertilizer, Condition.DownedSkeletron);
            plantShop.Register();
        }
    }
}
