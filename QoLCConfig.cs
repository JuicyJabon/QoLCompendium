using System;
using System.Collections.Generic;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace QoLCompendium
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
        public  bool EndlessAmmo { get; set; }

        [DefaultValue(true)]
        public  bool EndlessBait { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public  bool EndlessBossSummons { get; set; }

        [DefaultValue(true)]
        public  bool EndlessConsumables { get; set; }

        [Slider]
        [DefaultValue(30)]
        [Range(1, 60)]
        public  int EndlessBuffAmount { get; set; }

        [Slider]
        [DefaultValue(30)]
        [Range(1, 60)]
        public int EndlessHealingAmount { get; set; }

        [Slider]
        [DefaultValue(999)]
        [Increment(50)]
        [Range(1, 999)]
        public  int EndlessAmount { get; set; }

        [Header("$Mods.QoLCompendium.QoLCConfig.Headers.Spawn")]
        [DefaultValue(true)]
        public  bool InstantRespawn { get; set; }

        [DefaultValue(true)]
        public  bool FullHPRespawn { get; set; }

        [DefaultValue(true)]
        public  bool NoSpawns { get; set; }

        [Header("$Mods.QoLCompendium.QoLCConfig.Headers.Items2")]
        [DefaultValue(true)]
        public  bool NoDevs { get; set; }

        [DefaultValue(true)]
        public  bool IncreaseMaxStack { get; set; }

        [DefaultValue(true)]
        public  bool InformationBanks { get; set; }

        [Slider]
        [DefaultValue(5)]
        [Range(1, 25)]
        public  int MoreCoins { get; set; }

        [DefaultValue(true)]
        public  bool AutoMoneyStack { get; set; }

        [DefaultValue(true)]
        public bool NoFavoriteTooltip { get; set; }

        public  List<ItemDefinition> CustomItems { get; set; }

        [Range(0, 999)]
        public  List<int> CustomItemQuantities { get; set; }

        [Header("$Mods.QoLCompendium.QoLCConfig.Headers.NPCs")]
        [DefaultValue(true)]
        public  bool BMNPC { get; set; }

        [DefaultValue(true)]
        public  bool ECNPC { get; set; }

        [DefaultValue(true)]
        public  bool FriendliesDontDie { get; set; }

        [DefaultValue(true)]
        public  bool FastTownieSpawns { get; set; }

        [DefaultValue(true)]
        public  bool TownieSpawn { get; set; }

        [DefaultValue(true)]
        public bool GoHomeNPCs { get; set; }

        [DefaultValue(true)]
        public bool NoTownSlimes { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public  bool ToggleHappiness { get; set; }

        [Slider]
        [DefaultValue(0.75f)]
        [Increment(0.01f)]
        [Range(0, 1)]
        public  float HappinessPriceChange { get; set; }

        [Slider]
        [DefaultValue(10)]
        [Range(1, 100)]
        [Increment(5)]
        public  int TowerShield { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public  bool LavaSlimeNoLava { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public  bool StopOpeningDoors { get; set; }

        [Header("$Mods.QoLCompendium.QoLCConfig.Headers.Projectiles")]
        [DefaultValue(true)]
        public  bool ExtraLures { get; set; }

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
        public  int IncreasePlaceRange { get; set; }

        [DefaultValue(0d)]
        [Range(0, 1f)]
        [Slider]
        [Increment(0.125f)]
        public  float FastTools { get; set; }

        [DefaultValue(true)]
        public  bool FastExtractor { get; set; }

        [Header("$Mods.QoLCompendium.QoLCConfig.Headers.Player")]
        [Slider]
        [DefaultValue(44)]
        [Range(0, 88)]
        public  uint ExtraBuffSlots { get; set; }

        [DefaultValue(true)]
        public  bool RegrowthAutoReplant { get; set; }

        [DefaultValue(true)]
        public  bool LifeformPointer { get; set; }

        [DefaultValue(true)]
        public  bool WingSlot { get; set; }

        [DefaultValue(true)]
        public bool NoChilled { get; set; }

        [Slider]
        [DefaultValue(1)]
        [Range(0, 5)]
        [Increment(1)]
        public int AutoTeams { get; set; }

        [DefaultValue(true)]
        public bool NoTombs { get; set; }

        [DefaultValue(true)]
        public bool MapPorting { get; set; }

        [Header("$Mods.QoLCompendium.QoLCConfig.Headers.World")]
        [DefaultValue(true)]
        [ReloadRequired]
        public  bool DisableEvilSpread { get; set; }

        [DefaultValue(true)]
        public  bool FastTrees { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public  bool FastHerbs { get; set; }

        [DefaultValue(true)]
        public  bool Christmas { get; set; }

        [DefaultValue(true)]
        public  bool Halloween { get; set; }

        public override void OnLoaded()
        {
            QoLCompendium.mainConfig = this;
        }

        [SeparatePage]
        public class ItemConfig : ModConfig
        {
            public override ConfigScope Mode => ConfigScope.ServerSide;

            [Header("$Mods.QoLCompendium.QoLCConfig.Headers.Items")]

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool AsphaltPlatform { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool AutoStructures { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool BannerBox { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool EntityManipulator { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool Forwarper { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool InformationAccessories { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool Magnets { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool Mirrors { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool MobileStorages { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool MoonPedestals { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool Paperweight { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool PotionCrate { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool StarterBag { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool SummoningRemote { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool WatchingEye { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool WorldGlobe { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool DedicatedItems { get; set; }

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
            public  bool BMPotionShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool BMStationShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool BMMaterialShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool BMHardmodeMaterialShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool BMMovementAccessoryShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool BMCombatAccessoryShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool BMInformationShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool BMBagShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool BMCrateShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool BMOreShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool BMNaturalBlockShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool BMBuildingBlockShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool BMHerbShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public bool BMFishShop { get; set; }

            [Header("$Mods.QoLCompendium.QoLCConfig.Headers.ECShop")]

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool ECPotionShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool ECStationShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool ECMaterialShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool ECBagShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool ECCrateShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool ECOreShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool ECNaturalBlocksShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool ECBuildingBlocksShop { get; set; }

            [DefaultValue(true)]
            [ReloadRequired]
            public  bool ECHerbShop { get; set; }

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

            public override void OnLoaded()
            {
                QoLCompendium.shopConfig = this;
            }
        }
    }
}
