using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace QoLCompendium.Core.Configs
{
    public class CrossModConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("$Mods.QoLCompendium.ConfigHeaders.CrossMod")]

        [DefaultValue(true)]
        public bool AFKPetsCropFix { get; set; }

        [DefaultValue(true)]
        public bool AFKPetsFasterCropGrowth { get; set; }

        [DefaultValue(true)]
        public bool AFKPetsRegrowthReplant { get; set; }

        [DefaultValue(true)]
        public bool CrystalDragonsTopazPrefixFix { get; set; }

        [DefaultValue(true)]
        public bool MrPlagueRacesPrefixFix { get; set; }

        [DefaultValue(true)]
        public bool RemoveThoriumExhaustion { get; set; }

        [DefaultValue(true)]
        public bool RemoveThoriumExhaustionTooltip { get; set; }

        [DefaultValue(true)]
        public bool EndlessInspirationPotions { get; set; }

        [DefaultValue(30)]
        [Range(1, 99999)]
        public int EndlessInspirationPotionsAmount { get; set; }

        [DefaultValue(true)]
        public bool CalamityEntropyArmorPrefixesHaveEnchantedEffects { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool ShimmerableAnglerCoins { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool HomewardJourneyRarityFix { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool CalamityEffigyRecipes { get; set; }

        [DefaultValue(true)]
        public bool CalamityCrateDropRevert { get; set; }

        [DefaultValue(true)]
        public bool MoreCrateDrops { get; set; }

        [DefaultValue(true)]
        public bool EndlessVoidConsumables { get; set; }

        [DefaultValue(30)]
        [Range(1, 99999)]
        public int EndlessVoidConsumablesAmount { get; set; }

        [DefaultValue(false)]
        public bool ElementsAwokenPuffSlimes { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool SpiritClassicBossSummonClassificationFix { get; set; }

        public override void OnLoaded()
        {
            QoLCompendium.crossModConfig = this;
        }
    }
}
