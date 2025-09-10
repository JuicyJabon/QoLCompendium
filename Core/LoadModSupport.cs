namespace QoLCompendium.Core
{
    public static class LoadModSupport
    {
#pragma warning disable
        public static Dictionary<string, Mod> LoadedMods = new();

        public static void AddLoadedMod(this bool loaded, ref Mod mod)
        {
            if (loaded && mod != null)
                LoadedMods.Add(mod.Name, mod);
            else if (!loaded)
                mod = null;
        }

        public static void LoadTasks()
        {

        }

        public static void UnloadTasks()
        {
            LoadedMods.Clear();
        }

        public static void PostSetupTasks()
        {
            ModConditions.aequusLoaded.AddLoadedMod(ref ModConditions.aequusMod);
            ModConditions.afkpetsLoaded.AddLoadedMod(ref ModConditions.afkpetsMod);
            ModConditions.amuletOfManyMinionsLoaded.AddLoadedMod(ref ModConditions.amuletOfManyMinionsMod);
            ModConditions.arbourLoaded.AddLoadedMod(ref ModConditions.arbourMod);
            ModConditions.assortedCrazyThingsLoaded.AddLoadedMod(ref ModConditions.assortedCrazyThingsMod);
            ModConditions.awfulGarbageLoaded.AddLoadedMod(ref ModConditions.awfulGarbageMod);
            ModConditions.blocksArsenalLoaded.AddLoadedMod(ref ModConditions.blocksArsenalMod);
            ModConditions.blocksArtificerLoaded.AddLoadedMod(ref ModConditions.blocksArtificerMod);
            ModConditions.blocksCoreBossLoaded.AddLoadedMod(ref ModConditions.blocksCoreBossMod);
            ModConditions.blocksInfoAccessoriesLoaded.AddLoadedMod(ref ModConditions.blocksInfoAccessoriesMod);
            ModConditions.blocksThrowerLoaded.AddLoadedMod(ref ModConditions.blocksThrowerMod);
            ModConditions.bombusApisLoaded.AddLoadedMod(ref ModConditions.bombusApisMod);
            ModConditions.buffariaLoaded.AddLoadedMod(ref ModConditions.buffariaMod);
            ModConditions.calamityLoaded.AddLoadedMod(ref ModConditions.calamityMod);
            ModConditions.calamityCommunityRemixLoaded.AddLoadedMod(ref ModConditions.calamityCommunityRemixMod);
            ModConditions.calamityEntropyLoaded.AddLoadedMod(ref ModConditions.calamityEntropyMod);
            ModConditions.calamityOverhaulLoaded.AddLoadedMod(ref ModConditions.calamityOverhaulMod);
            ModConditions.calamityVanitiesLoaded.AddLoadedMod(ref ModConditions.calamityVanitiesMod);
            ModConditions.captureDiscsClassLoaded.AddLoadedMod(ref ModConditions.captureDiscsClassMod);
            ModConditions.catalystLoaded.AddLoadedMod(ref ModConditions.catalystMod);
            ModConditions.cerebralLoaded.AddLoadedMod(ref ModConditions.cerebralMod);
            ModConditions.clamityAddonLoaded.AddLoadedMod(ref ModConditions.clamityAddonMod);
            ModConditions.clickerClassLoaded.AddLoadedMod(ref ModConditions.clickerClassMod);
            ModConditions.confectionRebakedLoaded.AddLoadedMod(ref ModConditions.confectionRebakedMod);
            ModConditions.consolariaLoaded.AddLoadedMod(ref ModConditions.consolariaMod);
            ModConditions.coraliteLoaded.AddLoadedMod(ref ModConditions.coraliteMod);
            ModConditions.crystalDragonsLoaded.AddLoadedMod(ref ModConditions.crystalDragonsMod);
            ModConditions.depthsLoaded.AddLoadedMod(ref ModConditions.depthsMod);
            ModConditions.dormantDawnLoaded.AddLoadedMod(ref ModConditions.dormantDawnMod);
            ModConditions.draedonExpansionLoaded.AddLoadedMod(ref ModConditions.draedonExpansionMod);
            ModConditions.dragonBallTerrariaLoaded.AddLoadedMod(ref ModConditions.dragonBallTerrariaMod);
            ModConditions.echoesOfTheAncientsLoaded.AddLoadedMod(ref ModConditions.echoesOfTheAncientsMod);
            ModConditions.edorbisLoaded.AddLoadedMod(ref ModConditions.edorbisMod);
            ModConditions.enchantedMoonsLoaded.AddLoadedMod(ref ModConditions.enchantedMoonsMod);
            ModConditions.everjadeLoaded.AddLoadedMod(ref ModConditions.everjadeMod);
            ModConditions.exaltLoaded.AddLoadedMod(ref ModConditions.exaltMod);
            ModConditions.excelsiorLoaded.AddLoadedMod(ref ModConditions.excelsiorMod);
            ModConditions.exhaustionDisablerLoaded.AddLoadedMod(ref ModConditions.exhaustionDisablerMod);
            ModConditions.exxoAvalonOriginsLoaded.AddLoadedMod(ref ModConditions.exxoAvalonOriginsMod);
            ModConditions.fargosMutantLoaded.AddLoadedMod(ref ModConditions.fargosMutantMod);
            ModConditions.fargosSoulsLoaded.AddLoadedMod(ref ModConditions.fargosSoulsMod);
            ModConditions.fargosSoulsDLCLoaded.AddLoadedMod(ref ModConditions.fargosSoulsDLCMod);
            ModConditions.fargosSoulsExtrasLoaded.AddLoadedMod(ref ModConditions.fargosSoulsExtrasMod);
            ModConditions.fracturesOfPenumbraLoaded.AddLoadedMod(ref ModConditions.fracturesOfPenumbraMod);
            ModConditions.furnitureFoodAndFunLoaded.AddLoadedMod(ref ModConditions.furnitureFoodAndFunMod);
            ModConditions.gameTerrariaLoaded.AddLoadedMod(ref ModConditions.gameTerrariaMod);
            ModConditions.gensokyoLoaded.AddLoadedMod(ref ModConditions.gensokyoMod);
            ModConditions.gerdsLabLoaded.AddLoadedMod(ref ModConditions.gerdsLabMod);
            ModConditions.heartbeatariaLoaded.AddLoadedMod(ref ModConditions.heartbeatariaMod);
            ModConditions.homewardJourneyLoaded.AddLoadedMod(ref ModConditions.homewardJourneyMod);
            ModConditions.huntOfTheOldGodLoaded.AddLoadedMod(ref ModConditions.huntOfTheOldGodMod);
            ModConditions.infectedQualitiesLoaded.AddLoadedMod(ref ModConditions.infectedQualitiesMod);
            ModConditions.infernumLoaded.AddLoadedMod(ref ModConditions.infernumMod);
            ModConditions.infernalEclipseLoaded.AddLoadedMod(ref ModConditions.infernalEclipseMod);
            ModConditions.luiAFKLoaded.AddLoadedMod(ref ModConditions.luiAFKMod);
            ModConditions.luiAFKDLCLoaded.AddLoadedMod(ref ModConditions.luiAFKDLCMod);
            ModConditions.lunarVeilLoaded.AddLoadedMod(ref ModConditions.lunarVeilMod);
            ModConditions.magicStorageLoaded.AddLoadedMod(ref ModConditions.magicStorageMod);
            ModConditions.martainsOrderLoaded.AddLoadedMod(ref ModConditions.martainsOrderMod);
            ModConditions.mechReworkLoaded.AddLoadedMod(ref ModConditions.mechReworkMod);
            ModConditions.medialRiftLoaded.AddLoadedMod(ref ModConditions.medialRiftMod);
            ModConditions.metroidLoaded.AddLoadedMod(ref ModConditions.metroidMod);
            ModConditions.moomoosUltimateYoyoRevampLoaded.AddLoadedMod(ref ModConditions.moomoosUltimateYoyoRevampMod);
            ModConditions.mrPlagueRacesLoaded.AddLoadedMod(ref ModConditions.mrPlagueRacesMod);
            ModConditions.orchidLoaded.AddLoadedMod(ref ModConditions.orchidMod);
            ModConditions.ophioidLoaded.AddLoadedMod(ref ModConditions.ophioidMod);
            ModConditions.polaritiesLoaded.AddLoadedMod(ref ModConditions.polaritiesMod);
            ModConditions.projectZeroLoaded.AddLoadedMod(ref ModConditions.projectZeroMod);
            ModConditions.qwertyLoaded.AddLoadedMod(ref ModConditions.qwertyMod);
            ModConditions.ragnarokLoaded.AddLoadedMod(ref ModConditions.ragnarokMod);
            ModConditions.redemptionLoaded.AddLoadedMod(ref ModConditions.redemptionMod);
            ModConditions.reforgedLoaded.AddLoadedMod(ref ModConditions.reforgedMod);
            ModConditions.remnantsLoaded.AddLoadedMod(ref ModConditions.remnantsMod);
            ModConditions.ruptureLoaded.AddLoadedMod(ref ModConditions.ruptureMod);
            ModConditions.secretsOfTheShadowsLoaded.AddLoadedMod(ref ModConditions.secretsOfTheShadowsMod);
            ModConditions.secretsOfTheShadowsBardHealerLoaded.AddLoadedMod(ref ModConditions.secretsOfTheShadowsBardHealerMod);
            ModConditions.shadowsOfAbaddonLoaded.AddLoadedMod(ref ModConditions.shadowsOfAbaddonMod);
            ModConditions.sloomeLoaded.AddLoadedMod(ref ModConditions.sloomeMod);
            ModConditions.spiritClassicLoaded.AddLoadedMod(ref ModConditions.spiritClassicMod);
            ModConditions.spookyLoaded.AddLoadedMod(ref ModConditions.spookyMod);
            ModConditions.starlightRiverLoaded.AddLoadedMod(ref ModConditions.starlightRiverMod);
            ModConditions.starsAboveLoaded.AddLoadedMod(ref ModConditions.starsAboveMod);
            ModConditions.stormsAdditionsLoaded.AddLoadedMod(ref ModConditions.stormsAdditionsMod);
            ModConditions.stramsClassesLoaded.AddLoadedMod(ref ModConditions.stramsClassesMod);
            ModConditions.stramsSurvivalLoaded.AddLoadedMod(ref ModConditions.stramsSurvivalMod);
            ModConditions.supernovaLoaded.AddLoadedMod(ref ModConditions.supernovaMod);
            ModConditions.terrorbornLoaded.AddLoadedMod(ref ModConditions.terrorbornMod);
            ModConditions.thoriumLoaded.AddLoadedMod(ref ModConditions.thoriumMod);
            ModConditions.thoriumBossReworkLoaded.AddLoadedMod(ref ModConditions.thoriumBossReworkMod);
            ModConditions.throwerUnificationLoaded.AddLoadedMod(ref ModConditions.throwerUnificationMod);
            ModConditions.traeLoaded.AddLoadedMod(ref ModConditions.traeMod);
            ModConditions.uhtricLoaded.AddLoadedMod(ref ModConditions.uhtricMod);
            ModConditions.universeOfSwordsLoaded.AddLoadedMod(ref ModConditions.universeOfSwordsMod);
            ModConditions.valhallaLoaded.AddLoadedMod(ref ModConditions.valhallaMod);
            ModConditions.verdantLoaded.AddLoadedMod(ref ModConditions.verdantMod);
            ModConditions.vitalityLoaded.AddLoadedMod(ref ModConditions.vitalityMod);
            ModConditions.wayfairContentLoaded.AddLoadedMod(ref ModConditions.wayfairContentMod);
            ModConditions.wrathOfTheGodsLoaded.AddLoadedMod(ref ModConditions.wrathOfTheGodsMod);
            ModConditions.zylonLoaded.AddLoadedMod(ref ModConditions.zylonMod);
        }
    }
}
