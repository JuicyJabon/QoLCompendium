using QoLCompendium.Tweaks;
using QoLCompendium.UI;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;

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
            else if (shopNum == 12)
            {
                button = "Fish & Fishing Gear";
                ShopName = "Fish & Fishing Gear";
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
                    .Add(new Item(ItemID.AmmoReservationPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToJungle)
                    .Add(new Item(ItemID.Ale) { shopCustomPrice = Item.buyPrice(silver: 75) })
                    .Add(new Item(ItemID.ArcheryPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToPurity)
                    .Add(new Item(ItemID.BattlePotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToEvil)
                    .Add(new Item(ItemID.BiomeSightPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, Condition.DownedEyeOfCthulhu, ModConditions.HasBeenToUnderworld)
                    .Add(new Item(ItemID.BuilderPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToSnow)
                    .Add(new Item(ItemID.CalmingPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToSky)
                    .Add(new Item(ItemID.CratePotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToDesert)
                    .Add(new Item(ItemID.TrapsightPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToSnow)
                    .Add(new Item(ItemID.EndurancePotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.FeatherfallPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToSky)
                    .Add(new Item(ItemID.FishingPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToJungle)
                    .Add(new Item(ItemID.FlipperPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToSnow)
                    .Add(new Item(ItemID.GillsPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToOcean)
                    .Add(new Item(ItemID.GravitationPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToSky)
                    .Add(new Item(ItemID.LuckPotionGreater) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToDesert)
                    .Add(new Item(ItemID.HeartreachPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToEvil)
                    .Add(new Item(ItemID.HunterPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToOcean)
                    .Add(new Item(ItemID.InfernoPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToUnderworld)
                    .Add(new Item(ItemID.InvisibilityPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToJungle)
                    .Add(new Item(ItemID.IronskinPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.LifeforcePotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, Condition.Hardmode, ModConditions.HasBeenToHallow)
                    .Add(new Item(ItemID.MagicPowerPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToJungle)
                    .Add(new Item(ItemID.ManaRegenerationPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToJungle)
                    .Add(new Item(ItemID.MiningPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToDesert)
                    .Add(new Item(ItemID.NightOwlPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToPurity)
                    .Add(new Item(ItemID.ObsidianSkinPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToUnderworld)
                    .Add(new Item(ItemID.RagePotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToEvil)
                    .Add(new Item(ItemID.RedPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, Condition.ForTheWorthyWorld)
                    .Add(new Item(ItemID.RegenerationPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToPurity)
                    .Add(new Item(ItemID.Sake) { shopCustomPrice = Item.buyPrice(silver: 75) })
                    .Add(new Item(ItemID.ShinePotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToMushroom)
                    .Add(new Item(ItemID.SonarPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToOcean)
                    .Add(new Item(ItemID.SpelunkerPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.SummoningPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToJungle)
                    .Add(new Item(ItemID.SwiftnessPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToDesert)
                    .Add(new Item(ItemID.ThornsPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToDesert)
                    .Add(new Item(ItemID.TitanPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToDungeon)
                    .Add(new Item(ItemID.WarmthPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToSnow)
                    .Add(new Item(ItemID.WaterWalkingPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToOcean)
                    .Add(new Item(ItemID.WrathPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, ModConditions.HasBeenToEvil);
            potShop.Register();

            var flaskShop = new NPCShop(Type, "Flasks, Stations & Foods")
                    .Add(new Item(ItemID.FruitJuice) { shopCustomPrice = Item.buyPrice(silver: 75) })
                    .Add(new Item(ItemID.LobsterTail) { shopCustomPrice = Item.buyPrice(silver: 75) })
                    .Add(new Item(ItemID.GoldenDelight) { shopCustomPrice = Item.buyPrice(silver: 75) })
                    .Add(new Item(ItemID.FlaskofCursedFlames) { shopCustomPrice = Item.buyPrice(silver: 75) }, Condition.Hardmode, Condition.DownedQueenBee, ModConditions.HasBeenToEvil)
                    .Add(new Item(ItemID.FlaskofFire) { shopCustomPrice = Item.buyPrice(silver: 75) }, Condition.DownedQueenBee, ModConditions.HasBeenToUnderworld)
                    .Add(new Item(ItemID.FlaskofGold) { shopCustomPrice = Item.buyPrice(silver: 75) }, Condition.Hardmode, Condition.DownedQueenBee)
                    .Add(new Item(ItemID.FlaskofIchor) { shopCustomPrice = Item.buyPrice(silver: 75) }, Condition.Hardmode, Condition.DownedQueenBee, ModConditions.HasBeenToEvil)
                    .Add(new Item(ItemID.FlaskofNanites) { shopCustomPrice = Item.buyPrice(silver: 75) }, Condition.DownedPlantera, Condition.DownedQueenBee)
                    .Add(new Item(ItemID.FlaskofParty) { shopCustomPrice = Item.buyPrice(silver: 75) }, Condition.DownedQueenBee)
                    .Add(new Item(ItemID.FlaskofPoison) { shopCustomPrice = Item.buyPrice(silver: 75) }, Condition.DownedQueenBee, ModConditions.HasBeenToJungle)
                    .Add(new Item(ItemID.FlaskofVenom) { shopCustomPrice = Item.buyPrice(silver: 75) }, Condition.Hardmode, Condition.DownedQueenBee, ModConditions.HasBeenToJungle)
                    .Add(new Item(ItemID.GenderChangePotion) { shopCustomPrice = Item.buyPrice(silver: 75) })
                    .Add(new Item(ItemID.PotionOfReturn) { shopCustomPrice = Item.buyPrice(silver: 75) }, Condition.DownedEowOrBoc, ModConditions.HasBeenToUnderworld)
                    .Add(new Item(ItemID.RecallPotion) { shopCustomPrice = Item.buyPrice(silver: 75) })
                    .Add(new Item(ItemID.TeleportationPotion) { shopCustomPrice = Item.buyPrice(silver: 75) }, Condition.Hardmode, ModConditions.HasBeenToHallow)
                    .Add(new Item(ItemID.WormholePotion) { shopCustomPrice = Item.buyPrice(silver: 75) })
                    .Add(new Item(ItemID.Sunflower) { shopCustomPrice = Item.buyPrice(gold: 15) })
                    .Add(new Item(ItemID.Campfire) { shopCustomPrice = Item.buyPrice(gold: 15) })
                    .Add(new Item(ItemID.CrystalBall) { shopCustomPrice = Item.buyPrice(gold: 15) }, Condition.Hardmode, ModConditions.HasBeenToHallow)
                    .Add(new Item(ItemID.AmmoBox) { shopCustomPrice = Item.buyPrice(gold: 15) })
                    .Add(new Item(ItemID.SharpeningStation) { shopCustomPrice = Item.buyPrice(gold: 15) }, ModConditions.HasBeenToJungle)
                    .Add(new Item(ItemID.BewitchingTable) { shopCustomPrice = Item.buyPrice(gold: 15) }, Condition.DownedSkeletron, ModConditions.HasBeenToDungeon)
                    .Add(new Item(ItemID.WarTable) { shopCustomPrice = Item.buyPrice(gold: 15) }, Condition.DownedOldOnesArmyAny)
                    .Add(new Item(ItemID.CatBast) { shopCustomPrice = Item.buyPrice(gold: 15) }, ModConditions.HasBeenToDesert)
                    .Add(new Item(ItemID.SliceOfCake) { shopCustomPrice = Item.buyPrice(gold: 15) })
                    .Add(new Item(ItemID.StarinaBottle) { shopCustomPrice = Item.buyPrice(gold: 15) }, ModConditions.HasBeenThroughNight)
                    .Add(new Item(ItemID.HeartLantern) { shopCustomPrice = Item.buyPrice(gold: 15) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.GardenGnome) { shopCustomPrice = Item.buyPrice(gold: 15) })
                    .Add(new Item(ItemID.PeaceCandle) { shopCustomPrice = Item.buyPrice(gold: 15) })
                    .Add(new Item(ItemID.WaterCandle) { shopCustomPrice = Item.buyPrice(gold: 15) }, Condition.DownedSkeletron, ModConditions.HasBeenToDungeon)
                    .Add(new Item(ItemID.ShadowCandle) { shopCustomPrice = Item.buyPrice(gold: 15) }, ModConditions.HasBeenToEvil)
                    .Add(new Item(ItemID.WaterBucket) { shopCustomPrice = Item.buyPrice(gold: 15) })
                    .Add(new Item(ItemID.LavaBucket) { shopCustomPrice = Item.buyPrice(gold: 15) }, ModConditions.HasBeenToUnderworld)
                    .Add(new Item(ItemID.HoneyBucket) { shopCustomPrice = Item.buyPrice(gold: 15) }, ModConditions.HasBeenToJungle)
                    .Add(new Item(ItemID.LifeCrystal) { shopCustomPrice = Item.buyPrice(gold: 15) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.LifeFruit) { shopCustomPrice = Item.buyPrice(gold: 15) }, Condition.DownedMechBossAny, ModConditions.HasBeenToJungle)
                    .Add(new Item(ItemID.ManaCrystal) { shopCustomPrice = Item.buyPrice(gold: 15) }, ModConditions.HasBeenThroughNight)
                    .Add(new Item(ItemID.AegisCrystal) { shopCustomPrice = Item.buyPrice(gold: 15) }, ModConditions.HasBeenToAether)
                    .Add(new Item(ItemID.ArcaneCrystal) { shopCustomPrice = Item.buyPrice(gold: 15) }, ModConditions.HasBeenToAether)
                    .Add(new Item(ItemID.AegisFruit) { shopCustomPrice = Item.buyPrice(gold: 15) }, Condition.DownedMechBossAny, ModConditions.HasBeenToAether)
                    .Add(new Item(ItemID.Ambrosia) { shopCustomPrice = Item.buyPrice(gold: 15) }, ModConditions.HasBeenToAether)
                    .Add(new Item(ItemID.GummyWorm) { shopCustomPrice = Item.buyPrice(gold: 15) }, ModConditions.HasBeenToAether)
                    .Add(new Item(ItemID.GalaxyPearl) { shopCustomPrice = Item.buyPrice(gold: 15) }, ModConditions.HasBeenToAether)
                    .Add(new Item(ItemID.PeddlersSatchel) { shopCustomPrice = Item.buyPrice(gold: 15) }, ModConditions.HasBeenToAether)
                    .Add(new Item(ItemID.CombatBook) { shopCustomPrice = Item.buyPrice(gold: 15) }, ModConditions.DownedBloodMoon)
                    .Add(new Item(ItemID.CombatBookVolumeTwo) { shopCustomPrice = Item.buyPrice(gold: 15) }, Condition.Hardmode, ModConditions.HasBeenToAether);
            flaskShop.Register();

            var matShop = new NPCShop(Type, "Materials")
                    .Add(new Item(ItemID.AncientCloth) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.Hardmode, ModConditions.HasBeenToDesert)
                    .Add(new Item(ItemID.AntlionMandible) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToDesert)
                    .Add(new Item(ItemID.BeetleHusk) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedGolem, ModConditions.HasBeenToTemple)
                    .Add(new Item(ItemID.BeeWax) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedQueenBee, ModConditions.HasBeenToJungle)
                    .Add(new Item(ItemID.BlackFairyDust) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedPumpking)
                    .Add(new Item(ItemID.BlackInk) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToOcean)
                    .Add(new Item(ItemID.BlackLens) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenThroughNight)
                    .Add(new Item(ItemID.BlackPearl) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToDesert)
                    .Add(new Item(ItemID.BlackThread) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedSkeletron)
                    .Add(new Item(ItemID.Bone) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedSkeletron, ModConditions.HasBeenToDungeon)
                    .Add(new Item(ItemID.BoneFeather) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedPlantera, ModConditions.HasBeenToDungeon)
                    .Add(new Item(ItemID.BrokenBatWing) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.Hardmode, ModConditions.DownedEclipse)
                    .Add(new Item(ItemID.BrokenHeroSword) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedPlantera, ModConditions.DownedEclipse)
                    .Add(new Item(ItemID.ButterflyDust) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.Hardmode, ModConditions.HasBeenToJungle)
                    .Add(new Item(ItemID.CursedFlame) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.Hardmode, ModConditions.HasBeenToEvil)
                    .Add(new Item(ItemID.CyanHusk) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToSnow)
                    .Add(new Item(ItemID.DarkShard) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.Hardmode, ModConditions.HasBeenToEvil, ModConditions.HasBeenToDesert)
                    .Add(new Item(ItemID.Ectoplasm) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedPlantera, ModConditions.HasBeenToDungeon)
                    .Add(new Item(ItemID.ExplosivePowder) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.Hardmode)
                    .Add(new Item(ItemID.FallenStar) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenThroughNight)
                    .Add(new Item(ItemID.Feather) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToSky)
                    .Add(new Item(ItemID.FireFeather) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedMechBossAny, ModConditions.HasBeenToUnderworld)
                    .Add(new Item(ItemID.FlinxFur) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToSnow)
                    .Add(new Item(ItemID.AncientBattleArmorMaterial) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.Hardmode, ModConditions.HasBeenToDesert)
                    .Add(new Item(ItemID.FrostCore) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.Hardmode, ModConditions.HasBeenToSnow)
                    .Add(new Item(ItemID.Gel) { shopCustomPrice = Item.buyPrice(silver: 25) })
                    .Add(new Item(ItemID.GiantHarpyFeather) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.Hardmode, ModConditions.HasBeenToSky)
                    .Add(new Item(ItemID.GoldDust) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.Hardmode)
                    .Add(new Item(ItemID.GreenThread) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToJungle)
                    .Add(new Item(ItemID.Hook) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.IceFeather) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.Hardmode, ModConditions.HasBeenToSnow)
                    .Add(new Item(ItemID.Ichor) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.Hardmode, ModConditions.HasBeenToEvil)
                    .Add(new Item(ItemID.IllegalGunParts) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenThroughNight)
                    .Add(new Item(ItemID.JungleSpores) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToJungle)
                    .Add(new Item(ItemID.Leather) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToEvil)
                    .Add(new Item(ItemID.Lens) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenThroughNight)
                    .Add(new Item(ItemID.LightShard) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.Hardmode, ModConditions.HasBeenToHallow, ModConditions.HasBeenToDesert)
                    .Add(new Item(ItemID.MechanicalBatteryPiece) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedSkeletronPrime, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.MechanicalWagonPiece) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedDestroyer, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.MechanicalWheelPiece) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedTwins, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.Nanites) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedPlantera)
                    .Add(new Item(ItemID.FragmentNebula) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedNebulaPillar)
                    .Add(new Item(ItemID.PinkGel) { shopCustomPrice = Item.buyPrice(silver: 25) })
                    .Add(new Item(ItemID.PinkPearl) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToDesert)
                    .Add(new Item(ItemID.PinkThread) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedSkeletron)
                    .Add(new Item(ItemID.PixieDust) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.Hardmode, ModConditions.HasBeenToHallow)
                    .Add(new Item(ItemID.PurpleMucos) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToOcean)
                    .Add(new Item(ItemID.RedHusk) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.RottenChunk) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToEvil)
                    .Add(new Item(ItemID.ShadowScale) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedEowOrBoc, ModConditions.HasBeenToEvil)
                    .Add(new Item(ItemID.SharkFin) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToOcean)
                    .Add(new Item(ItemID.Silk) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.LunarTabletFragment) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedPlantera, ModConditions.HasBeenToTemple)
                    .Add(new Item(ItemID.FragmentSolar) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedSolarPillar)
                    .Add(new Item(ItemID.SoulofFlight) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.Hardmode, ModConditions.HasBeenToSky)
                    .Add(new Item(ItemID.SoulofLight) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.Hardmode, ModConditions.HasBeenToHallow, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.SoulofNight) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.Hardmode, ModConditions.HasBeenToEvil, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.SoulofMight) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedDestroyer)
                    .Add(new Item(ItemID.SoulofSight) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedTwins)
                    .Add(new Item(ItemID.SoulofFright) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedSkeletronPrime)
                    .Add(new Item(ItemID.SpiderFang) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.SpookyTwig) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedMourningWood)
                    .Add(new Item(ItemID.FragmentStardust) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedStardustPillar)
                    .Add(new Item(ItemID.Stinger) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToJungle)
                    .Add(new Item(ItemID.TatteredBeeWing) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedMechBossAny, ModConditions.HasBeenToJungle)
                    .Add(new Item(ItemID.TatteredCloth) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToOcean)
                    .Add(new Item(ItemID.TissueSample) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedEowOrBoc, ModConditions.HasBeenToEvil)
                    .Add(new Item(ItemID.TurtleShell) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.Hardmode, ModConditions.HasBeenToJungle)
                    .Add(new Item(ItemID.UnicornHorn) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.Hardmode, ModConditions.HasBeenToHallow)
                    .Add(new Item(ItemID.Vertebrae) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToEvil)
                    .Add(new Item(ItemID.VialofVenom) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedPlantera)
                    .Add(new Item(ItemID.Vine) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToJungle)
                    .Add(new Item(ItemID.VioletHusk) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToJungle)
                    .Add(new Item(ItemID.FragmentVortex) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedVortexPillar)
                    .Add(new Item(ItemID.WhitePearl) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToDesert)
                    .Add(new Item(ItemID.WhoopieCushion) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.WormTooth) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToEvil);
            matShop.Register();

            var moveAccsShop = new NPCShop(Type, "Movement Accessories")
                   .Add(new Item(ItemID.Aglet) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.AnkletoftheWind) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToJungle)
                   .Add(new Item(ItemID.BalloonPufferfish) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToOcean)
                   .Add(new Item(ItemID.BlizzardinaBottle) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToSnow)
                   .Add(new Item(ItemID.ClimbingClaws) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.CloudinaBottle) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(new Item(ItemID.DivingHelmet) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToOcean)
                   .Add(new Item(ItemID.SandBoots) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToDesert)
                   .Add(new Item(ItemID.Flipper) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToOcean)
                   .Add(new Item(ItemID.CreativeWings) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToSky)
                   .Add(new Item(ItemID.FlowerBoots) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToJungle)
                   .Add(new Item(ItemID.FlyingCarpet) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToDesert)
                   .Add(new Item(ItemID.FrogLeg) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToOcean)
                   .Add(new Item(ItemID.HermesBoots) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(new Item(ItemID.IceSkates) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToSnow)
                   .Add(new Item(ItemID.FloatingTube) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToOcean)
                   .Add(new Item(ItemID.JellyfishNecklace) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToOcean)
                   .Add(new Item(ItemID.LavaCharm) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToUnderworld)
                   .Add(new Item(ItemID.LuckyHorseshoe) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(new Item(ItemID.Magiluminescence) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToEvil)
                   .Add(new Item(ItemID.MoonCharm) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.Hardmode, ModConditions.DownedBloodMoon)
                   .Add(new Item(ItemID.NeptunesShell) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedMechBossAny, ModConditions.DownedEclipse)
                   .Add(new Item(ItemID.RocketBoots) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedGoblinArmy)
                   .Add(new Item(ItemID.SailfishBoots) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToOcean)
                   .Add(new Item(ItemID.SandstorminaBottle) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToDesert)
                   .Add(new Item(ItemID.ShinyRedBalloon) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToSky)
                   .Add(new Item(ItemID.ShoeSpikes) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(new Item(ItemID.Tabi) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedPlantera, ModConditions.HasBeenToDungeon)
                   .Add(new Item(ItemID.TsunamiInABottle) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToOcean)
                   .Add(new Item(ItemID.WaterWalkingBoots) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToOcean);
            moveAccsShop.Register();

            var combatAccsShop = new NPCShop(Type, "Combat Accessories")
                   .Add(new Item(ItemID.AdhesiveBandage) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.Hardmode, ModConditions.HasBeenToJungle)
                   .Add(new Item(ItemID.ApprenticeScarf) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedOldOnesArmyAny)
                   .Add(new Item(ItemID.ArmorPolish) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.Hardmode)
                   .Add(new Item(ItemID.AvengerEmblem) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedMechBossAll)
                   .Add(new Item(ItemID.BandofRegeneration) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(new Item(ItemID.BandofStarpower) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToEvil)
                   .Add(new Item(ItemID.Bezoar) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToJungle)
                   .Add(new Item(ItemID.BlackBelt) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedPlantera, ModConditions.HasBeenToDungeon)
                   .Add(new Item(ItemID.BlackCounterweight) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.Blindfold) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.Hardmode)
                   .Add(new Item(ItemID.CelestialMagnet) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToSky)
                   .Add(new Item(ItemID.CobaltShield) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedSkeletron, ModConditions.HasBeenToDungeon)
                   .Add(new Item(ItemID.CrossNecklace) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(new Item(ItemID.DestroyerEmblem) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedGolem)
                   .Add(new Item(ItemID.EyeoftheGolem) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedGolem, ModConditions.HasBeenToTemple)
                   .Add(new Item(ItemID.FastClock) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.Hardmode)
                   .Add(new Item(ItemID.FeralClaws) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToJungle)
                   .Add(new Item(ItemID.FleshKnuckles) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.Hardmode, ModConditions.HasBeenToEvil)
                   .Add(new Item(ItemID.FrozenTurtleShell) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.Hardmode, ModConditions.HasBeenToSnow)
                   .Add(new Item(ItemID.HandWarmer) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToSnow)
                   .Add(new Item(ItemID.HerculesBeetle) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedPlantera, ModConditions.HasBeenToJungle)
                   .Add(new Item(ItemID.HoneyComb) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedQueenBee, ModConditions.HasBeenToJungle)
                   .Add(new Item(ItemID.HuntressBuckler) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedOldOnesArmyT2)
                   .Add(new Item(ItemID.MagicQuiver) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(new Item(ItemID.MagmaStone) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToUnderworld)
                   .Add(new Item(ItemID.Megaphone) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.Hardmode, ModConditions.HasBeenToHallow)
                   .Add(new Item(ItemID.MonkBelt) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedOldOnesArmyT2)
                   .Add(new Item(ItemID.MoonStone) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedMechBossAny, ModConditions.DownedEclipse)
                   .Add(new Item(ItemID.NaturesGift) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToJungle)
                   .Add(new Item(ItemID.Nazar) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedSkeletron, ModConditions.HasBeenToDungeon)
                   .Add(new Item(ItemID.NecromanticScroll) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedMourningWood)
                   .Add(new Item(ItemID.ObsidianRose) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToUnderworld)
                   .Add(new Item(ItemID.ObsidianSkull) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToUnderworld)
                   .Add(new Item(ItemID.PaladinsShield) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedPlantera, ModConditions.HasBeenToDungeon)
                   .Add(new Item(ItemID.PanicNecklace) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToEvil)
                   .Add(new Item(ItemID.PhilosophersStone) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(new Item(ItemID.PocketMirror) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.Hardmode)
                   .Add(new Item(ItemID.PutridScent) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.Hardmode, ModConditions.HasBeenToEvil)
                   .Add(new Item(ItemID.PygmyNecklace) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedQueenBee)
                   .Add(new Item(ItemID.RangerEmblem) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.Hardmode, ModConditions.HasBeenToUnderworld)
                   .Add(new Item(ItemID.RifleScope) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedPlantera, ModConditions.HasBeenToDungeon)
                   .Add(new Item(ItemID.Shackle) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenThroughNight)
                   .Add(new Item(ItemID.SharkToothNecklace) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.DownedBloodMoon, ModConditions.HasBeenToOcean)
                   .Add(new Item(ItemID.SorcererEmblem) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.Hardmode, ModConditions.HasBeenToUnderworld)
                   .Add(new Item(ItemID.SquireShield) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedOldOnesArmyAny)
                   .Add(new Item(ItemID.StarCloak) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(new Item(ItemID.SummonerEmblem) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.Hardmode, ModConditions.HasBeenToUnderworld)
                   .Add(new Item(ItemID.SunStone) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedGolem, ModConditions.HasBeenToTemple)
                   .Add(new Item(ItemID.TitanGlove) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(new Item(ItemID.TrifoldMap) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.Hardmode)
                   .Add(new Item(ItemID.Vitamins) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.Hardmode, ModConditions.HasBeenToEvil)
                   .Add(new Item(ItemID.WarriorEmblem) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.Hardmode, ModConditions.HasBeenToUnderworld)
                   .Add(new Item(ItemID.WhiteString) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(new Item(ItemID.YoYoGlove) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground);
            combatAccsShop.Register();

            var infoShop = new NPCShop(Type, "Informative/Building Gear")
                   .Add(new Item(ItemID.Toolbelt) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.Toolbox) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.ArchitectGizmoPack) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.NotDownedSkeletron)
                   .Add(new Item(ItemID.AncientChisel) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.NotDownedSkeletron, ModConditions.HasBeenToDesert)
                   .Add(new Item(ItemID.HandOfCreation) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedSkeletron)
                   .Add(new Item(ItemID.ActuationAccessory) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedSkeletron, ModConditions.HasBeenToDungeon)
                   .Add(new Item(ItemID.Paintbrush) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.NotDownedPlantera)
                   .Add(new Item(ItemID.PaintRoller) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.NotDownedPlantera)
                   .Add(new Item(ItemID.PaintScraper) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.NotDownedPlantera)
                   .Add(new Item(ItemID.SpectrePaintbrush) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedPlantera)
                   .Add(new Item(ItemID.SpectrePaintRoller) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedPlantera)
                   .Add(new Item(ItemID.SpectrePaintScraper) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedPlantera)
                   .Add(new Item(ItemID.UltrabrightHelmet) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(new Item(ItemID.MiningShirt) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(new Item(ItemID.MiningPants) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(new Item(ItemID.PlatinumWatch) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(new Item(ItemID.DepthMeter) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(new Item(ItemID.Compass) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(new Item(ItemID.Radar) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(new Item(ItemID.TallyCounter) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedSkeletron, ModConditions.HasBeenToDungeon)
                   .Add(new Item(ItemID.LifeformAnalyzer) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.DPSMeter) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.Stopwatch) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.MetalDetector) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(new Item(ItemID.FishermansGuide) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToOcean)
                   .Add(new Item(ItemID.WeatherRadio) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToOcean)
                   .Add(new Item(ItemID.Sextant) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToOcean)
                   .Add(new Item(ItemID.MagicMirror) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(new Item(ItemID.MagicConch) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToOcean)
                   .Add(new Item(ItemID.DemonConch) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedEowOrBoc, ModConditions.HasBeenToUnderworld)
                   .Add(new Item(ItemID.Shellphone) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.Hardmode)
                   .Add(new Item(ItemID.ArcticDivingGear) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToSnow)
                   .Add(new Item(ItemID.DiscountCard) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedPirates)
                   .Add(new Item(ItemID.LuckyCoin) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedPirates)
                   .Add(new Item(ItemID.GoldRing) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedPirates)
                   .Add(new Item(ItemID.WireKite) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedSkeletron, ModConditions.HasBeenToDungeon)
                   .Add(new Item(ItemID.MoneyTrough) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.DownedBloodMoon)
                   .Add(new Item(ItemID.CordageGuide) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.DontHurtComboBook) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.RoyalGel) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedKingSlime)
                   .Add(new Item(ItemID.TorchGodsFavor) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(new Item(ItemID.GoldenKey) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedSkeletron, ModConditions.HasBeenToDungeon)
                   .Add(new Item(ItemID.ShadowKey) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedSkeletron, ModConditions.HasBeenToDungeon)
                   .Add(new Item(ItemID.BottomlessBucket) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.BottomlessHoneyBucket) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.BottomlessLavaBucket) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.BottomlessShimmerBucket) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedMoonLord)
                   .Add(new Item(ItemID.SuperAbsorbantSponge) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.HoneyAbsorbantSponge) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.LavaAbsorbantSponge) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.Binoculars) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedEyeOfCthulhu)
                   .Add(new Item(ItemID.EncumberingStone) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToDesert)
                   .Add(new Item(ItemID.PortalGun) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedMoonLord)
                   .Add(new Item(ItemID.RodofDiscord) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.Hardmode, ModConditions.HasBeenToHallow)
                   .Add(new Item(ItemID.RodOfHarmony) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedMoonLord, ModConditions.HasBeenToAether);
            infoShop.Register();

            var bossShop = new NPCShop(Type, "Treasure Bags")
                    .Add(new Item(ItemID.KingSlimeBossBag) { shopCustomPrice = Item.buyPrice(gold: 25) }, Condition.DownedKingSlime, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.EyeOfCthulhuBossBag) { shopCustomPrice = Item.buyPrice(gold: 25) }, Condition.DownedEyeOfCthulhu, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.EaterOfWorldsBossBag) { shopCustomPrice = Item.buyPrice(gold: 25) }, Condition.DownedEowOrBoc, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.BrainOfCthulhuBossBag) { shopCustomPrice = Item.buyPrice(gold: 25) }, Condition.DownedEowOrBoc, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.QueenBeeBossBag) { shopCustomPrice = Item.buyPrice(gold: 25) }, Condition.DownedQueenBee, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.SkeletronBossBag) { shopCustomPrice = Item.buyPrice(gold: 25) }, Condition.DownedSkeletron, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.DeerclopsBossBag) { shopCustomPrice = Item.buyPrice(gold: 25) }, Condition.DownedDeerclops, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.WallOfFleshBossBag) { shopCustomPrice = Item.buyPrice(gold: 25) }, Condition.Hardmode, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.QueenSlimeBossBag) { shopCustomPrice = Item.buyPrice(gold: 25) }, Condition.DownedQueenSlime, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.DestroyerBossBag) { shopCustomPrice = Item.buyPrice(gold: 25) }, Condition.DownedDestroyer, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.TwinsBossBag) { shopCustomPrice = Item.buyPrice(gold: 25) }, Condition.DownedTwins, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.SkeletronPrimeBossBag) { shopCustomPrice = Item.buyPrice(gold: 25) }, Condition.DownedSkeletronPrime, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.PlanteraBossBag) { shopCustomPrice = Item.buyPrice(gold: 25) }, Condition.DownedPlantera, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.GolemBossBag) { shopCustomPrice = Item.buyPrice(gold: 25) }, Condition.DownedGolem, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.BossBagBetsy) { shopCustomPrice = Item.buyPrice(gold: 25) }, Condition.DownedOldOnesArmyT3, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.FishronBossBag) { shopCustomPrice = Item.buyPrice(gold: 25) }, Condition.DownedDukeFishron, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.FairyQueenBossBag) { shopCustomPrice = Item.buyPrice(gold: 25) }, Condition.DownedEmpressOfLight, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.MoonLordBossBag) { shopCustomPrice = Item.buyPrice(gold: 25) }, Condition.DownedMoonLord, ModConditions.expertOrMaster)
                    .Add(new Item(ItemID.DefenderMedal) { shopCustomPrice = Item.buyPrice(gold: 1) }, Condition.DownedOldOnesArmyAny);
            bossShop.Register();

            var crateShop = new NPCShop(Type, "Crates & Grab Bags")
                    .Add(new Item(ItemID.WoodenCrate) { shopCustomPrice = Item.buyPrice(gold: 5) }, ModConditions.HasBeenToOcean)
                    .Add(new Item(ItemID.IronCrate) { shopCustomPrice = Item.buyPrice(gold: 5) }, ModConditions.HasBeenToOcean)
                    .Add(new Item(ItemID.GoldenCrate) { shopCustomPrice = Item.buyPrice(gold: 5) }, ModConditions.HasBeenToOcean)
                    .Add(new Item(ItemID.JungleFishingCrate) { shopCustomPrice = Item.buyPrice(gold: 5) }, ModConditions.HasBeenToJungle)
                    .Add(new Item(ItemID.FloatingIslandFishingCrate) { shopCustomPrice = Item.buyPrice(gold: 5) }, ModConditions.HasBeenToSky)
                    .Add(new Item(ItemID.CorruptFishingCrate) { shopCustomPrice = Item.buyPrice(gold: 5) }, ModConditions.HasBeenToEvil)
                    .Add(new Item(ItemID.CrimsonFishingCrate) { shopCustomPrice = Item.buyPrice(gold: 5) }, ModConditions.HasBeenToEvil)
                    .Add(new Item(ItemID.HallowedFishingCrate) { shopCustomPrice = Item.buyPrice(gold: 5) }, ModConditions.HasBeenToHallow)
                    .Add(new Item(ItemID.DungeonFishingCrate) { shopCustomPrice = Item.buyPrice(gold: 5) }, Condition.DownedSkeletron, ModConditions.HasBeenToDungeon)
                    .Add(new Item(ItemID.FrozenCrate) { shopCustomPrice = Item.buyPrice(gold: 5) }, ModConditions.HasBeenToSnow)
                    .Add(new Item(ItemID.OasisCrate) { shopCustomPrice = Item.buyPrice(gold: 5) }, ModConditions.HasBeenToDesert)
                    .Add(new Item(ItemID.LavaCrate) { shopCustomPrice = Item.buyPrice(gold: 5) }, ModConditions.HasBeenToUnderworld)
                    .Add(new Item(ItemID.OceanCrate) { shopCustomPrice = Item.buyPrice(gold: 5) }, ModConditions.HasBeenToOcean)
                    .Add(new Item(ItemID.WoodenCrateHard) { shopCustomPrice = Item.buyPrice(gold: 5) }, Condition.Hardmode, ModConditions.HasBeenToOcean)
                    .Add(new Item(ItemID.IronCrateHard) { shopCustomPrice = Item.buyPrice(gold: 5) }, Condition.Hardmode, ModConditions.HasBeenToOcean)
                    .Add(new Item(ItemID.GoldenCrateHard) { shopCustomPrice = Item.buyPrice(gold: 5) }, Condition.Hardmode, ModConditions.HasBeenToOcean)
                    .Add(new Item(ItemID.JungleFishingCrateHard) { shopCustomPrice = Item.buyPrice(gold: 5) }, Condition.Hardmode, ModConditions.HasBeenToJungle)
                    .Add(new Item(ItemID.FloatingIslandFishingCrateHard) { shopCustomPrice = Item.buyPrice(gold: 5) }, Condition.Hardmode, ModConditions.HasBeenToSky)
                    .Add(new Item(ItemID.CorruptFishingCrateHard) { shopCustomPrice = Item.buyPrice(gold: 5) }, Condition.Hardmode, ModConditions.HasBeenToEvil)
                    .Add(new Item(ItemID.CrimsonFishingCrateHard) { shopCustomPrice = Item.buyPrice(gold: 5) }, Condition.Hardmode, ModConditions.HasBeenToEvil)
                    .Add(new Item(ItemID.HallowedFishingCrateHard) { shopCustomPrice = Item.buyPrice(gold: 5) }, Condition.Hardmode, ModConditions.HasBeenToHallow)
                    .Add(new Item(ItemID.DungeonFishingCrateHard) { shopCustomPrice = Item.buyPrice(gold: 5) }, Condition.Hardmode, Condition.DownedSkeletron, ModConditions.HasBeenToDungeon)
                    .Add(new Item(ItemID.FrozenCrateHard) { shopCustomPrice = Item.buyPrice(gold: 5) }, Condition.Hardmode, ModConditions.HasBeenToSnow)
                    .Add(new Item(ItemID.OasisCrateHard) { shopCustomPrice = Item.buyPrice(gold: 5) }, Condition.Hardmode, ModConditions.HasBeenToDesert)
                    .Add(new Item(ItemID.LavaCrateHard) { shopCustomPrice = Item.buyPrice(gold: 5) }, Condition.Hardmode, ModConditions.HasBeenToUnderworld)
                    .Add(new Item(ItemID.OceanCrateHard) { shopCustomPrice = Item.buyPrice(gold: 5) }, Condition.Hardmode, ModConditions.HasBeenToOcean)
                    .Add(new Item(ItemID.GoodieBag) { shopCustomPrice = Item.buyPrice(gold: 5) })
                    .Add(new Item(ItemID.Present) { shopCustomPrice = Item.buyPrice(gold: 5) });
            crateShop.Register();

            var oreShop = new NPCShop(Type, "Ores & Bars")
                    .Add(new Item(ItemID.CopperOre) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.TinOre) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.IronOre) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.LeadOre) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.SilverOre) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.TungstenOre) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.GoldOre) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.PlatinumOre) { shopCustomPrice = Item.buyPrice(silver: 25) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.Meteorite) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedEowOrBoc)
                    .Add(new Item(ItemID.DemoniteOre) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedEowOrBoc, ModConditions.HasBeenToEvil)
                    .Add(new Item(ItemID.CrimtaneOre) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedEowOrBoc, ModConditions.HasBeenToEvil)
                    .Add(new Item(ItemID.Hellstone) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedEowOrBoc, ModConditions.HasBeenToUnderworld)
                    .Add(new Item(ItemID.CobaltOre) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.PalladiumOre) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.MythrilOre) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.OrichalcumOre) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.AdamantiteOre) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.TitaniumOre) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.ChlorophyteOre) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedMechBossAll, ModConditions.HasBeenToJungle)
                    .Add(new Item(ItemID.LunarOre) { shopCustomPrice = Item.buyPrice(silver: 25) }, Condition.DownedMoonLord)

                    .Add(new Item(ItemID.CopperBar) { shopCustomPrice = Item.buyPrice(silver: 50) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.TinBar) { shopCustomPrice = Item.buyPrice(silver: 50) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.IronBar) { shopCustomPrice = Item.buyPrice(silver: 50) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.LeadBar) { shopCustomPrice = Item.buyPrice(silver: 50) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.SilverBar) { shopCustomPrice = Item.buyPrice(silver: 50) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.TungstenBar) { shopCustomPrice = Item.buyPrice(silver: 50) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.GoldBar) { shopCustomPrice = Item.buyPrice(silver: 50) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.PlatinumBar) { shopCustomPrice = Item.buyPrice(silver: 50) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.MeteoriteBar) { shopCustomPrice = Item.buyPrice(silver: 50) }, Condition.DownedEowOrBoc)
                    .Add(new Item(ItemID.DemoniteBar) { shopCustomPrice = Item.buyPrice(silver: 50) }, Condition.DownedEowOrBoc, ModConditions.HasBeenToEvil)
                    .Add(new Item(ItemID.CrimtaneBar) { shopCustomPrice = Item.buyPrice(silver: 50) }, Condition.DownedEowOrBoc, ModConditions.HasBeenToEvil)
                    .Add(new Item(ItemID.HellstoneBar) { shopCustomPrice = Item.buyPrice(silver: 50) }, Condition.DownedEowOrBoc, ModConditions.HasBeenToUnderworld)
                    .Add(new Item(ItemID.CobaltBar) { shopCustomPrice = Item.buyPrice(silver: 50) }, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.PalladiumBar) { shopCustomPrice = Item.buyPrice(silver: 50) }, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.MythrilBar) { shopCustomPrice = Item.buyPrice(silver: 50) }, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.OrichalcumBar) { shopCustomPrice = Item.buyPrice(silver: 50) }, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.AdamantiteBar) { shopCustomPrice = Item.buyPrice(silver: 50) }, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.TitaniumBar) { shopCustomPrice = Item.buyPrice(silver: 50) }, Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.HallowedBar) { shopCustomPrice = Item.buyPrice(silver: 50) }, Condition.DownedMechBossAny)
                    .Add(new Item(ItemID.ChlorophyteBar) { shopCustomPrice = Item.buyPrice(silver: 50) }, Condition.DownedMechBossAll, ModConditions.HasBeenToJungle)
                    .Add(new Item(ItemID.SpectreBar) { shopCustomPrice = Item.buyPrice(silver: 50) }, Condition.DownedPlantera, ModConditions.HasBeenToDungeon)
                    .Add(new Item(ItemID.ShroomiteBar) { shopCustomPrice = Item.buyPrice(silver: 50) }, Condition.DownedPlantera, ModConditions.HasBeenToMushroom)
                    .Add(new Item(ItemID.LunarBar) { shopCustomPrice = Item.buyPrice(silver: 50) }, Condition.DownedMoonLord)
                    .Add(new Item(ItemID.CrystalShard) { shopCustomPrice = Item.buyPrice(silver: 50) }, Condition.Hardmode, ModConditions.HasBeenToHallow)
                    .Add(new Item(ItemID.Amber) { shopCustomPrice = Item.buyPrice(silver: 50) }, ModConditions.HasBeenToDesert)
                    .Add(new Item(ItemID.Amethyst) { shopCustomPrice = Item.buyPrice(silver: 50) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.Diamond) { shopCustomPrice = Item.buyPrice(silver: 50) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.Emerald) { shopCustomPrice = Item.buyPrice(silver: 50) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.Ruby) { shopCustomPrice = Item.buyPrice(silver: 50) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.Sapphire) { shopCustomPrice = Item.buyPrice(silver: 50) }, ModConditions.HasBeenToCavernsOrUnderground)
                    .Add(new Item(ItemID.Topaz) { shopCustomPrice = Item.buyPrice(silver: 50) }, ModConditions.HasBeenToCavernsOrUnderground);
            oreShop.Register();

            var naturalBlockShop = new NPCShop(Type, "Natural Blocks")
                    .Add(new Item(ItemID.Wood) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.BorealWood) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.PalmWood) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.RichMahogany) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.Ebonwood) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.Shadewood) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.AshWood) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.Pearlwood) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.Hardmode)
                    .Add(new Item(ItemID.SpookyWood) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedMourningWood)
                    .Add(new Item(ItemID.DynastyWood) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.BambooBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.LargeBambooBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.Cactus) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.Pumpkin) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.PineTreeBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.DirtBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.ClayBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.MudBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.AshBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.SiltBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.SlushBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.SnowBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.SandBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.EbonsandBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.CrimsandBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.PearlsandBlock) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.Hardmode)
                    .Add(new Item(ItemID.StoneBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.EbonstoneBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.CrimstoneBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.PearlstoneBlock) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.Hardmode)
                    .Add(new Item(ItemID.IceBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.PurpleIceBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.RedIceBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.PinkIceBlock) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.Hardmode)
                    .Add(new Item(ItemID.Granite) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.Marble) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.Obsidian) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.ShimmerBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.HardenedSand) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.CorruptHardenedSand) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.CrimsonHardenedSand) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.HallowHardenedSand) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.Hardmode)
                    .Add(new Item(ItemID.Sandstone) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.CorruptSandstone) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.CrimsonSandstone) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.HallowSandstone) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.Hardmode)
                    .Add(new Item(ItemID.DesertFossil) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.ShellPileBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.Cloud) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.RainCloud) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.Hive) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.HoneyBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.CrispyHoneyBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.Hay) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.Cobweb) { shopCustomPrice = Item.buyPrice(copper: 10) });
            naturalBlockShop.Register();

            var buildingBlockShop = new NPCShop(Type, "Building Blocks")
                    .Add(new Item(ItemID.GrayBrick) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.StoneSlab) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.AccentSlab) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.RedBrick) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.SandstoneBrick) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.SnowBrick) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.IceBrick) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.MudstoneBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.IridescentBrick) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.ObsidianBrick) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.EbonstoneBrick) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.CrimstoneBrick) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.PearlstoneBrick) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.Hardmode)
                    .Add(new Item(ItemID.RainbowBrick) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.Hardmode)
                    .Add(new Item(ItemID.CopperBrick) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.TinBrick) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.IronBrick) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.LeadBrick) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.SilverBrick) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.TungstenBrick) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.GoldBrick) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.PlatinumBrick) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.DemoniteBrick) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedEyeOfCthulhu)
                    .Add(new Item(ItemID.CrimtaneBrick) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedEyeOfCthulhu)
                    .Add(new Item(ItemID.MeteoriteBrick) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedEowOrBoc)
                    .Add(new Item(ItemID.HellstoneBrick) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedEowOrBoc)
                    .Add(new Item(ItemID.CobaltBrick) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.Hardmode)
                    .Add(new Item(ItemID.PalladiumColumn) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.Hardmode)
                    .Add(new Item(ItemID.MythrilBrick) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.Hardmode)
                    .Add(new Item(ItemID.BubblegumBlock) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.Hardmode)
                    .Add(new Item(ItemID.AdamantiteBeam) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.Hardmode)
                    .Add(new Item(ItemID.TitanstoneBlock) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.Hardmode)
                    .Add(new Item(ItemID.ChlorophyteBrick) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedMechBossAll)
                    .Add(new Item(ItemID.ShroomitePlating) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedPlantera)
                    .Add(new Item(ItemID.LunarBrick) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedMoonLord)
                    .Add(new Item(ItemID.ShimmerBrick) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.LavaMossBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.KryptonMossBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.XenonMossBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.ArgonMossBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.VioletMossBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.RainbowMossBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.BlueBrick) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedSkeletron)
                    .Add(new Item(ItemID.GreenBrick) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedSkeletron)
                    .Add(new Item(ItemID.PinkBrick) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedSkeletron)
                    .Add(new Item(ItemID.LihzahrdBrick) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedGolem)
                    .Add(new Item(ItemID.NebulaBrick) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedNebulaPillar)
                    .Add(new Item(ItemID.SolarBrick) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedSolarPillar)
                    .Add(new Item(ItemID.StardustBrick) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedStardustPillar)
                    .Add(new Item(ItemID.VortexBrick) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedVortexPillar)
                    .Add(new Item(ItemID.GrayStucco) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.GreenStucco) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.RedStucco) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.YellowStucco) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.GraniteBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.MarbleBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.SunplateBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.MartianConduitPlating) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedMartians)
                    .Add(new Item(ItemID.Glass) { shopCustomPrice = Item.buyPrice(copper: 10) }, ModConditions.HasBeenToDesert)
                    .Add(new Item(ItemID.AmberGemsparkBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.AmethystGemsparkBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.DiamondGemsparkBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.EmeraldGemsparkBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.RubyGemsparkBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.SapphireGemsparkBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.TopazGemsparkBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.TeamBlockRed) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.TeamBlockGreen) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.TeamBlockBlue) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.TeamBlockYellow) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.TeamBlockPink) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.TeamBlockWhite) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.LunarBlockNebula) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedNebulaPillar)
                    .Add(new Item(ItemID.LunarBlockSolar) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedSolarPillar)
                    .Add(new Item(ItemID.LunarBlockStardust) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedStardustPillar)
                    .Add(new Item(ItemID.LunarBlockVortex) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedVortexPillar)
                    .Add(new Item(ItemID.RedDynastyShingles) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.BlueDynastyShingles) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.CandyCaneBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.GreenCandyCaneBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.AsphaltBlock) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedMechBossAny)
                    .Add(new Item(ItemID.CoralstoneBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.FleshBlock) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.Hardmode)
                    .Add(new Item(ItemID.LesionBlock) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.Hardmode)
                    .Add(new Item(ItemID.SpiderBlock) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.Hardmode)
                    .Add(new Item(ItemID.SlimeBlock) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedKingSlime)
                    .Add(new Item(ItemID.PinkSlimeBlock) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedKingSlime);
            buildingBlockShop.Register();

            var plantShop = new NPCShop(Type, "Herbs & Plants")
                    .Add(new Item(ItemID.HerbBag) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.Blinkroot) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.Daybloom) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.DaybloomSeeds) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.Deathweed) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.DeathweedSeeds) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.Fireblossom) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.FireblossomSeeds) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.Moonglow) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.MoonglowSeeds) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.Shiverthorn) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.ShiverthornSeeds) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.Waterleaf) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.WaterleafSeeds) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.PumpkinSeed) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedEyeOfCthulhu)
                    .Add(new Item(ItemID.TealMushroom) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.GreenMushroom) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.SkyBlueFlower) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.YellowMarigold) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.BlueBerries) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.LimeKelp) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.PinkPricklyPear) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.OrangeBloodroot) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.VileMushroom) { shopCustomPrice = Item.buyPrice(copper: 10) }, ModConditions.HasBeenToEvil)
                    .Add(new Item(ItemID.ViciousMushroom) { shopCustomPrice = Item.buyPrice(copper: 10) }, ModConditions.HasBeenToEvil)
                    .Add(new Item(ItemID.Mushroom) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.GlowingMushroom) { shopCustomPrice = Item.buyPrice(copper: 10) }, ModConditions.HasBeenToMushroom)
                    .Add(new Item(ItemID.GrassSeeds) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedEyeOfCthulhu)
                    .Add(new Item(ItemID.JungleGrassSeeds) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.MushroomGrassSeeds) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.CorruptSeeds) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedEyeOfCthulhu)
                    .Add(new Item(ItemID.CrimsonSeeds) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedEyeOfCthulhu)
                    .Add(new Item(ItemID.AshGrassSeeds) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.HallowedSeeds) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.Hardmode)
                    .Add(new Item(ItemID.Coral) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.Starfish) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.Seashell) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.JunoniaShell) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.LightningWhelkShell) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.TulipShell) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.Acorn) { shopCustomPrice = Item.buyPrice(copper: 10) })
                    .Add(new Item(ItemID.Fertilizer) { shopCustomPrice = Item.buyPrice(copper: 10) }, Condition.DownedSkeletron);
            plantShop.Register();

            var fishShop = new NPCShop(Type, "Fish & Fishing Gear")
                   .Add(new Item(ItemID.AnglerTackleBag) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.NotDownedEowOrBoc, ModConditions.HasBeenToOcean)
                   .Add(new Item(ItemID.LavaproofTackleBag) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedEowOrBoc, ModConditions.HasBeenToOcean)
                   .Add(new Item(ItemID.FishingBobber) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToOcean)
                   .Add(new Item(ItemID.AnglerHat) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToOcean)
                   .Add(new Item(ItemID.AnglerVest) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToOcean)
                   .Add(new Item(ItemID.AnglerPants) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToOcean)
                   .Add(new Item(ItemID.GoldenFishingRod) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToOcean)
                   .Add(new Item(ItemID.GoldenBugNet) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToOcean)
                   .Add(new Item(ItemID.ChumBucket) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToOcean)
                   .Add(new Item(ItemID.ArmoredCavefish) { shopCustomPrice = Item.buyPrice(silver: 10) }, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(new Item(ItemID.AtlanticCod) { shopCustomPrice = Item.buyPrice(silver: 10) }, ModConditions.HasBeenToSnow)
                   .Add(new Item(ItemID.Bass) { shopCustomPrice = Item.buyPrice(silver: 10) })
                   .Add(new Item(ItemID.ChaosFish) { shopCustomPrice = Item.buyPrice(silver: 10) }, Condition.Hardmode, ModConditions.HasBeenToHallow)
                   .Add(new Item(ItemID.CrimsonTigerfish) { shopCustomPrice = Item.buyPrice(silver: 10) }, ModConditions.HasBeenToEvil)
                   .Add(new Item(ItemID.Damselfish) { shopCustomPrice = Item.buyPrice(silver: 10) }, ModConditions.HasBeenToSky)
                   .Add(new Item(ItemID.DoubleCod) { shopCustomPrice = Item.buyPrice(silver: 10) }, ModConditions.HasBeenToJungle)
                   .Add(new Item(ItemID.Ebonkoi) { shopCustomPrice = Item.buyPrice(silver: 10) }, ModConditions.HasBeenToEvil)
                   .Add(new Item(ItemID.FlarefinKoi) { shopCustomPrice = Item.buyPrice(silver: 10) }, Condition.DownedEowOrBoc, ModConditions.HasBeenToUnderworld)
                   .Add(new Item(ItemID.Flounder) { shopCustomPrice = Item.buyPrice(silver: 10) }, ModConditions.HasBeenToDesert)
                   .Add(new Item(ItemID.FrostMinnow) { shopCustomPrice = Item.buyPrice(silver: 10) }, ModConditions.HasBeenToSnow)
                   .Add(new Item(ItemID.GoldenCarp) { shopCustomPrice = Item.buyPrice(silver: 10) }, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(new Item(ItemID.Hemopiranha) { shopCustomPrice = Item.buyPrice(silver: 10) }, ModConditions.HasBeenToEvil)
                   .Add(new Item(ItemID.Honeyfin) { shopCustomPrice = Item.buyPrice(silver: 10) }, ModConditions.HasBeenToJungle)
                   .Add(new Item(ItemID.NeonTetra) { shopCustomPrice = Item.buyPrice(silver: 10) }, ModConditions.HasBeenToJungle)
                   .Add(new Item(ItemID.Obsidifish) { shopCustomPrice = Item.buyPrice(silver: 10) }, Condition.DownedEowOrBoc, ModConditions.HasBeenToUnderworld)
                   .Add(new Item(ItemID.PrincessFish) { shopCustomPrice = Item.buyPrice(silver: 10) }, Condition.Hardmode, ModConditions.HasBeenToHallow)
                   .Add(new Item(ItemID.Prismite) { shopCustomPrice = Item.buyPrice(silver: 10) }, Condition.Hardmode, ModConditions.HasBeenToHallow)
                   .Add(new Item(ItemID.RedSnapper) { shopCustomPrice = Item.buyPrice(silver: 10) }, ModConditions.HasBeenToOcean)
                   .Add(new Item(ItemID.RockLobster) { shopCustomPrice = Item.buyPrice(silver: 10) }, ModConditions.HasBeenToDesert)
                   .Add(new Item(ItemID.Salmon) { shopCustomPrice = Item.buyPrice(silver: 10) })
                   .Add(new Item(ItemID.Shrimp) { shopCustomPrice = Item.buyPrice(silver: 10) }, ModConditions.HasBeenToOcean)
                   .Add(new Item(ItemID.SpecularFish) { shopCustomPrice = Item.buyPrice(silver: 10) }, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(new Item(ItemID.Stinkfish) { shopCustomPrice = Item.buyPrice(silver: 10) }, ModConditions.HasBeenToCavernsOrUnderground)
                   .Add(new Item(ItemID.Trout) { shopCustomPrice = Item.buyPrice(silver: 10) })
                   .Add(new Item(ItemID.Tuna) { shopCustomPrice = Item.buyPrice(silver: 10) })
                   .Add(new Item(ItemID.VariegatedLardfish) { shopCustomPrice = Item.buyPrice(silver: 10) }, ModConditions.HasBeenToJungle)
                   .Add(new Item(ItemID.ApprenticeBait) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToOcean)
                   .Add(new Item(ItemID.JourneymanBait) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToOcean)
                   .Add(new Item(ItemID.MasterBait) { shopCustomPrice = Item.buyPrice(gold: 2) }, ModConditions.HasBeenToOcean)
                   .Add(new Item(ItemID.BlackDragonfly) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.BlackScorpion) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.BlueDragonfly) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.BlueJellyfish) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.Buggy) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.EnchantedNightcrawler) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.Firefly) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.GlowingSnail) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.GoldButterfly) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.GoldDragonfly) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.GoldGrasshopper) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.GoldLadyBug) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.GoldWaterStrider) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.GoldWorm) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.Grasshopper) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.GreenDragonfly) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.GreenJellyfish) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.Grubby) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.HellButterfly) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedEowOrBoc)
                   .Add(new Item(ItemID.JuliaButterfly) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.LadyBug) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.Lavafly) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedEowOrBoc)
                   .Add(new Item(ItemID.LightningBug) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.Hardmode)
                   .Add(new Item(ItemID.Maggot) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.MagmaSnail) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedEowOrBoc)
                   .Add(new Item(ItemID.MonarchButterfly) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.OrangeDragonfly) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.PinkJellyfish) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.PurpleEmperorButterfly) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.RedAdmiralButterfly) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.RedDragonfly) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.Scorpion) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.Sluggy) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.Snail) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.Stinkbug) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.SulphurButterfly) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.TreeNymphButterfly) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.TruffleWorm) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.Hardmode)
                   .Add(new Item(ItemID.UlyssesButterfly) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.WaterStrider) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.Worm) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.YellowDragonfly) { shopCustomPrice = Item.buyPrice(gold: 2) })
                   .Add(new Item(ItemID.ZebraSwallowtailButterfly) { shopCustomPrice = Item.buyPrice(gold: 2) });
            fishShop.Register();
        }
    }
}
