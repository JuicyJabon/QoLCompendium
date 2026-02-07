using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace QoLCompendium.Core.Configs
{
    public class ShopConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("$Mods.QoLCompendium.ConfigHeaders.BMShop")]

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
        public bool BMCritterShop { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool BMMountShop { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool BMAmmoShop { get; set; }

        [Header("$Mods.QoLCompendium.ConfigHeaders.ECShop")]

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

        [Header("$Mods.QoLCompendium.ConfigHeaders.Prices")]

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
        public int CritterPriceMultiplier { get; set; }

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
}
