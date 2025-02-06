using Terraria.GameContent.ItemDropRules;

namespace QoLCompendium.Core
{
    public class ExpertOnlyDropCondition : IItemDropRuleCondition, IProvideItemConditionDescription
    {
        public bool CanDrop(DropAttemptInfo info)
        {
            if (info.npc.boss && QoLCompendium.mainConfig.RelicsInExpert && !Main.masterMode)
                return Main.expertMode;

            return false;
        }

        public bool CanShowItemDropInUI()
        {
            return Main.expertMode && QoLCompendium.mainConfig.RelicsInExpert && !Main.masterMode;
        }

        public string GetConditionDescription()
        {
            return Language.GetTextValue("Mods.QoLCompendium.NPCDropConditions.ExpertNotMaster");
        }
    }
}
