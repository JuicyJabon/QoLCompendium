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
        public bool EndlessBuffsAndHealing { get; set; }

        [DefaultValue(true)]
        public bool EndlessConsumables { get; set; }

        [Slider]
        [DefaultValue(44)]
        [Range(0, 88)]
        public uint ExtraBuffSlots { get; set; }

        [Header("$Mods.QoLCompendium.QoLCConfig.Headers.Spawn")]
        [DefaultValue(true)]
        public bool InstantRespawn { get; set; }

        [DefaultValue(true)]
        public bool FullHPRespawn { get; set; }

        [DefaultValue(true)]
        public bool NoSpawns { get; set; }

        [Header("$Mods.QoLCompendium.QoLCConfig.Headers.NPCs")]
        [DefaultValue(true)]
        public bool BMNPC { get; set; }

        [DefaultValue(true)]
        public bool ECNPC { get; set; }

        [DefaultValue(true)]
        public bool FriendliesDontDie { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool ToggleHappiness { get; set; }

        [DefaultValue(true)]
        public bool TownieSpawn { get; set; }

        [Slider]
        [DefaultValue(15)]
        [Range(1, 150)]
        [Increment(5)]
        public int TowerShield { get; set; }

        [Slider]
        [DefaultValue(5)]
        [Range(1, 25)]
        public int MoreCoins { get; set; }

        [DefaultValue(true)]
        public bool LifeformPointer { get; set; }

        [DefaultValue(true)]
        public bool StalkerMoneyTrough { get; set; }

        [Header("$Mods.QoLCompendium.QoLCConfig.Headers.Speed")]
        [DefaultValue(true)]
        public bool IncreasePlaceSpeed { get; set; }

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

        [Header("$Mods.QoLCompendium.QoLCConfig.Headers.Other")]

        [DefaultValue(true)]
        public bool NoDevs { get; set; }

        [DefaultValue(true)]
        public bool ExtraLures { get; set; }

        [DefaultValue(true)]
        public bool AutoMoneyStack { get; set; }

        [DefaultValue(true)]
        public bool InformationBanks { get; set; }

        [DefaultValue(true)]
        public bool MapPorting { get; set; }

        [DefaultValue(true)]
        public bool NoLittering { get; set; }

        [DefaultValue(true)]
        public bool DisableEvilSpread { get; set; }

        [DefaultValue(true)]
        public bool RegrowthAutoReplant { get; set; }

        [DefaultValue(true)]
        public bool Christmas { get; set; }

        [DefaultValue(true)]
        public bool Halloween { get; set; }

        public List<ItemDefinition> CustomItems { get; set; }

        [Range(0, 999)]
        public List<int> CustomItemQuantities { get; set; }
    }

    public class ItemConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("$Mods.QoLCompendium.QoLCConfig.Headers.Items")]

        [DefaultValue(true)]
        [ReloadRequired]
        public bool AsphaltPlatform { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool AHouser { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool BBox { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool BloodIdol { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool CursedMirror { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool Erasers { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool Forwarper { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool Globes { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool HeadCounter { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool HCreator { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool Magnet { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool MoonPhaser { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool StarterBag { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool TArriver { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool WatchingEye { get; set; }
    }
}
