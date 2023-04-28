using Microsoft.Xna.Framework;
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
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<QoLCConfig>().ECNPC;
        }

        public override string Texture
        {
            get
            {
                return "QoLCompendium/NPCs/EtherealCollectorNPC";
            }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ethereal Collector");
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
            NPC.alpha = 100;
            NPC.HitSound = new SoundStyle?(SoundID.NPCHit1);
            NPC.DeathSound = new SoundStyle?(SoundID.NPCDeath1);
            NPC.knockBackResist = 0.5f;
            AnimationType = 22;
        }

        public override void DrawEffects(ref Color drawColor)
        {
            Lighting.AddLight(NPC.Center, 1f, 1f, 1f);
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            return true;
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
            return result;
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            if (shopNum == 0)
            {
                button = "Modded Potions";
            }
            else if (shopNum == 1)
            {
                button = "Modded Materials";
            }
            else if (shopNum == 2)
            {
                button = "Rare Modded Materials";
            }
            else if (shopNum == 3)
            {
                button = "Modded Treasure Bags 1";
            }
            else if (shopNum == 4)
            {
                button = "Modded Treasure Bags 2";
            }
            else if (shopNum == 5)
            {
                button = "Modded Treasure Bags 3";
            }
            button2 = "Shop Changer";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
                ECNPCUI.visible = false;
            }
            else
            {
                if (!ECNPCUI.visible) ECNPCUI.timeStart = Main.GameUpdateCount;
                ECNPCUI.visible = true;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            if (shopNum == 0)
            {
                if (CheckDowned.calamityLoaded)
                {
                    shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("AnechoicCoating").Type);
                    nextSlot++;
                    if (CheckDowned.downedAureus)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("AstralInjection").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("AureusCell").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("Baguette").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("BoundingPotion").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("CalciumPotion").Type);
                    nextSlot++;
                    if (CheckDowned.downedCalamitas)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("FlaskOfBrimstone").Type);
                        nextSlot++;
                    }
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("CrumblingPotion").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedAureus)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("GravityNormalizerPotion").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedProvidence)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("HolyWrathPotion").Type);
                        nextSlot++;
                    }
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("PhotosynthesisPotion").Type);
                        nextSlot++;
                    }
                    if (NPC.downedBoss3)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("PotionofOmniscience").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("ShadowPotion").Type);
                    nextSlot++;
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("SoaringPotion").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("SulphurskinPotion").Type);
                    nextSlot++;
                    if (CheckDowned.downedDesertScourge && (CheckDowned.downedHiveMind || CheckDowned.downedPerforators))
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("TeslaPotion").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedSlimeGod)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("ZenPotion").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("ZergPotion").Type);
                        nextSlot++;
                    }
                }
                if (CheckDowned.catalystLoaded)
                {
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.catalystMod.Find<ModItem>("AstraJelly").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedAureus)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.catalystMod.Find<ModItem>("Lean").Type);
                        nextSlot++;
                    }
                }
                if (CheckDowned.thoriumLoaded)
                {
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("AquaPotion").Type);
                    nextSlot++;
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("ArcanePotion").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("ArtilleryPotion").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("AssassinPotion").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("BloodPotion").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("BouncingFlamePotion").Type);
                    nextSlot++;
                    if (CheckDowned.downedGrandBird)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("CactusFruit").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("ConflagrationPotion").Type);
                    nextSlot++;
                    if (CheckDowned.downedGrandBird)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("CreativityPotion").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("EarwormPotion").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("FrenzyPotion").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("GlowingPotion").Type);
                    nextSlot++;
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("HolyPotion").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("HydrationPotion").Type);
                    nextSlot++;
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("InspirationReachPotion").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("KineticPotion").Type);
                        nextSlot++;
                    }
                    if (NPC.downedBoss2)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("WarmongerPotion").Type);
                        nextSlot++;
                    }
                }
                if (CheckDowned.sotsLoaded)
                {
                    shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("AbyssalTonic").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("AssassinationPotion").Type);
                    nextSlot++;
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("BlazingTonic").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("BlightfulTonic").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("BluefirePotion").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("BrittlePotion").Type);
                    nextSlot++;
                    if (NPC.downedBoss2)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("DoubleVisionPotion").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedLux)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("EtherealTonic").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("GlacialTonic").Type);
                    nextSlot++;
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("HarmonyPotion").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("HereticTonic").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("NightmarePotion").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("RipplePotion").Type);
                    nextSlot++;
                    if (NPC.downedBoss2)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("RoughskinPotion").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("SeismicTonic").Type);
                    nextSlot++;
                    if (NPC.downedBoss2)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("SoulAccessPotion").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedAdvisor)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("StarlightTonic").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("VibePotion").Type);
                    nextSlot++;
                }
                if (CheckDowned.redemptionLoaded)
                {
                    if (CheckDowned.downedThorn)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("CharismaPotion").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("VendettaPotion").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedNebby)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("VigourousPotion").Type);
                        nextSlot++;
                    }
                }
                if (CheckDowned.polaritiesLoaded)
                {
                    shop.item[nextSlot].SetDefaults(CheckDowned.polaritiesMod.Find<ModItem>("PiercingPotion").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.polaritiesMod.Find<ModItem>("TolerancePotion").Type);
                    nextSlot++;
                }
                if (CheckDowned.terrorbornLoaded)
                {
                    shop.item[nextSlot].SetDefaults(CheckDowned.terrorbornMod.Find<ModItem>("AdrenalinePotion").Type);
                    nextSlot++;
                    if (CheckDowned.downedTitan)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.terrorbornMod.Find<ModItem>("AerodynamicPotion").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.terrorbornMod.Find<ModItem>("BloodFlowPotion").Type);
                    nextSlot++;
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.terrorbornMod.Find<ModItem>("SinducementPotion").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.terrorbornMod.Find<ModItem>("StarpowerPotion").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.terrorbornMod.Find<ModItem>("VampirismPotion").Type);
                    nextSlot++;
                }
                if (CheckDowned.vitalityLoaded)
                {
                    shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("ArmorPiercingPotion").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("LeapingPotion").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("TranquillityPotion").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("TravelsensePotion").Type);
                    nextSlot++;
                    if (NPC.downedBoss2)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("WarriorPotion").Type);
                        nextSlot++;
                    }
                }
                if (CheckDowned.aqLoaded)
                {
                    shop.item[nextSlot].SetDefaults(CheckDowned.aqMod.Find<ModItem>("BloodthirstPotion").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.aqMod.Find<ModItem>("FrostPotion").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.aqMod.Find<ModItem>("ManathirstPotion").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.aqMod.Find<ModItem>("NecromancyPotion").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.aqMod.Find<ModItem>("NeutronYogurt").Type);
                    nextSlot++;
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.aqMod.Find<ModItem>("NoonPotion").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.aqMod.Find<ModItem>("SentryPotion").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.aqMod.Find<ModItem>("VeinminerPotion").Type);
                    nextSlot++;
                }
            }
            if (shopNum == 1)
            {
                if (CheckDowned.calamityLoaded)
                {
                    shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("AncientBoneDust").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("BeetleJuice").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("BlightedGel").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("BloodOrb").Type);
                    nextSlot++;
                    if (CheckDowned.downedPerforators)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("BloodSample").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("DemonicBoneAsh").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("DesertFeather").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("EnergyCore").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("MurkyPaste").Type);
                    nextSlot++;
                    if (CheckDowned.downedDesertScourge)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("PearlShard").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedSlimeGod)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("PurifiedGel").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedHiveMind)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("RottenMatter").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("StormlionMandible").Type);
                    nextSlot++;
                    if (NPC.downedBoss1)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("SulphuricScale").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("WulfrumMetalScrap").Type);
                    nextSlot++;
                }
                if (CheckDowned.thoriumLoaded)
                {
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("ArcaneDust").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("LivingLeaf").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("IcyShard").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("Petal").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("Blood").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("BirdTalon").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("UnholyShards").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("PurityShards").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("MarineKelp").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("DepthScale").Type);
                    nextSlot++;
                    if (NPC.downedBoss2)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("StrangeAlienTech").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("YewWood").Type);
                        nextSlot++;
                    }
                    if (NPC.downedBoss3)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("GraniteEnergyCore").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("BronzeFragments").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("SpiritDroplet").Type);
                        nextSlot++;
                    }
                }
                if (CheckDowned.sotsLoaded)
                {
                    shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("FragmentOfNature").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("FragmentOfEarth").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("FragmentOfPermafrost").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("FragmentOfTide").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("FragmentOfOtherworld").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("FragmentOfEvil").Type);
                    nextSlot++;
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("FragmentOfChaos").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("FragmentOfInferno").Type);
                    nextSlot++;
                }
                if (CheckDowned.redemptionLoaded)
                {
                    shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("CoastScarabShell").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("GraveSteelShards").Type);
                    nextSlot++;
                    if (CheckDowned.downedKeeper)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("GrimShard").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("LivingTwig").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("LostSoul").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("MoonflareFragment").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("TreeBugShell").Type);
                    nextSlot++;
                    if (CheckDowned.downedSeed)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("XenomiteShard").Type);
                        nextSlot++;
                    }
                }
                if (CheckDowned.polaritiesLoaded)
                {
                    shop.item[nextSlot].SetDefaults(CheckDowned.polaritiesMod.Find<ModItem>("AlkalineFluid").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.polaritiesMod.Find<ModItem>("Rattle").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.polaritiesMod.Find<ModItem>("SaltCrystals").Type);
                    nextSlot++;
                    if (CheckDowned.downedCloudfish)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.polaritiesMod.Find<ModItem>("StormChunk").Type);
                        nextSlot++;
                    }
                }
                if (CheckDowned.vitalityLoaded)
                {
                    shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("AncientGoldShard").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("Charcoal").Type);
                    nextSlot++;
                    if (CheckDowned.downedStormCloud)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("CloudVapor").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("GlacialChunk").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("GlowingGranitePowder").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("LivingStick").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("PurifiedSpore").Type);
                    nextSlot++;
                }
                if (CheckDowned.aqLoaded)
                {
                    if (CheckDowned.downedCrabson)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.aqMod.Find<ModItem>("AquaticEnergy").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedSprite || CheckDowned.downedSpaceSquid || CheckDowned.downedDevil)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.aqMod.Find<ModItem>("AtmosphericEnergy").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedStarite)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.aqMod.Find<ModItem>("CosmicEnergy").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.aqMod.Find<ModItem>("DemonicEnergy").Type);
                    nextSlot++;
                    if (NPC.downedPlantBoss)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.aqMod.Find<ModItem>("OrganicEnergy").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.aqMod.Find<ModItem>("UltimateEnergy").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.aqMod.Find<ModItem>("BloodyTearstone").Type);
                    nextSlot++;
                    if (CheckDowned.downedSprite)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.aqMod.Find<ModItem>("Fluorescence").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedSpaceSquid)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.aqMod.Find<ModItem>("FrozenTear").Type);
                        nextSlot++;
                    }
                    if (NPC.downedPlantBoss)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.aqMod.Find<ModItem>("Hexoplasm").Type);
                        nextSlot++;
                    }
                }
            }
            if (shopNum == 2)
            {
                if (CheckDowned.calamityLoaded)
                {
                    if (CheckDowned.downedStormWeaver)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("ArmoredShell").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedSupremeCalamitas)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("AshesofAnnihilation").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedCalamitas)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("AshesofCalamity").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedProvidence)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("Bloodstone").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedCeaselessVoid)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("DarkPlasma").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedDevourerOfGods)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("DarksunFragment").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedCalamitas)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("DepthCells").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedProvidence)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("DivineGeode").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("DubiousPlating").Type);
                    nextSlot++;
                    if (CheckDowned.downedDragonfolly)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("EffulgentFeather").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedDevourerOfGods)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("EndothermicEnergy").Type);
                        nextSlot++;
                    }
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("EssenceofChaos").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("EssenceofEleum").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("EssenceofSunlight").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedExoMechs)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("ExoPrism").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedGreatSandShark)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("GrandScale").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedPlaguebringer)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("InfectedArmorPlating").Type);
                        nextSlot++;
                    }
                    if (NPC.downedPlantBoss)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("LivingShard").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedCalamitas)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("Lumenyl").Type);
                        nextSlot++;
                    }
                    if (NPC.downedAncientCultist)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("MeldBlob").Type);
                        nextSlot++;
                    }
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("MolluskHusk").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("MysteriousCircuitry").Type);
                    nextSlot++;
                    if (CheckDowned.downedDevourerOfGods)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("NightmareFuel").Type);
                        nextSlot++;
                    }
                    if (NPC.downedMoonlord)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("Phantoplasm").Type);
                        nextSlot++;
                    }
                    if (NPC.downedGolemBoss)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("PlagueCellCanister").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedPolterghast)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("ReaperTooth").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("RuinousSoul").Type);
                        nextSlot++;
                    }
                    if (NPC.downedPlantBoss || CheckDowned.downedCalamitas)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("SolarVeil").Type);
                        nextSlot++;
                    }
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("Stardust").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("TitanHeart").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("TrapperBulb").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedSignus)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("TwistingNether").Type);
                        nextSlot++;
                    }
                    if (NPC.downedMoonlord)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("UnholyEssence").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedYharon)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("YharonSoulFragment").Type);
                        nextSlot++;
                    }
                }
                if (CheckDowned.thoriumLoaded && Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("SoulofPlight").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("CeruleanMorel").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("PharaohsBreath").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("BioMatter").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("AbyssalChitin").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("HallowedCharm").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("Geode").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("GreenDragonScale").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("UnfathomableFlesh").Type);
                    nextSlot++;
                    if (NPC.downedMechBossAny)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("StrangePlating").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("LifeCell").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedLich)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("CursedCloth").Type);
                        nextSlot++;
                    }
                    if (NPC.downedPlantBoss)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("BloomWeave").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("SolarPebble").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("DreadSoul").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("DemonBloodShard").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("DarkMatter").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("HolyKnightsAlloy").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("BloomWeave").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("BrokenHeroFragment").Type);
                        nextSlot++;
                    }
                    if (NPC.downedAncientCultist)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("TerrariumCore").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("WhiteDwarfFragment").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("CelestialFragment").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("ShootingStarFragment").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedPrimordials)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("InfernoEssence").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("DeathEssence").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("OceanEssence").Type);
                        nextSlot++;
                    }
                }
                if (CheckDowned.sotsLoaded)
                {
                    shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("DissolvingNature").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("DissolvingEarth").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("DissolvingAurora").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("DissolvingDeluge").Type);
                    nextSlot++;
                    if (CheckDowned.downedAdvisor)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("DissolvingAether").Type);
                        nextSlot++;
                    }
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("DissolvingUmbra").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("DissolvingNether").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedLux)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("DissolvingBrilliance").Type);
                        nextSlot++;
                    }
                }
                if (CheckDowned.redemptionLoaded && Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("AIChip").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("CarbonMyofibre").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("Capacitator").Type);
                    nextSlot++;
                    if (CheckDowned.downedDuo)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("GildedStar").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedNebby)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("LifeFragment").Type);
                        nextSlot++;
                    }
                    if (NPC.downedMoonlord)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("MoltenScrap").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("Plating").Type);
                    nextSlot++;
                    if (NPC.downedMoonlord)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("Plutonium").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("RawXenium").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("ToxicBile").Type);
                    nextSlot++;
                    if (CheckDowned.downedCleaver)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("CorruptedXenomite").Type);
                        nextSlot++;
                    }
                    if (NPC.downedGolemBoss)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("Uranium").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("Xenomite").Type);
                    nextSlot++;
                    if (NPC.downedMoonlord)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("XeniumAlloy").Type);
                        nextSlot++;
                    }
                }
                if (CheckDowned.polaritiesLoaded && Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(CheckDowned.polaritiesMod.Find<ModItem>("CongealedBrine").Type);
                    nextSlot++;
                    if (CheckDowned.downedEsophage)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.polaritiesMod.Find<ModItem>("EvilDNA").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.polaritiesMod.Find<ModItem>("LimestoneCarapace").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.polaritiesMod.Find<ModItem>("SerpentScale").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.polaritiesMod.Find<ModItem>("Tentacle").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.polaritiesMod.Find<ModItem>("VenomGland").Type);
                    nextSlot++;
                    if (CheckDowned.downedWanderer)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.polaritiesMod.Find<ModItem>("WandererPlating").Type);
                        nextSlot++;
                    }
                }
                if (CheckDowned.vitalityLoaded && Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("ChaosCrystal").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("ChaosDust").Type);
                    nextSlot++;
                    if (CheckDowned.downedPaladinSpirit)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("Ectosoul").Type);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("EquityCore").Type);
                        nextSlot++;
                    }
                    shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("EssenceofFire").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("EssenceofFrost").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("ForbiddenFeather").Type);
                    nextSlot++;
                    if (NPC.downedPlantBoss)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("ShiverFragment").Type);
                        nextSlot++;
                    }
                    if (CheckDowned.downedPaladinSpirit || NPC.downedPlantBoss)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("SoulofVitality").Type);
                        nextSlot++;
                    }
                }
            }
            if (shopNum == 3)
            {
                if (CheckDowned.calamityLoaded)
                {
                    if (CheckDowned.downedDesertScourge)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("DesertScourgeBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedCrabulon)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("CrabulonBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedHiveMind)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("HiveMindBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedPerforators)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("PerforatorBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedSlimeGod)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("SlimeGodBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedCryogen)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("CryogenBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedAquaticScourge)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("AquaticScourgeBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedBrimstoneElemental)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("BrimstoneWaifuBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedCalamitas)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("CalamitasCloneBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedLeviathan)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("LeviathanBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedAureus)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("AstrumAureusBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedPlaguebringer)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("PlaguebringerGoliathBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedRavager)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("RavagerBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedDeus)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("AstrumDeusBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedDragonfolly)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("DragonfollyBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedProvidence)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("ProvidenceBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedPolterghast)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("PolterghastBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedCeaselessVoid)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("CeaselessVoidBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedStormWeaver)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("StormWeaverBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedSignus)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("SignusBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedOldDuke)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("OldDukeBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedDevourerOfGods)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("DevourerofGodsBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedYharon)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("YharonBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedExoMechs)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("DraedonBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedSupremeCalamitas)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.calamityMod.Find<ModItem>("CalamitasCoffer").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                }
                if (CheckDowned.catalystLoaded)
                {
                    if (CheckDowned.downedGeldon)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.catalystMod.Find<ModItem>("AstrageldonBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                }
                if (CheckDowned.thoriumLoaded)
                {
                    if (CheckDowned.downedGrandBird)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("ThunderBirdBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedQueenJelly)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("JellyFishBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedViscount)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("CountBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedEnergyStorm)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("GraniteBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedBuriedChampion)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("HeroBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedScouter)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("ScouterBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedStrider)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("BoreanBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedFallenBeholder)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("BeholderBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedLich)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("LichBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedForgottenOne)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("AbyssionBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedPrimordials)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.thoriumMod.Find<ModItem>("RagBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                }
                if (CheckDowned.redemptionLoaded)
                {
                    if (CheckDowned.downedThorn)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("ThornBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedErhan)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("ErhanBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedKeeper)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("KeeperBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedSeed)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("SoIBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedKS3)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("SlayerBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedCleaver)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("OmegaCleaverBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedGigapora)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("OmegaGigaporaBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedObliterator)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("OmegaOblitBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedZero)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("PZBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedDuo)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("AkkaBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("UkkoBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedNebby)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.redemptionMod.Find<ModItem>("NebBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                }
                if (CheckDowned.homewardLoaded)
                {
                    if (CheckDowned.downedSquid)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.homewardMod.Find<ModItem>("MarquisMoonsquidTreasureBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedRod)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.homewardMod.Find<ModItem>("PriestessRodTreasureBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedDiver)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.homewardMod.Find<ModItem>("DiverTreasureBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedMotherbrain)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.homewardMod.Find<ModItem>("TheMotherbrainTreasureBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedWoS)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.homewardMod.Find<ModItem>("WallofShadowTreasureBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedSGod)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.homewardMod.Find<ModItem>("SlimeGodTreasureBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedOverwatcher)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.homewardMod.Find<ModItem>("TheOverwatcherTreasureBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedLifebringer)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.homewardMod.Find<ModItem>("TheLifebringerTreasureBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedMaterealizer)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.homewardMod.Find<ModItem>("TheMaterealizerTreasureBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedScarab)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.homewardMod.Find<ModItem>("ScarabBeliefTreasureBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedWhale)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.homewardMod.Find<ModItem>("EverlastingFallingWhaleTreasureBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedSon)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.homewardMod.Find<ModItem>("TheSonTreasureBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                }
            }
            if (shopNum == 4)
            {
                if (CheckDowned.sotsLoaded)
                {
                    if (CheckDowned.downedPutridPinky)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("PinkyBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedPharaohsCurse)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("CurseBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedAdvisor)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("TheAdvisorBossBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedPolaris)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("PolarisBossBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedLux)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("LuxBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedSerpent)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.sotsMod.Find<ModItem>("SubspaceBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                }
                if (CheckDowned.terrorbornLoaded)
                {
                    if (CheckDowned.downedIncarnate)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.terrorbornMod.Find<ModItem>("II_TreasureBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedTitan)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.terrorbornMod.Find<ModItem>("TT_TreasureBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedDunestock)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.terrorbornMod.Find<ModItem>("DS_TreasureBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedCrawler)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.terrorbornMod.Find<ModItem>("SC_TreasureBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedConstructor)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.terrorbornMod.Find<ModItem>("HC_TreasureBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedP1)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.terrorbornMod.Find<ModItem>("PI_TreasureBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                }
                if (CheckDowned.vitalityLoaded)
                {
                    if (CheckDowned.downedStormCloud)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("StormCloudBossBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedGrandAntlion)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("GrandAntlionBossBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedGemstoneElemental)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("GemstoneElementalBossBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedMoonlightDragonfly)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("MoonlightDragonflyBossBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedDreadnaught)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("DreadnaughtBossBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedAnarchulesBeetle)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("AnarchulesBeetleBossBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedChaosbringer)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("ChaosbringerBossBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedPaladinSpirit)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.vitalityMod.Find<ModItem>("PaladinSpiritBossBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                }
                if (CheckDowned.consolariaLoaded)
                {
                    if (CheckDowned.downedLepus)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.consolariaMod.Find<ModItem>("LepusBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedTurkor)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.consolariaMod.Find<ModItem>("TurkorBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedOcram)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.consolariaMod.Find<ModItem>("OcramBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                }
            }
            if (shopNum == 5)
            {
                if (CheckDowned.spookyLoaded)
                {
                    if (CheckDowned.downedGourd)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.spookyMod.Find<ModItem>("BossBagRotGourd").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedMoco)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.spookyMod.Find<ModItem>("BossBagMoco").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedOrroBoro)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.spookyMod.Find<ModItem>("BossBagOrroboro").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedBigBone)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.spookyMod.Find<ModItem>("BossBagBigBone").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                }
                if (CheckDowned.fargosSoulsLoaded)
                {
                    if (CheckDowned.downedTrojanSquirrel)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.fargosSoulsMod.Find<ModItem>("TrojanSquirrelBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedDeviant)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.fargosSoulsMod.Find<ModItem>("DeviBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedLieflight)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.fargosSoulsMod.Find<ModItem>("LifeChallengerBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedCosmosChampion)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.fargosSoulsMod.Find<ModItem>("CosmosBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedAbomination)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.fargosSoulsMod.Find<ModItem>("AbomBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedMutant)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.fargosSoulsMod.Find<ModItem>("MutantBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                }
                if (CheckDowned.polaritiesLoaded)
                {
                    if (CheckDowned.downedCloudfish)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.polaritiesMod.Find<ModItem>("StormCloudfishBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedConstruct)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.polaritiesMod.Find<ModItem>("StarConstructBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedGigabat)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.polaritiesMod.Find<ModItem>("GigabatBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedSunPixie)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.polaritiesMod.Find<ModItem>("SunPixieBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedEsophage)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.polaritiesMod.Find<ModItem>("EsophageBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedWanderer)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.polaritiesMod.Find<ModItem>("ConvectiveWandererBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                }
                if (CheckDowned.aqLoaded)
                {
                    if (CheckDowned.downedCrabson)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.aqMod.Find<ModItem>("CrabsonBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedStarite)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.aqMod.Find<ModItem>("OmegaStariteBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                    if (CheckDowned.downedDevil)
                    {
                        shop.item[nextSlot].SetDefaults(CheckDowned.aqMod.Find<ModItem>("DustDevilBag").Type);
                        shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0));
                        nextSlot++;
                    }
                }
            }
        }

        public static int shopNum;
    }
}
