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
    public class EtherealCollectorNPC : ModNPC
    {
        #pragma warning disable CA2211
        public static int shopNum = 0;
        public static string ShopName;
        #pragma warning restore CA2211

        public override string Texture
        {
            get
            {
                return "QoLCompendium/NPCs/EtherealCollectorNPC";
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
            NPC.Happiness.SetBiomeAffection<SnowBiome>((AffectionLevel)100).SetBiomeAffection<OceanBiome>((AffectionLevel)50).SetBiomeAffection<DesertBiome>((AffectionLevel)(-50)).SetNPCAffection(19, (AffectionLevel)100).SetNPCAffection(17, (AffectionLevel)50).SetNPCAffection(108, (AffectionLevel)(-50)).SetNPCAffection(441, (AffectionLevel)(100));
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("He arrived to sell his wares, but where did he come from?")
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
            NPC.alpha = Item.buyPrice(silver: 1);
            NPC.HitSound = new SoundStyle?(SoundID.NPCHit1);
            NPC.DeathSound = new SoundStyle?(SoundID.NPCDeath1);
            NPC.knockBackResist = 0.5f;
            AnimationType = 22;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            if (ModContent.GetInstance<QoLCConfig>().ECNPC)
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
                "Spiri",
                "Lumen",
                "Dexter",
                "Geist",
                "Sullivan"
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
                damage = Item.buyPrice(silver: 1);
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
            projType = 118;
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
                0 => "I won't tell you where I'm from",
                1 => "The more you progress, the more I materialize for you",
                2 => "Why don't you try to farm your gear sometimes?",
                _ => "If one of the townsfolk dies, I'll gladly sell their items!",
            };
            return result;
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            if (shopNum == 0)
            {
                button = "Modded Potions";
                ShopName = "Modded Potions";
            }
            else if (shopNum == 1)
            {
                button = "Modded Flasks, Stations & Foods";
                ShopName = "Modded Flasks, Stations & Foods";
            }
            else if (shopNum == 2)
            {
                button = "Modded Materials";
                ShopName = "Modded Materials";
            }
            else if (shopNum == 3)
            {
                button = "Modded Treasure Bags";
                ShopName = "Modded Treasure Bags";
            }
            else if (shopNum == 4)
            {
                button = "Modded Crates & Grab Bags";
                ShopName = "Modded Crates & Grab Bags";
            }
            else if (shopNum == 5)
            {
                button = "Modded Ores & Bars";
                ShopName = "Modded Ores & Bars";
            }
            else if (shopNum == 6)
            {
                button = "Modded Natural Blocks";
                ShopName = "Modded Natural Blocks";
            }
            else if (shopNum == 7)
            {
                button = "Modded Building Blocks";
                ShopName = "Modded Building Blocks";
            }
            else if (shopNum == 8)
            {
                button = "Modded Herbs & Plants";
                ShopName = "Modded Herbs & Plants";
            }
            button2 = "Shop Changer";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = ShopName;
                ECNPCUI.visible = false;
            }
            else
            {
                if (!ECNPCUI.visible) ECNPCUI.timeStart = Main.GameUpdateCount;
                ECNPCUI.visible = true;
            }
        }

        public override void AddShops()
        {
            var modPotionsShop = new NPCShop(Type, "Modded Potions")
            //Aequus
                .AddModItemToShop(CheckDowned.aqMod, "BloodthirstPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.aqMod, "FrostPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.aqMod, "ManathirstPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.aqMod, "MercerTonic", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.aqMod, "NecromancyPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.aqMod, "NeutronYogurt", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.aqMod, "NoonPotion", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.aqMod, "SentryPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.aqMod, "VeinminerPotion", Item.buyPrice(gold: 1))
            //Calamity
                .AddModItemToShop(CheckDowned.calamityMod, "AnechoicCoating", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "AstralInjection", Item.buyPrice(gold: 1), CheckDowned.aureus)
                .AddModItemToShop(CheckDowned.calamityMod, "AureusCell", Item.buyPrice(gold: 1), CheckDowned.aureus)
                .AddModItemToShop(CheckDowned.calamityMod, "BoundingPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "CalciumPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "GravityNormalizerPotion", Item.buyPrice(gold: 1), CheckDowned.aureus)
                .AddModItemToShop(CheckDowned.calamityMod, "PhotosynthesisPotion", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "PotionofOmniscience", Item.buyPrice(gold: 1), Condition.DownedSkeletron)
                .AddModItemToShop(CheckDowned.calamityMod, "ShadowPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "SoaringPotion", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "SulphurskinPotion", Item.buyPrice(gold: 1), CheckDowned.acidRain1)
                .AddModItemToShop(CheckDowned.calamityMod, "TeslaPotion", Item.buyPrice(gold: 1), CheckDowned.perfOrHive)
                .AddModItemToShop(CheckDowned.calamityMod, "ZenPotion", Item.buyPrice(gold: 1), CheckDowned.slimegod)
                .AddModItemToShop(CheckDowned.calamityMod, "ZergPotion", Item.buyPrice(gold: 1), CheckDowned.slimegod)
            //Catalyst
                .AddModItemToShop(CheckDowned.catalystMod, "AstraJelly", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.catalystMod, "Lean", Item.buyPrice(gold: 1), CheckDowned.aureus)
            //Consolaria
                .AddModItemToShop(CheckDowned.consolariaMod, "Wiesnbrau", Item.buyPrice(gold: 1))
            //Fargos
                .AddModItemToShop(CheckDowned.fargosSoulsMod, "RabiesShot", Item.buyPrice(gold: 1), CheckDowned.abom)
            //Homeward
                .AddModItemToShop(CheckDowned.homewardMod, "FlightPotion", Item.buyPrice(gold: 1), CheckDowned.materealizer)
                .AddModItemToShop(CheckDowned.homewardMod, "HastePotion", Item.buyPrice(gold: 1), CheckDowned.materealizer)
                .AddModItemToShop(CheckDowned.homewardMod, "ReanimationPotion", Item.buyPrice(gold: 1), CheckDowned.materealizer)
                .AddModItemToShop(CheckDowned.homewardMod, "YangPotion", Item.buyPrice(gold: 1), CheckDowned.wos)
                .AddModItemToShop(CheckDowned.homewardMod, "YinPotion", Item.buyPrice(gold: 1), CheckDowned.wos)
            //Polarities
                .AddModItemToShop(CheckDowned.polaritiesMod, "PiercingPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.polaritiesMod, "TolerancePotion", Item.buyPrice(gold: 1))
            //Redemption
                .AddModItemToShop(CheckDowned.redemptionMod, "CharismaPotion", Item.buyPrice(gold: 1), CheckDowned.thorn)
                .AddModItemToShop(CheckDowned.redemptionMod, "VendettaPotion", Item.buyPrice(gold: 1), CheckDowned.thorn)
                .AddModItemToShop(CheckDowned.redemptionMod, "VigourousPotion", Item.buyPrice(gold: 1), CheckDowned.nebby)
            //SOTS
                .AddModItemToShop(CheckDowned.sotsMod, "AbyssalTonic", Item.buyPrice(gold: 1), CheckDowned.tidalSpirit)
                .AddModItemToShop(CheckDowned.sotsMod, "AssassinationPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "BlazingTonic", Item.buyPrice(gold: 1), CheckDowned.infernoSpirit)
                .AddModItemToShop(CheckDowned.sotsMod, "BlightfulTonic", Item.buyPrice(gold: 1), CheckDowned.natureSpirit)
                .AddModItemToShop(CheckDowned.sotsMod, "BluefirePotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "BrittlePotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "DoubleVisionPotion", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(CheckDowned.sotsMod, "EtherealTonic", Item.buyPrice(gold: 1), CheckDowned.lux)
                .AddModItemToShop(CheckDowned.sotsMod, "GlacialTonic", Item.buyPrice(gold: 1), CheckDowned.permafrostSpirit)
                .AddModItemToShop(CheckDowned.sotsMod, "HarmonyPotion", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.sotsMod, "HereticTonic", Item.buyPrice(gold: 1), CheckDowned.evilSpirit)
                .AddModItemToShop(CheckDowned.sotsMod, "NightmarePotion", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.sotsMod, "RipplePotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "RoughskinPotion", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(CheckDowned.sotsMod, "SeismicTonic", Item.buyPrice(gold: 1), CheckDowned.earthenSpirit)
                .AddModItemToShop(CheckDowned.sotsMod, "SoulAccessPotion", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(CheckDowned.sotsMod, "StarlightTonic", Item.buyPrice(gold: 1), CheckDowned.advisor)
                .AddModItemToShop(CheckDowned.sotsMod, "VibePotion", Item.buyPrice(gold: 1))
            //Spirit
                .AddModItemToShop(CheckDowned.spiritMod, "PinkPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "MirrorCoat", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(CheckDowned.spiritMod, "RunePotion", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(CheckDowned.spiritMod, "FlightPotion", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.spiritMod, "SoulPotion", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(CheckDowned.spiritMod, "SpiritPotion", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(CheckDowned.spiritMod, "MushroomPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "StarPotion", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(CheckDowned.spiritMod, "TurtlePotion", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(CheckDowned.spiritMod, "BismitePotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "DoubleJumpPotion", Item.buyPrice(gold: 1))
            //Storms
                .AddModItemToShop(CheckDowned.stormMod, "BeetlePotion", Item.buyPrice(gold: 1), Condition.DownedGolem)
                .AddModItemToShop(CheckDowned.stormMod, "FruitHeartPotion", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(CheckDowned.stormMod, "GunPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.stormMod, "HeartPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.stormMod, "ShroomitePotion", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.stormMod, "SpectrePotion", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.stormMod, "SpookyPotion", Item.buyPrice(gold: 1), Condition.DownedPlantera)
            //Thorium
                .AddModItemToShop(CheckDowned.thoriumMod, "AquaPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "ArcanePotion", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.thoriumMod, "ArtilleryPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "AssassinPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "BatRepellent", Item.buyPrice(gold: 1), CheckDowned.bloodMoon)
                .AddModItemToShop(CheckDowned.thoriumMod, "BloodPotion", Item.buyPrice(gold: 1), CheckDowned.bloodMoon)
                .AddModItemToShop(CheckDowned.thoriumMod, "BouncingFlamePotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "CactusFruit", Item.buyPrice(gold: 1), CheckDowned.grandbird)
                .AddModItemToShop(CheckDowned.thoriumMod, "ConflagrationPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "CreativityPotion", Item.buyPrice(gold: 1), CheckDowned.grandbird)
                .AddModItemToShop(CheckDowned.thoriumMod, "EarwormPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "FishRepellent", Item.buyPrice(gold: 1), CheckDowned.bloodMoon)
                .AddModItemToShop(CheckDowned.thoriumMod, "FrenzyPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "GlowingPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "HolyPotion", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.thoriumMod, "HydrationPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "InsectRepellent", Item.buyPrice(gold: 1), CheckDowned.bloodMoon)
                .AddModItemToShop(CheckDowned.thoriumMod, "InspirationReachPotion", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.thoriumMod, "KineticPotion", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.thoriumMod, "SkeletonRepellent", Item.buyPrice(gold: 1), CheckDowned.bloodMoon)
                .AddModItemToShop(CheckDowned.thoriumMod, "WarmongerPotion", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(CheckDowned.thoriumMod, "ZombieRepellent", Item.buyPrice(gold: 1), CheckDowned.bloodMoon)
            //Vitality
                .AddModItemToShop(CheckDowned.vitalityMod, "ArmorPiercingPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.vitalityMod, "LeapingPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.vitalityMod, "TranquillityPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.vitalityMod, "TravelsensePotion", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.vitalityMod, "WarriorPotion", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc);
            modPotionsShop.Register();

            var modFlasksShop = new NPCShop(Type, "Modded Flasks, Stations & Foods")
            //Calamity
                .AddModItemToShop(CheckDowned.calamityMod, "Baguette", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "HadalStew", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "FlaskOfBrimstone", Item.buyPrice(gold: 1), CheckDowned.calamitas)
                .AddModItemToShop(CheckDowned.calamityMod, "FlaskOfCrumbling", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "FlaskOfHolyFlames", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(CheckDowned.calamityMod, "CorruptionEffigy", Item.buyPrice(platinum: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "CrimsonEffigy", Item.buyPrice(platinum: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "EffigyOfDecay", Item.buyPrice(platinum: 1), CheckDowned.acidRain1)
                .AddModItemToShop(CheckDowned.calamityMod, "TranquilityCandle", Item.buyPrice(platinum: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.calamityMod, "ChaosCandle", Item.buyPrice(platinum: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.calamityMod, "ResilientCandle", Item.buyPrice(platinum: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "SpitefulCandle", Item.buyPrice(platinum: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "WeightlessCandle", Item.buyPrice(platinum: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "VigorousCandle", Item.buyPrice(platinum: 1), Condition.Hardmode)
            //Fargos
                .AddModItemToShop(CheckDowned.fargosMod, "Omnistation", Item.buyPrice(platinum: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.fargosMod, "Omnistation2", Item.buyPrice(platinum: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.fargosMod, "Semistation", Item.buyPrice(platinum: 1))
            //Redemption
                .AddModItemToShop(CheckDowned.redemptionMod, "EvilJelly", Item.buyPrice(gold: 1), CheckDowned.keeper)
                .AddModItemToShop(CheckDowned.redemptionMod, "BileFlask", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.redemptionMod, "NitroglycerineFlask", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.redemptionMod, "EnergyStation", Item.buyPrice(platinum: 1), Condition.DownedMechBossAll)
            //SOTS
                .AddModItemToShop(CheckDowned.sotsMod, "AlmondMilk", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "AvocadoSoup", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "Chocolate", Item.buyPrice(gold: 1), Condition.DownedPirates)
                .AddModItemToShop(CheckDowned.sotsMod, "CoconutMilk", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "CookedMushroom", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "CursedCaviar", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(CheckDowned.sotsMod, "DigitalCornSyrup", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "FoulConcoction", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "StrawberryIcecream", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "DigitalDisplay", Item.buyPrice(platinum: 1))
            //Spirit
                .AddModItemToShop(CheckDowned.spiritMod, "Candy", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "ChocolateBar", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "HealthCandy", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "Lollipop", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "ManaCandy", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "MysteryCandy", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "Taffy", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "CoilEnergizerItem", Item.buyPrice(platinum: 1), Condition.DownedGoblinArmy)
                .AddModItemToShop(CheckDowned.spiritMod, "SunPot", Item.buyPrice(platinum: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "TheCouch", Item.buyPrice(platinum: 1), Condition.DownedSkeletron)
            //Thorium
                .AddModItemToShop(CheckDowned.thoriumMod, "DeepFreezeCoatingItem", Item.buyPrice(gold: 1), Condition.DownedQueenBee)
                .AddModItemToShop(CheckDowned.thoriumMod, "ExplosiveCoatingItem", Item.buyPrice(gold: 1), Condition.DownedQueenBee)
                .AddModItemToShop(CheckDowned.thoriumMod, "GorgonCoatingItem", Item.buyPrice(gold: 1), Condition.DownedQueenBee)
                .AddModItemToShop(CheckDowned.thoriumMod, "SporeCoatingItem", Item.buyPrice(gold: 1), Condition.DownedQueenBee)
                .AddModItemToShop(CheckDowned.thoriumMod, "ToxicCoatingItem", Item.buyPrice(gold: 1), Condition.DownedQueenBee)
                .AddModItemToShop(CheckDowned.thoriumMod, "Altar", Item.buyPrice(platinum: 1), CheckDowned.buriedchampion)
                .AddModItemToShop(CheckDowned.thoriumMod, "ArenaMastersBrazier", Item.buyPrice(platinum: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.thoriumMod, "ConductorsStand", Item.buyPrice(platinum: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.thoriumMod, "NinjaRack", Item.buyPrice(platinum: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.thoriumMod, "TrueArenaMastersBrazier", Item.buyPrice(platinum: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.thoriumMod, "Mistletoe", Item.buyPrice(platinum: 1));
            modFlasksShop.Register();

            var modMaterialsShop = new NPCShop(Type, "Modded Materials")
            //Aequus
                .AddModItemToShop(CheckDowned.aqMod, "AtmosphericEnergy", Item.buyPrice(gold: 1), CheckDowned.galeStreams)
                .AddModItemToShop(CheckDowned.aqMod, "AquaticEnergy", Item.buyPrice(gold: 1), CheckDowned.crabson)
                .AddModItemToShop(CheckDowned.aqMod, "BloodyTearstone", Item.buyPrice(gold: 1), CheckDowned.bloodMoon)
                .AddModItemToShop(CheckDowned.aqMod, "CosmicEnergy", Item.buyPrice(gold: 1), CheckDowned.glimmer)
                .AddModItemToShop(CheckDowned.aqMod, "DemonicEnergy", Item.buyPrice(gold: 1), CheckDowned.demonSiege)
                .AddModItemToShop(CheckDowned.aqMod, "Fluorescence", Item.buyPrice(gold: 1), CheckDowned.sprite)
                .AddModItemToShop(CheckDowned.aqMod, "FrozenTear", Item.buyPrice(gold: 1), CheckDowned.spacesquid)
                .AddModItemToShop(CheckDowned.aqMod, "Hexoplasm", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.aqMod, "OrganicEnergy", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.aqMod, "UltimateEnergy", Item.buyPrice(gold: 1), Condition.DownedPlantera)
            //Calamity
                .AddModItemToShop(CheckDowned.calamityMod, "AncientBoneDust", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "ArmoredShell", Item.buyPrice(gold: 1), CheckDowned.stormweaver)
                .AddModItemToShop(CheckDowned.calamityMod, "AshesofAnnihilation", Item.buyPrice(gold: 1), CheckDowned.scalamitas)
                .AddModItemToShop(CheckDowned.calamityMod, "AshesofCalamity", Item.buyPrice(gold: 1), CheckDowned.calamitas)
                .AddModItemToShop(CheckDowned.calamityMod, "BeetleJuice", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "BlightedGel", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "BloodOrb", Item.buyPrice(gold: 1), CheckDowned.bloodMoon)
                .AddModItemToShop(CheckDowned.calamityMod, "BloodSample", Item.buyPrice(gold: 1), CheckDowned.perforators)
                .AddModItemToShop(CheckDowned.calamityMod, "Bloodstone", Item.buyPrice(gold: 1), CheckDowned.providence)
                .AddModItemToShop(CheckDowned.calamityMod, "CorrodedFossil", Item.buyPrice(gold: 1), CheckDowned.acidRain2)
                .AddModItemToShop(CheckDowned.calamityMod, "DarkPlasma", Item.buyPrice(gold: 1), CheckDowned.ceaselessvoid)
                .AddModItemToShop(CheckDowned.calamityMod, "DarksunFragment", Item.buyPrice(gold: 1), CheckDowned.dog)
                .AddModItemToShop(CheckDowned.calamityMod, "DepthCells", Item.buyPrice(gold: 1), CheckDowned.calamitas)
                .AddModItemToShop(CheckDowned.calamityMod, "DemonicBoneAsh", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "DivineGeode", Item.buyPrice(gold: 1), CheckDowned.providence)
                .AddModItemToShop(CheckDowned.calamityMod, "DubiousPlating", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "EffulgentFeather", Item.buyPrice(gold: 1), CheckDowned.dragonfolly)
                .AddModItemToShop(CheckDowned.calamityMod, "EndothermicEnergy", Item.buyPrice(gold: 1), CheckDowned.dog)
                .AddModItemToShop(CheckDowned.calamityMod, "EnergyCore", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "EssenceofChaos", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "EssenceofEleum", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "EssenceofSunlight", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "ExoPrism", Item.buyPrice(gold: 1), CheckDowned.exomechs)
                .AddModItemToShop(CheckDowned.calamityMod, "GrandScale", Item.buyPrice(gold: 1), CheckDowned.sandshark)
                .AddModItemToShop(CheckDowned.calamityMod, "InfectedArmorPlating", Item.buyPrice(gold: 1), CheckDowned.plaguebringer)
                .AddModItemToShop(CheckDowned.calamityMod, "LivingShard", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.calamityMod, "Lumenyl", Item.buyPrice(gold: 1), CheckDowned.calamitas)
                .AddModItemToShop(CheckDowned.calamityMod, "MeldBlob", Item.buyPrice(gold: 1), Condition.DownedCultist)
                .AddModItemToShop(CheckDowned.calamityMod, "MolluskHusk", Item.buyPrice(gold: 1), Condition.Hardmode, CheckDowned.giantclam)
                .AddModItemToShop(CheckDowned.calamityMod, "MurkyPaste", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "MysteriousCircuitry", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "NightmareFuel", Item.buyPrice(gold: 1), CheckDowned.dog)
                .AddModItemToShop(CheckDowned.calamityMod, "PearlShard", Item.buyPrice(gold: 1), CheckDowned.desertscourge)
                .AddModItemToShop(CheckDowned.calamityMod, "Polterplasm", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(CheckDowned.calamityMod, "PlagueCellCanister", Item.buyPrice(gold: 1), Condition.DownedGolem)
                .AddModItemToShop(CheckDowned.calamityMod, "PurifiedGel", Item.buyPrice(gold: 1), CheckDowned.slimegod)
                .AddModItemToShop(CheckDowned.calamityMod, "ReaperTooth", Item.buyPrice(gold: 1), CheckDowned.polterghast)
                .AddModItemToShop(CheckDowned.calamityMod, "RottenMatter", Item.buyPrice(gold: 1), CheckDowned.hivemind)
                .AddModItemToShop(CheckDowned.calamityMod, "RuinousSoul", Item.buyPrice(gold: 1), CheckDowned.polterghast)
                .AddModItemToShop(CheckDowned.calamityMod, "SolarVeil", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.calamityMod, "StormlionMandible", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "Stardust", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "SulphuricScale", Item.buyPrice(gold: 1), CheckDowned.acidRain1)
                .AddModItemToShop(CheckDowned.calamityMod, "TrapperBulb", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "TwistingNether", Item.buyPrice(gold: 1), CheckDowned.signus)
                .AddModItemToShop(CheckDowned.calamityMod, "UnholyEssence", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(CheckDowned.calamityMod, "WulfrumMetalScrap", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "YharonSoulFragment", Item.buyPrice(gold: 1), CheckDowned.yharon)
            //Consolaria
                .AddModItemToShop(CheckDowned.consolariaMod, "RainbowPiece", Item.buyPrice(gold: 1), CheckDowned.yharon)
                .AddModItemToShop(CheckDowned.consolariaMod, "SoulofBlight", Item.buyPrice(gold: 1), CheckDowned.ocram)
                .AddModItemToShop(CheckDowned.consolariaMod, "WhiteThread", Item.buyPrice(gold: 1), CheckDowned.yharon)
            //Echoes
                .AddModItemToShop(CheckDowned.echoesMod, "BetsyScale", Item.buyPrice(gold: 1), Condition.DownedOldOnesArmyT3)
                .AddModItemToShop(CheckDowned.echoesMod, "Broken_Hero_GunParts", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.echoesMod, "CorruptShard", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(CheckDowned.echoesMod, "Cosmic_Essence", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(CheckDowned.echoesMod, "Crimson_Stone", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(CheckDowned.echoesMod, "Divine_Fragment", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(CheckDowned.echoesMod, "Duskbulb", Item.buyPrice(gold: 1), CheckDowned.destruction)
                .AddModItemToShop(CheckDowned.echoesMod, "Enkin", Item.buyPrice(gold: 1), CheckDowned.destruction)
                .AddModItemToShop(CheckDowned.echoesMod, "CosmicFabric", Item.buyPrice(gold: 1), CheckDowned.destruction)
                .AddModItemToShop(CheckDowned.echoesMod, "GenocideCore", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.echoesMod, "Hallow_Stone", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(CheckDowned.echoesMod, "Hell_Stone", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(CheckDowned.echoesMod, "Ice_Stone", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(CheckDowned.echoesMod, "InfinityCrystal", Item.buyPrice(gold: 1), CheckDowned.destruction, CheckDowned.creation)
                .AddModItemToShop(CheckDowned.echoesMod, "InfinityGeode", Item.buyPrice(gold: 1), CheckDowned.creation)
                .AddModItemToShop(CheckDowned.echoesMod, "Jungle_Stone", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(CheckDowned.echoesMod, "LunarSilk", Item.buyPrice(gold: 1), Condition.DownedCultist)
                .AddModItemToShop(CheckDowned.echoesMod, "Purity_Stone", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(CheckDowned.echoesMod, "Relic_Fragment", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.echoesMod, "Sand_Stone", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(CheckDowned.echoesMod, "SingularityCatalyst", Item.buyPrice(gold: 1), CheckDowned.creation)
                .AddModItemToShop(CheckDowned.echoesMod, "Stardust", Item.buyPrice(gold: 1), CheckDowned.destruction)
                .AddModItemToShop(CheckDowned.echoesMod, "SunstruckEssence", Item.buyPrice(gold: 1), CheckDowned.galahis)
                .AddModItemToShop(CheckDowned.echoesMod, "Tungqua", Item.buyPrice(gold: 1), CheckDowned.creation)
                .AddModItemToShop(CheckDowned.echoesMod, "Underground_Stone", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(CheckDowned.echoesMod, "Water_Stone", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(CheckDowned.echoesMod, "Wyvernscale", Item.buyPrice(gold: 1), Condition.Hardmode)
            //Exalt
                .AddModItemToShop(CheckDowned.exaltMod, "DragonScale", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(CheckDowned.exaltMod, "IceCrystal", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(CheckDowned.exaltMod, "Leaf", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.exaltMod, "Membrane", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.exaltMod, "Paper", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.exaltMod, "Remnant", Item.buyPrice(gold: 1), CheckDowned.iceLich)
                .AddModItemToShop(CheckDowned.exaltMod, "TwistedFlesh", Item.buyPrice(gold: 1), CheckDowned.bloodMoon, Condition.DownedSkeletron)
                .AddModItemToShop(CheckDowned.exaltMod, "Vescon", Item.buyPrice(gold: 1), Condition.DownedCultist)
            //Fargos
                .AddModItemToShop(CheckDowned.fargosSoulsMod, "AbomEnergy", Item.buyPrice(gold: 1), CheckDowned.abom)
                .AddModItemToShop(CheckDowned.fargosSoulsMod, "DeviatingEnergy", Item.buyPrice(gold: 1), CheckDowned.devi)
                .AddModItemToShop(CheckDowned.fargosSoulsMod, "Eridanium", Item.buyPrice(gold: 1), CheckDowned.cosmoschamp)
                .AddModItemToShop(CheckDowned.fargosSoulsMod, "EternalEnergy", Item.buyPrice(gold: 1), CheckDowned.mutant)
            //Gerds
                .AddModItemToShop(CheckDowned.gmrMod, "UpgradeCrystal", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.gmrMod, "AlloyBox", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.gmrMod, "BossUpgradeCrystal", Item.buyPrice(gold: 1), Condition.DownedEyeOfCthulhu)
                .AddModItemToShop(CheckDowned.gmrMod, "ScrapFragment", Item.buyPrice(gold: 1), CheckDowned.acheron)
                .AddModItemToShop(CheckDowned.gmrMod, "HardmodeUpgradeCrystal", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(CheckDowned.gmrMod, "SpecialUpgradeCrystal", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
            //Homeward
                .AddModItemToShop(CheckDowned.homewardMod, "AbyssFragment", Item.buyPrice(gold: 1), CheckDowned.diver)
                .AddModItemToShop(CheckDowned.homewardMod, "AnglerCoin", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.homewardMod, "AnglerGoldCoin", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.homewardMod, "Blood", Item.buyPrice(gold: 1), CheckDowned.bloodMoon)
                .AddModItemToShop(CheckDowned.homewardMod, "CoffeeBean_1", Item.buyPrice(gold: 1), CheckDowned.overwatcher, CheckDowned.materealizer, CheckDowned.lifebringer)
                .AddModItemToShop(CheckDowned.homewardMod, "CoffeeBean_2", Item.buyPrice(gold: 1), CheckDowned.overwatcher, CheckDowned.materealizer, CheckDowned.lifebringer)
                .AddModItemToShop(CheckDowned.homewardMod, "DenseIcicle", Item.buyPrice(gold: 1), CheckDowned.wos)
                .AddModItemToShop(CheckDowned.homewardMod, "DivineShard", Item.buyPrice(gold: 1), CheckDowned.wos)
                .AddModItemToShop(CheckDowned.homewardMod, "EssenceofBright", Item.buyPrice(gold: 1), CheckDowned.son)
                .AddModItemToShop(CheckDowned.homewardMod, "EssenceofLife", Item.buyPrice(gold: 1), CheckDowned.lifebringer)
                .AddModItemToShop(CheckDowned.homewardMod, "EssenceofMatter", Item.buyPrice(gold: 1), CheckDowned.materealizer)
                .AddModItemToShop(CheckDowned.homewardMod, "EssenceofNothingness", Item.buyPrice(gold: 1), CheckDowned.scarab)
                .AddModItemToShop(CheckDowned.homewardMod, "EssenceofTime", Item.buyPrice(gold: 1), CheckDowned.overwatcher)
                .AddModItemToShop(CheckDowned.homewardMod, "EssenceofDeath", Item.buyPrice(gold: 1), CheckDowned.whale)
                .AddModItemToShop(CheckDowned.homewardMod, "JungleDewdrop", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.homewardMod, "NetherStar", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.homewardMod, "SolarFlareScoria", Item.buyPrice(gold: 1), CheckDowned.sgod)
                .AddModItemToShop(CheckDowned.homewardMod, "SoulofBlight", Item.buyPrice(gold: 1), CheckDowned.motherbrain)
                .AddModItemToShop(CheckDowned.homewardMod, "SpiralTissue", Item.buyPrice(gold: 1), CheckDowned.wos)
                .AddModItemToShop(CheckDowned.homewardMod, "SteelFeather", Item.buyPrice(gold: 1), CheckDowned.wos)
                .AddModItemToShop(CheckDowned.homewardMod, "SunlightGel", Item.buyPrice(gold: 1), CheckDowned.wos)
                .AddModItemToShop(CheckDowned.homewardMod, "CoffeeBean_3", Item.buyPrice(gold: 1), CheckDowned.overwatcher, CheckDowned.materealizer, CheckDowned.lifebringer)
                .AddModItemToShop(CheckDowned.homewardMod, "TankOfThePastCave", Item.buyPrice(gold: 1), CheckDowned.caveOrdeal)
                .AddModItemToShop(CheckDowned.homewardMod, "TankOfThePastCorruption", Item.buyPrice(gold: 1), CheckDowned.corruptOrdeal)
                .AddModItemToShop(CheckDowned.homewardMod, "TankOfThePastCrimson", Item.buyPrice(gold: 1), CheckDowned.crimsonOrdeal)
                .AddModItemToShop(CheckDowned.homewardMod, "TankOfThePastDesert", Item.buyPrice(gold: 1), CheckDowned.desertOrdeal)
                .AddModItemToShop(CheckDowned.homewardMod, "TankOfThePastForest", Item.buyPrice(gold: 1), CheckDowned.forestOrdeal)
                .AddModItemToShop(CheckDowned.homewardMod, "TankOfThePastHallow", Item.buyPrice(gold: 1), CheckDowned.hallowOrdeal)
                .AddModItemToShop(CheckDowned.homewardMod, "TankOfThePastJungle", Item.buyPrice(gold: 1), CheckDowned.jungleOrdeal)
                .AddModItemToShop(CheckDowned.homewardMod, "TankOfThePastSky", Item.buyPrice(gold: 1), CheckDowned.skyOrdeal)
                .AddModItemToShop(CheckDowned.homewardMod, "TankOfThePastSnowland", Item.buyPrice(gold: 1), CheckDowned.snowOrdeal)
                .AddModItemToShop(CheckDowned.homewardMod, "TankOfThePastUnderworld", Item.buyPrice(gold: 1), CheckDowned.underworldOrdeal)
                .AddModItemToShop(CheckDowned.homewardMod, "TrueJungleSpore", Item.buyPrice(gold: 1), CheckDowned.wos)
                .AddModItemToShop(CheckDowned.homewardMod, "CoffeeBean_4", Item.buyPrice(gold: 1), CheckDowned.overwatcher, CheckDowned.materealizer, CheckDowned.lifebringer)
                .AddModItemToShop(CheckDowned.homewardMod, "WillToCorrode", Item.buyPrice(gold: 1), CheckDowned.overwatcher, CheckDowned.materealizer, CheckDowned.lifebringer)
                .AddModItemToShop(CheckDowned.homewardMod, "WillToCrown", Item.buyPrice(gold: 1), CheckDowned.overwatcher, CheckDowned.materealizer, CheckDowned.lifebringer)
                .AddModItemToShop(CheckDowned.homewardMod, "WillToGrow", Item.buyPrice(gold: 1), CheckDowned.overwatcher, CheckDowned.materealizer, CheckDowned.lifebringer)
            //Hunt of the Old God
                .AddModItemToShop(CheckDowned.huntMod, "ChromaticMass", Item.buyPrice(gold: 1), CheckDowned.goozma)
            //Polarities
                .AddModItemToShop(CheckDowned.polaritiesMod, "AlkalineFluid", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.polaritiesMod, "CongealedBrine", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.polaritiesMod, "EvilDNA", Item.buyPrice(gold: 1), CheckDowned.esophage)
                .AddModItemToShop(CheckDowned.polaritiesMod, "LimestoneCarapace", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.polaritiesMod, "Rattle", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.polaritiesMod, "SaltCrystals", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.polaritiesMod, "SerpentScale", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.polaritiesMod, "StormChunk", Item.buyPrice(gold: 1), CheckDowned.cloudfish)
                .AddModItemToShop(CheckDowned.polaritiesMod, "Tentacle", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.polaritiesMod, "VenomGland", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.polaritiesMod, "WandererPlating", Item.buyPrice(gold: 1), CheckDowned.wanderer)
            //Redemption
                .AddModItemToShop(CheckDowned.redemptionMod, "AIChip", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.redemptionMod, "CarbonMyofibre", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.redemptionMod, "Capacitator", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.redemptionMod, "CoastScarabShell", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.redemptionMod, "GildedStar", Item.buyPrice(gold: 1), CheckDowned.duo)
                .AddModItemToShop(CheckDowned.redemptionMod, "GrimShard", Item.buyPrice(gold: 1), CheckDowned.keeper)
                .AddModItemToShop(CheckDowned.redemptionMod, "LifeFragment", Item.buyPrice(gold: 1), CheckDowned.nebby)
                .AddModItemToShop(CheckDowned.redemptionMod, "LostSoul", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.redemptionMod, "MoonflareFragment", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.redemptionMod, "Plating", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.redemptionMod, "ToxicBile", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.redemptionMod, "TreeBugShell", Item.buyPrice(gold: 1))
            //SOTS
                .AddModItemToShop(CheckDowned.sotsMod, "CursedMatter", Item.buyPrice(gold: 1), CheckDowned.pharaohscurse)
                .AddModItemToShop(CheckDowned.sotsMod, "DissolvingAether", Item.buyPrice(gold: 1), CheckDowned.advisor)
                .AddModItemToShop(CheckDowned.sotsMod, "DissolvingAurora", Item.buyPrice(gold: 1), CheckDowned.permafrostSpirit)
                .AddModItemToShop(CheckDowned.sotsMod, "DissolvingBrilliance", Item.buyPrice(gold: 1), CheckDowned.lux)
                .AddModItemToShop(CheckDowned.sotsMod, "DissolvingDeluge", Item.buyPrice(gold: 1), CheckDowned.tidalSpirit)
                .AddModItemToShop(CheckDowned.sotsMod, "DissolvingEarth", Item.buyPrice(gold: 1), CheckDowned.earthenSpirit)
                .AddModItemToShop(CheckDowned.sotsMod, "DissolvingNature", Item.buyPrice(gold: 1), CheckDowned.natureSpirit)
                .AddModItemToShop(CheckDowned.sotsMod, "DissolvingNether", Item.buyPrice(gold: 1), CheckDowned.infernoSpirit)
                .AddModItemToShop(CheckDowned.sotsMod, "DissolvingUmbra", Item.buyPrice(gold: 1), CheckDowned.evilSpirit)
                .AddModItemToShop(CheckDowned.sotsMod, "FragmentOfChaos", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.sotsMod, "FragmentOfEarth", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "FragmentOfEvil", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "FragmentOfInferno", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "FragmentOfNature", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "FragmentOfOtherworld", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "FragmentOfPermafrost", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "FragmentOfTide", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "Peanut", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "SanguiteBar", Item.buyPrice(gold: 1), CheckDowned.serpent)
                .AddModItemToShop(CheckDowned.sotsMod, "Snakeskin", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(CheckDowned.sotsMod, "SoulResidue", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(CheckDowned.sotsMod, "TwilightGel", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "TwilightShard", Item.buyPrice(gold: 1), CheckDowned.advisor)
                .AddModItemToShop(CheckDowned.sotsMod, "VialofAcid", Item.buyPrice(gold: 1), CheckDowned.putridpinky)
            //Spirit
                .AddModItemToShop(CheckDowned.spiritMod, "Rune", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(CheckDowned.spiritMod, "ArcaneGeyser", Item.buyPrice(gold: 1), CheckDowned.atlas)
                .AddModItemToShop(CheckDowned.spiritMod, "MoonStone", Item.buyPrice(gold: 1), CheckDowned.mysticMoon)
                .AddModItemToShop(CheckDowned.spiritMod, "BismiteCrystal", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "Brightbulb", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "Chitin", Item.buyPrice(gold: 1), CheckDowned.scarabeus)
                .AddModItemToShop(CheckDowned.spiritMod, "DeepCascadeShard", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "SynthMaterial", Item.buyPrice(gold: 1), Condition.DownedGoblinArmy)
                .AddModItemToShop(CheckDowned.spiritMod, "DuskStone", Item.buyPrice(gold: 1), CheckDowned.dusking)
                .AddModItemToShop(CheckDowned.spiritMod, "DreamstrideEssence", Item.buyPrice(gold: 1), CheckDowned.bloodMoon)
                .AddModItemToShop(CheckDowned.spiritMod, "EmptyCodex", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "StarEnergy", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "FrigidFragment", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "GranitechMaterial", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.spiritMod, "HeartScale", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "IridescentScale", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "NetherCrystal", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(CheckDowned.spiritMod, "OldLeather", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "CarvedRock", Item.buyPrice(gold: 1), Condition.DownedSkeletron)
                .AddModItemToShop(CheckDowned.spiritMod, "InfernalAppendage", Item.buyPrice(gold: 1), CheckDowned.infernon)
                .AddModItemToShop(CheckDowned.spiritMod, "TribalScale", Item.buyPrice(gold: 1), CheckDowned.tide)
                .AddModItemToShop(CheckDowned.spiritMod, "SoulShred", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(CheckDowned.spiritMod, "SulfurDeposit", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "TechDrive", Item.buyPrice(gold: 1), Condition.DownedGoblinArmy)
            //Storms
                .AddModItemToShop(CheckDowned.stormMod, "BloodDrop", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc, CheckDowned.bloodMoon)
                .AddModItemToShop(CheckDowned.stormMod, "CrackedHeart", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.stormMod, "ChaosShard", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.stormMod, "DerplingShell", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.stormMod, "GraniteCore", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.stormMod, "SoulFire", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(CheckDowned.stormMod, "BlueCloth", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.stormMod, "SantankScrap", Item.buyPrice(gold: 1), Condition.DownedSantaNK1)
                .AddModItemToShop(CheckDowned.stormMod, "RedSilk", Item.buyPrice(gold: 1))
            //Thorium
                .AddModItemToShop(CheckDowned.thoriumMod, "AbyssalChitin", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.thoriumMod, "BioMatter", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.thoriumMod, "BirdTalon", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "Blood", Item.buyPrice(gold: 1), CheckDowned.bloodMoon)
                .AddModItemToShop(CheckDowned.thoriumMod, "BloomWeave", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.thoriumMod, "BrokenHeroFragment", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.thoriumMod, "BronzeFragments", Item.buyPrice(gold: 1), Condition.DownedSkeletron)
                .AddModItemToShop(CheckDowned.thoriumMod, "CelestialFragment", Item.buyPrice(gold: 1), Condition.DownedCultist)
                .AddModItemToShop(CheckDowned.thoriumMod, "CeruleanMorel", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.thoriumMod, "CursedCloth", Item.buyPrice(gold: 1), CheckDowned.lich)
                .AddModItemToShop(CheckDowned.thoriumMod, "DarkMatter", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.thoriumMod, "DeathEssence", Item.buyPrice(gold: 1), CheckDowned.primordials)
                .AddModItemToShop(CheckDowned.thoriumMod, "DemonBloodShard", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.thoriumMod, "DepthScale", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "DreadSoul", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.thoriumMod, "Geode", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.thoriumMod, "GraniteEnergyCore", Item.buyPrice(gold: 1), Condition.DownedSkeletron)
                .AddModItemToShop(CheckDowned.thoriumMod, "GreenDragonScale", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.thoriumMod, "HallowedCharm", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.thoriumMod, "HolyKnightsAlloy", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.thoriumMod, "IcyShard", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "InfernoEssence", Item.buyPrice(gold: 1), CheckDowned.primordials)
                .AddModItemToShop(CheckDowned.thoriumMod, "LifeCell", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(CheckDowned.thoriumMod, "LivingLeaf", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "OceanEssence", Item.buyPrice(gold: 1), CheckDowned.primordials)
                .AddModItemToShop(CheckDowned.thoriumMod, "Petal", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "PharaohsBreath", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.thoriumMod, "PurityShards", Item.buyPrice(gold: 1), CheckDowned.bloodMoon)
                .AddModItemToShop(CheckDowned.thoriumMod, "ShootingStarFragment", Item.buyPrice(gold: 1), Condition.DownedCultist)
                .AddModItemToShop(CheckDowned.thoriumMod, "StrangeAlienTech", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(CheckDowned.thoriumMod, "StrangePlating", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(CheckDowned.thoriumMod, "SolarPebble", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.thoriumMod, "SoulofPlight", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.thoriumMod, "SpiritDroplet", Item.buyPrice(gold: 1), Condition.DownedSkeletron)
                .AddModItemToShop(CheckDowned.thoriumMod, "TerrariumCore", Item.buyPrice(gold: 1), Condition.DownedCultist)
                .AddModItemToShop(CheckDowned.thoriumMod, "UnfathomableFlesh", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.thoriumMod, "UnholyShards", Item.buyPrice(gold: 1), CheckDowned.bloodMoon)
                .AddModItemToShop(CheckDowned.thoriumMod, "WhiteDwarfFragment", Item.buyPrice(gold: 1), Condition.DownedCultist)
            //VERDANT
                .AddModItemToShop(CheckDowned.verdantMod, "ApotheoticSoul", Item.buyPrice(gold: 1), Condition.DownedMechBossAll)
                .AddModItemToShop(CheckDowned.verdantMod, "Lightbulb", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.verdantMod, "LushLeaf", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.verdantMod, "MysteriaClump", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.verdantMod, "PinkPetal", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.verdantMod, "PuffMaterial", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.verdantMod, "RedPetal", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.verdantMod, "WisplantItem", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.verdantMod, "YellowBulb", Item.buyPrice(gold: 1))
            //Vitality
                .AddModItemToShop(CheckDowned.vitalityMod, "AncientGoldShard", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.vitalityMod, "ChaosCrystal", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.vitalityMod, "ChaosDust", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.vitalityMod, "Charcoal", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.vitalityMod, "CloudVapor", Item.buyPrice(gold: 1), CheckDowned.stormcloud)
                .AddModItemToShop(CheckDowned.vitalityMod, "Ectosoul", Item.buyPrice(gold: 1), CheckDowned.paladin)
                .AddModItemToShop(CheckDowned.vitalityMod, "EquityCore", Item.buyPrice(gold: 1), CheckDowned.paladin)
                .AddModItemToShop(CheckDowned.vitalityMod, "EssenceofFire", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.vitalityMod, "EssenceofFrost", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.vitalityMod, "ForbiddenFeather", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.vitalityMod, "GlacialChunk", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.vitalityMod, "GlowingGranitePowder", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.vitalityMod, "LivingStick", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.vitalityMod, "PurifiedSpore", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.vitalityMod, "ShiverFragment", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.vitalityMod, "SoulofVitality", Item.buyPrice(gold: 1), Condition.DownedPlantera);
            modMaterialsShop.Register();

            var modBossBagShop = new NPCShop(Type, "Modded Treasure Bags")
            //Aequus
                .AddModItemToShop(CheckDowned.aqMod, "CrabsonBag", Item.buyPrice(platinum: 2), CheckDowned.crabson, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.aqMod, "OmegaStariteBag", Item.buyPrice(platinum: 2), CheckDowned.omegastarite, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.aqMod, "DustDevilBag", Item.buyPrice(platinum: 2), CheckDowned.devil, CheckDowned.expertOrMaster)
            //Calamity
                .AddModItemToShop(CheckDowned.calamityMod, "DesertScourgeBag", Item.buyPrice(platinum: 2), CheckDowned.desertscourge, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.calamityMod, "CrabulonBag", Item.buyPrice(platinum: 2), CheckDowned.crabulon, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.calamityMod, "HiveMindBag", Item.buyPrice(platinum: 2), CheckDowned.hivemind, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.calamityMod, "PerforatorBag", Item.buyPrice(platinum: 2), CheckDowned.perforators, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.calamityMod, "SlimeGodBag", Item.buyPrice(platinum: 2), CheckDowned.slimegod, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.calamityMod, "CryogenBag", Item.buyPrice(platinum: 2), CheckDowned.cryogen, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.calamityMod, "AquaticScourgeBag", Item.buyPrice(platinum: 2), CheckDowned.aquaticscourge, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.calamityMod, "BrimstoneWaifuBag", Item.buyPrice(platinum: 2), CheckDowned.brimstoneelemental, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.calamityMod, "CalamitasCloneBag", Item.buyPrice(platinum: 2), CheckDowned.calamitas, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.calamityMod, "LeviathanBag", Item.buyPrice(platinum: 2), CheckDowned.leviathan, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.calamityMod, "AstrumAureusBag", Item.buyPrice(platinum: 2), CheckDowned.aureus, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.calamityMod, "PlaguebringerGoliathBag", Item.buyPrice(platinum: 2), CheckDowned.plaguebringer, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.calamityMod, "RavagerBag", Item.buyPrice(platinum: 2), CheckDowned.ravager, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.calamityMod, "AstrumDeusBag", Item.buyPrice(platinum: 2), CheckDowned.deus, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.calamityMod, "DragonfollyBag", Item.buyPrice(platinum: 2), CheckDowned.dragonfolly, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.calamityMod, "ProvidenceBag", Item.buyPrice(platinum: 2), CheckDowned.providence, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.calamityMod, "PolterghastBag", Item.buyPrice(platinum: 2), CheckDowned.polterghast, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.calamityMod, "CeaselessVoidBag", Item.buyPrice(platinum: 2), CheckDowned.ceaselessvoid, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.calamityMod, "StormWeaverBag", Item.buyPrice(platinum: 2), CheckDowned.stormweaver, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.calamityMod, "SignusBag", Item.buyPrice(platinum: 2), CheckDowned.signus, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.calamityMod, "OldDukeBag", Item.buyPrice(platinum: 2), CheckDowned.oldduke, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.calamityMod, "DevourerofGodsBag", Item.buyPrice(platinum: 2), CheckDowned.dog, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.calamityMod, "YharonBag", Item.buyPrice(platinum: 2), CheckDowned.yharon, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.calamityMod, "DraedonBag", Item.buyPrice(platinum: 2), CheckDowned.exomechs, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.calamityMod, "CalamitasCoffer", Item.buyPrice(platinum: 2), CheckDowned.scalamitas, CheckDowned.expertOrMaster)
            //Catalyst
                .AddModItemToShop(CheckDowned.catalystMod, "AstrageldonBag", Item.buyPrice(platinum: 2), CheckDowned.geldon, CheckDowned.expertOrMaster)
            //Consolaria
                .AddModItemToShop(CheckDowned.consolariaMod, "LepusBag", Item.buyPrice(platinum: 2), CheckDowned.lepus, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.consolariaMod, "TurkorBag", Item.buyPrice(platinum: 2), CheckDowned.turkor, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.consolariaMod, "OcramBag", Item.buyPrice(platinum: 2), CheckDowned.ocram, CheckDowned.expertOrMaster)
            //Echoes
                .AddModItemToShop(CheckDowned.echoesMod, "GalahisBag", Item.buyPrice(platinum: 2), CheckDowned.galahis, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.echoesMod, "CreationBag", Item.buyPrice(platinum: 2), CheckDowned.creation, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.echoesMod, "DestructionBag", Item.buyPrice(platinum: 2), CheckDowned.destruction, CheckDowned.expertOrMaster)
            //Exalt
                .AddModItemToShop(CheckDowned.exaltMod, "EffulgenceBossBag", Item.buyPrice(platinum: 2), CheckDowned.effulgence, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.exaltMod, "IceLichBossBag", Item.buyPrice(platinum: 2), CheckDowned.iceLich, CheckDowned.expertOrMaster)
            //Fargos
                .AddModItemToShop(CheckDowned.fargosSoulsMod, "TrojanSquirrelBag", Item.buyPrice(platinum: 2), CheckDowned.squirrel, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.fargosSoulsMod, "DeviBag", Item.buyPrice(platinum: 2), CheckDowned.devi, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.fargosSoulsMod, "LifeChallengerBag", Item.buyPrice(platinum: 2), CheckDowned.lieflight, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.fargosSoulsMod, "CosmosBag", Item.buyPrice(platinum: 2), CheckDowned.cosmoschamp, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.fargosSoulsMod, "AbomBag", Item.buyPrice(platinum: 2), CheckDowned.abom, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.fargosSoulsMod, "MutantBag", Item.buyPrice(platinum: 2), CheckDowned.mutant, CheckDowned.expertOrMaster)
            //Homeward
                .AddModItemToShop(CheckDowned.homewardMod, "MarquisMoonsquidTreasureBag", Item.buyPrice(platinum: 2), CheckDowned.squid, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.homewardMod, "PriestessRodTreasureBag", Item.buyPrice(platinum: 2), CheckDowned.rod, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.homewardMod, "DiverTreasureBag", Item.buyPrice(platinum: 2), CheckDowned.diver, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.homewardMod, "TheMotherbrainTreasureBag", Item.buyPrice(platinum: 2), CheckDowned.motherbrain, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.homewardMod, "WallofShadowTreasureBag", Item.buyPrice(platinum: 2), CheckDowned.wos, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.homewardMod, "SlimeGodTreasureBag", Item.buyPrice(platinum: 2), CheckDowned.sgod, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.homewardMod, "TheOverwatcherTreasureBag", Item.buyPrice(platinum: 2), CheckDowned.overwatcher, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.homewardMod, "TheLifebringerTreasureBag", Item.buyPrice(platinum: 2), CheckDowned.lifebringer, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.homewardMod, "TheMaterealizerTreasureBag", Item.buyPrice(platinum: 2), CheckDowned.materealizer, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.homewardMod, "ScarabBeliefTreasureBag", Item.buyPrice(platinum: 2), CheckDowned.scarab, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.homewardMod, "EverlastingFallingWhaleTreasureBag", Item.buyPrice(platinum: 2), CheckDowned.whale, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.homewardMod, "TheSonTreasureBag", Item.buyPrice(platinum: 2), CheckDowned.son, CheckDowned.expertOrMaster)
            //Hunt of the Old God
                .AddModItemToShop(CheckDowned.huntMod, "TreasureBucket", Item.buyPrice(platinum: 2), CheckDowned.goozma, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.huntMod, "TreasureTrunk", Item.buyPrice(platinum: 2), CheckDowned.goozma, CheckDowned.expertOrMaster)
            //Infernum
                .AddModItemToShop(CheckDowned.infernumMod, "BereftVassalBossBag", Item.buyPrice(platinum: 2), CheckDowned.vassal, CheckDowned.expertOrMaster)
            //Polarities
                .AddModItemToShop(CheckDowned.polaritiesMod, "StormCloudfishBag", Item.buyPrice(platinum: 2), CheckDowned.cloudfish, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.polaritiesMod, "StarConstructBag", Item.buyPrice(platinum: 2), CheckDowned.construct, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.polaritiesMod, "GigabatBag", Item.buyPrice(platinum: 2), CheckDowned.gigabat, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.polaritiesMod, "SunPixieBag", Item.buyPrice(platinum: 2), CheckDowned.sunpixie, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.polaritiesMod, "EsophageBag", Item.buyPrice(platinum: 2), CheckDowned.esophage, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.polaritiesMod, "ConvectiveWandererBag", Item.buyPrice(platinum: 2), CheckDowned.wanderer, CheckDowned.expertOrMaster)
            //Qwertys
                .AddModItemToShop(CheckDowned.qwertyMod, "TundraBossBag", Item.buyPrice(platinum: 2), CheckDowned.polarBear, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.qwertyMod, "FortressBossBag", Item.buyPrice(platinum: 2), CheckDowned.divineLight, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.qwertyMod, "AncientMachineBag", Item.buyPrice(platinum: 2), CheckDowned.ancientMachine, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.qwertyMod, "NoehtnapBag", Item.buyPrice(platinum: 2), CheckDowned.noehtnap, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.qwertyMod, "Hydrabag", Item.buyPrice(platinum: 2), CheckDowned.hydra, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.qwertyMod, "BladeBossBag", Item.buyPrice(platinum: 2), CheckDowned.imperious, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.qwertyMod, "RuneGhostBag", Item.buyPrice(platinum: 2), CheckDowned.runeGhost, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.qwertyMod, "B4Bag", Item.buyPrice(platinum: 2), CheckDowned.olord, CheckDowned.expertOrMaster)
            //Redemption
                .AddModItemToShop(CheckDowned.redemptionMod, "ThornBag", Item.buyPrice(platinum: 2), CheckDowned.thorn, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.redemptionMod, "ErhanBag", Item.buyPrice(platinum: 2), CheckDowned.erhan, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.redemptionMod, "KeeperBag", Item.buyPrice(platinum: 2), CheckDowned.keeper, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.redemptionMod, "SoIBag", Item.buyPrice(platinum: 2), CheckDowned.seed, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.redemptionMod, "SlayerBag", Item.buyPrice(platinum: 2), CheckDowned.ks3, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.redemptionMod, "OmegaCleaverBag", Item.buyPrice(platinum: 2), CheckDowned.cleaver, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.redemptionMod, "OmegaGigaporaBag", Item.buyPrice(platinum: 2), CheckDowned.gigapora, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.redemptionMod, "OmegaOblitBag", Item.buyPrice(platinum: 2), CheckDowned.obliterator, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.redemptionMod, "PZBag", Item.buyPrice(platinum: 2), CheckDowned.zero, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.redemptionMod, "AkkaBag", Item.buyPrice(platinum: 2), CheckDowned.duo, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.redemptionMod, "UkkoBag", Item.buyPrice(platinum: 2), CheckDowned.duo, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.redemptionMod, "NebBag", Item.buyPrice(platinum: 2), CheckDowned.nebby, CheckDowned.expertOrMaster)
            //SOTS
                .AddModItemToShop(CheckDowned.sotsMod, "GlowmothBag", Item.buyPrice(platinum: 2), CheckDowned.glowmoth, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.sotsMod, "PinkyBag", Item.buyPrice(platinum: 2), CheckDowned.putridpinky, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.sotsMod, "CurseBag", Item.buyPrice(platinum: 2), CheckDowned.pharaohscurse, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.sotsMod, "TheAdvisorBossBag", Item.buyPrice(platinum: 2), CheckDowned.advisor, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.sotsMod, "PolarisBossBag", Item.buyPrice(platinum: 2), CheckDowned.polaris, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.sotsMod, "LuxBag", Item.buyPrice(platinum: 2), CheckDowned.lux, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.sotsMod, "SubspaceBag", Item.buyPrice(platinum: 2), CheckDowned.serpent, CheckDowned.expertOrMaster)
            //Spirit
                .AddModItemToShop(CheckDowned.spiritMod, "BagOScarabs", Item.buyPrice(platinum: 2), CheckDowned.scarabeus, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.spiritMod, "MJWBag", Item.buyPrice(platinum: 2), CheckDowned.moonjelly, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.spiritMod, "ReachBossBag", Item.buyPrice(platinum: 2), CheckDowned.vinewrath, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.spiritMod, "FlyerBag", Item.buyPrice(platinum: 2), CheckDowned.avian, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.spiritMod, "SteamRaiderBag", Item.buyPrice(platinum: 2), CheckDowned.starvoyager, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.spiritMod, "InfernonBag", Item.buyPrice(platinum: 2), CheckDowned.infernon, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.spiritMod, "DuskingBag", Item.buyPrice(platinum: 2), CheckDowned.dusking, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.spiritMod, "AtlasBag", Item.buyPrice(platinum: 2), CheckDowned.atlas, CheckDowned.expertOrMaster)
            //Spooky
                .AddModItemToShop(CheckDowned.spookyMod, "BossBagSpookySpirit", Item.buyPrice(platinum: 2), CheckDowned.spookyspirit, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.spookyMod, "BossBagRotGourd", Item.buyPrice(platinum: 2), CheckDowned.gourd, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.spookyMod, "BossBagMoco", Item.buyPrice(platinum: 2), CheckDowned.moco, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.spookyMod, "BossBagOrroboro", Item.buyPrice(platinum: 2), CheckDowned.orroboro, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.spookyMod, "BossBagBigBone", Item.buyPrice(platinum: 2), CheckDowned.bigbone, CheckDowned.expertOrMaster)
            //Storms
                .AddModItemToShop(CheckDowned.stormMod, "AridBossBag", Item.buyPrice(platinum: 2), CheckDowned.arid, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.stormMod, "StormBossBag", Item.buyPrice(platinum: 2), CheckDowned.storm, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.stormMod, "UltimateBossBag", Item.buyPrice(platinum: 2), CheckDowned.painbringer, CheckDowned.expertOrMaster)
            //Thorium
                .AddModItemToShop(CheckDowned.thoriumMod, "ThunderBirdBag", Item.buyPrice(platinum: 2), CheckDowned.grandbird, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.thoriumMod, "JellyFishBag", Item.buyPrice(platinum: 2), CheckDowned.queenjelly, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.thoriumMod, "CountBag", Item.buyPrice(platinum: 2), CheckDowned.viscount, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.thoriumMod, "GraniteBag", Item.buyPrice(platinum: 2), CheckDowned.energystorm, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.thoriumMod, "HeroBag", Item.buyPrice(platinum: 2), CheckDowned.buriedchampion, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.thoriumMod, "ScouterBag", Item.buyPrice(platinum: 2), CheckDowned.scouter, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.thoriumMod, "BoreanBag", Item.buyPrice(platinum: 2), CheckDowned.strider, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.thoriumMod, "BeholderBag", Item.buyPrice(platinum: 2), CheckDowned.fallenbeholder, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.thoriumMod, "LichBag", Item.buyPrice(platinum: 2), CheckDowned.lich, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.thoriumMod, "AbyssionBag", Item.buyPrice(platinum: 2), CheckDowned.forgottenone, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.thoriumMod, "RagBag", Item.buyPrice(platinum: 2), CheckDowned.primordials, CheckDowned.expertOrMaster)
            //Vitality
                .AddModItemToShop(CheckDowned.vitalityMod, "StormCloudBossBag", Item.buyPrice(platinum: 2), CheckDowned.stormcloud, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.vitalityMod, "GrandAntlionBossBag", Item.buyPrice(platinum: 2), CheckDowned.grandantlion, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.vitalityMod, "GemstoneElementalBossBag", Item.buyPrice(platinum: 2), CheckDowned.gemstone, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.vitalityMod, "MoonlightDragonflyBossBag", Item.buyPrice(platinum: 2), CheckDowned.dragonfly, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.vitalityMod, "DreadnaughtBossBag", Item.buyPrice(platinum: 2), CheckDowned.dreadnaught, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.vitalityMod, "AnarchulesBeetleBossBag", Item.buyPrice(platinum: 2), CheckDowned.anarchulesbeetle, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.vitalityMod, "ChaosbringerBossBag", Item.buyPrice(platinum: 2), CheckDowned.chaosbringer, CheckDowned.expertOrMaster)
                .AddModItemToShop(CheckDowned.vitalityMod, "PaladinSpiritBossBag", Item.buyPrice(platinum: 2), CheckDowned.paladin, CheckDowned.expertOrMaster);
            modBossBagShop.Register();

            var modCratesShop = new NPCShop(Type, "Modded Crates & Grab Bags")
            //Aequus
                .AddModItemToShop(CheckDowned.aqMod, "CrabCreviceCrate", Item.buyPrice(platinum: 1))
                .AddModItemToShop(CheckDowned.aqMod, "CrabCreviceCrateHard", Item.buyPrice(platinum: 1), Condition.Hardmode)
            //Calamity
                .AddModItemToShop(CheckDowned.calamityMod, "AstralCrate", Item.buyPrice(platinum: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "BrimstoneCrate", Item.buyPrice(platinum: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(CheckDowned.calamityMod, "SulphurousCrate", Item.buyPrice(platinum: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "SunkenCrate", Item.buyPrice(platinum: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "SulphuricTreasure", Item.buyPrice(platinum: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "AbyssalTreasure", Item.buyPrice(platinum: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "FleshyGeode", Item.buyPrice(platinum: 1), CheckDowned.ravager)
                .AddModItemToShop(CheckDowned.calamityMod, "NecromanticGeode", Item.buyPrice(platinum: 1), CheckDowned.providence)
            //Polarities
                .AddModItemToShop(CheckDowned.polaritiesMod, "SaltCrate", Item.buyPrice(platinum: 1))
            //Redemption
                .AddModItemToShop(CheckDowned.redemptionMod, "PetrifiedCrate", Item.buyPrice(platinum: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.redemptionMod, "LabCrate", Item.buyPrice(platinum: 1), Condition.DownedMechBossAll)
                .AddModItemToShop(CheckDowned.redemptionMod, "LabCrate2", Item.buyPrice(platinum: 1), Condition.DownedMoonLord)
            //SOTS
                .AddModItemToShop(CheckDowned.sotsMod, "PyramidCrate", Item.buyPrice(platinum: 1), Condition.DownedEowOrBoc)
            //Spirit
                .AddModItemToShop(CheckDowned.spiritMod, "ReachCrate", Item.buyPrice(platinum: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "BriarCrate", Item.buyPrice(platinum: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.spiritMod, "SpiritCrate", Item.buyPrice(platinum: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(CheckDowned.spiritMod, "FishCrate", Item.buyPrice(platinum: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "PirateCrate", Item.buyPrice(platinum: 1), Condition.DownedPirates)
            //Thorium
                .AddModItemToShop(CheckDowned.thoriumMod, "AquaticDepthsCrate", Item.buyPrice(platinum: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "AbyssalCrate", Item.buyPrice(platinum: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.thoriumMod, "ScarletCrate", Item.buyPrice(platinum: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "SinisterCrate", Item.buyPrice(platinum: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.thoriumMod, "StrangeCrate", Item.buyPrice(platinum: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "WondrousCrate", Item.buyPrice(platinum: 1), Condition.Hardmode)
            //VERDANT
                .AddModItemToShop(CheckDowned.verdantMod, "LushWoodCrateItem", Item.buyPrice(platinum: 1))
                .AddModItemToShop(CheckDowned.verdantMod, "MysteriaCrateItem", Item.buyPrice(platinum: 1), Condition.Hardmode);
            modCratesShop.Register();

            var modOreShop = new NPCShop(Type, "Modded Ores & Bars")
            //Calamity
                .AddModItemToShop(CheckDowned.calamityMod, "AerialiteOre", Item.buyPrice(gold: 1), CheckDowned.perfOrHive)
                .AddModItemToShop(CheckDowned.calamityMod, "AstralOre", Item.buyPrice(gold: 1), CheckDowned.deus)
                .AddModItemToShop(CheckDowned.calamityMod, "AuricOre", Item.buyPrice(gold: 1), CheckDowned.yharon)
                .AddModItemToShop(CheckDowned.calamityMod, "CryonicOre", Item.buyPrice(gold: 1), CheckDowned.cryogen)
                .AddModItemToShop(CheckDowned.calamityMod, "ExodiumCluster", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(CheckDowned.calamityMod, "HallowedOre", Item.buyPrice(gold: 1), Condition.DownedMechBossAll)
                .AddModItemToShop(CheckDowned.calamityMod, "InfernalSuevite", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(CheckDowned.calamityMod, "PerennialOre", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.calamityMod, "PrismShard", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "ScoriaOre", Item.buyPrice(gold: 1), Condition.DownedGolem)
                .AddModItemToShop(CheckDowned.calamityMod, "SeaPrism", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "UelibloomOre", Item.buyPrice(gold: 1), CheckDowned.providence)
                .AddModItemToShop(CheckDowned.calamityMod, "AerialiteBar", Item.buyPrice(gold: 1), CheckDowned.perfOrHive)
                .AddModItemToShop(CheckDowned.calamityMod, "AstralBar", Item.buyPrice(gold: 1), CheckDowned.deus)
                .AddModItemToShop(CheckDowned.calamityMod, "AuricBar", Item.buyPrice(gold: 1), CheckDowned.yharon)
                .AddModItemToShop(CheckDowned.calamityMod, "CosmiliteBar", Item.buyPrice(gold: 1), CheckDowned.dog)
                .AddModItemToShop(CheckDowned.calamityMod, "CryonicBar", Item.buyPrice(gold: 1), CheckDowned.cryogen)
                .AddModItemToShop(CheckDowned.calamityMod, "PerennialBar", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.calamityMod, "ScoriaBar", Item.buyPrice(gold: 1), Condition.DownedGolem)
                .AddModItemToShop(CheckDowned.calamityMod, "ShadowspecBar", Item.buyPrice(gold: 1), CheckDowned.scalamitas, CheckDowned.exomechs)
                .AddModItemToShop(CheckDowned.calamityMod, "UelibloomBar", Item.buyPrice(gold: 1), CheckDowned.providence)
            //Catalyst
                .AddModItemToShop(CheckDowned.catalystMod, "MetanovaOre", Item.buyPrice(gold: 1), CheckDowned.geldon)
                .AddModItemToShop(CheckDowned.catalystMod, "MetanovaBar", Item.buyPrice(gold: 1), CheckDowned.geldon)
            //Echoes
                .AddModItemToShop(CheckDowned.echoesMod, "ArcaniumOre", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.echoesMod, "Moonstone", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.echoesMod, "Skystone_Ore", Item.buyPrice(gold: 1), Condition.DownedGolem)
                .AddModItemToShop(CheckDowned.echoesMod, "VarsiumCrystal", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(CheckDowned.echoesMod, "Ashen_Ore", Item.buyPrice(gold: 1), Condition.DownedGolem)
                .AddModItemToShop(CheckDowned.echoesMod, "UniversiumOre", Item.buyPrice(gold: 1), Condition.DownedCultist)
                .AddModItemToShop(CheckDowned.echoesMod, "Arcanium_Bar", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.echoesMod, "SkystoneBar", Item.buyPrice(gold: 1), Condition.DownedGolem)
                .AddModItemToShop(CheckDowned.echoesMod, "Ashen_Bar", Item.buyPrice(gold: 1), Condition.DownedGolem)
                .AddModItemToShop(CheckDowned.echoesMod, "UniversiumBar", Item.buyPrice(gold: 1), Condition.DownedCultist)
            //Exalt
                .AddModItemToShop(CheckDowned.exaltMod, "TitanicOre", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.exaltMod, "TitanicBar", Item.buyPrice(gold: 1), Condition.DownedPlantera)
            //Homeward
                .AddModItemToShop(CheckDowned.homewardMod, "Onyx", Item.buyPrice(gold: 1), Condition.DownedGolem)
                .AddModItemToShop(CheckDowned.homewardMod, "CubistOre", Item.buyPrice(gold: 1), CheckDowned.wos)
                .AddModItemToShop(CheckDowned.homewardMod, "DeepOre", Item.buyPrice(gold: 1), Condition.DownedGolem)
                .AddModItemToShop(CheckDowned.homewardMod, "FinalOre", Item.buyPrice(gold: 1), CheckDowned.lifebringer, CheckDowned.materealizer, CheckDowned.overwatcher)
                .AddModItemToShop(CheckDowned.homewardMod, "EternalOre", Item.buyPrice(gold: 1), CheckDowned.wos)
                .AddModItemToShop(CheckDowned.homewardMod, "LivingOre", Item.buyPrice(gold: 1), CheckDowned.wos)
                .AddModItemToShop(CheckDowned.homewardMod, "CubistBar", Item.buyPrice(gold: 1), CheckDowned.wos)
                .AddModItemToShop(CheckDowned.homewardMod, "DeepBar", Item.buyPrice(gold: 1), Condition.DownedGolem)
                .AddModItemToShop(CheckDowned.homewardMod, "FinalBar", Item.buyPrice(gold: 1), CheckDowned.lifebringer, CheckDowned.materealizer, CheckDowned.overwatcher)
                .AddModItemToShop(CheckDowned.homewardMod, "EternalBar", Item.buyPrice(gold: 1), CheckDowned.wos)
                .AddModItemToShop(CheckDowned.homewardMod, "LivingBar", Item.buyPrice(gold: 1), CheckDowned.wos)
                .AddModItemToShop(CheckDowned.homewardMod, "AbyssalChunk", Item.buyPrice(gold: 1), CheckDowned.diver)
            //Polarities
                .AddModItemToShop(CheckDowned.polaritiesMod, "MantellarOre", Item.buyPrice(gold: 1), Condition.DownedGolem)
                .AddModItemToShop(CheckDowned.polaritiesMod, "MantellarBar", Item.buyPrice(gold: 1), Condition.DownedGolem)
                .AddModItemToShop(CheckDowned.polaritiesMod, "SunplateBar", Item.buyPrice(gold: 1), CheckDowned.construct)
            //Qwertys
                .AddModItemToShop(CheckDowned.qwertyMod, "LuneOre", Item.buyPrice(gold: 1), Condition.DownedEyeOfCthulhu)
                .AddModItemToShop(CheckDowned.qwertyMod, "RhuthiniumOre", Item.buyPrice(gold: 1), Condition.DownedSkeletron)
                .AddModItemToShop(CheckDowned.qwertyMod, "CaeliteBar", Item.buyPrice(gold: 1), CheckDowned.divineLight)
                .AddModItemToShop(CheckDowned.qwertyMod, "LuneBar", Item.buyPrice(gold: 1), Condition.DownedEyeOfCthulhu)
                .AddModItemToShop(CheckDowned.qwertyMod, "RhuthiniumBar", Item.buyPrice(gold: 1), Condition.DownedSkeletron)
            //Redemption
                .AddModItemToShop(CheckDowned.redemptionMod, "CorruptedXenomite", Item.buyPrice(gold: 1), CheckDowned.cleaver)
                .AddModItemToShop(CheckDowned.redemptionMod, "DragonLeadOre", Item.buyPrice(gold: 1), Condition.DownedSkeletron)
                .AddModItemToShop(CheckDowned.redemptionMod, "GathicCryoCrystal", Item.buyPrice(gold: 1), Condition.DownedSkeletron)
                .AddModItemToShop(CheckDowned.redemptionMod, "GraveSteelShards", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.redemptionMod, "Plutonium", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(CheckDowned.redemptionMod, "RawXenium", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(CheckDowned.redemptionMod, "Uranium", Item.buyPrice(gold: 1), Condition.DownedGolem)
                .AddModItemToShop(CheckDowned.redemptionMod, "Xenomite", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.redemptionMod, "XenomiteShard", Item.buyPrice(gold: 1), CheckDowned.seed)
                .AddModItemToShop(CheckDowned.redemptionMod, "GraveSteelAlloy", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.redemptionMod, "DragonLeadAlloy", Item.buyPrice(gold: 1), Condition.DownedSkeletron)
                .AddModItemToShop(CheckDowned.redemptionMod, "MoltenScrap", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(CheckDowned.redemptionMod, "PureIronAlloy", Item.buyPrice(gold: 1), Condition.DownedSkeletron)
                .AddModItemToShop(CheckDowned.redemptionMod, "XeniumAlloy", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
            //SOTS
                .AddModItemToShop(CheckDowned.sotsMod, "FrigidIce", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "PhaseOre", Item.buyPrice(gold: 1), CheckDowned.lux)
                .AddModItemToShop(CheckDowned.sotsMod, "VibrantOre", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "AbsoluteBar", Item.buyPrice(gold: 1), CheckDowned.polaris)
                .AddModItemToShop(CheckDowned.sotsMod, "AncientSteelBar", Item.buyPrice(gold: 1), Condition.DownedGoblinArmy)
                .AddModItemToShop(CheckDowned.sotsMod, "FrigidBar", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "HardlightAlloy", Item.buyPrice(gold: 1), CheckDowned.advisor)
                .AddModItemToShop(CheckDowned.sotsMod, "PhaseBar", Item.buyPrice(gold: 1), CheckDowned.lux)
                .AddModItemToShop(CheckDowned.sotsMod, "StarlightAlloy", Item.buyPrice(gold: 1), CheckDowned.advisor)
                .AddModItemToShop(CheckDowned.sotsMod, "OtherworldlyAlloy", Item.buyPrice(gold: 1), CheckDowned.advisor)
                .AddModItemToShop(CheckDowned.sotsMod, "VibrantBar", Item.buyPrice(gold: 1))
            //Spirit
                .AddModItemToShop(CheckDowned.spiritMod, "MarbleChunk", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(CheckDowned.spiritMod, "CosmiliteShard", Item.buyPrice(gold: 1), CheckDowned.starvoyager)
                .AddModItemToShop(CheckDowned.spiritMod, "CryoliteOre", Item.buyPrice(gold: 1), Condition.DownedSkeletron)
                .AddModItemToShop(CheckDowned.spiritMod, "GraniteOre", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(CheckDowned.spiritMod, "FloranOre", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "SpiritOre", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(CheckDowned.spiritMod, "CryoliteBar", Item.buyPrice(gold: 1), Condition.DownedSkeletron)
                .AddModItemToShop(CheckDowned.spiritMod, "FloranBar", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "SpiritBar", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
            //Storms
                .AddModItemToShop(CheckDowned.stormMod, "SpaceRock", Item.buyPrice(gold: 1), Condition.DownedGolem)
                .AddModItemToShop(CheckDowned.stormMod, "DesertOre", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.stormMod, "IceOre", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.stormMod, "SpaceRockBar", Item.buyPrice(gold: 1), Condition.DownedGolem)
                .AddModItemToShop(CheckDowned.stormMod, "DesertBar", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.stormMod, "IceBar", Item.buyPrice(gold: 1), Condition.Hardmode)
            //Thorium
                .AddModItemToShop(CheckDowned.thoriumMod, "Aquaite", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(CheckDowned.thoriumMod, "aDarksteelAlloy", Item.buyPrice(gold: 1), Condition.DownedSkeletron)
                .AddModItemToShop(CheckDowned.thoriumMod, "IllumiteChunk", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.thoriumMod, "LifeQuartz", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "LodeStoneChunk", Item.buyPrice(gold: 1), CheckDowned.fallenbeholder)
                .AddModItemToShop(CheckDowned.thoriumMod, "SmoothCoal", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "ThoriumOre", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "ValadiumChunk", Item.buyPrice(gold: 1), CheckDowned.fallenbeholder)
                .AddModItemToShop(CheckDowned.thoriumMod, "AquaiteBar", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(CheckDowned.thoriumMod, "IllumiteIngot", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.thoriumMod, "LifeQuartz", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "LodeStoneIngot", Item.buyPrice(gold: 1), CheckDowned.fallenbeholder)
                .AddModItemToShop(CheckDowned.thoriumMod, "SandstoneIngot", Item.buyPrice(gold: 1), CheckDowned.grandbird)
                .AddModItemToShop(CheckDowned.thoriumMod, "SmoothCoal", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "ThoriumBar", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "TitanicBar", Item.buyPrice(gold: 1), Condition.DownedMechBossAll)
                .AddModItemToShop(CheckDowned.thoriumMod, "ValadiumIngot", Item.buyPrice(gold: 1), CheckDowned.fallenbeholder)
            //Verdant
                .AddModItemToShop(CheckDowned.verdantMod, "AquamarineItem", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.verdantMod, "GreenCrystalItem", Item.buyPrice(gold: 1), Condition.DownedEyeOfCthulhu)
            //Vitality
                .AddModItemToShop(CheckDowned.vitalityMod, "ArcticOre", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(CheckDowned.vitalityMod, "GeraniumOre", Item.buyPrice(gold: 1), Condition.DownedSkeletron)
                .AddModItemToShop(CheckDowned.vitalityMod, "AnarchyBar", Item.buyPrice(gold: 1), CheckDowned.anarchulesbeetle)
                .AddModItemToShop(CheckDowned.vitalityMod, "ArcaneGoldBar", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.vitalityMod, "ArcticBar", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(CheckDowned.vitalityMod, "BronzeAlloy", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.vitalityMod, "ChaosBar", Item.buyPrice(gold: 1), CheckDowned.chaosbringer)
                .AddModItemToShop(CheckDowned.vitalityMod, "DriedBar", Item.buyPrice(gold: 1), CheckDowned.grandantlion)
                .AddModItemToShop(CheckDowned.vitalityMod, "GeraniumBar", Item.buyPrice(gold: 1), Condition.DownedSkeletron)
                .AddModItemToShop(CheckDowned.vitalityMod, "GlowingGraniteBar", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.vitalityMod, "SteelAlloy", Item.buyPrice(gold: 1))
                .AddModItemToShop(CheckDowned.vitalityMod, "PurifiedBar", Item.buyPrice(gold: 1));
            modOreShop.Register();

            var modNaturalBlocksShop = new NPCShop(Type, "Modded Natural Blocks")
            //Arbour
                .AddModItemToShop(CheckDowned.arbourMod, "BirchWoodBlock", Item.buyPrice(silver: 1))
            //Aequus
                .AddModItemToShop(CheckDowned.aqMod, "SedimentaryRockItem", Item.buyPrice(silver: 1))
            //Calamity
                .AddModItemToShop(CheckDowned.calamityMod, "AbyssGravel", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(CheckDowned.calamityMod, "Acidwood", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "AstralClay", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "AstralDirt", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "AstralIce", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "AstralMonolith", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "AstralSand", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "AstralSandstone", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "AstralSnow", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "AstralStone", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "BrimstoneSlag", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(CheckDowned.calamityMod, "CelestialRemains", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "EutrophicSand", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "HardenedAstralSand", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "HardenedSulphurousSandstone", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "PyreMantleMolten", Item.buyPrice(silver: 1), Condition.DownedMechBossAll)
                .AddModItemToShop(CheckDowned.calamityMod, "Navystone", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "NovaeSlag", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "PlantyMush", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "PyreMantle", Item.buyPrice(silver: 1), Condition.DownedMechBossAll)
                .AddModItemToShop(CheckDowned.calamityMod, "ScorchedBone", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(CheckDowned.calamityMod, "ScorchedRemains", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(CheckDowned.calamityMod, "SulphurousSand", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "SulphurousSandstone", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "SulphurousShale", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "VernalSoil", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "Voidstone", Item.buyPrice(silver: 1), Condition.DownedMechBossAll)
            //Calamity Vanities
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "AstralClay", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "AstralDirt", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "AstralIce", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "AstralSand", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "AstralSandstone", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "AstralSnow", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "AstralHardenedSand", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "AstralTreeWood", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "Xenostone", Item.buyPrice(silver: 1), Condition.Hardmode)
            //Exalt
                .AddModItemToShop(CheckDowned.exaltMod, "Basalt", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
            //Homeward
                .AddModItemToShop(CheckDowned.homewardMod, "AbyssStone", Item.buyPrice(silver: 1), Condition.DownedMechBossAll)
            //Polarities
                .AddModItemToShop(CheckDowned.polaritiesMod, "Limestone", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.polaritiesMod, "RockSalt", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.polaritiesMod, "Salt", Item.buyPrice(silver: 1))
            //Redemption
                .AddModItemToShop(CheckDowned.redemptionMod, "AncientDirt", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.redemptionMod, "Asteroid", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.redemptionMod, "ElderWood", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.redemptionMod, "GathicColdstone", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.redemptionMod, "GathicFroststone", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.redemptionMod, "GathicGladestone", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.redemptionMod, "GathicStone", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.redemptionMod, "GloomMushroom", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.redemptionMod, "IrradiatedClay", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.redemptionMod, "IrradiatedCrimstone", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.redemptionMod, "IrradiatedDirt", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.redemptionMod, "IrradiatedEbonstone", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.redemptionMod, "IrradiatedHardenedSand", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.redemptionMod, "IrradiatedIce", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.redemptionMod, "IrradiatedSand", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.redemptionMod, "IrradiatedSandstone", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.redemptionMod, "IrradiatedSnow", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.redemptionMod, "IrradiatedStone", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.redemptionMod, "PetrifiedWood", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.redemptionMod, "PlantMatter", Item.buyPrice(silver: 1))
            //SOTS
                .AddModItemToShop(CheckDowned.sotsMod, "CharredWood", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "CursedTumor", Item.buyPrice(silver: 1), CheckDowned.pharaohscurse)
                .AddModItemToShop(CheckDowned.sotsMod, "Evostone", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "Wormwood", Item.buyPrice(silver: 1), Condition.DownedKingSlime)
                .AddModItemToShop(CheckDowned.sotsMod, "SootBlock", Item.buyPrice(silver: 1))
            //Spirit
                .AddModItemToShop(CheckDowned.spiritMod, "AsteroidBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "Black_Stone_Item", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "BlastStoneItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "CreepingIce", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "DriftwoodTileItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "SpiritStoneItem", Item.buyPrice(silver: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(CheckDowned.spiritMod, "SpiritWoodItem", Item.buyPrice(silver: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(CheckDowned.spiritMod, "AncientBark", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "ScrapItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "SpaceJunkItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "SpiritDirtItem", Item.buyPrice(silver: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(CheckDowned.spiritMod, "SpiritIceItem", Item.buyPrice(silver: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(CheckDowned.spiritMod, "SpiritSandItem", Item.buyPrice(silver: 1), Condition.DownedMechBossAny)
            //Spooky
                .AddModItemToShop(CheckDowned.spookyMod, "EyeBlockItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.spookyMod, "LivingFleshItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.spookyMod, "CemeteryDirtItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.spookyMod, "SpookyStoneItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.spookyMod, "SpookyWoodItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.spookyMod, "SpookyMushItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.spookyMod, "CemeteryStoneItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.spookyMod, "SpookyDirtItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.spookyMod, "ValleyStoneItem", Item.buyPrice(silver: 1))
            //Thorium
                .AddModItemToShop(CheckDowned.thoriumMod, "BrackishClump", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(CheckDowned.thoriumMod, "EvergreenBlock", Item.buyPrice(silver: 1), Condition.DownedEverscream, Condition.DownedSantaNK1, Condition.DownedIceQueen)
                .AddModItemToShop(CheckDowned.thoriumMod, "GingerbreadBlock", Item.buyPrice(silver: 1), Condition.DownedEverscream, Condition.DownedSantaNK1, Condition.DownedIceQueen)
                .AddModItemToShop(CheckDowned.thoriumMod, "MarineBlock", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(CheckDowned.thoriumMod, "MossyMarineBlock", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(CheckDowned.thoriumMod, "Permafrost", Item.buyPrice(silver: 1), Condition.DownedEverscream, Condition.DownedSantaNK1, Condition.DownedIceQueen)
                .AddModItemToShop(CheckDowned.thoriumMod, "SugarCookieBlock", Item.buyPrice(silver: 1), Condition.DownedEverscream, Condition.DownedSantaNK1, Condition.DownedIceQueen)
                .AddModItemToShop(CheckDowned.thoriumMod, "YewWood", Item.buyPrice(silver: 1), Condition.DownedGoblinArmy)
            //Verdant
                .AddModItemToShop(CheckDowned.verdantMod, "BackslateTileItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.verdantMod, "LushSoilBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.verdantMod, "LushWoodPlankBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.verdantMod, "MysteriaFluffItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.verdantMod, "MysteriaWood", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.verdantMod, "PuffBlockItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.verdantMod, "SnailShellBlockItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.verdantMod, "ThornBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.verdantMod, "VerdantWoodBlock", Item.buyPrice(silver: 1));
            modNaturalBlocksShop.Register();

            var modBuildingBlocksShop = new NPCShop(Type, "Modded Building Blocks")
            //Calamity
                .AddModItemToShop(CheckDowned.calamityMod, "AerialiteBrick", Item.buyPrice(silver: 1), CheckDowned.perfOrHive)
                .AddModItemToShop(CheckDowned.calamityMod, "AshenAccentSlab", Item.buyPrice(silver: 1), CheckDowned.brimstoneelemental)
                .AddModItemToShop(CheckDowned.calamityMod, "AshenSlab", Item.buyPrice(silver: 1), CheckDowned.brimstoneelemental)
                .AddModItemToShop(CheckDowned.calamityMod, "AstralBrick", Item.buyPrice(silver: 1), CheckDowned.deus)
                .AddModItemToShop(CheckDowned.calamityMod, "BrimstoneSlab", Item.buyPrice(silver: 1), CheckDowned.brimstoneelemental)
                .AddModItemToShop(CheckDowned.calamityMod, "Cinderplate", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "CosmiliteBrick", Item.buyPrice(silver: 1), CheckDowned.dog)
                .AddModItemToShop(CheckDowned.calamityMod, "CryonicBrick", Item.buyPrice(silver: 1), CheckDowned.cryogen)
                .AddModItemToShop(CheckDowned.calamityMod, "Elumplate", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "EutrophicGlass", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "ExoPlating", Item.buyPrice(silver: 1), CheckDowned.exomechs)
                .AddModItemToShop(CheckDowned.calamityMod, "ExoPrismPanel", Item.buyPrice(silver: 1), CheckDowned.exomechs)
                .AddModItemToShop(CheckDowned.calamityMod, "Havocplate", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "HazardChevronPanels", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "LaboratoryPanels", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "LaboratoryPipePlating", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "LaboratoryPlating", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "Navyplate", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "OccultBrickItem", Item.buyPrice(silver: 1), CheckDowned.scalamitas)
                .AddModItemToShop(CheckDowned.calamityMod, "Onyxplate", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityMod, "OtherworldlyStone", Item.buyPrice(silver: 1), CheckDowned.ceaselessvoid, CheckDowned.stormweaver, CheckDowned.signus)
                .AddModItemToShop(CheckDowned.calamityMod, "PerennialBrick", Item.buyPrice(silver: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.calamityMod, "PlaguedContainmentBrick", Item.buyPrice(silver: 1), CheckDowned.plaguebringer)
                .AddModItemToShop(CheckDowned.calamityMod, "Plagueplate", Item.buyPrice(silver: 1), CheckDowned.plaguebringer)
                .AddModItemToShop(CheckDowned.calamityMod, "ProfanedCrystal", Item.buyPrice(silver: 1), CheckDowned.providence)
                .AddModItemToShop(CheckDowned.calamityMod, "ProfanedRock", Item.buyPrice(silver: 1), CheckDowned.providence)
                .AddModItemToShop(CheckDowned.calamityMod, "ProfanedSlab", Item.buyPrice(silver: 1), CheckDowned.providence)
                .AddModItemToShop(CheckDowned.calamityMod, "RunicProfanedBrick", Item.buyPrice(silver: 1), CheckDowned.providence)
                .AddModItemToShop(CheckDowned.calamityMod, "RustedPipes", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "RustedPlating", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "SeaPrismBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.calamityMod, "ScoriaBrick", Item.buyPrice(silver: 1), Condition.DownedGolem)
                .AddModItemToShop(CheckDowned.calamityMod, "SilvaCrystal", Item.buyPrice(silver: 1), CheckDowned.dragonfolly)
                .AddModItemToShop(CheckDowned.calamityMod, "SmoothAbyssGravel", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(CheckDowned.calamityMod, "SmoothBrimstoneSlag", Item.buyPrice(silver: 1), CheckDowned.brimstoneelemental)
                .AddModItemToShop(CheckDowned.calamityMod, "SmoothVoidstone", Item.buyPrice(silver: 1), Condition.DownedMechBossAll)
                .AddModItemToShop(CheckDowned.calamityMod, "StatigelBlock", Item.buyPrice(silver: 1), CheckDowned.slimegod)
                .AddModItemToShop(CheckDowned.calamityMod, "StratusBricks", Item.buyPrice(silver: 1), CheckDowned.polterghast)
                .AddModItemToShop(CheckDowned.calamityMod, "UelibloomBrick", Item.buyPrice(silver: 1), CheckDowned.providence)
                .AddModItemToShop(CheckDowned.calamityMod, "VoidstoneSlab", Item.buyPrice(silver: 1), Condition.DownedMechBossAll)
                .AddModItemToShop(CheckDowned.calamityMod, "WulfrumPlating", Item.buyPrice(silver: 1))
            //Calamity Vanities
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "AstralBrick", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "AstralPearlBlock", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "AstralPlating", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "AuricBrick", Item.buyPrice(silver: 1), CheckDowned.yharon)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "AzufreSludge", Item.buyPrice(silver: 1), CheckDowned.oldduke)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "BlightedEggBlock", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "Bloodstone", Item.buyPrice(silver: 1), CheckDowned.providence)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "BloodstoneBrick", Item.buyPrice(silver: 1), CheckDowned.providence)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "ChiseledBloodstone", Item.buyPrice(silver: 1), CheckDowned.providence)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "EidolicSlab", Item.buyPrice(silver: 1), CheckDowned.polterghast)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "FrostflakeBrick", Item.buyPrice(silver: 1), CheckDowned.cryogen)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "HallowedBrick", Item.buyPrice(silver: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "MeldBlock", Item.buyPrice(silver: 1), Condition.DownedCultist)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "Necrostone", Item.buyPrice(silver: 1), CheckDowned.ravager)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "PhantowaxBlock", Item.buyPrice(silver: 1), CheckDowned.polterghast)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "PolishedAstralMonolith", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "PolishedXenomonolith", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "ShadowBrick", Item.buyPrice(silver: 1), CheckDowned.exomechs, CheckDowned.scalamitas)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "ThanatosPlating", Item.buyPrice(silver: 1), CheckDowned.exomechs)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "ThanatosPlatingVent", Item.buyPrice(silver: 1), CheckDowned.exomechs)
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "WulfrumPlating", Item.buyPrice(silver: 1))
            //Catalyst
                .AddModItemToShop(CheckDowned.catalystMod, "Astrogel", Item.buyPrice(silver: 1), CheckDowned.geldon)
                .AddModItemToShop(CheckDowned.catalystMod, "MetanovaBrick", Item.buyPrice(silver: 1), CheckDowned.geldon)
            //Exalt
                .AddModItemToShop(CheckDowned.exaltMod, "BasaltBrick", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
            //Homeward
                .AddModItemToShop(CheckDowned.homewardMod, "AbyssBrick", Item.buyPrice(silver: 1), Condition.DownedMechBossAll)
            //Polarities
                .AddModItemToShop(CheckDowned.polaritiesMod, "GlowingLimestoneBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.polaritiesMod, "HaliteBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.polaritiesMod, "LimestoneBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.polaritiesMod, "SaltBrick", Item.buyPrice(silver: 1))
            //Qwertys
                .AddModItemToShop(CheckDowned.qwertyMod, "ChiselledFortressBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.qwertyMod, "ReverseSand", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.qwertyMod, "DnasBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.qwertyMod, "FakeFortressBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.qwertyMod, "FortressBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.qwertyMod, "FortressPillar", Item.buyPrice(silver: 1))
            //Redemption
                .AddModItemToShop(CheckDowned.redemptionMod, "GathicColdstoneBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.redemptionMod, "GathicFroststoneBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.redemptionMod, "GathicGladestoneBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.redemptionMod, "GathicStoneBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.redemptionMod, "LabPlating", Item.buyPrice(silver: 1), Condition.DownedMoonLord)
                .AddModItemToShop(CheckDowned.redemptionMod, "MetalSupportBeam", Item.buyPrice(silver: 1), Condition.DownedMoonLord)
                .AddModItemToShop(CheckDowned.redemptionMod, "NiricPipe", Item.buyPrice(silver: 1), Condition.DownedGolem)
            //SOTS
                .AddModItemToShop(CheckDowned.sotsMod, "RoyalGoldBrick", Item.buyPrice(silver: 1), CheckDowned.pharaohscurse)
                .AddModItemToShop(CheckDowned.sotsMod, "DissolvingAuroraBlock", Item.buyPrice(silver: 1), CheckDowned.permafrostSpirit)
                .AddModItemToShop(CheckDowned.sotsMod, "AvaritianPlating", Item.buyPrice(silver: 1), CheckDowned.otherworldlyConstruct)
                .AddModItemToShop(CheckDowned.sotsMod, "DissolvingBrillianceBlock", Item.buyPrice(silver: 1), CheckDowned.lux)
                .AddModItemToShop(CheckDowned.sotsMod, "ChaosPlating", Item.buyPrice(silver: 1), CheckDowned.chaosConstruct)
                .AddModItemToShop(CheckDowned.sotsMod, "DarkShingles", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "DissolvingDelugeBlock", Item.buyPrice(silver: 1), CheckDowned.tidalSpirit)
                .AddModItemToShop(CheckDowned.sotsMod, "DullPlating", Item.buyPrice(silver: 1), CheckDowned.otherworldlyConstruct)
                .AddModItemToShop(CheckDowned.sotsMod, "DissolvingEarthBlock", Item.buyPrice(silver: 1), CheckDowned.earthenSpirit)
                .AddModItemToShop(CheckDowned.sotsMod, "EarthenPlating", Item.buyPrice(silver: 1), CheckDowned.earthenConstruct)
                .AddModItemToShop(CheckDowned.sotsMod, "EvilPlating", Item.buyPrice(silver: 1), CheckDowned.evilConstruct)
                .AddModItemToShop(CheckDowned.sotsMod, "EvostoneBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "FrigidBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.sotsMod, "HardIceBrick", Item.buyPrice(silver: 1), CheckDowned.polaris)
                .AddModItemToShop(CheckDowned.sotsMod, "HardlightBlock", Item.buyPrice(silver: 1), CheckDowned.otherworldlyConstruct)
                .AddModItemToShop(CheckDowned.sotsMod, "InfernoPlating", Item.buyPrice(silver: 1), CheckDowned.infernoConstruct)
                .AddModItemToShop(CheckDowned.sotsMod, "DissolvingNatureBlock", Item.buyPrice(silver: 1), CheckDowned.natureSpirit)
                .AddModItemToShop(CheckDowned.sotsMod, "NaturePlating", Item.buyPrice(silver: 1), CheckDowned.natureConstruct)
                .AddModItemToShop(CheckDowned.sotsMod, "DissolvingNetherBlock", Item.buyPrice(silver: 1), CheckDowned.infernoSpirit)
                .AddModItemToShop(CheckDowned.sotsMod, "OvergrownPyramidBlock", Item.buyPrice(silver: 1), Condition.DownedMechBossAll)
                .AddModItemToShop(CheckDowned.sotsMod, "PermafrostPlating", Item.buyPrice(silver: 1), CheckDowned.permafrostConstruct)
                .AddModItemToShop(CheckDowned.sotsMod, "DissolvingAetherBlock", Item.buyPrice(silver: 1), CheckDowned.advisor)
                .AddModItemToShop(CheckDowned.sotsMod, "PyramidBrick", Item.buyPrice(silver: 1), CheckDowned.pharaohscurse)
                .AddModItemToShop(CheckDowned.sotsMod, "PyramidSlab", Item.buyPrice(silver: 1), CheckDowned.pharaohscurse)
                .AddModItemToShop(CheckDowned.sotsMod, "PyramidRubble", Item.buyPrice(silver: 1), CheckDowned.pharaohscurse)
                .AddModItemToShop(CheckDowned.sotsMod, "RuinedPyramidBrick", Item.buyPrice(silver: 1), CheckDowned.pharaohscurse)
                .AddModItemToShop(CheckDowned.sotsMod, "TidePlating", Item.buyPrice(silver: 1), CheckDowned.tidalConstruct)
                .AddModItemToShop(CheckDowned.sotsMod, "UltimatePlating", Item.buyPrice(silver: 1), CheckDowned.chaosConstruct, CheckDowned.earthenConstruct, CheckDowned.evilConstruct, CheckDowned.infernoConstruct, CheckDowned.natureConstruct, CheckDowned.otherworldlyConstruct, CheckDowned.permafrostConstruct, CheckDowned.tidalConstruct)
                .AddModItemToShop(CheckDowned.sotsMod, "DissolvingUmbraBlock", Item.buyPrice(silver: 1), CheckDowned.evilSpirit)
                .AddModItemToShop(CheckDowned.sotsMod, "VibrantBrick", Item.buyPrice(silver: 1))
            //Spirit
                .AddModItemToShop(CheckDowned.spiritMod, "AcidBrick", Item.buyPrice(silver: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.spiritMod, "SepulchreBrickTwoItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "SepulchreBrickItem", Item.buyPrice(silver: 1))
            //Spooky
                .AddModItemToShop(CheckDowned.spookyMod, "CemeteryBrickItem", Item.buyPrice(silver: 1))
            //Thorium
                .AddModItemToShop(CheckDowned.thoriumMod, "AquamarineGemsparkBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "ScaleBlock", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(CheckDowned.thoriumMod, "BloodstainedBlock", Item.buyPrice(silver: 1), CheckDowned.bloodMoon)
                .AddModItemToShop(CheckDowned.thoriumMod, "BookshelfBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "CelestialBrick", Item.buyPrice(silver: 1), Condition.DownedCultist)
                .AddModItemToShop(CheckDowned.thoriumMod, "CelestialFragmentBlock", Item.buyPrice(silver: 1), Condition.DownedCultist)
                .AddModItemToShop(CheckDowned.thoriumMod, "CheckeredBrick", Item.buyPrice(silver: 1), Condition.DownedSkeletron)
                .AddModItemToShop(CheckDowned.thoriumMod, "CursedBlock", Item.buyPrice(silver: 1), CheckDowned.lich)
                .AddModItemToShop(CheckDowned.thoriumMod, "CutSandstoneBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "CutSandstoneBlockSlab", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "CutStoneBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "CutStoneBlockSlab", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "GlowingMarineBlock", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(CheckDowned.thoriumMod, "IllumiteBrick", Item.buyPrice(silver: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.thoriumMod, "LodestoneSlab", Item.buyPrice(silver: 1), CheckDowned.fallenbeholder)
                .AddModItemToShop(CheckDowned.thoriumMod, "MediciteBrick", Item.buyPrice(silver: 1), CheckDowned.bloodMoon)
                .AddModItemToShop(CheckDowned.thoriumMod, "NagaBlock", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(CheckDowned.thoriumMod, "OpalGemsparkBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "OrnateBlock", Item.buyPrice(silver: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.thoriumMod, "PlateSlab", Item.buyPrice(silver: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(CheckDowned.thoriumMod, "PotionShelfBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "RefinedMarineBlock", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(CheckDowned.thoriumMod, "ScarletBlock", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(CheckDowned.thoriumMod, "ShadyBlock", Item.buyPrice(silver: 1), Condition.DownedPlantera)
                .AddModItemToShop(CheckDowned.thoriumMod, "ShootingStarBrick", Item.buyPrice(silver: 1), Condition.DownedCultist)
                .AddModItemToShop(CheckDowned.thoriumMod, "ShootingStarFragmentBlock", Item.buyPrice(silver: 1), Condition.DownedCultist)
                .AddModItemToShop(CheckDowned.thoriumMod, "SmoothWood", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "ThoriumBrickBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "ThoriumBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.thoriumMod, "ValadiumPlating", Item.buyPrice(silver: 1), CheckDowned.fallenbeholder)
                .AddModItemToShop(CheckDowned.thoriumMod, "WhiteDwarfBrick", Item.buyPrice(silver: 1), Condition.DownedCultist)
                .AddModItemToShop(CheckDowned.thoriumMod, "WhiteDwarfFragmentBlock", Item.buyPrice(silver: 1), Condition.DownedCultist)
            //Verdant
                .AddModItemToShop(CheckDowned.verdantMod, "OvergrownBrickItem", Item.buyPrice(silver: 1))
            //Vitality
                .AddModItemToShop(CheckDowned.vitalityMod, "ArcticBrick", Item.buyPrice(silver: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(CheckDowned.vitalityMod, "BronzeBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.vitalityMod, "GeraniumBrick", Item.buyPrice(silver: 1), Condition.DownedSkeletron);
            modBuildingBlocksShop.Register();

            var modPlantShop = new NPCShop(Type, "Modded Herbs & Plants")
            //Arbour
                .AddModItemToShop(CheckDowned.arbourMod, "ArborGrassSeeds", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.arbourMod, "MicrobirchAcorn", Item.buyPrice(silver: 1))
            //Aequus
                .AddModItemToShop(CheckDowned.aqMod, "ManaclePollen", Item.buyPrice(silver: 1), CheckDowned.demonSiege)
                .AddModItemToShop(CheckDowned.aqMod, "MistralPollen", Item.buyPrice(silver: 1), CheckDowned.devil)
                .AddModItemToShop(CheckDowned.aqMod, "MoonflowerPollen", Item.buyPrice(silver: 1), CheckDowned.omegastarite)
                .AddModItemToShop(CheckDowned.aqMod, "MorayPollen", Item.buyPrice(silver: 1), CheckDowned.crabson)
            //Calamity
                .AddModItemToShop(CheckDowned.calamityMod, "CinderBlossomSeeds", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(CheckDowned.calamityMod, "SpineSapling", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
            //Calamity Vanities
                .AddModItemToShop(CheckDowned.calamityVanitiesMod, "AstralGrass", Item.buyPrice(silver: 1), Condition.Hardmode)
            //Redemption
                .AddModItemToShop(CheckDowned.redemptionMod, "AnglonicMysticBlossom", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.redemptionMod, "LivingTwig", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.redemptionMod, "Nightshade", Item.buyPrice(silver: 1))
            //Spirit
                .AddModItemToShop(CheckDowned.spiritMod, "CloudstalkItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "EnchantedLeaf", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "GlowRoot", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "Kelp", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.spiritMod, "SoulBloom", Item.buyPrice(silver: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(CheckDowned.spiritMod, "BriarGrassSeeds", Item.buyPrice(silver: 1))
            //Spooky
                .AddModItemToShop(CheckDowned.spookyMod, "SpookySeedsGreen", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.spookyMod, "SpookySeedsOrange", Item.buyPrice(silver: 1))
            //Thorium
                .AddModItemToShop(CheckDowned.thoriumMod, "MarineKelp", Item.buyPrice(silver: 1))
            //Verdant
                .AddModItemToShop(CheckDowned.verdantMod, "LightbulbSeeds", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.verdantMod, "MysteriaAcorn", Item.buyPrice(silver: 1))
                .AddModItemToShop(CheckDowned.verdantMod, "WisplantSeeds", Item.buyPrice(silver: 1));
            modPlantShop.Register();
        }
    }
}