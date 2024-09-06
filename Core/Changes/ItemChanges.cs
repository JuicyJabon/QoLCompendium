using Terraria.GameContent.Creative;

namespace QoLCompendium.Core.Changes
{
    public class DontConsumeSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            List<int> ModdedBossAndEventSummons = new()
            {
                //Aequus
                Common.GetModItem(ModConditions.aequusMod, "GalacticStarfruit"),
                //AFKPETS
                Common.GetModItem(ModConditions.afkpetsMod, "AncientSand"),
                Common.GetModItem(ModConditions.afkpetsMod, "BlackenedHeart"),
                Common.GetModItem(ModConditions.afkpetsMod, "BrokenDelftPlate"),
                Common.GetModItem(ModConditions.afkpetsMod, "CookingBook"),
                Common.GetModItem(ModConditions.afkpetsMod, "CorruptedServer"),
                Common.GetModItem(ModConditions.afkpetsMod, "DemonicAnalysis"),
                Common.GetModItem(ModConditions.afkpetsMod, "DesertMirror"),
                Common.GetModItem(ModConditions.afkpetsMod, "DuckWhistle"),
                Common.GetModItem(ModConditions.afkpetsMod, "FallingSlimeReplica"),
                Common.GetModItem(ModConditions.afkpetsMod, "FrozenSkull"),
                Common.GetModItem(ModConditions.afkpetsMod, "GoldenKingSlimeIdol"),
                Common.GetModItem(ModConditions.afkpetsMod, "GoldenSkull"),
                Common.GetModItem(ModConditions.afkpetsMod, "HaniwaIdol"),
                Common.GetModItem(ModConditions.afkpetsMod, "HolographicSlimeReplica"),
                Common.GetModItem(ModConditions.afkpetsMod, "IceBossCrystal"),
                Common.GetModItem(ModConditions.afkpetsMod, "MagicWand"),
                Common.GetModItem(ModConditions.afkpetsMod, "NightmareFuel"),
                Common.GetModItem(ModConditions.afkpetsMod, "PinkDiamond"),
                Common.GetModItem(ModConditions.afkpetsMod, "PlantAshContainer"),
                Common.GetModItem(ModConditions.afkpetsMod, "PreyTrackingChip"),
                Common.GetModItem(ModConditions.afkpetsMod, "RoastChickenPlate"),
                Common.GetModItem(ModConditions.afkpetsMod, "SeveredClothierHead"),
                Common.GetModItem(ModConditions.afkpetsMod, "SeveredDryadHead"),
                Common.GetModItem(ModConditions.afkpetsMod, "SeveredHarpyHead"),
                Common.GetModItem(ModConditions.afkpetsMod, "ShogunSlimesHelmet"),
                Common.GetModItem(ModConditions.afkpetsMod, "SlimeinaGlassCube"),
                Common.GetModItem(ModConditions.afkpetsMod, "SlimyWarBanner"),
                Common.GetModItem(ModConditions.afkpetsMod, "SoulofAgonyinaBottle"),
                Common.GetModItem(ModConditions.afkpetsMod, "SpineWormFood"),
                Common.GetModItem(ModConditions.afkpetsMod, "SpiritofFunPot"),
                Common.GetModItem(ModConditions.afkpetsMod, "SpiritualHeart"),
                Common.GetModItem(ModConditions.afkpetsMod, "StoryBook"),
                Common.GetModItem(ModConditions.afkpetsMod, "SuspiciousLookingChest"),
                Common.GetModItem(ModConditions.afkpetsMod, "SwissChocolate"),
                Common.GetModItem(ModConditions.afkpetsMod, "TiedBunny"),
                Common.GetModItem(ModConditions.afkpetsMod, "TinyMeatIdol"),
                Common.GetModItem(ModConditions.afkpetsMod, "TradeDeal"),
                Common.GetModItem(ModConditions.afkpetsMod, "UnstableRainbowCookie"),
                Common.GetModItem(ModConditions.afkpetsMod, "UntoldBurial"),
                //Awful Garbage
                Common.GetModItem(ModConditions.awfulGarbageMod, "InsectOnAStick"),
                Common.GetModItem(ModConditions.awfulGarbageMod, "PileOfFakeBones"),
                //Blocks Core Boss
                Common.GetModItem(ModConditions.blocksCoreBossMod, "ChargedOrb"),
                Common.GetModItem(ModConditions.blocksCoreBossMod, "ChargedOrbCrim"),
                //Consolaria
                Common.GetModItem(ModConditions.consolariaMod, "SuspiciousLookingEgg"),
                Common.GetModItem(ModConditions.consolariaMod, "CursedStuffing"),
                Common.GetModItem(ModConditions.consolariaMod, "SuspiciousLookingSkull"),
                Common.GetModItem(ModConditions.consolariaMod, "Wishbone"),
                //Coralite
                Common.GetModItem(ModConditions.coraliteMod, "RedBerry"),
                //Edorbis
                Common.GetModItem(ModConditions.edorbisMod, "BiomechanicalMatter"),
                Common.GetModItem(ModConditions.edorbisMod, "CursedSoul"),
                Common.GetModItem(ModConditions.edorbisMod, "KelviniteRadar"),
                Common.GetModItem(ModConditions.edorbisMod, "SlayerTrophy"),
                Common.GetModItem(ModConditions.edorbisMod, "ThePrettiestFlower"),
                //Enchanted Moons
                Common.GetModItem(ModConditions.enchantedMoonsMod, "BlueMedallion"),
                Common.GetModItem(ModConditions.enchantedMoonsMod, "CherryAmulet"),
                Common.GetModItem(ModConditions.enchantedMoonsMod, "HarvestLantern"),
                Common.GetModItem(ModConditions.enchantedMoonsMod, "MintRing"),
                //Everjade
                Common.GetModItem(ModConditions.everjadeMod, "FestivalLantern"),
                //Excelsior
                Common.GetModItem(ModConditions.excelsiorMod, "ReflectiveIceShard"),
                Common.GetModItem(ModConditions.excelsiorMod, "PlanetaryTrackingDevice"),
                //Exxo Avalon Origins
                Common.GetModItem(ModConditions.exxoAvalonOriginsMod, "BloodyAmulet"),
                Common.GetModItem(ModConditions.exxoAvalonOriginsMod, "InfestedCarcass"),
                Common.GetModItem(ModConditions.exxoAvalonOriginsMod, "DesertHorn"),
                Common.GetModItem(ModConditions.exxoAvalonOriginsMod, "GoblinRetreatOrder"),
                Common.GetModItem(ModConditions.exxoAvalonOriginsMod, "FalseTreasureMap"),
                Common.GetModItem(ModConditions.exxoAvalonOriginsMod, "OddFertilizer"),
                //Fargos Mutant
                    //ABOMINATIONN NPC ITEMS
                Common.GetModItem(ModConditions.fargosMutantMod, "Anemometer"),
                Common.GetModItem(ModConditions.fargosMutantMod, "BatteredClub"),
                Common.GetModItem(ModConditions.fargosMutantMod, "BetsyEgg"),
                Common.GetModItem(ModConditions.fargosMutantMod, "FestiveOrnament"),
                Common.GetModItem(ModConditions.fargosMutantMod, "ForbiddenScarab"),
                Common.GetModItem(ModConditions.fargosMutantMod, "ForbiddenTome"),
                Common.GetModItem(ModConditions.fargosMutantMod, "HeadofMan"),
                Common.GetModItem(ModConditions.fargosMutantMod, "IceKingsRemains"),
                Common.GetModItem(ModConditions.fargosMutantMod, "MartianMemoryStick"),
                Common.GetModItem(ModConditions.fargosMutantMod, "MatsuriLantern"),
                Common.GetModItem(ModConditions.fargosMutantMod, "NaughtyList"),
                Common.GetModItem(ModConditions.fargosMutantMod, "PartyInvite"),
                Common.GetModItem(ModConditions.fargosMutantMod, "PillarSummon"),
                Common.GetModItem(ModConditions.fargosMutantMod, "RunawayProbe"),
                Common.GetModItem(ModConditions.fargosMutantMod, "SlimyBarometer"),
                Common.GetModItem(ModConditions.fargosMutantMod, "SpentLantern"),
                Common.GetModItem(ModConditions.fargosMutantMod, "SpookyBranch"),
                Common.GetModItem(ModConditions.fargosMutantMod, "SuspiciousLookingScythe"),
                Common.GetModItem(ModConditions.fargosMutantMod, "WeatherBalloon"),
                    //DEVIANTT NPC ITEMS
                Common.GetModItem(ModConditions.fargosMutantMod, "AmalgamatedSkull"),
                Common.GetModItem(ModConditions.fargosMutantMod, "AmalgamatedSpirit"),
                Common.GetModItem(ModConditions.fargosMutantMod, "AthenianIdol"),
                Common.GetModItem(ModConditions.fargosMutantMod, "AttractiveOre"),
                Common.GetModItem(ModConditions.fargosMutantMod, "BloodSushiPlatter"),
                Common.GetModItem(ModConditions.fargosMutantMod, "BloodUrchin"),
                Common.GetModItem(ModConditions.fargosMutantMod, "CloudSnack"),
                Common.GetModItem(ModConditions.fargosMutantMod, "ClownLicense"),
                Common.GetModItem(ModConditions.fargosMutantMod, "CoreoftheFrostCore"),
                Common.GetModItem(ModConditions.fargosMutantMod, "CorruptChest"),
                Common.GetModItem(ModConditions.fargosMutantMod, "CrimsonChest"),
                Common.GetModItem(ModConditions.fargosMutantMod, "DemonicPlushie"),
                Common.GetModItem(ModConditions.fargosMutantMod, "DilutedRainbowMatter"),
                Common.GetModItem(ModConditions.fargosMutantMod, "Eggplant"),
                Common.GetModItem(ModConditions.fargosMutantMod, "ForbiddenForbiddenFragment"),
                Common.GetModItem(ModConditions.fargosMutantMod, "GnomeHat"),
                Common.GetModItem(ModConditions.fargosMutantMod, "GoblinScrap"),
                Common.GetModItem(ModConditions.fargosMutantMod, "GoldenSlimeCrown"),
                Common.GetModItem(ModConditions.fargosMutantMod, "GrandCross"),
                Common.GetModItem(ModConditions.fargosMutantMod, "HallowChest"),
                Common.GetModItem(ModConditions.fargosMutantMod, "HeartChocolate"),
                Common.GetModItem(ModConditions.fargosMutantMod, "HemoclawCrab"),
                Common.GetModItem(ModConditions.fargosMutantMod, "HolyGrail"),
                Common.GetModItem(ModConditions.fargosMutantMod, "JungleChest"),
                Common.GetModItem(ModConditions.fargosMutantMod, "LeesHeadband"),
                Common.GetModItem(ModConditions.fargosMutantMod, "MothLamp"),
                Common.GetModItem(ModConditions.fargosMutantMod, "MothronEgg"),
                Common.GetModItem(ModConditions.fargosMutantMod, "Pincushion"),
                Common.GetModItem(ModConditions.fargosMutantMod, "PinkSlimeCrown"),
                Common.GetModItem(ModConditions.fargosMutantMod, "PirateFlag"),
                Common.GetModItem(ModConditions.fargosMutantMod, "PlunderedBooty"),
                Common.GetModItem(ModConditions.fargosMutantMod, "RuneOrb"),
                Common.GetModItem(ModConditions.fargosMutantMod, "ShadowflameIcon"),
                Common.GetModItem(ModConditions.fargosMutantMod, "SlimyLockBox"),
                Common.GetModItem(ModConditions.fargosMutantMod, "SuspiciousLookingChest"),
                Common.GetModItem(ModConditions.fargosMutantMod, "SuspiciousLookingLure"),
                Common.GetModItem(ModConditions.fargosMutantMod, "WormSnack"),
                    //MUTANT NPC ITEMS
                Common.GetModItem(ModConditions.fargosMutantMod, "Abeemination2"),
                Common.GetModItem(ModConditions.fargosMutantMod, "AncientSeal"),
                Common.GetModItem(ModConditions.fargosMutantMod, "CelestialSigil2"),
                Common.GetModItem(ModConditions.fargosMutantMod, "CultistSummon"),
                Common.GetModItem(ModConditions.fargosMutantMod, "DeathBringerFairy"),
                Common.GetModItem(ModConditions.fargosMutantMod, "DeerThing2"),
                Common.GetModItem(ModConditions.fargosMutantMod, "FleshyDoll"),
                Common.GetModItem(ModConditions.fargosMutantMod, "GoreySpine"),
                Common.GetModItem(ModConditions.fargosMutantMod, "JellyCrystal"),
                Common.GetModItem(ModConditions.fargosMutantMod, "LihzahrdPowerCell2"),
                Common.GetModItem(ModConditions.fargosMutantMod, "MechanicalAmalgam"),
                Common.GetModItem(ModConditions.fargosMutantMod, "MechEye"),
                Common.GetModItem(ModConditions.fargosMutantMod, "MechSkull"),
                Common.GetModItem(ModConditions.fargosMutantMod, "MechWorm"),
                Common.GetModItem(ModConditions.fargosMutantMod, "MutantVoodoo"),
                Common.GetModItem(ModConditions.fargosMutantMod, "PlanterasFruit"),
                Common.GetModItem(ModConditions.fargosMutantMod, "PrismaticPrimrose"),
                Common.GetModItem(ModConditions.fargosMutantMod, "SlimyCrown"),
                Common.GetModItem(ModConditions.fargosMutantMod, "SuspiciousEye"),
                Common.GetModItem(ModConditions.fargosMutantMod, "SuspiciousSkull"),
                Common.GetModItem(ModConditions.fargosMutantMod, "TruffleWorm2"),
                Common.GetModItem(ModConditions.fargosMutantMod, "WormyFood"),
                //Fargos Souls
                Common.GetModItem(ModConditions.fargosSoulsMod, "AbomsCurse"),
                Common.GetModItem(ModConditions.fargosSoulsMod, "ChampionySigil"),
                Common.GetModItem(ModConditions.fargosSoulsMod, "CoffinSummon"),
                Common.GetModItem(ModConditions.fargosSoulsMod, "DevisCurse"),
                Common.GetModItem(ModConditions.fargosSoulsMod, "FragilePixieLamp"),
                Common.GetModItem(ModConditions.fargosSoulsMod, "MechLure"),
                Common.GetModItem(ModConditions.fargosSoulsMod, "MutantsCurse"),
                Common.GetModItem(ModConditions.fargosSoulsMod, "SquirrelCoatofArms"),
                //Fargos DLC
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "AbandonedRemote"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "ABombInMyNation"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "AstrumCor"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "BirbPheromones"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "BlightedEye"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "BloodyWorm"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "ChunkyStardust"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "ClamPearl"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "ColossalTentacle"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "CryingKey"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "DeepseaProteinShake"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "DefiledCore"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "DefiledShard"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "DragonEgg"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "EyeofExtinction"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "FriedDoll"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "HiveTumor"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "LetterofKos"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "MaulerSkull"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "MedallionoftheDesert"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "MurkySludge"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "NoisyWhistle"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "NuclearChunk"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "OphiocordycipitaceaeSprout"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "PlaguedWalkieTalkie"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "PolterplasmicBeacon"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "PortableCodebreaker"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "QuakeIdol"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "RedStainedWormFood"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "RiftofKos"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "SeeFood"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "SirensPearl"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "SomeKindofSpaceWorm"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "StormIdol"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "SulphurBearTrap"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "WormFoodofKos"),
                Common.GetModItem(ModConditions.fargosSoulsDLCMod, "WyrmTablet"),
                //Fargos Extras
                Common.GetModItem(ModConditions.fargosSoulsExtrasMod, "PandorasBox"),
                //Gensokyo
                Common.GetModItem(ModConditions.gensokyoMod, "AliceMargatroidSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "CirnoSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "EternityLarvaSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "HinaKagiyamaSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "KaguyaHouraisanSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "LilyWhiteSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "MayumiJoutouguuSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "MedicineMelancholySpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "MinamitsuMurasaSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "NazrinSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "NitoriKawashiroSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "RumiaSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "SakuyaIzayoiSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "SeijaKijinSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "SeiranSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "SekibankiSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "TenshiHinanawiSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "ToyosatomimiNoMikoSpawner"),
                Common.GetModItem(ModConditions.gensokyoMod, "UtsuhoReiujiSpawner"),
                //Homeward Journey
                Common.GetModItem(ModConditions.homewardJourneyMod, "CannedSoulofFlight"),
                Common.GetModItem(ModConditions.homewardJourneyMod, "MetalSpine"),
                Common.GetModItem(ModConditions.homewardJourneyMod, "SouthernPotting"),
                Common.GetModItem(ModConditions.homewardJourneyMod, "SunlightCrown"),
                Common.GetModItem(ModConditions.homewardJourneyMod, "UltimateTorch"),
                Common.GetModItem(ModConditions.homewardJourneyMod, "UnstableGlobe"),
                //Martains Order
                Common.GetModItem(ModConditions.martainsOrderMod, "FrigidEgg"),
                Common.GetModItem(ModConditions.martainsOrderMod, "SuspiciousLookingCloud"),
                Common.GetModItem(ModConditions.martainsOrderMod, "CarnageSuspiciousRazor"),
                Common.GetModItem(ModConditions.martainsOrderMod, "VoidWorm"),
                Common.GetModItem(ModConditions.martainsOrderMod, "LuminiteSlimeCrown"),
                Common.GetModItem(ModConditions.martainsOrderMod, "LuminiteEye"),
                Common.GetModItem(ModConditions.martainsOrderMod, "JunglesLastTreasure"),
                Common.GetModItem(ModConditions.martainsOrderMod, "TeslaRemote"),
                //Medial Rift
                Common.GetModItem(ModConditions.medialRiftMod, "RemoteOfTheMetalHeads"),
                //Metroid Mod
                Common.GetModItem(ModConditions.metroidMod, "GoldenTorizoSummon"),
                Common.GetModItem(ModConditions.metroidMod, "KraidSummon"),
                Common.GetModItem(ModConditions.metroidMod, "NightmareSummon"),
                Common.GetModItem(ModConditions.metroidMod, "OmegaPirateSummon"),
                Common.GetModItem(ModConditions.metroidMod, "PhantoonSummon"),
                Common.GetModItem(ModConditions.metroidMod, "SerrisSummon"),
                Common.GetModItem(ModConditions.metroidMod, "TorizoSummon"),
                //Ophioid
                Common.GetModItem(ModConditions.ophioidMod, "DeadFungusbug"),
                Common.GetModItem(ModConditions.ophioidMod, "InfestedCompost"),
                Common.GetModItem(ModConditions.ophioidMod, "LivingCarrion"),
                //Qwerty
                Common.GetModItem(ModConditions.qwertyMod, "AncientEmblem"),
                Common.GetModItem(ModConditions.qwertyMod, "B4Summon"),
                Common.GetModItem(ModConditions.qwertyMod, "BladeBossSummon"),
                Common.GetModItem(ModConditions.qwertyMod, "DinoEgg"),
                //Common.GetModItem(ModConditions.qwertyMod, "FortressBossSummon"),
                //Common.GetModItem(ModConditions.qwertyMod, "GodSealKeycard"),
                Common.GetModItem(ModConditions.qwertyMod, "HydraSummon"),
                Common.GetModItem(ModConditions.qwertyMod, "RitualInterupter"),
                Common.GetModItem(ModConditions.qwertyMod, "SummoningRune"),
                //Redemption
                Common.GetModItem(ModConditions.redemptionMod, "EaglecrestSpelltome"),
                Common.GetModItem(ModConditions.redemptionMod, "EggCrown"),
                Common.GetModItem(ModConditions.redemptionMod, "FowlWarHorn"),
                //Secrets of the Shadows
                Common.GetModItem(ModConditions.secretsOfTheShadowsMod, "ElectromagneticLure"),
                Common.GetModItem(ModConditions.secretsOfTheShadowsMod, "SuspiciousLookingCandle"),
                Common.GetModItem(ModConditions.secretsOfTheShadowsMod, "JarOfPeanuts"),
                Common.GetModItem(ModConditions.secretsOfTheShadowsMod, "CatalystBomb"),
                //Shadows of Abaddon
                Common.GetModItem(ModConditions.shadowsOfAbaddonMod, "PumpkinLantern"),
                Common.GetModItem(ModConditions.shadowsOfAbaddonMod, "PrimordiaSummon"),
                Common.GetModItem(ModConditions.shadowsOfAbaddonMod, "AbaddonSummon"),
                Common.GetModItem(ModConditions.shadowsOfAbaddonMod, "SerpentSummon"),
                Common.GetModItem(ModConditions.shadowsOfAbaddonMod, "SoranEmblem"),
                Common.GetModItem(ModConditions.shadowsOfAbaddonMod, "HeirsAuthority"),
                Common.GetModItem(ModConditions.shadowsOfAbaddonMod, "PigmanBanner"),
                Common.GetModItem(ModConditions.shadowsOfAbaddonMod, "SandstormMedallion"),
                //Spirit
                Common.GetModItem(ModConditions.spiritMod, "DistressJellyItem"),
                Common.GetModItem(ModConditions.spiritMod, "GladeWreath"),
                Common.GetModItem(ModConditions.spiritMod, "ReachBossSummon"),
                Common.GetModItem(ModConditions.spiritMod, "JewelCrown"),
                Common.GetModItem(ModConditions.spiritMod, "BlackPearl"),
                Common.GetModItem(ModConditions.spiritMod, "BlueMoonSpawn"),
                Common.GetModItem(ModConditions.spiritMod, "DuskCrown"),
                Common.GetModItem(ModConditions.spiritMod, "CursedCloth"),
                Common.GetModItem(ModConditions.spiritMod, "StoneSkin"),
                Common.GetModItem(ModConditions.spiritMod, "MartianTransmitter"),
                //Spooky
                Common.GetModItem(ModConditions.spookyMod, "Fertilizer"),
                Common.GetModItem(ModConditions.spookyMod, "RottenSeed"),
                //Storms Additions
                Common.GetModItem(ModConditions.stormsAdditionsMod, "AridBossSummon"),
                Common.GetModItem(ModConditions.stormsAdditionsMod, "MoonlingSummoner"),
                Common.GetModItem(ModConditions.stormsAdditionsMod, "StormBossSummoner"),
                Common.GetModItem(ModConditions.stormsAdditionsMod, "UltimateBossSummoner"),
                //Supernova
                Common.GetModItem(ModConditions.supernovaMod, "BugOnAStick"),
                Common.GetModItem(ModConditions.supernovaMod, "EerieCrystal"),
                //Thorium
                Common.GetModItem(ModConditions.thoriumMod, "StormFlare"),
                Common.GetModItem(ModConditions.thoriumMod, "JellyfishResonator"),
                Common.GetModItem(ModConditions.thoriumMod, "UnstableCore"),
                Common.GetModItem(ModConditions.thoriumMod, "AncientBlade"),
                Common.GetModItem(ModConditions.thoriumMod, "StarCaller"),
                Common.GetModItem(ModConditions.thoriumMod, "StriderTear"),
                Common.GetModItem(ModConditions.thoriumMod, "VoidLens"),
                Common.GetModItem(ModConditions.thoriumMod, "AromaticBulb"),
                Common.GetModItem(ModConditions.thoriumMod, "AbyssalShadow2"),
                Common.GetModItem(ModConditions.thoriumMod, "DoomSayersCoin"),
                Common.GetModItem(ModConditions.thoriumMod, "FreshBrain"),
                Common.GetModItem(ModConditions.thoriumMod, "RottingSpore"),
                Common.GetModItem(ModConditions.thoriumMod, "IllusionaryGlass"),
                //Utric
                Common.GetModItem(ModConditions.uhtricMod, "RareGeode"),
                Common.GetModItem(ModConditions.uhtricMod, "SnowyCharcoal"),
                Common.GetModItem(ModConditions.uhtricMod, "CosmicLure"),
                //Universe of Swords
                Common.GetModItem(ModConditions.universeOfSwordsMod, "SwordBossSummon"),
                //Valhalla
                Common.GetModItem(ModConditions.valhallaMod, "HeavensSeal"),
                Common.GetModItem(ModConditions.valhallaMod, "HellishRadish"),
                //Vitality
                Common.GetModItem(ModConditions.vitalityMod, "CloudCore"),
                Common.GetModItem(ModConditions.vitalityMod, "AncientCrown"),
                Common.GetModItem(ModConditions.vitalityMod, "MultigemCluster"),
                Common.GetModItem(ModConditions.vitalityMod, "MoonlightLotusFlower"),
                Common.GetModItem(ModConditions.vitalityMod, "Dreadcandle"),
                Common.GetModItem(ModConditions.vitalityMod, "MeatyMushroom"),
                Common.GetModItem(ModConditions.vitalityMod, "AnarchyCrystal"),
                Common.GetModItem(ModConditions.vitalityMod, "TotemofChaos"),
                Common.GetModItem(ModConditions.vitalityMod, "MartianRadio"),
                Common.GetModItem(ModConditions.vitalityMod, "SpiritBox"),
                //Wayfair
                Common.GetModItem(ModConditions.wayfairContentMod, "MagicFertilizer"),
                //Zylon
                Common.GetModItem(ModConditions.zylonMod, "ForgottenFlame"),
                Common.GetModItem(ModConditions.zylonMod, "SlimyScepter")
            };

