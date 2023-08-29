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
        public static int shopNum = 0;
        public static string ShopName;

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
            /*
            else if (shopNum == 8)
            {
                button = "Modded Herbs & Plants";
                ShopName = "Modded Herbs & Plants";
            }
            */
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
            var modPotionsShop = new NPCShop(Type, "Modded Potions");
            if (CheckDowned.aqLoaded)
            {
                if (CheckDowned.aqMod.TryFind("BloodthirstPotion", out ModItem BloodthirstPotion))
                {
                    modPotionsShop.Add(BloodthirstPotion.Type);
                }
                if (CheckDowned.aqMod.TryFind("FrostPotion", out ModItem FrostPotion))
                {
                    modPotionsShop.Add(FrostPotion.Type);
                }
                if (CheckDowned.aqMod.TryFind("ManathirstPotion", out ModItem ManathirstPotion))
                {
                    modPotionsShop.Add(ManathirstPotion.Type);
                }
                if (CheckDowned.aqMod.TryFind("NecromancyPotion", out ModItem NecromancyPotion))
                {
                    modPotionsShop.Add(NecromancyPotion.Type);
                }
                if (CheckDowned.aqMod.TryFind("NeutronYogurt", out ModItem NeutronYogurt))
                {
                    modPotionsShop.Add(NeutronYogurt.Type);
                }
                if (CheckDowned.aqMod.TryFind("NoonPotion", out ModItem NoonPotion))
                {
                    modPotionsShop.Add(NoonPotion.Type, Condition.Hardmode);
                }
                if (CheckDowned.aqMod.TryFind("SentryPotion", out ModItem SentryPotion))
                {
                    modPotionsShop.Add(SentryPotion.Type);
                }
                if (CheckDowned.aqMod.TryFind("VeinminerPotion", out ModItem VeinminerPotion))
                {
                    modPotionsShop.Add(VeinminerPotion.Type);
                }
            }
            if (CheckDowned.calamityLoaded)
            {
                if (CheckDowned.calamityMod.TryFind("AnechoicCoating", out ModItem AnechoicCoating))
                {
                    modPotionsShop.Add(AnechoicCoating.Type);
                }
                if (CheckDowned.calamityMod.TryFind("AstralInjection", out ModItem AstralInjection))
                {
                    modPotionsShop.Add(AstralInjection.Type, CheckDowned.aureus);
                }
                if (CheckDowned.calamityMod.TryFind("AureusCell", out ModItem AureusCell))
                {
                    modPotionsShop.Add(AureusCell.Type, CheckDowned.aureus);
                }
                if (CheckDowned.calamityMod.TryFind("BoundingPotion", out ModItem BoundingPotion))
                {
                    modPotionsShop.Add(BoundingPotion.Type);
                }
                if (CheckDowned.calamityMod.TryFind("CalciumPotion", out ModItem CalciumPotion))
                {
                    modPotionsShop.Add(CalciumPotion.Type);
                }
                if (CheckDowned.calamityMod.TryFind("GravityNormalizerPotion", out ModItem GravityNormalizerPotion))
                {
                    modPotionsShop.Add(GravityNormalizerPotion.Type, CheckDowned.aureus);
                }
                if (CheckDowned.calamityMod.TryFind("PhotosynthesisPotion", out ModItem PhotosynthesisPotion))
                {
                    modPotionsShop.Add(PhotosynthesisPotion.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("PotionofOmniscience", out ModItem PotionofOmniscience))
                {
                    modPotionsShop.Add(PotionofOmniscience.Type , Condition.DownedSkeletron);
                }
                if (CheckDowned.calamityMod.TryFind("ShadowPotion", out ModItem ShadowPotion))
                {
                    modPotionsShop.Add(ShadowPotion.Type);
                }
                if (CheckDowned.calamityMod.TryFind("SoaringPotion", out ModItem SoaringPotion))
                {
                    modPotionsShop.Add(SoaringPotion.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("SulphurskinPotion", out ModItem SulphurskinPotion))
                {
                    modPotionsShop.Add(SulphurskinPotion.Type);
                }
                if (CheckDowned.calamityMod.TryFind("TeslaPotion", out ModItem TeslaPotion))
                {
                    modPotionsShop.Add(TeslaPotion.Type, CheckDowned.perforators, CheckDowned.hivemind);
                }
                if (CheckDowned.calamityMod.TryFind("ZenPotion", out ModItem ZenPotion))
                {
                    modPotionsShop.Add(ZenPotion.Type, CheckDowned.slimegod);
                }
                if (CheckDowned.calamityMod.TryFind("ZergPotion", out ModItem ZergPotion))
                {
                    modPotionsShop.Add(ZergPotion.Type, CheckDowned.slimegod);
                }
            }
            if (CheckDowned.catalystLoaded)
            {
                if (CheckDowned.catalystMod.TryFind("AstraJelly", out ModItem AstraJelly))
                {
                    modPotionsShop.Add(AstraJelly.Type, Condition.Hardmode);
                }
                if (CheckDowned.catalystMod.TryFind("Lean", out ModItem Lean))
                {
                    modPotionsShop.Add(Lean.Type, CheckDowned.aureus);
                }
            }
            //Consolaria N/A
            //Echoes N/A
            if (CheckDowned.fargosSoulsLoaded)
            {
                if (CheckDowned.fargosSoulsMod.TryFind("RabiesShot", out ModItem RabiesShot))
                {
                    modPotionsShop.Add(RabiesShot.Type, CheckDowned.abom);
                }
            }
            //Gerds N/A
            if (CheckDowned.homewardLoaded)
            {
                if (CheckDowned.homewardMod.TryFind("FlightPotion", out ModItem FlightPotion))
                {
                    modPotionsShop.Add(FlightPotion.Type, CheckDowned.materealizer);
                }
                if (CheckDowned.homewardMod.TryFind("HastePotion", out ModItem HastePotion))
                {
                    modPotionsShop.Add(HastePotion.Type, CheckDowned.materealizer);
                }
                if (CheckDowned.homewardMod.TryFind("ReanimationPotion", out ModItem ReanimationPotion))
                {
                    modPotionsShop.Add(ReanimationPotion.Type, CheckDowned.materealizer);
                }
                if (CheckDowned.homewardMod.TryFind("YangPotion", out ModItem YangPotion))
                {
                    modPotionsShop.Add(YangPotion.Type, CheckDowned.wos);
                }
                if (CheckDowned.homewardMod.TryFind("YinPotion", out ModItem YinPotion))
                {
                    modPotionsShop.Add(YinPotion.Type, CheckDowned.wos);
                }
            }
            //Infernum N/A
            if (CheckDowned.polaritiesLoaded)
            {
                if (CheckDowned.polaritiesMod.TryFind("PiercingPotion", out ModItem PiercingPotion))
                {
                    modPotionsShop.Add(PiercingPotion.Type);
                }
                if (CheckDowned.polaritiesMod.TryFind("TolerancePotion", out ModItem TolerancePotion))
                {
                    modPotionsShop.Add(TolerancePotion.Type);
                }
            }
            //Qwerty N/A
            if (CheckDowned.redemptionLoaded)
            {
                if (CheckDowned.redemptionMod.TryFind("CharismaPotion", out ModItem CharismaPotion))
                {
                    modPotionsShop.Add(CharismaPotion.Type, CheckDowned.thorn);
                }
                if (CheckDowned.redemptionMod.TryFind("VendettaPotion", out ModItem VendettaPotion))
                {
                    modPotionsShop.Add(VendettaPotion.Type, CheckDowned.thorn);
                }
                if (CheckDowned.redemptionMod.TryFind("VigourousPotion", out ModItem VigourousPotion))
                {
                    modPotionsShop.Add(VigourousPotion.Type, CheckDowned.nebby);
                }
            }
            if (CheckDowned.sotsLoaded)
            {
                if (CheckDowned.sotsMod.TryFind("AbyssalTonic", out ModItem AbyssalTonic))
                {
                    modPotionsShop.Add(AbyssalTonic.Type, CheckDowned.tidalSpirit);
                }
                if (CheckDowned.sotsMod.TryFind("AssassinationPotion", out ModItem AssassinationPotion))
                {
                    modPotionsShop.Add(AssassinationPotion.Type);
                }
                if (CheckDowned.sotsMod.TryFind("BlazingTonic", out ModItem BlazingTonic))
                {
                    modPotionsShop.Add(BlazingTonic.Type, CheckDowned.infernoSpirit);
                }
                if (CheckDowned.sotsMod.TryFind("BlightfulTonic", out ModItem BlightfulTonic))
                {
                    modPotionsShop.Add(BlightfulTonic.Type, CheckDowned.natureSpirit);
                }
                if (CheckDowned.sotsMod.TryFind("BluefirePotion", out ModItem BluefirePotion))
                {
                    modPotionsShop.Add(BluefirePotion.Type);
                }
                if (CheckDowned.sotsMod.TryFind("BrittlePotion", out ModItem BrittlePotion))
                {
                    modPotionsShop.Add(BrittlePotion.Type);
                }
                if (CheckDowned.sotsMod.TryFind("DoubleVisionPotion", out ModItem DoubleVisionPotion))
                {
                    modPotionsShop.Add(DoubleVisionPotion.Type);
                }
                if (CheckDowned.sotsMod.TryFind("EtherealTonic", out ModItem EtherealTonic))
                {
                    modPotionsShop.Add(EtherealTonic.Type, CheckDowned.lux);
                }
                if (CheckDowned.sotsMod.TryFind("GlacialTonic", out ModItem GlacialTonic))
                {
                    modPotionsShop.Add(GlacialTonic.Type, CheckDowned.permafrostSpirit);
                }
                if (CheckDowned.sotsMod.TryFind("HarmonyPotion", out ModItem HarmonyPotion))
                {
                    modPotionsShop.Add(HarmonyPotion.Type, Condition.Hardmode);
                }
                if (CheckDowned.sotsMod.TryFind("HereticTonic", out ModItem HereticTonic))
                {
                    modPotionsShop.Add(HereticTonic.Type, CheckDowned.evilSpirit);
                }
                if (CheckDowned.sotsMod.TryFind("NightmarePotion", out ModItem NightmarePotion))
                {
                    modPotionsShop.Add(NightmarePotion.Type, Condition.Hardmode);
                }
                if (CheckDowned.sotsMod.TryFind("RipplePotion", out ModItem RipplePotion))
                {
                    modPotionsShop.Add(RipplePotion.Type);
                }
                if (CheckDowned.sotsMod.TryFind("RoughskinPotion", out ModItem RoughskinPotion))
                {
                    modPotionsShop.Add(RoughskinPotion.Type, Condition.DownedEowOrBoc);
                }
                if (CheckDowned.sotsMod.TryFind("SeismicTonic", out ModItem SeismicTonic))
                {
                    modPotionsShop.Add(SeismicTonic.Type, CheckDowned.earthenSpirit);
                }
                if (CheckDowned.sotsMod.TryFind("SoulAccessPotion", out ModItem SoulAccessPotion))
                {
                    modPotionsShop.Add(SoulAccessPotion.Type, Condition.DownedEowOrBoc);
                }
                if (CheckDowned.sotsMod.TryFind("StarlightTonic", out ModItem StarlightTonic))
                {
                    modPotionsShop.Add(StarlightTonic.Type, CheckDowned.advisor);
                }
                if (CheckDowned.sotsMod.TryFind("VibePotion", out ModItem VibePotion))
                {
                    modPotionsShop.Add(VibePotion.Type);
                }
            }
            if (CheckDowned.spiritLoaded)
            {
                if (CheckDowned.spiritMod.TryFind("PinkPotion", out ModItem PinkPotion))
                {
                    modPotionsShop.Add(PinkPotion.Type);
                }
                if (CheckDowned.spiritMod.TryFind("MirrorCoat", out ModItem MirrorCoat))
                {
                    modPotionsShop.Add(MirrorCoat.Type, Condition.DownedEowOrBoc);
                }
                if (CheckDowned.spiritMod.TryFind("RunePotion", out ModItem RunePotion))
                {
                    modPotionsShop.Add(RunePotion.Type, Condition.DownedMechBossAny);
                }
                if (CheckDowned.spiritMod.TryFind("FlightPotion", out ModItem FlightPotion))
                {
                    modPotionsShop.Add(FlightPotion.Type, Condition.Hardmode);
                }
                if (CheckDowned.spiritMod.TryFind("SoulPotion", out ModItem SoulPotion))
                {
                    modPotionsShop.Add(SoulPotion.Type, Condition.DownedMechBossAny);
                }
                if (CheckDowned.spiritMod.TryFind("SpiritPotion", out ModItem SpiritPotion))
                {
                    modPotionsShop.Add(SpiritPotion.Type, Condition.DownedMechBossAny);
                }
                if (CheckDowned.spiritMod.TryFind("MushroomPotion", out ModItem MushroomPotion))
                {
                    modPotionsShop.Add(MushroomPotion.Type);
                }
                if (CheckDowned.spiritMod.TryFind("StarPotion", out ModItem StarPotion))
                {
                    modPotionsShop.Add(StarPotion.Type, Condition.DownedMechBossAny);
                }
                if (CheckDowned.spiritMod.TryFind("TurtlePotion", out ModItem TurtlePotion))
                {
                    modPotionsShop.Add(TurtlePotion.Type, Condition.DownedMechBossAny);
                }
                if (CheckDowned.spiritMod.TryFind("BismitePotion", out ModItem BismitePotion))
                {
                    modPotionsShop.Add(BismitePotion.Type);
                }
                if (CheckDowned.spiritMod.TryFind("DoubleJumpPotion", out ModItem DoubleJumpPotion))
                {
                    modPotionsShop.Add(DoubleJumpPotion.Type);
                }
            }
            //Spooky N/A
            if (CheckDowned.stormLoaded)
            {
                if (CheckDowned.stormMod.TryFind("BeetlePotion", out ModItem BeetlePotion))
                {
                    modPotionsShop.Add(BeetlePotion.Type, Condition.DownedGolem);
                }
                if (CheckDowned.stormMod.TryFind("FruitHeartPotion", out ModItem FruitHeartPotion))
                {
                    modPotionsShop.Add(FruitHeartPotion.Type, Condition.DownedMechBossAny);
                }
                if (CheckDowned.stormMod.TryFind("GunPotion", out ModItem GunPotion))
                {
                    modPotionsShop.Add(GunPotion.Type);
                }
                if (CheckDowned.stormMod.TryFind("HeartPotion", out ModItem HeartPotion))
                {
                    modPotionsShop.Add(HeartPotion.Type);
                }
                if (CheckDowned.stormMod.TryFind("ShroomitePotion", out ModItem ShroomitePotion))
                {
                    modPotionsShop.Add(ShroomitePotion.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.stormMod.TryFind("SpectrePotion", out ModItem SpectrePotion))
                {
                    modPotionsShop.Add(SpectrePotion.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.stormMod.TryFind("SpookyPotion", out ModItem SpookyPotion))
                {
                    modPotionsShop.Add(SpookyPotion.Type, Condition.DownedPlantera);
                }
            }
            if (CheckDowned.terrorbornLoaded)
            {
                if (CheckDowned.terrorbornMod.TryFind("AdrenalinePotion", out ModItem AdrenalinePotion))
                {
                    modPotionsShop.Add(AdrenalinePotion.Type);
                }
                if (CheckDowned.terrorbornMod.TryFind("AerodynamicPotion", out ModItem AerodynamicPotion))
                {
                    modPotionsShop.Add(AerodynamicPotion.Type);
                }
                if (CheckDowned.terrorbornMod.TryFind("BloodFlowPotion", out ModItem BloodFlowPotion))
                {
                    modPotionsShop.Add(BloodFlowPotion.Type);
                }
                if (CheckDowned.terrorbornMod.TryFind("SinducementPotion", out ModItem SinducementPotion))
                {
                    modPotionsShop.Add(SinducementPotion.Type, Condition.Hardmode);
                }
                if (CheckDowned.terrorbornMod.TryFind("StarpowerPotion", out ModItem StarpowerPotion))
                {
                    modPotionsShop.Add(StarpowerPotion.Type);
                }
                if (CheckDowned.terrorbornMod.TryFind("VampirismPotion", out ModItem VampirismPotion))
                {
                    modPotionsShop.Add(VampirismPotion.Type);
                }
            }
            if (CheckDowned.thoriumLoaded)
            {
                if (CheckDowned.thoriumMod.TryFind("AquaPotion", out ModItem AquaPotion))
                {
                    modPotionsShop.Add(AquaPotion.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("ArcanePotion", out ModItem ArcanePotion))
                {
                    modPotionsShop.Add(ArcanePotion.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("ArtilleryPotion", out ModItem ArtilleryPotion))
                {
                    modPotionsShop.Add(ArtilleryPotion.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("AssassinPotion", out ModItem AssassinPotion))
                {
                    modPotionsShop.Add(AssassinPotion.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("BatRepellent", out ModItem BatRepellent))
                {
                    modPotionsShop.Add(BatRepellent.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("BloodPotion", out ModItem BloodPotion))
                {
                    modPotionsShop.Add(BloodPotion.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("BouncingFlamePotion", out ModItem BouncingFlamePotion))
                {
                    modPotionsShop.Add(BouncingFlamePotion.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("CactusFruit", out ModItem CactusFruit))
                {
                    modPotionsShop.Add(CactusFruit.Type, CheckDowned.grandbird);
                }
                if (CheckDowned.thoriumMod.TryFind("ConflagrationPotion", out ModItem ConflagrationPotion))
                {
                    modPotionsShop.Add(ConflagrationPotion.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("CreativityPotion", out ModItem CreativityPotion))
                {
                    modPotionsShop.Add(CreativityPotion.Type, CheckDowned.grandbird);
                }
                if (CheckDowned.thoriumMod.TryFind("EarwormPotion", out ModItem EarwormPotion))
                {
                    modPotionsShop.Add(EarwormPotion.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("FishRepellent", out ModItem FishRepellent))
                {
                    modPotionsShop.Add(FishRepellent.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("FrenzyPotion", out ModItem FrenzyPotion))
                {
                    modPotionsShop.Add(FrenzyPotion.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("GlowingPotion", out ModItem GlowingPotion))
                {
                    modPotionsShop.Add(GlowingPotion.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("HolyPotion", out ModItem HolyPotion))
                {
                    modPotionsShop.Add(HolyPotion.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("HydrationPotion", out ModItem HydrationPotion))
                {
                    modPotionsShop.Add(HydrationPotion.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("InsectRepellent", out ModItem InsectRepellent))
                {
                    modPotionsShop.Add(InsectRepellent.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("InspirationReachPotion", out ModItem InspirationReachPotion))
                {
                    modPotionsShop.Add(InspirationReachPotion.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("KineticPotion", out ModItem KineticPotion))
                {
                    modPotionsShop.Add(KineticPotion.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("SkeletonRepellent", out ModItem SkeletonRepellent))
                {
                    modPotionsShop.Add(SkeletonRepellent.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("WarmongerPotion", out ModItem WarmongerPotion))
                {
                    modPotionsShop.Add(WarmongerPotion.Type, Condition.DownedEowOrBoc);
                }
                if (CheckDowned.thoriumMod.TryFind("ZombieRepellent", out ModItem ZombieRepellent))
                {
                    modPotionsShop.Add(ZombieRepellent.Type);
                }
            }
            if (CheckDowned.vitalityLoaded)
            {
                if (CheckDowned.vitalityMod.TryFind("ArmorPiercingPotion", out ModItem ArmorPiercingPotion))
                {
                    modPotionsShop.Add(ArmorPiercingPotion.Type);
                }
                if (CheckDowned.vitalityMod.TryFind("LeapingPotion", out ModItem LeapingPotion))
                {
                    modPotionsShop.Add(LeapingPotion.Type);
                }
                if (CheckDowned.vitalityMod.TryFind("TranquillityPotion", out ModItem TranquillityPotion))
                {
                    modPotionsShop.Add(TranquillityPotion.Type);
                }
                if (CheckDowned.vitalityMod.TryFind("TravelsensePotion", out ModItem TravelsensePotion))
                {
                    modPotionsShop.Add(TravelsensePotion.Type, Condition.Hardmode);
                }
                if (CheckDowned.vitalityMod.TryFind("WarriorPotion", out ModItem WarriorPotion))
                {
                    modPotionsShop.Add(WarriorPotion.Type, Condition.DownedEowOrBoc);
                }
            }
            modPotionsShop.Register();

            var modFlasksShop = new NPCShop(Type, "Modded Flasks, Stations & Foods");
            //Aequus N/A
            if (CheckDowned.calamityLoaded)
            {
                if (CheckDowned.calamityMod.TryFind("Baguette", out ModItem Baguette))
                {
                    modFlasksShop.Add(Baguette.Type);
                }
                if (CheckDowned.calamityMod.TryFind("HadalStew", out ModItem HadalStew))
                {
                    modFlasksShop.Add(HadalStew.Type);
                }
                if (CheckDowned.calamityMod.TryFind("FlaskOfBrimstone", out ModItem FlaskOfBrimstone))
                {
                    modFlasksShop.Add(FlaskOfBrimstone.Type, CheckDowned.calamitas);
                }
                if (CheckDowned.calamityMod.TryFind("FlaskOfCrumbling", out ModItem FlaskOfCrumbling))
                {
                    modFlasksShop.Add(FlaskOfCrumbling.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("FlaskOfHolyFlames", out ModItem FlaskOfHolyFlames))
                {
                    modFlasksShop.Add(FlaskOfHolyFlames.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.calamityMod.TryFind("CorruptionEffigy", out ModItem CorruptionEffigy))
                {
                    modFlasksShop.Add(CorruptionEffigy.Type);
                }
                if (CheckDowned.calamityMod.TryFind("CrimsonEffigy", out ModItem CrimsonEffigy))
                {
                    modFlasksShop.Add(CrimsonEffigy.Type);
                }
                if (CheckDowned.calamityMod.TryFind("EffigyOfDecay", out ModItem EffigyOfDecay))
                {
                    modFlasksShop.Add(EffigyOfDecay.Type);
                }
                if (CheckDowned.calamityMod.TryFind("TranquilityCandle", out ModItem TranquilityCandle))
                {
                    modFlasksShop.Add(TranquilityCandle.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.calamityMod.TryFind("ChaosCandle", out ModItem ChaosCandle))
                {
                    modFlasksShop.Add(ChaosCandle.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.calamityMod.TryFind("ResilientCandle", out ModItem ResilientCandle))
                {
                    modFlasksShop.Add(ResilientCandle.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("SpitefulCandle", out ModItem SpitefulCandle))
                {
                    modFlasksShop.Add(SpitefulCandle.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("WeightlessCandle", out ModItem WeightlessCandle))
                {
                    modFlasksShop.Add(WeightlessCandle.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("VigorousCandle", out ModItem VigorousCandle))
                {
                    modFlasksShop.Add(VigorousCandle.Type, Condition.Hardmode);
                }
                
            }
            //Catalyst N/A
            //Consolaria N/A
            //Echoes N/A
            if (CheckDowned.fargosSoulsLoaded)
            {
                if (CheckDowned.fargosSoulsMod.TryFind("Omnistation", out ModItem Omnistation))
                {
                    modFlasksShop.Add(Omnistation.Type, Condition.Hardmode);
                }
                if (CheckDowned.fargosSoulsMod.TryFind("Omnistation2", out ModItem Omnistation2))
                {
                    modFlasksShop.Add(Omnistation2.Type, Condition.Hardmode);
                }
                if (CheckDowned.fargosSoulsMod.TryFind("Semistation", out ModItem Semistation))
                {
                    modFlasksShop.Add(Semistation.Type);
                }
            }
            //Gerds N/A
            //Homeward N/A
            //Infernum N/A
            //Polarities N/A
            if (CheckDowned.qwertyLoaded)
            {
                if (CheckDowned.qwertyMod.TryFind("CaeliteFlask", out ModItem CaeliteFlask))
                {
                    modFlasksShop.Add(CaeliteFlask.Type, CheckDowned.divineLight);
                }
            }
            if (CheckDowned.redemptionLoaded)
            {
                if (CheckDowned.redemptionMod.TryFind("EvilJelly", out ModItem EvilJelly))
                {
                    modFlasksShop.Add(EvilJelly.Type);
                }
                if (CheckDowned.redemptionMod.TryFind("BileFlask", out ModItem BileFlask))
                {
                    modFlasksShop.Add(BileFlask.Type, Condition.Hardmode);
                }
                if (CheckDowned.redemptionMod.TryFind("NitroglycerineFlask", out ModItem NitroglycerineFlask))
                {
                    modFlasksShop.Add(NitroglycerineFlask.Type, Condition.Hardmode);
                }
                if (CheckDowned.redemptionMod.TryFind("EnergyStation", out ModItem EnergyStation))
                {
                    modFlasksShop.Add(EnergyStation.Type);
                }
            }
            if (CheckDowned.sotsLoaded)
            {
                if (CheckDowned.sotsMod.TryFind("AlmondMilk", out ModItem AlmondMilk))
                {
                    modFlasksShop.Add(AlmondMilk.Type);
                }
                if (CheckDowned.sotsMod.TryFind("AvocadoSoup", out ModItem AvocadoSoup))
                {
                    modFlasksShop.Add(AvocadoSoup.Type);
                }
                if (CheckDowned.sotsMod.TryFind("Chocolate", out ModItem Chocolate))
                {
                    modFlasksShop.Add(Chocolate.Type, Condition.Hardmode);
                }
                if (CheckDowned.sotsMod.TryFind("CoconutMilk", out ModItem CoconutMilk))
                {
                    modFlasksShop.Add(CoconutMilk.Type);
                }
                if (CheckDowned.sotsMod.TryFind("CookedMushroom", out ModItem CookedMushroom))
                {
                    modFlasksShop.Add(CookedMushroom.Type);
                }
                if (CheckDowned.sotsMod.TryFind("CursedCaviar", out ModItem CursedCaviar))
                {
                    modFlasksShop.Add(CursedCaviar.Type, Condition.DownedEowOrBoc);
                }
                if (CheckDowned.sotsMod.TryFind("DigitalCornSyrup", out ModItem DigitalCornSyrup))
                {
                    modFlasksShop.Add(DigitalCornSyrup.Type);
                }
                if (CheckDowned.sotsMod.TryFind("FoulConcoction", out ModItem FoulConcoction))
                {
                    modFlasksShop.Add(FoulConcoction.Type);
                }
                if (CheckDowned.sotsMod.TryFind("StrawberryIcecream", out ModItem StrawberryIcecream))
                {
                    modFlasksShop.Add(StrawberryIcecream.Type);
                }
                if (CheckDowned.sotsMod.TryFind("DigitalDisplay", out ModItem DigitalDisplay))
                {
                    modFlasksShop.Add(DigitalDisplay.Type);
                }
            }
            if (CheckDowned.spiritLoaded)
            {
                if (CheckDowned.spiritMod.TryFind("Candy", out ModItem Candy))
                {
                    modFlasksShop.Add(Candy.Type);
                }
                if (CheckDowned.spiritMod.TryFind("ChocolateBar", out ModItem ChocolateBar))
                {
                    modFlasksShop.Add(ChocolateBar.Type);
                }
                if (CheckDowned.spiritMod.TryFind("HealthCandy", out ModItem HealthCandy))
                {
                    modFlasksShop.Add(HealthCandy.Type);
                }
                if (CheckDowned.spiritMod.TryFind("Lollipop", out ModItem Lollipop))
                {
                    modFlasksShop.Add(Lollipop.Type);
                }
                if (CheckDowned.spiritMod.TryFind("ManaCandy", out ModItem ManaCandy))
                {
                    modFlasksShop.Add(ManaCandy.Type);
                }
                if (CheckDowned.spiritMod.TryFind("MysteryCandy", out ModItem MysteryCandy))
                {
                    modFlasksShop.Add(MysteryCandy.Type);
                }
                if (CheckDowned.spiritMod.TryFind("Taffy", out ModItem Taffy))
                {
                    modFlasksShop.Add(Taffy.Type);
                }
                if (CheckDowned.spiritMod.TryFind("CoilEnergizerItem", out ModItem CoilEnergizerItem))
                {
                    modFlasksShop.Add(CoilEnergizerItem.Type, Condition.DownedGoblinArmy);
                }
                if (CheckDowned.spiritMod.TryFind("SunPot", out ModItem SunPot))
                {
                    modFlasksShop.Add(SunPot.Type);
                }
                if (CheckDowned.spiritMod.TryFind("TheCouch", out ModItem TheCouch))
                {
                    modFlasksShop.Add(TheCouch.Type, Condition.DownedSkeletron);
                }
            }
            //Spooky N/A
            //Storms N/A
            //Terrorborn N/A
            if (CheckDowned.thoriumLoaded)
            {
                if (CheckDowned.thoriumMod.TryFind("DeepFreezeCoatingItem", out ModItem DeepFreezeCoatingItem))
                {
                    modFlasksShop.Add(DeepFreezeCoatingItem.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("ExplosiveCoatingItem", out ModItem ExplosiveCoatingItem))
                {
                    modFlasksShop.Add(ExplosiveCoatingItem.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("GorgonCoatingItem", out ModItem GorgonCoatingItem))
                {
                    modFlasksShop.Add(GorgonCoatingItem.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("SporeCoatingItem", out ModItem SporeCoatingItem))
                {
                    modFlasksShop.Add(SporeCoatingItem.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("ToxicCoatingItem", out ModItem ToxicCoatingItem))
                {
                    modFlasksShop.Add(ToxicCoatingItem.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("Altar", out ModItem Altar))
                {
                    modFlasksShop.Add(Altar.Type, CheckDowned.buriedchampion);
                }
                if (CheckDowned.thoriumMod.TryFind("ConductorsStand", out ModItem ConductorsStand))
                {
                    modFlasksShop.Add(ConductorsStand.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("NinjaRack", out ModItem NinjaRack))
                {
                    modFlasksShop.Add(NinjaRack.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("ArenaMastersBrazier", out ModItem ArenaMastersBrazier))
                {
                    modFlasksShop.Add(ArenaMastersBrazier.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("TrueArenaMastersBrazier", out ModItem TrueArenaMastersBrazier))
                {
                    modFlasksShop.Add(TrueArenaMastersBrazier.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("Mistletoe", out ModItem Mistletoe))
                {
                    modFlasksShop.Add(Mistletoe.Type);
                }
            }
            //Vitality N/A
            modFlasksShop.Register();

            var modMaterialsShop = new NPCShop(Type, "Modded Materials");
            if (CheckDowned.aqLoaded)
            {
                if (CheckDowned.aqMod.TryFind("AtmosphericEnergy", out ModItem AtmosphericEnergy))
                {
                    modMaterialsShop.Add(AtmosphericEnergy.Type, CheckDowned.sprite, CheckDowned.spacesquid, CheckDowned.devil);
                }
                if (CheckDowned.aqMod.TryFind("AquaticEnergy", out ModItem AquaticEnergy))
                {
                    modMaterialsShop.Add(AquaticEnergy.Type);
                }
                if (CheckDowned.aqMod.TryFind("BloodyTearstone", out ModItem BloodyTearstone))
                {
                    modMaterialsShop.Add(BloodyTearstone.Type, CheckDowned.bloodMoon);
                }
                if (CheckDowned.aqMod.TryFind("CosmicEnergy", out ModItem CosmicEnergy))
                {
                    modMaterialsShop.Add(CosmicEnergy.Type, CheckDowned.omegastarite);
                }
                if (CheckDowned.aqMod.TryFind("DemonicEnergy", out ModItem DemonicEnergy))
                {
                    modMaterialsShop.Add(DemonicEnergy.Type);
                }
                if (CheckDowned.aqMod.TryFind("Fluorescence", out ModItem Fluorescence))
                {
                    modMaterialsShop.Add(Fluorescence.Type, CheckDowned.sprite);
                }
                if (CheckDowned.aqMod.TryFind("FrozenTear", out ModItem FrozenTear))
                {
                    modMaterialsShop.Add(FrozenTear.Type, CheckDowned.spacesquid);
                }
                if (CheckDowned.aqMod.TryFind("Hexoplasm", out ModItem Hexoplasm))
                {
                    modMaterialsShop.Add(Hexoplasm.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.aqMod.TryFind("OrganicEnergy", out ModItem OrganicEnergy))
                {
                    modMaterialsShop.Add(OrganicEnergy.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.aqMod.TryFind("UltimateEnergy", out ModItem UltimateEnergy))
                {
                    modMaterialsShop.Add(UltimateEnergy.Type, Condition.DownedPlantera);
                }
            }
            if (CheckDowned.calamityLoaded)
            {
                if (CheckDowned.calamityMod.TryFind("AncientBoneDust", out ModItem AncientBoneDust))
                {
                    modMaterialsShop.Add(AncientBoneDust.Type);
                }
                if (CheckDowned.calamityMod.TryFind("ArmoredShell", out ModItem ArmoredShell))
                {
                    modMaterialsShop.Add(ArmoredShell.Type, CheckDowned.stormweaver);
                }
                if (CheckDowned.calamityMod.TryFind("AshesofAnnihilation", out ModItem AshesofAnnihilation))
                {
                    modMaterialsShop.Add(AshesofAnnihilation.Type, CheckDowned.scalamitas);
                }
                if (CheckDowned.calamityMod.TryFind("AshesofCalamity", out ModItem AshesofCalamity))
                {
                    modMaterialsShop.Add(AshesofCalamity.Type, CheckDowned.calamitas);
                }
                if (CheckDowned.calamityMod.TryFind("BeetleJuice", out ModItem BeetleJuice))
                {
                    modMaterialsShop.Add(BeetleJuice.Type);
                }
                if (CheckDowned.calamityMod.TryFind("BlightedGel", out ModItem BlightedGel))
                {
                    modMaterialsShop.Add(BlightedGel.Type);
                }
                if (CheckDowned.calamityMod.TryFind("BloodOrb", out ModItem BloodOrb))
                {
                    modMaterialsShop.Add(BloodOrb.Type, CheckDowned.bloodMoon);
                }
                if (CheckDowned.calamityMod.TryFind("BloodSample", out ModItem BloodSample))
                {
                    modMaterialsShop.Add(BloodSample.Type, CheckDowned.perforators);
                }
                if (CheckDowned.calamityMod.TryFind("Bloodstone", out ModItem Bloodstone))
                {
                    modMaterialsShop.Add(Bloodstone.Type, CheckDowned.providence);
                }
                if (CheckDowned.calamityMod.TryFind("CorrodedFossil", out ModItem CorrodedFossil))
                {
                    modMaterialsShop.Add(CorrodedFossil.Type, CheckDowned.acidRain2);
                }
                if (CheckDowned.calamityMod.TryFind("DarkPlasma", out ModItem DarkPlasma))
                {
                    modMaterialsShop.Add(DarkPlasma.Type, CheckDowned.ceaselessvoid);
                }
                if (CheckDowned.calamityMod.TryFind("DarksunFragment", out ModItem DarksunFragment))
                {
                    modMaterialsShop.Add(DarksunFragment.Type, CheckDowned.dog);
                }
                if (CheckDowned.calamityMod.TryFind("DepthCells", out ModItem DepthCells))
                {
                    modMaterialsShop.Add(DepthCells.Type, CheckDowned.calamitas);
                }
                if (CheckDowned.calamityMod.TryFind("DemonicBoneAsh", out ModItem DemonicBoneAsh))
                {
                    modMaterialsShop.Add(DemonicBoneAsh.Type);
                }
                if (CheckDowned.calamityMod.TryFind("DivineGeode", out ModItem DivineGeode))
                {
                    modMaterialsShop.Add(DivineGeode.Type, CheckDowned.providence);
                }
                if (CheckDowned.calamityMod.TryFind("DubiousPlating", out ModItem DubiousPlating))
                {
                    modMaterialsShop.Add(DubiousPlating.Type);
                }
                if (CheckDowned.calamityMod.TryFind("EffulgentFeather", out ModItem EffulgentFeather))
                {
                    modMaterialsShop.Add(EffulgentFeather.Type, CheckDowned.dragonfolly);
                }
                if (CheckDowned.calamityMod.TryFind("EndothermicEnergy", out ModItem EndothermicEnergy))
                {
                    modMaterialsShop.Add(EndothermicEnergy.Type, CheckDowned.dog);
                }
                if (CheckDowned.calamityMod.TryFind("EnergyCore", out ModItem EnergyCore))
                {
                    modMaterialsShop.Add(EnergyCore.Type);
                }
                if (CheckDowned.calamityMod.TryFind("EssenceofChaos", out ModItem EssenceofChaos))
                {
                    modMaterialsShop.Add(EssenceofChaos.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("EssenceofEleum", out ModItem EssenceofEleum))
                {
                    modMaterialsShop.Add(EssenceofEleum.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("EssenceofSunlight", out ModItem EssenceofSunlight))
                {
                    modMaterialsShop.Add(EssenceofSunlight.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("ExoPrism", out ModItem ExoPrism))
                {
                    modMaterialsShop.Add(ExoPrism.Type, CheckDowned.exomechs);
                }
                if (CheckDowned.calamityMod.TryFind("GrandScale", out ModItem GrandScale))
                {
                    modMaterialsShop.Add(GrandScale.Type, CheckDowned.sandshark);
                }
                if (CheckDowned.calamityMod.TryFind("InfectedArmorPlating", out ModItem InfectedArmorPlating))
                {
                    modMaterialsShop.Add(InfectedArmorPlating.Type, CheckDowned.plaguebringer);
                }
                if (CheckDowned.calamityMod.TryFind("LivingShard", out ModItem LivingShard))
                {
                    modMaterialsShop.Add(LivingShard.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.calamityMod.TryFind("Lumenyl", out ModItem Lumenyl))
                {
                    modMaterialsShop.Add(Lumenyl.Type, CheckDowned.calamitas);
                }
                if (CheckDowned.calamityMod.TryFind("MeldBlob", out ModItem MeldBlob))
                {
                    modMaterialsShop.Add(MeldBlob.Type, Condition.DownedCultist);
                }
                if (CheckDowned.calamityMod.TryFind("MolluskHusk", out ModItem MolluskHusk))
                {
                    modMaterialsShop.Add(MolluskHusk.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("MurkyPaste", out ModItem MurkyPaste))
                {
                    modMaterialsShop.Add(MurkyPaste.Type);
                }
                if (CheckDowned.calamityMod.TryFind("MysteriousCircuitry", out ModItem MysteriousCircuitry))
                {
                    modMaterialsShop.Add(MysteriousCircuitry.Type);
                }
                if (CheckDowned.calamityMod.TryFind("NightmareFuel", out ModItem NightmareFuel))
                {
                    modMaterialsShop.Add(NightmareFuel.Type, CheckDowned.dog);
                }
                if (CheckDowned.calamityMod.TryFind("PearlShard", out ModItem PearlShard))
                {
                    modMaterialsShop.Add(PearlShard.Type, CheckDowned.desertscourge);
                }
                if (CheckDowned.calamityMod.TryFind("Polterplasm", out ModItem Polterplasm))
                {
                    modMaterialsShop.Add(Polterplasm.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.calamityMod.TryFind("PlagueCellCanister", out ModItem PlagueCellCanister))
                {
                    modMaterialsShop.Add(PlagueCellCanister.Type, Condition.DownedGolem);
                }
                if (CheckDowned.calamityMod.TryFind("PurifiedGel", out ModItem PurifiedGel))
                {
                    modMaterialsShop.Add(PurifiedGel.Type, CheckDowned.slimegod);
                }
                if (CheckDowned.calamityMod.TryFind("ReaperTooth", out ModItem ReaperTooth))
                {
                    modMaterialsShop.Add(ReaperTooth.Type, CheckDowned.polterghast);
                }
                if (CheckDowned.calamityMod.TryFind("RottenMatter", out ModItem RottenMatter))
                {
                    modMaterialsShop.Add(RottenMatter.Type, CheckDowned.hivemind);
                }
                if (CheckDowned.calamityMod.TryFind("RuinousSoul", out ModItem RuinousSoul))
                {
                    modMaterialsShop.Add(RuinousSoul.Type, CheckDowned.polterghast);
                }
                if (CheckDowned.calamityMod.TryFind("SolarVeil", out ModItem SolarVeil))
                {
                    modMaterialsShop.Add(SolarVeil.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.calamityMod.TryFind("StormlionMandible", out ModItem StormlionMandible))
                {
                    modMaterialsShop.Add(StormlionMandible.Type);
                }
                if (CheckDowned.calamityMod.TryFind("Stardust", out ModItem Stardust))
                {
                    modMaterialsShop.Add(Stardust.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("SulphuricScale", out ModItem SulphuricScale))
                {
                    modMaterialsShop.Add(SulphuricScale.Type, CheckDowned.acidRain1);
                }
                if (CheckDowned.calamityMod.TryFind("TrapperBulb", out ModItem TrapperBulb))
                {
                    modMaterialsShop.Add(TrapperBulb.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("TwistingNether", out ModItem TwistingNether))
                {
                    modMaterialsShop.Add(TwistingNether.Type, CheckDowned.signus);
                }
                if (CheckDowned.calamityMod.TryFind("UnholyEssence", out ModItem UnholyEssence))
                {
                    modMaterialsShop.Add(UnholyEssence.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.calamityMod.TryFind("WulfrumMetalScrap", out ModItem WulfrumMetalScrap))
                {
                    modMaterialsShop.Add(WulfrumMetalScrap.Type);
                }
                if (CheckDowned.calamityMod.TryFind("YharonSoulFragment", out ModItem YharonSoulFragment))
                {
                    modMaterialsShop.Add(YharonSoulFragment.Type, CheckDowned.yharon);
                }
            }
            //Catalyst N/A
            if (CheckDowned.consolariaLoaded)
            {
                if (CheckDowned.consolariaMod.TryFind("RainbowPiece", out ModItem RainbowPiece))
                {
                    modMaterialsShop.Add(RainbowPiece.Type);
                }
                if (CheckDowned.consolariaMod.TryFind("SoulofBlight", out ModItem SoulofBlight))
                {
                    modMaterialsShop.Add(SoulofBlight.Type, CheckDowned.ocram);
                }
                if (CheckDowned.consolariaMod.TryFind("WhiteThread", out ModItem WhiteThread))
                {
                    modMaterialsShop.Add(WhiteThread.Type);
                }
            }
            if (CheckDowned.echoesLoaded)
            {
                if (CheckDowned.echoesMod.TryFind("BetsyScale", out ModItem BetsyScale))
                {
                    modMaterialsShop.Add(BetsyScale.Type, Condition.DownedOldOnesArmyT3);
                }
                if (CheckDowned.echoesMod.TryFind("Broken_Hero_GunParts", out ModItem Broken_Hero_GunParts))
                {
                    modMaterialsShop.Add(Broken_Hero_GunParts.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.echoesMod.TryFind("CorruptShard", out ModItem CorruptShard))
                {
                    modMaterialsShop.Add(CorruptShard.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.echoesMod.TryFind("Cosmic_Essence", out ModItem Cosmic_Essence))
                {
                    modMaterialsShop.Add(Cosmic_Essence.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.echoesMod.TryFind("Crimson_Stone", out ModItem Crimson_Stone))
                {
                    modMaterialsShop.Add(Crimson_Stone.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.echoesMod.TryFind("Divine_Fragment", out ModItem Divine_Fragment))
                {
                    modMaterialsShop.Add(Divine_Fragment.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.echoesMod.TryFind("Duskbulb", out ModItem Duskbulb))
                {
                    modMaterialsShop.Add(Duskbulb.Type, CheckDowned.destruction);
                }
                if (CheckDowned.echoesMod.TryFind("Enkin", out ModItem Enkin))
                {
                    modMaterialsShop.Add(Enkin.Type, CheckDowned.destruction);
                }
                if (CheckDowned.echoesMod.TryFind("CosmicFabric", out ModItem CosmicFabric))
                {
                    //Fabric of Reality
                    modMaterialsShop.Add(CosmicFabric.Type, CheckDowned.destruction);
                }
                if (CheckDowned.echoesMod.TryFind("GenocideCore", out ModItem GenocideCore))
                {
                    modMaterialsShop.Add(GenocideCore.Type, Condition.Hardmode);
                }
                if (CheckDowned.echoesMod.TryFind("Hallow_Stone", out ModItem Hallow_Stone))
                {
                    modMaterialsShop.Add(Hallow_Stone.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.echoesMod.TryFind("Hell_Stone", out ModItem Hell_Stone))
                {
                    modMaterialsShop.Add(Hell_Stone.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.echoesMod.TryFind("Ice_Stone", out ModItem Ice_Stone))
                {
                    modMaterialsShop.Add(Ice_Stone.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.echoesMod.TryFind("InfinityCrystal", out ModItem InfinityCrystal))
                {
                    modMaterialsShop.Add(InfinityCrystal.Type, CheckDowned.destruction, CheckDowned.creation);
                }
                if (CheckDowned.echoesMod.TryFind("InfinityGeode", out ModItem InfinityGeode))
                {
                    modMaterialsShop.Add(InfinityGeode.Type, CheckDowned.creation);
                }
                if (CheckDowned.echoesMod.TryFind("Jungle_Stone", out ModItem Jungle_Stone))
                {
                    modMaterialsShop.Add(Jungle_Stone.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.echoesMod.TryFind("LunarSilk", out ModItem LunarSilk))
                {
                    modMaterialsShop.Add(LunarSilk.Type, Condition.DownedCultist);
                }
                if (CheckDowned.echoesMod.TryFind("Purity_Stone", out ModItem Purity_Stone))
                {
                    modMaterialsShop.Add(Purity_Stone.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.echoesMod.TryFind("Relic_Fragment", out ModItem Relic_Fragment))
                {
                    modMaterialsShop.Add(Relic_Fragment.Type, Condition.Hardmode);
                }
                if (CheckDowned.echoesMod.TryFind("Sand_Stone", out ModItem Sand_Stone))
                {
                    modMaterialsShop.Add(Sand_Stone.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.echoesMod.TryFind("SingularityCatalyst", out ModItem SingularityCatalyst))
                {
                    modMaterialsShop.Add(SingularityCatalyst.Type, CheckDowned.creation);
                }
                if (CheckDowned.echoesMod.TryFind("Stardust", out ModItem Stardust))
                {
                    modMaterialsShop.Add(Stardust.Type, CheckDowned.destruction);
                }
                if (CheckDowned.echoesMod.TryFind("SunstruckEssence", out ModItem SunstruckEssence))
                {
                    modMaterialsShop.Add(SunstruckEssence.Type, CheckDowned.galahis);
                }
                if (CheckDowned.echoesMod.TryFind("Tungqua", out ModItem Tungqua))
                {
                    modMaterialsShop.Add(Tungqua.Type, CheckDowned.creation);
                }
                if (CheckDowned.echoesMod.TryFind("Underground_Stone", out ModItem Underground_Stone))
                {
                    modMaterialsShop.Add(Underground_Stone.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.echoesMod.TryFind("Water_Stone", out ModItem Water_Stone))
                {
                    modMaterialsShop.Add(Water_Stone.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.echoesMod.TryFind("Wyvernscale", out ModItem Wyvernscale))
                {
                    modMaterialsShop.Add(Wyvernscale.Type, Condition.Hardmode);
                }
            }
            if (CheckDowned.fargosSoulsLoaded)
            {
                if (CheckDowned.fargosSoulsMod.TryFind("AbomEnergy", out ModItem AbomEnergy))
                {
                    modMaterialsShop.Add(AbomEnergy.Type, CheckDowned.abom);
                }
                if (CheckDowned.fargosSoulsMod.TryFind("DeviatingEnergy", out ModItem DeviatingEnergy))
                {
                    modMaterialsShop.Add(DeviatingEnergy.Type, CheckDowned.devi);
                }
                if (CheckDowned.fargosSoulsMod.TryFind("Eridanium", out ModItem Eridanium))
                {
                    modMaterialsShop.Add(Eridanium.Type, CheckDowned.cosmoschamp);
                }
                if (CheckDowned.fargosSoulsMod.TryFind("EternalEnergy", out ModItem EternalEnergy))
                {
                    modMaterialsShop.Add(EternalEnergy.Type, CheckDowned.mutant);
                }
            }
            if (CheckDowned.gmrLoaded)
            {
                if (CheckDowned.gmrMod.TryFind("UpgradeCrystal", out ModItem UpgradeCrystal))
                {
                    modMaterialsShop.Add(UpgradeCrystal.Type);
                }
                if (CheckDowned.gmrMod.TryFind("AlloyBox", out ModItem AlloyBox))
                {
                    modMaterialsShop.Add(AlloyBox.Type);
                }
                if (CheckDowned.gmrMod.TryFind("BossUpgradeCrystal", out ModItem BossUpgradeCrystal))
                {
                    modMaterialsShop.Add(BossUpgradeCrystal.Type, Condition.DownedEyeOfCthulhu);
                }
                if (CheckDowned.gmrMod.TryFind("ScrapFragment", out ModItem ScrapFragment))
                {
                    modMaterialsShop.Add(ScrapFragment.Type, CheckDowned.acheron);
                }
                if (CheckDowned.gmrMod.TryFind("HardmodeUpgradeCrystal", out ModItem HardmodeUpgradeCrystal))
                {
                    modMaterialsShop.Add(HardmodeUpgradeCrystal.Type, Condition.DownedMechBossAny);
                }
                if (CheckDowned.gmrMod.TryFind("SpecialUpgradeCrystal", out ModItem SpecialUpgradeCrystal))
                {
                    modMaterialsShop.Add(SpecialUpgradeCrystal.Type, Condition.DownedMechBossAny);
                }
            }
            if (CheckDowned.homewardLoaded)
            {
                if (CheckDowned.homewardMod.TryFind("AbyssFragment", out ModItem AbyssFragment))
                {
                    modMaterialsShop.Add(AbyssFragment.Type, CheckDowned.diver);
                }
                if (CheckDowned.homewardMod.TryFind("AnglerCoin", out ModItem AnglerCoin))
                {
                    modMaterialsShop.Add(AnglerCoin.Type);
                }
                if (CheckDowned.homewardMod.TryFind("AnglerGoldCoin", out ModItem AnglerGoldCoin))
                {
                    modMaterialsShop.Add(AnglerGoldCoin.Type, Condition.Hardmode);
                }
                if (CheckDowned.homewardMod.TryFind("Blood", out ModItem Blood))
                {
                    modMaterialsShop.Add(Blood.Type, CheckDowned.bloodMoon);
                }
                if (CheckDowned.homewardMod.TryFind("DenseIcicle", out ModItem DenseIcicle))
                {
                    modMaterialsShop.Add(DenseIcicle.Type, CheckDowned.wos);
                }
                if (CheckDowned.homewardMod.TryFind("DivineShard", out ModItem DivineShard))
                {
                    modMaterialsShop.Add(DivineShard.Type, CheckDowned.wos);
                }
                if (CheckDowned.homewardMod.TryFind("EssenceofBright", out ModItem EssenceofBright))
                {
                    modMaterialsShop.Add(EssenceofBright.Type, CheckDowned.son);
                }
                if (CheckDowned.homewardMod.TryFind("EssenceofLife", out ModItem EssenceofLife))
                {
                    modMaterialsShop.Add(EssenceofLife.Type, CheckDowned.lifebringer);
                }
                if (CheckDowned.homewardMod.TryFind("EssenceofMatter", out ModItem EssenceofMatter))
                {
                    modMaterialsShop.Add(EssenceofMatter.Type, CheckDowned.materealizer);
                }
                if (CheckDowned.homewardMod.TryFind("EssenceofNothingness", out ModItem EssenceofNothingness))
                {
                    modMaterialsShop.Add(EssenceofNothingness.Type, CheckDowned.scarab);
                }
                if (CheckDowned.homewardMod.TryFind("EssenceofTime", out ModItem EssenceofTime))
                {
                    modMaterialsShop.Add(EssenceofTime.Type, CheckDowned.overwatcher);
                }
                if (CheckDowned.homewardMod.TryFind("EssenceofDeath", out ModItem EssenceofDeath))
                {
                    modMaterialsShop.Add(EssenceofDeath.Type, CheckDowned.whale);
                }
                if (CheckDowned.homewardMod.TryFind("JungleDewdrop", out ModItem JungleDewdrop))
                {
                    modMaterialsShop.Add(JungleDewdrop.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.homewardMod.TryFind("SolarFlareScoria", out ModItem SolarFlareScoria))
                {
                    modMaterialsShop.Add(SolarFlareScoria.Type, CheckDowned.sgod);
                }
                if (CheckDowned.homewardMod.TryFind("SoulofBlight", out ModItem SoulofBlight))
                {
                    modMaterialsShop.Add(SoulofBlight.Type, CheckDowned.motherbrain);
                }
                if (CheckDowned.homewardMod.TryFind("SpiralTissue", out ModItem SpiralTissue))
                {
                    modMaterialsShop.Add(SpiralTissue.Type, CheckDowned.wos);
                }
                if (CheckDowned.homewardMod.TryFind("SteelFeather", out ModItem SteelFeather))
                {
                    modMaterialsShop.Add(SteelFeather.Type, CheckDowned.wos);
                }
                if (CheckDowned.homewardMod.TryFind("SunlightGel", out ModItem SunlightGel))
                {
                    modMaterialsShop.Add(SunlightGel.Type, CheckDowned.wos);
                }
                if (CheckDowned.homewardMod.TryFind("TankOfThePastCave", out ModItem TankOfThePastCave))
                {
                    modMaterialsShop.Add(TankOfThePastCave.Type, CheckDowned.caveOrdeal);
                }
                if (CheckDowned.homewardMod.TryFind("TankOfThePastCorruption", out ModItem TankOfThePastCorruption))
                {
                    modMaterialsShop.Add(TankOfThePastCorruption.Type, CheckDowned.corruptOrdeal);
                }
                if (CheckDowned.homewardMod.TryFind("TankOfThePastCrimson", out ModItem TankOfThePastCrimson))
                {
                    modMaterialsShop.Add(TankOfThePastCrimson.Type, CheckDowned.crimsonOrdeal);
                }
                if (CheckDowned.homewardMod.TryFind("TankOfThePastDesert", out ModItem TankOfThePastDesert))
                {
                    modMaterialsShop.Add(TankOfThePastDesert.Type, CheckDowned.desertOrdeal);
                }
                if (CheckDowned.homewardMod.TryFind("TankOfThePastForest", out ModItem TankOfThePastForest))
                {
                    modMaterialsShop.Add(TankOfThePastForest.Type, CheckDowned.forestOrdeal);
                }
                if (CheckDowned.homewardMod.TryFind("TankOfThePastHallow", out ModItem TankOfThePastHallow))
                {
                    modMaterialsShop.Add(TankOfThePastHallow.Type, CheckDowned.hallowOrdeal);
                }
                if (CheckDowned.homewardMod.TryFind("TankOfThePastJungle", out ModItem TankOfThePastJungle))
                {
                    modMaterialsShop.Add(TankOfThePastJungle.Type, CheckDowned.jungleOrdeal);
                }
                if (CheckDowned.homewardMod.TryFind("TankOfThePastSky", out ModItem TankOfThePastSky))
                {
                    modMaterialsShop.Add(TankOfThePastSky.Type, CheckDowned.skyOrdeal);
                }
                if (CheckDowned.homewardMod.TryFind("TankOfThePastSnowland", out ModItem TankOfThePastSnowland))
                {
                    modMaterialsShop.Add(TankOfThePastSnowland.Type, CheckDowned.snowOrdeal);
                }
                if (CheckDowned.homewardMod.TryFind("TankOfThePastUnderworld", out ModItem TankOfThePastUnderworld))
                {
                    modMaterialsShop.Add(TankOfThePastUnderworld.Type, CheckDowned.underworldOrdeal);
                }
                if (CheckDowned.homewardMod.TryFind("TrueJungleSpore", out ModItem TrueJungleSpore))
                {
                    modMaterialsShop.Add(TrueJungleSpore.Type, CheckDowned.wos);
                }
                if (CheckDowned.homewardMod.TryFind("WillToCorrode", out ModItem WillToCorrode))
                {
                    modMaterialsShop.Add(WillToCorrode.Type, CheckDowned.sgod, CheckDowned.materealizer, CheckDowned.lifebringer);
                }
                if (CheckDowned.homewardMod.TryFind("WillToCrown", out ModItem WillToCrown))
                {
                    modMaterialsShop.Add(WillToCrown.Type, CheckDowned.sgod, CheckDowned.materealizer, CheckDowned.lifebringer);
                }
                if (CheckDowned.homewardMod.TryFind("WillToGrow", out ModItem WillToGrow))
                {
                    modMaterialsShop.Add(WillToGrow.Type, CheckDowned.sgod, CheckDowned.materealizer, CheckDowned.lifebringer);
                }
            }
            //Infernum N/A
            if (CheckDowned.polaritiesLoaded)
            {
                if (CheckDowned.polaritiesMod.TryFind("AlkalineFluid", out ModItem AlkalineFluid))
                {
                    modMaterialsShop.Add(AlkalineFluid.Type);
                }
                if (CheckDowned.polaritiesMod.TryFind("CongealedBrine", out ModItem CongealedBrine))
                {
                    modMaterialsShop.Add(CongealedBrine.Type, Condition.Hardmode);
                }
                if (CheckDowned.polaritiesMod.TryFind("EvilDNA", out ModItem EvilDNA))
                {
                    modMaterialsShop.Add(EvilDNA.Type, CheckDowned.esophage);
                }
                if (CheckDowned.polaritiesMod.TryFind("LimestoneCarapace", out ModItem LimestoneCarapace))
                {
                    modMaterialsShop.Add(LimestoneCarapace.Type, Condition.Hardmode);
                }
                if (CheckDowned.polaritiesMod.TryFind("Rattle", out ModItem Rattle))
                {
                    modMaterialsShop.Add(Rattle.Type);
                }
                if (CheckDowned.polaritiesMod.TryFind("SaltCrystals", out ModItem SaltCrystals))
                {
                    modMaterialsShop.Add(SaltCrystals.Type);
                }
                if (CheckDowned.polaritiesMod.TryFind("SerpentScale", out ModItem SerpentScale))
                {
                    modMaterialsShop.Add(SerpentScale.Type, Condition.Hardmode);
                }
                if (CheckDowned.polaritiesMod.TryFind("StormChunk", out ModItem StormChunk))
                {
                    modMaterialsShop.Add(StormChunk.Type, CheckDowned.cloudfish);
                }
                if (CheckDowned.polaritiesMod.TryFind("Tentacle", out ModItem Tentacle))
                {
                    modMaterialsShop.Add(Tentacle.Type, Condition.Hardmode);
                }
                if (CheckDowned.polaritiesMod.TryFind("VenomGland", out ModItem VenomGland))
                {
                    modMaterialsShop.Add(VenomGland.Type, Condition.Hardmode);
                }
                if (CheckDowned.polaritiesMod.TryFind("WandererPlating", out ModItem WandererPlating))
                {
                    modMaterialsShop.Add(WandererPlating.Type, CheckDowned.wanderer);
                }
            }
            if (CheckDowned.redemptionLoaded)
            {
                if (CheckDowned.redemptionMod.TryFind("AIChip", out ModItem AIChip))
                {
                    modMaterialsShop.Add(AIChip.Type, Condition.Hardmode);
                }
                if (CheckDowned.redemptionMod.TryFind("CarbonMyofibre", out ModItem CarbonMyofibre))
                {
                    modMaterialsShop.Add(CarbonMyofibre.Type, Condition.Hardmode);
                }
                if (CheckDowned.redemptionMod.TryFind("Capacitator", out ModItem Capacitator))
                {
                    modMaterialsShop.Add(Capacitator.Type, Condition.Hardmode);
                }
                if (CheckDowned.redemptionMod.TryFind("CoastScarabShell", out ModItem CoastScarabShell))
                {
                    modMaterialsShop.Add(CoastScarabShell.Type);
                }
                if (CheckDowned.redemptionMod.TryFind("GildedStar", out ModItem GildedStar))
                {
                    modMaterialsShop.Add(GildedStar.Type, CheckDowned.duo);
                }
                if (CheckDowned.redemptionMod.TryFind("GrimShard", out ModItem GrimShard))
                {
                    modMaterialsShop.Add(GrimShard.Type, CheckDowned.keeper);
                }
                if (CheckDowned.redemptionMod.TryFind("LifeFragment", out ModItem LifeFragment))
                {
                    modMaterialsShop.Add(LifeFragment.Type, CheckDowned.nebby);
                }
                if (CheckDowned.redemptionMod.TryFind("LivingTwig", out ModItem LivingTwig))
                {
                    modMaterialsShop.Add(LivingTwig.Type);
                }
                if (CheckDowned.redemptionMod.TryFind("LostSoul", out ModItem LostSoul))
                {
                    modMaterialsShop.Add(LostSoul.Type);
                }
                if (CheckDowned.redemptionMod.TryFind("MoonflareFragment", out ModItem MoonflareFragment))
                {
                    modMaterialsShop.Add(MoonflareFragment.Type);
                }
                if (CheckDowned.redemptionMod.TryFind("Plating", out ModItem Plating))
                {
                    modMaterialsShop.Add(Plating.Type, Condition.Hardmode);
                }
                if (CheckDowned.redemptionMod.TryFind("ToxicBile", out ModItem ToxicBile))
                {
                    modMaterialsShop.Add(ToxicBile.Type, Condition.Hardmode);
                }
                if (CheckDowned.redemptionMod.TryFind("TreeBugShell", out ModItem TreeBugShell))
                {
                    modMaterialsShop.Add(TreeBugShell.Type);
                }
            }
            if (CheckDowned.sotsLoaded)
            {
                if (CheckDowned.sotsMod.TryFind("CursedMatter", out ModItem CursedMatter))
                {
                    modMaterialsShop.Add(CursedMatter.Type, CheckDowned.pharaohscurse);
                }
                if (CheckDowned.sotsMod.TryFind("DissolvingAether", out ModItem DissolvingAether))
                {
                    modMaterialsShop.Add(DissolvingAether.Type, CheckDowned.advisor);
                }
                if (CheckDowned.sotsMod.TryFind("DissolvingAurora", out ModItem DissolvingAurora))
                {
                    modMaterialsShop.Add(DissolvingAurora.Type, CheckDowned.permafrostSpirit);
                }
                if (CheckDowned.sotsMod.TryFind("DissolvingBrilliance", out ModItem DissolvingBrilliance))
                {
                    modMaterialsShop.Add(DissolvingBrilliance.Type, CheckDowned.lux);
                }
                if (CheckDowned.sotsMod.TryFind("DissolvingDeluge", out ModItem DissolvingDeluge))
                {
                    modMaterialsShop.Add(DissolvingDeluge.Type, CheckDowned.tidalSpirit);
                }
                if (CheckDowned.sotsMod.TryFind("DissolvingEarth", out ModItem DissolvingEarth))
                {
                    modMaterialsShop.Add(DissolvingEarth.Type, CheckDowned.earthenSpirit);
                }
                if (CheckDowned.sotsMod.TryFind("DissolvingNature", out ModItem DissolvingNature))
                {
                    modMaterialsShop.Add(DissolvingNature.Type, CheckDowned.natureSpirit);
                }
                if (CheckDowned.sotsMod.TryFind("DissolvingNether", out ModItem DissolvingNether))
                {
                    modMaterialsShop.Add(DissolvingNether.Type, CheckDowned.infernoSpirit);
                }
                if (CheckDowned.sotsMod.TryFind("DissolvingUmbra", out ModItem DissolvingUmbra))
                {
                    modMaterialsShop.Add(DissolvingUmbra.Type, CheckDowned.evilSpirit);
                }
                if (CheckDowned.sotsMod.TryFind("FragmentOfChaos", out ModItem FragmentOfChaos))
                {
                    modMaterialsShop.Add(FragmentOfChaos.Type, Condition.Hardmode);
                }
                if (CheckDowned.sotsMod.TryFind("FragmentOfEarth", out ModItem FragmentOfEarth))
                {
                    modMaterialsShop.Add(FragmentOfEarth.Type);
                }
                if (CheckDowned.sotsMod.TryFind("FragmentOfEvil", out ModItem FragmentOfEvil))
                {
                    modMaterialsShop.Add(FragmentOfEvil.Type);
                }
                if (CheckDowned.sotsMod.TryFind("FragmentOfInferno", out ModItem FragmentOfInferno))
                {
                    modMaterialsShop.Add(FragmentOfInferno.Type);
                }
                if (CheckDowned.sotsMod.TryFind("FragmentOfNature", out ModItem FragmentOfNature))
                {
                    modMaterialsShop.Add(FragmentOfNature.Type);
                }
                if (CheckDowned.sotsMod.TryFind("FragmentOfOtherworld", out ModItem FragmentOfOtherworld))
                {
                    modMaterialsShop.Add(FragmentOfOtherworld.Type);
                }
                if (CheckDowned.sotsMod.TryFind("FragmentOfPermafrost", out ModItem FragmentOfPermafrost))
                {
                    modMaterialsShop.Add(FragmentOfPermafrost.Type);
                }
                if (CheckDowned.sotsMod.TryFind("FragmentOfTide", out ModItem FragmentOfTide))
                {
                    modMaterialsShop.Add(FragmentOfTide.Type);
                }
                if (CheckDowned.sotsMod.TryFind("Peanut", out ModItem Peanut))
                {
                    modMaterialsShop.Add(Peanut.Type);
                }
                if (CheckDowned.sotsMod.TryFind("SanguiteBar", out ModItem SanguiteBar))
                {
                    modMaterialsShop.Add(SanguiteBar.Type, CheckDowned.serpent);
                }
                if (CheckDowned.sotsMod.TryFind("Snakeskin", out ModItem Snakeskin))
                {
                    modMaterialsShop.Add(Snakeskin.Type, Condition.DownedEowOrBoc);
                }
                if (CheckDowned.sotsMod.TryFind("SoulResidue", out ModItem SoulResidue))
                {
                    modMaterialsShop.Add(SoulResidue.Type, Condition.DownedEowOrBoc);
                }
                if (CheckDowned.sotsMod.TryFind("TwilightGel", out ModItem TwilightGel))
                {
                    modMaterialsShop.Add(TwilightGel.Type);
                }
                if (CheckDowned.sotsMod.TryFind("TwilightShard", out ModItem TwilightShard))
                {
                    modMaterialsShop.Add(TwilightShard.Type, CheckDowned.advisor);
                }
                if (CheckDowned.sotsMod.TryFind("VialofAcid", out ModItem VialofAcid))
                {
                    modMaterialsShop.Add(VialofAcid.Type, CheckDowned.putridpinky);
                }
            }
            if (CheckDowned.spiritLoaded)
            {
                if (CheckDowned.spiritMod.TryFind("Rune", out ModItem Rune))
                {
                    modMaterialsShop.Add(Rune.Type, Condition.DownedMechBossAny);
                }
                if (CheckDowned.spiritMod.TryFind("ArcaneGeyser", out ModItem ArcaneGeyser))
                {
                    modMaterialsShop.Add(ArcaneGeyser.Type, CheckDowned.atlas);
                }
                if (CheckDowned.spiritMod.TryFind("MoonStone", out ModItem MoonStone))
                {
                    modMaterialsShop.Add(MoonStone.Type, CheckDowned.mysticMoon);
                }
                if (CheckDowned.spiritMod.TryFind("BismiteCrystal", out ModItem BismiteCrystal))
                {
                    modMaterialsShop.Add(BismiteCrystal.Type);
                }
                if (CheckDowned.spiritMod.TryFind("Brightbulb", out ModItem Brightbulb))
                {
                    modMaterialsShop.Add(Brightbulb.Type);
                }
                if (CheckDowned.spiritMod.TryFind("Chitin", out ModItem Chitin))
                {
                    modMaterialsShop.Add(Chitin.Type, CheckDowned.scarabeus);
                }
                if (CheckDowned.spiritMod.TryFind("CloudstalkItem", out ModItem CloudstalkItem))
                {
                    modMaterialsShop.Add(CloudstalkItem.Type);
                }
                if (CheckDowned.spiritMod.TryFind("DeepCascadeShard", out ModItem DeepCascadeShard))
                {
                    modMaterialsShop.Add(DeepCascadeShard.Type);
                }
                if (CheckDowned.spiritMod.TryFind("SynthMaterial", out ModItem SynthMaterial))
                {
                    modMaterialsShop.Add(SynthMaterial.Type, Condition.DownedGoblinArmy);
                }
                if (CheckDowned.spiritMod.TryFind("DuskStone", out ModItem DuskStone))
                {
                    modMaterialsShop.Add(DuskStone.Type, CheckDowned.dusking);
                }
                if (CheckDowned.spiritMod.TryFind("DreamstrideEssence", out ModItem DreamstrideEssence))
                {
                    modMaterialsShop.Add(DreamstrideEssence.Type, CheckDowned.bloodMoon);
                }
                if (CheckDowned.spiritMod.TryFind("EmptyCodex", out ModItem EmptyCodex))
                {
                    modMaterialsShop.Add(EmptyCodex.Type);
                }
                if (CheckDowned.spiritMod.TryFind("EnchantedLeaf", out ModItem EnchantedLeaf))
                {
                    modMaterialsShop.Add(EnchantedLeaf.Type);
                }
                if (CheckDowned.spiritMod.TryFind("StarEnergy", out ModItem StarEnergy))
                {
                    modMaterialsShop.Add(StarEnergy.Type);
                }
                if (CheckDowned.spiritMod.TryFind("FrigidFragment", out ModItem FrigidFragment))
                {
                    modMaterialsShop.Add(FrigidFragment.Type);
                }
                if (CheckDowned.spiritMod.TryFind("GlowRoot", out ModItem GlowRoot))
                {
                    modMaterialsShop.Add(GlowRoot.Type);
                }
                if (CheckDowned.spiritMod.TryFind("GranitechMaterial", out ModItem GranitechMaterial))
                {
                    modMaterialsShop.Add(GranitechMaterial.Type, Condition.Hardmode);
                }
                if (CheckDowned.spiritMod.TryFind("HeartScale", out ModItem HeartScale))
                {
                    modMaterialsShop.Add(HeartScale.Type);
                }
                if (CheckDowned.spiritMod.TryFind("IridescentScale", out ModItem IridescentScale))
                {
                    modMaterialsShop.Add(IridescentScale.Type);
                }
                if (CheckDowned.spiritMod.TryFind("Kelp", out ModItem Kelp))
                {
                    modMaterialsShop.Add(Kelp.Type);
                }
                if (CheckDowned.spiritMod.TryFind("NetherCrystal", out ModItem NetherCrystal))
                {
                    modMaterialsShop.Add(NetherCrystal.Type, Condition.DownedMechBossAny);
                }
                if (CheckDowned.spiritMod.TryFind("OldLeather", out ModItem OldLeather))
                {
                    modMaterialsShop.Add(OldLeather.Type);
                }
                if (CheckDowned.spiritMod.TryFind("CarvedRock", out ModItem CarvedRock))
                {
                    modMaterialsShop.Add(CarvedRock.Type, Condition.DownedSkeletron);
                }
                if (CheckDowned.spiritMod.TryFind("InfernalAppendage", out ModItem InfernalAppendage))
                {
                    modMaterialsShop.Add(InfernalAppendage.Type, CheckDowned.infernon);
                }
                if (CheckDowned.spiritMod.TryFind("TribalScale", out ModItem TribalScale))
                {
                    modMaterialsShop.Add(TribalScale.Type, CheckDowned.tide);
                }
                if (CheckDowned.spiritMod.TryFind("SoulBloom", out ModItem SoulBloom))
                {
                    modMaterialsShop.Add(SoulBloom.Type, Condition.DownedMechBossAny);
                }
                if (CheckDowned.spiritMod.TryFind("SoulShred", out ModItem SoulShred))
                {
                    modMaterialsShop.Add(SoulShred.Type, Condition.DownedMechBossAny);
                }
                if (CheckDowned.spiritMod.TryFind("SulfurDeposit", out ModItem SulfurDeposit))
                {
                    modMaterialsShop.Add(SulfurDeposit.Type);
                }
                if (CheckDowned.spiritMod.TryFind("TechDrive", out ModItem TechDrive))
                {
                    modMaterialsShop.Add(TechDrive.Type, Condition.DownedGoblinArmy);
                }
            }
            //Spooky N/A
            if (CheckDowned.stormLoaded)
            {
                if (CheckDowned.stormMod.TryFind("BloodDrop", out ModItem BloodDrop))
                {
                    modMaterialsShop.Add(BloodDrop.Type, Condition.DownedEowOrBoc, CheckDowned.bloodMoon);
                }
                if (CheckDowned.stormMod.TryFind("CrackedHeart", out ModItem CrackedHeart))
                {
                    //Broken Heart
                    modMaterialsShop.Add(CrackedHeart.Type);
                }
                if (CheckDowned.stormMod.TryFind("ChaosShard", out ModItem ChaosShard))
                {
                    modMaterialsShop.Add(ChaosShard.Type, Condition.Hardmode);
                }
                if (CheckDowned.stormMod.TryFind("DerplingShell", out ModItem DerplingShell))
                {
                    modMaterialsShop.Add(DerplingShell.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.stormMod.TryFind("GraniteCore", out ModItem GraniteCore))
                {
                    modMaterialsShop.Add(GraniteCore.Type);
                }
                if (CheckDowned.stormMod.TryFind("SoulFire", out ModItem SoulFire))
                {
                    modMaterialsShop.Add(SoulFire.Type, Condition.DownedMechBossAny);
                }
                if (CheckDowned.stormMod.TryFind("BlueCloth", out ModItem BlueCloth))
                {
                    //Insulated Fabric
                    modMaterialsShop.Add(BlueCloth.Type);
                }
                if (CheckDowned.stormMod.TryFind("SantankScrap", out ModItem SantankScrap))
                {
                    modMaterialsShop.Add(SantankScrap.Type, Condition.DownedSantaNK1);
                }
                if (CheckDowned.stormMod.TryFind("RedSilk", out ModItem RedSilk))
                {
                    //Warrior Cloth
                    modMaterialsShop.Add(RedSilk.Type);
                }
            }
            //Terrorborn (IF PORTED)
            if (CheckDowned.thoriumLoaded)
            {
                if (CheckDowned.thoriumMod.TryFind("AbyssalChitin", out ModItem AbyssalChitin))
                {
                    modMaterialsShop.Add(AbyssalChitin.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("BioMatter", out ModItem BioMatter))
                {
                    modMaterialsShop.Add(BioMatter.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("BirdTalon", out ModItem BirdTalon))
                {
                    modMaterialsShop.Add(BirdTalon.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("Blood", out ModItem Blood))
                {
                    modMaterialsShop.Add(Blood.Type, CheckDowned.bloodMoon);
                }
                if (CheckDowned.thoriumMod.TryFind("BloomWeave", out ModItem BloomWeave))
                {
                    modMaterialsShop.Add(BloomWeave.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.thoriumMod.TryFind("BrokenHeroFragment", out ModItem BrokenHeroFragment))
                {
                    modMaterialsShop.Add(BrokenHeroFragment.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.thoriumMod.TryFind("BronzeFragments", out ModItem BronzeFragments))
                {
                    modMaterialsShop.Add(BronzeFragments.Type, Condition.DownedSkeletron);
                }
                if (CheckDowned.thoriumMod.TryFind("CelestialFragment", out ModItem CelestialFragment))
                {
                    modMaterialsShop.Add(CelestialFragment.Type, Condition.DownedCultist);
                }
                if (CheckDowned.thoriumMod.TryFind("CeruleanMorel", out ModItem CeruleanMorel))
                {
                    modMaterialsShop.Add(CeruleanMorel.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("CursedCloth", out ModItem CursedCloth))
                {
                    modMaterialsShop.Add(CursedCloth.Type, CheckDowned.lich);
                }
                if (CheckDowned.thoriumMod.TryFind("DarkMatter", out ModItem DarkMatter))
                {
                    modMaterialsShop.Add(DarkMatter.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.thoriumMod.TryFind("DeathEssence", out ModItem DeathEssence))
                {
                    modMaterialsShop.Add(DeathEssence.Type, CheckDowned.primordials);
                }
                if (CheckDowned.thoriumMod.TryFind("DemonBloodShard", out ModItem DemonBloodShard))
                {
                    modMaterialsShop.Add(DemonBloodShard.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.thoriumMod.TryFind("DepthScale", out ModItem DepthScale))
                {
                    modMaterialsShop.Add(DepthScale.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("DreadSoul", out ModItem DreadSoul))
                {
                    modMaterialsShop.Add(DreadSoul.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.thoriumMod.TryFind("Geode", out ModItem Geode))
                {
                    modMaterialsShop.Add(Geode.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("GraniteEnergyCore", out ModItem GraniteEnergyCore))
                {
                    modMaterialsShop.Add(GraniteEnergyCore.Type, Condition.DownedSkeletron);
                }
                if (CheckDowned.thoriumMod.TryFind("GreenDragonScale", out ModItem GreenDragonScale))
                {
                    modMaterialsShop.Add(GreenDragonScale.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("HallowedCharm", out ModItem HallowedCharm))
                {
                    modMaterialsShop.Add(HallowedCharm.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("HolyKnightsAlloy", out ModItem HolyKnightsAlloy))
                {
                    modMaterialsShop.Add(HolyKnightsAlloy.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.thoriumMod.TryFind("IcyShard", out ModItem IcyShard))
                {
                    modMaterialsShop.Add(IcyShard.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("InfernoEssence", out ModItem InfernoEssence))
                {
                    modMaterialsShop.Add(InfernoEssence.Type, CheckDowned.primordials);
                }
                if (CheckDowned.thoriumMod.TryFind("LifeCell", out ModItem LifeCell))
                {
                    modMaterialsShop.Add(LifeCell.Type, Condition.DownedMechBossAny);
                }
                if (CheckDowned.thoriumMod.TryFind("LivingLeaf", out ModItem LivingLeaf))
                {
                    modMaterialsShop.Add(LivingLeaf.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("MarineKelp", out ModItem MarineKelp))
                {
                    modMaterialsShop.Add(MarineKelp.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("OceanEssence", out ModItem OceanEssence))
                {
                    modMaterialsShop.Add(OceanEssence.Type, CheckDowned.primordials);
                }
                if (CheckDowned.thoriumMod.TryFind("Petal", out ModItem Petal))
                {
                    modMaterialsShop.Add(Petal.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("PharaohsBreath", out ModItem PharaohsBreath))
                {
                    modMaterialsShop.Add(PharaohsBreath.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("PurityShards", out ModItem PurityShards))
                {
                    modMaterialsShop.Add(PurityShards.Type, CheckDowned.bloodMoon);
                }
                if (CheckDowned.thoriumMod.TryFind("ShootingStarFragment", out ModItem ShootingStarFragment))
                {
                    modMaterialsShop.Add(ShootingStarFragment.Type, Condition.DownedCultist);
                }
                if (CheckDowned.thoriumMod.TryFind("StrangeAlienTech", out ModItem StrangeAlienTech))
                {
                    modMaterialsShop.Add(StrangeAlienTech.Type, Condition.DownedEowOrBoc);
                }
                if (CheckDowned.thoriumMod.TryFind("StrangePlating", out ModItem StrangePlating))
                {
                    modMaterialsShop.Add(StrangePlating.Type, Condition.DownedMechBossAny);
                }
                if (CheckDowned.thoriumMod.TryFind("SolarPebble", out ModItem SolarPebble))
                {
                    modMaterialsShop.Add(SolarPebble.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.thoriumMod.TryFind("SoulofPlight", out ModItem SoulofPlight))
                {
                    modMaterialsShop.Add(SoulofPlight.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("SpiritDroplet", out ModItem SpiritDroplet))
                {
                    modMaterialsShop.Add(SpiritDroplet.Type, Condition.DownedSkeletron);
                }
                if (CheckDowned.thoriumMod.TryFind("TerrariumCore", out ModItem TerrariumCore))
                {
                    modMaterialsShop.Add(TerrariumCore.Type, Condition.DownedCultist);
                }
                if (CheckDowned.thoriumMod.TryFind("UnfathomableFlesh", out ModItem UnfathomableFlesh))
                {
                    modMaterialsShop.Add(UnfathomableFlesh.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("UnholyShards", out ModItem UnholyShards))
                {
                    modMaterialsShop.Add(UnholyShards.Type, CheckDowned.bloodMoon);
                }
                if (CheckDowned.thoriumMod.TryFind("WhiteDwarfFragment", out ModItem WhiteDwarfFragment))
                {
                    modMaterialsShop.Add(WhiteDwarfFragment.Type, Condition.DownedCultist);
                }
            }
            if (CheckDowned.vitalityLoaded)
            {
                if (CheckDowned.vitalityMod.TryFind("AncientGoldShard", out ModItem AncientGoldShard))
                {
                    modMaterialsShop.Add(AncientGoldShard.Type);
                }
                if (CheckDowned.vitalityMod.TryFind("ChaosCrystal", out ModItem ChaosCrystal))
                {
                    modMaterialsShop.Add(ChaosCrystal.Type, Condition.Hardmode);
                }
                if (CheckDowned.vitalityMod.TryFind("ChaosDust", out ModItem ChaosDust))
                {
                    modMaterialsShop.Add(ChaosDust.Type, Condition.Hardmode);
                }
                if (CheckDowned.vitalityMod.TryFind("Charcoal", out ModItem Charcoal))
                {
                    modMaterialsShop.Add(Charcoal.Type);
                }
                if (CheckDowned.vitalityMod.TryFind("CloudVapor", out ModItem CloudVapor))
                {
                    modMaterialsShop.Add(CloudVapor.Type, CheckDowned.stormcloud);
                }
                if (CheckDowned.vitalityMod.TryFind("Ectosoul", out ModItem Ectosoul))
                {
                    modMaterialsShop.Add(Ectosoul.Type, CheckDowned.paladin);
                }
                if (CheckDowned.vitalityMod.TryFind("EquityCore", out ModItem EquityCore))
                {
                    modMaterialsShop.Add(EquityCore.Type, CheckDowned.paladin);
                }
                if (CheckDowned.vitalityMod.TryFind("EssenceofFire", out ModItem EssenceofFire))
                {
                    modMaterialsShop.Add(EssenceofFire.Type, Condition.Hardmode);
                }
                if (CheckDowned.vitalityMod.TryFind("EssenceofFrost", out ModItem EssenceofFrost))
                {
                    modMaterialsShop.Add(EssenceofFrost.Type, Condition.Hardmode);
                }
                if (CheckDowned.vitalityMod.TryFind("ForbiddenFeather", out ModItem ForbiddenFeather))
                {
                    modMaterialsShop.Add(ForbiddenFeather.Type, Condition.Hardmode);
                }
                if (CheckDowned.vitalityMod.TryFind("GlacialChunk", out ModItem GlacialChunk))
                {
                    modMaterialsShop.Add(GlacialChunk.Type);
                }
                if (CheckDowned.vitalityMod.TryFind("GlowingGranitePowder", out ModItem GlowingGranitePowder))
                {
                    modMaterialsShop.Add(GlowingGranitePowder.Type);
                }
                if (CheckDowned.vitalityMod.TryFind("LivingStick", out ModItem LivingStick))
                {
                    modMaterialsShop.Add(LivingStick.Type);
                }
                if (CheckDowned.vitalityMod.TryFind("PurifiedSpore", out ModItem PurifiedSpore))
                {
                    modMaterialsShop.Add(PurifiedSpore.Type);
                }
                if (CheckDowned.vitalityMod.TryFind("ShiverFragment", out ModItem ShiverFragment))
                {
                    modMaterialsShop.Add(ShiverFragment.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.vitalityMod.TryFind("SoulofVitality", out ModItem SoulofVitality))
                {
                    modMaterialsShop.Add(SoulofVitality.Type, Condition.DownedPlantera);
                }
            }
            modMaterialsShop.Register();

            var modBossBagShop = new NPCShop(Type, "Modded Treasure Bags");
            if (CheckDowned.aqLoaded)
            {
                if (CheckDowned.aqMod.TryFind("CrabsonBag", out ModItem CrabsonBag))
                {
                    modBossBagShop.Add(new Item(CrabsonBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.crabson);
                }
                if (CheckDowned.aqMod.TryFind("OmegaStariteBag", out ModItem OmegaStariteBag))
                {
                    modBossBagShop.Add(new Item(OmegaStariteBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.omegastarite);
                }
                if (CheckDowned.aqMod.TryFind("DustDevilBag", out ModItem DustDevilBag))
                {
                    modBossBagShop.Add(new Item(DustDevilBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.devil);
                }
            }
            if (CheckDowned.calamityLoaded)
            {
                if (CheckDowned.calamityMod.TryFind("DesertScourgeBag", out ModItem DesertScourgeBag))
                {
                    modBossBagShop.Add(new Item(DesertScourgeBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.desertscourge);
                }
                if (CheckDowned.calamityMod.TryFind("CrabulonBag", out ModItem CrabulonBag))
                {
                    modBossBagShop.Add(new Item(CrabulonBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.crabulon);
                }
                if (CheckDowned.calamityMod.TryFind("HiveMindBag", out ModItem HiveMindBag))
                {
                    modBossBagShop.Add(new Item(HiveMindBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.hivemind);
                }
                if (CheckDowned.calamityMod.TryFind("PerforatorBag", out ModItem PerforatorBag))
                {
                    modBossBagShop.Add(new Item(PerforatorBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.perforators);
                }
                if (CheckDowned.calamityMod.TryFind("SlimeGodBag", out ModItem SlimeGodBag))
                {
                    modBossBagShop.Add(new Item(SlimeGodBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.slimegod);
                }
                if (CheckDowned.calamityMod.TryFind("CryogenBag", out ModItem CryogenBag))
                {
                    modBossBagShop.Add(new Item(CryogenBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.cryogen);
                }
                if (CheckDowned.calamityMod.TryFind("AquaticScourgeBag", out ModItem AquaticScourgeBag))
                {
                    modBossBagShop.Add(new Item(AquaticScourgeBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.aquaticscourge);
                }
                if (CheckDowned.calamityMod.TryFind("BrimstoneWaifuBag", out ModItem BrimstoneWaifuBag))
                {
                    modBossBagShop.Add(new Item(BrimstoneWaifuBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.brimstoneelemental);
                }
                if (CheckDowned.calamityMod.TryFind("CalamitasCloneBag", out ModItem CalamitasCloneBag))
                {
                    modBossBagShop.Add(new Item(CalamitasCloneBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.calamitas);
                }
                if (CheckDowned.calamityMod.TryFind("LeviathanBag", out ModItem LeviathanBag))
                {
                    modBossBagShop.Add(new Item(LeviathanBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.leviathan);
                }
                if (CheckDowned.calamityMod.TryFind("AstrumAureusBag", out ModItem AstrumAureusBag))
                {
                    modBossBagShop.Add(new Item(AstrumAureusBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.aureus);
                }
                if (CheckDowned.calamityMod.TryFind("PlaguebringerGoliathBag", out ModItem PlaguebringerGoliathBag))
                {
                    modBossBagShop.Add(new Item(PlaguebringerGoliathBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.plaguebringer);
                }
                if (CheckDowned.calamityMod.TryFind("RavagerBag", out ModItem RavagerBag))
                {
                    modBossBagShop.Add(new Item(RavagerBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.ravager);
                }
                if (CheckDowned.calamityMod.TryFind("AstrumDeusBag", out ModItem AstrumDeusBag))
                {
                    modBossBagShop.Add(new Item(AstrumDeusBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.deus);
                }
                if (CheckDowned.calamityMod.TryFind("DragonfollyBag", out ModItem DragonfollyBag))
                {
                    modBossBagShop.Add(new Item(DragonfollyBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.dragonfolly);
                }
                if (CheckDowned.calamityMod.TryFind("ProvidenceBag", out ModItem ProvidenceBag))
                {
                    modBossBagShop.Add(new Item(ProvidenceBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.providence);
                }
                if (CheckDowned.calamityMod.TryFind("PolterghastBag", out ModItem PolterghastBag))
                {
                    modBossBagShop.Add(new Item(PolterghastBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.polterghast);
                }
                if (CheckDowned.calamityMod.TryFind("CeaselessVoidBag", out ModItem CeaselessVoidBag))
                {
                    modBossBagShop.Add(new Item(CeaselessVoidBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.ceaselessvoid);
                }
                if (CheckDowned.calamityMod.TryFind("StormWeaverBag", out ModItem StormWeaverBag))
                {
                    modBossBagShop.Add(new Item(StormWeaverBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.stormweaver);
                }
                if (CheckDowned.calamityMod.TryFind("SignusBag", out ModItem SignusBag))
                {
                    modBossBagShop.Add(new Item(SignusBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.signus);
                }
                if (CheckDowned.calamityMod.TryFind("OldDukeBag", out ModItem OldDukeBag))
                {
                    modBossBagShop.Add(new Item(OldDukeBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.oldduke);
                }
                if (CheckDowned.calamityMod.TryFind("DevourerofGodsBag", out ModItem DevourerofGodsBag))
                {
                    modBossBagShop.Add(new Item(DevourerofGodsBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.dog);
                }
                if (CheckDowned.calamityMod.TryFind("YharonBag", out ModItem YharonBag))
                {
                    modBossBagShop.Add(new Item(YharonBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.yharon);
                }
                if (CheckDowned.calamityMod.TryFind("DraedonBag", out ModItem DraedonBag))
                {
                    modBossBagShop.Add(new Item(DraedonBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.exomechs);
                }
                if (CheckDowned.calamityMod.TryFind("CalamitasCoffer", out ModItem CalamitasCoffer))
                {
                    modBossBagShop.Add(new Item(CalamitasCoffer.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.scalamitas);
                }
            }
            if (CheckDowned.catalystLoaded)
            {
                if (CheckDowned.catalystMod.TryFind("AstrageldonBag", out ModItem AstrageldonBag))
                {
                    modBossBagShop.Add(new Item(AstrageldonBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.geldon);
                }
            }
            if (CheckDowned.consolariaLoaded)
            {
                if (CheckDowned.consolariaMod.TryFind("LepusBag", out ModItem LepusBag))
                {
                    modBossBagShop.Add(new Item(LepusBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.lepus);
                }
                if (CheckDowned.consolariaMod.TryFind("TurkorBag", out ModItem TurkorBag))
                {
                    modBossBagShop.Add(new Item(TurkorBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.turkor);
                }
                if (CheckDowned.consolariaMod.TryFind("OcramBag", out ModItem OcramBag))
                {
                    modBossBagShop.Add(new Item(OcramBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.ocram);
                }
            }
            if (CheckDowned.echoesLoaded)
            {
                if (CheckDowned.echoesMod.TryFind("GalahisBag", out ModItem GalahisBag))
                {
                    modBossBagShop.Add(new Item(GalahisBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.galahis);
                }
                if (CheckDowned.echoesMod.TryFind("CreationBag", out ModItem CreationBag))
                {
                    modBossBagShop.Add(new Item(CreationBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.creation);
                }
                if (CheckDowned.echoesMod.TryFind("DestructionBag", out ModItem DestructionBag))
                {
                    modBossBagShop.Add(new Item(DestructionBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.destruction);
                }
            }
            if (CheckDowned.fargosSoulsLoaded)
            {
                if (CheckDowned.fargosSoulsMod.TryFind("TrojanSquirrelBag", out ModItem TrojanSquirrelBag))
                {
                    modBossBagShop.Add(new Item(TrojanSquirrelBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.squirrel);
                }
                if (CheckDowned.fargosSoulsMod.TryFind("DeviBag", out ModItem DeviBag))
                {
                    modBossBagShop.Add(new Item(DeviBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.devi);
                }
                if (CheckDowned.fargosSoulsMod.TryFind("LifeChallengerBag", out ModItem LifeChallengerBag))
                {
                    modBossBagShop.Add(new Item(LifeChallengerBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.lieflight);
                }
                if (CheckDowned.fargosSoulsMod.TryFind("CosmosBag", out ModItem CosmosBag))
                {
                    modBossBagShop.Add(new Item(CosmosBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.cosmoschamp);
                }
                if (CheckDowned.fargosSoulsMod.TryFind("AbomBag", out ModItem AbomBag))
                {
                    modBossBagShop.Add(new Item(AbomBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.abom);
                }
                if (CheckDowned.fargosSoulsMod.TryFind("MutantBag", out ModItem MutantBag))
                {
                    modBossBagShop.Add(new Item(MutantBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.mutant);
                }
            }
            //Gerds N/A
            if (CheckDowned.homewardLoaded)
            {
                if (CheckDowned.homewardMod.TryFind("MarquisMoonsquidTreasureBag", out ModItem MarquisMoonsquidTreasureBag))
                {
                    modBossBagShop.Add(new Item(MarquisMoonsquidTreasureBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.squid);
                }
                if (CheckDowned.homewardMod.TryFind("PriestessRodTreasureBag", out ModItem PriestessRodTreasureBag))
                {
                    modBossBagShop.Add(new Item(PriestessRodTreasureBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.rod);
                }
                if (CheckDowned.homewardMod.TryFind("DiverTreasureBag", out ModItem DiverTreasureBag))
                {
                    modBossBagShop.Add(new Item(DiverTreasureBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.diver);
                }
                if (CheckDowned.homewardMod.TryFind("TheMotherbrainTreasureBag", out ModItem TheMotherbrainTreasureBag))
                {
                    modBossBagShop.Add(new Item(TheMotherbrainTreasureBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.motherbrain);
                }
                if (CheckDowned.homewardMod.TryFind("WallofShadowTreasureBag", out ModItem WallofShadowTreasureBag))
                {
                    modBossBagShop.Add(new Item(WallofShadowTreasureBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.wos);
                }
                if (CheckDowned.homewardMod.TryFind("SlimeGodTreasureBag", out ModItem SlimeGodTreasureBag))
                {
                    modBossBagShop.Add(new Item(SlimeGodTreasureBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.sgod);
                }
                if (CheckDowned.homewardMod.TryFind("TheOverwatcherTreasureBag", out ModItem TheOverwatcherTreasureBag))
                {
                    modBossBagShop.Add(new Item(TheOverwatcherTreasureBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.overwatcher);
                }
                if (CheckDowned.homewardMod.TryFind("TheLifebringerTreasureBag", out ModItem TheLifebringerTreasureBag))
                {
                    modBossBagShop.Add(new Item(TheLifebringerTreasureBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.lifebringer);
                }
                if (CheckDowned.homewardMod.TryFind("TheMaterealizerTreasureBag", out ModItem TheMaterealizerTreasureBag))
                {
                    modBossBagShop.Add(new Item(TheMaterealizerTreasureBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.materealizer);
                }
                if (CheckDowned.homewardMod.TryFind("ScarabBeliefTreasureBag", out ModItem ScarabBeliefTreasureBag))
                {
                    modBossBagShop.Add(new Item(ScarabBeliefTreasureBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.scarab);
                }
                if (CheckDowned.homewardMod.TryFind("EverlastingFallingWhaleTreasureBag", out ModItem EverlastingFallingWhaleTreasureBag))
                {
                    modBossBagShop.Add(new Item(EverlastingFallingWhaleTreasureBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.whale);
                }
                if (CheckDowned.homewardMod.TryFind("TheSonTreasureBag", out ModItem TheSonTreasureBag))
                {
                    modBossBagShop.Add(new Item(TheSonTreasureBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.son);
                }
            }
            if (CheckDowned.infernumLoaded)
            {
                if (CheckDowned.infernumMod.TryFind("BereftVassalBossBag", out ModItem BereftVassalBossBag))
                {
                    modBossBagShop.Add(new Item(BereftVassalBossBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.vassal);
                }
            }
            if (CheckDowned.polaritiesLoaded)
            {
                if (CheckDowned.polaritiesMod.TryFind("StormCloudfishBag", out ModItem StormCloudfishBag))
                {
                    modBossBagShop.Add(new Item(StormCloudfishBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.cloudfish);
                }
                if (CheckDowned.polaritiesMod.TryFind("StarConstructBag", out ModItem StarConstructBag))
                {
                    modBossBagShop.Add(new Item(StarConstructBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.construct);
                }
                if (CheckDowned.polaritiesMod.TryFind("GigabatBag", out ModItem GigabatBag))
                {
                    modBossBagShop.Add(new Item(GigabatBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.gigabat);
                }
                if (CheckDowned.polaritiesMod.TryFind("SunPixieBag", out ModItem SunPixieBag))
                {
                    modBossBagShop.Add(new Item(SunPixieBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.sunpixie);
                }
                if (CheckDowned.polaritiesMod.TryFind("EsophageBag", out ModItem EsophageBag))
                {
                    modBossBagShop.Add(new Item(EsophageBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.esophage);
                }
                if (CheckDowned.polaritiesMod.TryFind("ConvectiveWandererBag", out ModItem ConvectiveWandererBag))
                {
                    modBossBagShop.Add(new Item(ConvectiveWandererBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.wanderer);
                }
            }
            if (CheckDowned.qwertyLoaded)
            {
                if (CheckDowned.qwertyMod.TryFind("TundraBossBag", out ModItem TundraBossBag))
                {
                    modBossBagShop.Add(new Item(TundraBossBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.polarBear);
                }
                if (CheckDowned.qwertyMod.TryFind("FortressBossBag", out ModItem FortressBossBag))
                {
                    modBossBagShop.Add(new Item(FortressBossBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.divineLight);
                }
                if (CheckDowned.qwertyMod.TryFind("AncientMachineBag", out ModItem AncientMachineBag))
                {
                    modBossBagShop.Add(new Item(AncientMachineBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.ancientMachine);
                }
                if (CheckDowned.qwertyMod.TryFind("NoehtnapBag", out ModItem NoehtnapBag))
                {
                    modBossBagShop.Add(new Item(NoehtnapBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.noehtnap);
                }
                if (CheckDowned.qwertyMod.TryFind("Hydrabag", out ModItem Hydrabag))
                {
                    modBossBagShop.Add(new Item(Hydrabag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.hydra);
                }
                if (CheckDowned.qwertyMod.TryFind("BladeBossBag", out ModItem BladeBossBag))
                {
                    modBossBagShop.Add(new Item(BladeBossBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.imperious);
                }
                if (CheckDowned.qwertyMod.TryFind("RuneGhostBag", out ModItem RuneGhostBag))
                {
                    modBossBagShop.Add(new Item(RuneGhostBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.runeGhost);
                }
                if (CheckDowned.qwertyMod.TryFind("B4Bag", out ModItem B4Bag))
                {
                    modBossBagShop.Add(new Item(B4Bag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.olord);
                }
            }
            if (CheckDowned.redemptionLoaded)
            {
                if (CheckDowned.redemptionMod.TryFind("ThornBag", out ModItem ThornBag))
                {
                    modBossBagShop.Add(new Item(ThornBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.thorn);
                }
                if (CheckDowned.redemptionMod.TryFind("ErhanBag", out ModItem ErhanBag))
                {
                    modBossBagShop.Add(new Item(ErhanBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.erhan);
                }
                if (CheckDowned.redemptionMod.TryFind("KeeperBag", out ModItem KeeperBag))
                {
                    modBossBagShop.Add(new Item(KeeperBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.keeper);
                }
                if (CheckDowned.redemptionMod.TryFind("SoIBag", out ModItem SoIBag))
                {
                    modBossBagShop.Add(new Item(SoIBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.seed);
                }
                if (CheckDowned.redemptionMod.TryFind("SlayerBag", out ModItem SlayerBag))
                {
                    modBossBagShop.Add(new Item(SlayerBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.ks3);
                }
                if (CheckDowned.redemptionMod.TryFind("OmegaCleaverBag", out ModItem OmegaCleaverBag))
                {
                    modBossBagShop.Add(new Item(OmegaCleaverBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.cleaver);
                }
                if (CheckDowned.redemptionMod.TryFind("OmegaGigaporaBag", out ModItem OmegaGigaporaBag))
                {
                    modBossBagShop.Add(new Item(OmegaGigaporaBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.gigapora);
                }
                if (CheckDowned.redemptionMod.TryFind("OmegaOblitBag", out ModItem OmegaOblitBag))
                {
                    modBossBagShop.Add(new Item(OmegaOblitBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.obliterator);
                }
                if (CheckDowned.redemptionMod.TryFind("PZBag", out ModItem PZBag))
                {
                    modBossBagShop.Add(new Item(PZBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.zero);
                }
                if (CheckDowned.redemptionMod.TryFind("AkkaBag", out ModItem AkkaBag))
                {
                    modBossBagShop.Add(new Item(AkkaBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.duo);
                }
                if (CheckDowned.redemptionMod.TryFind("UkkoBag", out ModItem UkkoBag))
                {
                    modBossBagShop.Add(new Item(UkkoBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.duo);
                }
                if (CheckDowned.redemptionMod.TryFind("NebBag", out ModItem NebBag))
                {
                    modBossBagShop.Add(new Item(NebBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.nebby);
                }
            }
            if (CheckDowned.sotsLoaded)
            {
                if (CheckDowned.sotsMod.TryFind("GlowmothBag", out ModItem GlowmothBag))
                {
                    modBossBagShop.Add(new Item(GlowmothBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.glowmoth);
                }
                if (CheckDowned.sotsMod.TryFind("PinkyBag", out ModItem PinkyBag))
                {
                    modBossBagShop.Add(new Item(PinkyBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.putridpinky);
                }
                if (CheckDowned.sotsMod.TryFind("CurseBag", out ModItem CurseBag))
                {
                    modBossBagShop.Add(new Item(CurseBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.pharaohscurse);
                }
                if (CheckDowned.sotsMod.TryFind("TheAdvisorBossBag", out ModItem TheAdvisorBossBag))
                {
                    modBossBagShop.Add(new Item(TheAdvisorBossBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.advisor);
                }
                if (CheckDowned.sotsMod.TryFind("PolarisBossBag", out ModItem PolarisBossBag))
                {
                    modBossBagShop.Add(new Item(PolarisBossBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.polaris);
                }
                if (CheckDowned.sotsMod.TryFind("LuxBag", out ModItem LuxBag))
                {
                    modBossBagShop.Add(new Item(LuxBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.lux);
                }
                if (CheckDowned.sotsMod.TryFind("SubspaceBag", out ModItem SubspaceBag))
                {
                    modBossBagShop.Add(new Item(SubspaceBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.serpent);
                }
            }
            if (CheckDowned.spiritLoaded)
            {
                if (CheckDowned.spiritMod.TryFind("BagOScarabs", out ModItem BagOScarabs))
                {
                    modBossBagShop.Add(new Item(BagOScarabs.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.scarabeus);
                }
                if (CheckDowned.spiritMod.TryFind("MJWBag", out ModItem MJWBag))
                {
                    modBossBagShop.Add(new Item(MJWBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.moonjelly);
                }
                if (CheckDowned.spiritMod.TryFind("ReachBossBag", out ModItem ReachBossBag))
                {
                    modBossBagShop.Add(new Item(ReachBossBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.vinewrath);
                }
                if (CheckDowned.spiritMod.TryFind("FlyerBag", out ModItem FlyerBag))
                {
                    modBossBagShop.Add(new Item(FlyerBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.avian);
                }
                if (CheckDowned.spiritMod.TryFind("SteamRaiderBag", out ModItem SteamRaiderBag))
                {
                    modBossBagShop.Add(new Item(SteamRaiderBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.starvoyager);
                }
                if (CheckDowned.spiritMod.TryFind("InfernonBag", out ModItem InfernonBag))
                {
                    modBossBagShop.Add(new Item(InfernonBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.infernon);
                }
                if (CheckDowned.spiritMod.TryFind("DuskingBag", out ModItem DuskingBag))
                {
                    modBossBagShop.Add(new Item(DuskingBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.dusking);
                }
                if (CheckDowned.spiritMod.TryFind("AtlasBag", out ModItem AtlasBag))
                {
                    modBossBagShop.Add(new Item(AtlasBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.atlas);
                }
            }
            if (CheckDowned.spookyLoaded)
            {
                if (CheckDowned.spookyMod.TryFind("BossBagSpookySpirit", out ModItem BossBagSpookySpirit))
                {
                    modBossBagShop.Add(new Item(BossBagSpookySpirit.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.spookyspirit);
                }
                if (CheckDowned.spookyMod.TryFind("BossBagRotGourd", out ModItem BossBagRotGourd))
                {
                    modBossBagShop.Add(new Item(BossBagRotGourd.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.gourd);
                }
                if (CheckDowned.spookyMod.TryFind("BossBagMoco", out ModItem BossBagMoco))
                {
                    modBossBagShop.Add(new Item(BossBagMoco.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.moco);
                }
                if (CheckDowned.spookyMod.TryFind("BossBagOrroboro", out ModItem BossBagOrroboro))
                {
                    modBossBagShop.Add(new Item(BossBagOrroboro.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.orroboro);
                }
                if (CheckDowned.spookyMod.TryFind("BossBagBigBone", out ModItem BossBagBigBone))
                {
                    modBossBagShop.Add(new Item(BossBagBigBone.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.bigbone);
                }
            }
            if (CheckDowned.stormLoaded)
            {
                if (CheckDowned.stormMod.TryFind("AridBossBag", out ModItem AridBossBag))
                {
                    modBossBagShop.Add(new Item(AridBossBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.arid);
                }
                if (CheckDowned.stormMod.TryFind("StormBossBag", out ModItem StormBossBag))
                {
                    modBossBagShop.Add(new Item(StormBossBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.storm);
                }
                if (CheckDowned.stormMod.TryFind("UltimateBossBag", out ModItem UltimateBossBag))
                {
                    modBossBagShop.Add(new Item(UltimateBossBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.painbringer);
                }
            }
            if (CheckDowned.terrorbornLoaded)
            {
                if (CheckDowned.terrorbornMod.TryFind("II_TreasureBag", out ModItem II_TreasureBag))
                {
                    modBossBagShop.Add(new Item(II_TreasureBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.incarnate);
                }
                if (CheckDowned.terrorbornMod.TryFind("TT_TreasureBag", out ModItem TT_TreasureBag))
                {
                    modBossBagShop.Add(new Item(TT_TreasureBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.titan);
                }
                if (CheckDowned.terrorbornMod.TryFind("DS_TreasureBag", out ModItem DS_TreasureBag))
                {
                    modBossBagShop.Add(new Item(DS_TreasureBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.dunestock);
                }
                if (CheckDowned.terrorbornMod.TryFind("SC_TreasureBag", out ModItem SC_TreasureBag))
                {
                    modBossBagShop.Add(new Item(SC_TreasureBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.crawler);
                }
                if (CheckDowned.terrorbornMod.TryFind("HC_TreasureBag", out ModItem HC_TreasureBag))
                {
                    modBossBagShop.Add(new Item(HC_TreasureBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.constructor);
                }
                if (CheckDowned.terrorbornMod.TryFind("PI_TreasureBag", out ModItem PI_TreasureBag))
                {
                    modBossBagShop.Add(new Item(PI_TreasureBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.p1);
                }
            }
            if (CheckDowned.thoriumLoaded)
            {
                if (CheckDowned.thoriumMod.TryFind("ThunderBirdBag", out ModItem ThunderBirdBag))
                {
                    modBossBagShop.Add(new Item(ThunderBirdBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.grandbird);
                }
                if (CheckDowned.thoriumMod.TryFind("JellyFishBag", out ModItem JellyFishBag))
                {
                    modBossBagShop.Add(new Item(JellyFishBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.queenjelly);
                }
                if (CheckDowned.thoriumMod.TryFind("CountBag", out ModItem CountBag))
                {
                    modBossBagShop.Add(new Item(CountBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.viscount);
                }
                if (CheckDowned.thoriumMod.TryFind("GraniteBag", out ModItem GraniteBag))
                {
                    modBossBagShop.Add(new Item(GraniteBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.energystorm);
                }
                if (CheckDowned.thoriumMod.TryFind("HeroBag", out ModItem HeroBag))
                {
                    modBossBagShop.Add(new Item(HeroBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.buriedchampion);
                }
                if (CheckDowned.thoriumMod.TryFind("ScouterBag", out ModItem ScouterBag))
                {
                    modBossBagShop.Add(new Item(ScouterBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.scouter);
                }
                if (CheckDowned.thoriumMod.TryFind("BoreanBag", out ModItem BoreanBag))
                {
                    modBossBagShop.Add(new Item(BoreanBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.strider);
                }
                if (CheckDowned.thoriumMod.TryFind("BeholderBag", out ModItem BeholderBag))
                {
                    modBossBagShop.Add(new Item(BeholderBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.fallenbeholder);
                }
                if (CheckDowned.thoriumMod.TryFind("LichBag", out ModItem LichBag))
                {
                    modBossBagShop.Add(new Item(LichBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.lich);
                }
                if (CheckDowned.thoriumMod.TryFind("AbyssionBag", out ModItem AbyssionBag))
                {
                    modBossBagShop.Add(new Item(AbyssionBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.forgottenone);
                }
                if (CheckDowned.thoriumMod.TryFind("RagBag", out ModItem RagBag))
                {
                    modBossBagShop.Add(new Item(RagBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.primordials);
                }
            }
            if (CheckDowned.vitalityLoaded)
            {
                if (CheckDowned.vitalityMod.TryFind("StormCloudBossBag", out ModItem StormCloudBossBag))
                {
                    modBossBagShop.Add(new Item(StormCloudBossBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.stormcloud);
                }
                if (CheckDowned.vitalityMod.TryFind("GrandAntlionBossBag", out ModItem GrandAntlionBossBag))
                {
                    modBossBagShop.Add(new Item(GrandAntlionBossBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.grandantlion);
                }
                if (CheckDowned.vitalityMod.TryFind("GemstoneElementalBossBag", out ModItem GemstoneElementalBossBag))
                {
                    modBossBagShop.Add(new Item(GemstoneElementalBossBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.gemstone);
                }
                if (CheckDowned.vitalityMod.TryFind("MoonlightDragonflyBossBag", out ModItem MoonlightDragonflyBossBag))
                {
                    modBossBagShop.Add(new Item(MoonlightDragonflyBossBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.dragonfly);
                }
                if (CheckDowned.vitalityMod.TryFind("DreadnaughtBossBag", out ModItem DreadnaughtBossBag))
                {
                    modBossBagShop.Add(new Item(DreadnaughtBossBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.dreadnaught);
                }
                if (CheckDowned.vitalityMod.TryFind("AnarchulesBeetleBossBag", out ModItem AnarchulesBeetleBossBag))
                {
                    modBossBagShop.Add(new Item(AnarchulesBeetleBossBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.anarchulesbeetle);
                }
                if (CheckDowned.vitalityMod.TryFind("ChaosbringerBossBag", out ModItem ChaosbringerBossBag))
                {
                    modBossBagShop.Add(new Item(ChaosbringerBossBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.chaosbringer);
                }
                if (CheckDowned.vitalityMod.TryFind("PaladinSpiritBossBag", out ModItem PaladinSpiritBossBag))
                {
                    modBossBagShop.Add(new Item(PaladinSpiritBossBag.Type) { shopCustomPrice = Item.buyPrice(platinum: 2) }, CheckDowned.paladin);
                }
            }
            modBossBagShop.Register();

            var modCratesShop = new NPCShop(Type, "Modded Crates & Grab Bags");
            if (CheckDowned.aqLoaded)
            {
                if (CheckDowned.aqMod.TryFind("CrabCreviceCrate", out ModItem CrabCreviceCrate))
                {
                    modCratesShop.Add(CrabCreviceCrate.Type);
                }
                if (CheckDowned.aqMod.TryFind("CrabCreviceCrateHard", out ModItem CrabCreviceCrateHard))
                {
                    modCratesShop.Add(CrabCreviceCrateHard.Type, Condition.Hardmode);
                }
            }
            if (CheckDowned.calamityLoaded)
            {
                if (CheckDowned.calamityMod.TryFind("AstralCrate", out ModItem AstralCrate))
                {
                    modCratesShop.Add(AstralCrate.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("BrimstoneCrate", out ModItem BrimstoneCrate))
                {
                    modCratesShop.Add(BrimstoneCrate.Type);
                }
                if (CheckDowned.calamityMod.TryFind("SulphurousCrate", out ModItem SulphurousCrate))
                {
                    modCratesShop.Add(SulphurousCrate.Type);
                }
                if (CheckDowned.calamityMod.TryFind("SunkenCrate", out ModItem SunkenCrate))
                {
                    modCratesShop.Add(SunkenCrate.Type);
                }
                if (CheckDowned.calamityMod.TryFind("AbyssalTreasure", out ModItem AbyssalTreasure))
                {
                    modCratesShop.Add(AbyssalTreasure.Type);
                }
                if (CheckDowned.calamityMod.TryFind("FleshyGeode", out ModItem FleshyGeode))
                {
                    modCratesShop.Add(FleshyGeode.Type, CheckDowned.ravager);
                }
                if (CheckDowned.calamityMod.TryFind("NecromanticGeode", out ModItem NecromanticGeode))
                {
                    modCratesShop.Add(NecromanticGeode.Type, CheckDowned.providence);
                }
                if (CheckDowned.calamityMod.TryFind("SulphuricTreasure", out ModItem SulphuricTreasure))
                {
                    modCratesShop.Add(SulphuricTreasure.Type);
                }
            }
            //Catalyst N/A
            //Consolaria N/A
            //Echoes N/A
            //Fargos N/A
            //Gerds N/A
            //Homeward N/A
            //Infernum N/A
            if (CheckDowned.polaritiesLoaded)
            {
                if (CheckDowned.polaritiesMod.TryFind("SaltCrate", out ModItem SaltCrate))
                {
                    modCratesShop.Add(SaltCrate.Type);
                }
            }
            //Qwerty N/A
            if (CheckDowned.redemptionLoaded)
            {
                if (CheckDowned.redemptionMod.TryFind("PetrifiedCrate", out ModItem PetrifiedCrate))
                {
                    modCratesShop.Add(PetrifiedCrate.Type, Condition.Hardmode);
                }
                if (CheckDowned.redemptionMod.TryFind("LabCrate", out ModItem LabCrate))
                {
                    modCratesShop.Add(LabCrate.Type, Condition.DownedMechBossAll);
                }
                if (CheckDowned.redemptionMod.TryFind("LabCrate2", out ModItem LabCrate2))
                {
                    modCratesShop.Add(LabCrate2.Type, Condition.DownedMoonLord);
                }
            }
            if (CheckDowned.sotsLoaded)
            {
                if (CheckDowned.sotsMod.TryFind("PyramidCrate", out ModItem PyramidCrate))
                {
                    modCratesShop.Add(PyramidCrate.Type, Condition.DownedEowOrBoc);
                }
            }
            if (CheckDowned.spiritLoaded)
            {
                if (CheckDowned.spiritMod.TryFind("ReachCrate", out ModItem ReachCrate))
                {
                    modCratesShop.Add(ReachCrate.Type);
                }
                if (CheckDowned.spiritMod.TryFind("BriarCrate", out ModItem BriarCrate))
                {
                    modCratesShop.Add(BriarCrate.Type, Condition.Hardmode);
                }
                if (CheckDowned.spiritMod.TryFind("SpiritCrate", out ModItem SpiritCrate))
                {
                    modCratesShop.Add(SpiritCrate.Type, Condition.DownedMechBossAny);
                }
                if (CheckDowned.spiritMod.TryFind("FishCrate", out ModItem FishCrate))
                {
                    modCratesShop.Add(FishCrate.Type);
                }
                if (CheckDowned.spiritMod.TryFind("PirateCrate", out ModItem PirateCrate))
                {
                    modCratesShop.Add(PirateCrate.Type, Condition.DownedPirates);
                }
            }
            //Spooky N/A
            //Storms N/A
            //Terrorborn N/A
            if (CheckDowned.thoriumLoaded)
            {
                if (CheckDowned.thoriumMod.TryFind("AquaticDepthsCrate", out ModItem AquaticDepthsCrate))
                {
                    modCratesShop.Add(AquaticDepthsCrate.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("AbyssalCrate", out ModItem AbyssalCrate))
                {
                    modCratesShop.Add(AbyssalCrate.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("ScarletCrate", out ModItem ScarletCrate))
                {
                    modCratesShop.Add(ScarletCrate.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("SinisterCrate", out ModItem SinisterCrate))
                {
                    modCratesShop.Add(SinisterCrate.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("StrangeCrate", out ModItem StrangeCrate))
                {
                    modCratesShop.Add(StrangeCrate.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("WondrousCrate", out ModItem WondrousCrate))
                {
                    modCratesShop.Add(WondrousCrate.Type, Condition.Hardmode);
                }
            }
            //Vitality N/A
            modCratesShop.Register();

            var modOreShop = new NPCShop(Type, "Modded Ores & Bars");
            //Aequus N/A
            if (CheckDowned.calamityLoaded)
            {
                if (CheckDowned.calamityMod.TryFind("AerialiteOre", out ModItem AerialiteOre))
                {
                    modOreShop.Add(AerialiteOre.Type, CheckDowned.perfOrHive);
                }
                if (CheckDowned.calamityMod.TryFind("AstralOre", out ModItem AstralOre))
                {
                    modOreShop.Add(AstralOre.Type, CheckDowned.deus);
                }
                if (CheckDowned.calamityMod.TryFind("AuricOre", out ModItem AuricOre))
                {
                    modOreShop.Add(AuricOre.Type, CheckDowned.yharon);
                }
                if (CheckDowned.calamityMod.TryFind("CryonicOre", out ModItem CryonicOre))
                {
                    modOreShop.Add(CryonicOre.Type, CheckDowned.cryogen);
                }
                if (CheckDowned.calamityMod.TryFind("ExodiumCluster", out ModItem ExodiumCluster))
                {
                    modOreShop.Add(ExodiumCluster.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.calamityMod.TryFind("HallowedOre", out ModItem HallowedOre))
                {
                    modOreShop.Add(HallowedOre.Type, Condition.DownedMechBossAll);
                }
                if (CheckDowned.calamityMod.TryFind("InfernalSuevite", out ModItem InfernalSuevite))
                {
                    modOreShop.Add(InfernalSuevite.Type, Condition.DownedMechBossAny);
                }
                if (CheckDowned.calamityMod.TryFind("PerennialOre", out ModItem PerennialOre))
                {
                    modOreShop.Add(PerennialOre.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.calamityMod.TryFind("PrismShard", out ModItem PrismShard))
                {
                    modOreShop.Add(PrismShard.Type);
                }
                if (CheckDowned.calamityMod.TryFind("ScoriaOre", out ModItem ScoriaOre))
                {
                    modOreShop.Add(ScoriaOre.Type, Condition.DownedGolem);
                }
                if (CheckDowned.calamityMod.TryFind("SeaPrism", out ModItem SeaPrism))
                {
                    modOreShop.Add(SeaPrism.Type);
                }
                if (CheckDowned.calamityMod.TryFind("UelibloomOre", out ModItem UelibloomOre))
                {
                    modOreShop.Add(UelibloomOre.Type, CheckDowned.providence);
                }
                if (CheckDowned.calamityMod.TryFind("AerialiteBar", out ModItem AerialiteBar))
                {
                    modOreShop.Add(AerialiteBar.Type, CheckDowned.perfOrHive);
                }
                if (CheckDowned.calamityMod.TryFind("AstralBar", out ModItem AstralBar))
                {
                    modOreShop.Add(AstralBar.Type, CheckDowned.deus);
                }
                if (CheckDowned.calamityMod.TryFind("AuricBar", out ModItem AuricBar))
                {
                    modOreShop.Add(AuricBar.Type, CheckDowned.yharon);
                }
                if (CheckDowned.calamityMod.TryFind("CosmiliteBar", out ModItem CosmiliteBar))
                {
                    modOreShop.Add(CosmiliteBar.Type, CheckDowned.dog);
                }
                if (CheckDowned.calamityMod.TryFind("CryonicBar", out ModItem CryonicBar))
                {
                    modOreShop.Add(CryonicBar.Type, CheckDowned.cryogen);
                }
                if (CheckDowned.calamityMod.TryFind("PerennialBar", out ModItem PerennialBar))
                {
                    modOreShop.Add(PerennialBar.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.calamityMod.TryFind("ScoriaBar", out ModItem ScoriaBar))
                {
                    modOreShop.Add(ScoriaBar.Type, Condition.DownedGolem);
                }
                if (CheckDowned.calamityMod.TryFind("ShadowspecBar", out ModItem ShadowspecBar))
                {
                    modOreShop.Add(ShadowspecBar.Type, CheckDowned.scalamitas);
                }
                if (CheckDowned.calamityMod.TryFind("UelibloomBar", out ModItem UelibloomBar))
                {
                    modOreShop.Add(UelibloomBar.Type, CheckDowned.providence);
                }
            }
            if (CheckDowned.catalystLoaded)
            {
                if (CheckDowned.catalystMod.TryFind("MetanovaOre", out ModItem MetanovaOre))
                {
                    modOreShop.Add(MetanovaOre.Type, CheckDowned.geldon);
                }
                if (CheckDowned.catalystMod.TryFind("MetanovaBar", out ModItem MetanovaBar))
                {
                    modOreShop.Add(MetanovaBar.Type, CheckDowned.geldon);
                }
            }
            //Consolaria N/A
            if (CheckDowned.echoesLoaded)
            {
                if (CheckDowned.echoesMod.TryFind("ArcaniumOre", out ModItem ArcaniumOre))
                {
                    modOreShop.Add(ArcaniumOre.Type);
                }
                if (CheckDowned.echoesMod.TryFind("Moonstone", out ModItem Moonstone))
                {
                    modOreShop.Add(Moonstone.Type, Condition.Hardmode);
                }
                if (CheckDowned.echoesMod.TryFind("Skystone_Ore", out ModItem Skystone_Ore))
                {
                    modOreShop.Add(Skystone_Ore.Type, Condition.DownedGolem);
                }
                if (CheckDowned.echoesMod.TryFind("VarsiumCrystal", out ModItem VarsiumCrystal))
                {
                    modOreShop.Add(VarsiumCrystal.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.echoesMod.TryFind("Ashen_Ore", out ModItem Ashen_Ore))
                {
                    modOreShop.Add(Ashen_Ore.Type, Condition.DownedGolem);
                }
                if (CheckDowned.echoesMod.TryFind("UniversiumOre", out ModItem UniversiumOre))
                {
                    modOreShop.Add(UniversiumOre.Type, Condition.DownedCultist);
                }
                if (CheckDowned.echoesMod.TryFind("Arcanium_Bar", out ModItem Arcanium_Bar))
                {
                    modOreShop.Add(Arcanium_Bar.Type);
                }
                if (CheckDowned.echoesMod.TryFind("SkystoneBar", out ModItem SkystoneBar))
                {
                    modOreShop.Add(SkystoneBar.Type, Condition.DownedGolem);
                }
                if (CheckDowned.echoesMod.TryFind("Ashen_Bar", out ModItem Ashen_Bar))
                {
                    modOreShop.Add(Ashen_Bar.Type, Condition.DownedGolem);
                }
                if (CheckDowned.echoesMod.TryFind("UniversiumBar", out ModItem UniversiumBar))
                {
                    modOreShop.Add(UniversiumBar.Type, Condition.DownedCultist);
                }
            }
            //Fargos N/A
            //Gerds N/A
            if (CheckDowned.homewardLoaded)
            {
                if (CheckDowned.homewardMod.TryFind("Onyx", out ModItem Onyx))
                {
                    modOreShop.Add(Onyx.Type, CheckDowned.diver);
                }
                if (CheckDowned.homewardMod.TryFind("CubistOre", out ModItem CubistOre))
                {
                    modOreShop.Add(CubistOre.Type, CheckDowned.wos);
                }
                if (CheckDowned.homewardMod.TryFind("DeepOre", out ModItem DeepOre))
                {
                    modOreShop.Add(DeepOre.Type, CheckDowned.diver);
                }
                if (CheckDowned.homewardMod.TryFind("FinalOre", out ModItem FinalOre))
                {
                    modOreShop.Add(FinalOre.Type, CheckDowned.lifebringer, CheckDowned.materealizer, CheckDowned.overwatcher);
                }
                if (CheckDowned.homewardMod.TryFind("EternalOre", out ModItem EternalOre))
                {
                    modOreShop.Add(EternalOre.Type, CheckDowned.wos);
                }
                if (CheckDowned.homewardMod.TryFind("LivingOre", out ModItem LivingOre))
                {
                    modOreShop.Add(LivingOre.Type, CheckDowned.wos);
                }
                if (CheckDowned.homewardMod.TryFind("CubistBar", out ModItem CubistBar))
                {
                    modOreShop.Add(CubistBar.Type, CheckDowned.wos);
                }
                if (CheckDowned.homewardMod.TryFind("DeepBar", out ModItem DeepBar))
                {
                    modOreShop.Add(DeepBar.Type, CheckDowned.diver);
                }
                if (CheckDowned.homewardMod.TryFind("FinalBar", out ModItem FinalBar))
                {
                    modOreShop.Add(FinalBar.Type, CheckDowned.lifebringer, CheckDowned.materealizer, CheckDowned.overwatcher);
                }
                if (CheckDowned.homewardMod.TryFind("EternalBar", out ModItem EternalBar))
                {
                    modOreShop.Add(EternalBar.Type, CheckDowned.wos);
                }
                if (CheckDowned.homewardMod.TryFind("LivingBar", out ModItem LivingBar))
                {
                    modOreShop.Add(LivingBar.Type, CheckDowned.wos);
                }
                if (CheckDowned.homewardMod.TryFind("AbyssalChunk", out ModItem AbyssalChunk))
                {
                    modOreShop.Add(AbyssalChunk.Type, CheckDowned.diver);
                }
            }
            //Infernum N/A
            if (CheckDowned.polaritiesLoaded)
            {
                if (CheckDowned.polaritiesMod.TryFind("MantellarOre", out ModItem MantellarOre))
                {
                    modOreShop.Add(MantellarOre.Type, Condition.DownedGolem);
                }
                if (CheckDowned.polaritiesMod.TryFind("MantellarBar", out ModItem MantellarBar))
                {
                    modOreShop.Add(MantellarBar.Type, Condition.DownedGolem);
                }
                if (CheckDowned.polaritiesMod.TryFind("SunplateBar", out ModItem SunplateBar))
                {
                    modOreShop.Add(SunplateBar.Type, CheckDowned.construct);
                }
            }
            if (CheckDowned.qwertyLoaded)
            {
                if (CheckDowned.qwertyMod.TryFind("LuneOre", out ModItem LuneOre))
                {
                    modOreShop.Add(LuneOre.Type, Condition.DownedEyeOfCthulhu);
                }
                if (CheckDowned.qwertyMod.TryFind("RhuthiniumOre", out ModItem RhuthiniumOre))
                {
                    modOreShop.Add(RhuthiniumOre.Type, Condition.DownedSkeletron);
                }
                if (CheckDowned.qwertyMod.TryFind("CaeliteBar", out ModItem CaeliteBar))
                {
                    modOreShop.Add(CaeliteBar.Type, CheckDowned.divineLight);
                }
                if (CheckDowned.qwertyMod.TryFind("LuneBar", out ModItem LuneBar))
                {
                    modOreShop.Add(LuneBar.Type, Condition.DownedEyeOfCthulhu);
                }
                if (CheckDowned.qwertyMod.TryFind("RhuthiniumBar", out ModItem RhuthiniumBar))
                {
                    modOreShop.Add(RhuthiniumBar.Type, Condition.DownedSkeletron);
                }
            }
            if (CheckDowned.redemptionLoaded)
            {
                if (CheckDowned.redemptionMod.TryFind("CorruptedXenomite", out ModItem CorruptedXenomite))
                {
                    modOreShop.Add(CorruptedXenomite.Type, CheckDowned.cleaver);
                }
                if (CheckDowned.redemptionMod.TryFind("DragonLeadOre", out ModItem DragonLeadOre))
                {
                    modOreShop.Add(DragonLeadOre.Type, Condition.DownedSkeletron);
                }
                if (CheckDowned.redemptionMod.TryFind("GathicCryoCrystal", out ModItem GathicCryoCrystal))
                {
                    modOreShop.Add(GathicCryoCrystal.Type, Condition.DownedSkeletron);
                }
                if (CheckDowned.redemptionMod.TryFind("GraveSteelShards", out ModItem GraveSteelShards))
                {
                    modOreShop.Add(GraveSteelShards.Type);
                }
                if (CheckDowned.redemptionMod.TryFind("Plutonium", out ModItem Plutonium))
                {
                    modOreShop.Add(Plutonium.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.redemptionMod.TryFind("RawXenium", out ModItem RawXenium))
                {
                    modOreShop.Add(RawXenium.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.redemptionMod.TryFind("Uranium", out ModItem Uranium))
                {
                    modOreShop.Add(Uranium.Type, Condition.DownedGolem);
                }
                if (CheckDowned.redemptionMod.TryFind("Xenomite", out ModItem Xenomite))
                {
                    modOreShop.Add(Xenomite.Type, Condition.Hardmode);
                }
                if (CheckDowned.redemptionMod.TryFind("XenomiteShard", out ModItem XenomiteShard))
                {
                    modOreShop.Add(XenomiteShard.Type, CheckDowned.seed);
                }
                if (CheckDowned.redemptionMod.TryFind("GraveSteelAlloy", out ModItem GraveSteelAlloy))
                {
                    modOreShop.Add(GraveSteelAlloy.Type);
                }
                if (CheckDowned.redemptionMod.TryFind("DragonLeadAlloy", out ModItem DragonLeadAlloy))
                {
                    modOreShop.Add(DragonLeadAlloy.Type, Condition.DownedSkeletron);
                }
                if (CheckDowned.redemptionMod.TryFind("MoltenScrap", out ModItem MoltenScrap))
                {
                    modOreShop.Add(MoltenScrap.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.redemptionMod.TryFind("PureIronAlloy", out ModItem PureIronAlloy))
                {
                    modOreShop.Add(PureIronAlloy.Type, Condition.DownedSkeletron);
                }
                if (CheckDowned.redemptionMod.TryFind("XeniumAlloy", out ModItem XeniumAlloy))
                {
                    modOreShop.Add(XeniumAlloy.Type, Condition.DownedMoonLord);
                }
            }
            if (CheckDowned.sotsLoaded)
            {
                if (CheckDowned.sotsMod.TryFind("FrigidIce", out ModItem FrigidIce))
                {
                    modOreShop.Add(FrigidIce.Type);
                }
                if (CheckDowned.sotsMod.TryFind("PhaseOre", out ModItem PhaseOre))
                {
                    modOreShop.Add(PhaseOre.Type, CheckDowned.lux);
                }
                if (CheckDowned.sotsMod.TryFind("VibrantOre", out ModItem VibrantOre))
                {
                    modOreShop.Add(VibrantOre.Type);
                }
                if (CheckDowned.sotsMod.TryFind("AbsoluteBar", out ModItem AbsoluteBar))
                {
                    modOreShop.Add(AbsoluteBar.Type, CheckDowned.polaris);
                }
                if (CheckDowned.sotsMod.TryFind("AncientSteelBar", out ModItem AncientSteelBar))
                {
                    modOreShop.Add(AncientSteelBar.Type, Condition.DownedGoblinArmy);
                }
                if (CheckDowned.sotsMod.TryFind("FrigidBar", out ModItem FrigidBar))
                {
                    modOreShop.Add(FrigidBar.Type);
                }
                if (CheckDowned.sotsMod.TryFind("HardlightAlloy", out ModItem HardlightAlloy))
                {
                    modOreShop.Add(HardlightAlloy.Type, CheckDowned.advisor);
                }
                if (CheckDowned.sotsMod.TryFind("PhaseBar", out ModItem PhaseBar))
                {
                    modOreShop.Add(PhaseBar.Type, CheckDowned.lux);
                }
                if (CheckDowned.sotsMod.TryFind("StarlightAlloy", out ModItem StarlightAlloy))
                {
                    modOreShop.Add(StarlightAlloy.Type, CheckDowned.advisor);
                }
                if (CheckDowned.sotsMod.TryFind("OtherworldlyAlloy", out ModItem OtherworldlyAlloy))
                {
                    modOreShop.Add(OtherworldlyAlloy.Type, CheckDowned.advisor);
                }
                if (CheckDowned.sotsMod.TryFind("VibrantBar", out ModItem VibrantBar))
                {
                    modOreShop.Add(VibrantBar.Type);
                }
            }
            if (CheckDowned.spiritLoaded)
            {
                if (CheckDowned.spiritMod.TryFind("MarbleChunk", out ModItem MarbleChunk))
                {
                    modOreShop.Add(MarbleChunk.Type, Condition.DownedEowOrBoc);
                }
                if (CheckDowned.spiritMod.TryFind("CosmiliteShard", out ModItem CosmiliteShard))
                {
                    modOreShop.Add(CosmiliteShard.Type, CheckDowned.starvoyager);
                }
                if (CheckDowned.spiritMod.TryFind("CryoliteOre", out ModItem CryoliteOre))
                {
                    modOreShop.Add(CryoliteOre.Type, Condition.DownedSkeletron);
                }
                if (CheckDowned.spiritMod.TryFind("GraniteOre", out ModItem GraniteOre))
                {
                    modOreShop.Add(GraniteOre.Type, Condition.DownedEowOrBoc);
                }
                if (CheckDowned.spiritMod.TryFind("FloranOre", out ModItem FloranOre))
                {
                    modOreShop.Add(FloranOre.Type);
                }
                if (CheckDowned.spiritMod.TryFind("SpiritOre", out ModItem SpiritOre))
                {
                    modOreShop.Add(SpiritOre.Type, Condition.DownedMechBossAny);
                }
                if (CheckDowned.spiritMod.TryFind("CryoliteBar", out ModItem CryoliteBar))
                {
                    modOreShop.Add(CryoliteBar.Type, Condition.DownedSkeletron);
                }
                if (CheckDowned.spiritMod.TryFind("FloranBar", out ModItem FloranBar))
                {
                    modOreShop.Add(FloranBar.Type);
                }
                if (CheckDowned.spiritMod.TryFind("SpiritBar", out ModItem SpiritBar))
                {
                    modOreShop.Add(SpiritBar.Type, Condition.DownedMechBossAny);
                }
            }
            //Spooky N/A
            if (CheckDowned.stormLoaded)
            {
                if (CheckDowned.stormMod.TryFind("SpaceRock", out ModItem SpaceRock))
                {
                    modOreShop.Add(SpaceRock.Type, Condition.DownedGolem);
                }
                if (CheckDowned.stormMod.TryFind("DesertOre", out ModItem DesertOre))
                {
                    modOreShop.Add(DesertOre.Type, Condition.Hardmode);
                }
                if (CheckDowned.stormMod.TryFind("IceOre", out ModItem IceOre))
                {
                    modOreShop.Add(IceOre.Type, Condition.Hardmode);
                }
                if (CheckDowned.stormMod.TryFind("SpaceRockBar", out ModItem SpaceRockBar))
                {
                    modOreShop.Add(SpaceRockBar.Type, Condition.DownedGolem);
                }
                if (CheckDowned.stormMod.TryFind("DesertBar", out ModItem DesertBar))
                {
                    modOreShop.Add(DesertBar.Type, Condition.Hardmode);
                }
                if (CheckDowned.stormMod.TryFind("IceBar", out ModItem IceBar))
                {
                    modOreShop.Add(IceBar.Type, Condition.Hardmode);
                }
            }
            //Terrorborn (IF PORTED)
            if (CheckDowned.thoriumLoaded)
            {
                if (CheckDowned.thoriumMod.TryFind("SmoothCoal", out ModItem SmoothCoal))
                {
                    modOreShop.Add(SmoothCoal.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("ThoriumOre", out ModItem ThoriumOre))
                {
                    modOreShop.Add(ThoriumOre.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("LifeQuartz", out ModItem LifeQuartz))
                {
                    modOreShop.Add(LifeQuartz.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("Aquaite", out ModItem Aquaite))
                {
                    modOreShop.Add(Aquaite.Type, Condition.DownedEowOrBoc);
                }
                if (CheckDowned.thoriumMod.TryFind("LodeStoneChunk", out ModItem LodeStoneChunk))
                {
                    modOreShop.Add(LodeStoneChunk.Type, CheckDowned.fallenbeholder);
                }
                if (CheckDowned.thoriumMod.TryFind("ValadiumChunk", out ModItem ValadiumChunk))
                {
                    modOreShop.Add(ValadiumChunk.Type, CheckDowned.fallenbeholder);
                }
                if (CheckDowned.thoriumMod.TryFind("IllumiteChunk", out ModItem IllumiteChunk))
                {
                    modOreShop.Add(IllumiteChunk.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.thoriumMod.TryFind("ThoriumBar", out ModItem ThoriumBar))
                {
                    modOreShop.Add(ThoriumBar.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("SandstoneIngot", out ModItem SandstoneIngot))
                {
                    modOreShop.Add(SandstoneIngot.Type, CheckDowned.grandbird);
                }
                if (CheckDowned.thoriumMod.TryFind("AquaiteBar", out ModItem AquaiteBar))
                {
                    modOreShop.Add(AquaiteBar.Type, Condition.DownedEowOrBoc);
                }
                if (CheckDowned.thoriumMod.TryFind("aDarksteelAlloy", out ModItem aDarksteelAlloy))
                {
                    modOreShop.Add(aDarksteelAlloy.Type, Condition.DownedSkeletron);
                }
                if (CheckDowned.thoriumMod.TryFind("LodeStoneIngot", out ModItem LodeStoneIngot))
                {
                    modOreShop.Add(LodeStoneIngot.Type, CheckDowned.fallenbeholder);
                }
                if (CheckDowned.thoriumMod.TryFind("ValadiumIngot", out ModItem ValadiumIngot))
                {
                    modOreShop.Add(ValadiumIngot.Type, CheckDowned.fallenbeholder);
                }
                if (CheckDowned.thoriumMod.TryFind("TitanicBar", out ModItem TitanicBar))
                {
                    modOreShop.Add(TitanicBar.Type, Condition.DownedMechBossAll);
                }
                if (CheckDowned.thoriumMod.TryFind("IllumiteIngot", out ModItem IllumiteIngot))
                {
                    modOreShop.Add(IllumiteIngot.Type, Condition.DownedPlantera);
                }
            }
            if (CheckDowned.vitalityLoaded)
            {
                if (CheckDowned.vitalityMod.TryFind("ArcticOre", out ModItem ArcticOre))
                {
                    modOreShop.Add(ArcticOre.Type, Condition.DownedMechBossAny);
                }
                if (CheckDowned.vitalityMod.TryFind("GeraniumOre", out ModItem GeraniumOre))
                {
                    modOreShop.Add(GeraniumOre.Type, Condition.DownedSkeletron);
                }
                if (CheckDowned.vitalityMod.TryFind("AnarchyBar", out ModItem AnarchyBar))
                {
                    modOreShop.Add(AnarchyBar.Type, CheckDowned.anarchulesbeetle);
                }
                if (CheckDowned.vitalityMod.TryFind("ArcaneGoldBar", out ModItem ArcaneGoldBar))
                {
                    modOreShop.Add(ArcaneGoldBar.Type, Condition.Hardmode);
                }
                if (CheckDowned.vitalityMod.TryFind("ArcticBar", out ModItem ArcticBar))
                {
                    modOreShop.Add(ArcticBar.Type, Condition.DownedMechBossAny);
                }
                if (CheckDowned.vitalityMod.TryFind("BronzeAlloy", out ModItem BronzeAlloy))
                {
                    modOreShop.Add(BronzeAlloy.Type);
                }
                if (CheckDowned.vitalityMod.TryFind("ChaosBar", out ModItem ChaosBar))
                {
                    modOreShop.Add(ChaosBar.Type, CheckDowned.chaosbringer);
                }
                if (CheckDowned.vitalityMod.TryFind("DriedBar", out ModItem DriedBar))
                {
                    modOreShop.Add(DriedBar.Type, CheckDowned.grandantlion);
                }
                if (CheckDowned.vitalityMod.TryFind("GeraniumBar", out ModItem GeraniumBar))
                {
                    modOreShop.Add(GeraniumBar.Type, Condition.DownedSkeletron);
                }
                if (CheckDowned.vitalityMod.TryFind("GlowingGraniteBar", out ModItem GlowingGraniteBar))
                {
                    modOreShop.Add(GlowingGraniteBar.Type);
                }
                if (CheckDowned.vitalityMod.TryFind("SteelAlloy", out ModItem SteelAlloy))
                {
                    modOreShop.Add(SteelAlloy.Type);
                }
                if (CheckDowned.vitalityMod.TryFind("PurifiedBar", out ModItem PurifiedBar))
                {
                    modOreShop.Add(PurifiedBar.Type);
                }
            }
            modOreShop.Register();

            var modNaturalBlocksShop = new NPCShop(Type, "Modded Natural Blocks");
            if (CheckDowned.aqLoaded)
            {
                if (CheckDowned.aqMod.TryFind("SedimentaryRockItem", out ModItem SedimentaryRockItem))
                {
                    modNaturalBlocksShop.Add(SedimentaryRockItem.Type);
                }
            }
            if (CheckDowned.calamityLoaded)
            {
                if (CheckDowned.calamityMod.TryFind("AbyssGravel", out ModItem AbyssGravel))
                {
                    modNaturalBlocksShop.Add(AbyssGravel.Type);
                }
                if (CheckDowned.calamityMod.TryFind("Acidwood", out ModItem Acidwood))
                {
                    modNaturalBlocksShop.Add(Acidwood.Type);
                }
                if (CheckDowned.calamityMod.TryFind("AstralClay", out ModItem AstralClay))
                {
                    modNaturalBlocksShop.Add(AstralClay.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("AstralDirt", out ModItem AstralDirt))
                {
                    modNaturalBlocksShop.Add(AstralDirt.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("AstralIce", out ModItem AstralIce))
                {
                    modNaturalBlocksShop.Add(AstralIce.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("AstralMonolith", out ModItem AstralMonolith))
                {
                    modNaturalBlocksShop.Add(AstralMonolith.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("AstralSand", out ModItem AstralSand))
                {
                    modNaturalBlocksShop.Add(AstralSand.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("AstralSandstone", out ModItem AstralSandstone))
                {
                    modNaturalBlocksShop.Add(AstralSandstone.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("AstralSnow", out ModItem AstralSnow))
                {
                    modNaturalBlocksShop.Add(AstralSnow.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("AstralStone", out ModItem AstralStone))
                {
                    modNaturalBlocksShop.Add(AstralStone.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("BrimstoneSlag", out ModItem BrimstoneSlag))
                {
                    modNaturalBlocksShop.Add(BrimstoneSlag.Type);
                }
                if (CheckDowned.calamityMod.TryFind("CelestialRemains", out ModItem CelestialRemains))
                {
                    modNaturalBlocksShop.Add(CelestialRemains.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("EutrophicSand", out ModItem EutrophicSand))
                {
                    modNaturalBlocksShop.Add(EutrophicSand.Type);
                }
                if (CheckDowned.calamityMod.TryFind("HardenedAstralSand", out ModItem HardenedAstralSand))
                {
                    modNaturalBlocksShop.Add(HardenedAstralSand.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("HardenedSulphurousSandstone", out ModItem HardenedSulphurousSandstone))
                {
                    modNaturalBlocksShop.Add(HardenedSulphurousSandstone.Type);
                }
                if (CheckDowned.calamityMod.TryFind("PyreMantleMolten", out ModItem PyreMantleMolten))
                {
                    modNaturalBlocksShop.Add(PyreMantleMolten.Type, Condition.DownedMechBossAll);
                }
                if (CheckDowned.calamityMod.TryFind("Navystone", out ModItem Navystone))
                {
                    modNaturalBlocksShop.Add(Navystone.Type);
                }
                if (CheckDowned.calamityMod.TryFind("NovaeSlag", out ModItem NovaeSlag))
                {
                    modNaturalBlocksShop.Add(NovaeSlag.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("PlantyMush", out ModItem PlantyMush))
                {
                    modNaturalBlocksShop.Add(PlantyMush.Type);
                }
                if (CheckDowned.calamityMod.TryFind("PyreMantle", out ModItem PyreMantle))
                {
                    modNaturalBlocksShop.Add(PyreMantle.Type, Condition.DownedMechBossAll);
                }
                if (CheckDowned.calamityMod.TryFind("ScorchedBone", out ModItem ScorchedBone))
                {
                    modNaturalBlocksShop.Add(ScorchedBone.Type);
                }
                if (CheckDowned.calamityMod.TryFind("ScorchedRemains", out ModItem ScorchedRemains))
                {
                    modNaturalBlocksShop.Add(ScorchedRemains.Type);
                }
                if (CheckDowned.calamityMod.TryFind("SulphurousSand", out ModItem SulphurousSand))
                {
                    modNaturalBlocksShop.Add(SulphurousSand.Type);
                }
                if (CheckDowned.calamityMod.TryFind("SulphurousSandstone", out ModItem SulphurousSandstone))
                {
                    modNaturalBlocksShop.Add(SulphurousSandstone.Type);
                }
                if (CheckDowned.calamityMod.TryFind("SulphurousShale", out ModItem SulphurousShale))
                {
                    modNaturalBlocksShop.Add(SulphurousShale.Type);
                }
                if (CheckDowned.calamityMod.TryFind("VernalSoil", out ModItem VernalSoil))
                {
                    modNaturalBlocksShop.Add(VernalSoil.Type);
                }
                if (CheckDowned.calamityMod.TryFind("Voidstone", out ModItem Voidstone))
                {
                    modNaturalBlocksShop.Add(Voidstone.Type, Condition.DownedMechBossAll);
                }
            }
            //Catalyst N/A
            //Consolaria N/A
            //Echoes N/A
            //Fargos N/A
            //Gerds N/A
            if (CheckDowned.homewardLoaded)
            {
                if (CheckDowned.homewardMod.TryFind("AbyssStone", out ModItem AbyssStone))
                {
                    modNaturalBlocksShop.Add(AbyssStone.Type, Condition.DownedMechBossAll);
                }
            }
            //Infernum N/A
            if (CheckDowned.polaritiesLoaded)
            {
                if (CheckDowned.polaritiesMod.TryFind("Limestone", out ModItem Limestone))
                {
                    modNaturalBlocksShop.Add(Limestone.Type);
                }
                if (CheckDowned.polaritiesMod.TryFind("RockSalt", out ModItem RockSalt))
                {
                    modNaturalBlocksShop.Add(RockSalt.Type);
                }
                if (CheckDowned.polaritiesMod.TryFind("Salt", out ModItem Salt))
                {
                    modNaturalBlocksShop.Add(Salt.Type);
                }
            }
            //Qwerty N/A
            if (CheckDowned.redemptionLoaded)
            {
                if (CheckDowned.redemptionMod.TryFind("AncientDirt", out ModItem AncientDirt))
                {
                    modNaturalBlocksShop.Add(AncientDirt.Type);
                }
                if (CheckDowned.redemptionMod.TryFind("Asteroid", out ModItem Asteroid))
                {
                    modNaturalBlocksShop.Add(Asteroid.Type);
                }
                if (CheckDowned.redemptionMod.TryFind("ElderWood", out ModItem ElderWood))
                {
                    modNaturalBlocksShop.Add(ElderWood.Type);
                }
                if (CheckDowned.redemptionMod.TryFind("GathicColdstone", out ModItem GathicColdstone))
                {
                    modNaturalBlocksShop.Add(GathicColdstone.Type);
                }
                if (CheckDowned.redemptionMod.TryFind("GathicFroststone", out ModItem GathicFroststone))
                {
                    modNaturalBlocksShop.Add(GathicFroststone.Type);
                }
                if (CheckDowned.redemptionMod.TryFind("GathicGladestone", out ModItem GathicGladestone))
                {
                    modNaturalBlocksShop.Add(GathicGladestone.Type);
                }
                if (CheckDowned.redemptionMod.TryFind("GathicStone", out ModItem GathicStone))
                {
                    modNaturalBlocksShop.Add(GathicStone.Type);
                }
                if (CheckDowned.redemptionMod.TryFind("GloomMushroom", out ModItem GloomMushroom))
                {
                    modNaturalBlocksShop.Add(GloomMushroom.Type);
                }
                if (CheckDowned.redemptionMod.TryFind("IrradiatedClay", out ModItem IrradiatedClay))
                {
                    modNaturalBlocksShop.Add(IrradiatedClay.Type, Condition.Hardmode);
                }
                if (CheckDowned.redemptionMod.TryFind("IrradiatedCrimstone", out ModItem IrradiatedCrimstone))
                {
                    modNaturalBlocksShop.Add(IrradiatedCrimstone.Type, Condition.Hardmode);
                }
                if (CheckDowned.redemptionMod.TryFind("IrradiatedDirt", out ModItem IrradiatedDirt))
                {
                    modNaturalBlocksShop.Add(IrradiatedDirt.Type, Condition.Hardmode);
                }
                if (CheckDowned.redemptionMod.TryFind("IrradiatedEbonstone", out ModItem IrradiatedEbonstone))
                {
                    modNaturalBlocksShop.Add(IrradiatedEbonstone.Type, Condition.Hardmode);
                }
                if (CheckDowned.redemptionMod.TryFind("IrradiatedHardenedSand", out ModItem IrradiatedHardenedSand))
                {
                    modNaturalBlocksShop.Add(IrradiatedHardenedSand.Type, Condition.Hardmode);
                }
                if (CheckDowned.redemptionMod.TryFind("IrradiatedIce", out ModItem IrradiatedIce))
                {
                    modNaturalBlocksShop.Add(IrradiatedIce.Type, Condition.Hardmode);
                }
                if (CheckDowned.redemptionMod.TryFind("IrradiatedSand", out ModItem IrradiatedSand))
                {
                    modNaturalBlocksShop.Add(IrradiatedSand.Type, Condition.Hardmode);
                }
                if (CheckDowned.redemptionMod.TryFind("IrradiatedSandstone", out ModItem IrradiatedSandstone))
                {
                    modNaturalBlocksShop.Add(IrradiatedSandstone.Type, Condition.Hardmode);
                }
                if (CheckDowned.redemptionMod.TryFind("IrradiatedSnow", out ModItem IrradiatedSnow))
                {
                    modNaturalBlocksShop.Add(IrradiatedSnow.Type, Condition.Hardmode);
                }
                if (CheckDowned.redemptionMod.TryFind("IrradiatedStone", out ModItem IrradiatedStone))
                {
                    modNaturalBlocksShop.Add(IrradiatedStone.Type, Condition.Hardmode);
                }
                if (CheckDowned.redemptionMod.TryFind("PetrifiedWood", out ModItem PetrifiedWood))
                {
                    modNaturalBlocksShop.Add(PetrifiedWood.Type, Condition.Hardmode);
                }
                if (CheckDowned.redemptionMod.TryFind("PlantMatter", out ModItem PlantMatter))
                {
                    modNaturalBlocksShop.Add(PlantMatter.Type);
                }
            }
            if (CheckDowned.sotsLoaded)
            {
                if (CheckDowned.sotsMod.TryFind("CharredWood", out ModItem CharredWood))
                {
                    modNaturalBlocksShop.Add(CharredWood.Type);
                }
                if (CheckDowned.sotsMod.TryFind("CursedTumor", out ModItem CursedTumor))
                {
                    modNaturalBlocksShop.Add(CursedTumor.Type, CheckDowned.pharaohscurse);
                }
                if (CheckDowned.sotsMod.TryFind("Evostone", out ModItem Evostone))
                {
                    modNaturalBlocksShop.Add(Evostone.Type);
                }
                if (CheckDowned.sotsMod.TryFind("Wormwood", out ModItem Wormwood))
                {
                    modNaturalBlocksShop.Add(Wormwood.Type, Condition.DownedKingSlime);
                }
                if (CheckDowned.sotsMod.TryFind("SootBlock", out ModItem SootBlock))
                {
                    modNaturalBlocksShop.Add(SootBlock.Type);
                }
            }
            if (CheckDowned.spiritLoaded)
            {
                if (CheckDowned.spiritMod.TryFind("AsteroidBlock", out ModItem AsteroidBlock))
                {
                    modNaturalBlocksShop.Add(AsteroidBlock.Type);
                }
                if (CheckDowned.spiritMod.TryFind("Black_Stone_Item", out ModItem Black_Stone_Item))
                {
                    modNaturalBlocksShop.Add(Black_Stone_Item.Type);
                }
                if (CheckDowned.spiritMod.TryFind("BlastStoneItem", out ModItem BlastStoneItem))
                {
                    modNaturalBlocksShop.Add(BlastStoneItem.Type);
                }
                if (CheckDowned.spiritMod.TryFind("CreepingIce", out ModItem CreepingIce))
                {
                    modNaturalBlocksShop.Add(CreepingIce.Type);
                }
                if (CheckDowned.spiritMod.TryFind("DriftwoodTileItem", out ModItem DriftwoodTileItem))
                {
                    modNaturalBlocksShop.Add(DriftwoodTileItem.Type);
                }
                if (CheckDowned.spiritMod.TryFind("SpiritStoneItem", out ModItem SpiritStoneItem))
                {
                    modNaturalBlocksShop.Add(SpiritStoneItem.Type, Condition.DownedMechBossAny);
                }
                if (CheckDowned.spiritMod.TryFind("SpiritWoodItem", out ModItem SpiritWoodItem))
                {
                    modNaturalBlocksShop.Add(SpiritWoodItem.Type, Condition.DownedMechBossAny);
                }
                if (CheckDowned.spiritMod.TryFind("AncientBark", out ModItem AncientBark))
                {
                    modNaturalBlocksShop.Add(AncientBark.Type);
                }
                if (CheckDowned.spiritMod.TryFind("ScrapItem", out ModItem ScrapItem))
                {
                    modNaturalBlocksShop.Add(ScrapItem.Type);
                }
                if (CheckDowned.spiritMod.TryFind("SpaceJunkItem", out ModItem SpaceJunkItem))
                {
                    modNaturalBlocksShop.Add(SpaceJunkItem.Type);
                }
                if (CheckDowned.spiritMod.TryFind("SpiritDirtItem", out ModItem SpiritDirtItem))
                {
                    modNaturalBlocksShop.Add(SpiritDirtItem.Type, Condition.DownedMechBossAny);
                }
                if (CheckDowned.spiritMod.TryFind("SpiritIceItem", out ModItem SpiritIceItem))
                {
                    modNaturalBlocksShop.Add(SpiritIceItem.Type, Condition.DownedMechBossAny);
                }
                if (CheckDowned.spiritMod.TryFind("SpiritSandItem", out ModItem SpiritSandItem))
                {
                    modNaturalBlocksShop.Add(SpiritSandItem.Type, Condition.DownedMechBossAny);
                }
            }
            if (CheckDowned.spookyLoaded)
            {
                if (CheckDowned.spookyMod.TryFind("EyeBlockItem", out ModItem EyeBlockItem))
                {
                    modNaturalBlocksShop.Add(EyeBlockItem.Type);
                }
                if (CheckDowned.spookyMod.TryFind("LivingFleshItem", out ModItem LivingFleshItem))
                {
                    modNaturalBlocksShop.Add(LivingFleshItem.Type);
                }
                if (CheckDowned.spookyMod.TryFind("CemeteryDirtItem", out ModItem CemeteryDirtItem))
                {
                    modNaturalBlocksShop.Add(CemeteryDirtItem.Type);
                }
                if (CheckDowned.spookyMod.TryFind("SpookyStoneItem", out ModItem SpookyStoneItem))
                {
                    modNaturalBlocksShop.Add(SpookyStoneItem.Type);
                }
                if (CheckDowned.spookyMod.TryFind("SpookyWoodItem", out ModItem SpookyWoodItem))
                {
                    modNaturalBlocksShop.Add(SpookyWoodItem.Type);
                }
                if (CheckDowned.spookyMod.TryFind("SpookyMushItem", out ModItem SpookyMushItem))
                {
                    modNaturalBlocksShop.Add(SpookyMushItem.Type);
                }
                if (CheckDowned.spookyMod.TryFind("CemeteryStoneItem", out ModItem CemeteryStoneItem))
                {
                    modNaturalBlocksShop.Add(CemeteryStoneItem.Type);
                }
                if (CheckDowned.spookyMod.TryFind("SpookyDirtItem", out ModItem SpookyDirtItem))
                {
                    modNaturalBlocksShop.Add(SpookyDirtItem.Type);
                }
                if (CheckDowned.spookyMod.TryFind("ValleyStoneItem", out ModItem ValleyStoneItem))
                {
                    modNaturalBlocksShop.Add(ValleyStoneItem.Type);
                }
            }
            //Storms N/A
            //Terrorborn (IF PORTED)
            if (CheckDowned.thoriumLoaded)
            {
                if (CheckDowned.thoriumMod.TryFind("BrackishClump", out ModItem BrackishClump))
                {
                    modNaturalBlocksShop.Add(BrackishClump.Type, CheckDowned.queenjelly);
                }
                if (CheckDowned.thoriumMod.TryFind("EvergreenBlock", out ModItem EvergreenBlock))
                {
                    modNaturalBlocksShop.Add(EvergreenBlock.Type, Condition.DownedEverscream, Condition.DownedSantaNK1, Condition.DownedIceQueen);
                }
                if (CheckDowned.thoriumMod.TryFind("GingerbreadBlock", out ModItem GingerbreadBlock))
                {
                    modNaturalBlocksShop.Add(GingerbreadBlock.Type, Condition.DownedEverscream, Condition.DownedSantaNK1, Condition.DownedIceQueen);
                }
                if (CheckDowned.thoriumMod.TryFind("MarineBlock", out ModItem MarineBlock))
                {
                    modNaturalBlocksShop.Add(MarineBlock.Type, CheckDowned.queenjelly);
                }
                if (CheckDowned.thoriumMod.TryFind("MossyMarineBlock", out ModItem MossyMarineBlock))
                {
                    modNaturalBlocksShop.Add(MossyMarineBlock.Type, CheckDowned.queenjelly);
                }
                if (CheckDowned.thoriumMod.TryFind("Permafrost", out ModItem Permafrost))
                {
                    modNaturalBlocksShop.Add(Permafrost.Type, Condition.DownedEverscream, Condition.DownedSantaNK1, Condition.DownedIceQueen);
                }
                if (CheckDowned.thoriumMod.TryFind("SugarCookieBlock", out ModItem SugarCookieBlock))
                {
                    modNaturalBlocksShop.Add(SugarCookieBlock.Type, Condition.DownedEverscream, Condition.DownedSantaNK1, Condition.DownedIceQueen);
                }
                if (CheckDowned.thoriumMod.TryFind("YewWood", out ModItem YewWood))
                {
                    modNaturalBlocksShop.Add(YewWood.Type, Condition.DownedGoblinArmy);
                }
            }
            //Vitality N/A
            modNaturalBlocksShop.Register();

            var modBuildingBlocksShop = new NPCShop(Type, "Modded Building Blocks");
            //Aequus N/A
            if (CheckDowned.calamityLoaded)
            {
                if (CheckDowned.calamityMod.TryFind("AerialiteBrick", out ModItem AerialiteBrick))
                {
                    modBuildingBlocksShop.Add(AerialiteBrick.Type, CheckDowned.perfOrHive);
                }
                if (CheckDowned.calamityMod.TryFind("AshenAccentSlab", out ModItem AshenAccentSlab))
                {
                    modBuildingBlocksShop.Add(AshenAccentSlab.Type, CheckDowned.brimstoneelemental);
                }
                if (CheckDowned.calamityMod.TryFind("AshenSlab", out ModItem AshenSlab))
                {
                    modBuildingBlocksShop.Add(AshenSlab.Type, CheckDowned.brimstoneelemental);
                }
                if (CheckDowned.calamityMod.TryFind("AstralBrick", out ModItem AstralBrick))
                {
                    modBuildingBlocksShop.Add(AstralBrick.Type, CheckDowned.deus);
                }
                if (CheckDowned.calamityMod.TryFind("BrimstoneSlab", out ModItem BrimstoneSlab))
                {
                    modBuildingBlocksShop.Add(BrimstoneSlab.Type);
                }
                if (CheckDowned.calamityMod.TryFind("Cinderplate", out ModItem Cinderplate))
                {
                    modBuildingBlocksShop.Add(Cinderplate.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("CosmiliteBrick", out ModItem CosmiliteBrick))
                {
                    modBuildingBlocksShop.Add(CosmiliteBrick.Type, CheckDowned.dog);
                }
                if (CheckDowned.calamityMod.TryFind("CryonicBrick", out ModItem CryonicBrick))
                {
                    modBuildingBlocksShop.Add(CryonicBrick.Type, CheckDowned.cryogen);
                }
                if (CheckDowned.calamityMod.TryFind("Elumplate", out ModItem Elumplate))
                {
                    modBuildingBlocksShop.Add(Elumplate.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("EutrophicGlass", out ModItem EutrophicGlass))
                {
                    modBuildingBlocksShop.Add(EutrophicGlass.Type);
                }
                if (CheckDowned.calamityMod.TryFind("ExoPlating", out ModItem ExoPlating))
                {
                    modBuildingBlocksShop.Add(ExoPlating.Type, CheckDowned.exomechs);
                }
                if (CheckDowned.calamityMod.TryFind("ExoPrismPanel", out ModItem ExoPrismPanel))
                {
                    modBuildingBlocksShop.Add(ExoPrismPanel.Type, CheckDowned.exomechs);
                }
                if (CheckDowned.calamityMod.TryFind("Havocplate", out ModItem Havocplate))
                {
                    modBuildingBlocksShop.Add(Havocplate.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("HazardChevronPanels", out ModItem HazardChevronPanels))
                {
                    modBuildingBlocksShop.Add(HazardChevronPanels.Type);
                }
                if (CheckDowned.calamityMod.TryFind("LaboratoryPanels", out ModItem LaboratoryPanels))
                {
                    modBuildingBlocksShop.Add(LaboratoryPanels.Type);
                }
                if (CheckDowned.calamityMod.TryFind("LaboratoryPipePlating", out ModItem LaboratoryPipePlating))
                {
                    modBuildingBlocksShop.Add(LaboratoryPipePlating.Type);
                }
                if (CheckDowned.calamityMod.TryFind("LaboratoryPlating", out ModItem LaboratoryPlating))
                {
                    modBuildingBlocksShop.Add(LaboratoryPlating.Type);
                }
                if (CheckDowned.calamityMod.TryFind("Navyplate", out ModItem Navyplate))
                {
                    modBuildingBlocksShop.Add(Navyplate.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("OccultBrickItem", out ModItem OccultBrickItem))
                {
                    modBuildingBlocksShop.Add(OccultBrickItem.Type, CheckDowned.scalamitas);
                }
                if (CheckDowned.calamityMod.TryFind("Onyxplate", out ModItem Onyxplate))
                {
                    modBuildingBlocksShop.Add(Onyxplate.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("OtherworldlyStone", out ModItem OtherworldlyStone))
                {
                    modBuildingBlocksShop.Add(OtherworldlyStone.Type, CheckDowned.ceaselessvoid, CheckDowned.stormweaver, CheckDowned.signus);
                }
                if (CheckDowned.calamityMod.TryFind("PerennialBrick", out ModItem PerennialBrick))
                {
                    modBuildingBlocksShop.Add(PerennialBrick.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.calamityMod.TryFind("PlaguedContainmentBrick", out ModItem PlaguedContainmentBrick))
                {
                    modBuildingBlocksShop.Add(PlaguedContainmentBrick.Type, CheckDowned.plaguebringer);
                }
                if (CheckDowned.calamityMod.TryFind("Plagueplate", out ModItem Plagueplate))
                {
                    modBuildingBlocksShop.Add(Plagueplate.Type, CheckDowned.plaguebringer);
                }
                if (CheckDowned.calamityMod.TryFind("ProfanedCrystal", out ModItem ProfanedCrystal))
                {
                    modBuildingBlocksShop.Add(ProfanedCrystal.Type, CheckDowned.providence);
                }
                if (CheckDowned.calamityMod.TryFind("ProfanedRock", out ModItem ProfanedRock))
                {
                    modBuildingBlocksShop.Add(ProfanedRock.Type, CheckDowned.providence);
                }
                if (CheckDowned.calamityMod.TryFind("ProfanedSlab", out ModItem ProfanedSlab))
                {
                    modBuildingBlocksShop.Add(ProfanedSlab.Type, CheckDowned.providence);
                }
                if (CheckDowned.calamityMod.TryFind("RunicProfanedBrick", out ModItem RunicProfanedBrick))
                {
                    modBuildingBlocksShop.Add(RunicProfanedBrick.Type, CheckDowned.providence);
                }
                if (CheckDowned.calamityMod.TryFind("RustedPipes", out ModItem RustedPipes))
                {
                    modBuildingBlocksShop.Add(RustedPipes.Type);
                }
                if (CheckDowned.calamityMod.TryFind("RustedPlating", out ModItem RustedPlating))
                {
                    modBuildingBlocksShop.Add(RustedPlating.Type);
                }
                if (CheckDowned.calamityMod.TryFind("SeaPrismBrick", out ModItem SeaPrismBrick))
                {
                    modBuildingBlocksShop.Add(SeaPrismBrick.Type);
                }
                if (CheckDowned.calamityMod.TryFind("ScoriaBrick", out ModItem ScoriaBrick))
                {
                    modBuildingBlocksShop.Add(ScoriaBrick.Type, Condition.DownedGolem);
                }
                if (CheckDowned.calamityMod.TryFind("SilvaCrystal", out ModItem SilvaCrystal))
                {
                    modBuildingBlocksShop.Add(SilvaCrystal.Type, CheckDowned.dragonfolly);
                }
                if (CheckDowned.calamityMod.TryFind("SmoothAbyssGravel", out ModItem SmoothAbyssGravel))
                {
                    modBuildingBlocksShop.Add(SmoothAbyssGravel.Type);
                }
                if (CheckDowned.calamityMod.TryFind("SmoothBrimstoneSlag", out ModItem SmoothBrimstoneSlag))
                {
                    modBuildingBlocksShop.Add(SmoothBrimstoneSlag.Type);
                }
                if (CheckDowned.calamityMod.TryFind("SmoothVoidstone", out ModItem SmoothVoidstone))
                {
                    modBuildingBlocksShop.Add(SmoothVoidstone.Type, Condition.DownedMechBossAll);
                }
                if (CheckDowned.calamityMod.TryFind("StatigelBlock", out ModItem StatigelBlock))
                {
                    modBuildingBlocksShop.Add(StatigelBlock.Type, CheckDowned.slimegod);
                }
                if (CheckDowned.calamityMod.TryFind("StratusBricks", out ModItem StratusBricks))
                {
                    modBuildingBlocksShop.Add(StratusBricks.Type, CheckDowned.polterghast);
                }
                if (CheckDowned.calamityMod.TryFind("UelibloomBrick", out ModItem UelibloomBrick))
                {
                    modBuildingBlocksShop.Add(UelibloomBrick.Type, CheckDowned.providence);
                }
                if (CheckDowned.calamityMod.TryFind("VoidstoneSlab", out ModItem VoidstoneSlab))
                {
                    modBuildingBlocksShop.Add(VoidstoneSlab.Type, Condition.DownedMechBossAll);
                }
                if (CheckDowned.calamityMod.TryFind("WulfrumPlating", out ModItem WulfrumPlating))
                {
                    modBuildingBlocksShop.Add(WulfrumPlating.Type);
                }
            }
            if (CheckDowned.catalystLoaded)
            {
                if (CheckDowned.catalystMod.TryFind("Astrogel", out ModItem Astrogel))
                {
                    modBuildingBlocksShop.Add(Astrogel.Type, CheckDowned.geldon);
                }
                if (CheckDowned.catalystMod.TryFind("MetanovaBrick", out ModItem MetanovaBrick))
                {
                    modBuildingBlocksShop.Add(MetanovaBrick.Type, CheckDowned.geldon);
                }
            }
            //Consolaria N/A
            //Echoes N/A
            //Fargos N/A
            //Gerds N/A
            if (CheckDowned.homewardLoaded)
            {
                if (CheckDowned.homewardMod.TryFind("AbyssBrick", out ModItem AbyssBrick))
                {
                    modBuildingBlocksShop.Add(AbyssBrick.Type, Condition.DownedMechBossAll);
                }
            }
            //Infernum N/A
            if (CheckDowned.polaritiesLoaded)
            {
                if (CheckDowned.polaritiesMod.TryFind("GlowingLimestoneBrick", out ModItem GlowingLimestoneBrick))
                {
                    modBuildingBlocksShop.Add(GlowingLimestoneBrick.Type);
                }
                if (CheckDowned.polaritiesMod.TryFind("HaliteBrick", out ModItem HaliteBrick))
                {
                    modBuildingBlocksShop.Add(HaliteBrick.Type);
                }
                if (CheckDowned.polaritiesMod.TryFind("LimestoneBrick", out ModItem LimestoneBrick))
                {
                    modBuildingBlocksShop.Add(LimestoneBrick.Type);
                }
                if (CheckDowned.polaritiesMod.TryFind("SaltBrick", out ModItem SaltBrick))
                {
                    modBuildingBlocksShop.Add(SaltBrick.Type);
                }
            }
            if (CheckDowned.qwertyLoaded)
            {
                if (CheckDowned.qwertyMod.TryFind("ChiselledFortressBrick", out ModItem ChiselledFortressBrick))
                {
                    modBuildingBlocksShop.Add(ChiselledFortressBrick.Type);
                }
                if (CheckDowned.qwertyMod.TryFind("ReverseSand", out ModItem ReverseSand))
                {
                    modBuildingBlocksShop.Add(ReverseSand.Type);
                }
                if (CheckDowned.qwertyMod.TryFind("DnasBrick", out ModItem DnasBrick))
                {
                    modBuildingBlocksShop.Add(DnasBrick.Type);
                }
                if (CheckDowned.qwertyMod.TryFind("FakeFortressBrick", out ModItem FakeFortressBrick))
                {
                    modBuildingBlocksShop.Add(FakeFortressBrick.Type);
                }
                if (CheckDowned.qwertyMod.TryFind("FortressBrick", out ModItem FortressBrick))
                {
                    modBuildingBlocksShop.Add(FortressBrick.Type);
                }
                if (CheckDowned.qwertyMod.TryFind("FortressPillar", out ModItem FortressPillar))
                {
                    modBuildingBlocksShop.Add(FortressPillar.Type);
                }
            }
            if (CheckDowned.redemptionLoaded)
            {
                if (CheckDowned.redemptionMod.TryFind("GathicColdstoneBrick", out ModItem GathicColdstoneBrick))
                {
                    modBuildingBlocksShop.Add(GathicColdstoneBrick.Type);
                }
                if (CheckDowned.redemptionMod.TryFind("GathicFroststoneBrick", out ModItem GathicFroststoneBrick))
                {
                    modBuildingBlocksShop.Add(GathicFroststoneBrick.Type);
                }
                if (CheckDowned.redemptionMod.TryFind("GathicGladestoneBrick", out ModItem GathicGladestoneBrick))
                {
                    modBuildingBlocksShop.Add(GathicGladestoneBrick.Type);
                }
                if (CheckDowned.redemptionMod.TryFind("GathicStoneBrick", out ModItem GathicStoneBrick))
                {
                    modBuildingBlocksShop.Add(GathicStoneBrick.Type);
                }
                if (CheckDowned.redemptionMod.TryFind("LabPlating", out ModItem LabPlating))
                {
                    modBuildingBlocksShop.Add(LabPlating.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.redemptionMod.TryFind("MetalSupportBeam", out ModItem MetalSupportBeam))
                {
                    modBuildingBlocksShop.Add(MetalSupportBeam.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.redemptionMod.TryFind("NiricPipe", out ModItem NiricPipe))
                {
                    modBuildingBlocksShop.Add(NiricPipe.Type, Condition.DownedGolem);
                }
            }
            if (CheckDowned.sotsLoaded)
            {
                if (CheckDowned.sotsMod.TryFind("RoyalGoldBrick", out ModItem RoyalGoldBrick))
                {
                    modBuildingBlocksShop.Add(RoyalGoldBrick.Type, CheckDowned.pharaohscurse);
                }
                if (CheckDowned.sotsMod.TryFind("DissolvingAuroraBlock", out ModItem DissolvingAuroraBlock))
                {
                    modBuildingBlocksShop.Add(DissolvingAuroraBlock.Type, CheckDowned.permafrostSpirit);
                }
                if (CheckDowned.sotsMod.TryFind("AvaritianPlating", out ModItem AvaritianPlating))
                {
                    modBuildingBlocksShop.Add(AvaritianPlating.Type, CheckDowned.otherworldlyConstruct);
                }
                if (CheckDowned.sotsMod.TryFind("DissolvingBrillianceBlock", out ModItem DissolvingBrillianceBlock))
                {
                    modBuildingBlocksShop.Add(DissolvingBrillianceBlock.Type, CheckDowned.lux);
                }
                if (CheckDowned.sotsMod.TryFind("ChaosPlating", out ModItem ChaosPlating))
                {
                    modBuildingBlocksShop.Add(ChaosPlating.Type, CheckDowned.chaosConstruct);
                }
                if (CheckDowned.sotsMod.TryFind("DarkShingles", out ModItem DarkShingles))
                {
                    modBuildingBlocksShop.Add(DarkShingles.Type);
                }
                if (CheckDowned.sotsMod.TryFind("DissolvingDelugeBlock", out ModItem DissolvingDelugeBlock))
                {
                    modBuildingBlocksShop.Add(DissolvingDelugeBlock.Type, CheckDowned.tidalSpirit);
                }
                if (CheckDowned.sotsMod.TryFind("DullPlating", out ModItem DullPlating))
                {
                    modBuildingBlocksShop.Add(DullPlating.Type, CheckDowned.otherworldlyConstruct);
                }
                if (CheckDowned.sotsMod.TryFind("DissolvingEarthBlock", out ModItem DissolvingEarthBlock))
                {
                    modBuildingBlocksShop.Add(DissolvingEarthBlock.Type, CheckDowned.earthenSpirit);
                }
                if (CheckDowned.sotsMod.TryFind("EarthenPlating", out ModItem EarthenPlating))
                {
                    modBuildingBlocksShop.Add(EarthenPlating.Type, CheckDowned.earthenConstruct);
                }
                if (CheckDowned.sotsMod.TryFind("EvilPlating", out ModItem EvilPlating))
                {
                    modBuildingBlocksShop.Add(EvilPlating.Type, CheckDowned.evilConstruct);
                }
                if (CheckDowned.sotsMod.TryFind("EvostoneBrick", out ModItem EvostoneBrick))
                {
                    modBuildingBlocksShop.Add(EvostoneBrick.Type);
                }
                if (CheckDowned.sotsMod.TryFind("FrigidBrick", out ModItem FrigidBrick))
                {
                    modBuildingBlocksShop.Add(FrigidBrick.Type);
                }
                if (CheckDowned.sotsMod.TryFind("HardIceBrick", out ModItem HardIceBrick))
                {
                    modBuildingBlocksShop.Add(HardIceBrick.Type, CheckDowned.polaris);
                }
                if (CheckDowned.sotsMod.TryFind("HardlightBlock", out ModItem HardlightBlock))
                {
                    modBuildingBlocksShop.Add(HardlightBlock.Type, CheckDowned.otherworldlyConstruct);
                }
                if (CheckDowned.sotsMod.TryFind("InfernoPlating", out ModItem InfernoPlating))
                {
                    modBuildingBlocksShop.Add(InfernoPlating.Type, CheckDowned.infernoConstruct);
                }
                if (CheckDowned.sotsMod.TryFind("DissolvingNatureBlock", out ModItem DissolvingNatureBlock))
                {
                    modBuildingBlocksShop.Add(DissolvingNatureBlock.Type, CheckDowned.natureSpirit);
                }
                if (CheckDowned.sotsMod.TryFind("NaturePlating", out ModItem NaturePlating))
                {
                    modBuildingBlocksShop.Add(NaturePlating.Type, CheckDowned.natureConstruct);
                }
                if (CheckDowned.sotsMod.TryFind("DissolvingNetherBlock", out ModItem DissolvingNetherBlock))
                {
                    modBuildingBlocksShop.Add(DissolvingNetherBlock.Type, CheckDowned.infernoSpirit);
                }
                if (CheckDowned.sotsMod.TryFind("OvergrownPyramidBlock", out ModItem OvergrownPyramidBlock))
                {
                    modBuildingBlocksShop.Add(OvergrownPyramidBlock.Type, Condition.DownedMechBossAll);
                }
                if (CheckDowned.sotsMod.TryFind("PermafrostPlating", out ModItem PermafrostPlating))
                {
                    modBuildingBlocksShop.Add(PermafrostPlating.Type, CheckDowned.permafrostConstruct);
                }
                if (CheckDowned.sotsMod.TryFind("DissolvingAetherBlock", out ModItem DissolvingAetherBlock))
                {
                    modBuildingBlocksShop.Add(DissolvingAetherBlock.Type, CheckDowned.advisor);
                }
                if (CheckDowned.sotsMod.TryFind("PyramidBrick", out ModItem PyramidBrick))
                {
                    modBuildingBlocksShop.Add(PyramidBrick.Type, CheckDowned.pharaohscurse);
                }
                if (CheckDowned.sotsMod.TryFind("PyramidSlab", out ModItem PyramidSlab))
                {
                    modBuildingBlocksShop.Add(PyramidSlab.Type, CheckDowned.pharaohscurse);
                }
                if (CheckDowned.sotsMod.TryFind("PyramidRubble", out ModItem PyramidRubble))
                {
                    modBuildingBlocksShop.Add(PyramidRubble.Type, CheckDowned.pharaohscurse);
                }
                if (CheckDowned.sotsMod.TryFind("RuinedPyramidBrick", out ModItem RuinedPyramidBrick))
                {
                    modBuildingBlocksShop.Add(RuinedPyramidBrick.Type, CheckDowned.pharaohscurse);
                }
                if (CheckDowned.sotsMod.TryFind("TidePlating", out ModItem TidePlating))
                {
                    modBuildingBlocksShop.Add(TidePlating.Type, CheckDowned.tidalConstruct);
                }
                if (CheckDowned.sotsMod.TryFind("UltimatePlating", out ModItem UltimatePlating))
                {
                    modBuildingBlocksShop.Add(UltimatePlating.Type, CheckDowned.lux);
                }
                if (CheckDowned.sotsMod.TryFind("DissolvingUmbraBlock", out ModItem DissolvingUmbraBlock))
                {
                    modBuildingBlocksShop.Add(DissolvingUmbraBlock.Type, CheckDowned.evilSpirit);
                }
                if (CheckDowned.sotsMod.TryFind("VibrantBrick", out ModItem VibrantBrick))
                {
                    modBuildingBlocksShop.Add(VibrantBrick.Type);
                }
            }
            if (CheckDowned.spiritLoaded)
            {
                if (CheckDowned.spiritMod.TryFind("AcidBrick", out ModItem AcidBrick))
                {
                    modBuildingBlocksShop.Add(AcidBrick.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.spiritMod.TryFind("SepulchreBrickTwoItem", out ModItem SepulchreBrickTwoItem))
                {
                    modBuildingBlocksShop.Add(SepulchreBrickTwoItem.Type);
                }
                if (CheckDowned.spiritMod.TryFind("SepulchreBrickItem", out ModItem SepulchreBrickItem))
                {
                    modBuildingBlocksShop.Add(SepulchreBrickItem.Type);
                }
            }
            if (CheckDowned.spookyLoaded)
            {
                if (CheckDowned.spookyMod.TryFind("CemeteryBrickItem", out ModItem CemeteryBrickItem))
                {
                    modBuildingBlocksShop.Add(CemeteryBrickItem.Type);
                }
            }
            //Storms N/A
            //Terrorborn (IF PORTED)
            if (CheckDowned.thoriumLoaded)
            {
                if (CheckDowned.thoriumMod.TryFind("AquamarineGemsparkBlock", out ModItem AquamarineGemsparkBlock))
                {
                    modBuildingBlocksShop.Add(AquamarineGemsparkBlock.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("ScaleBlock", out ModItem ScaleBlock))
                {
                    modBuildingBlocksShop.Add(ScaleBlock.Type, Condition.DownedEowOrBoc);
                }
                if (CheckDowned.thoriumMod.TryFind("BloodstainedBlock", out ModItem BloodstainedBlock))
                {
                    modBuildingBlocksShop.Add(BloodstainedBlock.Type, CheckDowned.bloodMoon);
                }
                if (CheckDowned.thoriumMod.TryFind("BookshelfBlock", out ModItem BookshelfBlock))
                {
                    modBuildingBlocksShop.Add(BookshelfBlock.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("CelestialBrick", out ModItem CelestialBrick))
                {
                    modBuildingBlocksShop.Add(CelestialBrick.Type, Condition.DownedCultist);
                }
                if (CheckDowned.thoriumMod.TryFind("CelestialFragmentBlock", out ModItem CelestialFragmentBlock))
                {
                    modBuildingBlocksShop.Add(CelestialFragmentBlock.Type, Condition.DownedCultist);
                }
                if (CheckDowned.thoriumMod.TryFind("CheckeredBrick", out ModItem CheckeredBrick))
                {
                    modBuildingBlocksShop.Add(CheckeredBrick.Type, Condition.DownedSkeletron);
                }
                if (CheckDowned.thoriumMod.TryFind("CursedBlock", out ModItem CursedBlock))
                {
                    modBuildingBlocksShop.Add(CursedBlock.Type, CheckDowned.lich);
                }
                if (CheckDowned.thoriumMod.TryFind("CutSandstoneBlock", out ModItem CutSandstoneBlock))
                {
                    modBuildingBlocksShop.Add(CutSandstoneBlock.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("CutSandstoneBlockSlab", out ModItem CutSandstoneBlockSlab))
                {
                    modBuildingBlocksShop.Add(CutSandstoneBlockSlab.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("CutStoneBlock", out ModItem CutStoneBlock))
                {
                    modBuildingBlocksShop.Add(CutStoneBlock.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("CutStoneBlockSlab", out ModItem CutStoneBlockSlab))
                {
                    modBuildingBlocksShop.Add(CutStoneBlockSlab.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("GlowingMarineBlock", out ModItem GlowingMarineBlock))
                {
                    modBuildingBlocksShop.Add(GlowingMarineBlock.Type, Condition.DownedEowOrBoc);
                }
                if (CheckDowned.thoriumMod.TryFind("IllumiteBrick", out ModItem IllumiteBrick))
                {
                    modBuildingBlocksShop.Add(IllumiteBrick.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.thoriumMod.TryFind("LodestoneSlab", out ModItem LodestoneSlab))
                {
                    modBuildingBlocksShop.Add(LodestoneSlab.Type, CheckDowned.fallenbeholder);
                }
                if (CheckDowned.thoriumMod.TryFind("MediciteBrick", out ModItem MediciteBrick))
                {
                    modBuildingBlocksShop.Add(MediciteBrick.Type, CheckDowned.bloodMoon);
                }
                if (CheckDowned.thoriumMod.TryFind("NagaBlock", out ModItem NagaBlock))
                {
                    modBuildingBlocksShop.Add(NagaBlock.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("OpalGemsparkBlock", out ModItem OpalGemsparkBlock))
                {
                    modBuildingBlocksShop.Add(OpalGemsparkBlock.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("OrnateBlock", out ModItem OrnateBlock))
                {
                    modBuildingBlocksShop.Add(OrnateBlock.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.thoriumMod.TryFind("PlateSlab", out ModItem PlateSlab))
                {
                    modBuildingBlocksShop.Add(PlateSlab.Type, Condition.DownedMechBossAny);
                }
                if (CheckDowned.thoriumMod.TryFind("PotionShelfBlock", out ModItem PotionShelfBlock))
                {
                    modBuildingBlocksShop.Add(PotionShelfBlock.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("RefinedMarineBlock", out ModItem RefinedMarineBlock))
                {
                    modBuildingBlocksShop.Add(RefinedMarineBlock.Type, Condition.DownedEowOrBoc);
                }
                if (CheckDowned.thoriumMod.TryFind("ScarletBlock", out ModItem ScarletBlock))
                {
                    modBuildingBlocksShop.Add(ScarletBlock.Type, Condition.DownedEowOrBoc);
                }
                if (CheckDowned.thoriumMod.TryFind("ShadyBlock", out ModItem ShadyBlock))
                {
                    modBuildingBlocksShop.Add(ShadyBlock.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.thoriumMod.TryFind("ShootingStarBrick", out ModItem ShootingStarBrick))
                {
                    modBuildingBlocksShop.Add(ShootingStarBrick.Type, Condition.DownedCultist);
                }
                if (CheckDowned.thoriumMod.TryFind("ShootingStarFragmentBlock", out ModItem ShootingStarFragmentBlock))
                {
                    modBuildingBlocksShop.Add(ShootingStarFragmentBlock.Type, Condition.DownedCultist);
                }
                if (CheckDowned.thoriumMod.TryFind("SmoothWood", out ModItem SmoothWood))
                {
                    modBuildingBlocksShop.Add(SmoothWood.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("ThoriumBrickBlock", out ModItem ThoriumBrickBlock))
                {
                    modBuildingBlocksShop.Add(ThoriumBrickBlock.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("ThoriumBrick", out ModItem ThoriumBrick))
                {
                    modBuildingBlocksShop.Add(ThoriumBrick.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("ValadiumPlating", out ModItem ValadiumPlating))
                {
                    modBuildingBlocksShop.Add(ValadiumPlating.Type, CheckDowned.fallenbeholder);
                }
                if (CheckDowned.thoriumMod.TryFind("WhiteDwarfBrick", out ModItem WhiteDwarfBrick))
                {
                    modBuildingBlocksShop.Add(WhiteDwarfBrick.Type, Condition.DownedCultist);
                }
                if (CheckDowned.thoriumMod.TryFind("WhiteDwarfFragmentBlock", out ModItem WhiteDwarfFragmentBlock))
                {
                    modBuildingBlocksShop.Add(WhiteDwarfFragmentBlock.Type, Condition.DownedCultist);
                }
            }
            if (CheckDowned.vitalityLoaded)
            {
                if (CheckDowned.vitalityMod.TryFind("ArcticBrick", out ModItem ArcticBrick))
                {
                    modBuildingBlocksShop.Add(ArcticBrick.Type, Condition.DownedMechBossAny);
                }
                if (CheckDowned.vitalityMod.TryFind("BronzeBrick", out ModItem BronzeBrick))
                {
                    modBuildingBlocksShop.Add(BronzeBrick.Type);
                }
                if (CheckDowned.vitalityMod.TryFind("GeraniumBrick", out ModItem GeraniumBrick))
                {
                    modBuildingBlocksShop.Add(GeraniumBrick.Type, Condition.DownedSkeletron);
                }
            }
            modBuildingBlocksShop.Register();

            /*
            var modPlantShop = new NPCShop(Type, "Modded Herbs & Plants");
            modPlantShop.Add(ModContent.ItemType<WIP>());
            //Aequus
            //Calamity
            //Catalyst
            //Consolaria
            //Echoes
            //Fargos
            //Gerds
            //Homeward
            //Infernum
            //Polarities
            //Qwerty
            //Redemption
            //SOTS
            //Spirit
            //Spooky
            //Storms
            //Terrorborn (IF PORTED)
            //Thorium
            //Vitality
            modPlantShop.Register();
            */
        }
    }
}