using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace QoLCompendium.Core
{
    public class QoLCConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("$Mods.QoLCompendium.QoLCConfig.Headers.Endless")]
        [DefaultValue(true)]
        public bool EndlessBuffs { get; set; }

        [DefaultValue(true)]
        public bool EndlessHealing { get; set; }

        [DefaultValue(true)]
        public bool EndlessAmmo { get; set; }

        [DefaultValue(true)]
        public bool EndlessBait { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool EndlessBossSummons { get; set; }

        [DefaultValue(true)]
        public bool EndlessConsumables { get; set; }

        [DefaultValue(true)]
        public bool EndlessWeapons { get; set; }

        [DefaultValue(30)]
        [Range(1, 99999)]
        public int EndlessBuffAmount { get; set; }

        [DefaultValue(1)]
        [Range(1, 99999)]
        public int EndlessStationAmount { get; set; }

        [DefaultValue(30)]
        [Range(1, 99999)]
        public int EndlessHealingAmount { get; set; }

        [DefaultValue(999)]
        [Range(1, 99999)]
        public int EndlessItemAmount { get; set; }

        [DefaultValue(999)]
        [Range(1, 99999)]
        public int EndlessWeaponAmount { get; set; }

        [DefaultValue(999)]
        [Range(1, 99999)]
        public int EndlessAmmoAmount { get; set; }

        [DefaultValue(999)]
        [Range(1, 99999)]
        public int EndlessBaitAmount { get; set; }

        [DefaultValue(false)]
        public bool ActiveBuffsHaveEnchantedEffects { get; set; }

        [Header("$Mods.QoLCompendium.QoLCConfig.Headers.Items2")]
        [DefaultValue(9999)]
        [Range(1, 99999)]
        public int IncreaseMaxStack { get; set; }

        [DefaultValue(true)]
        public bool UtilityAccessoriesWorkInBanks { get; set; }

        [DefaultValue(false)]
        public bool FountainsWorkFromInventories { get; set; }

        [DefaultValue(true)]
        public bool StackableQuestItems { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool NonConsumableKeys { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool BossItemTransmutation { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool ItemConversions { get; set; }

        [DefaultValue(true)]
        public bool EasierRecipes { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool EmblemLooping { get; set; }

        [DefaultValue(true)]
        public bool PortableStations { get; set; }

        [DefaultValue(true)]
        public bool NoDeveloperSetsFromBossBags { get; set; }

        [Slider]
        [DefaultValue(5)]
        [Range(1, 25)]
        public int EnemiesDropMoreCoins { get; set; }

        [DefaultValue(true)]
        public bool EncumberingStoneAllowsCoins { get; set; }

        [DefaultValue(true)]
        public bool AutoMoneyQuickStack { get; set; }

        [DefaultValue(true)]
        public bool GoldenCarpDelight { get; set; }

        [DefaultValue(true)]
        public bool EasierUniversalPylon { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool AutoReuseUpgrades { get; set; }

        [DefaultValue(false)]
        public bool GoodPrefixesHaveEnchantedEffects { get; set; }

        [DefaultValue(true)]
        public bool ReworkReforging { get; set; }

        [DefaultValue(false)]
        [ReloadRequired]
        public bool FullyDisableRecipes { get; set; }

        [Header("$Mods.QoLCompendium.QoLCConfig.Headers.NPCs")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool BlackMarketDealerCanSpawn { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool EtherealCollectorCanSpawn { get; set; }

        /*
        [DefaultValue(false)]
        [ReloadRequired]
        public bool RequireItemObtainedForShops { get; set; }
        */

        [DefaultValue(false)]
        public bool RemoveBiomeShopRequirements { get; set; }

        [DefaultValue(true)]
        public bool TownNPCsDontDie { get; set; }

        [Slider]
        [Range(1, 10)]
        [DefaultValue(1)]
        public int FastTownNPCSpawns { get; set; }

        [DefaultValue(true)]
        public bool TownNPCSpawnImprovements { get; set; }

        [DefaultValue(true)]
        public bool NoTownSlimes { get; set; }

        [DefaultValue(true)]
        public bool TownNPCsLiveInEvil { get; set; }

        [DefaultValue(true)]
        public bool DisableHappiness { get; set; }

        [DefaultValue(false)]
        public bool OverridePylonSales { get; set; }

        [Slider]
        [DefaultValue(0.75f)]
        [Increment(0.01f)]
        [Range(0, 1)]
        public float HappinessPriceChange { get; set; }

        [Range(0, 100)]
        [DefaultValue(25)]
        public int ReforgePriceChange { get; set; }

        [DefaultValue(true)]
        public bool AnglerQuestInstantReset { get; set; }

        [Slider]
        [DefaultValue(10)]
        [Range(1, 100)]
        [Increment(5)]
        public int LunarPillarShieldHeath { get; set; }

        [DefaultValue(true)]
        public bool LunarPillarsDropMoreFragments { get; set; }

        [DefaultValue(true)]
        public bool LunarEnemiesDropFragments { get; set; }

        [DefaultValue(true)]
        public bool OneKillForBestiaryEntries { get; set; }

        [DefaultValue(true)]
        public bool LavaSlimesDontDropLava { get; set; }

        [DefaultValue(true)]
        public bool ExtraDefenderMedalDrops { get; set; }

        [DefaultValue(true)]
        public bool RelicsInExpert { get; set; }

        [DefaultValue(true)]
        public bool NoSpawnsDuringBosses { get; set; }

        [DefaultValue(true)]
        public bool NoNaturalBossSpawns { get; set; }

        [Header("$Mods.QoLCompendium.QoLCConfig.Headers.Projectiles")]
        [Range(0, 25)]
        [DefaultValue(3)]
        public int ExtraLures { get; set; }

        [DefaultValue(true)]
        public bool MobileStoragesFollowThePlayer { get; set; }

        [DefaultValue(true)]
        public bool NoFallingSandDamage { get; set; }

        [DefaultValue(true)]
        public bool NoLittering { get; set; }

        [DefaultValue(true)]
        public bool NoLarvaBreak { get; set; }

        [DefaultValue(true)]
        public bool PurificationPowderCleansesWalls { get; set; }

        [Header("$Mods.QoLCompendium.QoLCConfig.Headers.Player")]
        [Slider]
        [DefaultValue(0.2f)]
        [Range(0f, 1f)]
        [Increment(0.1f)]
        public float IncreasePlaceSpeed { get; set; }

        [Slider]
        [DefaultValue(4)]
        [Range(0, 60)]
        [Increment(2)]
        public int IncreasePlaceRange { get; set; }

        [DefaultValue(0d)]
        [Range(0, 1f)]
        [Slider]
        [Increment(0.125f)]
        public float IncreaseToolSpeed { get; set; }

        [DefaultValue(true)]
        public bool FasterExtractinator { get; set; }

        [DefaultValue(44)]
        [Range(0, 132)]
        [Slider]
        [Increment(22)]
        [ReloadRequired]
        public int ExtraBuffSlots { get; set; }

        [DefaultValue(true)]
        public bool KeepBuffsOnDeath { get; set; }

        [DefaultValue(false)]
        public bool KeepDebuffsOnDeath { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool InfiniteSliceOfCake { get; set; }

        [DefaultValue(false)]
        public bool HideBuffs { get; set; }

        [DefaultValue(true)]
        public bool RegrowthAutoReplant { get; set; }

        [DefaultValue(true)]
        public bool LifeformAnalyzerPointer { get; set; }

        [DefaultValue(true)]
        public bool NoExpertIceWaterChilled { get; set; }

        [DefaultValue(true)]
        public bool NoShimmerSink { get; set; }

        [Slider]
        [DefaultValue(1)]
        [Range(0, 5)]
        [Increment(1)]
        public int AutoTeams { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool AllHairStylesAvailable { get; set; }

        [DefaultValue(true)]
        public bool NoTombstoneDrops { get; set; }

        [DefaultValue(true)]
        public bool HellstoneSpelunker { get; set; }

        [DefaultValue(true)]
        public bool DangersenseIgnoresThinIce { get; set; }

        [DefaultValue(true)]
        public bool DangersenseHighlightsSiltAndSlush { get; set; }

        [DefaultValue(true)]
        public bool AutoFishing { get; set; }

        [DefaultValue(true)]
        public bool NoLakeSizePenalty { get; set; }

        [DefaultValue(false)]
        public bool NoPylonTeleportRestrictions { get; set; }

        [DefaultValue(true)]
        public bool InstantRespawn { get; set; }

        [DefaultValue(true)]
        public bool FullHealthRespawn { get; set; }

        [DefaultValue(false)]
        public bool WingSlot { get; set; }

        [DefaultValue(false)]
        public bool BootSlot { get; set; }

        [DefaultValue(false)]
        public bool ShieldSlot { get; set; }

        [DefaultValue(false)]
        public bool ExpertSlot { get; set; }

        [DefaultValue(false)]
        public bool MapTeleporting { get; set; }

        [Header("$Mods.QoLCompendium.QoLCConfig.Headers.World")]
        [DefaultValue(true)]
        public bool DisableEvilBiomeSpread { get; set; }

        [DefaultValue(true)]
        public bool FountainsCauseBiomes { get; set; }

        [DefaultValue(true)]
        public bool FastTreeGrowth { get; set; }

        [DefaultValue(true)]
        public bool FastHerbGrowth { get; set; }

        [DefaultValue(true)]
        public bool TreesDropMoreWhenShook { get; set; }

        [DefaultValue(true)]
        public bool HeartCrystalGlow { get; set; }

        [DefaultValue(true)]
        public bool LifeFruitGlow { get; set; }

        [DefaultValue(true)]
        public bool BreakAllDungeonBricks { get; set; }

        [DefaultValue(2)]
        [Range(1, 500)]
        public int MoreFallenStars { get; set; }

        [DefaultValue(true)]
        public bool NoMeteorSpawns { get; set; }

        [DefaultValue(true)]
        public bool ChristmasActive { get; set; }

        [DefaultValue(true)]
        public bool HalloweenActive { get; set; }

        [DefaultValue(false)]
        public bool DisableCredits { get; set; }

        public override void OnLoaded()
        {
            QoLCompendium.mainConfig = this;
        }

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref NetworkText message)
        {
            return Common.TryAcceptChanges(whoAmI, ref message);
        }

        [SeparatePage]
        public class MainClientConfig : ModConfig
        {
            public override ConfigScope Mode => ConfigScope.ClientSide;

            [Header("$Mods.QoLCompendium.QoLCConfig.Headers.Player")]
            [DefaultValue(true)]
            public bool FavoriteResearching { get; set; }

            [DefaultValue(false)]
            public bool NoAuraVisuals { get; set; }

            [DefaultValue(false)]
            public bool DisableDashDoubleTap { get; set; }

            [DefaultValue(100)]
            [Range(1, 100000)]
            [ReloadRequired]
            public int CombatTextLimit { get; set; }

            [DefaultValue(0)]
            [DrawTicks]
            public ConfigGlintID GlintColor { get; set; }

            public enum ConfigGlintID
            {
                White = 0,
                Red = 1,
                Orange = 2,
                Yellow = 3,
                Green = 4,
                Lime = 5,
                Blue = 6,
                Cyan = 7,
                SkyBlue = 8,
                Purple = 9,
                Magenta = 10,
                Pink = 11,
                Rainbow = 12
            }

            public override void OnLoaded()
            {
                QoLCompendium.mainClientConfig = this;
            }
        }

        [SeparatePage]
        public class ItemConfig : ModConfig
        {
            public override ConfigScope Mode => ConfigScope.ServerSide;

            [DefaultValue(false)]
            [ReloadRequired]
            public bool DisableModdedItems { get; set; }

            [DefaultValue(true)]
            public bool AsphaltPlatform { get; set; }

            [DefaultValue(true)]
            public bool AutoStructures { get; set; }

            [DefaultValue(true)]
            public bool BannerBox { get; set; }

            [DefaultValue(true)]
            public bool BottomlessBuckets { get; set; }

            [DefaultValue(true)]
            public bool BossSummons { get; set; }

            [DefaultValue(true)]
            public bool ChallengersCoin { get; set; }

            [DefaultValue(true)]
            public bool ConstructionAccessories { get; set; }

            [DefaultValue(true)]
            public bool CraftingStations { get; set; }

            [DefaultValue(true)]
            public bool DestinationGlobe { get; set; }

            [DefaultValue(true)]
            public bool Eightworm { get; set; }

            [DefaultValue(true)]
            public bool EndlessAmmo { get; set; }

            [DefaultValue(true)]
            public bool EntityManipulator { get; set; }

            [DefaultValue(true)]
            public bool FishingAccessories { get; set; }

            [DefaultValue(true)]
            public bool GoldenLockpick { get; set; }

            [DefaultValue(true)]
            public bool GoldenPowder { get; set; }

            [DefaultValue(true)]
            public bool InformationAccessories { get; set; }

            [DefaultValue(true)]
            public bool LegendaryCatcher { get; set; }

            [DefaultValue(true)]
            public bool Magnets { get; set; }

            [DefaultValue(true)]
            public bool MiniSundial { get; set; }

            [DefaultValue(true)]
            public bool Mirrors { get; set; }

            [DefaultValue(true)]
            public bool MobileStorages { get; set; }

            [DefaultValue(true)]
            public bool MoonPedestals { get; set; }

            [DefaultValue(true)]
            public bool Paperweight { get; set; }

            [DefaultValue(true)]
            public bool PermanentBuffs { get; set; }

            [DefaultValue(true)]
            public bool PhaseInterrupter { get; set; }

            [DefaultValue(true)]
            public bool PotionCrate { get; set; }

            [DefaultValue(true)]
            public bool Pylons { get; set; }

            [DefaultValue(true)]
            public bool RegrowthStaves { get; set; }

            [DefaultValue(true)]
            public bool RestockNotice { get; set; }

            [DefaultValue(true)]
            public bool SkeletonRucksack { get; set; }

            [DefaultValue(true)]
            public bool StarterBag { get; set; }

            [DefaultValue(true)]
            public bool SummoningRemote { get; set; }

            [DefaultValue(true)]
            public bool SuperDummy { get; set; }
            
            [DefaultValue(true)]
            public bool TravelersMannequin { get; set; }

            [DefaultValue(true)]
            public bool UltimateChecklist { get; set; }

            [DefaultValue(true)]
            public bool WatchingEye { get; set; }

            [DefaultValue(true)]
            public bool DedicatedItems { get; set; }

            [DefaultValue(true)]
            public bool CrossModItems { get; set; }

            public List<ItemDefinition> CustomItems { get; set; }

            [Range(1, 99999)]
            public List<int> CustomItemQuantities { get; set; }

            public override void OnLoaded()
            {
                QoLCompendium.itemConfig = this;
            }

            public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref NetworkText message)
            {
                return Common.TryAcceptChanges(whoAmI, ref message);
            }
        }

        [SeparatePage]
        public class ShopConfig : ModConfig
        {
            public override ConfigScope Mode => ConfigScope.ServerSide;

            [Header("$Mods.QoLCompendium.QoLCConfig.Headers.BMShop")]

            [DefaultValue(true)]
            [ReloadRequired]
            public bool BMPotionShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool BMStationShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool BMMaterialShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool BMMovementAccessoryShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool BMCombatAccessoryShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool BMInformationShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool BMBagShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool BMCrateShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool BMOreShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool BMNaturalBlockShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool BMBuildingBlockShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool BMHerbShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool BMFishShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool BMMountShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool BMAmmoShop { get; set; }

            [Header("$Mods.QoLCompendium.QoLCConfig.Headers.ECShop")]

            [DefaultValue(true)]
            [ReloadRequired]
            public bool ECPotionShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool ECStationShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool ECMaterialShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool ECBagShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool ECCrateShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool ECOreShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool ECNaturalBlocksShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool ECBuildingBlocksShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool ECHerbShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool ECFishShop { get; set; }

            [Header("$Mods.QoLCompendium.QoLCConfig.Headers.Prices")]

            [DefaultValue(true)]
            public bool BossScaling { get; set; }

            [DefaultValue(1)]
            [Increment(1)]
            [Range(1, 1000)]
            public int GlobalPriceMultiplier { get; set; }

            [DefaultValue(1)]
            [Increment(1)]
            [Range(1, 1000)]
            public int PotionPriceMultiplier { get; set; }

            [DefaultValue(1)]
            [Increment(1)]
            [Range(1, 1000)]
            public int StationPriceMultiplier { get; set; }

            [DefaultValue(1)]
            [Increment(1)]
            [Range(1, 1000)]
            public int MaterialPriceMultiplier { get; set; }

            [DefaultValue(1)]
            [Increment(1)]
            [Range(1, 1000)]
            public int AccessoryPriceMultiplier { get; set; }

            [DefaultValue(1)]
            [Increment(1)]
            [Range(1, 1000)]
            public int BagPriceMultiplier { get; set; }

            [DefaultValue(1)]
            [Increment(1)]
            [Range(1, 1000)]
            public int CratePriceMultiplier { get; set; }

            [DefaultValue(1)]
            [Increment(1)]
            [Range(1, 1000)]
            public int OrePriceMultiplier { get; set; }

            [DefaultValue(1)]
            [Increment(1)]
            [Range(1, 1000)]
            public int NaturalBlockPriceMultiplier { get; set; }

            [DefaultValue(1)]
            [Increment(1)]
            [Range(1, 1000)]
            public int BuildingBlockPriceMultiplier { get; set; }

            [DefaultValue(1)]
            [Increment(1)]
            [Range(1, 1000)]
            public int HerbPriceMultiplier { get; set; }

            [DefaultValue(1)]
            [Increment(1)]
            [Range(1, 1000)]
            public int FishPriceMultiplier { get; set; }

            [DefaultValue(1)]
            [Increment(1)]
            [Range(1, 1000)]
            public int MountPriceMultiplier { get; set; }

            [DefaultValue(1)]
            [Increment(1)]
            [Range(1, 1000)]
            public int AmmoPriceMultiplier { get; set; }

            public override void OnLoaded()
            {
                QoLCompendium.shopConfig = this;
            }

            public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref NetworkText message)
            {
                return Common.TryAcceptChanges(whoAmI, ref message);
            }
        }

        [SeparatePage]
        public class TooltipConfig : ModConfig
        {
            public override ConfigScope Mode => ConfigScope.ClientSide;

            [Header("$Mods.QoLCompendium.QoLCConfig.Headers.Tooltips")]

            [DefaultValue(true)]
            public bool NoFavoriteTooltip { get; set; }
            
            [DefaultValue(true)]
            public bool ShimmerableTooltip { get; set; }

            [DefaultValue(true)]
            public bool WorksInBanksTooltip { get; set; }

            [DefaultValue(true)]
            public bool UsedPermanentUpgradeTooltip { get; set; }

            [DefaultValue(true)]
            public bool WingStatsTooltips { get; set; }

            [DefaultValue(true)]
            public bool HookStatsTooltips { get; set; }

            [DefaultValue(true)]
            public bool AmmoTooltip { get; set; }

            [DefaultValue(true)]
            public bool ActiveTooltip { get; set; }

            [DefaultValue(true)]
            public bool NoYoyoTooltip { get; set; }

            [DefaultValue(false)]
            public bool FromModTooltip { get; set; }

            [DefaultValue(true)]
            public bool ClassTagTooltip { get; set; }

            public override void OnLoaded()
            {
                QoLCompendium.tooltipConfig = this;
            }
        }

        [SeparatePage]
        public class CrossModConfig : ModConfig
        {
            public override ConfigScope Mode => ConfigScope.ServerSide;

            [Header("$Mods.QoLCompendium.QoLCConfig.Headers.CrossMod")]

            [DefaultValue(true)]
            public bool AFKPetsCropFix { get; set; }

            [DefaultValue(true)]
            public bool AFKPetsFasterCropGrowth { get; set; }

            [DefaultValue(true)]
            public bool AFKPetsRegrowthReplant { get; set; }

            [DefaultValue(true)]
            public bool CrystalDragonsTopazPrefixFix { get; set; }

            [DefaultValue(true)]
            public bool MrPlagueRacesPrefixFix { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool CalamityEffigyRecipes { get; set; }

            [DefaultValue(true)]
            public bool RemoveThoriumExhaustionTooltip { get; set; }

            [DefaultValue(true)]
            public bool CalamityEntropyArmorPrefixesHaveEnchantedEffects { get; set; }

            public override void OnLoaded()
            {
                QoLCompendium.crossModConfig = this;
            }
        }

        [SeparatePage]
        public class VeinminerConfig : ModConfig
        {
            public override ConfigScope Mode => ConfigScope.ServerSide;

            [Header("$Mods.QoLCompendium.QoLCConfig.Headers.Veinminer")]

            [DefaultValue(true)]
            public bool VeinMiner { get; set; }

            [DefaultValue(3)]
            [Range(0, 15)]
            public int VeinMinerSpeed { get; set; }

            [DefaultValue(120)]
            [Range(1, 750)]
            public int VeinMinerTileLimit { get; set; }

            [DefaultListValue("Terraria:")]
            public HashSet<string> VeinMinerTileWhitelist =
            [
                "Terraria:" + TileID.Search.GetName(6),
                "Terraria:" + TileID.Search.GetName(7),
                "Terraria:" + TileID.Search.GetName(8),
                "Terraria:" + TileID.Search.GetName(9),
                "Terraria:" + TileID.Search.GetName(22),
                "Terraria:" + TileID.Search.GetName(37),
                "Terraria:" + TileID.Search.GetName(40),
                "Terraria:" + TileID.Search.GetName(56),
                "Terraria:" + TileID.Search.GetName(58),
                "Terraria:" + TileID.Search.GetName(63),
                "Terraria:" + TileID.Search.GetName(64),
                "Terraria:" + TileID.Search.GetName(65),
                "Terraria:" + TileID.Search.GetName(66),
                "Terraria:" + TileID.Search.GetName(67),
                "Terraria:" + TileID.Search.GetName(68),
                "Terraria:" + TileID.Search.GetName(107),
                "Terraria:" + TileID.Search.GetName(108),
                "Terraria:" + TileID.Search.GetName(111),
                "Terraria:" + TileID.Search.GetName(123),
                "Terraria:" + TileID.Search.GetName(162),
                "Terraria:" + TileID.Search.GetName(166),
                "Terraria:" + TileID.Search.GetName(167),
                "Terraria:" + TileID.Search.GetName(168),
                "Terraria:" + TileID.Search.GetName(169),
                "Terraria:" + TileID.Search.GetName(178),
                "Terraria:" + TileID.Search.GetName(204),
                "Terraria:" + TileID.Search.GetName(211),
                "Terraria:" + TileID.Search.GetName(221),
                "Terraria:" + TileID.Search.GetName(222),
                "Terraria:" + TileID.Search.GetName(223),
                "Terraria:" + TileID.Search.GetName(224),
                "Terraria:" + TileID.Search.GetName(404),
                "Terraria:" + TileID.Search.GetName(407),
                "Terraria:" + TileID.Search.GetName(408),
                "Terraria:" + TileID.Search.GetName(481),
                "Terraria:" + TileID.Search.GetName(482),
                "Terraria:" + TileID.Search.GetName(483),
                "Terraria:" + TileID.Search.GetName(48)
            ];

            public override void OnLoaded()
            {
                QoLCompendium.veinminerConfig = this;
            }
        }
    }
}
