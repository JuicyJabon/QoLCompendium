using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace QoLCompendium.Core.Configs
{
    public class ShopConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        //REMOVE \/\/\/\/

        [Header("$Mods.QoLCompendium.ConfigHeaders.ECShop")]

        [DefaultValue(true)]
        public bool ECPotionShop { get; set; }

        [DefaultValue(true)]
        public bool ECStationShop { get; set; }

        [DefaultValue(true)]
        public bool ECMaterialShop { get; set; }

        [DefaultValue(true)]
        public bool ECBagShop { get; set; }

        [DefaultValue(true)]
        public bool ECCrateShop { get; set; }

        [DefaultValue(true)]
        public bool ECOreShop { get; set; }

        [DefaultValue(true)]
        public bool ECNaturalBlocksShop { get; set; }

        [DefaultValue(true)]
        public bool ECBuildingBlocksShop { get; set; }

        [DefaultValue(true)]
        public bool ECHerbShop { get; set; }

        [DefaultValue(true)]
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
