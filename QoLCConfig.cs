using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace QoLCompendium
{
    public class QoLCConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("Endless Toggles")]
        [DefaultValue(true)]
        [Label("Endless Buffs & Healing")]
        [Tooltip("Toggles endless buffs & healing items on stacks of 30 or greater \nAlso works with buff stations \nYou only need 1 buff station for infinite buffs \nDefault value: True")]
        public bool EndlessBuffsAndHealing { get; set; }

        [DefaultValue(true)]
        [Label("Endless Consumables")]
        [Tooltip("Toggles endless consumables on stacks of 999 or greater \nIncludes boss summons, tiles, bait, weapons, ammo, and other misc items \nDefault value: True")]
        public bool EndlessConsumables { get; set; }

        [Slider]
        [DefaultValue(44)]
        [Range(0, 88)]
        [Label("Extra Buff Slots")]
        [Tooltip("Choose the amount of extra buff slots \nDefault value: 44")]
        public uint ExtraBuffSlots { get; set; }

        [Header("Spawn Toggles")]
        [DefaultValue(true)]
        [Label("Instant Respawn")]
        [Tooltip("Toggles instant respawns \nDespawns bosses on death if true \nDefault value: True")]
        public bool InstantRespawn { get; set; }

        [DefaultValue(true)]
        [Label("Full HP on Respawn")]
        [Tooltip("Toggles if you respawn with max health \nDefault value: True")]
        public bool FullHPRespawn { get; set; }

        [DefaultValue(true)]
        [Label("No Enemy Spawns During Bosses")]
        [Tooltip("Toggles enemy spawns during bosses \nDefault value: True")]
        public bool NoSpawns { get; set; }

        [Header("Item Toggles")]
        [DefaultValue(true)]
        [Label("Item Magnet")]
        [Tooltip("Toggles the Item Magnet item \nDefault value: True \nReload Required")]
        [ReloadRequired]
        public bool Magnet { get; set; }

        [DefaultValue(true)]
        [Label("Biome Globes")]
        [Tooltip("Toggles the Biome Globe items \nDefault value: True \nReload Required")]
        [ReloadRequired]
        public bool Globes { get; set; }

        [DefaultValue(true)]
        [Label("Erasers & Aggressors")]
        [Tooltip("Toggles the Eraser & Aggressor items \nDefault value: True \nReload Required")]
        [ReloadRequired]
        public bool Erasers { get; set; }

        [DefaultValue(true)]
        [Label("Cursed Mirror")]
        [Tooltip("Toggles the Cursed Mirror item \nDefault value: True \nReload Required")]
        [ReloadRequired]
        public bool CursedMirror { get; set; }

        [DefaultValue(true)]
        [Label("Head Counter")]
        [Tooltip("Toggles the Head Counter item \nDefault value: True \nReload Required")]
        [ReloadRequired]
        public bool HeadCounter { get; set; }

        [DefaultValue(true)]
        [Label("Forwarper")]
        [Tooltip("Toggles the Forwarper item \nDefault value: True \nReload Required")]
        [ReloadRequired]
        public bool Forwarper { get; set; }

        [DefaultValue(true)]
        [Label("Moon Phaser")]
        [Tooltip("Toggles the Moon Phaser item \nDefault value: True \nReload Required")]
        [ReloadRequired]
        public bool MoonPhaser { get; set; }

        [DefaultValue(true)]
        [Label("Watching Eye")]
        [Tooltip("Toggles the Watching Eye item \nDefault value: True \nReload Required")]
        [ReloadRequired]
        public bool WatchingEye { get; set; }

        [DefaultValue(true)]
        [Label("Hellevator Creator")]
        [Tooltip("Toggles the Hellevator Creator item \nDefault value: True \nReload Required")]
        [ReloadRequired]
        public bool HCreator { get; set; }

        [DefaultValue(true)]
        [Label("Auto Houser")]
        [Tooltip("Toggles the Auto Houser item \nDefault value: True \nReload Required")]
        [ReloadRequired]
        public bool AHouser { get; set; }

        [DefaultValue(true)]
        [Label("Boss Bags Don't Drop Dev Sets")]
        [Tooltip("Toggles if boss bags can drop dev sets \nDefault value: True")]
        [ReloadRequired]
        public bool NoDevs { get; set; }

        [DefaultValue(true)]
        [Label("Increase Item Stack Size")]
        [Tooltip("Toggles increased max stacks for items \nDefault value: True")]
        public bool IncreasedStackSize { get; set; }

        [DefaultValue(true)]
        [Label("All Accessories Can be Placed in Vanity")]
        [Tooltip("Toggles if vanity slots can host all accessories \nDefault value: True")]
        public bool VanityAccessories { get; set; }

        [Header("NPC Toggles")]
        [DefaultValue(true)]
        [Label("Black Market Dealer NPC")]
        [Tooltip("Toggles the Black Market Dealer NPC \nDefault value: True \nReload Required")]
        [ReloadRequired]
        public bool BMNPC { get; set; }

        [DefaultValue(true)]
        [Label("Ethereal Collector NPC")]
        [Tooltip("Toggles the Ethereal Collector NPC \nDefault value: True \nReload Required")]
        [ReloadRequired]
        public bool ECNPC { get; set; }

        [DefaultValue(true)]
        [Label("Invincible NPCs")]
        [Tooltip("Toggles whether friendly NPCs take damage \nDefault value: True")]
        public bool FriendliesDontDie { get; set; }

        [DefaultValue(true)]
        [Label("No NPC Happiness")]
        [Tooltip("Toggles if NPCs should have happiness or not \nDefault value: True \nReload Required")]
        [ReloadRequired]
        public bool ToggleHappiness { get; set; }

        [Slider]
        [DefaultValue(15)]
        [Range(1, 100)]
        [Increment(5)]
        [Label("Celestial Tower Shield Health")]
        [Tooltip("Changes the shield health of the celestial towers \nDefault value: 15")]
        [ReloadRequired]
        public int TowerShield { get; set; }

        [Slider]
        [DefaultValue(3)]
        [Range(1, 25)]
        [Label("Increased Coin Drops")]
        [Tooltip("Increases the amount of dropped coins \nDefault value: 3")]
        public int MoreCoins { get; set; }

        [Header("Speed Toggles")]
        [DefaultValue(true)]
        [Label("Faster Placement Speed & Increased Placement Range")]
        [Tooltip("Toggles faster placement speed & increased placement range \nDefault value: True")]
        public bool IncreasePlaceSpeed { get; set; }

        [DefaultValue(true)]
        [Label("Faster Tools")]
        [Tooltip("Toggles faster tool use speed \nDefault value: True \nReload Required")]
        [ReloadRequired]
        public bool FastTools { get; set; }

        [DefaultValue(true)]
        [Label("Faster Extractinator")]
        [Tooltip("Toggles faster extractinator use speed \nDefault value: True")]
        public bool FastExtractor { get; set; }

        [Header("Other Toggles")]
        [DefaultValue(true)]
        [Label("Auto Stack Money")]
        [Tooltip("Toggles money automatically going into the bank \nRequires at least 1 copper in the bank to function \nDefault value: True")]
        public bool AutoMoneyStack { get; set; }

        [DefaultValue(true)]
        [Label("Lifeform Locator")]
        [Tooltip("Toggles an arrow that points towards rare creatures when using a lifeform analyzer \nDefault value: True")]
        public bool LifeformPointer { get; set; }

        [DefaultValue(true)]
        [Label("Autoswing")]
        [Tooltip("Toggles weapon autoswing \nDefault value: True")]
        public bool AutoSwingin { get; set; }

        [DefaultValue(true)]
        [Label("Info Accessories Work In Banks")]
        [Tooltip("Toggles if informational, fishing, mining, and building accessories work in banks \nDefault value: True")]
        public bool InformationBanks { get; set; }

        [DefaultValue(true)]
        [Label("Map Teleporting")]
        [Tooltip("Toggles if you can right click on the map to teleport to that position \nDefault value: True")]
        public bool MapPorting { get; set; }

        [DefaultValue(true)]
        [Label("Money Trough Follows You")]
        [Tooltip("Toggles if the Money Trough follows you \nDefault value: True")]
        public bool StalkerMoneyTrough { get; set; }

        [DefaultValue(true)]
        [Label("Extra Lures")]
        [Tooltip("Toggles if fishing rods fire extra lures \nDefault value: True")]
        public bool ExtraLures { get; set; }

        [DefaultValue(true)]
        [Label("No Block Litter")]
        [Tooltip("Toggles if certain projectiles don't place their tile \nDefault value: True")]
        public bool NoLittering { get; set; }
    }
}
