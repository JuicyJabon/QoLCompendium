using CalamityMod.World;
using FargowiltasSouls.Core.Systems;
using Terraria.GameContent.ItemDropRules;

namespace QoLCompendium.Core
{
    public class ExpertOnlyDropCondition : IItemDropRuleCondition, IProvideItemConditionDescription
    {
        [JITWhenModsEnabled("CalamityMod")]
        public static bool RevengeanceMode => CalamityWorld.revenge;

        [JITWhenModsEnabled("CalamityMod")]
        public static bool DeathMode => CalamityWorld.death;

        [JITWhenModsEnabled("FargowiltasSouls")]
        public static bool EternityMode => WorldSavingSystem.EternityMode;

        public bool CanDrop(DropAttemptInfo info)
        {
            if (info.npc.boss && QoLCompendium.mainConfig.RelicsInExpert && !Main.masterMode && !CalamityDifficultyEnabled() && !FargoSoulsDifficultyEnabled())
                return Main.expertMode;

            return false;
        }

        public bool CanShowItemDropInUI()
        {
            return Main.expertMode && QoLCompendium.mainConfig.RelicsInExpert && !Main.masterMode && !CalamityDifficultyEnabled() && !FargoSoulsDifficultyEnabled();
        }

        public string GetConditionDescription()
        {
            return Language.GetTextValue("Mods.QoLCompendium.NPCDropConditions.ExpertNotMaster");
        }

        public static bool CalamityDifficultyEnabled()
        {
            if (ModLoader.HasMod("CalamityMod"))
            {
                if (RevengeanceMode || DeathMode)
                    return true;
            }
            return false;
        }

        public static bool FargoSoulsDifficultyEnabled()
        {
            if (ModLoader.HasMod("FargowiltasSouls"))
            {
                if (EternityMode)
                    return true;
            }
            return false;
        }
    }
}
