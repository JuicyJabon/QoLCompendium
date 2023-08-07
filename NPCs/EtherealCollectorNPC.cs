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
                button = "Modded Materials 1";
                ShopName = "Modded Materials 1";
            }
            else if (shopNum == 2)
            {
                button = "Modded Materials 2";
                ShopName = "Modded Materials 2";
            }
            else if (shopNum == 3)
            {
                button = "Modded Materials 3";
                ShopName = "Modded Materials 3";
            }
            else if (shopNum == 4)
            {
                button = "Modded Treasure Bags 1";
                ShopName = "Modded Treasure Bags 1";
            }
            else if (shopNum == 5)
            {
                button = "Modded Treasure Bags 2";
                ShopName = "Modded Treasure Bags 2";
            }
            else if (shopNum == 6)
            {
                button = "Modded Treasure Bags 3";
                ShopName = "Modded Treasure Bags 3";
            }
            else if (shopNum == 7)
            {
                button = "Modded Crates & Grab Bags";
                ShopName = "Modded Crates & Grab Bags";
            }
            else if (shopNum == 8)
            {
                button = "Modded Ores & Bars";
                ShopName = "Modded Ores & Bars";
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
            var modPotShop = new NPCShop(Type, "Modded Potions");
            if (CheckDowned.calamityLoaded)
            {
                if (CheckDowned.calamityMod.TryFind("AnechoicCoating", out ModItem AnechoicCoating))
                {
                    modPotShop.Add(AnechoicCoating.Type);
                }
                if (CheckDowned.calamityMod.TryFind("AstralInjection", out ModItem AstralInjection))
                {
                    modPotShop.Add(AstralInjection.Type, CheckDowned.aureus);
                }
                if (CheckDowned.calamityMod.TryFind("AureusCell", out ModItem AureusCell))
                {
                    modPotShop.Add(AureusCell.Type, CheckDowned.aureus);
                }
                if (CheckDowned.calamityMod.TryFind("Baguette", out ModItem Baguette))
                {
                    modPotShop.Add(Baguette.Type);
                }
                if (CheckDowned.calamityMod.TryFind("BoundingPotion", out ModItem BoundingPotion))
                {
                    modPotShop.Add(BoundingPotion.Type);
                }
                if (CheckDowned.calamityMod.TryFind("CalciumPotion", out ModItem CalciumPotion))
                {
                    modPotShop.Add(CalciumPotion.Type);
                }
                if (CheckDowned.calamityMod.TryFind("FlaskOfBrimstone", out ModItem FlaskOfBrimstone))
                {
                    modPotShop.Add(FlaskOfBrimstone.Type, CheckDowned.calamitas);
                }
                if (CheckDowned.calamityMod.TryFind("CrumblingPotion", out ModItem CrumblingPotion))
                {
                    modPotShop.Add(CrumblingPotion.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("GravityNormalizerPotion", out ModItem GravityNormalizerPotion))
                {
                    modPotShop.Add(GravityNormalizerPotion.Type, CheckDowned.aureus);
                }
                if (CheckDowned.calamityMod.TryFind("HolyWrathPotion", out ModItem HolyWrathPotion))
                {
                    modPotShop.Add(HolyWrathPotion.Type, CheckDowned.providence);
                }
                if (CheckDowned.calamityMod.TryFind("PhotosynthesisPotion", out ModItem PhotosynthesisPotion))
                {
                    modPotShop.Add(PhotosynthesisPotion.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("PotionofOmniscience", out ModItem PotionofOmniscience))
                {
                    modPotShop.Add(PotionofOmniscience.Type , Condition.DownedSkeletron);
                }
                if (CheckDowned.calamityMod.TryFind("ShadowPotion", out ModItem ShadowPotion))
                {
                    modPotShop.Add(ShadowPotion.Type);
                }
                if (CheckDowned.calamityMod.TryFind("SoaringPotion", out ModItem SoaringPotion))
                {
                    modPotShop.Add(SoaringPotion.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("SulphurskinPotion", out ModItem SulphurskinPotion))
                {
                    modPotShop.Add(SulphurskinPotion.Type);
                }
                if (CheckDowned.calamityMod.TryFind("TeslaPotion", out ModItem TeslaPotion))
                {
                    modPotShop.Add(TeslaPotion.Type, CheckDowned.perforators, CheckDowned.hivemind);
                }
                if (CheckDowned.calamityMod.TryFind("ZenPotion", out ModItem ZenPotion))
                {
                    modPotShop.Add(ZenPotion.Type, CheckDowned.slimegod);
                }
                if (CheckDowned.calamityMod.TryFind("ZergPotion", out ModItem ZergPotion))
                {
                    modPotShop.Add(ZergPotion.Type, CheckDowned.slimegod);
                }
            }
            if (CheckDowned.catalystLoaded)
            {
                if (CheckDowned.catalystMod.TryFind("AstraJelly", out ModItem AstraJelly))
                {
                    modPotShop.Add(AstraJelly.Type, Condition.Hardmode);
                }
                if (CheckDowned.catalystMod.TryFind("Lean", out ModItem Lean))
                {
                    modPotShop.Add(Lean.Type, CheckDowned.aureus);
                }
            }
            if (CheckDowned.thoriumLoaded)
            {
                if (CheckDowned.thoriumMod.TryFind("AquaPotion", out ModItem AquaPotion))
                {
                    modPotShop.Add(AquaPotion.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("ArcanePotion", out ModItem ArcanePotion))
                {
                    modPotShop.Add(ArcanePotion.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("ArtilleryPotion", out ModItem ArtilleryPotion))
                {
                    modPotShop.Add(ArtilleryPotion.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("AssassinPotion", out ModItem AssassinPotion))
                {
                    modPotShop.Add(AssassinPotion.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("BloodPotion", out ModItem BloodPotion))
                {
                    modPotShop.Add(BloodPotion.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("BouncingFlamePotion", out ModItem BouncingFlamePotion))
                {
                    modPotShop.Add(BouncingFlamePotion.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("CactusFruit", out ModItem CactusFruit))
                {
                    modPotShop.Add(CactusFruit.Type, CheckDowned.grandbird);
                }
                if (CheckDowned.thoriumMod.TryFind("ConflagrationPotion", out ModItem ConflagrationPotion))
                {
                    modPotShop.Add(ConflagrationPotion.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("CreativityPotion", out ModItem CreativityPotion))
                {
                    modPotShop.Add(CreativityPotion.Type, CheckDowned.grandbird);
                }
                if (CheckDowned.thoriumMod.TryFind("EarwormPotion", out ModItem EarwormPotion))
                {
                    modPotShop.Add(EarwormPotion.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("FrenzyPotion", out ModItem FrenzyPotion))
                {
                    modPotShop.Add(FrenzyPotion.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("GlowingPotion", out ModItem GlowingPotion))
                {
                    modPotShop.Add(GlowingPotion.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("HolyPotion", out ModItem HolyPotion))
                {
                    modPotShop.Add(HolyPotion.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("HydrationPotion", out ModItem HydrationPotion))
                {
                    modPotShop.Add(HydrationPotion.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("InspirationReachPotion", out ModItem InspirationReachPotion))
                {
                    modPotShop.Add(InspirationReachPotion.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("KineticPotion", out ModItem KineticPotion))
                {
                    modPotShop.Add(KineticPotion.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("WarmongerPotion", out ModItem WarmongerPotion))
                {
                    modPotShop.Add(WarmongerPotion.Type, Condition.DownedEowOrBoc);
                }
            }
            if (CheckDowned.redemptionLoaded)
            {
                if (CheckDowned.redemptionMod.TryFind("CharismaPotion", out ModItem CharismaPotion))
                {
                    modPotShop.Add(CharismaPotion.Type, CheckDowned.thorn);
                }
                if (CheckDowned.redemptionMod.TryFind("VendettaPotion", out ModItem VendettaPotion))
                {
                    modPotShop.Add(VendettaPotion.Type, CheckDowned.thorn);
                }
                if (CheckDowned.redemptionMod.TryFind("VigourousPotion", out ModItem VigourousPotion))
                {
                    modPotShop.Add(VigourousPotion.Type, CheckDowned.nebby);
                }
            }
            if (CheckDowned.sotsLoaded)
            {
                if (CheckDowned.sotsMod.TryFind("AbyssalTonic", out ModItem AbyssalTonic))
                {
                    modPotShop.Add(AbyssalTonic.Type);
                }
                if (CheckDowned.sotsMod.TryFind("AssassinationPotion", out ModItem AssassinationPotion))
                {
                    modPotShop.Add(AssassinationPotion.Type);
                }
                if (CheckDowned.sotsMod.TryFind("BlazingTonic", out ModItem BlazingTonic))
                {
                    modPotShop.Add(BlazingTonic.Type, Condition.Hardmode);
                }
                if (CheckDowned.sotsMod.TryFind("BlightfulTonic", out ModItem BlightfulTonic))
                {
                    modPotShop.Add(BlightfulTonic.Type);
                }
                if (CheckDowned.sotsMod.TryFind("BluefirePotion", out ModItem BluefirePotion))
                {
                    modPotShop.Add(BluefirePotion.Type);
                }
                if (CheckDowned.sotsMod.TryFind("BrittlePotion", out ModItem BrittlePotion))
                {
                    modPotShop.Add(BrittlePotion.Type);
                }
                if (CheckDowned.sotsMod.TryFind("DoubleVisionPotion", out ModItem DoubleVisionPotion))
                {
                    modPotShop.Add(DoubleVisionPotion.Type);
                }
                if (CheckDowned.sotsMod.TryFind("EtherealTonic", out ModItem EtherealTonic))
                {
                    modPotShop.Add(EtherealTonic.Type, CheckDowned.lux);
                }
                if (CheckDowned.sotsMod.TryFind("GlacialTonic", out ModItem GlacialTonic))
                {
                    modPotShop.Add(GlacialTonic.Type);
                }
                if (CheckDowned.sotsMod.TryFind("HarmonyPotion", out ModItem HarmonyPotion))
                {
                    modPotShop.Add(HarmonyPotion.Type, Condition.Hardmode);
                }
                if (CheckDowned.sotsMod.TryFind("HereticTonic", out ModItem HereticTonic))
                {
                    modPotShop.Add(HereticTonic.Type, Condition.Hardmode);
                }
                if (CheckDowned.sotsMod.TryFind("NightmarePotion", out ModItem NightmarePotion))
                {
                    modPotShop.Add(NightmarePotion.Type, Condition.Hardmode);
                }
                if (CheckDowned.sotsMod.TryFind("RipplePotion", out ModItem RipplePotion))
                {
                    modPotShop.Add(RipplePotion.Type);
                }
                if (CheckDowned.sotsMod.TryFind("RoughskinPotion", out ModItem RoughskinPotion))
                {
                    modPotShop.Add(RoughskinPotion.Type, Condition.DownedEowOrBoc);
                }
                if (CheckDowned.sotsMod.TryFind("SeismicTonic", out ModItem SeismicTonic))
                {
                    modPotShop.Add(SeismicTonic.Type);
                }
                if (CheckDowned.sotsMod.TryFind("SoulAccessPotion", out ModItem SoulAccessPotion))
                {
                    modPotShop.Add(SoulAccessPotion.Type, Condition.DownedEowOrBoc);
                }
                if (CheckDowned.sotsMod.TryFind("StarlightTonic", out ModItem StarlightTonic))
                {
                    modPotShop.Add(StarlightTonic.Type, CheckDowned.advisor);
                }
                if (CheckDowned.sotsMod.TryFind("VibePotion", out ModItem VibePotion))
                {
                    modPotShop.Add(VibePotion.Type, Condition.DownedEowOrBoc);
                }
            }
            if (CheckDowned.aqLoaded)
            {
                if (CheckDowned.aqMod.TryFind("BloodthirstPotion", out ModItem BloodthirstPotion))
                {
                    modPotShop.Add(BloodthirstPotion.Type);
                }
                if (CheckDowned.aqMod.TryFind("FrostPotion", out ModItem FrostPotion))
                {
                    modPotShop.Add(FrostPotion.Type);
                }
                if (CheckDowned.aqMod.TryFind("ManathirstPotion", out ModItem ManathirstPotion))
                {
                    modPotShop.Add(ManathirstPotion.Type);
                }
                if (CheckDowned.aqMod.TryFind("NecromancyPotion", out ModItem NecromancyPotion))
                {
                    modPotShop.Add(NecromancyPotion.Type);
                }
                if (CheckDowned.aqMod.TryFind("NeutronYogurt", out ModItem NeutronYogurt))
                {
                    modPotShop.Add(NeutronYogurt.Type);
                }
                if (CheckDowned.aqMod.TryFind("NoonPotion", out ModItem NoonPotion))
                {
                    modPotShop.Add(NoonPotion.Type, Condition.Hardmode);
                }
                if (CheckDowned.aqMod.TryFind("SentryPotion", out ModItem SentryPotion))
                {
                    modPotShop.Add(SentryPotion.Type);
                }
                if (CheckDowned.aqMod.TryFind("VeinminerPotion", out ModItem VeinminerPotion))
                {
                    modPotShop.Add(VeinminerPotion.Type);
                }
            }
            if (CheckDowned.polaritiesLoaded)
            {
                if (CheckDowned.polaritiesMod.TryFind("PiercingPotion", out ModItem PiercingPotion))
                {
                    modPotShop.Add(PiercingPotion.Type);
                }
                if (CheckDowned.polaritiesMod.TryFind("TolerancePotion", out ModItem TolerancePotion))
                {
                    modPotShop.Add(TolerancePotion.Type);
                }
            }
            if (CheckDowned.vitalityLoaded)
            {
                if (CheckDowned.vitalityMod.TryFind("ArmorPiercingPotion", out ModItem ArmorPiercingPotion))
                {
                    modPotShop.Add(ArmorPiercingPotion.Type);
                }
                if (CheckDowned.vitalityMod.TryFind("LeapingPotion", out ModItem LeapingPotion))
                {
                    modPotShop.Add(LeapingPotion.Type);
                }
                if (CheckDowned.vitalityMod.TryFind("TranquillityPotion", out ModItem TranquillityPotion))
                {
                    modPotShop.Add(TranquillityPotion.Type);
                }
                if (CheckDowned.vitalityMod.TryFind("TravelsensePotion", out ModItem TravelsensePotion))
                {
                    modPotShop.Add(TravelsensePotion.Type, Condition.Hardmode);
                }
                if (CheckDowned.vitalityMod.TryFind("WarriorPotion", out ModItem WarriorPotion))
                {
                    modPotShop.Add(WarriorPotion.Type, Condition.DownedEowOrBoc);
                }
            }
            if (CheckDowned.terrorbornLoaded)
            {
                if (CheckDowned.terrorbornMod.TryFind("AdrenalinePotion", out ModItem AdrenalinePotion))
                {
                    modPotShop.Add(AdrenalinePotion.Type);
                }
                if (CheckDowned.terrorbornMod.TryFind("AerodynamicPotion", out ModItem AerodynamicPotion))
                {
                    modPotShop.Add(AerodynamicPotion.Type);
                }
                if (CheckDowned.terrorbornMod.TryFind("BloodFlowPotion", out ModItem BloodFlowPotion))
                {
                    modPotShop.Add(BloodFlowPotion.Type);
                }
                if (CheckDowned.terrorbornMod.TryFind("SinducementPotion", out ModItem SinducementPotion))
                {
                    modPotShop.Add(SinducementPotion.Type, Condition.Hardmode);
                }
                if (CheckDowned.terrorbornMod.TryFind("StarpowerPotion", out ModItem StarpowerPotion))
                {
                    modPotShop.Add(StarpowerPotion.Type);
                }
                if (CheckDowned.terrorbornMod.TryFind("VampirismPotion", out ModItem VampirismPotion))
                {
                    modPotShop.Add(VampirismPotion.Type);
                }
            }
            modPotShop.Register();

            var modMatShop = new NPCShop(Type, "Modded Materials 1");
            if (CheckDowned.calamityLoaded)
            {
                if (CheckDowned.calamityMod.TryFind("AncientBoneDust", out ModItem AncientBoneDust))
                {
                    modMatShop.Add(AncientBoneDust.Type);
                }
                if (CheckDowned.calamityMod.TryFind("ArmoredShell", out ModItem ArmoredShell))
                {
                    modMatShop.Add(ArmoredShell.Type, CheckDowned.stormweaver);
                }
                if (CheckDowned.calamityMod.TryFind("AshesofAnnihilation", out ModItem AshesofAnnihilation))
                {
                    modMatShop.Add(AshesofAnnihilation.Type, CheckDowned.scalamitas);
                }
                if (CheckDowned.calamityMod.TryFind("AshesofCalamity", out ModItem AshesofCalamity))
                {
                    modMatShop.Add(AshesofCalamity.Type, CheckDowned.calamitas);
                }
                if (CheckDowned.calamityMod.TryFind("BeetleJuice", out ModItem BeetleJuice))
                {
                    modMatShop.Add(BeetleJuice.Type);
                }
                if (CheckDowned.calamityMod.TryFind("BlightedGel", out ModItem BlightedGel))
                {
                    modMatShop.Add(BlightedGel.Type);
                }
                if (CheckDowned.calamityMod.TryFind("BloodOrb", out ModItem BloodOrb))
                {
                    modMatShop.Add(BloodOrb.Type);
                }
                if (CheckDowned.calamityMod.TryFind("BloodSample", out ModItem BloodSample))
                {
                    modMatShop.Add(BloodSample.Type, CheckDowned.perforators);
                }
                if (CheckDowned.calamityMod.TryFind("Bloodstone", out ModItem Bloodstone))
                {
                    modMatShop.Add(Bloodstone.Type, CheckDowned.providence);
                }
                if (CheckDowned.calamityMod.TryFind("DarkPlasma", out ModItem DarkPlasma))
                {
                    modMatShop.Add(DarkPlasma.Type, CheckDowned.ceaselessvoid);
                }
                if (CheckDowned.calamityMod.TryFind("DarksunFragment", out ModItem DarksunFragment))
                {
                    modMatShop.Add(DarksunFragment.Type, CheckDowned.dog);
                }
                if (CheckDowned.calamityMod.TryFind("DepthCells", out ModItem DepthCells))
                {
                    modMatShop.Add(DepthCells.Type, CheckDowned.calamitas);
                }
                if (CheckDowned.calamityMod.TryFind("DemonicBoneAsh", out ModItem DemonicBoneAsh))
                {
                    modMatShop.Add(DemonicBoneAsh.Type);
                }
                if (CheckDowned.calamityMod.TryFind("DivineGeode", out ModItem DivineGeode))
                {
                    modMatShop.Add(DivineGeode.Type, CheckDowned.providence);
                }
                if (CheckDowned.calamityMod.TryFind("DubiousPlating", out ModItem DubiousPlating))
                {
                    modMatShop.Add(DubiousPlating.Type);
                }
                if (CheckDowned.calamityMod.TryFind("EffulgentFeather", out ModItem EffulgentFeather))
                {
                    modMatShop.Add(EffulgentFeather.Type, CheckDowned.dragonfolly);
                }
                if (CheckDowned.calamityMod.TryFind("EndothermicEnergy", out ModItem EndothermicEnergy))
                {
                    modMatShop.Add(EndothermicEnergy.Type, CheckDowned.dog);
                }
                if (CheckDowned.calamityMod.TryFind("EnergyCore", out ModItem EnergyCore))
                {
                    modMatShop.Add(EnergyCore.Type);
                }
                if (CheckDowned.calamityMod.TryFind("EssenceofChaos", out ModItem EssenceofChaos))
                {
                    modMatShop.Add(EssenceofChaos.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("EssenceofEleum", out ModItem EssenceofEleum))
                {
                    modMatShop.Add(EssenceofEleum.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("EssenceofSunlight", out ModItem EssenceofSunlight))
                {
                    modMatShop.Add(EssenceofSunlight.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("ExoPrism", out ModItem ExoPrism))
                {
                    modMatShop.Add(ExoPrism.Type, CheckDowned.exomechs);
                }
                if (CheckDowned.calamityMod.TryFind("GrandScale", out ModItem GrandScale))
                {
                    modMatShop.Add(GrandScale.Type, CheckDowned.sandshark);
                }
                if (CheckDowned.calamityMod.TryFind("InfectedArmorPlating", out ModItem InfectedArmorPlating))
                {
                    modMatShop.Add(InfectedArmorPlating.Type, CheckDowned.plaguebringer);
                }
                if (CheckDowned.calamityMod.TryFind("LivingShard", out ModItem LivingShard))
                {
                    modMatShop.Add(LivingShard.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.calamityMod.TryFind("Lumenyl", out ModItem Lumenyl))
                {
                    modMatShop.Add(Lumenyl.Type, CheckDowned.calamitas);
                }
                if (CheckDowned.calamityMod.TryFind("MeldBlob", out ModItem MeldBlob))
                {
                    modMatShop.Add(MeldBlob.Type, Condition.DownedCultist);
                }
                if (CheckDowned.calamityMod.TryFind("MolluskHusk", out ModItem MolluskHusk))
                {
                    modMatShop.Add(MolluskHusk.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("MurkyPaste", out ModItem MurkyPaste))
                {
                    modMatShop.Add(MurkyPaste.Type);
                }
                if (CheckDowned.calamityMod.TryFind("MysteriousCircuitry", out ModItem MysteriousCircuitry))
                {
                    modMatShop.Add(MysteriousCircuitry.Type);
                }
                if (CheckDowned.calamityMod.TryFind("NightmareFuel", out ModItem NightmareFuel))
                {
                    modMatShop.Add(NightmareFuel.Type, CheckDowned.dog);
                }
                if (CheckDowned.calamityMod.TryFind("PearlShard", out ModItem PearlShard))
                {
                    modMatShop.Add(PearlShard.Type, CheckDowned.desertscourge);
                }
                if (CheckDowned.calamityMod.TryFind("Polterplasm", out ModItem Polterplasm))
                {
                    modMatShop.Add(Polterplasm.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.calamityMod.TryFind("PlagueCellCanister", out ModItem PlagueCellCanister))
                {
                    modMatShop.Add(PlagueCellCanister.Type, Condition.DownedGolem);
                }
                if (CheckDowned.calamityMod.TryFind("PurifiedGel", out ModItem PurifiedGel))
                {
                    modMatShop.Add(PurifiedGel.Type, CheckDowned.slimegod);
                }
                if (CheckDowned.calamityMod.TryFind("ReaperTooth", out ModItem ReaperTooth))
                {
                    modMatShop.Add(ReaperTooth.Type, CheckDowned.polterghast);
                }
                if (CheckDowned.calamityMod.TryFind("RottenMatter", out ModItem RottenMatter))
                {
                    modMatShop.Add(RottenMatter.Type, CheckDowned.hivemind);
                }
                if (CheckDowned.calamityMod.TryFind("RuinousSoul", out ModItem RuinousSoul))
                {
                    modMatShop.Add(RuinousSoul.Type, CheckDowned.polterghast);
                }
                if (CheckDowned.calamityMod.TryFind("SolarVeil", out ModItem SolarVeil))
                {
                    modMatShop.Add(SolarVeil.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.calamityMod.TryFind("StormlionMandible", out ModItem StormlionMandible))
                {
                    modMatShop.Add(StormlionMandible.Type);
                }
                if (CheckDowned.calamityMod.TryFind("Stardust", out ModItem Stardust))
                {
                    modMatShop.Add(Stardust.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("SulphuricScale", out ModItem SulphuricScale))
                {
                    modMatShop.Add(SulphuricScale.Type, Condition.DownedEyeOfCthulhu);
                }
                if (CheckDowned.calamityMod.TryFind("TrapperBulb", out ModItem TrapperBulb))
                {
                    modMatShop.Add(TrapperBulb.Type, Condition.Hardmode);
                }
                if (CheckDowned.calamityMod.TryFind("TwistingNether", out ModItem TwistingNether))
                {
                    modMatShop.Add(TwistingNether.Type, CheckDowned.signus);
                }
                if (CheckDowned.calamityMod.TryFind("UnholyEssence", out ModItem UnholyEssence))
                {
                    modMatShop.Add(UnholyEssence.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.calamityMod.TryFind("WulfrumMetalScrap", out ModItem WulfrumMetalScrap))
                {
                    modMatShop.Add(WulfrumMetalScrap.Type);
                }
                if (CheckDowned.calamityMod.TryFind("YharonSoulFragment", out ModItem YharonSoulFragment))
                {
                    modMatShop.Add(YharonSoulFragment.Type, CheckDowned.yharon);
                }
            }
            if (CheckDowned.thoriumLoaded)
            {
                if (CheckDowned.thoriumMod.TryFind("AbyssalChitin", out ModItem AbyssalChitin))
                {
                    modMatShop.Add(AbyssalChitin.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("BioMatter", out ModItem BioMatter))
                {
                    modMatShop.Add(BioMatter.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("BirdTalon", out ModItem BirdTalon))
                {
                    modMatShop.Add(BirdTalon.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("Blood", out ModItem Blood))
                {
                    modMatShop.Add(Blood.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("BloomWeave", out ModItem BloomWeave))
                {
                    modMatShop.Add(BloomWeave.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.thoriumMod.TryFind("BrokenHeroFragment", out ModItem BrokenHeroFragment))
                {
                    modMatShop.Add(BrokenHeroFragment.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.thoriumMod.TryFind("BronzeFragments", out ModItem BronzeFragments))
                {
                    modMatShop.Add(BronzeFragments.Type, Condition.DownedSkeletron);
                }
                if (CheckDowned.thoriumMod.TryFind("CelestialFragment", out ModItem CelestialFragment))
                {
                    modMatShop.Add(CelestialFragment.Type, Condition.DownedCultist);
                }
                if (CheckDowned.thoriumMod.TryFind("CeruleanMorel", out ModItem CeruleanMorel))
                {
                    modMatShop.Add(CeruleanMorel.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("CursedCloth", out ModItem CursedCloth))
                {
                    modMatShop.Add(CursedCloth.Type, CheckDowned.lich);
                }
                if (CheckDowned.thoriumMod.TryFind("DarkMatter", out ModItem DarkMatter))
                {
                    modMatShop.Add(DarkMatter.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.thoriumMod.TryFind("DeathEssence", out ModItem DeathEssence))
                {
                    modMatShop.Add(DeathEssence.Type, CheckDowned.primordials);
                }
                if (CheckDowned.thoriumMod.TryFind("DemonBloodShard", out ModItem DemonBloodShard))
                {
                    modMatShop.Add(DemonBloodShard.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.thoriumMod.TryFind("DepthScale", out ModItem DepthScale))
                {
                    modMatShop.Add(DepthScale.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("DreadSoul", out ModItem DreadSoul))
                {
                    modMatShop.Add(DreadSoul.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.thoriumMod.TryFind("Geode", out ModItem Geode))
                {
                    modMatShop.Add(Geode.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("GraniteEnergyCore", out ModItem GraniteEnergyCore))
                {
                    modMatShop.Add(GraniteEnergyCore.Type, Condition.DownedSkeletron);
                }
                if (CheckDowned.thoriumMod.TryFind("GreenDragonScale", out ModItem GreenDragonScale))
                {
                    modMatShop.Add(GreenDragonScale.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("HallowedCharm", out ModItem HallowedCharm))
                {
                    modMatShop.Add(HallowedCharm.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("HolyKnightsAlloy", out ModItem HolyKnightsAlloy))
                {
                    modMatShop.Add(HolyKnightsAlloy.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.thoriumMod.TryFind("IcyShard", out ModItem IcyShard))
                {
                    modMatShop.Add(IcyShard.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("InfernoEssence", out ModItem InfernoEssence))
                {
                    modMatShop.Add(InfernoEssence.Type, CheckDowned.primordials);
                }
                if (CheckDowned.thoriumMod.TryFind("LifeCell", out ModItem LifeCell))
                {
                    modMatShop.Add(LifeCell.Type, Condition.DownedMechBossAny);
                }
                if (CheckDowned.thoriumMod.TryFind("LivingLeaf", out ModItem LivingLeaf))
                {
                    modMatShop.Add(LivingLeaf.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("MarineKelp", out ModItem MarineKelp))
                {
                    modMatShop.Add(MarineKelp.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("OceanEssence", out ModItem OceanEssence))
                {
                    modMatShop.Add(OceanEssence.Type, CheckDowned.primordials);
                }
                if (CheckDowned.thoriumMod.TryFind("Petal", out ModItem Petal))
                {
                    modMatShop.Add(Petal.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("PharaohsBreath", out ModItem PharaohsBreath))
                {
                    modMatShop.Add(PharaohsBreath.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("PurityShards", out ModItem PurityShards))
                {
                    modMatShop.Add(PurityShards.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("ShootingStarFragment", out ModItem ShootingStarFragment))
                {
                    modMatShop.Add(ShootingStarFragment.Type, Condition.DownedCultist);
                }
                if (CheckDowned.thoriumMod.TryFind("StrangeAlienTech", out ModItem StrangeAlienTech))
                {
                    modMatShop.Add(StrangeAlienTech.Type, Condition.DownedEowOrBoc);
                }
                if (CheckDowned.thoriumMod.TryFind("StrangePlating", out ModItem StrangePlating))
                {
                    modMatShop.Add(StrangePlating.Type, Condition.DownedMechBossAny);
                }
                if (CheckDowned.thoriumMod.TryFind("SolarPebble", out ModItem SolarPebble))
                {
                    modMatShop.Add(SolarPebble.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.thoriumMod.TryFind("SoulofPlight", out ModItem SoulofPlight))
                {
                    modMatShop.Add(SoulofPlight.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("SpiritDroplet", out ModItem SpiritDroplet))
                {
                    modMatShop.Add(SpiritDroplet.Type, Condition.DownedSkeletron);
                }
                if (CheckDowned.thoriumMod.TryFind("TerrariumCore", out ModItem TerrariumCore))
                {
                    modMatShop.Add(TerrariumCore.Type, Condition.DownedCultist);
                }
                if (CheckDowned.thoriumMod.TryFind("UnfathomableFlesh", out ModItem UnfathomableFlesh))
                {
                    modMatShop.Add(UnfathomableFlesh.Type, Condition.Hardmode);
                }
                if (CheckDowned.thoriumMod.TryFind("UnholyShards", out ModItem UnholyShards))
                {
                    modMatShop.Add(UnholyShards.Type);
                }
                if (CheckDowned.thoriumMod.TryFind("WhiteDwarfFragment", out ModItem WhiteDwarfFragment))
                {
                    modMatShop.Add(WhiteDwarfFragment.Type, Condition.DownedCultist);
                }
                if (CheckDowned.thoriumMod.TryFind("YewWood", out ModItem YewWood))
                {
                    modMatShop.Add(YewWood.Type, Condition.DownedEowOrBoc);
                }
            }
            modMatShop.Register();

            var modMatShop2 = new NPCShop(Type, "Modded Materials 2");
            if (CheckDowned.redemptionLoaded)
            {
                if (CheckDowned.redemptionMod.TryFind("AIChip", out ModItem AIChip))
                {
                    modMatShop2.Add(AIChip.Type, Condition.Hardmode);
                }
                if (CheckDowned.redemptionMod.TryFind("CarbonMyofibre", out ModItem CarbonMyofibre))
                {
                    modMatShop2.Add(CarbonMyofibre.Type, Condition.Hardmode);
                }
                if (CheckDowned.redemptionMod.TryFind("Capacitator", out ModItem Capacitator))
                {
                    modMatShop2.Add(Capacitator.Type, Condition.Hardmode);
                }
                if (CheckDowned.redemptionMod.TryFind("CoastScarabShell", out ModItem CoastScarabShell))
                {
                    modMatShop2.Add(CoastScarabShell.Type);
                }
                if (CheckDowned.redemptionMod.TryFind("GildedStar", out ModItem GildedStar))
                {
                    modMatShop2.Add(GildedStar.Type, CheckDowned.duo);
                }
                if (CheckDowned.redemptionMod.TryFind("GraveSteelShards", out ModItem GraveSteelShards))
                {
                    modMatShop2.Add(GraveSteelShards.Type);
                }
                if (CheckDowned.redemptionMod.TryFind("GrimShard", out ModItem GrimShard))
                {
                    modMatShop2.Add(GrimShard.Type, CheckDowned.keeper);
                }
                if (CheckDowned.redemptionMod.TryFind("LifeFragment", out ModItem LifeFragment))
                {
                    modMatShop2.Add(LifeFragment.Type, CheckDowned.nebby);
                }
                if (CheckDowned.redemptionMod.TryFind("LivingTwig", out ModItem LivingTwig))
                {
                    modMatShop2.Add(LivingTwig.Type);
                }
                if (CheckDowned.redemptionMod.TryFind("LostSoul", out ModItem LostSoul))
                {
                    modMatShop2.Add(LostSoul.Type);
                }
                if (CheckDowned.redemptionMod.TryFind("MoltenScrap", out ModItem MoltenScrap))
                {
                    modMatShop2.Add(MoltenScrap.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.redemptionMod.TryFind("MoonflareFragment", out ModItem MoonflareFragment))
                {
                    modMatShop2.Add(MoonflareFragment.Type);
                }
                if (CheckDowned.redemptionMod.TryFind("Plating", out ModItem Plating))
                {
                    modMatShop2.Add(Plating.Type, Condition.Hardmode);
                }
                if (CheckDowned.redemptionMod.TryFind("Plutonium", out ModItem Plutonium))
                {
                    modMatShop2.Add(Plutonium.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.redemptionMod.TryFind("RawXenium", out ModItem RawXenium))
                {
                    modMatShop2.Add(RawXenium.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.redemptionMod.TryFind("ToxicBile", out ModItem ToxicBile))
                {
                    modMatShop2.Add(ToxicBile.Type, Condition.Hardmode);
                }
                if (CheckDowned.redemptionMod.TryFind("TreeBugShell", out ModItem TreeBugShell))
                {
                    modMatShop2.Add(TreeBugShell.Type);
                }
                if (CheckDowned.redemptionMod.TryFind("CorruptedXenomite", out ModItem CorruptedXenomite))
                {
                    modMatShop2.Add(CorruptedXenomite.Type, CheckDowned.cleaver);
                }
                if (CheckDowned.redemptionMod.TryFind("Uranium", out ModItem Uranium))
                {
                    modMatShop2.Add(Uranium.Type, Condition.DownedGolem);
                }
                if (CheckDowned.redemptionMod.TryFind("Xenomite", out ModItem Xenomite))
                {
                    modMatShop2.Add(Xenomite.Type, Condition.Hardmode);
                }
                if (CheckDowned.redemptionMod.TryFind("XeniumAlloy", out ModItem XeniumAlloy))
                {
                    modMatShop2.Add(XeniumAlloy.Type, Condition.DownedMoonLord);
                }
                if (CheckDowned.redemptionMod.TryFind("XenomiteShard", out ModItem XenomiteShard))
                {
                    modMatShop2.Add(XenomiteShard.Type, CheckDowned.seed);
                }
            }
            if (CheckDowned.sotsLoaded)
            {
                if (CheckDowned.sotsMod.TryFind("DissolvingAether", out ModItem DissolvingAether))
                {
                    modMatShop2.Add(DissolvingAether.Type, CheckDowned.advisor);
                }
                if (CheckDowned.sotsMod.TryFind("DissolvingAurora", out ModItem DissolvingAurora))
                {
                    modMatShop2.Add(DissolvingAurora.Type);
                }
                if (CheckDowned.sotsMod.TryFind("DissolvingBrilliance", out ModItem DissolvingBrilliance))
                {
                    modMatShop2.Add(DissolvingBrilliance.Type, CheckDowned.lux);
                }
                if (CheckDowned.sotsMod.TryFind("DissolvingDeluge", out ModItem DissolvingDeluge))
                {
                    modMatShop2.Add(DissolvingDeluge.Type);
                }
                if (CheckDowned.sotsMod.TryFind("DissolvingEarth", out ModItem DissolvingEarth))
                {
                    modMatShop2.Add(DissolvingEarth.Type);
                }
                if (CheckDowned.sotsMod.TryFind("DissolvingNature", out ModItem DissolvingNature))
                {
                    modMatShop2.Add(DissolvingNature.Type);
                }
                if (CheckDowned.sotsMod.TryFind("DissolvingNether", out ModItem DissolvingNether))
                {
                    modMatShop2.Add(DissolvingNether.Type, Condition.Hardmode);
                }
                if (CheckDowned.sotsMod.TryFind("DissolvingUmbra", out ModItem DissolvingUmbra))
                {
                    modMatShop2.Add(DissolvingUmbra.Type, Condition.Hardmode);
                }
                if (CheckDowned.sotsMod.TryFind("FragmentOfChaos", out ModItem FragmentOfChaos))
                {
                    modMatShop2.Add(FragmentOfChaos.Type, Condition.Hardmode);
                }
                if (CheckDowned.sotsMod.TryFind("FragmentOfEarth", out ModItem FragmentOfEarth))
                {
                    modMatShop2.Add(FragmentOfEarth.Type);
                }
                if (CheckDowned.sotsMod.TryFind("FragmentOfEvil", out ModItem FragmentOfEvil))
                {
                    modMatShop2.Add(FragmentOfEvil.Type);
                }
                if (CheckDowned.sotsMod.TryFind("FragmentOfInferno", out ModItem FragmentOfInferno))
                {
                    modMatShop2.Add(FragmentOfInferno.Type);
                }
                if (CheckDowned.sotsMod.TryFind("FragmentOfNature", out ModItem FragmentOfNature))
                {
                    modMatShop2.Add(FragmentOfNature.Type);
                }
                if (CheckDowned.sotsMod.TryFind("FragmentOfOtherworld", out ModItem FragmentOfOtherworld))
                {
                    modMatShop2.Add(FragmentOfOtherworld.Type);
                }
                if (CheckDowned.sotsMod.TryFind("FragmentOfPermafrost", out ModItem FragmentOfPermafrost))
                {
                    modMatShop2.Add(FragmentOfPermafrost.Type);
                }
                if (CheckDowned.sotsMod.TryFind("FragmentOfTide", out ModItem FragmentOfTide))
                {
                    modMatShop2.Add(FragmentOfTide.Type);
                }
            }
            if (CheckDowned.aqLoaded)
            {
                if (CheckDowned.aqMod.TryFind("AtmosphericEnergy", out ModItem AtmosphericEnergy) && (CheckDowned.downedSprite || CheckDowned.downedSpaceSquid || CheckDowned.downedDevil))
                {
                    modMatShop2.Add(AtmosphericEnergy.Type);
                }
                if (CheckDowned.aqMod.TryFind("AquaticEnergy", out ModItem AquaticEnergy))
                {
                    modMatShop2.Add(AquaticEnergy.Type);
                }
                if (CheckDowned.aqMod.TryFind("BloodyTearstone", out ModItem BloodyTearstone))
                {
                    modMatShop2.Add(BloodyTearstone.Type);
                }
                if (CheckDowned.aqMod.TryFind("CosmicEnergy", out ModItem CosmicEnergy))
                {
                    modMatShop2.Add(CosmicEnergy.Type, CheckDowned.omegastarite);
                }
                if (CheckDowned.aqMod.TryFind("DemonicEnergy", out ModItem DemonicEnergy))
                {
                    modMatShop2.Add(DemonicEnergy.Type);
                }
                if (CheckDowned.aqMod.TryFind("Fluorescence", out ModItem Fluorescence))
                {
                    modMatShop2.Add(Fluorescence.Type, CheckDowned.sprite);
                }
                if (CheckDowned.aqMod.TryFind("FrozenTear", out ModItem FrozenTear))
                {
                    modMatShop2.Add(FrozenTear.Type, CheckDowned.spacesquid);
                }
                if (CheckDowned.aqMod.TryFind("Hexoplasm", out ModItem Hexoplasm))
                {
                    modMatShop2.Add(Hexoplasm.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.aqMod.TryFind("OrganicEnergy", out ModItem OrganicEnergy))
                {
                    modMatShop2.Add(OrganicEnergy.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.aqMod.TryFind("UltimateEnergy", out ModItem UltimateEnergy))
                {
                    modMatShop2.Add(UltimateEnergy.Type, Condition.DownedPlantera);
                }
            }
            modMatShop2.Register();

            var modMatShop3 = new NPCShop(Type, "Modded Materials 3");
            if (CheckDowned.polaritiesLoaded)
            {
                if (CheckDowned.polaritiesMod.TryFind("AlkalineFluid", out ModItem AlkalineFluid))
                {
                    modMatShop3.Add(AlkalineFluid.Type);
                }
                if (CheckDowned.polaritiesMod.TryFind("CongealedBrine", out ModItem CongealedBrine))
                {
                    modMatShop3.Add(CongealedBrine.Type, Condition.Hardmode);
                }
                if (CheckDowned.polaritiesMod.TryFind("EvilDNA", out ModItem EvilDNA))
                {
                    modMatShop3.Add(EvilDNA.Type, CheckDowned.esophage);
                }
                if (CheckDowned.polaritiesMod.TryFind("LimestoneCarapace", out ModItem LimestoneCarapace))
                {
                    modMatShop3.Add(LimestoneCarapace.Type, Condition.Hardmode);
                }
                if (CheckDowned.polaritiesMod.TryFind("Rattle", out ModItem Rattle))
                {
                    modMatShop3.Add(Rattle.Type);
                }
                if (CheckDowned.polaritiesMod.TryFind("SaltCrystals", out ModItem SaltCrystals))
                {
                    modMatShop3.Add(SaltCrystals.Type);
                }
                if (CheckDowned.polaritiesMod.TryFind("SerpentScale", out ModItem SerpentScale))
                {
                    modMatShop3.Add(SerpentScale.Type, Condition.Hardmode);
                }
                if (CheckDowned.polaritiesMod.TryFind("StormChunk", out ModItem StormChunk))
                {
                    modMatShop3.Add(StormChunk.Type, CheckDowned.cloudfish);
                }
                if (CheckDowned.polaritiesMod.TryFind("Tentacle", out ModItem Tentacle))
                {
                    modMatShop3.Add(Tentacle.Type, Condition.Hardmode);
                }
                if (CheckDowned.polaritiesMod.TryFind("VenomGland", out ModItem VenomGland))
                {
                    modMatShop3.Add(VenomGland.Type, Condition.Hardmode);
                }
                if (CheckDowned.polaritiesMod.TryFind("WandererPlating", out ModItem WandererPlating))
                {
                    modMatShop3.Add(WandererPlating.Type, CheckDowned.wanderer);
                }
            }
            if (CheckDowned.vitalityLoaded)
            {
                if (CheckDowned.vitalityMod.TryFind("AncientGoldShard", out ModItem AncientGoldShard))
                {
                    modMatShop3.Add(AncientGoldShard.Type);
                }
                if (CheckDowned.vitalityMod.TryFind("ChaosCrystal", out ModItem ChaosCrystal))
                {
                    modMatShop3.Add(ChaosCrystal.Type, Condition.Hardmode);
                }
                if (CheckDowned.vitalityMod.TryFind("ChaosDust", out ModItem ChaosDust))
                {
                    modMatShop3.Add(ChaosDust.Type, Condition.Hardmode);
                }
                if (CheckDowned.vitalityMod.TryFind("Charcoal", out ModItem Charcoal))
                {
                    modMatShop3.Add(Charcoal.Type);
                }
                if (CheckDowned.vitalityMod.TryFind("CloudVapor", out ModItem CloudVapor))
                {
                    modMatShop3.Add(CloudVapor.Type, CheckDowned.stormcloud);
                }
                if (CheckDowned.vitalityMod.TryFind("Ectosoul", out ModItem Ectosoul))
                {
                    modMatShop3.Add(Ectosoul.Type, CheckDowned.paladin);
                }
                if (CheckDowned.vitalityMod.TryFind("EquityCore", out ModItem EquityCore))
                {
                    modMatShop3.Add(EquityCore.Type, CheckDowned.paladin);
                }
                if (CheckDowned.vitalityMod.TryFind("EssenceofFire", out ModItem EssenceofFire))
                {
                    modMatShop3.Add(EssenceofFire.Type, Condition.Hardmode);
                }
                if (CheckDowned.vitalityMod.TryFind("EssenceofFrost", out ModItem EssenceofFrost))
                {
                    modMatShop3.Add(EssenceofFrost.Type, Condition.Hardmode);
                }
                if (CheckDowned.vitalityMod.TryFind("ForbiddenFeather", out ModItem ForbiddenFeather))
                {
                    modMatShop3.Add(ForbiddenFeather.Type, Condition.Hardmode);
                }
                if (CheckDowned.vitalityMod.TryFind("GlacialChunk", out ModItem GlacialChunk))
                {
                    modMatShop3.Add(GlacialChunk.Type);
                }
                if (CheckDowned.vitalityMod.TryFind("GlowingGranitePowder", out ModItem GlowingGranitePowder))
                {
                    modMatShop3.Add(GlowingGranitePowder.Type);
                }
                if (CheckDowned.vitalityMod.TryFind("LivingStick", out ModItem LivingStick))
                {
                    modMatShop3.Add(LivingStick.Type);
                }
                if (CheckDowned.vitalityMod.TryFind("PurifiedSpore", out ModItem PurifiedSpore))
                {
                    modMatShop3.Add(PurifiedSpore.Type);
                }
                if (CheckDowned.vitalityMod.TryFind("ShiverFragment", out ModItem ShiverFragment))
                {
                    modMatShop3.Add(ShiverFragment.Type, Condition.DownedPlantera);
                }
                if (CheckDowned.vitalityMod.TryFind("SoulofVitality", out ModItem SoulofVitality))
                {
                    modMatShop3.Add(SoulofVitality.Type, Condition.DownedPlantera);
                }
            }
            modMatShop3.Register();

            var boss1Shop = new NPCShop(Type, "Modded Treasure Bags 1");
            if (CheckDowned.calamityLoaded)
            {
                if (CheckDowned.calamityMod.TryFind("DesertScourgeBag", out ModItem DesertScourgeBag))
                {
                    boss1Shop.Add(DesertScourgeBag.Type, CheckDowned.desertscourge);
                }
                if (CheckDowned.calamityMod.TryFind("CrabulonBag", out ModItem CrabulonBag))
                {
                    boss1Shop.Add(CrabulonBag.Type, CheckDowned.crabulon);
                }
                if (CheckDowned.calamityMod.TryFind("HiveMindBag", out ModItem HiveMindBag))
                {
                    boss1Shop.Add(HiveMindBag.Type, CheckDowned.hivemind);
                }
                if (CheckDowned.calamityMod.TryFind("PerforatorBag", out ModItem PerforatorBag))
                {
                    boss1Shop.Add(PerforatorBag.Type, CheckDowned.perforators);
                }
                if (CheckDowned.calamityMod.TryFind("SlimeGodBag", out ModItem SlimeGodBag))
                {
                    boss1Shop.Add(SlimeGodBag.Type, CheckDowned.slimegod);
                }
                if (CheckDowned.calamityMod.TryFind("CryogenBag", out ModItem CryogenBag))
                {
                    boss1Shop.Add(CryogenBag.Type, CheckDowned.cryogen);
                }
                if (CheckDowned.calamityMod.TryFind("AquaticScourgeBag", out ModItem AquaticScourgeBag))
                {
                    boss1Shop.Add(AquaticScourgeBag.Type, CheckDowned.aquaticscourge);
                }
                if (CheckDowned.calamityMod.TryFind("BrimstoneWaifuBag", out ModItem BrimstoneWaifuBag))
                {
                    boss1Shop.Add(BrimstoneWaifuBag.Type, CheckDowned.brimstoneelemental);
                }
                if (CheckDowned.calamityMod.TryFind("CalamitasCloneBag", out ModItem CalamitasCloneBag))
                {
                    boss1Shop.Add(CalamitasCloneBag.Type, CheckDowned.calamitas);
                }
                if (CheckDowned.calamityMod.TryFind("LeviathanBag", out ModItem LeviathanBag))
                {
                    boss1Shop.Add(LeviathanBag.Type, CheckDowned.leviathan);
                }
                if (CheckDowned.calamityMod.TryFind("AstrumAureusBag", out ModItem AstrumAureusBag))
                {
                    boss1Shop.Add(AstrumAureusBag.Type, CheckDowned.aureus);
                }
                if (CheckDowned.calamityMod.TryFind("PlaguebringerGoliathBag", out ModItem PlaguebringerGoliathBag))
                {
                    boss1Shop.Add(PlaguebringerGoliathBag.Type, CheckDowned.plaguebringer);
                }
                if (CheckDowned.calamityMod.TryFind("RavagerBag", out ModItem RavagerBag))
                {
                    boss1Shop.Add(RavagerBag.Type, CheckDowned.ravager);
                }
                if (CheckDowned.calamityMod.TryFind("AstrumDeusBag", out ModItem AstrumDeusBag))
                {
                    boss1Shop.Add(AstrumDeusBag.Type, CheckDowned.deus);
                }
                if (CheckDowned.calamityMod.TryFind("DragonfollyBag", out ModItem DragonfollyBag))
                {
                    boss1Shop.Add(DragonfollyBag.Type, CheckDowned.dragonfolly);
                }
                if (CheckDowned.calamityMod.TryFind("ProvidenceBag", out ModItem ProvidenceBag))
                {
                    boss1Shop.Add(ProvidenceBag.Type, CheckDowned.providence);
                }
                if (CheckDowned.calamityMod.TryFind("PolterghastBag", out ModItem PolterghastBag))
                {
                    boss1Shop.Add(PolterghastBag.Type, CheckDowned.polterghast);
                }
                if (CheckDowned.calamityMod.TryFind("CeaselessVoidBag", out ModItem CeaselessVoidBag))
                {
                    boss1Shop.Add(CeaselessVoidBag.Type, CheckDowned.ceaselessvoid);
                }
                if (CheckDowned.calamityMod.TryFind("StormWeaverBag", out ModItem StormWeaverBag))
                {
                    boss1Shop.Add(StormWeaverBag.Type, CheckDowned.stormweaver);
                }
                if (CheckDowned.calamityMod.TryFind("SignusBag", out ModItem SignusBag))
                {
                    boss1Shop.Add(SignusBag.Type, CheckDowned.signus);
                }
                if (CheckDowned.calamityMod.TryFind("OldDukeBag", out ModItem OldDukeBag))
                {
                    boss1Shop.Add(OldDukeBag.Type, CheckDowned.oldduke);
                }
                if (CheckDowned.calamityMod.TryFind("DevourerofGodsBag", out ModItem DevourerofGodsBag))
                {
                    boss1Shop.Add(DevourerofGodsBag.Type, CheckDowned.dog);
                }
                if (CheckDowned.calamityMod.TryFind("YharonBag", out ModItem YharonBag))
                {
                    boss1Shop.Add(YharonBag.Type, CheckDowned.yharon);
                }
                if (CheckDowned.calamityMod.TryFind("DraedonBag", out ModItem DraedonBag))
                {
                    boss1Shop.Add(DraedonBag.Type, CheckDowned.exomechs);
                }
                if (CheckDowned.calamityMod.TryFind("CalamitasCoffer", out ModItem CalamitasCoffer))
                {
                    boss1Shop.Add(CalamitasCoffer.Type, CheckDowned.scalamitas);
                }
            }
            if (CheckDowned.catalystLoaded)
            {
                if (CheckDowned.catalystMod.TryFind("AstrageldonBag", out ModItem AstrageldonBag))
                {
                    boss1Shop.Add(AstrageldonBag.Type, CheckDowned.geldon);
                }
            }
            if (CheckDowned.infernumLoaded)
            {
                if (CheckDowned.infernumMod.TryFind("BereftVassalBossBag", out ModItem BereftVassalBossBag))
                {
                    boss1Shop.Add(BereftVassalBossBag.Type, CheckDowned.vassal);
                }
            }
            if (CheckDowned.thoriumLoaded)
            {
                if (CheckDowned.thoriumMod.TryFind("ThunderBirdBag", out ModItem ThunderBirdBag))
                {
                    boss1Shop.Add(ThunderBirdBag.Type, CheckDowned.grandbird);
                }
                if (CheckDowned.thoriumMod.TryFind("JellyFishBag", out ModItem JellyFishBag))
                {
                    boss1Shop.Add(JellyFishBag.Type, CheckDowned.queenjelly);
                }
                if (CheckDowned.thoriumMod.TryFind("CountBag", out ModItem CountBag))
                {
                    boss1Shop.Add(CountBag.Type, CheckDowned.viscount);
                }
                if (CheckDowned.thoriumMod.TryFind("GraniteBag", out ModItem GraniteBag))
                {
                    boss1Shop.Add(GraniteBag.Type, CheckDowned.energystorm);
                }
                if (CheckDowned.thoriumMod.TryFind("HeroBag", out ModItem HeroBag))
                {
                    boss1Shop.Add(HeroBag.Type, CheckDowned.buriedchampion);
                }
                if (CheckDowned.thoriumMod.TryFind("ScouterBag", out ModItem ScouterBag))
                {
                    boss1Shop.Add(ScouterBag.Type, CheckDowned.scouter);
                }
                if (CheckDowned.thoriumMod.TryFind("BoreanBag", out ModItem BoreanBag))
                {
                    boss1Shop.Add(BoreanBag.Type, CheckDowned.strider);
                }
                if (CheckDowned.thoriumMod.TryFind("BeholderBag", out ModItem BeholderBag))
                {
                    boss1Shop.Add(BeholderBag.Type, CheckDowned.fallenbeholder);
                }
                if (CheckDowned.thoriumMod.TryFind("LichBag", out ModItem LichBag))
                {
                    boss1Shop.Add(LichBag.Type, CheckDowned.lich);
                }
                if (CheckDowned.thoriumMod.TryFind("AbyssionBag", out ModItem AbyssionBag))
                {
                    boss1Shop.Add(AbyssionBag.Type, CheckDowned.forgottenone);
                }
                if (CheckDowned.thoriumMod.TryFind("RagBag", out ModItem RagBag))
                {
                    boss1Shop.Add(RagBag.Type, CheckDowned.primordials);
                }
            }
            boss1Shop.Register();

            var boss2Shop = new NPCShop(Type, "Modded Treasure Bags 2");
            if (CheckDowned.redemptionLoaded)
            {
                if (CheckDowned.redemptionMod.TryFind("ThornBag", out ModItem ThornBag))
                {
                    boss2Shop.Add(ThornBag.Type, CheckDowned.thorn);
                }
                if (CheckDowned.redemptionMod.TryFind("ErhanBag", out ModItem ErhanBag))
                {
                    boss2Shop.Add(ErhanBag.Type, CheckDowned.erhan);
                }
                if (CheckDowned.redemptionMod.TryFind("KeeperBag", out ModItem KeeperBag))
                {
                    boss2Shop.Add(KeeperBag.Type, CheckDowned.keeper);
                }
                if (CheckDowned.redemptionMod.TryFind("SoIBag", out ModItem SoIBag))
                {
                    boss2Shop.Add(SoIBag.Type, CheckDowned.seed);
                }
                if (CheckDowned.redemptionMod.TryFind("SlayerBag", out ModItem SlayerBag))
                {
                    boss2Shop.Add(SlayerBag.Type, CheckDowned.ks3);
                }
                if (CheckDowned.redemptionMod.TryFind("OmegaCleaverBag", out ModItem OmegaCleaverBag))
                {
                    boss2Shop.Add(OmegaCleaverBag.Type, CheckDowned.cleaver);
                }
                if (CheckDowned.redemptionMod.TryFind("OmegaGigaporaBag", out ModItem OmegaGigaporaBag))
                {
                    boss2Shop.Add(OmegaGigaporaBag.Type, CheckDowned.gigapora);
                }
                if (CheckDowned.redemptionMod.TryFind("OmegaOblitBag", out ModItem OmegaOblitBag))
                {
                    boss2Shop.Add(OmegaOblitBag.Type, CheckDowned.obliterator);
                }
                if (CheckDowned.redemptionMod.TryFind("PZBag", out ModItem PZBag))
                {
                    boss2Shop.Add(PZBag.Type, CheckDowned.zero);
                }
                if (CheckDowned.redemptionMod.TryFind("AkkaBag", out ModItem AkkaBag))
                {
                    boss2Shop.Add(AkkaBag.Type, CheckDowned.duo);
                }
                if (CheckDowned.redemptionMod.TryFind("UkkoBag", out ModItem UkkoBag))
                {
                    boss2Shop.Add(UkkoBag.Type, CheckDowned.duo);
                }
                if (CheckDowned.redemptionMod.TryFind("NebBag", out ModItem NebBag))
                {
                    boss2Shop.Add(NebBag.Type, CheckDowned.nebby);
                }
            }        
            if (CheckDowned.sotsLoaded)
            {
                if (CheckDowned.sotsMod.TryFind("PinkyBag", out ModItem PinkyBag))
                {
                    boss2Shop.Add(PinkyBag.Type, CheckDowned.putridpinky);
                }
                if (CheckDowned.sotsMod.TryFind("CurseBag", out ModItem CurseBag))
                {
                    boss2Shop.Add(CurseBag.Type, CheckDowned.pharaohscurse);
                }
                if (CheckDowned.sotsMod.TryFind("TheAdvisorBossBag", out ModItem TheAdvisorBossBag))
                {
                    boss2Shop.Add(TheAdvisorBossBag.Type, CheckDowned.advisor);
                }
                if (CheckDowned.sotsMod.TryFind("PolarisBossBag", out ModItem PolarisBossBag))
                {
                    boss2Shop.Add(PolarisBossBag.Type, CheckDowned.polaris);
                }
                if (CheckDowned.sotsMod.TryFind("LuxBag", out ModItem LuxBag))
                {
                    boss2Shop.Add(LuxBag.Type, CheckDowned.lux);
                }
                if (CheckDowned.sotsMod.TryFind("SubspaceBag", out ModItem SubspaceBag))
                {
                    boss2Shop.Add(SubspaceBag.Type, CheckDowned.serpent);
                }
            }
            if (CheckDowned.fargosSoulsLoaded)
            {
                if (CheckDowned.fargosSoulsMod.TryFind("TrojanSquirrelBag", out ModItem TrojanSquirrelBag))
                {
                    boss2Shop.Add(TrojanSquirrelBag.Type, CheckDowned.squirrel);
                }
                if (CheckDowned.fargosSoulsMod.TryFind("DeviBag", out ModItem DeviBag))
                {
                    boss2Shop.Add(DeviBag.Type, CheckDowned.devi);
                }
                if (CheckDowned.fargosSoulsMod.TryFind("LifeChallengerBag", out ModItem LifeChallengerBag))
                {
                    boss2Shop.Add(LifeChallengerBag.Type, CheckDowned.lieflight);
                }
                if (CheckDowned.fargosSoulsMod.TryFind("CosmosBag", out ModItem CosmosBag))
                {
                    boss2Shop.Add(CosmosBag.Type, CheckDowned.cosmoschamp);
                }
                if (CheckDowned.fargosSoulsMod.TryFind("AbomBag", out ModItem AbomBag))
                {
                    boss2Shop.Add(AbomBag.Type, CheckDowned.abom);
                }
                if (CheckDowned.fargosSoulsMod.TryFind("MutantBag", out ModItem MutantBag))
                {
                    boss2Shop.Add(MutantBag.Type, CheckDowned.mutant);
                }
            }
            if (CheckDowned.homewardLoaded)
            {
                if (CheckDowned.homewardMod.TryFind("MarquisMoonsquidTreasureBag", out ModItem MarquisMoonsquidTreasureBag))
                {
                    boss2Shop.Add(MarquisMoonsquidTreasureBag.Type, CheckDowned.squid);
                }
                if (CheckDowned.homewardMod.TryFind("PriestessRodTreasureBag", out ModItem PriestessRodTreasureBag))
                {
                    boss2Shop.Add(PriestessRodTreasureBag.Type, CheckDowned.rod);
                }
                if (CheckDowned.homewardMod.TryFind("DiverTreasureBag", out ModItem DiverTreasureBag))
                {
                    boss2Shop.Add(DiverTreasureBag.Type, CheckDowned.diver);
                }
                if (CheckDowned.homewardMod.TryFind("TheMotherbrainTreasureBag", out ModItem TheMotherbrainTreasureBag))
                {
                    boss2Shop.Add(TheMotherbrainTreasureBag.Type, CheckDowned.motherbrain);
                }
                if (CheckDowned.homewardMod.TryFind("WallofShadowTreasureBag", out ModItem WallofShadowTreasureBag))
                {
                    boss2Shop.Add(WallofShadowTreasureBag.Type, CheckDowned.wos);
                }
                if (CheckDowned.homewardMod.TryFind("SlimeGodTreasureBag", out ModItem SlimeGodTreasureBag))
                {
                    boss2Shop.Add(SlimeGodTreasureBag.Type, CheckDowned.sgod);
                }
                if (CheckDowned.homewardMod.TryFind("TheOverwatcherTreasureBag", out ModItem TheOverwatcherTreasureBag))
                {
                    boss2Shop.Add(TheOverwatcherTreasureBag.Type, CheckDowned.overwatcher);
                }
                if (CheckDowned.homewardMod.TryFind("TheLifebringerTreasureBag", out ModItem TheLifebringerTreasureBag))
                {
                    boss2Shop.Add(TheLifebringerTreasureBag.Type, CheckDowned.lifebringer);
                }
                if (CheckDowned.homewardMod.TryFind("TheMaterealizerTreasureBag", out ModItem TheMaterealizerTreasureBag))
                {
                    boss2Shop.Add(TheMaterealizerTreasureBag.Type, CheckDowned.materealizer);
                }
                if (CheckDowned.homewardMod.TryFind("ScarabBeliefTreasureBag", out ModItem ScarabBeliefTreasureBag))
                {
                    boss2Shop.Add(ScarabBeliefTreasureBag.Type, CheckDowned.scarab);
                }
                if (CheckDowned.homewardMod.TryFind("EverlastingFallingWhaleTreasureBag", out ModItem EverlastingFallingWhaleTreasureBag))
                {
                    boss2Shop.Add(EverlastingFallingWhaleTreasureBag.Type, CheckDowned.whale);
                }
                if (CheckDowned.homewardMod.TryFind("TheSonTreasureBag", out ModItem TheSonTreasureBag))
                {
                    boss2Shop.Add(TheSonTreasureBag.Type, CheckDowned.son);
                }
            }
            if (CheckDowned.aqLoaded)
            {
                if (CheckDowned.aqMod.TryFind("CrabsonBag", out ModItem CrabsonBag))
                {
                    boss2Shop.Add(CrabsonBag.Type, CheckDowned.crabson);
                }
                if (CheckDowned.aqMod.TryFind("OmegaStariteBag", out ModItem OmegaStariteBag))
                {
                    boss2Shop.Add(OmegaStariteBag.Type, CheckDowned.omegastarite);
                }
                if (CheckDowned.aqMod.TryFind("DustDevilBag", out ModItem DustDevilBag))
                {
                    boss2Shop.Add(DustDevilBag.Type, CheckDowned.devil);
                }
            }
            boss2Shop.Register();

            var boss3Shop = new NPCShop(Type, "Modded Treasure Bags 3");
            if (CheckDowned.spookyLoaded)
            {
                if (CheckDowned.spookyMod.TryFind("BossBagRotGourd", out ModItem BossBagRotGourd))
                {
                    boss3Shop.Add(BossBagRotGourd.Type, CheckDowned.gourd);
                }
                if (CheckDowned.spookyMod.TryFind("BossBagMoco", out ModItem BossBagMoco))
                {
                    boss3Shop.Add(BossBagMoco.Type, CheckDowned.moco);
                }
                if (CheckDowned.spookyMod.TryFind("BossBagOrroboro", out ModItem BossBagOrroboro))
                {
                    boss3Shop.Add(BossBagOrroboro.Type, CheckDowned.orroboro);
                }
                if (CheckDowned.spookyMod.TryFind("BossBagBigBone", out ModItem BossBagBigBone))
                {
                    boss3Shop.Add(BossBagBigBone.Type, CheckDowned.bigbone);
                }
            }
            if (CheckDowned.consolariaLoaded)
            {
                if (CheckDowned.consolariaMod.TryFind("LepusBag", out ModItem LepusBag))
                {
                    boss3Shop.Add(LepusBag.Type, CheckDowned.lepus);
                }
                if (CheckDowned.consolariaMod.TryFind("TurkorBag", out ModItem TurkorBag))
                {
                    boss3Shop.Add(TurkorBag.Type, CheckDowned.turkor);
                }
                if (CheckDowned.consolariaMod.TryFind("OcramBag", out ModItem OcramBag))
                {
                    boss3Shop.Add(OcramBag.Type, CheckDowned.ocram);
                }
            }
            if (CheckDowned.polaritiesLoaded)
            {
                if (CheckDowned.polaritiesMod.TryFind("StormCloudfishBag", out ModItem StormCloudfishBag))
                {
                    boss3Shop.Add(StormCloudfishBag.Type, CheckDowned.cloudfish);
                }
                if (CheckDowned.polaritiesMod.TryFind("StarConstructBag", out ModItem StarConstructBag))
                {
                    boss3Shop.Add(StarConstructBag.Type, CheckDowned.construct);
                }
                if (CheckDowned.polaritiesMod.TryFind("GigabatBag", out ModItem GigabatBag))
                {
                    boss3Shop.Add(GigabatBag.Type, CheckDowned.gigabat);
                }
                if (CheckDowned.polaritiesMod.TryFind("SunPixieBag", out ModItem SunPixieBag))
                {
                    boss3Shop.Add(SunPixieBag.Type, CheckDowned.sunpixie);
                }
                if (CheckDowned.polaritiesMod.TryFind("EsophageBag", out ModItem EsophageBag))
                {
                    boss3Shop.Add(EsophageBag.Type, CheckDowned.esophage);
                }
                if (CheckDowned.polaritiesMod.TryFind("ConvectiveWandererBag", out ModItem ConvectiveWandererBag))
                {
                    boss3Shop.Add(ConvectiveWandererBag.Type, CheckDowned.wanderer);
                }
            }
            if (CheckDowned.vitalityLoaded)
            {
                if (CheckDowned.vitalityMod.TryFind("StormCloudBossBag", out ModItem StormCloudBossBag))
                {
                    boss3Shop.Add(StormCloudBossBag.Type, CheckDowned.stormcloud);
                }
                if (CheckDowned.vitalityMod.TryFind("GrandAntlionBossBag", out ModItem GrandAntlionBossBag))
                {
                    boss3Shop.Add(GrandAntlionBossBag.Type, CheckDowned.grandantlion);
                }
                if (CheckDowned.vitalityMod.TryFind("GemstoneElementalBossBag", out ModItem GemstoneElementalBossBag))
                {
                    boss3Shop.Add(GemstoneElementalBossBag.Type, CheckDowned.gemstone);
                }
                if (CheckDowned.vitalityMod.TryFind("MoonlightDragonflyBossBag", out ModItem MoonlightDragonflyBossBag))
                {
                    boss3Shop.Add(MoonlightDragonflyBossBag.Type, CheckDowned.dragonfly);
                }
                if (CheckDowned.vitalityMod.TryFind("DreadnaughtBossBag", out ModItem DreadnaughtBossBag))
                {
                    boss3Shop.Add(DreadnaughtBossBag.Type, CheckDowned.dreadnaught);
                }
                if (CheckDowned.vitalityMod.TryFind("AnarchulesBeetleBossBag", out ModItem AnarchulesBeetleBossBag))
                {
                    boss3Shop.Add(AnarchulesBeetleBossBag.Type, CheckDowned.anarchulesbeetle);
                }
                if (CheckDowned.vitalityMod.TryFind("ChaosbringerBossBag", out ModItem ChaosbringerBossBag))
                {
                    boss3Shop.Add(ChaosbringerBossBag.Type, CheckDowned.chaosbringer);
                }
                if (CheckDowned.vitalityMod.TryFind("PaladinSpiritBossBag", out ModItem PaladinSpiritBossBag))
                {
                    boss3Shop.Add(PaladinSpiritBossBag.Type, CheckDowned.paladin);
                }
            }
            if (CheckDowned.terrorbornLoaded)
            {
                if (CheckDowned.terrorbornMod.TryFind("II_TreasureBag", out ModItem II_TreasureBag))
                {
                    boss3Shop.Add(II_TreasureBag.Type, CheckDowned.incarnate);
                }
                if (CheckDowned.terrorbornMod.TryFind("TT_TreasureBag", out ModItem TT_TreasureBag))
                {
                    boss3Shop.Add(TT_TreasureBag.Type, CheckDowned.titan);
                }
                if (CheckDowned.terrorbornMod.TryFind("DS_TreasureBag", out ModItem DS_TreasureBag))
                {
                    boss3Shop.Add(DS_TreasureBag.Type, CheckDowned.dunestock);
                }
                if (CheckDowned.terrorbornMod.TryFind("SC_TreasureBag", out ModItem SC_TreasureBag))
                {
                    boss3Shop.Add(SC_TreasureBag.Type, CheckDowned.crawler);
                }
                if (CheckDowned.terrorbornMod.TryFind("HC_TreasureBag", out ModItem HC_TreasureBag))
                {
                    boss3Shop.Add(HC_TreasureBag.Type, CheckDowned.constructor);
                }
                if (CheckDowned.terrorbornMod.TryFind("PI_TreasureBag", out ModItem PI_TreasureBag))
                {
                    boss3Shop.Add(PI_TreasureBag.Type, CheckDowned.p1);
                }
            }
            boss3Shop.Register();

            var modCratesShop = new NPCShop(Type, "Modded Crates & Grab Bags");
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
            modCratesShop.Register();

            var modOreShop = new NPCShop(Type, "Modded Ores & Bars");
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
            modOreShop.Register();
        }
    }
}
