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
        public bool EndlessBuffsOnlyFromCrate { get; set; }

        [Header("$Mods.QoLCompendium.QoLCConfig.Headers.Spawn")]
        [DefaultValue(true)]
        public bool InstantRespawn { get; set; }

        [DefaultValue(true)]
        public bool FullHPRespawn { get; set; }

        [DefaultValue(true)]
        public bool NoSpawns { get; set; }

        [DefaultValue(true)]
        public bool NoNaturalBossSpawns { get; set; }

        [Header("$Mods.QoLCompendium.QoLCConfig.Headers.Items2")]
        [DefaultValue(true)]
        public bool NoDevs { get; set; }

        [DefaultValue(9999)]
        [Range(1, 99999)]
        public int IncreaseMaxStack { get; set; }

        [DefaultValue(true)]
        public bool InformationBanks { get; set; }

        [DefaultValue(true)]
        public bool StackableQuestItems { get; set; }

        [DefaultValue(true)]
        public bool BossItemTransmutation { get; set; }

        [DefaultValue(true)]
        public bool ItemConversions { get; set; }

        [DefaultValue(true)]
        public bool FavoriteResearching { get; set; }

        [Slider]
        [DefaultValue(5)]
        [Range(1, 25)]
        public  int MoreCoins { get; set; }

        [DefaultValue(true)]
        public bool AutoMoneyStack { get; set; }

        [Header("$Mods.QoLCompendium.QoLCConfig.Headers.NPCs")]
        [DefaultValue(true)]
        public bool BMNPC { get; set; }

        [DefaultValue(true)]
        public bool ECNPC { get; set; }

        [DefaultValue(false)]
        public bool RemoveBiomeRequirements { get; set; }

        [DefaultValue(true)]
        public bool FriendliesDontDie { get; set; }

        [DefaultValue(true)]
        public bool FastTownieSpawns { get; set; }

        [DefaultValue(true)]
        public bool TownieSpawn { get; set; }

        [DefaultValue(true)]
        public bool GoHomeNPCs { get; set; }

        [DefaultValue(true)]
        public bool NoTownSlimes { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool TowniesLiveInEvil { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool ToggleHappiness { get; set; }

        [DefaultValue(false)]
        [ReloadRequired]
        public bool OverridePylon { get; set; }

        [DefaultValue(false)]
        public bool NoPylonRestriction { get; set; }

        [Slider]
        [DefaultValue(0.75f)]
        [Increment(0.01f)]
        [Range(0, 1)]
        public float HappinessPriceChange { get; set; }

        [DefaultValue(true)]
        public bool AnglerQuestInstantReset { get; set; }

        [Slider]
        [DefaultValue(10)]
        [Range(1, 100)]
        [Increment(5)]
        public int TowerShield { get; set; }

        [DefaultValue(true)]
        public bool MoreFragments { get; set; }

        [DefaultValue(true)]
        public bool OneKillForBestiary { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool LavaSlimeNoLava { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool NoDoorBreaking { get; set; }

        [DefaultValue(true)]
        public bool DefenderMedalDrops { get; set; }

        [Header("$Mods.QoLCompendium.QoLCConfig.Headers.Projectiles")]
        [DefaultValue(true)]
        public bool ExtraLures { get; set; }

        [DefaultValue(true)]
        public bool NoFallingSandDamage { get; set; }

        [DefaultValue(true)]
        public  bool NoLittering { get; set; }

        [DefaultValue(true)]
        public bool NoLarvaBreak { get; set; }

        [Header("$Mods.QoLCompendium.QoLCConfig.Headers.Speed")]
        [Slider]
        [DefaultValue(3f)]
        [Range(0f, 4f)]
        [Increment(1f)]
        public float IncreasePlaceSpeed { get; set; }

        [Slider]
        [DefaultValue(6)]
        [Range(0, 20)]
        [Increment(2)]
        public int IncreasePlaceRange { get; set; }

        [DefaultValue(0d)]
        [Range(0, 1f)]
        [Slider]
        [Increment(0.125f)]
        public float FastTools { get; set; }

        [DefaultValue(true)]
        public bool FastExtractor { get; set; }

        [Header("$Mods.QoLCompendium.QoLCConfig.Headers.Player")]
        [Slider]
        [DefaultValue(44)]
        [Range(0, 88)]
        public uint ExtraBuffSlots { get; set; }

        [DefaultValue(true)]
        public bool KeepBuffsOnDeath { get; set; }

        [DefaultValue(false)]
        public bool KeepDebuffsOnDeath { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool InfiniteSliceOfCake { get; set; }

        [DefaultValue(true)]
        public bool RegrowthAutoReplant { get; set; }

        [DefaultValue(true)]
        public bool LifeformPointer { get; set; }

        [DefaultValue(true)]
        public bool WingSlot { get; set; }

        [DefaultValue(true)]
        public bool NoChilled { get; set; }

        [DefaultValue(true)]
        public bool NoShimmerSink { get; set; }

        [Slider]
        [DefaultValue(1)]
        [Range(0, 5)]
        [Increment(1)]
        public int AutoTeams { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool AllHairsAvailable { get; set; }

        [DefaultValue(true)]
        public bool NoTombs { get; set; }

        [DefaultValue(true)]
        public bool AutoFishing { get; set; }

        [DefaultValue(true)]
        public bool PortableCrafting { get; set; }

        [DefaultValue(true)]
        public bool MapPorting { get; set; }

        [DefaultValue(false)]
        public bool DisableDashing { get; set; }

        [Header("$Mods.QoLCompendium.QoLCConfig.Headers.World")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool DisableEvilSpread { get; set; }

        [DefaultValue(true)]
        public bool FastTrees { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool FastHerbs { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool TreesDropMore { get; set; }

        [DefaultValue(2)]
        [Range(1, 500)]
        [Increment(1)]
        public int MoreStars { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool NoMeteors { get; set; }

        [DefaultValue(true)]
        public bool Christmas { get; set; }

        [DefaultValue(true)]
        public bool Halloween { get; set; }

        [DefaultValue(false)]
        public bool DisableCredits { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool VeinMiner { get; set; }

        [DefaultValue(3)]
        [Range(0, 15)]
        [ReloadRequired]
        public int VeinMinerSpeed { get; set; }

        [DefaultValue(120)]
        [Range(1, 500)]
        [ReloadRequired]
        public int VeinMinerTileLimit { get; set; }

        public List<TileDefinition> VeinMinerWhitelist = new()
        {
            new TileDefinition(TileID.Copper),
            new TileDefinition(TileID.Tin),
            new TileDefinition(TileID.Iron),
            new TileDefinition(TileID.Lead),
            new TileDefinition(TileID.Silver),
            new TileDefinition(TileID.Tungsten),
            new TileDefinition(TileID.Gold),
            new TileDefinition(TileID.Platinum),
            new TileDefinition(TileID.Meteorite),
            new TileDefinition(TileID.Demonite),
            new TileDefinition(TileID.Crimtane),
            new TileDefinition(TileID.Obsidian),
            new TileDefinition(TileID.Hellstone),
            new TileDefinition(TileID.Cobalt),
            new TileDefinition(TileID.Palladium),
            new TileDefinition(TileID.Mythril),
            new TileDefinition(TileID.Orichalcum),
            new TileDefinition(TileID.Adamantite),
            new TileDefinition(TileID.Titanium),
            new TileDefinition(TileID.Chlorophyte),
            new TileDefinition(TileID.LunarOre),
            new TileDefinition(TileID.Amethyst),
            new TileDefinition(TileID.Topaz),
            new TileDefinition(TileID.Sapphire),
            new TileDefinition(TileID.Emerald),
            new TileDefinition(TileID.Ruby),
            new TileDefinition(TileID.Diamond),
            new TileDefinition(TileID.Silt),
            new TileDefinition(TileID.Slush),
            new TileDefinition(TileID.DesertFossil)
        };

        public override void OnLoaded()
        {
            QoLCompendium.mainConfig = this;
        }

        [SeparatePage]
        public class ItemConfig : ModConfig
        {
            public override ConfigScope Mode => ConfigScope.ServerSide;

            [DefaultValue(true)]
            public bool AsphaltPlatform { get; set; }

            [DefaultValue(true)]
            public bool AutoStructures { get; set; }

            [DefaultValue(true)]
            public bool BannerBox { get; set; }

            [DefaultValue(true)]
            public bool CraftingStations { get; set; }

            [DefaultValue(true)]
            public bool EndlessAmmo { get; set; }

            [DefaultValue(true)]
            public bool EntityManipulator { get; set; }

            [DefaultValue(true)]
            public bool GoldenLockpick { get; set; }

            [DefaultValue(true)]
            public bool InformationAccessories { get; set; }

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
            public bool StarterBag { get; set; }

            [DefaultValue(true)]
            public bool SummoningRemote { get; set; }

            [DefaultValue(true)]
            public bool SuperDummy { get; set; }

            [DefaultValue(true)]
            public bool TheFinalList { get; set; }
            
            [DefaultValue(true)]
            public bool TravelersMannequin { get; set; }

            [DefaultValue(true)]
            public bool UltimateChecklist { get; set; }

            [DefaultValue(true)]
            public bool WatchingEye { get; set; }

            [DefaultValue(true)]
            public bool WorldGlobe { get; set; }

            [DefaultValue(true)]
            public bool DedicatedItems { get; set; }

            public List<ItemDefinition> CustomItems { get; set; }

            [Range(1, 9999)]
            public List<int> CustomItemQuantities { get; set; }

            public override void OnLoaded()
            {
                QoLCompendium.itemConfig = this;
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
        }

        [SeparatePage]
        public class TooltipConfig : ModConfig
        {
            public override ConfigScope Mode => ConfigScope.ClientSide;

            [Header("$Mods.QoLCompendium.QoLCConfig.Headers.Tooltips")]

            [DefaultValue(true)]
            [ReloadRequired]
            public bool NoFavoriteTooltip { get; set; }
            
            [DefaultValue(true)]
            [ReloadRequired]
            public bool ShimmerableTooltip { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool WorksInBanksTooltip { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool UsedPermanentUpgradeTooltip { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool WingStatsTooltips { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool HookStatsTooltips { get; set; }

            public override void OnLoaded()
            {
                QoLCompendium.tooltipConfig = this;
            }
        }
    }
}
