using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace QoLCompendium.Core.Configs
{
    public class MainConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("$Mods.QoLCompendium.ConfigHeaders.Endless")]
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

        [Header("$Mods.QoLCompendium.ConfigHeaders.Items2")]
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

        //[DefaultValue(true)]
        //public bool FurnitureRecipes { get; set; }

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

        [Header("$Mods.QoLCompendium.ConfigHeaders.NPCs")]
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
        [ReloadRequired]
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

        [Header("$Mods.QoLCompendium.ConfigHeaders.Projectiles")]
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

        [Header("$Mods.QoLCompendium.ConfigHeaders.Player")]
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

        [Header("$Mods.QoLCompendium.ConfigHeaders.World")]
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

        [DefaultValue(true)]
        public bool BombableHardmodeOres { get; set; }

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
        [ReloadRequired]
        public bool DisableCredits { get; set; }

        public override void OnLoaded()
        {
            QoLCompendium.mainConfig = this;
        }

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref NetworkText message)
        {
            return Common.TryAcceptChanges(whoAmI, ref message);
        }
    }
}
