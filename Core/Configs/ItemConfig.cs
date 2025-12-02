using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace QoLCompendium.Core.Configs
{
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

        //[DefaultValue(true)]
        //public bool CrossModItems { get; set; }

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
}
