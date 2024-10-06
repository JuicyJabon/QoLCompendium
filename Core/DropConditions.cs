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

    public class ExpertOnlyCalamityDropCondition : IItemDropRuleCondition, IProvideItemConditionDescription
    {
        public bool CanDrop(DropAttemptInfo info)
        {
            if (info.npc.boss && QoLCompendium.mainConfig.RelicsInExpert && !Main.masterMode && ModConditions.calamityLoaded && (!(bool)ModConditions.calamityMod.Call("DifficultyActive", "revengeance") || !(bool)ModConditions.calamityMod.Call("DifficultyActive", "death")))
                return Main.expertMode;

            return false;
        }

        public bool CanShowItemDropInUI()
        {
            return Main.expertMode && QoLCompendium.mainConfig.RelicsInExpert && !Main.masterMode && ModConditions.calamityLoaded && (!(bool)ModConditions.calamityMod.Call("DifficultyActive", "revengeance") || !(bool)ModConditions.calamityMod.Call("DifficultyActive", "death"));
        }

        public string GetConditionDescription()
        {
            return Language.GetTextValue("Mods.QoLCompendium.NPCDropConditions.ExpertNotMaster");
        }
    }

    public class ExpertOnlyFargoSoulsDropCondition : IItemDropRuleCondition, IProvideItemConditionDescription
    {
        public bool CanDrop(DropAttemptInfo info)
        {
            if (info.npc.boss && QoLCompendium.mainConfig.RelicsInExpert && !Main.masterMode && ModConditions.fargosSoulsLoaded && !(bool)ModConditions.fargosSoulsMod.Call("EternityMode"))
                return Main.expertMode;

            return false;
        }

        public bool CanShowItemDropInUI()
        {
            return Main.expertMode && QoLCompendium.mainConfig.RelicsInExpert && !Main.masterMode && ModConditions.fargosSoulsLoaded && !(bool)ModConditions.fargosSoulsMod.Call("EternityMode");
        }

        public string GetConditionDescription()
        {
            return Language.GetTextValue("Mods.QoLCompendium.NPCDropConditions.ExpertNotMaster");
        }
    }

    public class ExpertOnlyFargoSoulsAndCalamityDropCondition : IItemDropRuleCondition, IProvideItemConditionDescription
    {
        public bool CanDrop(DropAttemptInfo info)
        {
            if (info.npc.boss && QoLCompendium.mainConfig.RelicsInExpert && !Main.masterMode && ModConditions.fargosSoulsLoaded && !(bool)ModConditions.fargosSoulsMod.Call("EternityMode") && ModConditions.calamityLoaded && (!(bool)ModConditions.calamityMod.Call("DifficultyActive", "revengeance") || !(bool)ModConditions.calamityMod.Call("DifficultyActive", "death")))
                return Main.expertMode;

            return false;
        }

        public bool CanShowItemDropInUI()
        {
            return Main.expertMode && QoLCompendium.mainConfig.RelicsInExpert && !Main.masterMode && ModConditions.fargosSoulsLoaded && !(bool)ModConditions.fargosSoulsMod.Call("EternityMode") && ModConditions.calamityLoaded && (!(bool)ModConditions.calamityMod.Call("DifficultyActive", "revengeance") || !(bool)ModConditions.calamityMod.Call("DifficultyActive", "death"));
        }

        public string GetConditionDescription()
        {
            return Language.GetTextValue("Mods.QoLCompendium.NPCDropConditions.ExpertNotMaster");
        }
    }
}
