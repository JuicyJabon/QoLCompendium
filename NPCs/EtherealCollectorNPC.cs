using QoLCompendium.Items;
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
            NPC.Happiness.SetBiomeAffection<SnowBiome>((AffectionLevel)100)
                .SetBiomeAffection<UndergroundBiome>((AffectionLevel)50)
                .SetBiomeAffection<DesertBiome>((AffectionLevel)(-50))
                .SetNPCAffection(NPCID.Dryad, (AffectionLevel)100)
                .SetNPCAffection(NPCID.DD2Bartender, (AffectionLevel)50)
                .SetNPCAffection(NPCID.Wizard, (AffectionLevel)(-50))
                .SetNPCAffection(NPCID.TaxCollector, (AffectionLevel)(-100));
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

            if (Main.LocalPlayer.HasItem(ItemID.SilverShortsword) && ModContent.GetInstance<ItemConfig>().DedicatedItems)
            {
                result = "That Silver Shortsword is looking mighty fine! Take some burgers for showing me this beauty!";
            }

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
            if (Main.LocalPlayer.HasItem(ItemID.SilverShortsword) && ModContent.GetInstance<ItemConfig>().DedicatedItems)
            {
                button2 = "Get some burgers";
            }
            else
            {
                button2 = "Shop Changer";
            }
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
                if (Main.LocalPlayer.HasItem(ItemID.SilverShortsword) && ModContent.GetInstance<ItemConfig>().DedicatedItems)
                {
                    Item.NewItem(null, Main.LocalPlayer.getRect(), ModContent.ItemType<Burger>(), 100);
                }
                else
                {
                    if (!ECNPCUI.visible) ECNPCUI.timeStart = Main.GameUpdateCount;
                    ECNPCUI.visible = true;
                }
            }
        }

        public override void AddShops()
        {
            var modPotionsShop = new NPCShop(Type, "Modded Potions")
            //Aequus
                .AddModItemToShop(ModConditions.aequusMod, "BloodthirstPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToEvil)
                .AddModItemToShop(ModConditions.aequusMod, "FrostPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToSky)
                .AddModItemToShop(ModConditions.aequusMod, "ManathirstPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToEvil)
                .AddModItemToShop(ModConditions.aequusMod, "MercerTonic", Item.buyPrice(gold: 1), ModConditions.HasBeenToDesert)
                .AddModItemToShop(ModConditions.aequusMod, "NecromancyPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToDesert)
                .AddModItemToShop(ModConditions.aequusMod, "NeutronYogurt", Item.buyPrice(gold: 1), ModConditions.DownedGlimmer)
                .AddModItemToShop(ModConditions.aequusMod, "NoonPotion", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToHallow)
                .AddModItemToShop(ModConditions.aequusMod, "SentryPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToSnow)
                .AddModItemToShop(ModConditions.aequusMod, "VeinminerPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
            //AFKPets
                .AddModItemToShop(ModConditions.afkpetsMod, "AstralwalkerPotion", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToSky)
                .AddModItemToShop(ModConditions.afkpetsMod, "BarkSkinPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.afkpetsMod, "BeetJuice", Item.buyPrice(gold: 1), Condition.DownedQueenBee, ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.afkpetsMod, "BottledFlaxOil", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.afkpetsMod, "CarrotJuice", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.afkpetsMod, "CoronaPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToSky)
                .AddModItemToShop(ModConditions.afkpetsMod, "DragonheartElixir", Item.buyPrice(gold: 1), Condition.DownedOldOnesArmyT3, ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.afkpetsMod, "FarmingPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToJungle)
                .AddModItemToShop(ModConditions.afkpetsMod, "IroncladPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.afkpetsMod, "JumpmansMightyBrew", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.afkpetsMod, "KheprisSacrificialElixir", Item.buyPrice(gold: 1), Condition.DownedGolem, ModConditions.HasBeenToTemple)
                .AddModItemToShop(ModConditions.afkpetsMod, "LeafLoversBrew", Item.buyPrice(gold: 1), ModConditions.HasBeenToJungle)
                .AddModItemToShop(ModConditions.afkpetsMod, "PhantomBloodPotion", Item.buyPrice(gold: 1), Condition.DownedSkeletron, ModConditions.HasBeenToDungeon, ModConditions.DownedBloodMoon)
                .AddModItemToShop(ModConditions.afkpetsMod, "RedBullPotion", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToSky)
                .AddModItemToShop(ModConditions.afkpetsMod, "StarSealerPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToSky)
                .AddModItemToShop(ModConditions.afkpetsMod, "StinguardPotion", Item.buyPrice(gold: 1), Condition.DownedEverscream, ModConditions.HasBeenToSnow)
            //Assorted Crazy Things
                .AddModItemToShop(ModConditions.assortedCrazyThingsMod, "EnhancedHunterPotion", Item.buyPrice(gold: 1), ModConditions.DownedSoulHarvester, ModConditions.HasBeenToDungeon)
            //Buffaria
                .AddModItemToShop(ModConditions.buffariaMod, "AgilityPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "BeePotion", Item.buyPrice(gold: 1), Condition.DownedQueenBee)
                .AddModItemToShop(ModConditions.buffariaMod, "BrightlightPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "BurningPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "CorruptionPotion", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.buffariaMod, "CreationPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "CrimsonPotion", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.buffariaMod, "DashPotion", Item.buyPrice(gold: 1), Condition.DownedDestroyer)
                .AddModItemToShop(ModConditions.buffariaMod, "DeliriousPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "DemonitePotion", Item.buyPrice(gold: 1), Condition.DownedEyeOfCthulhu)
                .AddModItemToShop(ModConditions.buffariaMod, "DesertPotion", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.buffariaMod, "DominancePotion", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(ModConditions.buffariaMod, "DoubleRegenerationPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "EnlargingPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "EyeOfTheGods", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "FastfallPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "FeralPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "FirefootPotion", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.buffariaMod, "ForeseerPotion", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.buffariaMod, "ForestPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "FossilPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "FrogPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "GlassPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "GoliathPotion", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.buffariaMod, "GrowthPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "HallowPotion", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.buffariaMod, "HellPotion", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.buffariaMod, "HuskPotion", Item.buyPrice(gold: 1), Condition.DownedGolem)
                .AddModItemToShop(ModConditions.buffariaMod, "HyperPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "ImpalingPotion", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.buffariaMod, "JunglePotion", Item.buyPrice(gold: 1), Condition.DownedQueenBee)
                .AddModItemToShop(ModConditions.buffariaMod, "LeapingPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "LobbingPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "MagePotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "ManaforcePotion", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.buffariaMod, "MermaidPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "MeteorPotion", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.buffariaMod, "MythPotion", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.buffariaMod, "PalladiumRegenerationPotion", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.buffariaMod, "PhoenixPotion", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(ModConditions.buffariaMod, "PotionPotion", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(ModConditions.buffariaMod, "PrecisionPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "RagingInfernoPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "RangerPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "RejuvenationPotion", Item.buyPrice(gold: 1), Condition.DownedEyeOfCthulhu)
                .AddModItemToShop(ModConditions.buffariaMod, "SeeingEyePotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "ShadowPotion", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(ModConditions.buffariaMod, "ShinyPotion", Item.buyPrice(gold: 1), Condition.DownedGolem)
                .AddModItemToShop(ModConditions.buffariaMod, "ShockPotion", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(ModConditions.buffariaMod, "SnowPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "SpongePotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "StabbingPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "SteadfastPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "SteelskinPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "SturdyPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "SuffocationPotion", Item.buyPrice(gold: 1), Condition.DownedDestroyer)
                .AddModItemToShop(ModConditions.buffariaMod, "SurvivalPotion", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.buffariaMod, "UltimaPotion", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(ModConditions.buffariaMod, "UnflinchingPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "WayfarerPotion", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.buffariaMod, "WisdomPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.buffariaMod, "BloodFrenzyInjection", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.buffariaMod, "DeadeyeInjection", Item.buyPrice(gold: 1), Condition.DownedSkeletron)
                .AddModItemToShop(ModConditions.buffariaMod, "EMCInjection", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.buffariaMod, "InvocationInjection", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.buffariaMod, "NebulaElixir", Item.buyPrice(gold: 1), Condition.DownedNebulaPillar)
                .AddModItemToShop(ModConditions.buffariaMod, "SolarElixir", Item.buyPrice(gold: 1), Condition.DownedSolarPillar)
                .AddModItemToShop(ModConditions.buffariaMod, "StardustElixir", Item.buyPrice(gold: 1), Condition.DownedStardustPillar)
                .AddModItemToShop(ModConditions.buffariaMod, "VortexElixir", Item.buyPrice(gold: 1), Condition.DownedVortexPillar)
                .AddModItemToShop(ModConditions.buffariaMod, "ElixirOfTheMoon", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
            //Calamity
                .AddModItemToShop(ModConditions.calamityMod, "AnechoicCoating", Item.buyPrice(gold: 1), ModConditions.HasBeenToSulphurSea)
                .AddModItemToShop(ModConditions.calamityMod, "AstralInjection", Item.buyPrice(gold: 1), ModConditions.DownedAstrumAureus, ModConditions.HasBeenToAstral)
                .AddModItemToShop(ModConditions.calamityMod, "AureusCell", Item.buyPrice(gold: 1), ModConditions.DownedAstrumAureus, ModConditions.HasBeenToAstral)
                .AddModItemToShop(ModConditions.calamityMod, "BoundingPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToJungle)
                .AddModItemToShop(ModConditions.calamityMod, "CalciumPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.calamityMod, "CeaselessHungerPotion", Item.buyPrice(gold: 1), ModConditions.DownedCeaselessVoid)
                .AddModItemToShop(ModConditions.calamityMod, "GravityNormalizerPotion", Item.buyPrice(gold: 1), ModConditions.DownedAstrumAureus, ModConditions.HasBeenToAstral)
                .AddModItemToShop(ModConditions.calamityMod, "PhotosynthesisPotion", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToJungle)
                .AddModItemToShop(ModConditions.calamityMod, "PotionofOmniscience", Item.buyPrice(gold: 1), Condition.DownedSkeletron)
                .AddModItemToShop(ModConditions.calamityMod, "ShadowPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenThroughNight)
                .AddModItemToShop(ModConditions.calamityMod, "SoaringPotion", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToSky)
                .AddModItemToShop(ModConditions.calamityMod, "SulphurskinPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToSulphurSea)
                .AddModItemToShop(ModConditions.calamityMod, "TeslaPotion", Item.buyPrice(gold: 1), ModConditions.DownedPerforatorsOrHiveMind, ModConditions.HasBeenToSky)
                .AddModItemToShop(ModConditions.calamityMod, "ZenPotion", Item.buyPrice(gold: 1), ModConditions.DownedSlimeGod)
                .AddModItemToShop(ModConditions.calamityMod, "ZergPotion", Item.buyPrice(gold: 1), ModConditions.DownedSlimeGod)
            //Catalyst
                .AddModItemToShop(ModConditions.catalystMod, "AstraJelly", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToAstral)
                .AddModItemToShop(ModConditions.catalystMod, "Lean", Item.buyPrice(gold: 1), ModConditions.DownedAstrumAureus, ModConditions.HasBeenToAstral)
            //Clamity
                .AddModItemToShop(ModConditions.clamityAddonMod, "SupremeLuckPotion", Item.buyPrice(gold: 1), ModConditions.DownedClamitas)
            //Clicker Class
                .AddModItemToShop(ModConditions.clickerClassMod, "InfluencePotion", Item.buyPrice(gold: 1))
            //Consolaria
                .AddModItemToShop(ModConditions.consolariaMod, "Wiesnbrau", Item.buyPrice(gold: 1))
            //Depths
                .AddModItemToShop(ModConditions.depthsMod, "CrystalSkinPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToDepthsOrUnderworld)
                .AddModItemToShop(ModConditions.depthsMod, "SilverSpherePotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToDepthsOrUnderworld)
            //Edorbis
                .AddModItemToShop(ModConditions.edorbisMod, "CapacityPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.edorbisMod, "EnergyRegenerationPotion", Item.buyPrice(gold: 1), ModConditions.DownedGlaciation)
            //Fargos
                .AddModItemToShop(ModConditions.fargosSoulsMod, "RabiesShot", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
            //Homeward
                .AddModItemToShop(ModConditions.homewardJourneyMod, "FlightPotion", Item.buyPrice(gold: 1), ModConditions.DownedMaterealizer)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "HastePotion", Item.buyPrice(gold: 1), ModConditions.DownedMaterealizer)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "ReanimationPotion", Item.buyPrice(gold: 1), ModConditions.DownedMaterealizer)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "YangPotion", Item.buyPrice(gold: 1), ModConditions.DownedWallOfShadow, ModConditions.HasBeenToEvil)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "YinPotion", Item.buyPrice(gold: 1), ModConditions.DownedWallOfShadow, ModConditions.HasBeenToEvil)
            //Polarities
                .AddModItemToShop(ModConditions.polaritiesMod, "PiercingPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.polaritiesMod, "TolerancePotion", Item.buyPrice(gold: 1))
            //Redemption
                .AddModItemToShop(ModConditions.redemptionMod, "CharismaPotion", Item.buyPrice(gold: 1), ModConditions.DownedThorn, ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.redemptionMod, "VendettaPotion", Item.buyPrice(gold: 1), ModConditions.DownedThorn, ModConditions.HasBeenToDesert)
                .AddModItemToShop(ModConditions.redemptionMod, "VigourousPotion", Item.buyPrice(gold: 1), ModConditions.DownedNebuleus)
            //SOTS
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "AbyssalTonic", Item.buyPrice(gold: 1), ModConditions.DownedTidalSpirit, ModConditions.HasBeenToOcean)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "AssassinationPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToPlanetarium)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "BlazingTonic", Item.buyPrice(gold: 1), ModConditions.DownedInfernoSpirit, ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "BlightfulTonic", Item.buyPrice(gold: 1), ModConditions.DownedNatureSpirit)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "BluefirePotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "BrittlePotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToSnow)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "DoubleVisionPotion", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc, ModConditions.HasBeenToPyramid)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "EtherealTonic", Item.buyPrice(gold: 1), ModConditions.DownedLux, ModConditions.HasBeenToHallow)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "GlacialTonic", Item.buyPrice(gold: 1), ModConditions.DownedPermafrostSpirit, ModConditions.HasBeenToSnow)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "HarmonyPotion", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToHallow)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "HereticTonic", Item.buyPrice(gold: 1), ModConditions.DownedEvilSpirit, ModConditions.HasBeenToEvil)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "NightmarePotion", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToEvil)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "RipplePotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToOcean)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "RoughskinPotion", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc, ModConditions.HasBeenToPyramid)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "SeismicTonic", Item.buyPrice(gold: 1), ModConditions.DownedEarthenSpirit, ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "SoulAccessPotion", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc, ModConditions.HasBeenToPyramid)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "StarlightTonic", Item.buyPrice(gold: 1), ModConditions.DownedAdvisor, ModConditions.HasBeenToPlanetarium)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "VibePotion", Item.buyPrice(gold: 1))
            //Spirit
                .AddModItemToShop(ModConditions.spiritMod, "PinkPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.spiritMod, "MirrorCoat", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToHallow)
                .AddModItemToShop(ModConditions.spiritMod, "RunePotion", Item.buyPrice(gold: 1), Condition.DownedMechBossAny, ModConditions.HasBeenToSpirit)
                .AddModItemToShop(ModConditions.spiritMod, "FlightPotion", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToSky)
                .AddModItemToShop(ModConditions.spiritMod, "SoulPotion", Item.buyPrice(gold: 1), Condition.DownedMechBossAny, ModConditions.HasBeenToSpirit)
                .AddModItemToShop(ModConditions.spiritMod, "SpiritPotion", Item.buyPrice(gold: 1), Condition.DownedMechBossAny, ModConditions.HasBeenToSpirit)
                .AddModItemToShop(ModConditions.spiritMod, "MushroomPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToMushroom)
                .AddModItemToShop(ModConditions.spiritMod, "StarPotion", Item.buyPrice(gold: 1), Condition.DownedMechBossAny, ModConditions.HasBeenToSpirit)
                .AddModItemToShop(ModConditions.spiritMod, "TurtlePotion", Item.buyPrice(gold: 1), Condition.DownedMechBossAny, ModConditions.HasBeenToSpirit)
                .AddModItemToShop(ModConditions.spiritMod, "BismitePotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.spiritMod, "DoubleJumpPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToSky)
            //Storms
                .AddModItemToShop(ModConditions.stormsAdditionsMod, "BeetlePotion", Item.buyPrice(gold: 1), Condition.DownedGolem, ModConditions.HasBeenToTemple)
                .AddModItemToShop(ModConditions.stormsAdditionsMod, "FruitHeartPotion", Item.buyPrice(gold: 1), Condition.DownedMechBossAny, ModConditions.HasBeenToJungle)
                .AddModItemToShop(ModConditions.stormsAdditionsMod, "GunPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToJungle)
                .AddModItemToShop(ModConditions.stormsAdditionsMod, "HeartPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.stormsAdditionsMod, "ShroomitePotion", Item.buyPrice(gold: 1), Condition.DownedPlantera, ModConditions.HasBeenToMushroom)
                .AddModItemToShop(ModConditions.stormsAdditionsMod, "SpectrePotion", Item.buyPrice(gold: 1), Condition.DownedPlantera, ModConditions.HasBeenToDungeon)
                .AddModItemToShop(ModConditions.stormsAdditionsMod, "SpookyPotion", Item.buyPrice(gold: 1), Condition.DownedPlantera, Condition.DownedMourningWood)
            //Supernova
                .AddModItemToShop(ModConditions.supernovaMod, "QuarionPotion", Item.buyPrice(gold: 1))
            //Terrorborn
                .AddModItemToShop(ModConditions.terrorbornMod, "AdrenalinePotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.terrorbornMod, "AerodynamicPotion", Item.buyPrice(gold: 1), ModConditions.DownedTidalTitan, ModConditions.HasBeenToOcean)
                .AddModItemToShop(ModConditions.terrorbornMod, "BloodFlowPotion", Item.buyPrice(gold: 1), ModConditions.DownedBloodMoon, Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.terrorbornMod, "DarkbloodPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.terrorbornMod, "SinducementPotion", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.terrorbornMod, "StarpowerPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenThroughNight)
                .AddModItemToShop(ModConditions.terrorbornMod, "VampirismPotion", Item.buyPrice(gold: 1), ModConditions.DownedBloodMoon, Condition.DownedEowOrBoc)
            //Thorium
                .AddModItemToShop(ModConditions.thoriumMod, "AquaPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToAquaticDepths)
                .AddModItemToShop(ModConditions.thoriumMod, "ArcanePotion", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToHallow)
                .AddModItemToShop(ModConditions.thoriumMod, "ArtilleryPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.thoriumMod, "AssassinPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.thoriumMod, "BatRepellent", Item.buyPrice(gold: 1), ModConditions.DownedBloodMoon, ModConditions.DownedPatchWerk)
                .AddModItemToShop(ModConditions.thoriumMod, "BloodPotion", Item.buyPrice(gold: 1), ModConditions.DownedBloodMoon)
                .AddModItemToShop(ModConditions.thoriumMod, "BouncingFlamePotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.thoriumMod, "CactusFruit", Item.buyPrice(gold: 1), ModConditions.DownedGrandThunderBird, ModConditions.HasBeenToDesert)
                .AddModItemToShop(ModConditions.thoriumMod, "ConflagrationPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.thoriumMod, "CreativityPotion", Item.buyPrice(gold: 1), ModConditions.DownedGrandThunderBird, ModConditions.HasBeenToDesert)
                .AddModItemToShop(ModConditions.thoriumMod, "EarwormPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.thoriumMod, "FishRepellent", Item.buyPrice(gold: 1), ModConditions.DownedBloodMoon, ModConditions.DownedPatchWerk)
                .AddModItemToShop(ModConditions.thoriumMod, "FrenzyPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToAquaticDepths)
                .AddModItemToShop(ModConditions.thoriumMod, "GlowingPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToAquaticDepths)
                .AddModItemToShop(ModConditions.thoriumMod, "HolyPotion", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToHallow)
                .AddModItemToShop(ModConditions.thoriumMod, "HydrationPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToAquaticDepths)
                .AddModItemToShop(ModConditions.thoriumMod, "InsectRepellent", Item.buyPrice(gold: 1), ModConditions.DownedBloodMoon, ModConditions.DownedPatchWerk)
                .AddModItemToShop(ModConditions.thoriumMod, "InspirationReachPotion", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToHallow)
                .AddModItemToShop(ModConditions.thoriumMod, "KineticPotion", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToHallow)
                .AddModItemToShop(ModConditions.thoriumMod, "SkeletonRepellent", Item.buyPrice(gold: 1), ModConditions.DownedBloodMoon, ModConditions.DownedPatchWerk)
                .AddModItemToShop(ModConditions.thoriumMod, "WarmongerPotion", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc, ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.thoriumMod, "ZombieRepellent", Item.buyPrice(gold: 1), ModConditions.DownedBloodMoon, ModConditions.DownedPatchWerk)
            //Valhalla
                .AddModItemToShop(ModConditions.valhallaMod, "DartPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.valhallaMod, "SentryPlusPotion", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.valhallaMod, "AuraPlusPotion", Item.buyPrice(gold: 1))
            //Vitality
                .AddModItemToShop(ModConditions.vitalityMod, "ArmorPiercingPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.vitalityMod, "LeapingPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToSky)
                .AddModItemToShop(ModConditions.vitalityMod, "TranquillityPotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToSky)
                .AddModItemToShop(ModConditions.vitalityMod, "TravelsensePotion", Item.buyPrice(gold: 1), ModConditions.HasBeenToOcean)
                .AddModItemToShop(ModConditions.vitalityMod, "WarriorPotion", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc, ModConditions.HasBeenToEvil);
            modPotionsShop.Register();

            var modFlasksShop = new NPCShop(Type, "Modded Flasks, Stations & Foods")
            //AFKPets
                .AddModItemToShop(ModConditions.afkpetsMod, "FlaskofBlood", Item.buyPrice(gold: 1), Condition.DownedQueenBee, ModConditions.DownedBloodMoon)
                .AddModItemToShop(ModConditions.afkpetsMod, "FlaskofNature", Item.buyPrice(gold: 1), Condition.DownedQueenBee, Condition.DownedMechBossAll, ModConditions.HasBeenToJungle)
                .AddModItemToShop(ModConditions.afkpetsMod, "FlaskofShadowflames", Item.buyPrice(gold: 1), Condition.DownedQueenBee, Condition.DownedGoblinArmy)
                .AddModItemToShop(ModConditions.afkpetsMod, "JellyfishJam", Item.buyPrice(gold: 1), Condition.DownedQueenBee, ModConditions.HasBeenToOcean)
                .AddModItemToShop(ModConditions.afkpetsMod, "OliveOilBottle", Item.buyPrice(gold: 1), Condition.DownedQueenBee)
            //Assorted Crazy Things
                .AddModItemToShop(ModConditions.assortedCrazyThingsMod, "EmpowermentFlask", Item.buyPrice(gold: 1), ModConditions.DownedSoulHarvester, ModConditions.HasBeenToDungeon)
            //Buffaria
                .AddModItemToShop(ModConditions.buffariaMod, "CursedFlamesPhial", Item.buyPrice(gold: 1), Condition.DownedQueenBee, Condition.Hardmode)
                .AddModItemToShop(ModConditions.buffariaMod, "DaybreakPhial", Item.buyPrice(gold: 1), Condition.DownedQueenBee, Condition.DownedSolarPillar)
                .AddModItemToShop(ModConditions.buffariaMod, "ElectricityPhial", Item.buyPrice(gold: 1), Condition.DownedQueenBee, Condition.DownedPlantera)
                .AddModItemToShop(ModConditions.buffariaMod, "FirePhial", Item.buyPrice(gold: 1), Condition.DownedQueenBee)
                .AddModItemToShop(ModConditions.buffariaMod, "FrostburnPhial", Item.buyPrice(gold: 1), Condition.DownedQueenBee)
                .AddModItemToShop(ModConditions.buffariaMod, "GoldRushPhial", Item.buyPrice(gold: 1), Condition.DownedQueenBee)
                .AddModItemToShop(ModConditions.buffariaMod, "GunpowderPhial", Item.buyPrice(gold: 1), Condition.DownedQueenBee, Condition.Hardmode)
                .AddModItemToShop(ModConditions.buffariaMod, "IchorPhial", Item.buyPrice(gold: 1), Condition.DownedQueenBee, Condition.Hardmode)
                .AddModItemToShop(ModConditions.buffariaMod, "MultiPhial", Item.buyPrice(gold: 1), Condition.DownedQueenBee, Condition.DownedMoonLord)
                .AddModItemToShop(ModConditions.buffariaMod, "PoisonPhial", Item.buyPrice(gold: 1), Condition.DownedQueenBee)
                .AddModItemToShop(ModConditions.buffariaMod, "ShadowflamePhial", Item.buyPrice(gold: 1), Condition.DownedQueenBee, Condition.Hardmode)
                .AddModItemToShop(ModConditions.buffariaMod, "VenomPhial", Item.buyPrice(gold: 1), Condition.DownedQueenBee, Condition.DownedPlantera)
            //Calamity
                .AddModItemToShop(ModConditions.calamityMod, "Baguette", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.calamityMod, "HadalStew", Item.buyPrice(gold: 1), ModConditions.HasBeenToAbyss)
                .AddModItemToShop(ModConditions.calamityMod, "FlaskOfBrimstone", Item.buyPrice(gold: 1), ModConditions.DownedCalamitasClone)
                .AddModItemToShop(ModConditions.calamityMod, "FlaskOfCrumbling", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.calamityMod, "FlaskOfHolyFlames", Item.buyPrice(gold: 1), Condition.DownedMoonLord, ModConditions.HasBeenToHallow)
                .AddModItemToShop(ModConditions.calamityMod, "CorruptionEffigy", Item.buyPrice(platinum: 1), ModConditions.HasBeenToEvil)
                .AddModItemToShop(ModConditions.calamityMod, "CrimsonEffigy", Item.buyPrice(platinum: 1), ModConditions.HasBeenToEvil)
                .AddModItemToShop(ModConditions.calamityMod, "EffigyOfDecay", Item.buyPrice(platinum: 1), ModConditions.DownedAcidRain1, ModConditions.HasBeenToSulphurSea)
                .AddModItemToShop(ModConditions.calamityMod, "TranquilityCandle", Item.buyPrice(platinum: 1), Condition.DownedPlantera)
                .AddModItemToShop(ModConditions.calamityMod, "ChaosCandle", Item.buyPrice(platinum: 1), Condition.DownedPlantera)
                .AddModItemToShop(ModConditions.calamityMod, "ResilientCandle", Item.buyPrice(platinum: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityMod, "SpitefulCandle", Item.buyPrice(platinum: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityMod, "WeightlessCandle", Item.buyPrice(platinum: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityMod, "VigorousCandle", Item.buyPrice(platinum: 1), Condition.Hardmode)
            //Depths
                .AddModItemToShop(ModConditions.depthsMod, "FlaskofMercury", Item.buyPrice(gold: 1), Condition.DownedQueenBee, ModConditions.HasBeenToDepthsOrUnderworld)
            //Fargos
                .AddModItemToShop(ModConditions.fargosMutantMod, "Omnistation", Item.buyPrice(platinum: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.fargosMutantMod, "Omnistation2", Item.buyPrice(platinum: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.fargosMutantMod, "Semistation", Item.buyPrice(platinum: 1))
            //Redemption
                .AddModItemToShop(ModConditions.redemptionMod, "EvilJelly", Item.buyPrice(gold: 1), ModConditions.DownedKeeper)
                .AddModItemToShop(ModConditions.redemptionMod, "BileFlask", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToWasteland)
                .AddModItemToShop(ModConditions.redemptionMod, "NitroglycerineFlask", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.redemptionMod, "EnergyStation", Item.buyPrice(platinum: 1), Condition.DownedMechBossAll, ModConditions.HasBeenToLab)
            //SOTS
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "AlmondMilk", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "AvocadoSoup", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "Chocolate", Item.buyPrice(gold: 1), Condition.DownedPirates)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "CoconutMilk", Item.buyPrice(gold: 1), ModConditions.HasBeenToOcean)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "CookedMushroom", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "CursedCaviar", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc, ModConditions.HasBeenToPyramid)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "DigitalCornSyrup", Item.buyPrice(gold: 1), ModConditions.HasBeenToPlanetarium)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "FoulConcoction", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "StrawberryIcecream", Item.buyPrice(gold: 1), ModConditions.HasBeenToSnow)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "DigitalDisplay", Item.buyPrice(platinum: 1), ModConditions.HasBeenToPlanetarium)
            //Spirit
                .AddModItemToShop(ModConditions.spiritMod, "Candy", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.spiritMod, "ChocolateBar", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.spiritMod, "HealthCandy", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.spiritMod, "Lollipop", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.spiritMod, "ManaCandy", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.spiritMod, "MysteryCandy", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.spiritMod, "Taffy", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.spiritMod, "CoilEnergizerItem", Item.buyPrice(platinum: 1), Condition.DownedGoblinArmy)
                .AddModItemToShop(ModConditions.spiritMod, "SunPot", Item.buyPrice(platinum: 1))
                .AddModItemToShop(ModConditions.spiritMod, "TheCouch", Item.buyPrice(platinum: 1), Condition.DownedSkeletron)
            //Thorium
                .AddModItemToShop(ModConditions.thoriumMod, "DeepFreezeCoatingItem", Item.buyPrice(gold: 1), Condition.DownedQueenBee, ModConditions.HasBeenToSnow)
                .AddModItemToShop(ModConditions.thoriumMod, "ExplosiveCoatingItem", Item.buyPrice(gold: 1), Condition.DownedQueenBee, ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.thoriumMod, "GorgonCoatingItem", Item.buyPrice(gold: 1), Condition.DownedQueenBee, ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.thoriumMod, "SporeCoatingItem", Item.buyPrice(gold: 1), Condition.DownedQueenBee, ModConditions.HasBeenToMushroom)
                .AddModItemToShop(ModConditions.thoriumMod, "ToxicCoatingItem", Item.buyPrice(gold: 1), Condition.DownedQueenBee, ModConditions.HasBeenToJungle)
                .AddModItemToShop(ModConditions.thoriumMod, "Altar", Item.buyPrice(platinum: 1), ModConditions.DownedBuriedChampion)
                .AddModItemToShop(ModConditions.thoriumMod, "ArenaMastersBrazier", Item.buyPrice(platinum: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.thoriumMod, "ConductorsStand", Item.buyPrice(platinum: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.thoriumMod, "NinjaRack", Item.buyPrice(platinum: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.thoriumMod, "TrueArenaMastersBrazier", Item.buyPrice(platinum: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.thoriumMod, "Mistletoe", Item.buyPrice(platinum: 1));
            modFlasksShop.Register();

            var modMaterialsShop = new NPCShop(Type, "Modded Materials")
            //Aequus
                .AddModItemToShop(ModConditions.aequusMod, "AtmosphericEnergy", Item.buyPrice(gold: 1), ModConditions.DownedGaleStreams, ModConditions.HasBeenToSky)
                .AddModItemToShop(ModConditions.aequusMod, "AquaticEnergy", Item.buyPrice(gold: 1), ModConditions.DownedCrabson, ModConditions.HasBeenToOcean)
                .AddModItemToShop(ModConditions.aequusMod, "BloodyTearstone", Item.buyPrice(gold: 1), ModConditions.DownedBloodMoon)
                .AddModItemToShop(ModConditions.aequusMod, "CosmicEnergy", Item.buyPrice(gold: 1), ModConditions.DownedGlimmer)
                .AddModItemToShop(ModConditions.aequusMod, "DemonicEnergy", Item.buyPrice(gold: 1), ModConditions.DownedDemonSiege, ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.aequusMod, "Fluorescence", Item.buyPrice(gold: 1), ModConditions.DownedRedSprite, ModConditions.HasBeenToSky)
                .AddModItemToShop(ModConditions.aequusMod, "FrozenTear", Item.buyPrice(gold: 1), ModConditions.DownedSpaceSquid, ModConditions.HasBeenToSky)
                .AddModItemToShop(ModConditions.aequusMod, "Hexoplasm", Item.buyPrice(gold: 1), Condition.DownedPlantera, ModConditions.HasBeenToDungeon)
                .AddModItemToShop(ModConditions.aequusMod, "OrganicEnergy", Item.buyPrice(gold: 1), Condition.DownedPlantera, ModConditions.HasBeenToJungle)
                .AddModItemToShop(ModConditions.aequusMod, "UltimateEnergy", Item.buyPrice(gold: 1), Condition.DownedPlantera)
            //AFKPets
                .AddModItemToShop(ModConditions.afkpetsMod, "Bakamite", Item.buyPrice(gold: 1), Condition.DownedIceQueen)
                .AddModItemToShop(ModConditions.afkpetsMod, "Bitcoin", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(ModConditions.afkpetsMod, "BlueThread", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.afkpetsMod, "BoilingBlood", Item.buyPrice(gold: 1), Condition.DownedEyeOfCthulhu)
                .AddModItemToShop(ModConditions.afkpetsMod, "BrokenDollParts", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.afkpetsMod, "BrokenRealityPieceA", Item.buyPrice(gold: 1), ModConditions.DownedDrFetus)
                .AddModItemToShop(ModConditions.afkpetsMod, "BrokenRealityPieceB", Item.buyPrice(gold: 1), ModConditions.DownedAncientTrio)
                .AddModItemToShop(ModConditions.afkpetsMod, "BrokenRealityPieceD", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(ModConditions.afkpetsMod, "Circuit", Item.buyPrice(gold: 1), Condition.DownedSkeletron)
                .AddModItemToShop(ModConditions.afkpetsMod, "DragonsBreath", Item.buyPrice(gold: 1), Condition.DownedOldOnesArmyT3)
                .AddModItemToShop(ModConditions.afkpetsMod, "EncryptedScroll", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.afkpetsMod, "Flax", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.afkpetsMod, "HolographicShard", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.afkpetsMod, "KeyPiece1", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.afkpetsMod, "KeyPiece2", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.afkpetsMod, "KeyPiece3", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(ModConditions.afkpetsMod, "MolecularStabilizer", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(ModConditions.afkpetsMod, "Paper", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.afkpetsMod, "Pine", Item.buyPrice(gold: 1), Condition.DownedEverscream)
                .AddModItemToShop(ModConditions.afkpetsMod, "PlantBox", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.afkpetsMod, "PouchofPhoenixAsh", Item.buyPrice(gold: 1), ModConditions.DownedLavalGolem)
                .AddModItemToShop(ModConditions.afkpetsMod, "PurpleThread", Item.buyPrice(gold: 1), Condition.DownedEyeOfCthulhu)
                .AddModItemToShop(ModConditions.afkpetsMod, "RedThread", Item.buyPrice(gold: 1), Condition.DownedEyeOfCthulhu)
                .AddModItemToShop(ModConditions.afkpetsMod, "RainbowVial", Item.buyPrice(gold: 1), Condition.DownedMechBossAll)
                .AddModItemToShop(ModConditions.afkpetsMod, "ScrapMetal", Item.buyPrice(gold: 1), ModConditions.DownedSATLA)
                .AddModItemToShop(ModConditions.afkpetsMod, "ShadeCinder", Item.buyPrice(gold: 1), Condition.Hardmode, Condition.DownedGoblinArmy)
            //Amulet Of Many Minions
                .AddModItemToShop(ModConditions.amuletOfManyMinionsMod, "GraniteSpark", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.amuletOfManyMinionsMod, "InertCombatPetFriendshipBow", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.amuletOfManyMinionsMod, "GuideHair", Item.buyPrice(gold: 1), ModConditions.DownedLunarEvent)
            //Assorted Crazy Things
                .AddModItemToShop(ModConditions.assortedCrazyThingsMod, "ChunkysEyeItem", Item.buyPrice(gold: 1), ModConditions.HasBeenToEvil)
                .AddModItemToShop(ModConditions.assortedCrazyThingsMod, "CaughtDungeonSoulFreed", Item.buyPrice(gold: 1), ModConditions.DownedSoulHarvester, ModConditions.HasBeenToDungeon)
                .AddModItemToShop(ModConditions.assortedCrazyThingsMod, "DesiccatedLeather", Item.buyPrice(gold: 1), ModConditions.DownedSoulHarvester, ModConditions.HasBeenToDungeon)
                .AddModItemToShop(ModConditions.assortedCrazyThingsMod, "DroneParts", Item.buyPrice(gold: 1), Condition.DownedDestroyer)
                .AddModItemToShop(ModConditions.assortedCrazyThingsMod, "MeatballsEyeItem", Item.buyPrice(gold: 1), ModConditions.HasBeenToEvil)
            //Bombus Apis
                .AddModItemToShop(ModConditions.bombusApisMod, "PhotonFragment", Item.buyPrice(gold: 1), ModConditions.DownedLunarPillarAny)
                .AddModItemToShop(ModConditions.bombusApisMod, "Pollen", Item.buyPrice(gold: 1))
            //Calamity
                .AddModItemToShop(ModConditions.calamityMod, "AncientBoneDust", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.calamityMod, "ArmoredShell", Item.buyPrice(gold: 1), ModConditions.DownedStormWeaver)
                .AddModItemToShop(ModConditions.calamityMod, "AshesofAnnihilation", Item.buyPrice(gold: 1), ModConditions.DownedSupremeCalamitas)
                .AddModItemToShop(ModConditions.calamityMod, "AshesofCalamity", Item.buyPrice(gold: 1), ModConditions.DownedCalamitasClone)
                .AddModItemToShop(ModConditions.calamityMod, "BeetleJuice", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.calamityMod, "BlightedGel", Item.buyPrice(gold: 1), ModConditions.HasBeenToEvil)
                .AddModItemToShop(ModConditions.calamityMod, "BloodOrb", Item.buyPrice(gold: 1), ModConditions.DownedBloodMoon)
                .AddModItemToShop(ModConditions.calamityMod, "BloodSample", Item.buyPrice(gold: 1), ModConditions.DownedPerforators)
                .AddModItemToShop(ModConditions.calamityMod, "Bloodstone", Item.buyPrice(gold: 1), ModConditions.DownedProvidence)
                .AddModItemToShop(ModConditions.calamityMod, "CorrodedFossil", Item.buyPrice(gold: 1), ModConditions.DownedAcidRain2)
                .AddModItemToShop(ModConditions.calamityMod, "DarkPlasma", Item.buyPrice(gold: 1), ModConditions.DownedCeaselessVoid)
                .AddModItemToShop(ModConditions.calamityMod, "DarksunFragment", Item.buyPrice(gold: 1), ModConditions.DownedDevourerOfGods)
                .AddModItemToShop(ModConditions.calamityMod, "DepthCells", Item.buyPrice(gold: 1), ModConditions.DownedCalamitasClone)
                .AddModItemToShop(ModConditions.calamityMod, "DemonicBoneAsh", Item.buyPrice(gold: 1), ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.calamityMod, "DivineGeode", Item.buyPrice(gold: 1), ModConditions.DownedProvidence)
                .AddModItemToShop(ModConditions.calamityMod, "DubiousPlating", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.calamityMod, "EffulgentFeather", Item.buyPrice(gold: 1), ModConditions.DownedDragonfolly)
                .AddModItemToShop(ModConditions.calamityMod, "EndothermicEnergy", Item.buyPrice(gold: 1), ModConditions.DownedDevourerOfGods)
                .AddModItemToShop(ModConditions.calamityMod, "EnergyCore", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.calamityMod, "EssenceofChaos", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToCrags)
                .AddModItemToShop(ModConditions.calamityMod, "EssenceofEleum", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToSnow)
                .AddModItemToShop(ModConditions.calamityMod, "EssenceofSunlight", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToSky)
                .AddModItemToShop(ModConditions.calamityMod, "ExoPrism", Item.buyPrice(gold: 1), ModConditions.DownedExoMechs)
                .AddModItemToShop(ModConditions.calamityMod, "GrandScale", Item.buyPrice(gold: 1), ModConditions.DownedGreatSandShark)
                .AddModItemToShop(ModConditions.calamityMod, "InfectedArmorPlating", Item.buyPrice(gold: 1), ModConditions.DownedPlaguebringerGoliath)
                .AddModItemToShop(ModConditions.calamityMod, "LivingShard", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(ModConditions.calamityMod, "Lumenyl", Item.buyPrice(gold: 1), ModConditions.DownedCalamitasClone)
                .AddModItemToShop(ModConditions.calamityMod, "MeldBlob", Item.buyPrice(gold: 1), ModConditions.DownedLunarPillarAny)
                .AddModItemToShop(ModConditions.calamityMod, "MolluskHusk", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.DownedGiantClam)
                .AddModItemToShop(ModConditions.calamityMod, "MurkyPaste", Item.buyPrice(gold: 1), ModConditions.HasBeenToJungle)
                .AddModItemToShop(ModConditions.calamityMod, "MysteriousCircuitry", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.calamityMod, "NightmareFuel", Item.buyPrice(gold: 1), ModConditions.DownedDevourerOfGods)
                .AddModItemToShop(ModConditions.calamityMod, "PearlShard", Item.buyPrice(gold: 1), ModConditions.DownedDesertScourge)
                .AddModItemToShop(ModConditions.calamityMod, "Polterplasm", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(ModConditions.calamityMod, "PlagueCellCanister", Item.buyPrice(gold: 1), Condition.DownedGolem)
                .AddModItemToShop(ModConditions.calamityMod, "PurifiedGel", Item.buyPrice(gold: 1), ModConditions.DownedSlimeGod)
                .AddModItemToShop(ModConditions.calamityMod, "ReaperTooth", Item.buyPrice(gold: 1), ModConditions.DownedPolterghast)
                .AddModItemToShop(ModConditions.calamityMod, "RottenMatter", Item.buyPrice(gold: 1), ModConditions.DownedHiveMind)
                .AddModItemToShop(ModConditions.calamityMod, "RuinousSoul", Item.buyPrice(gold: 1), ModConditions.DownedPolterghast)
                .AddModItemToShop(ModConditions.calamityMod, "SolarVeil", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(ModConditions.calamityMod, "StormlionMandible", Item.buyPrice(gold: 1), ModConditions.HasBeenToDesert)
                .AddModItemToShop(ModConditions.calamityMod, "Stardust", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToAstral)
                .AddModItemToShop(ModConditions.calamityMod, "SulphuricScale", Item.buyPrice(gold: 1), ModConditions.DownedAcidRain1)
                .AddModItemToShop(ModConditions.calamityMod, "TrapperBulb", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToJungle)
                .AddModItemToShop(ModConditions.calamityMod, "TwistingNether", Item.buyPrice(gold: 1), ModConditions.DownedSignus)
                .AddModItemToShop(ModConditions.calamityMod, "UnholyEssence", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(ModConditions.calamityMod, "WulfrumMetalScrap", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.calamityMod, "YharonSoulFragment", Item.buyPrice(gold: 1), ModConditions.DownedYharon)
            //Clamity
                .AddModItemToShop(ModConditions.clamityAddonMod, "ClamitousPearl", Item.buyPrice(gold: 1), ModConditions.DownedClamitas)
                .AddModItemToShop(ModConditions.clamityAddonMod, "HuskOfCalamity", Item.buyPrice(gold: 1), ModConditions.DownedClamitas)
            //Clicker Class
                .AddModItemToShop(ModConditions.clickerClassMod, "MiceFragment", Item.buyPrice(gold: 1), ModConditions.DownedLunarPillarAny)
            //Confection
                .AddModItemToShop(ModConditions.confectionRebakedMod, "CanofMeat", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToEvil)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "CookieDough", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToConfectionOrHallow)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "SoulofDelight", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToConfectionOrHallow)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "SoulofSpite", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToEvil)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "Sprinkles", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToConfectionOrHallow)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "YumDrop", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToConfectionOrHallow)
            //Consolaria
                .AddModItemToShop(ModConditions.consolariaMod, "RainbowPiece", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.consolariaMod, "SoulofBlight", Item.buyPrice(gold: 1), ModConditions.DownedOcram)
                .AddModItemToShop(ModConditions.consolariaMod, "WhiteThread", Item.buyPrice(gold: 1))
            //Depths
                .AddModItemToShop(ModConditions.depthsMod, "DiamondDust", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.depthsMod, "Ember", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.depthsMod, "Geode", Item.buyPrice(gold: 1), ModConditions.HasBeenToDepthsOrUnderworld)
            //Echoes
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "BetsyScale", Item.buyPrice(gold: 1), Condition.DownedOldOnesArmyT3)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "Broken_Hero_GunParts", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "CorruptShard", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "Cosmic_Essence", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "Crimson_Stone", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "Divine_Fragment", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "Duskbulb", Item.buyPrice(gold: 1), ModConditions.DownedDestruction)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "Enkin", Item.buyPrice(gold: 1), ModConditions.DownedDestruction)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "CosmicFabric", Item.buyPrice(gold: 1), ModConditions.DownedDestruction)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "GenocideCore", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "Hallow_Stone", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "Hell_Stone", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "Ice_Stone", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "InfinityCrystal", Item.buyPrice(gold: 1), ModConditions.DownedDestruction, ModConditions.DownedCreation)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "InfinityGeode", Item.buyPrice(gold: 1), ModConditions.DownedCreation)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "Jungle_Stone", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "LunarSilk", Item.buyPrice(gold: 1), Condition.DownedCultist)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "Purity_Stone", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "Relic_Fragment", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "Sand_Stone", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "SingularityCatalyst", Item.buyPrice(gold: 1), ModConditions.DownedCreation)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "Stardust", Item.buyPrice(gold: 1), ModConditions.DownedDestruction)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "SunstruckEssence", Item.buyPrice(gold: 1), ModConditions.DownedGalahis)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "Tungqua", Item.buyPrice(gold: 1), ModConditions.DownedCreation)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "Underground_Stone", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "Water_Stone", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "Wyvernscale", Item.buyPrice(gold: 1), Condition.Hardmode)
            //Edorbis
                .AddModItemToShop(ModConditions.edorbisMod, "Battery", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.edorbisMod, "BrokenDamocles", Item.buyPrice(gold: 1), ModConditions.DownedGlaciation)
                .AddModItemToShop(ModConditions.edorbisMod, "CentauriumBattery", Item.buyPrice(gold: 1), Condition.DownedCultist)
                .AddModItemToShop(ModConditions.edorbisMod, "ChlorophyteWire", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(ModConditions.edorbisMod, "DarkDust", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.edorbisMod, "DiscordShard", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.edorbisMod, "ElectrostaticSilk", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.edorbisMod, "FishronScale", Item.buyPrice(gold: 1), Condition.DownedDukeFishron)
                .AddModItemToShop(ModConditions.edorbisMod, "GlaciationPlating", Item.buyPrice(gold: 1), ModConditions.DownedGlaciation)
                .AddModItemToShop(ModConditions.edorbisMod, "HighTechSalvages", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(ModConditions.edorbisMod, "MetalSalvages", Item.buyPrice(gold: 1), Condition.DownedGoblinArmy)
                .AddModItemToShop(ModConditions.edorbisMod, "MetalWire", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.edorbisMod, "SoulOfFight", Item.buyPrice(gold: 1), ModConditions.DownedCursePreacher)
            //Exalt
                .AddModItemToShop(ModConditions.exaltMod, "DragonScale", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(ModConditions.exaltMod, "IceCrystal", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(ModConditions.exaltMod, "Leaf", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.exaltMod, "Membrane", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.exaltMod, "Paper", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.exaltMod, "Remnant", Item.buyPrice(gold: 1), ModConditions.DownedIceLich)
                .AddModItemToShop(ModConditions.exaltMod, "TwistedFlesh", Item.buyPrice(gold: 1), ModConditions.DownedBloodMoon, Condition.DownedSkeletron)
                .AddModItemToShop(ModConditions.exaltMod, "Vescon", Item.buyPrice(gold: 1), Condition.DownedCultist)
            //Fargos
                .AddModItemToShop(ModConditions.fargosSoulsMod, "AbomEnergy", Item.buyPrice(gold: 1), ModConditions.DownedAbominationn)
                .AddModItemToShop(ModConditions.fargosSoulsMod, "DeviatingEnergy", Item.buyPrice(gold: 1), ModConditions.DownedDeviantt)
                .AddModItemToShop(ModConditions.fargosSoulsMod, "Eridanium", Item.buyPrice(gold: 1), ModConditions.DownedEridanus)
                .AddModItemToShop(ModConditions.fargosSoulsMod, "EternalEnergy", Item.buyPrice(gold: 1), ModConditions.DownedMutant)
            //Furniture Food & Fun
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "WeirdlyColoredPetal", Item.buyPrice(gold: 1))
            //GaMeTerraria
                .AddModItemToShop(ModConditions.gameTerrariaMod, "ChargedScale", Item.buyPrice(gold: 1), ModConditions.DownedHornlitz)
            //Gensokyo
                .AddModItemToShop(ModConditions.gensokyoMod, "KappaTech", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.gensokyoMod, "YamawaroTech", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.gensokyoMod, "PointItem", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.gensokyoMod, "PowerItem", Item.buyPrice(gold: 1), ModConditions.DownedLilyWhite)
            //Gerds
                .AddModItemToShop(ModConditions.gerdsLabMod, "UpgradeCrystal", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.gerdsLabMod, "AlloyBox", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.gerdsLabMod, "BossUpgradeCrystal", Item.buyPrice(gold: 1), Condition.DownedEyeOfCthulhu)
                .AddModItemToShop(ModConditions.gerdsLabMod, "ScrapFragment", Item.buyPrice(gold: 1), ModConditions.DownedAcheron)
                .AddModItemToShop(ModConditions.gerdsLabMod, "HardmodeUpgradeCrystal", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(ModConditions.gerdsLabMod, "SpecialUpgradeCrystal", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
            //Heartbeataria
                .AddModItemToShop(ModConditions.heartbeatariaMod, "DreadFangs", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.heartbeatariaMod, "FilthySap", Item.buyPrice(gold: 1), Condition.DownedSkeletron)
                .AddModItemToShop(ModConditions.heartbeatariaMod, "FusionModule", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.heartbeatariaMod, "GelOfCthulhu", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.heartbeatariaMod, "GreenScales", Item.buyPrice(gold: 1), Condition.DownedEyeOfCthulhu)
                .AddModItemToShop(ModConditions.heartbeatariaMod, "MagmaShell", Item.buyPrice(gold: 1), Condition.Hardmode) 
            //Homeward
                .AddModItemToShop(ModConditions.homewardJourneyMod, "AbyssFragment", Item.buyPrice(gold: 1), ModConditions.DownedDiver)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "AnglerCoin", Item.buyPrice(gold: 1), ModConditions.HasBeenToOcean)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "AnglerGoldCoin", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToOcean)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "Blood", Item.buyPrice(gold: 1), ModConditions.DownedBloodMoon)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "CoffeeBean_1", Item.buyPrice(gold: 1), ModConditions.DownedOverwatcher, ModConditions.DownedMaterealizer, ModConditions.DownedLifebringer)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "CoffeeBean_2", Item.buyPrice(gold: 1), ModConditions.DownedOverwatcher, ModConditions.DownedMaterealizer, ModConditions.DownedLifebringer)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "DenseIcicle", Item.buyPrice(gold: 1), ModConditions.DownedWallOfShadow)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "DivineShard", Item.buyPrice(gold: 1), ModConditions.DownedWallOfShadow)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "EssenceofBright", Item.buyPrice(gold: 1), ModConditions.DownedSon)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "EssenceofLife", Item.buyPrice(gold: 1), ModConditions.DownedLifebringer)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "EssenceofMatter", Item.buyPrice(gold: 1), ModConditions.DownedMaterealizer)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "EssenceofNothingness", Item.buyPrice(gold: 1), ModConditions.DownedScarabBelief)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "EssenceofTime", Item.buyPrice(gold: 1), ModConditions.DownedOverwatcher)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "EssenceofDeath", Item.buyPrice(gold: 1), ModConditions.DownedWorldsEndWhale)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "JungleDewdrop", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "NetherStar", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "SolarFlareScoria", Item.buyPrice(gold: 1), ModConditions.DownedSunSlimeGod)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "SoulofBlight", Item.buyPrice(gold: 1), ModConditions.DownedMotherbrain)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "SpiralTissue", Item.buyPrice(gold: 1), ModConditions.DownedWallOfShadow)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "SteelFeather", Item.buyPrice(gold: 1), ModConditions.DownedWallOfShadow)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "SunlightGel", Item.buyPrice(gold: 1), ModConditions.DownedWallOfShadow)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "CoffeeBean_3", Item.buyPrice(gold: 1), ModConditions.DownedOverwatcher, ModConditions.DownedMaterealizer, ModConditions.DownedLifebringer)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "TankOfThePastCave", Item.buyPrice(gold: 1), ModConditions.DownedCaveOrdeal)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "TankOfThePastCorruption", Item.buyPrice(gold: 1), ModConditions.DownedCorruptOrdeal)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "TankOfThePastCrimson", Item.buyPrice(gold: 1), ModConditions.DownedCrimsonOrdeal)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "TankOfThePastDesert", Item.buyPrice(gold: 1), ModConditions.DownedDesertOrdeal)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "TankOfThePastForest", Item.buyPrice(gold: 1), ModConditions.DownedForestOrdeal)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "TankOfThePastHallow", Item.buyPrice(gold: 1), ModConditions.DownedHallowOrdeal)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "TankOfThePastJungle", Item.buyPrice(gold: 1), ModConditions.DownedJungleOrdeal)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "TankOfThePastSky", Item.buyPrice(gold: 1), ModConditions.DownedSkyOrdeal)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "TankOfThePastSnowland", Item.buyPrice(gold: 1), ModConditions.DownedSnowOrdeal)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "TankOfThePastUnderworld", Item.buyPrice(gold: 1), ModConditions.DownedUnderworldOrdeal)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "TrueJungleSpore", Item.buyPrice(gold: 1), ModConditions.DownedWallOfShadow)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "CoffeeBean_4", Item.buyPrice(gold: 1), ModConditions.DownedOverwatcher, ModConditions.DownedMaterealizer, ModConditions.DownedLifebringer)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "WillToCorrode", Item.buyPrice(gold: 1), ModConditions.DownedOverwatcher, ModConditions.DownedMaterealizer, ModConditions.DownedLifebringer)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "WillToCrown", Item.buyPrice(gold: 1), ModConditions.DownedOverwatcher, ModConditions.DownedMaterealizer, ModConditions.DownedLifebringer)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "WillToGrow", Item.buyPrice(gold: 1), ModConditions.DownedOverwatcher, ModConditions.DownedMaterealizer, ModConditions.DownedLifebringer)
            //Hunt of the Old God
                .AddModItemToShop(ModConditions.huntOfTheOldGodMod, "ChromaticMass", Item.buyPrice(gold: 1), ModConditions.DownedGoozma)
            //Magic Storage
                .AddModItemToShop(ModConditions.magicStorageMod, "ShadowDiamond", Item.buyPrice(gold: 1), Condition.DownedEyeOfCthulhu)
                .AddModItemToShop(ModConditions.magicStorageMod, "RadiantJewel", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
            //Mech Rework
                .AddModItemToShop(ModConditions.mechReworkMod, "SoulofFreight", Item.buyPrice(gold: 1), ModConditions.DownedSt4sys)
                .AddModItemToShop(ModConditions.mechReworkMod, "SoulofPlight", Item.buyPrice(gold: 1), ModConditions.DownedTerminator)
                .AddModItemToShop(ModConditions.mechReworkMod, "SoulofDight", Item.buyPrice(gold: 1), ModConditions.DownedCaretaker)
                .AddModItemToShop(ModConditions.mechReworkMod, "SoulofTight", Item.buyPrice(gold: 1), ModConditions.DownedSiegeEngine)
            //Polarities
                .AddModItemToShop(ModConditions.polaritiesMod, "AlkalineFluid", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.polaritiesMod, "CongealedBrine", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.polaritiesMod, "EvilDNA", Item.buyPrice(gold: 1), ModConditions.DownedEsophage)
                .AddModItemToShop(ModConditions.polaritiesMod, "LimestoneCarapace", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.polaritiesMod, "Rattle", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.polaritiesMod, "SaltCrystals", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.polaritiesMod, "SerpentScale", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.polaritiesMod, "StormChunk", Item.buyPrice(gold: 1), ModConditions.DownedStormCloudfish)
                .AddModItemToShop(ModConditions.polaritiesMod, "Tentacle", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.polaritiesMod, "VenomGland", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.polaritiesMod, "WandererPlating", Item.buyPrice(gold: 1), ModConditions.DownedConvectiveWanderer)
            //Qwerty
                .AddModItemToShop(ModConditions.qwertyMod, "CraftingRune", Item.buyPrice(gold: 1), ModConditions.DownedRuneGhost)
                .AddModItemToShop(ModConditions.qwertyMod, "Etims", Item.buyPrice(gold: 1), ModConditions.DownedNoehtnap)
                .AddModItemToShop(ModConditions.qwertyMod, "FortressHarpyBeak", Item.buyPrice(gold: 1), ModConditions.HasBeenToSkyFortress)
                .AddModItemToShop(ModConditions.qwertyMod, "HydraScale", Item.buyPrice(gold: 1), ModConditions.DownedHydra)
                .AddModItemToShop(ModConditions.qwertyMod, "InvaderPlating", Item.buyPrice(gold: 1), ModConditions.DownedInvaders)
                .AddModItemToShop(ModConditions.qwertyMod, "CaeliteCore", Item.buyPrice(gold: 1), ModConditions.DownedDivineLight)
                .AddModItemToShop(ModConditions.qwertyMod, "SoulOfHeight", Item.buyPrice(gold: 1), ModConditions.DownedInvaders)
            //Redemption
                .AddModItemToShop(ModConditions.redemptionMod, "AIChip", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.redemptionMod, "CarbonMyofibre", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.redemptionMod, "Capacitator", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.redemptionMod, "CoastScarabShell", Item.buyPrice(gold: 1), ModConditions.HasBeenToOcean)
                .AddModItemToShop(ModConditions.redemptionMod, "GildedStar", Item.buyPrice(gold: 1), ModConditions.DownedAncientDeityDuo)
                .AddModItemToShop(ModConditions.redemptionMod, "GrimShard", Item.buyPrice(gold: 1), ModConditions.DownedKeeper)
                .AddModItemToShop(ModConditions.redemptionMod, "LifeFragment", Item.buyPrice(gold: 1), ModConditions.DownedNebuleus)
                .AddModItemToShop(ModConditions.redemptionMod, "LostSoul", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.redemptionMod, "MoonflareFragment", Item.buyPrice(gold: 1), ModConditions.HasBeenThroughNight)
                .AddModItemToShop(ModConditions.redemptionMod, "Plating", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.redemptionMod, "ToxicBile", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToWasteland)
                .AddModItemToShop(ModConditions.redemptionMod, "TreeBugShell", Item.buyPrice(gold: 1))
            //SOTS
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "CursedMatter", Item.buyPrice(gold: 1), ModConditions.DownedPharaohsCurse, ModConditions.HasBeenToPyramid)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "DissolvingAether", Item.buyPrice(gold: 1), ModConditions.DownedAdvisor, ModConditions.HasBeenToPlanetarium)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "DissolvingAurora", Item.buyPrice(gold: 1), ModConditions.DownedPermafrostSpirit, ModConditions.HasBeenToSnow)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "DissolvingBrilliance", Item.buyPrice(gold: 1), ModConditions.DownedLux, ModConditions.HasBeenToHallow)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "DissolvingDeluge", Item.buyPrice(gold: 1), ModConditions.DownedTidalSpirit, ModConditions.HasBeenToOcean)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "DissolvingEarth", Item.buyPrice(gold: 1), ModConditions.DownedEarthenSpirit, ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "DissolvingNature", Item.buyPrice(gold: 1), ModConditions.DownedNatureSpirit)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "DissolvingNether", Item.buyPrice(gold: 1), ModConditions.DownedInfernoSpirit, ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "DissolvingUmbra", Item.buyPrice(gold: 1), ModConditions.DownedEvilSpirit, ModConditions.HasBeenToEvil)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "FragmentOfChaos", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToHallow)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "FragmentOfEarth", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "FragmentOfEvil", Item.buyPrice(gold: 1), ModConditions.HasBeenToEvil)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "FragmentOfInferno", Item.buyPrice(gold: 1), ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "FragmentOfNature", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "FragmentOfOtherworld", Item.buyPrice(gold: 1), ModConditions.HasBeenToPlanetarium)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "FragmentOfPermafrost", Item.buyPrice(gold: 1), ModConditions.HasBeenToSnow)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "FragmentOfTide", Item.buyPrice(gold: 1), ModConditions.HasBeenToOcean)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "Peanut", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "SanguiteBar", Item.buyPrice(gold: 1), ModConditions.DownedSubspaceSerpent)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "Snakeskin", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc, ModConditions.HasBeenToPyramid)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "SoulResidue", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc, ModConditions.HasBeenToPyramid)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "TwilightGel", Item.buyPrice(gold: 1), ModConditions.HasBeenToPlanetarium)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "TwilightShard", Item.buyPrice(gold: 1), ModConditions.DownedAdvisor)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "VialofAcid", Item.buyPrice(gold: 1), ModConditions.DownedPutridPinky)
            //Spirit
                .AddModItemToShop(ModConditions.spiritMod, "Rune", Item.buyPrice(gold: 1), Condition.DownedMechBossAny, ModConditions.HasBeenToSpirit)
                .AddModItemToShop(ModConditions.spiritMod, "ArcaneGeyser", Item.buyPrice(gold: 1), ModConditions.DownedAtlas)
                .AddModItemToShop(ModConditions.spiritMod, "MoonStone", Item.buyPrice(gold: 1), ModConditions.DownedMysticMoon)
                .AddModItemToShop(ModConditions.spiritMod, "BismiteCrystal", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.spiritMod, "Brightbulb", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.spiritMod, "Chitin", Item.buyPrice(gold: 1), ModConditions.DownedScarabeus)
                .AddModItemToShop(ModConditions.spiritMod, "DeepCascadeShard", Item.buyPrice(gold: 1), ModConditions.HasBeenToOcean)
                .AddModItemToShop(ModConditions.spiritMod, "SynthMaterial", Item.buyPrice(gold: 1), Condition.DownedGoblinArmy)
                .AddModItemToShop(ModConditions.spiritMod, "DuskStone", Item.buyPrice(gold: 1), ModConditions.DownedDusking)
                .AddModItemToShop(ModConditions.spiritMod, "DreamstrideEssence", Item.buyPrice(gold: 1), ModConditions.DownedBloodMoon)
                .AddModItemToShop(ModConditions.spiritMod, "EmptyCodex", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.spiritMod, "StarEnergy", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.spiritMod, "FrigidFragment", Item.buyPrice(gold: 1), ModConditions.HasBeenToSnow)
                .AddModItemToShop(ModConditions.spiritMod, "GranitechMaterial", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.spiritMod, "HeartScale", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.spiritMod, "IridescentScale", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.spiritMod, "NetherCrystal", Item.buyPrice(gold: 1), Condition.DownedMechBossAny, ModConditions.HasBeenToSpirit)
                .AddModItemToShop(ModConditions.spiritMod, "OldLeather", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.spiritMod, "CarvedRock", Item.buyPrice(gold: 1), Condition.DownedSkeletron, ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.spiritMod, "InfernalAppendage", Item.buyPrice(gold: 1), ModConditions.DownedInfernon)
                .AddModItemToShop(ModConditions.spiritMod, "TribalScale", Item.buyPrice(gold: 1), ModConditions.DownedTide)
                .AddModItemToShop(ModConditions.spiritMod, "SoulShred", Item.buyPrice(gold: 1), Condition.DownedMechBossAny, ModConditions.HasBeenToSpirit)
                .AddModItemToShop(ModConditions.spiritMod, "SulfurDeposit", Item.buyPrice(gold: 1), ModConditions.HasBeenToOcean)
                .AddModItemToShop(ModConditions.spiritMod, "TechDrive", Item.buyPrice(gold: 1), Condition.DownedGoblinArmy)
            //Spooky
                .AddModItemToShop(ModConditions.spookyMod, "ArteryPiece", Item.buyPrice(gold: 1), ModConditions.DownedOrroBoro)
                .AddModItemToShop(ModConditions.spookyMod, "RottenChunk", Item.buyPrice(gold: 1), ModConditions.DownedRotGourd)
                .AddModItemToShop(ModConditions.spookyMod, "CreepyChunk", Item.buyPrice(gold: 1), ModConditions.HasBeenToEyeValley)
                .AddModItemToShop(ModConditions.spookyMod, "PlantChunk", Item.buyPrice(gold: 1), ModConditions.DownedDaffodil)
                .AddModItemToShop(ModConditions.spookyMod, "SentientHeart", Item.buyPrice(gold: 1), ModConditions.DownedMoco)
            //Starlight River
                .AddModItemToShop(ModConditions.starlightRiverMod, "SandstoneChunk", Item.buyPrice(gold: 1), ModConditions.HasBeenToVitricDesert)
                .AddModItemToShop(ModConditions.starlightRiverMod, "AncientGear", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.starlightRiverMod, "Astroscrap", Item.buyPrice(gold: 1), ModConditions.DownedCeiros)
                .AddModItemToShop(ModConditions.starlightRiverMod, "ExoticGeodeArtifactItem", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.starlightRiverMod, "LivingBlood", Item.buyPrice(gold: 1), ModConditions.DownedBloodMoon)
                .AddModItemToShop(ModConditions.starlightRiverMod, "MagmaCore", Item.buyPrice(gold: 1), ModConditions.DownedCeiros)
                .AddModItemToShop(ModConditions.starlightRiverMod, "StaminaGel", Item.buyPrice(gold: 1), ModConditions.DownedCeiros)
                .AddModItemToShop(ModConditions.starlightRiverMod, "VengefulSpirit", Item.buyPrice(gold: 1), Condition.DownedEyeOfCthulhu)
                .AddModItemToShop(ModConditions.starlightRiverMod, "VitricOre", Item.buyPrice(gold: 1), ModConditions.HasBeenToVitricDesert, ModConditions.DownedCeiros)
            //Stars Above
                .AddModItemToShop(ModConditions.starsAboveMod, "BandedTenebrium", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.starsAboveMod, "EnigmaticDust", Item.buyPrice(gold: 1), ModConditions.DownedVagrantofSpace)
                .AddModItemToShop(ModConditions.starsAboveMod, "InertShard", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.starsAboveMod, "PrismaticCore", Item.buyPrice(gold: 1), ModConditions.DownedVagrantofSpace)
                .AddModItemToShop(ModConditions.starsAboveMod, "StellarRemnant", Item.buyPrice(gold: 1), Condition.DownedEyeOfCthulhu)
            //Storms
                .AddModItemToShop(ModConditions.stormsAdditionsMod, "BloodDrop", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc, ModConditions.DownedBloodMoon)
                .AddModItemToShop(ModConditions.stormsAdditionsMod, "CrackedHeart", Item.buyPrice(gold: 1), ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.stormsAdditionsMod, "ChaosShard", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToHallow)
                .AddModItemToShop(ModConditions.stormsAdditionsMod, "DerplingShell", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(ModConditions.stormsAdditionsMod, "GraniteCore", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.stormsAdditionsMod, "SoulFire", Item.buyPrice(gold: 1), Condition.DownedMechBossAny, ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.stormsAdditionsMod, "BlueCloth", Item.buyPrice(gold: 1), ModConditions.HasBeenToSnow)
                .AddModItemToShop(ModConditions.stormsAdditionsMod, "SantankScrap", Item.buyPrice(gold: 1), Condition.DownedSantaNK1)
                .AddModItemToShop(ModConditions.stormsAdditionsMod, "RedSilk", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
            //Supernova
                .AddModItemToShop(ModConditions.supernovaMod, "BloodShards", Item.buyPrice(gold: 1), ModConditions.DownedBloodMoon)
                .AddModItemToShop(ModConditions.supernovaMod, "BoneFragment", Item.buyPrice(gold: 1), Condition.DownedEyeOfCthulhu)
                .AddModItemToShop(ModConditions.supernovaMod, "FirearmManual", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.supernovaMod, "GoldenRingMold", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.supernovaMod, "QuarionShard", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.supernovaMod, "Rime", Item.buyPrice(gold: 1), Condition.DownedQueenBee)
                .AddModItemToShop(ModConditions.supernovaMod, "TerrorTuft", Item.buyPrice(gold: 1), ModConditions.DownedFlyingTerror)
            //Terrorborn
                .AddModItemToShop(ModConditions.terrorbornMod, "DreadfulEssence", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.terrorbornMod, "FusionFragment", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.terrorbornMod, "HellbornEssence", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.terrorbornMod, "HexingEssence", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.terrorbornMod, "IncendiusAlloy", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.terrorbornMod, "NoxiousScale", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.terrorbornMod, "SanguineFang", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.terrorbornMod, "ShellFragments", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.terrorbornMod, "SoulOfPlight", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.terrorbornMod, "TerrorSample", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.terrorbornMod, "ThunderShard", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.terrorbornMod, "TorturedEssence", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.terrorbornMod, "TarOfHunger", Item.buyPrice(gold: 1))
            //Thorium
                .AddModItemToShop(ModConditions.thoriumMod, "AbyssalChitin", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToAquaticDepths)
                .AddModItemToShop(ModConditions.thoriumMod, "BioMatter", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToJungle)
                .AddModItemToShop(ModConditions.thoriumMod, "BirdTalon", Item.buyPrice(gold: 1), ModConditions.HasBeenToDesert)
                .AddModItemToShop(ModConditions.thoriumMod, "Blood", Item.buyPrice(gold: 1), ModConditions.DownedBloodMoon)
                .AddModItemToShop(ModConditions.thoriumMod, "BloomWeave", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(ModConditions.thoriumMod, "BrokenHeroFragment", Item.buyPrice(gold: 1), Condition.DownedPlantera, ModConditions.DownedEclipse)
                .AddModItemToShop(ModConditions.thoriumMod, "BronzeFragments", Item.buyPrice(gold: 1), Condition.DownedSkeletron, ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.thoriumMod, "CelestialFragment", Item.buyPrice(gold: 1), ModConditions.DownedLunarPillarAny)
                .AddModItemToShop(ModConditions.thoriumMod, "CeruleanMorel", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToMushroom)
                .AddModItemToShop(ModConditions.thoriumMod, "CursedCloth", Item.buyPrice(gold: 1), ModConditions.DownedLich)
                .AddModItemToShop(ModConditions.thoriumMod, "DarkMatter", Item.buyPrice(gold: 1), Condition.DownedPlantera, ModConditions.HasBeenToDungeon)
                .AddModItemToShop(ModConditions.thoriumMod, "DeathEssence", Item.buyPrice(gold: 1), ModConditions.DownedPrimordials)
                .AddModItemToShop(ModConditions.thoriumMod, "DemonBloodShard", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(ModConditions.thoriumMod, "DepthScale", Item.buyPrice(gold: 1), ModConditions.HasBeenToAquaticDepths)
                .AddModItemToShop(ModConditions.thoriumMod, "DreadSoul", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(ModConditions.thoriumMod, "Geode", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToHallow)
                .AddModItemToShop(ModConditions.thoriumMod, "GraniteEnergyCore", Item.buyPrice(gold: 1), Condition.DownedSkeletron, ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.thoriumMod, "GreenDragonScale", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToEvil)
                .AddModItemToShop(ModConditions.thoriumMod, "HallowedCharm", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToHallow)
                .AddModItemToShop(ModConditions.thoriumMod, "HolyKnightsAlloy", Item.buyPrice(gold: 1), Condition.DownedPlantera, ModConditions.HasBeenToDungeon)
                .AddModItemToShop(ModConditions.thoriumMod, "IcyShard", Item.buyPrice(gold: 1), ModConditions.HasBeenToSnow)
                .AddModItemToShop(ModConditions.thoriumMod, "InfernoEssence", Item.buyPrice(gold: 1), ModConditions.DownedPrimordials)
                .AddModItemToShop(ModConditions.thoriumMod, "LifeCell", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(ModConditions.thoriumMod, "LivingLeaf", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.thoriumMod, "OceanEssence", Item.buyPrice(gold: 1), ModConditions.DownedPrimordials)
                .AddModItemToShop(ModConditions.thoriumMod, "Petal", Item.buyPrice(gold: 1), ModConditions.HasBeenToJungle)
                .AddModItemToShop(ModConditions.thoriumMod, "PharaohsBreath", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToDesert)
                .AddModItemToShop(ModConditions.thoriumMod, "PurityShards", Item.buyPrice(gold: 1), ModConditions.DownedBloodMoon)
                .AddModItemToShop(ModConditions.thoriumMod, "ShootingStarFragment", Item.buyPrice(gold: 1), ModConditions.DownedLunarPillarAny)
                .AddModItemToShop(ModConditions.thoriumMod, "StrangeAlienTech", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.thoriumMod, "StrangePlating", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(ModConditions.thoriumMod, "SolarPebble", Item.buyPrice(gold: 1), Condition.DownedPlantera, ModConditions.HasBeenToTemple)
                .AddModItemToShop(ModConditions.thoriumMod, "SoulofPlight", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.thoriumMod, "SpiritDroplet", Item.buyPrice(gold: 1), Condition.DownedSkeletron, ModConditions.HasBeenToDungeon)
                .AddModItemToShop(ModConditions.thoriumMod, "TerrariumCore", Item.buyPrice(gold: 1), Condition.DownedCultist)
                .AddModItemToShop(ModConditions.thoriumMod, "UnfathomableFlesh", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToEvil)
                .AddModItemToShop(ModConditions.thoriumMod, "UnholyShards", Item.buyPrice(gold: 1), ModConditions.DownedBloodMoon)
                .AddModItemToShop(ModConditions.thoriumMod, "WhiteDwarfFragment", Item.buyPrice(gold: 1), ModConditions.DownedLunarPillarAny)
            //TRAE
                .AddModItemToShop(ModConditions.traeMod, "DriedRose", Item.buyPrice(gold: 1), Condition.DownedPlantera, ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.traeMod, "IceQueenJewel", Item.buyPrice(gold: 1), Condition.DownedIceQueen)
                .AddModItemToShop(ModConditions.traeMod, "GraniteBattery", Item.buyPrice(gold: 1), ModConditions.DownedGraniteOvergrowth, ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.traeMod, "LuminiteFeather", Item.buyPrice(gold: 1), Condition.DownedCultist)
                .AddModItemToShop(ModConditions.traeMod, "MagicalAsh", Item.buyPrice(gold: 1), Condition.DownedPlantera, ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.traeMod, "ObsidianScale", Item.buyPrice(gold: 1), Condition.DownedPlantera, ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.traeMod, "SalamanderTail", Item.buyPrice(gold: 1), Condition.DownedPlantera, ModConditions.HasBeenToUnderworld)
            //Valhalla
                .AddModItemToShop(ModConditions.valhallaMod, "GargoyleFeather", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.valhallaMod, "BrokenGlaive", Item.buyPrice(gold: 1), Condition.DownedPlantera, ModConditions.DownedEclipse)
                .AddModItemToShop(ModConditions.valhallaMod, "BrokenGranitbur", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.valhallaMod, "BrokenPigronWing", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.valhallaMod, "BrokenSpear", Item.buyPrice(gold: 1), Condition.DownedPlantera, ModConditions.DownedEclipse)
                .AddModItemToShop(ModConditions.valhallaMod, "DamagedBook", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.valhallaMod, "EvilIngot", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.valhallaMod, "HiveIngot", Item.buyPrice(gold: 1), Condition.DownedGolem)
                .AddModItemToShop(ModConditions.valhallaMod, "JadeCloth", Item.buyPrice(gold: 1), ModConditions.DownedYurnero)
                .AddModItemToShop(ModConditions.valhallaMod, "PureGoldChunk", Item.buyPrice(gold: 1), Condition.DownedPirates)
                .AddModItemToShop(ModConditions.valhallaMod, "ToxicGel", Item.buyPrice(gold: 1), Condition.Hardmode)
            //Verdant
                .AddModItemToShop(ModConditions.verdantMod, "ApotheoticSoul", Item.buyPrice(gold: 1), Condition.DownedMechBossAll, ModConditions.HasBeenToVerdant)
                .AddModItemToShop(ModConditions.verdantMod, "Lightbulb", Item.buyPrice(gold: 1), ModConditions.HasBeenToVerdant)
                .AddModItemToShop(ModConditions.verdantMod, "LushLeaf", Item.buyPrice(gold: 1), ModConditions.HasBeenToVerdant)
                .AddModItemToShop(ModConditions.verdantMod, "MysteriaClump", Item.buyPrice(gold: 1), ModConditions.HasBeenToVerdant)
                .AddModItemToShop(ModConditions.verdantMod, "PinkPetal", Item.buyPrice(gold: 1), ModConditions.HasBeenToVerdant)
                .AddModItemToShop(ModConditions.verdantMod, "PuffMaterial", Item.buyPrice(gold: 1), ModConditions.HasBeenToVerdant)
                .AddModItemToShop(ModConditions.verdantMod, "RedPetal", Item.buyPrice(gold: 1), ModConditions.HasBeenToVerdant)
                .AddModItemToShop(ModConditions.verdantMod, "WisplantItem", Item.buyPrice(gold: 1), ModConditions.HasBeenToVerdant)
                .AddModItemToShop(ModConditions.verdantMod, "YellowBulb", Item.buyPrice(gold: 1), ModConditions.HasBeenToVerdant)
            //Vitality
                .AddModItemToShop(ModConditions.vitalityMod, "AncientGoldShard", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.vitalityMod, "BloodCandy", Item.buyPrice(gold: 1), ModConditions.DownedLunarPillarAny)
                .AddModItemToShop(ModConditions.vitalityMod, "BloodVial", Item.buyPrice(gold: 1), Condition.DownedEyeOfCthulhu, ModConditions.HasBeenToEvil)
                .AddModItemToShop(ModConditions.vitalityMod, "ChaosCrystal", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToHallow)
                .AddModItemToShop(ModConditions.vitalityMod, "ChaosDust", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToHallow)
                .AddModItemToShop(ModConditions.vitalityMod, "Charcoal", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.vitalityMod, "CloudVapor", Item.buyPrice(gold: 1), ModConditions.DownedStormCloud)
                .AddModItemToShop(ModConditions.vitalityMod, "DarkLeather", Item.buyPrice(gold: 1), ModConditions.HasBeenToEvil)
                .AddModItemToShop(ModConditions.vitalityMod, "Ectosoul", Item.buyPrice(gold: 1), ModConditions.DownedPaladinSpirit, ModConditions.HasBeenToDungeon)
                .AddModItemToShop(ModConditions.vitalityMod, "EquityCore", Item.buyPrice(gold: 1), ModConditions.DownedPaladinSpirit, ModConditions.HasBeenToDungeon)
                .AddModItemToShop(ModConditions.vitalityMod, "EssenceofFire", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.vitalityMod, "EssenceofFrost", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToSnow)
                .AddModItemToShop(ModConditions.vitalityMod, "ForbiddenFeather", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToDesert)
                .AddModItemToShop(ModConditions.vitalityMod, "GlacialChunk", Item.buyPrice(gold: 1), ModConditions.HasBeenToSnow)
                .AddModItemToShop(ModConditions.vitalityMod, "GlowingGranitePowder", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.vitalityMod, "Glowshroom", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToMushroom)
                .AddModItemToShop(ModConditions.vitalityMod, "LivingStick", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.vitalityMod, "Paper", Item.buyPrice(gold: 1), ModConditions.HasBeenToJungle)
                .AddModItemToShop(ModConditions.vitalityMod, "PurifiedSpore", Item.buyPrice(gold: 1), ModConditions.HasBeenToJungle)
                .AddModItemToShop(ModConditions.vitalityMod, "SanguineVial", Item.buyPrice(gold: 1), ModConditions.DownedBloodMoon)
                .AddModItemToShop(ModConditions.vitalityMod, "ShiverFragment", Item.buyPrice(gold: 1), Condition.DownedEverscream, Condition.DownedSantaNK1, Condition.DownedIceQueen)
                .AddModItemToShop(ModConditions.vitalityMod, "SoulofVitality", Item.buyPrice(gold: 1), Condition.DownedPlantera, ModConditions.HasBeenToDungeon)
                .AddModItemToShop(ModConditions.vitalityMod, "TornPage", Item.buyPrice(gold: 1));
            modMaterialsShop.Register();

            var modBossBagShop = new NPCShop(Type, "Modded Treasure Bags")
            //Aequus
                .AddModItemToShop(ModConditions.aequusMod, "CrabsonBag", Item.buyPrice(platinum: 2), ModConditions.DownedCrabson, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.aequusMod, "OmegaStariteBag", Item.buyPrice(platinum: 2), ModConditions.DownedOmegaStarite, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.aequusMod, "DustDevilBag", Item.buyPrice(platinum: 2), ModConditions.DownedDustDevil, ModConditions.expertOrMaster)
            //AFKPets
                .AddModItemToShop(ModConditions.afkpetsMod, "LeatherBag", Item.buyPrice(platinum: 2), ModConditions.DownedSlayerOfEvil, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.afkpetsMod, "SATLA001TreasureBag", Item.buyPrice(platinum: 2), ModConditions.DownedSATLA, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.afkpetsMod, "DrFetusTreasureBag", Item.buyPrice(platinum: 2), ModConditions.DownedDrFetus, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.afkpetsMod, "SlimesLastHopeTreasureBag", Item.buyPrice(platinum: 2), ModConditions.DownedSlimesHope, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.afkpetsMod, "PoliticianSlimeTreasureBag", Item.buyPrice(platinum: 2), ModConditions.DownedPoliticianSlime, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.afkpetsMod, "Inventory", Item.buyPrice(platinum: 2), ModConditions.DownedAncientTrio, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.afkpetsMod, "LavalGolemTreasureBag", Item.buyPrice(platinum: 2), ModConditions.DownedLavalGolem, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.afkpetsMod, "AntonyPouch", Item.buyPrice(platinum: 2), ModConditions.DownedAntony, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.afkpetsMod, "BunnyZeppelinPouch", Item.buyPrice(platinum: 2), ModConditions.DownedBunnyZeppelin, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.afkpetsMod, "OkikuPouch", Item.buyPrice(platinum: 2), ModConditions.DownedOkiku, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.afkpetsMod, "RoyalHarpyAirForcePouch", Item.buyPrice(platinum: 2), ModConditions.DownedHarpyAirforce, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.afkpetsMod, "IsaacPouch", Item.buyPrice(platinum: 2), ModConditions.DownedIsaac, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.afkpetsMod, "AncientGuardianPouch", Item.buyPrice(platinum: 2), ModConditions.DownedAncientGuardian, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.afkpetsMod, "HeroicSlimePouch", Item.buyPrice(platinum: 2), ModConditions.DownedHeroicSlime, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.afkpetsMod, "HolographicSlimePouch", Item.buyPrice(platinum: 2), ModConditions.DownedHoloSlime, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.afkpetsMod, "SecurityBotPouch", Item.buyPrice(platinum: 2), ModConditions.DownedSecurityBot, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.afkpetsMod, "UndeadChefPouch", Item.buyPrice(platinum: 2), ModConditions.DownedUndeadChef, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.afkpetsMod, "GuardianofFrostPouch", Item.buyPrice(platinum: 2), ModConditions.DownedGuardianOfFrost, ModConditions.expertOrMaster)
            //Assorted Crazy Things
                .AddModItemToShop(ModConditions.assortedCrazyThingsMod, "HarvesterTreasureBag", Item.buyPrice(platinum: 2), ModConditions.DownedSoulHarvester, ModConditions.expertOrMaster)
            //Calamity
                .AddModItemToShop(ModConditions.calamityMod, "DesertScourgeBag", Item.buyPrice(platinum: 2), ModConditions.DownedDesertScourge, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.calamityMod, "CrabulonBag", Item.buyPrice(platinum: 2), ModConditions.DownedCrabulon, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.calamityMod, "HiveMindBag", Item.buyPrice(platinum: 2), ModConditions.DownedHiveMind, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.calamityMod, "PerforatorBag", Item.buyPrice(platinum: 2), ModConditions.DownedPerforators, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.calamityMod, "SlimeGodBag", Item.buyPrice(platinum: 2), ModConditions.DownedSlimeGod, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.calamityMod, "CryogenBag", Item.buyPrice(platinum: 2), ModConditions.DownedCryogen, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.calamityMod, "AquaticScourgeBag", Item.buyPrice(platinum: 2), ModConditions.DownedAquaticScourge, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.calamityMod, "BrimstoneWaifuBag", Item.buyPrice(platinum: 2), ModConditions.DownedBrimstoneElemental, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.calamityMod, "CalamitasCloneBag", Item.buyPrice(platinum: 2), ModConditions.DownedCalamitasClone, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.calamityMod, "LeviathanBag", Item.buyPrice(platinum: 2), ModConditions.DownedLeviathanAndAnahita, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.calamityMod, "AstrumAureusBag", Item.buyPrice(platinum: 2), ModConditions.DownedAstrumAureus, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.calamityMod, "PlaguebringerGoliathBag", Item.buyPrice(platinum: 2), ModConditions.DownedPlaguebringerGoliath, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.calamityMod, "RavagerBag", Item.buyPrice(platinum: 2), ModConditions.DownedRavager, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.calamityMod, "AstrumDeusBag", Item.buyPrice(platinum: 2), ModConditions.DownedAstrumDeus, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.calamityMod, "DragonfollyBag", Item.buyPrice(platinum: 2), ModConditions.DownedDragonfolly, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.calamityMod, "ProvidenceBag", Item.buyPrice(platinum: 2), ModConditions.DownedProvidence, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.calamityMod, "PolterghastBag", Item.buyPrice(platinum: 2), ModConditions.DownedPolterghast, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.calamityMod, "CeaselessVoidBag", Item.buyPrice(platinum: 2), ModConditions.DownedCeaselessVoid, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.calamityMod, "StormWeaverBag", Item.buyPrice(platinum: 2), ModConditions.DownedStormWeaver, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.calamityMod, "SignusBag", Item.buyPrice(platinum: 2), ModConditions.DownedSignus, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.calamityMod, "OldDukeBag", Item.buyPrice(platinum: 2), ModConditions.DownedOldDuke, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.calamityMod, "DevourerofGodsBag", Item.buyPrice(platinum: 2), ModConditions.DownedDevourerOfGods, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.calamityMod, "YharonBag", Item.buyPrice(platinum: 2), ModConditions.DownedYharon, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.calamityMod, "DraedonBag", Item.buyPrice(platinum: 2), ModConditions.DownedExoMechs, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.calamityMod, "CalamitasCoffer", Item.buyPrice(platinum: 2), ModConditions.DownedSupremeCalamitas, ModConditions.expertOrMaster)
            //Catalyst
                .AddModItemToShop(ModConditions.catalystMod, "AstrageldonBag", Item.buyPrice(platinum: 2), ModConditions.DownedAstrageldon, ModConditions.expertOrMaster)
            //Consolaria
                .AddModItemToShop(ModConditions.consolariaMod, "LepusBag", Item.buyPrice(platinum: 2), ModConditions.DownedLepus, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.consolariaMod, "TurkorBag", Item.buyPrice(platinum: 2), ModConditions.DownedTurkor, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.consolariaMod, "OcramBag", Item.buyPrice(platinum: 2), ModConditions.DownedOcram, ModConditions.expertOrMaster)
            //Depths
                .AddModItemToShop(ModConditions.depthsMod, "ChasmeBag", Item.buyPrice(platinum: 2), ModConditions.DownedChasme, ModConditions.expertOrMaster)
            //Echoes
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "GalahisBag", Item.buyPrice(platinum: 2), ModConditions.DownedGalahis, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "CreationBag", Item.buyPrice(platinum: 2), ModConditions.DownedCreation, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "DestructionBag", Item.buyPrice(platinum: 2), ModConditions.DownedDestruction, ModConditions.expertOrMaster)
            //Edorbis
                .AddModItemToShop(ModConditions.edorbisMod, "BlightKingBag", Item.buyPrice(platinum: 2), ModConditions.DownedBlightKing, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.edorbisMod, "GardenerBag", Item.buyPrice(platinum: 2), ModConditions.DownedGardener, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.edorbisMod, "GlaciationBag", Item.buyPrice(platinum: 2), ModConditions.DownedGlaciation, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.edorbisMod, "HocBag", Item.buyPrice(platinum: 2), ModConditions.DownedHandOfCthulhu, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.edorbisMod, "CursedLordBag", Item.buyPrice(platinum: 2), ModConditions.DownedCursePreacher, ModConditions.expertOrMaster)
            //Exalt
                .AddModItemToShop(ModConditions.exaltMod, "EffulgenceBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedEffulgence, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.exaltMod, "IceLichBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedIceLich, ModConditions.expertOrMaster)
            //Fargos
                .AddModItemToShop(ModConditions.fargosSoulsMod, "TrojanSquirrelBag", Item.buyPrice(platinum: 2), ModConditions.DownedTrojanSquirrel, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.fargosSoulsMod, "DeviBag", Item.buyPrice(platinum: 2), ModConditions.DownedDeviantt, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.fargosSoulsMod, "LifeChallengerBag", Item.buyPrice(platinum: 2), ModConditions.DownedLieflight, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.fargosSoulsMod, "CosmosBag", Item.buyPrice(platinum: 2), ModConditions.DownedEridanus, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.fargosSoulsMod, "AbomBag", Item.buyPrice(platinum: 2), ModConditions.DownedAbominationn, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.fargosSoulsMod, "MutantBag", Item.buyPrice(platinum: 2), ModConditions.DownedMutant, ModConditions.expertOrMaster)
            //GaMeTerraria
                .AddModItemToShop(ModConditions.gameTerrariaMod, "SnowDonBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedSnowDon, ModConditions.expertOrMaster)
            //Gensokyo
                .AddModItemToShop(ModConditions.gensokyoMod, "LilyWhiteBag", Item.buyPrice(platinum: 2), ModConditions.DownedLilyWhite, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.gensokyoMod, "RumiaBag", Item.buyPrice(platinum: 2), ModConditions.DownedRumia, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.gensokyoMod, "EternityLarvaBag", Item.buyPrice(platinum: 2), ModConditions.DownedEternityLarva, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.gensokyoMod, "NazrinBag", Item.buyPrice(platinum: 2), ModConditions.DownedNazrin, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.gensokyoMod, "HinaKagiyamaBag", Item.buyPrice(platinum: 2), ModConditions.DownedHinaKagiyama, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.gensokyoMod, "SekibankiBag", Item.buyPrice(platinum: 2), ModConditions.DownedSekibanki, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.gensokyoMod, "SeiranBag", Item.buyPrice(platinum: 2), ModConditions.DownedSeiran, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.gensokyoMod, "NitoriKawashiroBag", Item.buyPrice(platinum: 2), ModConditions.DownedNitoriKawashiro, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.gensokyoMod, "MedicineMelancholyBag", Item.buyPrice(platinum: 2), ModConditions.DownedMedicineMelancholy, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.gensokyoMod, "CirnoBag", Item.buyPrice(platinum: 2), ModConditions.DownedCirno, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.gensokyoMod, "MinamitsuMurasaBag", Item.buyPrice(platinum: 2), ModConditions.DownedMinamitsuMurasa, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.gensokyoMod, "AliceMargatroidBag", Item.buyPrice(platinum: 2), ModConditions.DownedAliceMargatroid, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.gensokyoMod, "SakuyaIzayoiBag", Item.buyPrice(platinum: 2), ModConditions.DownedSakuyaIzayoi, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.gensokyoMod, "SeijaKijinBag", Item.buyPrice(platinum: 2), ModConditions.DownedSeijaKijin, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.gensokyoMod, "MayumiJoutouguuBag", Item.buyPrice(platinum: 2), ModConditions.DownedMayumiJoutouguu, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.gensokyoMod, "ToyosatomimiNoMikoBag", Item.buyPrice(platinum: 2), ModConditions.DownedToyosatomimiNoMiko, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.gensokyoMod, "KaguyaHouraisanBag", Item.buyPrice(platinum: 2), ModConditions.DownedKaguyaHouraisan, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.gensokyoMod, "UtsuhoReiujiBag", Item.buyPrice(platinum: 2), ModConditions.DownedUtsuhoReiuji, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.gensokyoMod, "TenshiHinanawiBag", Item.buyPrice(platinum: 2), ModConditions.DownedTenshiHinanawi, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.gensokyoMod, "KisumeBag", Item.buyPrice(platinum: 2), ModConditions.DownedKisume, ModConditions.expertOrMaster)
            //Homeward
                .AddModItemToShop(ModConditions.homewardJourneyMod, "MarquisMoonsquidTreasureBag", Item.buyPrice(platinum: 2), ModConditions.DownedMarquisMoonsquid, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "PriestessRodTreasureBag", Item.buyPrice(platinum: 2), ModConditions.DownedPriestessRod, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "DiverTreasureBag", Item.buyPrice(platinum: 2), ModConditions.DownedDiver, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "TheMotherbrainTreasureBag", Item.buyPrice(platinum: 2), ModConditions.DownedMotherbrain, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "WallofShadowTreasureBag", Item.buyPrice(platinum: 2), ModConditions.DownedWallOfShadow, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "SlimeGodTreasureBag", Item.buyPrice(platinum: 2), ModConditions.DownedSunSlimeGod, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "TheOverwatcherTreasureBag", Item.buyPrice(platinum: 2), ModConditions.DownedOverwatcher, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "TheLifebringerTreasureBag", Item.buyPrice(platinum: 2), ModConditions.DownedLifebringer, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "TheMaterealizerTreasureBag", Item.buyPrice(platinum: 2), ModConditions.DownedMaterealizer, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "ScarabBeliefTreasureBag", Item.buyPrice(platinum: 2), ModConditions.DownedScarabBelief, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "EverlastingFallingWhaleTreasureBag", Item.buyPrice(platinum: 2), ModConditions.DownedWorldsEndWhale, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "TheSonTreasureBag", Item.buyPrice(platinum: 2), ModConditions.DownedSon, ModConditions.expertOrMaster)
            //Hunt of the Old God
                .AddModItemToShop(ModConditions.huntOfTheOldGodMod, "TreasureBucket", Item.buyPrice(platinum: 2), ModConditions.DownedGoozma, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.huntOfTheOldGodMod, "TreasureTrunk", Item.buyPrice(platinum: 2), ModConditions.DownedGoozma, ModConditions.expertOrMaster)
            //Infernum
                .AddModItemToShop(ModConditions.infernumMod, "BereftVassalBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedBereftVassal, ModConditions.expertOrMaster)
            //Mech Rework
                .AddModItemToShop(ModConditions.mechReworkMod, "MechclopsBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedSt4sys, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.mechReworkMod, "TerminatorBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedTerminator, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.mechReworkMod, "CaretakerBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedCaretaker, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.mechReworkMod, "SiegeEngineBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedSiegeEngine, ModConditions.expertOrMaster)
            //Polarities
                .AddModItemToShop(ModConditions.polaritiesMod, "StormCloudfishBag", Item.buyPrice(platinum: 2), ModConditions.DownedStormCloudfish, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.polaritiesMod, "StarConstructBag", Item.buyPrice(platinum: 2), ModConditions.DownedStarConstruct, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.polaritiesMod, "GigabatBag", Item.buyPrice(platinum: 2), ModConditions.DownedGigabat, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.polaritiesMod, "SunPixieBag", Item.buyPrice(platinum: 2), ModConditions.DownedSunPixie, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.polaritiesMod, "EsophageBag", Item.buyPrice(platinum: 2), ModConditions.DownedEsophage, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.polaritiesMod, "ConvectiveWandererBag", Item.buyPrice(platinum: 2), ModConditions.DownedConvectiveWanderer, ModConditions.expertOrMaster)
            //Qwertys
                .AddModItemToShop(ModConditions.qwertyMod, "TundraBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedPolarExterminator, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.qwertyMod, "FortressBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedDivineLight, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.qwertyMod, "AncientMachineBag", Item.buyPrice(platinum: 2), ModConditions.DownedAncientMachine, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.qwertyMod, "NoehtnapBag", Item.buyPrice(platinum: 2), ModConditions.DownedNoehtnap, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.qwertyMod, "HydraBag", Item.buyPrice(platinum: 2), ModConditions.DownedHydra, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.qwertyMod, "BladeBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedImperious, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.qwertyMod, "RuneGhostBag", Item.buyPrice(platinum: 2), ModConditions.DownedRuneGhost, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.qwertyMod, "BattleshipBag", Item.buyPrice(platinum: 2), ModConditions.DownedInvaderBattleship, ModConditions.DownedInvaderNoehtnap, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.qwertyMod, "B4Bag", Item.buyPrice(platinum: 2), ModConditions.DownedOLORD, ModConditions.expertOrMaster)
            //Redemption
                .AddModItemToShop(ModConditions.redemptionMod, "ThornBag", Item.buyPrice(platinum: 2), ModConditions.DownedThorn, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.redemptionMod, "ErhanBag", Item.buyPrice(platinum: 2), ModConditions.DownedErhan, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.redemptionMod, "KeeperBag", Item.buyPrice(platinum: 2), ModConditions.DownedKeeper, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.redemptionMod, "SoIBag", Item.buyPrice(platinum: 2), ModConditions.DownedSeedOfInfection, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.redemptionMod, "SlayerBag", Item.buyPrice(platinum: 2), ModConditions.DownedKingSlayerIII, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.redemptionMod, "OmegaCleaverBag", Item.buyPrice(platinum: 2), ModConditions.DownedOmegaCleaver, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.redemptionMod, "OmegaGigaporaBag", Item.buyPrice(platinum: 2), ModConditions.DownedOmegaGigapora, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.redemptionMod, "OmegaOblitBag", Item.buyPrice(platinum: 2), ModConditions.DownedOmegaObliterator, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.redemptionMod, "PZBag", Item.buyPrice(platinum: 2), ModConditions.DownedPatientZero, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.redemptionMod, "AkkaBag", Item.buyPrice(platinum: 2), ModConditions.DownedAkka, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.redemptionMod, "UkkoBag", Item.buyPrice(platinum: 2), ModConditions.DownedUkko, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.redemptionMod, "NebBag", Item.buyPrice(platinum: 2), ModConditions.DownedNebuleus, ModConditions.expertOrMaster)
            //SOTS
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "GlowmothBag", Item.buyPrice(platinum: 2), ModConditions.DownedGlowmoth, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "PinkyBag", Item.buyPrice(platinum: 2), ModConditions.DownedPutridPinky, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "CurseBag", Item.buyPrice(platinum: 2), ModConditions.DownedPharaohsCurse, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "TheAdvisorBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedAdvisor, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "PolarisBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedPolaris, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "LuxBag", Item.buyPrice(platinum: 2), ModConditions.DownedLux, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "SubspaceBag", Item.buyPrice(platinum: 2), ModConditions.DownedSubspaceSerpent, ModConditions.expertOrMaster)
            //Spirit
                .AddModItemToShop(ModConditions.spiritMod, "BagOScarabs", Item.buyPrice(platinum: 2), ModConditions.DownedScarabeus, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.spiritMod, "MJWBag", Item.buyPrice(platinum: 2), ModConditions.DownedMoonJellyWizard, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.spiritMod, "ReachBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedVinewrathBane, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.spiritMod, "FlyerBag", Item.buyPrice(platinum: 2), ModConditions.DownedAncientAvian, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.spiritMod, "SteamRaiderBag", Item.buyPrice(platinum: 2), ModConditions.DownedStarplateVoyager, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.spiritMod, "InfernonBag", Item.buyPrice(platinum: 2), ModConditions.DownedInfernon, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.spiritMod, "DuskingBag", Item.buyPrice(platinum: 2), ModConditions.DownedDusking, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.spiritMod, "AtlasBag", Item.buyPrice(platinum: 2), ModConditions.DownedAtlas, ModConditions.expertOrMaster)
            //Spooky
                .AddModItemToShop(ModConditions.spookyMod, "BossBagRotGourd", Item.buyPrice(platinum: 2), ModConditions.DownedRotGourd, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.spookyMod, "BossBagSpookySpirit", Item.buyPrice(platinum: 2), ModConditions.DownedSpookySpirit, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.spookyMod, "BossBagMoco", Item.buyPrice(platinum: 2), ModConditions.DownedMoco, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.spookyMod, "BossBagDaffodil", Item.buyPrice(platinum: 2), ModConditions.DownedDaffodil, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.spookyMod, "BossBagOrroboro", Item.buyPrice(platinum: 2), ModConditions.DownedOrroBoro, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.spookyMod, "BossBagBigBone", Item.buyPrice(platinum: 2), ModConditions.DownedBigBone, ModConditions.expertOrMaster)
            //Starlight River
                .AddModItemToShop(ModConditions.starlightRiverMod, "SquidBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedAuroracle, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.starlightRiverMod, "VitricBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedCeiros, ModConditions.expertOrMaster)
            //Stars Above
                .AddModItemToShop(ModConditions.starsAboveMod, "VagrantBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedVagrantofSpace, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.starsAboveMod, "DioskouroiBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedDioskouroi, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.starsAboveMod, "NalhaunBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedNalhaun, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.starsAboveMod, "PenthBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedPenthesilea, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.starsAboveMod, "ArbitrationBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedArbitration, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.starsAboveMod, "WarriorBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedWarriorOfLight, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.starsAboveMod, "TsukiBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedTsukiyomi, ModConditions.expertOrMaster)
            //Storms
                .AddModItemToShop(ModConditions.stormsAdditionsMod, "AridBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedAncientHusk, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.stormsAdditionsMod, "StormBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedOverloadedScandrone, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.stormsAdditionsMod, "UltimateBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedPainbringer, ModConditions.expertOrMaster)
            //Supernova
                .AddModItemToShop(ModConditions.supernovaMod, "FlyingTerrorBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedFlyingTerror, ModConditions.expertOrMaster)
            //Terrorborn
                .AddModItemToShop(ModConditions.terrorbornMod, "II_TreasureBag", Item.buyPrice(platinum: 2), ModConditions.DownedInfectedIncarnate, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.terrorbornMod, "TT_TreasureBag", Item.buyPrice(platinum: 2), ModConditions.DownedTidalTitan, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.terrorbornMod, "DS_TreasureBag", Item.buyPrice(platinum: 2), ModConditions.DownedDunestock, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.terrorbornMod, "HC_TreasureBag", Item.buyPrice(platinum: 2), ModConditions.DownedHexedConstructor, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.terrorbornMod, "SC_TreasureBag", Item.buyPrice(platinum: 2), ModConditions.DownedShadowcrawler, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.terrorbornMod, "PI_TreasureBag", Item.buyPrice(platinum: 2), ModConditions.DownedPrototypeI, ModConditions.expertOrMaster)
            //Thorium
                .AddModItemToShop(ModConditions.thoriumMod, "ThunderBirdBag", Item.buyPrice(platinum: 2), ModConditions.DownedGrandThunderBird, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.thoriumMod, "JellyFishBag", Item.buyPrice(platinum: 2), ModConditions.DownedQueenJellyfish, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.thoriumMod, "CountBag", Item.buyPrice(platinum: 2), ModConditions.DownedViscount, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.thoriumMod, "GraniteBag", Item.buyPrice(platinum: 2), ModConditions.DownedGraniteEnergyStorm, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.thoriumMod, "HeroBag", Item.buyPrice(platinum: 2), ModConditions.DownedBuriedChampion, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.thoriumMod, "ScouterBag", Item.buyPrice(platinum: 2), ModConditions.DownedStarScouter, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.thoriumMod, "BoreanBag", Item.buyPrice(platinum: 2), ModConditions.DownedBoreanStrider, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.thoriumMod, "BeholderBag", Item.buyPrice(platinum: 2), ModConditions.DownedFallenBeholder, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.thoriumMod, "LichBag", Item.buyPrice(platinum: 2), ModConditions.DownedLich, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.thoriumMod, "AbyssionBag", Item.buyPrice(platinum: 2), ModConditions.DownedForgottenOne, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.thoriumMod, "RagBag", Item.buyPrice(platinum: 2), ModConditions.DownedPrimordials, ModConditions.expertOrMaster)
            //TRAE
                .AddModItemToShop(ModConditions.traeMod, "DreadBag", Item.buyPrice(platinum: 2), ModConditions.DownedDreadnautilus, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.traeMod, "BeholderBag", Item.buyPrice(platinum: 2), ModConditions.DownedBeholder, ModConditions.expertOrMaster)
            //Valhalla
                .AddModItemToShop(ModConditions.valhallaMod, "PirateSquidBag", Item.buyPrice(platinum: 2), ModConditions.DownedColossalCarnage, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.valhallaMod, "EmperorBag", Item.buyPrice(platinum: 2), ModConditions.DownedYurnero, ModConditions.expertOrMaster)
            //Vitality
                .AddModItemToShop(ModConditions.vitalityMod, "StormCloudBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedStormCloud, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.vitalityMod, "GrandAntlionBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedGrandAntlion, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.vitalityMod, "GemstoneElementalBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedGemstoneElemental, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.vitalityMod, "MoonlightDragonflyBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedMoonlightDragonfly, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.vitalityMod, "DreadnaughtBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedDreadnaught, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.vitalityMod, "AnarchulesBeetleBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedAnarchulesBeetle, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.vitalityMod, "ChaosbringerBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedChaosbringer, ModConditions.expertOrMaster)
                .AddModItemToShop(ModConditions.vitalityMod, "PaladinSpiritBossBag", Item.buyPrice(platinum: 2), ModConditions.DownedPaladinSpirit, ModConditions.expertOrMaster);
            modBossBagShop.Register();

            var modCratesShop = new NPCShop(Type, "Modded Crates & Grab Bags")
            //Aequus
                .AddModItemToShop(ModConditions.aequusMod, "CrabCreviceCrate", Item.buyPrice(platinum: 1), ModConditions.HasBeenToCrabCrevice)
                .AddModItemToShop(ModConditions.aequusMod, "CrabCreviceCrateHard", Item.buyPrice(platinum: 1), Condition.Hardmode, ModConditions.HasBeenToCrabCrevice)
            //Calamity
                .AddModItemToShop(ModConditions.calamityMod, "StarterBag", Item.buyPrice(platinum: 1))
                .AddModItemToShop(ModConditions.calamityMod, "AstralCrate", Item.buyPrice(platinum: 1), Condition.Hardmode, ModConditions.HasBeenToAstral)
                .AddModItemToShop(ModConditions.calamityMod, "BrimstoneCrate", Item.buyPrice(platinum: 1), Condition.DownedEowOrBoc, ModConditions.HasBeenToCrags)
                .AddModItemToShop(ModConditions.calamityMod, "SulphurousCrate", Item.buyPrice(platinum: 1), ModConditions.HasBeenToSulphurSea)
                .AddModItemToShop(ModConditions.calamityMod, "SunkenCrate", Item.buyPrice(platinum: 1), ModConditions.HasBeenToSunkenSea)
                .AddModItemToShop(ModConditions.calamityMod, "SulphuricTreasure", Item.buyPrice(platinum: 1), ModConditions.HasBeenToSulphurSea)
                .AddModItemToShop(ModConditions.calamityMod, "AbyssalTreasure", Item.buyPrice(platinum: 1), ModConditions.HasBeenToAbyss)
                .AddModItemToShop(ModConditions.calamityMod, "FleshyGeode", Item.buyPrice(platinum: 1), ModConditions.DownedRavager)
                .AddModItemToShop(ModConditions.calamityMod, "NecromanticGeode", Item.buyPrice(platinum: 1), ModConditions.DownedProvidence)
                .AddModItemToShop(ModConditions.calamityMod, "SandyAnglingKit", Item.buyPrice(platinum: 1), ModConditions.DownedDesertScourge)
                .AddModItemToShop(ModConditions.calamityMod, "BleachedAnglingKit", Item.buyPrice(platinum: 1), ModConditions.DownedAquaticScourge)
            //Confection
                .AddModItemToShop(ModConditions.confectionRebakedMod, "BananaSplitCrate", Item.buyPrice(platinum: 1), ModConditions.HasBeenToConfectionOrHallow)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "ConfectionCrate", Item.buyPrice(platinum: 1), Condition.Hardmode, ModConditions.HasBeenToConfectionOrHallow)
            //Depths
                .AddModItemToShop(ModConditions.depthsMod, "QuartzCrate", Item.buyPrice(platinum: 1), ModConditions.HasBeenToDepthsOrUnderworld)
                .AddModItemToShop(ModConditions.depthsMod, "ArqueriteCrate", Item.buyPrice(platinum: 1), Condition.Hardmode, ModConditions.HasBeenToDepthsOrUnderworld)
            //Polarities
                .AddModItemToShop(ModConditions.polaritiesMod, "SaltCrate", Item.buyPrice(platinum: 1), ModConditions.HasBeenToCavernsOrUnderground)
            //Redemption
                .AddModItemToShop(ModConditions.redemptionMod, "PetrifiedCrate", Item.buyPrice(platinum: 1), Condition.Hardmode, ModConditions.HasBeenToWasteland)
                .AddModItemToShop(ModConditions.redemptionMod, "LabCrate", Item.buyPrice(platinum: 1), Condition.DownedMechBossAll, ModConditions.HasBeenToLab)
                .AddModItemToShop(ModConditions.redemptionMod, "LabCrate2", Item.buyPrice(platinum: 1), Condition.DownedMoonLord, ModConditions.HasBeenToLab)
            //SOTS
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "PyramidCrate", Item.buyPrice(platinum: 1), Condition.DownedEowOrBoc, ModConditions.HasBeenToPyramid)
            //Spirit
                .AddModItemToShop(ModConditions.spiritMod, "ReachCrate", Item.buyPrice(platinum: 1), ModConditions.HasBeenToBriar)
                .AddModItemToShop(ModConditions.spiritMod, "BriarCrate", Item.buyPrice(platinum: 1), Condition.Hardmode, ModConditions.HasBeenToBriar)
                .AddModItemToShop(ModConditions.spiritMod, "SpiritCrate", Item.buyPrice(platinum: 1), Condition.DownedMechBossAny, ModConditions.HasBeenToSpirit)
                .AddModItemToShop(ModConditions.spiritMod, "FishCrate", Item.buyPrice(platinum: 1), ModConditions.HasBeenToOcean)
                .AddModItemToShop(ModConditions.spiritMod, "PirateCrate", Item.buyPrice(platinum: 1), Condition.DownedPirates)
            //Thorium
                .AddModItemToShop(ModConditions.thoriumMod, "AquaticDepthsCrate", Item.buyPrice(platinum: 1), ModConditions.HasBeenToAquaticDepths)
                .AddModItemToShop(ModConditions.thoriumMod, "AbyssalCrate", Item.buyPrice(platinum: 1), Condition.Hardmode, ModConditions.HasBeenToAquaticDepths)
                .AddModItemToShop(ModConditions.thoriumMod, "ScarletCrate", Item.buyPrice(platinum: 1), ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.thoriumMod, "SinisterCrate", Item.buyPrice(platinum: 1), Condition.Hardmode, ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.thoriumMod, "StrangeCrate", Item.buyPrice(platinum: 1))
                .AddModItemToShop(ModConditions.thoriumMod, "WondrousCrate", Item.buyPrice(platinum: 1), Condition.Hardmode)
            //Verdant
                .AddModItemToShop(ModConditions.verdantMod, "LushWoodCrateItem", Item.buyPrice(platinum: 1), ModConditions.HasBeenToVerdant)
                .AddModItemToShop(ModConditions.verdantMod, "MysteriaCrateItem", Item.buyPrice(platinum: 1), Condition.Hardmode, ModConditions.HasBeenToVerdant);
            modCratesShop.Register();

            var modOreShop = new NPCShop(Type, "Modded Ores & Bars")
            //AFKPets
                .AddModItemToShop(ModConditions.afkpetsMod, "NetheriteOre", Item.buyPrice(gold: 1), ModConditions.DownedLavalGolem)
                .AddModItemToShop(ModConditions.afkpetsMod, "NetheriteBar", Item.buyPrice(gold: 1), ModConditions.DownedLavalGolem)
            //Calamity
                .AddModItemToShop(ModConditions.calamityMod, "AerialiteOre", Item.buyPrice(gold: 1), ModConditions.DownedPerforatorsOrHiveMind, ModConditions.HasBeenToSky)
                .AddModItemToShop(ModConditions.calamityMod, "AstralOre", Item.buyPrice(gold: 1), ModConditions.DownedAstrumDeus, ModConditions.HasBeenToAstral)
                .AddModItemToShop(ModConditions.calamityMod, "AuricOre", Item.buyPrice(gold: 1), ModConditions.DownedYharon, ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.calamityMod, "CryonicOre", Item.buyPrice(gold: 1), ModConditions.DownedCryogen, ModConditions.HasBeenToSnow)
                .AddModItemToShop(ModConditions.calamityMod, "ExodiumCluster", Item.buyPrice(gold: 1), Condition.DownedMoonLord, ModConditions.HasBeenToSky)
                .AddModItemToShop(ModConditions.calamityMod, "HallowedOre", Item.buyPrice(gold: 1), Condition.DownedMechBossAll, ModConditions.HasBeenToHallow)
                .AddModItemToShop(ModConditions.calamityMod, "InfernalSuevite", Item.buyPrice(gold: 1), Condition.DownedMechBossAny, ModConditions.HasBeenToCrags)
                .AddModItemToShop(ModConditions.calamityMod, "PerennialOre", Item.buyPrice(gold: 1), Condition.DownedPlantera, ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.calamityMod, "PrismShard", Item.buyPrice(gold: 1), ModConditions.HasBeenToSunkenSea)
                .AddModItemToShop(ModConditions.calamityMod, "ScoriaOre", Item.buyPrice(gold: 1), Condition.DownedGolem, ModConditions.HasBeenToAbyss)
                .AddModItemToShop(ModConditions.calamityMod, "SeaPrism", Item.buyPrice(gold: 1), ModConditions.HasBeenToSunkenSea)
                .AddModItemToShop(ModConditions.calamityMod, "UelibloomOre", Item.buyPrice(gold: 1), ModConditions.DownedProvidence, ModConditions.HasBeenToJungle)
                .AddModItemToShop(ModConditions.calamityMod, "AerialiteBar", Item.buyPrice(gold: 1), ModConditions.DownedPerforatorsOrHiveMind, ModConditions.HasBeenToSky)
                .AddModItemToShop(ModConditions.calamityMod, "AstralBar", Item.buyPrice(gold: 1), ModConditions.DownedAstrumDeus, ModConditions.HasBeenToAstral)
                .AddModItemToShop(ModConditions.calamityMod, "AuricBar", Item.buyPrice(gold: 1), ModConditions.DownedYharon, ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.calamityMod, "CosmiliteBar", Item.buyPrice(gold: 1), ModConditions.DownedDevourerOfGods)
                .AddModItemToShop(ModConditions.calamityMod, "CryonicBar", Item.buyPrice(gold: 1), ModConditions.DownedCryogen, ModConditions.HasBeenToSnow)
                .AddModItemToShop(ModConditions.calamityMod, "PerennialBar", Item.buyPrice(gold: 1), Condition.DownedPlantera, ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.calamityMod, "ScoriaBar", Item.buyPrice(gold: 1), Condition.DownedGolem, ModConditions.HasBeenToAbyss)
                .AddModItemToShop(ModConditions.calamityMod, "ShadowspecBar", Item.buyPrice(gold: 1), ModConditions.DownedSupremeCalamitas, ModConditions.DownedExoMechs)
                .AddModItemToShop(ModConditions.calamityMod, "UelibloomBar", Item.buyPrice(gold: 1), ModConditions.DownedProvidence, ModConditions.HasBeenToJungle)
            //Catalyst
                .AddModItemToShop(ModConditions.catalystMod, "MetanovaOre", Item.buyPrice(gold: 1), ModConditions.DownedAstrageldon, ModConditions.HasBeenToAstral)
                .AddModItemToShop(ModConditions.catalystMod, "MetanovaBar", Item.buyPrice(gold: 1), ModConditions.DownedAstrageldon, ModConditions.HasBeenToAstral)
            //Confection
                .AddModItemToShop(ModConditions.confectionRebakedMod, "HallowedOre", Item.buyPrice(gold: 1), Condition.DownedMechBossAny, ModConditions.HasBeenToConfectionOrHallow)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "NeapoliniteOre", Item.buyPrice(gold: 1), Condition.DownedMechBossAny, ModConditions.HasBeenToConfectionOrHallow)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "NeapoliniteBar", Item.buyPrice(gold: 1), Condition.DownedMechBossAny, ModConditions.HasBeenToConfectionOrHallow)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "Saccharite", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToConfectionOrHallow)
            //Depths
                .AddModItemToShop(ModConditions.depthsMod, "ArqueriteOre", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc, ModConditions.HasBeenToDepthsOrUnderworld)
                .AddModItemToShop(ModConditions.depthsMod, "ArqueriteBar", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc, ModConditions.HasBeenToDepthsOrUnderworld)
                .AddModItemToShop(ModConditions.depthsMod, "Onyx", Item.buyPrice(gold: 1), ModConditions.HasBeenToDepthsOrUnderworld)
            //Echoes
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "ArcaniumOre", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "Moonstone", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToSky)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "Skystone_Ore", Item.buyPrice(gold: 1), Condition.DownedGolem, ModConditions.HasBeenToSky)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "VarsiumCrystal", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "Ashen_Ore", Item.buyPrice(gold: 1), Condition.DownedGolem, ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "UniversiumOre", Item.buyPrice(gold: 1), Condition.DownedCultist)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "Arcanium_Bar", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "SkystoneBar", Item.buyPrice(gold: 1), Condition.DownedGolem, ModConditions.HasBeenToSky)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "Ashen_Bar", Item.buyPrice(gold: 1), Condition.DownedGolem, ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.echoesOfTheAncientsMod, "UniversiumBar", Item.buyPrice(gold: 1), Condition.DownedCultist)
            //Edorbis
                .AddModItemToShop(ModConditions.edorbisMod, "CentauriumOre", Item.buyPrice(gold: 1), Condition.DownedGolem)
                .AddModItemToShop(ModConditions.edorbisMod, "KelviniteOre", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.edorbisMod, "Lithium", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.edorbisMod, "AtlantiumBar", Item.buyPrice(gold: 1), ModConditions.DownedHandOfCthulhu)
                .AddModItemToShop(ModConditions.edorbisMod, "CentauriumBar", Item.buyPrice(gold: 1), Condition.DownedGolem)
                .AddModItemToShop(ModConditions.edorbisMod, "KelviniteBar", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.edorbisMod, "SteampunkAlloy", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(ModConditions.edorbisMod, "ThermiteBar", Item.buyPrice(gold: 1), ModConditions.DownedCursePreacher)
            //Exalt
                .AddModItemToShop(ModConditions.exaltMod, "TitanicOre", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(ModConditions.exaltMod, "TitanicBar", Item.buyPrice(gold: 1), Condition.DownedPlantera)
            //Furniture Food & Fun
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "ZilliumOre", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "BrassBar", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "IndustrialWaxBar", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "ZilliumBar", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "Aquamarine", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "Chalcedony", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "Peridot", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "RoseQuartz", Item.buyPrice(gold: 1))
            //Homeward
                .AddModItemToShop(ModConditions.homewardJourneyMod, "Onyx", Item.buyPrice(gold: 1), Condition.DownedGolem, ModConditions.HasBeenToHomewardAbyss)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "CubistOre", Item.buyPrice(gold: 1), ModConditions.DownedWallOfShadow, ModConditions.HasBeenToSnow)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "DeepOre", Item.buyPrice(gold: 1), Condition.DownedGolem, ModConditions.HasBeenToHomewardAbyss)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "FinalOre", Item.buyPrice(gold: 1), ModConditions.DownedLifebringer, ModConditions.DownedMaterealizer, ModConditions.DownedOverwatcher)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "EternalOre", Item.buyPrice(gold: 1), ModConditions.DownedWallOfShadow, ModConditions.HasBeenToDesert)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "LivingOre", Item.buyPrice(gold: 1), ModConditions.DownedWallOfShadow, ModConditions.HasBeenToJungle)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "CubistBar", Item.buyPrice(gold: 1), ModConditions.DownedWallOfShadow, ModConditions.HasBeenToSnow)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "DeepBar", Item.buyPrice(gold: 1), Condition.DownedGolem, ModConditions.HasBeenToHomewardAbyss)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "FinalBar", Item.buyPrice(gold: 1), ModConditions.DownedLifebringer, ModConditions.DownedMaterealizer, ModConditions.DownedOverwatcher)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "EternalBar", Item.buyPrice(gold: 1), ModConditions.DownedWallOfShadow, ModConditions.HasBeenToDesert)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "LivingBar", Item.buyPrice(gold: 1), ModConditions.DownedWallOfShadow, ModConditions.HasBeenToJungle)
                .AddModItemToShop(ModConditions.homewardJourneyMod, "AbyssalChunk", Item.buyPrice(gold: 1), ModConditions.DownedDiver, ModConditions.HasBeenToHomewardAbyss)
            //Polarities
                .AddModItemToShop(ModConditions.polaritiesMod, "MantellarOre", Item.buyPrice(gold: 1), Condition.DownedGolem, ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.polaritiesMod, "MantellarBar", Item.buyPrice(gold: 1), Condition.DownedGolem, ModConditions.HasBeenToUnderworld)
                .AddModItemToShop(ModConditions.polaritiesMod, "SunplateBar", Item.buyPrice(gold: 1), ModConditions.DownedStarConstruct)
            //Qwertys
                .AddModItemToShop(ModConditions.qwertyMod, "LuneOre", Item.buyPrice(gold: 1), Condition.DownedEyeOfCthulhu)
                .AddModItemToShop(ModConditions.qwertyMod, "RhuthiniumOre", Item.buyPrice(gold: 1), Condition.DownedSkeletron, ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.qwertyMod, "CaeliteBar", Item.buyPrice(gold: 1), ModConditions.DownedDivineLight, ModConditions.HasBeenToSkyFortress)
                .AddModItemToShop(ModConditions.qwertyMod, "LuneBar", Item.buyPrice(gold: 1), Condition.DownedEyeOfCthulhu)
                .AddModItemToShop(ModConditions.qwertyMod, "RhuthiniumBar", Item.buyPrice(gold: 1), Condition.DownedSkeletron, ModConditions.HasBeenToCavernsOrUnderground)
            //Redemption
                .AddModItemToShop(ModConditions.redemptionMod, "CorruptedXenomite", Item.buyPrice(gold: 1), ModConditions.DownedOmegaCleaver)
                .AddModItemToShop(ModConditions.redemptionMod, "DragonLeadOre", Item.buyPrice(gold: 1), Condition.DownedSkeletron, ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.redemptionMod, "GathicCryoCrystal", Item.buyPrice(gold: 1), Condition.DownedSkeletron, ModConditions.HasBeenToSnow)
                .AddModItemToShop(ModConditions.redemptionMod, "GraveSteelShards", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.redemptionMod, "Plutonium", Item.buyPrice(gold: 1), Condition.DownedMoonLord, ModConditions.HasBeenToLab)
                .AddModItemToShop(ModConditions.redemptionMod, "RawXenium", Item.buyPrice(gold: 1), Condition.DownedMoonLord, ModConditions.HasBeenToLab)
                .AddModItemToShop(ModConditions.redemptionMod, "Uranium", Item.buyPrice(gold: 1), Condition.DownedGolem, ModConditions.HasBeenToLab)
                .AddModItemToShop(ModConditions.redemptionMod, "Xenomite", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToLab)
                .AddModItemToShop(ModConditions.redemptionMod, "XenomiteShard", Item.buyPrice(gold: 1), ModConditions.DownedSeedOfInfection)
                .AddModItemToShop(ModConditions.redemptionMod, "GraveSteelAlloy", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.redemptionMod, "DragonLeadAlloy", Item.buyPrice(gold: 1), Condition.DownedSkeletron, ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.redemptionMod, "MoltenScrap", Item.buyPrice(gold: 1), Condition.DownedMoonLord)
                .AddModItemToShop(ModConditions.redemptionMod, "PureIronAlloy", Item.buyPrice(gold: 1), Condition.DownedSkeletron, ModConditions.HasBeenToSnow)
                .AddModItemToShop(ModConditions.redemptionMod, "XeniumAlloy", Item.buyPrice(gold: 1), Condition.DownedMoonLord, ModConditions.HasBeenToLab)
            //SOTS
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "FrigidIce", Item.buyPrice(gold: 1), ModConditions.HasBeenToSnow)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "PhaseOre", Item.buyPrice(gold: 1), ModConditions.DownedLux, ModConditions.HasBeenToSky)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "VibrantOre", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "AbsoluteBar", Item.buyPrice(gold: 1), ModConditions.DownedPolaris)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "AncientSteelBar", Item.buyPrice(gold: 1), Condition.DownedGoblinArmy)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "FrigidBar", Item.buyPrice(gold: 1), ModConditions.HasBeenToSnow)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "HardlightAlloy", Item.buyPrice(gold: 1), ModConditions.DownedAdvisor, ModConditions.HasBeenToPlanetarium)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "PhaseBar", Item.buyPrice(gold: 1), ModConditions.DownedLux, ModConditions.HasBeenToSky)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "StarlightAlloy", Item.buyPrice(gold: 1), ModConditions.DownedAdvisor, ModConditions.HasBeenToPlanetarium)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "OtherworldlyAlloy", Item.buyPrice(gold: 1), ModConditions.DownedAdvisor, ModConditions.HasBeenToPlanetarium)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "VibrantBar", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
            //Spirit
                .AddModItemToShop(ModConditions.spiritMod, "MarbleChunk", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc, ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.spiritMod, "CosmiliteShard", Item.buyPrice(gold: 1), ModConditions.DownedStarplateVoyager, ModConditions.HasBeenToSky)
                .AddModItemToShop(ModConditions.spiritMod, "CryoliteOre", Item.buyPrice(gold: 1), Condition.DownedSkeletron, ModConditions.HasBeenToSnow)
                .AddModItemToShop(ModConditions.spiritMod, "GraniteOre", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc, ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.spiritMod, "FloranOre", Item.buyPrice(gold: 1), ModConditions.HasBeenToBriar)
                .AddModItemToShop(ModConditions.spiritMod, "SpiritOre", Item.buyPrice(gold: 1), Condition.DownedMechBossAny, ModConditions.HasBeenToSpirit)
                .AddModItemToShop(ModConditions.spiritMod, "CryoliteBar", Item.buyPrice(gold: 1), Condition.DownedSkeletron, ModConditions.HasBeenToSnow)
                .AddModItemToShop(ModConditions.spiritMod, "FloranBar", Item.buyPrice(gold: 1), ModConditions.HasBeenToBriar)
                .AddModItemToShop(ModConditions.spiritMod, "SpiritBar", Item.buyPrice(gold: 1), Condition.DownedMechBossAny, ModConditions.HasBeenToSpirit)
            //Starlight River
                .AddModItemToShop(ModConditions.starlightRiverMod, "AuroraIceItem", Item.buyPrice(gold: 1), ModConditions.HasBeenToAuroracleTemple)
                .AddModItemToShop(ModConditions.starlightRiverMod, "MoonstoneOreItem", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.starlightRiverMod, "AuroraIceBar", Item.buyPrice(gold: 1), ModConditions.HasBeenToAuroracleTemple)
                .AddModItemToShop(ModConditions.starlightRiverMod, "MoonstoneBarItem", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
            //Storms
                .AddModItemToShop(ModConditions.stormsAdditionsMod, "SpaceRock", Item.buyPrice(gold: 1), Condition.DownedGolem, ModConditions.HasBeenToSky)
                .AddModItemToShop(ModConditions.stormsAdditionsMod, "DesertOre", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToDesert)
                .AddModItemToShop(ModConditions.stormsAdditionsMod, "IceOre", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToSnow)
                .AddModItemToShop(ModConditions.stormsAdditionsMod, "SpaceRockBar", Item.buyPrice(gold: 1), Condition.DownedGolem, ModConditions.HasBeenToSky)
                .AddModItemToShop(ModConditions.stormsAdditionsMod, "DesertBar", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToDesert)
                .AddModItemToShop(ModConditions.stormsAdditionsMod, "IceBar", Item.buyPrice(gold: 1), Condition.Hardmode, ModConditions.HasBeenToSnow)
            //Supernova
                .AddModItemToShop(ModConditions.supernovaMod, "ZirconiumOre", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.supernovaMod, "VerglasBar", Item.buyPrice(gold: 1), Condition.DownedQueenBee)
                .AddModItemToShop(ModConditions.supernovaMod, "ZirconiumBar", Item.buyPrice(gold: 1))
            //Terrorborn
                .AddModItemToShop(ModConditions.terrorbornMod, "AzuriteOre", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.terrorbornMod, "DeimosteelOreItem", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.terrorbornMod, "NovagoldOre", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.terrorbornMod, "SkullmoundOre", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.terrorbornMod, "AzuriteBar", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.terrorbornMod, "PlasmaliumBar", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.terrorbornMod, "DeimosteelBar", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.terrorbornMod, "NovagoldBar", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.terrorbornMod, "SkullmoundBar", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.terrorbornMod, "PyroclasticGemstone", Item.buyPrice(gold: 1))
            //Thorium
                .AddModItemToShop(ModConditions.thoriumMod, "Aquaite", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc, ModConditions.HasBeenToAquaticDepths)
                .AddModItemToShop(ModConditions.thoriumMod, "aDarksteelAlloy", Item.buyPrice(gold: 1), Condition.DownedSkeletron, ModConditions.HasBeenToDungeon)
                .AddModItemToShop(ModConditions.thoriumMod, "IllumiteChunk", Item.buyPrice(gold: 1), Condition.DownedPlantera, ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.thoriumMod, "LifeQuartz", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.thoriumMod, "LodeStoneChunk", Item.buyPrice(gold: 1), ModConditions.DownedFallenBeholder, ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.thoriumMod, "SmoothCoal", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.thoriumMod, "ThoriumOre", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.thoriumMod, "ValadiumChunk", Item.buyPrice(gold: 1), ModConditions.DownedFallenBeholder, ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.thoriumMod, "AquaiteBar", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc, ModConditions.HasBeenToAquaticDepths)
                .AddModItemToShop(ModConditions.thoriumMod, "IllumiteIngot", Item.buyPrice(gold: 1), Condition.DownedPlantera, ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.thoriumMod, "LifeQuartz", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.thoriumMod, "LodeStoneIngot", Item.buyPrice(gold: 1), ModConditions.DownedFallenBeholder, ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.thoriumMod, "SandstoneIngot", Item.buyPrice(gold: 1), ModConditions.DownedGrandThunderBird, ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.thoriumMod, "ThoriumBar", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.thoriumMod, "TitanicBar", Item.buyPrice(gold: 1), Condition.DownedMechBossAll)
                .AddModItemToShop(ModConditions.thoriumMod, "ValadiumIngot", Item.buyPrice(gold: 1), ModConditions.DownedFallenBeholder, ModConditions.HasBeenToCavernsOrUnderground)
            //Valhalla
                .AddModItemToShop(ModConditions.valhallaMod, "CorrodeOre", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.valhallaMod, "JadeFragment", Item.buyPrice(gold: 1), ModConditions.DownedYurnero)
                .AddModItemToShop(ModConditions.valhallaMod, "TarOre", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.valhallaMod, "ValhalliteOre", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.valhallaMod, "CorrodeBar", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.valhallaMod, "HardenedGlass", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.valhallaMod, "ValhalliteBar", Item.buyPrice(gold: 1))
            //Verdant
                .AddModItemToShop(ModConditions.verdantMod, "AquamarineItem", Item.buyPrice(gold: 1), ModConditions.HasBeenToCavernsOrUnderground)
                .AddModItemToShop(ModConditions.verdantMod, "GreenCrystalItem", Item.buyPrice(gold: 1), Condition.DownedEyeOfCthulhu, ModConditions.HasBeenToVerdant)
            //Vitality
                .AddModItemToShop(ModConditions.vitalityMod, "ArcticOre", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(ModConditions.vitalityMod, "Bloodrock", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(ModConditions.vitalityMod, "GeraniumOre", Item.buyPrice(gold: 1), Condition.DownedSkeletron)
                .AddModItemToShop(ModConditions.vitalityMod, "AnarchyBar", Item.buyPrice(gold: 1), ModConditions.DownedAnarchulesBeetle)
                .AddModItemToShop(ModConditions.vitalityMod, "ArcaneGoldBar", Item.buyPrice(gold: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.vitalityMod, "ArcticBar", Item.buyPrice(gold: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(ModConditions.vitalityMod, "BloodrockBar", Item.buyPrice(gold: 1), Condition.DownedPlantera)
                .AddModItemToShop(ModConditions.vitalityMod, "BronzeAlloy", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.vitalityMod, "ChaosBar", Item.buyPrice(gold: 1), ModConditions.DownedChaosbringer)
                .AddModItemToShop(ModConditions.vitalityMod, "DriedBar", Item.buyPrice(gold: 1), ModConditions.DownedGrandAntlion)
                .AddModItemToShop(ModConditions.vitalityMod, "GeraniumBar", Item.buyPrice(gold: 1), Condition.DownedSkeletron)
                .AddModItemToShop(ModConditions.vitalityMod, "GlowingGraniteBar", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.vitalityMod, "SteelAlloy", Item.buyPrice(gold: 1))
                .AddModItemToShop(ModConditions.vitalityMod, "PurifiedBar", Item.buyPrice(gold: 1));
            modOreShop.Register();

            var modNaturalBlocksShop = new NPCShop(Type, "Modded Natural Blocks")
            //Arbour
                .AddModItemToShop(ModConditions.arbourMod, "BirchWoodBlock", Item.buyPrice(silver: 1))
            //Aequus
                .AddModItemToShop(ModConditions.aequusMod, "SedimentaryRockItem", Item.buyPrice(silver: 1))
            //Calamity
                .AddModItemToShop(ModConditions.calamityMod, "AbyssGravel", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.calamityMod, "Acidwood", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.calamityMod, "AstralClay", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityMod, "AstralDirt", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityMod, "AstralIce", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityMod, "AstralMonolith", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityMod, "AstralSand", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityMod, "AstralSandstone", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityMod, "AstralSnow", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityMod, "AstralStone", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityMod, "BrimstoneSlag", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.calamityMod, "CelestialRemains", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityMod, "EutrophicSand", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.calamityMod, "HardenedAstralSand", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityMod, "HardenedSulphurousSandstone", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.calamityMod, "PyreMantleMolten", Item.buyPrice(silver: 1), Condition.DownedMechBossAll)
                .AddModItemToShop(ModConditions.calamityMod, "Navystone", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.calamityMod, "NovaeSlag", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityMod, "PlantyMush", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.calamityMod, "PyreMantle", Item.buyPrice(silver: 1), Condition.DownedMechBossAll)
                .AddModItemToShop(ModConditions.calamityMod, "ScorchedBone", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.calamityMod, "ScorchedRemains", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.calamityMod, "SulphurousSand", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.calamityMod, "SulphurousSandstone", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.calamityMod, "SulphurousShale", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.calamityMod, "VernalSoil", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.calamityMod, "Voidstone", Item.buyPrice(silver: 1), Condition.DownedMechBossAll)
            //Calamity Vanities
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "AstralClay", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "AstralDirt", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "AstralIce", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "AstralSand", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "AstralSandstone", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "AstralSnow", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "AstralHardenedSand", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "AstralTreeWood", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "Xenostone", Item.buyPrice(silver: 1), Condition.Hardmode)
            //Confection
                .AddModItemToShop(ModConditions.confectionRebakedMod, "BlueFairyFloss", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "ChocolateFudge", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "CookieBlock", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "CreamBlock", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "Creamsand", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "Creamsandstone", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "Creamstone", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "CreamWood", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "HardenedCreamsand", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "OrangeIce", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "PinkFairyFloss", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "PipBlock", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "PurpleFairyFloss", Item.buyPrice(silver: 1), Condition.Hardmode)
            //Depths
                .AddModItemToShop(ModConditions.depthsMod, "NightWood", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.depthsMod, "PetrifiedWood", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.depthsMod, "Quartz", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.depthsMod, "ShaleBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.depthsMod, "Shalestone", Item.buyPrice(silver: 1))
            //Exalt
                .AddModItemToShop(ModConditions.exaltMod, "Basalt", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
            //Furniture Food & Fun
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "BeanstalkBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "BlinkrootBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "BlueFlowerBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "Chalchum", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "DaybloomBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "DeathweedBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "FertileDirt", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "FireblossomBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "Floralwood", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "KelpBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "Loam", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "Mantilum", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "MoondustBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "MoonglowBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "OrangeFlowerBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "Pallasite", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "PurpleFlowerBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "RedFlowerBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "SeashellBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "ShiverthornBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "StarDirt", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "StarlightOre", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "Starsand", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "Starstone", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "Starwood", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "Veridanite", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "Vinestone", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "WaterleafBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "YellowFlowerBlock", Item.buyPrice(silver: 1))
            //Homeward
                .AddModItemToShop(ModConditions.homewardJourneyMod, "AbyssStone", Item.buyPrice(silver: 1), Condition.DownedMechBossAll)
            //Polarities
                .AddModItemToShop(ModConditions.polaritiesMod, "Limestone", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.polaritiesMod, "RockSalt", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.polaritiesMod, "Salt", Item.buyPrice(silver: 1))
            //Redemption
                .AddModItemToShop(ModConditions.redemptionMod, "AncientDirt", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.redemptionMod, "Asteroid", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.redemptionMod, "ElderWood", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.redemptionMod, "GathicColdstone", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.redemptionMod, "GathicFroststone", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.redemptionMod, "GathicGladestone", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.redemptionMod, "GathicStone", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.redemptionMod, "GloomMushroom", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.redemptionMod, "IrradiatedClay", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.redemptionMod, "IrradiatedCrimstone", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.redemptionMod, "IrradiatedDirt", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.redemptionMod, "IrradiatedEbonstone", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.redemptionMod, "IrradiatedHardenedSand", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.redemptionMod, "IrradiatedIce", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.redemptionMod, "IrradiatedSand", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.redemptionMod, "IrradiatedSandstone", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.redemptionMod, "IrradiatedSnow", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.redemptionMod, "IrradiatedStone", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.redemptionMod, "PetrifiedWood", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.redemptionMod, "PlantMatter", Item.buyPrice(silver: 1))
            //SOTS
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "CharredWood", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "CursedTumor", Item.buyPrice(silver: 1), ModConditions.DownedPharaohsCurse)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "Evostone", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "Wormwood", Item.buyPrice(silver: 1), Condition.DownedKingSlime)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "SootBlock", Item.buyPrice(silver: 1))
            //Spirit
                .AddModItemToShop(ModConditions.spiritMod, "AsteroidBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.spiritMod, "Black_Stone_Item", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.spiritMod, "BlastStoneItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.spiritMod, "CreepingIce", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.spiritMod, "DriftwoodTileItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.spiritMod, "SpiritStoneItem", Item.buyPrice(silver: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(ModConditions.spiritMod, "SpiritWoodItem", Item.buyPrice(silver: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(ModConditions.spiritMod, "AncientBark", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.spiritMod, "ScrapItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.spiritMod, "SpaceJunkItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.spiritMod, "SpiritDirtItem", Item.buyPrice(silver: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(ModConditions.spiritMod, "SpiritIceItem", Item.buyPrice(silver: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(ModConditions.spiritMod, "SpiritSandItem", Item.buyPrice(silver: 1), Condition.DownedMechBossAny)
            //Spooky
                .AddModItemToShop(ModConditions.spookyMod, "EyeBlockItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.spookyMod, "LivingFleshItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.spookyMod, "SpookyStoneItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.spookyMod, "SpookyWoodItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.spookyMod, "SpookyMushItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.spookyMod, "CemeteryStoneItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.spookyMod, "CemeteryDirtItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.spookyMod, "SpookyDirtItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.spookyMod, "ValleyStoneItem", Item.buyPrice(silver: 1))
            //Starlight River
                .AddModItemToShop(ModConditions.starlightRiverMod, "AncientSandstoneItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.starlightRiverMod, "VitricCactusItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.starlightRiverMod, "LeafOvergrowItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.starlightRiverMod, "VitricSandItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.starlightRiverMod, "PalestoneItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.starlightRiverMod, "PermafrostIceItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.starlightRiverMod, "StoneOvergrowItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.starlightRiverMod, "VitricSoftSandItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.starlightRiverMod, "VitricSoftSandItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.starlightRiverMod, "VitricSandPlainItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.starlightRiverMod, "SpringstoneItem", Item.buyPrice(silver: 1))
            //Terrorborn
                .AddModItemToShop(ModConditions.terrorbornMod, "DeimostoneBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.terrorbornMod, "KindlingSoilBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.terrorbornMod, "PyroclasticCloudBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.terrorbornMod, "PyroclasticRaincloudBlock", Item.buyPrice(silver: 1))
            //Thorium
                .AddModItemToShop(ModConditions.thoriumMod, "BrackishClump", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.thoriumMod, "EvergreenBlock", Item.buyPrice(silver: 1), Condition.DownedEverscream, Condition.DownedSantaNK1, Condition.DownedIceQueen)
                .AddModItemToShop(ModConditions.thoriumMod, "GingerbreadBlock", Item.buyPrice(silver: 1), Condition.DownedEverscream, Condition.DownedSantaNK1, Condition.DownedIceQueen)
                .AddModItemToShop(ModConditions.thoriumMod, "MarineBlock", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.thoriumMod, "MossyMarineBlock", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.thoriumMod, "Permafrost", Item.buyPrice(silver: 1), Condition.DownedEverscream, Condition.DownedSantaNK1, Condition.DownedIceQueen)
                .AddModItemToShop(ModConditions.thoriumMod, "SugarCookieBlock", Item.buyPrice(silver: 1), Condition.DownedEverscream, Condition.DownedSantaNK1, Condition.DownedIceQueen)
                .AddModItemToShop(ModConditions.thoriumMod, "YewWood", Item.buyPrice(silver: 1), Condition.DownedGoblinArmy)
            //Valhalla
                .AddModItemToShop(ModConditions.valhallaMod, "LivingSnow", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.valhallaMod, "LivingSnowBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.valhallaMod, "WildRootDirt", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.valhallaMod, "Sinstone", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.valhallaMod, "TarBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.valhallaMod, "WildRoot", Item.buyPrice(silver: 1))
            //Verdant
                .AddModItemToShop(ModConditions.verdantMod, "BackslateTileItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.verdantMod, "LushSoilBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.verdantMod, "LushWoodPlankBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.verdantMod, "MysteriaFluffItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.verdantMod, "MysteriaWood", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.verdantMod, "PuffBlockItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.verdantMod, "SnailShellBlockItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.verdantMod, "ThornBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.verdantMod, "VerdantWoodBlock", Item.buyPrice(silver: 1));
            modNaturalBlocksShop.Register();

            var modBuildingBlocksShop = new NPCShop(Type, "Modded Building Blocks")
            //Calamity
                .AddModItemToShop(ModConditions.calamityMod, "AerialiteBrick", Item.buyPrice(silver: 1), ModConditions.DownedPerforatorsOrHiveMind)
                .AddModItemToShop(ModConditions.calamityMod, "AshenAccentSlab", Item.buyPrice(silver: 1), ModConditions.DownedBrimstoneElemental)
                .AddModItemToShop(ModConditions.calamityMod, "AshenSlab", Item.buyPrice(silver: 1), ModConditions.DownedBrimstoneElemental)
                .AddModItemToShop(ModConditions.calamityMod, "AstralBrick", Item.buyPrice(silver: 1), ModConditions.DownedAstrumDeus)
                .AddModItemToShop(ModConditions.calamityMod, "BrimstoneSlab", Item.buyPrice(silver: 1), ModConditions.DownedBrimstoneElemental)
                .AddModItemToShop(ModConditions.calamityMod, "Cinderplate", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityMod, "CosmiliteBrick", Item.buyPrice(silver: 1), ModConditions.DownedDevourerOfGods)
                .AddModItemToShop(ModConditions.calamityMod, "CryonicBrick", Item.buyPrice(silver: 1), ModConditions.DownedCryogen)
                .AddModItemToShop(ModConditions.calamityMod, "Elumplate", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityMod, "EutrophicGlass", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.calamityMod, "ExoPlating", Item.buyPrice(silver: 1), ModConditions.DownedExoMechs)
                .AddModItemToShop(ModConditions.calamityMod, "ExoPrismPanel", Item.buyPrice(silver: 1), ModConditions.DownedExoMechs)
                .AddModItemToShop(ModConditions.calamityMod, "Havocplate", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityMod, "HazardChevronPanels", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.calamityMod, "LaboratoryPanels", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.calamityMod, "LaboratoryPipePlating", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.calamityMod, "LaboratoryPlating", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.calamityMod, "Navyplate", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityMod, "OccultBrickItem", Item.buyPrice(silver: 1), ModConditions.DownedSupremeCalamitas)
                .AddModItemToShop(ModConditions.calamityMod, "Onyxplate", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityMod, "OtherworldlyStone", Item.buyPrice(silver: 1), ModConditions.DownedCeaselessVoid, ModConditions.DownedStormWeaver, ModConditions.DownedSignus)
                .AddModItemToShop(ModConditions.calamityMod, "PerennialBrick", Item.buyPrice(silver: 1), Condition.DownedPlantera)
                .AddModItemToShop(ModConditions.calamityMod, "PlaguedContainmentBrick", Item.buyPrice(silver: 1), ModConditions.DownedPlaguebringerGoliath)
                .AddModItemToShop(ModConditions.calamityMod, "Plagueplate", Item.buyPrice(silver: 1), ModConditions.DownedPlaguebringerGoliath)
                .AddModItemToShop(ModConditions.calamityMod, "ProfanedCrystal", Item.buyPrice(silver: 1), ModConditions.DownedProvidence)
                .AddModItemToShop(ModConditions.calamityMod, "ProfanedRock", Item.buyPrice(silver: 1), ModConditions.DownedProvidence)
                .AddModItemToShop(ModConditions.calamityMod, "ProfanedSlab", Item.buyPrice(silver: 1), ModConditions.DownedProvidence)
                .AddModItemToShop(ModConditions.calamityMod, "RunicProfanedBrick", Item.buyPrice(silver: 1), ModConditions.DownedProvidence)
                .AddModItemToShop(ModConditions.calamityMod, "RustedPipes", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.calamityMod, "RustedPlating", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.calamityMod, "SeaPrismBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.calamityMod, "ScoriaBrick", Item.buyPrice(silver: 1), Condition.DownedGolem)
                .AddModItemToShop(ModConditions.calamityMod, "SilvaCrystal", Item.buyPrice(silver: 1), ModConditions.DownedDragonfolly)
                .AddModItemToShop(ModConditions.calamityMod, "SmoothAbyssGravel", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.calamityMod, "SmoothBrimstoneSlag", Item.buyPrice(silver: 1), ModConditions.DownedBrimstoneElemental)
                .AddModItemToShop(ModConditions.calamityMod, "SmoothVoidstone", Item.buyPrice(silver: 1), Condition.DownedMechBossAll)
                .AddModItemToShop(ModConditions.calamityMod, "StatigelBlock", Item.buyPrice(silver: 1), ModConditions.DownedSlimeGod)
                .AddModItemToShop(ModConditions.calamityMod, "StratusBricks", Item.buyPrice(silver: 1), ModConditions.DownedPolterghast)
                .AddModItemToShop(ModConditions.calamityMod, "UelibloomBrick", Item.buyPrice(silver: 1), ModConditions.DownedProvidence)
                .AddModItemToShop(ModConditions.calamityMod, "VoidstoneSlab", Item.buyPrice(silver: 1), Condition.DownedMechBossAll)
                .AddModItemToShop(ModConditions.calamityMod, "WulfrumPlating", Item.buyPrice(silver: 1))
            //Calamity Vanities
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "AstralBrick", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "AstralPearlBlock", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "AstralPlating", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "AuricBrick", Item.buyPrice(silver: 1), ModConditions.DownedYharon)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "AzufreSludge", Item.buyPrice(silver: 1), ModConditions.DownedOldDuke)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "BlightedEggBlock", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "Bloodstone", Item.buyPrice(silver: 1), ModConditions.DownedProvidence)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "BloodstoneBrick", Item.buyPrice(silver: 1), ModConditions.DownedProvidence)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "ChiseledBloodstone", Item.buyPrice(silver: 1), ModConditions.DownedProvidence)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "EidolicSlab", Item.buyPrice(silver: 1), ModConditions.DownedPolterghast)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "FrostflakeBrick", Item.buyPrice(silver: 1), ModConditions.DownedCryogen)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "HallowedBrick", Item.buyPrice(silver: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "MeldBlock", Item.buyPrice(silver: 1), ModConditions.DownedLunarPillarAny)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "Necrostone", Item.buyPrice(silver: 1), ModConditions.DownedRavager)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "PhantowaxBlock", Item.buyPrice(silver: 1), ModConditions.DownedPolterghast)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "PolishedAstralMonolith", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "PolishedXenomonolith", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "ShadowBrick", Item.buyPrice(silver: 1), ModConditions.DownedExoMechs, ModConditions.DownedSupremeCalamitas)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "ThanatosPlating", Item.buyPrice(silver: 1), ModConditions.DownedExoMechs)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "ThanatosPlatingVent", Item.buyPrice(silver: 1), ModConditions.DownedExoMechs)
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "WulfrumPlating", Item.buyPrice(silver: 1))
            //Catalyst
                .AddModItemToShop(ModConditions.catalystMod, "Astrogel", Item.buyPrice(silver: 1), ModConditions.DownedAstrageldon)
                .AddModItemToShop(ModConditions.catalystMod, "MetanovaBrick", Item.buyPrice(silver: 1), ModConditions.DownedAstrageldon)
            //Clicker Class
                .AddModItemToShop(ModConditions.clickerClassMod, "MiceBrick", Item.buyPrice(silver: 1), ModConditions.DownedLunarPillarAny)
            //Confection
                .AddModItemToShop(ModConditions.confectionRebakedMod, "CreamstoneBrick", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "HallowedBrick", Item.buyPrice(silver: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "NeapoliniteBrick", Item.buyPrice(silver: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "PastryBlock", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "SacchariteBrick", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "ShellBlock", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "SherbetBricks", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.confectionRebakedMod, "YumBlock", Item.buyPrice(silver: 1), Condition.Hardmode)
            //Depths
                .AddModItemToShop(ModConditions.depthsMod, "AncientShadowBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.depthsMod, "ArqueriteBricks", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.depthsMod, "BlackGemspark", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.depthsMod, "LivingFog", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.depthsMod, "QuartzBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.depthsMod, "QuartzBricks", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.depthsMod, "QuartzPillar", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.depthsMod, "ShadowBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.depthsMod, "ShaleBricks", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.depthsMod, "SilverfallBlock", Item.buyPrice(silver: 1))
            //Exalt
                .AddModItemToShop(ModConditions.exaltMod, "BasaltBrick", Item.buyPrice(gold: 1), Condition.DownedEowOrBoc)
            //Furniture Food & Fun
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "AliceRose", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "AmberBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "AmethystBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "AppleSpiceCakeBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "AquamarineBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "AquamarineGemsparkBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "BlueFlowerBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "CarrotCakeBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "ChalcedonyBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "ChalcedonyGemsparkBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "ChalchumBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "ChocolateBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "CoconutCakeBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "ConstellationBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "CottonCandyBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "DiamondBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "EmeraldBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "ForestCakeBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "GardenBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "IndustrialWaxBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "IronBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "LaminatedFlooring", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "LeadBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "ManaStarAltBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "ManaStarBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "MantilumBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "MilkChocolateBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "MoonsetterBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "MoonsetterPlate", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "NaniteBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "OrangeFlowerBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "PallasiteBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "PerfectlyGenericBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "PeridotBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "PeridotGemsparkBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "PurpleFlowerBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "RedFlowerBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "RoseQuartzBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "RoseQuartzGemsparkBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "RubyBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "SapphireBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "SilkCarpet", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "SoulFlightBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "SoulFrightBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "SoulLightBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "SoulMightBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "SoulNightBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "SoulSightBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "StarlightBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "StarsandstoneBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "StarshineBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "StarshineBlockAlt", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "StarshineBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "StarstoneBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "StrawberryShortCakeBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "SweetBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "TopazBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "VeridaniteBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "VinestoneBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "WhiteChocolateBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "WickerBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "WickerBlock2", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "WickerBlock2", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "YellowFlowerBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "ZilliumBrick", Item.buyPrice(silver: 1))
            //Homeward
                .AddModItemToShop(ModConditions.homewardJourneyMod, "AbyssBrick", Item.buyPrice(silver: 1), Condition.DownedMechBossAll)
            //Polarities
                .AddModItemToShop(ModConditions.polaritiesMod, "GlowingLimestoneBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.polaritiesMod, "HaliteBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.polaritiesMod, "LimestoneBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.polaritiesMod, "SaltBrick", Item.buyPrice(silver: 1))
            //Qwertys
                .AddModItemToShop(ModConditions.qwertyMod, "ChiselledFortressBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.qwertyMod, "ReverseSand", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.qwertyMod, "DnasBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.qwertyMod, "FakeFortressBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.qwertyMod, "FortressBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.qwertyMod, "FortressPillar", Item.buyPrice(silver: 1))
            //Redemption
                .AddModItemToShop(ModConditions.redemptionMod, "GathicColdstoneBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.redemptionMod, "GathicFroststoneBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.redemptionMod, "GathicGladestoneBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.redemptionMod, "GathicStoneBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.redemptionMod, "LabPlating", Item.buyPrice(silver: 1), Condition.DownedMoonLord)
                .AddModItemToShop(ModConditions.redemptionMod, "MetalSupportBeam", Item.buyPrice(silver: 1), Condition.DownedMoonLord)
                .AddModItemToShop(ModConditions.redemptionMod, "NiricPipe", Item.buyPrice(silver: 1), Condition.DownedGolem)
            //SOTS
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "RoyalGoldBrick", Item.buyPrice(silver: 1), ModConditions.DownedPharaohsCurse)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "DissolvingAuroraBlock", Item.buyPrice(silver: 1), ModConditions.DownedPermafrostSpirit)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "AvaritianPlating", Item.buyPrice(silver: 1), ModConditions.DownedOtherworldlyConstruct)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "DissolvingBrillianceBlock", Item.buyPrice(silver: 1), ModConditions.DownedLux)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "ChaosPlating", Item.buyPrice(silver: 1), ModConditions.DownedChaosConstruct)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "DarkShingles", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "DissolvingDelugeBlock", Item.buyPrice(silver: 1), ModConditions.DownedTidalSpirit)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "DullPlating", Item.buyPrice(silver: 1), ModConditions.DownedOtherworldlyConstruct)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "DissolvingEarthBlock", Item.buyPrice(silver: 1), ModConditions.DownedEarthenSpirit)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "EarthenPlating", Item.buyPrice(silver: 1), ModConditions.DownedEarthenConstruct)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "EvilPlating", Item.buyPrice(silver: 1), ModConditions.DownedEvilConstruct)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "EvostoneBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "FrigidBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "HardIceBrick", Item.buyPrice(silver: 1), ModConditions.DownedPolaris)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "HardlightBlock", Item.buyPrice(silver: 1), ModConditions.DownedOtherworldlyConstruct)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "InfernoPlating", Item.buyPrice(silver: 1), ModConditions.DownedInfernoConstruct)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "DissolvingNatureBlock", Item.buyPrice(silver: 1), ModConditions.DownedNatureSpirit)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "NaturePlating", Item.buyPrice(silver: 1), ModConditions.DownedNatureConstruct)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "DissolvingNetherBlock", Item.buyPrice(silver: 1), ModConditions.DownedInfernoSpirit)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "OvergrownPyramidBlock", Item.buyPrice(silver: 1), Condition.DownedMechBossAll)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "PermafrostPlating", Item.buyPrice(silver: 1), ModConditions.DownedPermafrostConstruct)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "DissolvingAetherBlock", Item.buyPrice(silver: 1), ModConditions.DownedAdvisor)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "PyramidBrick", Item.buyPrice(silver: 1), ModConditions.DownedPharaohsCurse)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "PyramidSlab", Item.buyPrice(silver: 1), ModConditions.DownedPharaohsCurse)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "PyramidRubble", Item.buyPrice(silver: 1), ModConditions.DownedPharaohsCurse)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "RuinedPyramidBrick", Item.buyPrice(silver: 1), ModConditions.DownedPharaohsCurse)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "TidePlating", Item.buyPrice(silver: 1), ModConditions.DownedTidalConstruct)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "UltimatePlating", Item.buyPrice(silver: 1), ModConditions.DownedChaosConstruct, ModConditions.DownedEarthenConstruct, ModConditions.DownedEvilConstruct, ModConditions.DownedInfernoConstruct, ModConditions.DownedNatureConstruct, ModConditions.DownedOtherworldlyConstruct, ModConditions.DownedPermafrostConstruct, ModConditions.DownedTidalConstruct)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "DissolvingUmbraBlock", Item.buyPrice(silver: 1), ModConditions.DownedEvilSpirit)
                .AddModItemToShop(ModConditions.secretsOfTheShadowsMod, "VibrantBrick", Item.buyPrice(silver: 1))
            //Spirit
                .AddModItemToShop(ModConditions.spiritMod, "AcidBrick", Item.buyPrice(silver: 1), Condition.DownedPlantera)
                .AddModItemToShop(ModConditions.spiritMod, "SepulchreBrickTwoItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.spiritMod, "SepulchreBrickItem", Item.buyPrice(silver: 1))
            //Starlight River
                .AddModItemToShop(ModConditions.starlightRiverMod, "TempleBrickItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.starlightRiverMod, "AncientSandstoneTileItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.starlightRiverMod, "GreenhouseGlassItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.starlightRiverMod, "BrickOvergrowItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.starlightRiverMod, "SkeletonBrickItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.starlightRiverMod, "VitricBrickItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.starlightRiverMod, "VitricGlassItem", Item.buyPrice(silver: 1))
            //Terrorborn
                .AddModItemToShop(ModConditions.terrorbornMod, "IncendiaryBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.terrorbornMod, "IncendiaryMachineryBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.terrorbornMod, "IncendiaryPipe", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.terrorbornMod, "SmoothDeimostoneBlock", Item.buyPrice(silver: 1))
            //Thorium
                .AddModItemToShop(ModConditions.thoriumMod, "AquamarineGemsparkBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.thoriumMod, "ScaleBlock", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.thoriumMod, "BloodstainedBlock", Item.buyPrice(silver: 1), ModConditions.DownedBloodMoon)
                .AddModItemToShop(ModConditions.thoriumMod, "BookshelfBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.thoriumMod, "CelestialBrick", Item.buyPrice(silver: 1), ModConditions.DownedLunarPillarAny)
                .AddModItemToShop(ModConditions.thoriumMod, "CelestialFragmentBlock", Item.buyPrice(silver: 1), ModConditions.DownedLunarPillarAny)
                .AddModItemToShop(ModConditions.thoriumMod, "CheckeredBrick", Item.buyPrice(silver: 1), Condition.DownedSkeletron)
                .AddModItemToShop(ModConditions.thoriumMod, "CursedBlock", Item.buyPrice(silver: 1), ModConditions.DownedLich)
                .AddModItemToShop(ModConditions.thoriumMod, "CutSandstoneBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.thoriumMod, "CutSandstoneBlockSlab", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.thoriumMod, "CutStoneBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.thoriumMod, "CutStoneBlockSlab", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.thoriumMod, "GlowingMarineBlock", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.thoriumMod, "IllumiteBrick", Item.buyPrice(silver: 1), Condition.DownedPlantera)
                .AddModItemToShop(ModConditions.thoriumMod, "LodestoneSlab", Item.buyPrice(silver: 1), ModConditions.DownedFallenBeholder)
                .AddModItemToShop(ModConditions.thoriumMod, "MediciteBrick", Item.buyPrice(silver: 1), ModConditions.DownedBloodMoon)
                .AddModItemToShop(ModConditions.thoriumMod, "NagaBlock", Item.buyPrice(silver: 1), Condition.Hardmode)
                .AddModItemToShop(ModConditions.thoriumMod, "OpalGemsparkBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.thoriumMod, "OrnateBlock", Item.buyPrice(silver: 1), Condition.DownedPlantera)
                .AddModItemToShop(ModConditions.thoriumMod, "PlateSlab", Item.buyPrice(silver: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(ModConditions.thoriumMod, "PotionShelfBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.thoriumMod, "RefinedMarineBlock", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.thoriumMod, "ScarletBlock", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.thoriumMod, "ShadyBlock", Item.buyPrice(silver: 1), Condition.DownedPlantera)
                .AddModItemToShop(ModConditions.thoriumMod, "ShootingStarBrick", Item.buyPrice(silver: 1), ModConditions.DownedLunarPillarAny)
                .AddModItemToShop(ModConditions.thoriumMod, "ShootingStarFragmentBlock", Item.buyPrice(silver: 1), ModConditions.DownedLunarPillarAny)
                .AddModItemToShop(ModConditions.thoriumMod, "SmoothWood", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.thoriumMod, "ThoriumBrickBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.thoriumMod, "ThoriumBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.thoriumMod, "ValadiumPlating", Item.buyPrice(silver: 1), ModConditions.DownedFallenBeholder)
                .AddModItemToShop(ModConditions.thoriumMod, "WhiteDwarfBrick", Item.buyPrice(silver: 1), ModConditions.DownedLunarPillarAny)
                .AddModItemToShop(ModConditions.thoriumMod, "WhiteDwarfFragmentBlock", Item.buyPrice(silver: 1), ModConditions.DownedLunarPillarAny)
            //Valhalla
                .AddModItemToShop(ModConditions.valhallaMod, "BurntCobble", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.valhallaMod, "CorrodeBrick", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.valhallaMod, "HardGlassBlock", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.valhallaMod, "HellstoneRoof", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.valhallaMod, "SinstoneBrick", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc)
                .AddModItemToShop(ModConditions.valhallaMod, "Terracotta", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.valhallaMod, "ValhalliteBrick", Item.buyPrice(silver: 1))
            //Verdant
                .AddModItemToShop(ModConditions.verdantMod, "OvergrownBrickItem", Item.buyPrice(silver: 1))
            //Vitality
                .AddModItemToShop(ModConditions.vitalityMod, "ArcticBrick", Item.buyPrice(silver: 1), Condition.DownedMechBossAny)
                .AddModItemToShop(ModConditions.vitalityMod, "BronzeBrick", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.vitalityMod, "GeraniumBrick", Item.buyPrice(silver: 1), Condition.DownedSkeletron);
            modBuildingBlocksShop.Register();

            var modPlantShop = new NPCShop(Type, "Modded Herbs & Plants")
            //Arbour
                .AddModItemToShop(ModConditions.arbourMod, "ArborGrassSeeds", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.arbourMod, "MicrobirchAcorn", Item.buyPrice(silver: 1))
            //Aequus
                .AddModItemToShop(ModConditions.aequusMod, "ManaclePollen", Item.buyPrice(silver: 1), ModConditions.DownedDemonSiege)
                .AddModItemToShop(ModConditions.aequusMod, "MistralPollen", Item.buyPrice(silver: 1), ModConditions.DownedDustDevil)
                .AddModItemToShop(ModConditions.aequusMod, "MoonflowerPollen", Item.buyPrice(silver: 1), ModConditions.DownedOmegaStarite)
                .AddModItemToShop(ModConditions.aequusMod, "MorayPollen", Item.buyPrice(silver: 1), ModConditions.DownedCrabson)
            //Calamity
                .AddModItemToShop(ModConditions.calamityMod, "AstralGrassSeeds", Item.buyPrice(silver: 1), Condition.Hardmode, ModConditions.HasBeenToAstral)
                .AddModItemToShop(ModConditions.calamityMod, "CinderBlossomSeeds", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc, ModConditions.HasBeenToCrags)
                .AddModItemToShop(ModConditions.calamityMod, "SpineSapling", Item.buyPrice(silver: 1), Condition.DownedEowOrBoc, ModConditions.HasBeenToCrags)
            //Calamity Vanities
                .AddModItemToShop(ModConditions.calamityVanitiesMod, "AstralGrass", Item.buyPrice(silver: 1), Condition.Hardmode, ModConditions.HasBeenToAstral)
            //Confection
                .AddModItemToShop(ModConditions.confectionRebakedMod, "CreamBeans", Item.buyPrice(silver: 1), Condition.Hardmode, ModConditions.HasBeenToConfectionOrHallow)
            //Depths
                .AddModItemToShop(ModConditions.depthsMod, "ShadowShrub", Item.buyPrice(silver: 1), ModConditions.HasBeenToDepthsOrUnderworld)
            //Furniture Food & Fun
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "CelestialGrassSeed", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.furnitureFoodAndFunMod, "GardenGrassSeed", Item.buyPrice(silver: 1))
            //Gensokyo
                .AddModItemToShop(ModConditions.gensokyoMod, "EssenceOfSpring", Item.buyPrice(silver: 1), ModConditions.DownedLilyWhite)
            //Redemption
                .AddModItemToShop(ModConditions.redemptionMod, "AnglonicMysticBlossom", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.redemptionMod, "LivingTwig", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.redemptionMod, "Nightshade", Item.buyPrice(silver: 1))
            //Spirit
                .AddModItemToShop(ModConditions.spiritMod, "CloudstalkItem", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.spiritMod, "EnchantedLeaf", Item.buyPrice(silver: 1))
                .AddModItemToShop(ModConditions.spiritMod, "GlowRoot", Item.buyPrice(silver: 1), ModConditions.HasBeenToMushroom)
                .AddModItemToShop(ModConditions.spiritMod, "Kelp", Item.buyPrice(silver: 1), ModConditions.HasBeenToOcean)
                .AddModItemToShop(ModConditions.spiritMod, "SoulBloom", Item.buyPrice(silver: 1), Condition.DownedMechBossAny, ModConditions.HasBeenToSpirit)
                .AddModItemToShop(ModConditions.spiritMod, "BriarGrassSeeds", Item.buyPrice(silver: 1), ModConditions.HasBeenToBriar)
            //Spooky
                .AddModItemToShop(ModConditions.spookyMod, "SpookySeedsGreen", Item.buyPrice(silver: 1), ModConditions.HasBeenToSpookyForest)
                .AddModItemToShop(ModConditions.spookyMod, "SpookySeedsOrange", Item.buyPrice(silver: 1), ModConditions.HasBeenToSpookyForest)
                .AddModItemToShop(ModConditions.spookyMod, "MushroomMossSeeds", Item.buyPrice(silver: 1), ModConditions.HasBeenToSpookyUnderground)
            //Thorium
                .AddModItemToShop(ModConditions.thoriumMod, "MarineKelp", Item.buyPrice(silver: 1), ModConditions.HasBeenToAquaticDepths)
            //Verdant
                .AddModItemToShop(ModConditions.verdantMod, "LightbulbSeeds", Item.buyPrice(silver: 1), ModConditions.HasBeenToVerdant)
                .AddModItemToShop(ModConditions.verdantMod, "MysteriaAcorn", Item.buyPrice(silver: 1), ModConditions.HasBeenToVerdant)
                .AddModItemToShop(ModConditions.verdantMod, "WisplantSeeds", Item.buyPrice(silver: 1), ModConditions.HasBeenToVerdant);
            modPlantShop.Register();
        }
    }
}