            if (Common.VanillaBossAndEventSummons.Contains(entity.type) && QoLCompendium.mainServerConfig.EndlessBossSummons && !ModConditions.calamityLoaded)
            {
                return true;
            }
            else if (ModdedBossAndEventSummons.Contains(entity.type) && QoLCompendium.mainServerConfig.EndlessBossSummons)
            {
                return true;
            }
            return false;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class DontConsumeVanillaRightClickSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return (entity.type == ItemID.DD2ElderCrystal || entity.type == ItemID.LihzahrdPowerCell) && QoLCompendium.mainServerConfig.EndlessBossSummons;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            item.maxStack = 1;
        }

        public override bool ConsumeItem(Item item, Player player)
        {
            return false;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }

    public class OtherItemStuff : GlobalItem
    {
        public override void Load()
        {
            On_Player.ItemCheck_UseMiningTools_TryHittingWall += (orig, player, item, x, y) =>
            {
                orig.Invoke(player, item, x, y);
                if (player.itemTime == item.useTime / 2)
                    player.itemTime = (int)Math.Max(1, (1f - QoLCompendium.mainServerConfig.IncreaseToolSpeed) * (item.useTime / 2f));
            };
        }

        public override void SetDefaults(Item item)
        {
            if (QoLCompendium.mainServerConfig.NoDeveloperSetsFromBossBags && ItemID.Sets.BossBag[item.type])
            {
                ItemID.Sets.PreHardmodeLikeBossBag[item.type] = true;
            }

            if (QoLCompendium.mainServerConfig.IncreaseMaxStack > 0 && item.maxStack > 10 && item.maxStack != 100 && !(item.type >= ItemID.CopperCoin && item.type <= ItemID.PlatinumCoin))
            {
                item.maxStack = QoLCompendium.mainServerConfig.IncreaseMaxStack;
            }

            if (QoLCompendium.mainServerConfig.StackableQuestItems && item.questItem == true && QoLCompendium.mainServerConfig.IncreaseMaxStack > 0)
            {
                item.maxStack = QoLCompendium.mainServerConfig.IncreaseMaxStack;
            }

            if (QoLCompendium.mainServerConfig.BossItemTransmutation)
            {
                //King Slime
                if (item.type == ItemID.NinjaHood)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.NinjaShirt;
                if (item.type == ItemID.NinjaShirt)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.NinjaPants;
                if (item.type == ItemID.NinjaPants)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.NinjaHood;

                //Queen Bee
                if (item.type == ItemID.BeeKeeper)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.BeesKnees;
                if (item.type == ItemID.BeesKnees)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.BeeGun;
                if (item.type == ItemID.BeeGun)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.BeeKeeper;
                //Bee Vanity
                if (item.type == ItemID.BeeHat)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.BeeShirt;
                if (item.type == ItemID.BeeShirt)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.BeePants;
                if (item.type == ItemID.BeePants)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.BeeHat;

                //Deerclops
                if (item.type == ItemID.LucyTheAxe)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.PewMaticHorn;
                if (item.type == ItemID.PewMaticHorn)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.WeatherPain;
                if (item.type == ItemID.WeatherPain)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.HoundiusShootius;
                if (item.type == ItemID.HoundiusShootius)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.LucyTheAxe;

                //Wall of Flesh
                if (item.type == ItemID.BreakerBlade)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.ClockworkAssaultRifle;
                if (item.type == ItemID.ClockworkAssaultRifle)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.LaserRifle;
                if (item.type == ItemID.LaserRifle)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.FireWhip;
                if (item.type == ItemID.FireWhip)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.BreakerBlade;

                //Queen Slime
                if (item.type == ItemID.CrystalNinjaHelmet)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.CrystalNinjaChestplate;
                if (item.type == ItemID.CrystalNinjaChestplate)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.CrystalNinjaLeggings;
                if (item.type == ItemID.CrystalNinjaLeggings)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.CrystalNinjaHelmet;

                //Plantera
                if (item.type == ItemID.Seedler)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.FlowerPow;
                if (item.type == ItemID.FlowerPow)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.GrenadeLauncher;
                if (item.type == ItemID.GrenadeLauncher)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.VenusMagnum;
                if (item.type == ItemID.VenusMagnum)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.NettleBurst;
                if (item.type == ItemID.NettleBurst)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.LeafBlower;
                if (item.type == ItemID.LeafBlower)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.WaspGun;
                if (item.type == ItemID.WaspGun)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.Seedler;

                //Golem
                if (item.type == ItemID.GolemFist)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.PossessedHatchet;
                if (item.type == ItemID.PossessedHatchet)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.Stynger;
                if (item.type == ItemID.Stynger)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.HeatRay;
                if (item.type == ItemID.HeatRay)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.StaffofEarth;
                if (item.type == ItemID.StaffofEarth)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.SunStone;
                if (item.type == ItemID.SunStone)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.EyeoftheGolem;
                if (item.type == ItemID.EyeoftheGolem)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.GolemFist;

                //Duke Fishron
                if (item.type == ItemID.Flairon)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.Tsunami;
                if (item.type == ItemID.Tsunami)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.RazorbladeTyphoon;
                if (item.type == ItemID.RazorbladeTyphoon)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.BubbleGun;
                if (item.type == ItemID.BubbleGun)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.TempestStaff;
                if (item.type == ItemID.TempestStaff)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.Flairon;

                //Empress of Light
                if (item.type == ItemID.PiercingStarlight)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.FairyQueenRangedItem;
                if (item.type == ItemID.FairyQueenRangedItem)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.FairyQueenMagicItem;
                if (item.type == ItemID.FairyQueenMagicItem)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.RainbowWhip;
                if (item.type == ItemID.RainbowWhip)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.PiercingStarlight;

                //Moon Lord
                if (item.type == ItemID.Terrarian)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.Meowmere;
                if (item.type == ItemID.Meowmere)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.StarWrath;
                if (item.type == ItemID.StarWrath)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.Celeb2;
                if (item.type == ItemID.Celeb2)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.SDMG;
                if (item.type == ItemID.SDMG)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.LastPrism;
                if (item.type == ItemID.LastPrism)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.LunarFlareBook;
                if (item.type == ItemID.LunarFlareBook)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.RainbowCrystalStaff;
                if (item.type == ItemID.RainbowCrystalStaff)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.MoonlordTurretStaff;
                if (item.type == ItemID.MoonlordTurretStaff)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.Terrarian;

                //EVENT BOSSES

                //Ogre
                if (item.type == ItemID.DD2SquireDemonSword)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.MonkStaffT1;
                if (item.type == ItemID.MonkStaffT1)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.MonkStaffT2;
                if (item.type == ItemID.MonkStaffT2)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.DD2PhoenixBow;
                if (item.type == ItemID.DD2PhoenixBow)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.BookStaff;
                if (item.type == ItemID.BookStaff)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.DD2SquireDemonSword;

                //Betsy
                if (item.type == ItemID.DD2SquireBetsySword)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.MonkStaffT3;
                if (item.type == ItemID.MonkStaffT3)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.DD2BetsyBow;
                if (item.type == ItemID.DD2BetsyBow)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.ApprenticeStaffT3;
                if (item.type == ItemID.ApprenticeStaffT3)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.DD2SquireBetsySword;

                //Mourning Wood
                if (item.type == ItemID.SpookyHook)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.SpookyTwig;
                if (item.type == ItemID.SpookyTwig)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.StakeLauncher;
                if (item.type == ItemID.StakeLauncher)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.CursedSapling;
                if (item.type == ItemID.CursedSapling)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.NecromanticScroll;
                if (item.type == ItemID.NecromanticScroll)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.SpookyHook;

                //Pumpking
                if (item.type == ItemID.CandyCornRifle)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.JackOLanternLauncher;
                if (item.type == ItemID.JackOLanternLauncher)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.BlackFairyDust;
                if (item.type == ItemID.BlackFairyDust)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.TheHorsemansBlade;
                if (item.type == ItemID.TheHorsemansBlade)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.BatScepter;
                if (item.type == ItemID.BatScepter)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.RavenStaff;
                if (item.type == ItemID.RavenStaff)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.ScytheWhip;
                if (item.type == ItemID.ScytheWhip)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.SpiderEgg;
                if (item.type == ItemID.SpiderEgg)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.CandyCornRifle;

                //Everscream
                if (item.type == ItemID.ChristmasTreeSword)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.ChristmasHook;
                if (item.type == ItemID.ChristmasHook)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.Razorpine;
                if (item.type == ItemID.Razorpine)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.FestiveWings;
                if (item.type == ItemID.FestiveWings)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.ChristmasTreeSword;

                //Santa-NK1
                if (item.type == ItemID.ElfMelter)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.ChainGun;
                if (item.type == ItemID.ChainGun)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.ElfMelter;

                //Ice Queen
                if (item.type == ItemID.NorthPole)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.SnowmanCannon;
                if (item.type == ItemID.SnowmanCannon)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.BlizzardStaff;
                if (item.type == ItemID.BlizzardStaff)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.BabyGrinchMischiefWhistle;
                if (item.type == ItemID.BabyGrinchMischiefWhistle)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.NorthPole;

                //Martian Saucer
                if (item.type == ItemID.InfluxWaver)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.Xenopopper;
                if (item.type == ItemID.Xenopopper)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.ElectrosphereLauncher;
                if (item.type == ItemID.ElectrosphereLauncher)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.LaserMachinegun;
                if (item.type == ItemID.LaserMachinegun)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.XenoStaff;
                if (item.type == ItemID.XenoStaff)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.CosmicCarKey;
                if (item.type == ItemID.CosmicCarKey)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.InfluxWaver;

                //Pre-HM Blood Moon
                if (item.type == ItemID.BloodRainBow)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.VampireFrogStaff;
                if (item.type == ItemID.VampireFrogStaff)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.BloodRainBow;

                //HM Blood Moon
                if (item.type == ItemID.SharpTears)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.DripplerFlail;
                if (item.type == ItemID.DripplerFlail)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.SharpTears;

                //Goblin Warlock
                if (item.type == ItemID.ShadowFlameKnife)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.ShadowFlameBow;
                if (item.type == ItemID.ShadowFlameBow)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.ShadowFlameHexDoll;
                if (item.type == ItemID.ShadowFlameHexDoll)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.ShadowFlameKnife;

                //Biome Chests
                if (item.type == ItemID.ScourgeoftheCorruptor)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.VampireKnives;
                if (item.type == ItemID.VampireKnives)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.ScourgeoftheCorruptor;

                //Corruption Mimic Drops
                if (item.type == ItemID.DartRifle)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.ClingerStaff;
                if (item.type == ItemID.ClingerStaff)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.ChainGuillotines;
                if (item.type == ItemID.ChainGuillotines)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.PutridScent;
                if (item.type == ItemID.PutridScent)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.WormHook;
                if (item.type == ItemID.WormHook)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.DartRifle;

                //Crimson Mimic Drops
                if (item.type == ItemID.SoulDrain)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.DartPistol;
                if (item.type == ItemID.DartPistol)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.FetidBaghnakhs;
                if (item.type == ItemID.FetidBaghnakhs)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.FleshKnuckles;
                if (item.type == ItemID.FleshKnuckles)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.TendonHook;
                if (item.type == ItemID.TendonHook)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.SoulDrain;

                //Hallowed Mimic Drops
                if (item.type == ItemID.DaedalusStormbow)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.FlyingKnife;
                if (item.type == ItemID.FlyingKnife)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.CrystalVileShard;
                if (item.type == ItemID.CrystalVileShard)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.IlluminantHook;
                if (item.type == ItemID.IlluminantHook)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.DaedalusStormbow;
            }

            if (QoLCompendium.mainServerConfig.ItemConversions)
            {
                if (item.type == ItemID.BrickLayer)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.ExtendoGrip;

                if (item.type == ItemID.ExtendoGrip)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.PaintSprayer;

                if (item.type == ItemID.PaintSprayer)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.PortableCementMixer;

                if (item.type == ItemID.PortableCementMixer)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.BrickLayer;

                if (item.type == ItemID.Toolbelt)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.Toolbox;

                if (item.type == ItemID.Toolbox)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.Toolbelt;
            }
        }

        public override float UseTimeMultiplier(Item item, Player player)
        {
            if (item.pick > 0 || item.hammer > 0 || item.axe > 0 || item.type == ItemID.WireCutter)
                return 1f - QoLCompendium.mainServerConfig.IncreaseToolSpeed;
            return 1f;
        }

        public override bool ReforgePrice(Item item, ref int reforgePrice, ref bool canApplyDiscount)
        {
            reforgePrice = (int)(reforgePrice * (1f - QoLCompendium.mainServerConfig.ReforgePriceChange * 0.01f));
            return true;
        }

        public override bool ConsumeItem(Item item, Player player)
        {
            if (item.consumable == true && item.damage == -1 && item.stack >= QoLCompendium.mainServerConfig.EndlessItemAmount && QoLCompendium.mainServerConfig.EndlessConsumables)
            {
                return false;
            }

            if (item.consumable == true && item.damage > 0 && item.stack >= QoLCompendium.mainServerConfig.EndlessWeaponAmount && QoLCompendium.mainServerConfig.EndlessWeapons)
            {
                return false;
            }

            return base.ConsumeItem(item, player);
        }

        public override bool CanBeConsumedAsAmmo(Item ammo, Item weapon, Player player)
        {
            if (ammo.ammo > 0 && ammo.stack >= QoLCompendium.mainServerConfig.EndlessAmmoAmount && QoLCompendium.mainServerConfig.EndlessAmmo)
            {
                return false;
            }
            return base.CanBeConsumedAsAmmo(ammo, weapon, player);
        }

        public override bool? CanConsumeBait(Player player, Item bait)
        {
            if (bait.bait > 0 && bait.stack >= QoLCompendium.mainServerConfig.EndlessBaitAmount && QoLCompendium.mainServerConfig.EndlessBait)
            {
                return false;
            }
            return base.CanConsumeBait(player, bait);
        }
    }

    public class FavoriteToResearch : GlobalItem
    {
        public override void UpdateInventory(Item item, Player player)
        {
            if (item.favorited && item.stack >= CreativeUI.GetSacrificeCount(item.type, out bool researched) && CreativeItemSacrificesCatalog.Instance.TryGetSacrificeCountCapToUnlockInfiniteItems(item.type, out int numResearch) && !researched && player.difficulty == PlayerDifficultyID.Creative && item.stack >= numResearch && QoLCompendium.mainClientConfig.FavoriteResearching)
            {
                if (item.type == ItemID.ShellphoneDummy || item.type == ItemID.ShellphoneHell || item.type == ItemID.ShellphoneOcean || item.type == ItemID.ShellphoneSpawn || item.type == ItemID.Shellphone)
                {
                    return;
                }
                CreativeUI.ResearchItem(item.type);
                SoundEngine.PlaySound(SoundID.ResearchComplete, default, null);
                item.stack -= numResearch;
                if (item.stack <= 0)
                {
                    item.TurnToAir();
                }
            }
        }
    }

    public static class CoinStacker
    {
        public static int CoinType(int item)
        {
            if (item == 71)
            {
                return 1;
            }
            if (item == 72)
            {
                return 2;
            }
            if (item == 73)
            {
                return 3;
            }
            if (item == 74)
            {
                return 4;
            }
            return 0;
        }

        public static void Pig(Item[] pInv, Item[] cInv)
        {
            int[] array = new int[4];
            List<int> list = new();
            List<int> list2 = new();
            bool flag = false;
            int[] array2 = new int[40];
            for (int i = 0; i < cInv.Length; i++)
            {
                array2[i] = -1;
                if (cInv[i].stack < 1 || cInv[i].type <= ItemID.None)
                {
                    list2.Add(i);
                    cInv[i] = new Item();
                }
                if (cInv[i] != null && cInv[i].stack > 0)
                {
                    int num = CoinType(cInv[i].type);
                    array2[i] = num - 1;
                    if (num > 0)
                    {
                        array[num - 1] += cInv[i].stack;
                        list2.Add(i);
                        cInv[i] = new Item();
                        flag = true;
                    }
                }
            }
            if (!flag)
            {
                return;
            }
            for (int j = 0; j < pInv.Length; j++)
            {
                if (j != 58 && pInv[j] != null && pInv[j].stack > 0 && !pInv[j].favorited)
                {
                    int num2 = CoinType(pInv[j].type);
                    if (num2 > 0)
                    {
                        array[num2 - 1] += pInv[j].stack;
                        list.Add(j);
                        pInv[j] = new Item();
                    }
                }
            }
            for (int k = 0; k < 3; k++)
            {
                while (array[k] >= 100)
                {
                    array[k] -= 100;
                    array[k + 1]++;
                }
            }
            for (int l = 0; l < 40; l++)
            {
                if (array2[l] >= 0 && cInv[l].type == ItemID.None)
                {
                    int num3 = l;
                    int num4 = array2[l];
                    if (array[num4] > 0)
                    {
                        cInv[num3].SetDefaults(71 + num4);
                        cInv[num3].stack = array[num4];
                        if (cInv[num3].stack > cInv[num3].maxStack)
                        {
                            cInv[num3].stack = cInv[num3].maxStack;
                        }
                        array[num4] -= cInv[num3].stack;
                        array2[l] = -1;
                    }
                    list2.Remove(num3);
                }
            }
            for (int m = 0; m < 40; m++)
            {
                if (array2[m] >= 0 && cInv[m].type == ItemID.None)
                {
                    int num5 = m;
                    int n = 3;
                    while (n >= 0)
                    {
                        if (array[n] > 0)
                        {
                            cInv[num5].SetDefaults(71 + n);
                            cInv[num5].stack = array[n];
                            if (cInv[num5].stack > cInv[num5].maxStack)
                            {
                                cInv[num5].stack = cInv[num5].maxStack;
                            }
                            array[n] -= cInv[num5].stack;
                            array2[m] = -1;
                            break;
                        }
                        if (array[n] == 0)
                        {
                            n--;
                        }
                    }
                    if (Main.netMode == NetmodeID.MultiplayerClient && Main.player[Main.myPlayer].chest > -1)
                    {
                        NetMessage.SendData(MessageID.SyncChestItem, -1, -1, null, Main.player[Main.myPlayer].chest, num5, 0f, 0f, 0, 0, 0);
                    }
                    list2.Remove(num5);
                }
            }
            while (list2.Count > 0)
            {
                int num6 = list2[0];
                int num7 = 3;
                while (num7 >= 0)
                {
                    if (array[num7] > 0)
                    {
                        cInv[num6].SetDefaults(71 + num7);
                        cInv[num6].stack = array[num7];
                        if (cInv[num6].stack > cInv[num6].maxStack)
                        {
                            cInv[num6].stack = cInv[num6].maxStack;
                        }
                        array[num7] -= cInv[num6].stack;
                        break;
                    }
                    if (array[num7] == 0)
                    {
                        num7--;
                    }
                }
                if (Main.netMode == NetmodeID.MultiplayerClient && Main.player[Main.myPlayer].chest > -1)
                {
                    NetMessage.SendData(MessageID.SyncChestItem, -1, -1, null, Main.player[Main.myPlayer].chest, list2[0], 0f, 0f, 0, 0, 0);
                }
                list2.RemoveAt(0);
            }
            int num8 = 3;
            while (num8 >= 0 && list.Count > 0)
            {
                int num9 = list[0];
                if (array[num8] > 0)
                {
                    pInv[num9].SetDefaults(71 + num8);
                    pInv[num9].stack = array[num8];
                    if (pInv[num9].stack > pInv[num9].maxStack)
                    {
                        pInv[num9].stack = pInv[num9].maxStack;
                    }
                    array[num8] -= pInv[num9].stack;
                    list.RemoveAt(0);
                }
                if (array[num8] == 0)
                {
                    num8--;
                }
            }
        }

        static CoinStacker()
        {
            HashSet<int> hashSet = new()
            {
                71,
                72,
                73,
                74
            };
            CoinTypes = hashSet;
            List<int> list = new()
            {
                0,
                1,
                100,
                10000,
                1000000
            };
            CoinValues = list;
        }

#pragma warning disable CA2211
        public static HashSet<int> CoinTypes;
        public static List<int> CoinValues;
        public const int Copper = 1;
        public const int Silver = 100;
        public const int Gold = 10000;
        public const int Platinum = 1000000;
#pragma warning restore CA2211
    }

    public class CoinGItem : GlobalItem
    {
        public override void UpdateInventory(Item item, Player player)
        {
            if (CoinStacker.CoinTypes.Contains(item.type) && QoLCompendium.mainServerConfig.AutoMoneyQuickStack)
                CoinStacker.Pig(player.inventory, player.bank.item);
        }
    }
}