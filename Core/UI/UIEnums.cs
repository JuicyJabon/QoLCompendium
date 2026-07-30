namespace QoLCompendium.Core.UI
{
    public class UIEnums
    {
        public enum BiomeTypes
        {
            Purity = 0,
            Desert = 1,
            Snow = 2,
            Jungle = 3,
            Glowshroom = 4,
            Corruption = 5,
            Crimson = 6,
            Hallow = 7,
            NoSelection = 8
        }

        public enum EventTypes
        {
            Party = 0,
            LanternNight = 1,
            Rain = 2,
            Sandstorm = 3,
            WindyDay = 4,
            BloodMoon = 5,
            SlimeRain = 6,
            GoblinArmy = 7,
            FrostLegion = 8,
            PirateInvasion = 9,
            SolarEclipse = 10,
            PumpkinMoon = 11,
            FrostMoon = 12,
            MartianMadness = 13,
            LunarEvent = 14,
        }

        public enum MoonPhases
        {
            Full = 0,
            WaningGibbous = 1,
            ThirdQuarter = 2,
            WaningCrescent = 3,
            New = 4,
            WaxingCrescent = 5,
            FirstQuarter = 6,
            WaxingGibbous = 7
        }

        public enum SpawnRateManipulators
        {
            IncreasedSpawns = 0,
            DecreasedSpawns = 1,
            NoSpawns = 2,
            NoEvents = 3,
            NoSelection = 4
        }

        public enum TimeManipulators
        {
            AlwaysDay = 0,
            AlwaysNight = 1,
            AlwaysBloodMoon = 2,
            AlwaysEclipse = 3,
            TimePaused = 4,
            NoSelection = 5
        }
    }
}
