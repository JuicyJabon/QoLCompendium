using Newtonsoft.Json;

namespace QoLCompendium.Core.ShopData
{
    public static class ShopCreation
    {
        public static Dictionary<string, string> AllShops = [];
        public static Dictionary<string, string> Potions = [];
        public static Dictionary<string, string> StationsAndUpgrades = [];
        public static Dictionary<string, string> Materials = [];
        public static Dictionary<string, string> MobilityAccessories = [];
        public static Dictionary<string, string> CombatAccessories = [];
        public static Dictionary<string, string> ToolsAndInfo = [];
        public static Dictionary<string, string> TreasureBags = [];
        public static Dictionary<string, string> CratesAndGrabBags = [];
        public static Dictionary<string, string> OresAndBars = [];
        public static Dictionary<string, string> NaturalBlocks = [];
        public static Dictionary<string, string> BuildingBlocks = [];
        public static Dictionary<string, string> HerbsAndPlants = [];
        public static Dictionary<string, string> Fish = [];
        public static Dictionary<string, string> Critters = [];
        public static Dictionary<string, string> MountsAndHooks = [];
        public static Dictionary<string, string> Ammo = [];

        public static bool FileNotFound = false;

        public const string shopFilePath = "Core/ShopData/ShopDatabase.json";

        public static void PostSetupTasks()
        {
            if (!QoLCompendium.Instance.FileExists(shopFilePath))
            {
                FileNotFound = true;
                return;
            }

            using Stream stream = QoLCompendium.Instance.GetFileStream(shopFilePath);
            using StreamReader r = new(stream);
            var readAllShops = JsonConvert.DeserializeObject<Dictionary<string, string>>(r.ReadToEnd());

            foreach (var entry in readAllShops)
            {
                AllShops.Add(entry.Key, entry.Value);
                if (entry.Key.Contains("Potion"))
                {
                    Potions.Add(entry.Key, entry.Value);
                }
            }
        }

        public static void UnloadTasks()
        {
            AllShops.Clear();
            Potions.Clear();
        }
    }
}