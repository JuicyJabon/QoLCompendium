using Newtonsoft.Json;

namespace QoLCompendium.Core.ShopData
{
    public static class ShopCreation
    {
        public static Dictionary<string, Dictionary<string, List<string>>> AllShops = [];
        public static Dictionary<string, List<string>> Potions = [];
        public static Dictionary<string, List<string>> StationsAndUpgrades = [];
        public static Dictionary<string, List<string>> Materials = [];
        public static Dictionary<string, List<string>> MobilityAccessories = [];
        public static Dictionary<string, List<string>> CombatAccessories = [];
        public static Dictionary<string, List<string>> ToolsAndInfo = [];
        public static Dictionary<string, List<string>> TreasureBags = [];
        public static Dictionary<string, List<string>> CratesAndGrabBags = [];
        public static Dictionary<string, List<string>> OresAndBars = [];
        public static Dictionary<string, List<string>> NaturalBlocks = [];
        public static Dictionary<string, List<string>> BuildingBlocks = [];
        public static Dictionary<string, List<string>> HerbsAndPlants = [];
        public static Dictionary<string, List<string>> Fish = [];
        public static Dictionary<string, List<string>> Critters = [];
        public static Dictionary<string, List<string>> MountsAndHooks = [];
        public static Dictionary<string, List<string>> Ammo = [];

        public static bool FileNotFound = false;

        public const string shopFilePath = "Core/ShopData/ShopDatabase.json";

        public static void PostSetupTasks()
        {
            if (!QoLCompendium.Instance.FileExists(shopFilePath))
            {
                FileNotFound = true;
                return;
            }

            var serializer = new JsonSerializer();

            using Stream stream = QoLCompendium.Instance.GetFileStream(shopFilePath);
            using StreamReader r = new(stream);

            using var jsonReader = new JsonTextReader(r);

            Dictionary<string, Dictionary<string, List<string>>> shops = serializer.Deserialize<Dictionary<string, Dictionary<string, List<string>>>>(jsonReader)!;

            Potions = shops["PotionShop"];
            StationsAndUpgrades = shops["StationsAndUpgradesShop"];

            foreach (var shop in shops)
            {
                AllShops.Add(shop.Key, shop.Value);
            }
        }

        public static void UnloadTasks()
        {
            AllShops.Clear();
            Potions.Clear();
        }
    }
}