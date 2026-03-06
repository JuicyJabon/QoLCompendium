using Terraria.GameContent.ItemDropRules;

namespace QoLCompendium.Core;

public static class DropHelper
{
    internal class LambdaDropRuleCondition : IItemDropRuleCondition, IProvideItemConditionDescription
    {
        private readonly Func<DropAttemptInfo, bool> conditionLambda;

        private readonly bool visibleInUI;

        private readonly string description;

        internal LambdaDropRuleCondition(Func<DropAttemptInfo, bool> lambda, bool ui = true, string desc = null)
        {
            conditionLambda = lambda;
            visibleInUI = ui;
            description = desc;
        }

        public bool CanDrop(DropAttemptInfo info)
        {
            return conditionLambda(info);
        }

        public bool CanShowItemDropInUI()
        {
            return visibleInUI;
        }

        public string GetConditionDescription()
        {
            return description;
        }
    }

    internal class LambdaDropRuleCondition2 : IItemDropRuleCondition, IProvideItemConditionDescription
    {
        private readonly Func<DropAttemptInfo, bool> conditionLambda;

        private readonly Func<bool> visibleInUI;

        private readonly string description;

        internal LambdaDropRuleCondition2(Func<DropAttemptInfo, bool> lambda, Func<bool> ui, string desc = null)
        {
            conditionLambda = lambda;
            visibleInUI = ui;
            description = desc;
        }

        public bool CanDrop(DropAttemptInfo info)
        {
            return conditionLambda(info);
        }

        public bool CanShowItemDropInUI()
        {
            return visibleInUI();
        }

        public string GetConditionDescription()
        {
            return description;
        }
    }

    internal class LambdaDropRuleCondition3 : IItemDropRuleCondition, IProvideItemConditionDescription
    {
        private readonly Func<DropAttemptInfo, bool> conditionLambda;

        private readonly Func<bool> visibleInUI;

        private readonly Func<string> description;

        internal LambdaDropRuleCondition3(Func<DropAttemptInfo, bool> lambda, Func<bool> ui, Func<string> desc)
        {
            conditionLambda = lambda;
            visibleInUI = ui;
            description = desc;
        }

        public bool CanDrop(DropAttemptInfo info)
        {
            return conditionLambda(info);
        }

        public bool CanShowItemDropInUI()
        {
            return visibleInUI();
        }

        public string GetConditionDescription()
        {
            return description();
        }
    }

    public const int NormalWeaponDropRateInt = 4;

    public const float NormalWeaponDropRateFloat = 0.25f;

    public static readonly Fraction NormalWeaponDropRateFraction = new Fraction(1, 4);

    public const int BagWeaponDropRateInt = 3;

    public const float BagWeaponDropRateFloat = 0.3333333f;

    public static readonly Fraction BagWeaponDropRateFraction = new Fraction(1, 3);

    public static IItemDropRuleCondition If(Func<bool> lambda)
    {
        return new LambdaDropRuleCondition((_) => lambda());
    }

    public static IItemDropRuleCondition If(Func<bool> lambda, bool ui = true, string desc = null)
    {
        return new LambdaDropRuleCondition(LambdaInfoWrapper, ui, desc);
        bool LambdaInfoWrapper(DropAttemptInfo _)
        {
            return lambda();
        }
    }

    public static IItemDropRuleCondition If(Func<bool> lambda, Func<bool> ui, string desc = null)
    {
        return new LambdaDropRuleCondition2(LambdaInfoWrapper, ui, desc);
        bool LambdaInfoWrapper(DropAttemptInfo _)
        {
            return lambda();
        }
    }

    public static IItemDropRuleCondition If(Func<bool> lambda, Func<bool> ui, Func<string> desc)
    {
        return new LambdaDropRuleCondition3(LambdaInfoWrapper, ui, desc);
        bool LambdaInfoWrapper(DropAttemptInfo _)
        {
            return lambda();
        }
    }

    public static IItemDropRuleCondition If(Func<DropAttemptInfo, bool> lambda)
    {
        return new LambdaDropRuleCondition(lambda);
    }

    public static IItemDropRuleCondition If(Func<DropAttemptInfo, bool> lambda, bool ui = true, string desc = null)
    {
        return new LambdaDropRuleCondition(lambda, ui, desc);
    }

    public static IItemDropRuleCondition If(Func<DropAttemptInfo, bool> lambda, Func<bool> ui, string desc = null)
    {
        return new LambdaDropRuleCondition2(lambda, ui, desc);
    }

    public static IItemDropRuleCondition If(Func<DropAttemptInfo, bool> lambda, Func<bool> ui, Func<string> desc)
    {
        return new LambdaDropRuleCondition3(lambda, ui, desc);
    }

    public static IItemDropRule Add(this LeadingConditionRule mainRule, IItemDropRule chainedRule, bool hideLootReport = false)
    {
        return mainRule.OnSuccess(chainedRule, hideLootReport);
    }

    public static IItemDropRule Add(this LeadingConditionRule mainRule, int itemID, int dropRateInt = 1, int minQuantity = 1, int maxQuantity = 1, bool hideLootReport = false)
    {
        return mainRule.OnSuccess(ItemDropRule.Common(itemID, dropRateInt, minQuantity, maxQuantity), hideLootReport);
    }

    public static IItemDropRule Add(this LeadingConditionRule mainRule, int itemID, Fraction dropRate, int minQuantity = 1, int maxQuantity = 1, bool hideLootReport = false)
    {
        return mainRule.OnSuccess(new CommonDrop(itemID, dropRate.denominator, minQuantity, maxQuantity, dropRate.numerator), hideLootReport);
    }

    public static IItemDropRule AddIf(this LeadingConditionRule mainRule, Func<bool> lambda, int itemID, int dropRateInt = 1, int minQuantity = 1, int maxQuantity = 1, bool hideLootReport = false, string desc = null)
    {
        return mainRule.OnSuccess(ItemDropRule.ByCondition(If(lambda, ui: true, desc), itemID, dropRateInt, minQuantity, maxQuantity), hideLootReport);
    }

    public static IItemDropRule AddIf(this LeadingConditionRule mainRule, Func<bool> lambda, int itemID, Fraction dropRate, int minQuantity = 1, int maxQuantity = 1, bool hideLootReport = false, string desc = null)
    {
        return mainRule.OnSuccess(ItemDropRule.ByCondition(If(lambda, ui: true, desc), itemID, dropRate.denominator, minQuantity, maxQuantity, dropRate.numerator), hideLootReport);
    }

    public static IItemDropRule AddIf(this LeadingConditionRule mainRule, Func<DropAttemptInfo, bool> lambda, int itemID, int dropRateInt = 1, int minQuantity = 1, int maxQuantity = 1, bool hideLootReport = false, string desc = null)
    {
        return mainRule.OnSuccess(ItemDropRule.ByCondition(If(lambda, ui: true, desc), itemID, dropRateInt, minQuantity, maxQuantity), hideLootReport);
    }

    public static IItemDropRule AddIf(this LeadingConditionRule mainRule, Func<DropAttemptInfo, bool> lambda, int itemID, Fraction dropRate, int minQuantity = 1, int maxQuantity = 1, bool hideLootReport = false, string desc = null)
    {
        return mainRule.OnSuccess(ItemDropRule.ByCondition(If(lambda, ui: true, desc), itemID, dropRate.denominator, minQuantity, maxQuantity, dropRate.numerator), hideLootReport);
    }

    public static IItemDropRule AddFail(this LeadingConditionRule mainRule, IItemDropRule chainedRule, bool hideLootReport = false)
    {
        return mainRule.OnFailedConditions(chainedRule, hideLootReport);
    }

    public static IItemDropRule AddFail(this LeadingConditionRule mainRule, int itemID, int dropRateInt = 1, int minQuantity = 1, int maxQuantity = 1, bool hideLootReport = false)
    {
        return mainRule.OnFailedConditions(ItemDropRule.Common(itemID, dropRateInt, minQuantity, maxQuantity), hideLootReport);
    }

    public static IItemDropRule AddFail(this LeadingConditionRule mainRule, int itemID, Fraction dropRate, int minQuantity = 1, int maxQuantity = 1, bool hideLootReport = false)
    {
        return mainRule.OnFailedConditions(new CommonDrop(itemID, dropRate.denominator, minQuantity, maxQuantity, dropRate.numerator), hideLootReport);
    }

    public static IItemDropRule Add(this ILoot loot, int itemID, int dropRateInt = 1, int minQuantity = 1, int maxQuantity = 1)
    {
        return loot.Add(ItemDropRule.Common(itemID, dropRateInt, minQuantity, maxQuantity));
    }

    public static IItemDropRule Add(this ILoot loot, int itemID, Fraction dropRate, int minQuantity = 1, int maxQuantity = 1)
    {
        return loot.Add(new CommonDrop(itemID, dropRate.denominator, minQuantity, maxQuantity, dropRate.numerator));
    }

    public static IItemDropRule AddIf(this ILoot loot, IItemDropRuleCondition cond, int itemID, int dropRateInt = 1, int minQuantity = 1, int maxQuantity = 1)
    {
        return loot.Add(ItemDropRule.ByCondition(cond, itemID, dropRateInt, minQuantity, maxQuantity));
    }

    public static IItemDropRule AddIf(this ILoot loot, IItemDropRuleCondition cond, int itemID, Fraction dropRate, int minQuantity = 1, int maxQuantity = 1)
    {
        return loot.Add(ItemDropRule.ByCondition(cond, itemID, dropRate.denominator, minQuantity, maxQuantity, dropRate.numerator));
    }

    public static IItemDropRule AddIf(this ILoot loot, Func<bool> lambda, int itemID, int dropRateInt = 1, int minQuantity = 1, int maxQuantity = 1, bool ui = true, string desc = null)
    {
        return loot.Add(ItemDropRule.ByCondition(If(lambda, ui, desc), itemID, dropRateInt, minQuantity, maxQuantity));
    }

    public static IItemDropRule AddIf(this ILoot loot, Func<bool> lambda, int itemID, Fraction dropRate, int minQuantity = 1, int maxQuantity = 1, bool ui = true, string desc = null)
    {
        return loot.Add(ItemDropRule.ByCondition(If(lambda, ui, desc), itemID, dropRate.denominator, minQuantity, maxQuantity, dropRate.numerator));
    }

    public static IItemDropRule AddIf(this ILoot loot, Func<DropAttemptInfo, bool> lambda, int itemID, int dropRateInt = 1, int minQuantity = 1, int maxQuantity = 1, bool ui = true, string desc = null)
    {
        return loot.Add(ItemDropRule.ByCondition(If(lambda, ui, desc), itemID, dropRateInt, minQuantity, maxQuantity));
    }

    public static IItemDropRule AddIf(this ILoot loot, Func<DropAttemptInfo, bool> lambda, int itemID, Fraction dropRate, int minQuantity = 1, int maxQuantity = 1, bool ui = true, string desc = null)
    {
        return loot.Add(ItemDropRule.ByCondition(If(lambda, ui, desc), itemID, dropRate.denominator, minQuantity, maxQuantity, dropRate.numerator));
    }

    public static IItemDropRule AddNormalOnly(this ILoot loot, int itemID, int dropRateInt = 1, int minQuantity = 1, int maxQuantity = 1)
    {
        return loot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), itemID, dropRateInt, minQuantity, maxQuantity));
    }

    public static IItemDropRule AddNormalOnly(this ILoot loot, int itemID, Fraction dropRate, int minQuantity = 1, int maxQuantity = 1)
    {
        return loot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), itemID, dropRate.denominator, minQuantity, maxQuantity, dropRate.numerator));
    }

    public static void AddNormalOnly(this ILoot loot, IItemDropRule rule)
    {
        loot.DefineNormalOnlyDropSet().Add(rule);
    }

    public static LeadingConditionRule DefineConditionalDropSet(this ILoot loot, IItemDropRuleCondition condition)
    {
        LeadingConditionRule leadingConditionRule = new LeadingConditionRule(condition);
        loot.Add(leadingConditionRule);
        return leadingConditionRule;
    }

    public static LeadingConditionRule DefineConditionalDropSet(this ILoot loot, Func<bool> lambda)
    {
        return loot.DefineConditionalDropSet(If(lambda));
    }

    public static LeadingConditionRule DefineConditionalDropSet(this ILoot loot, Func<DropAttemptInfo, bool> lambda)
    {
        return loot.DefineConditionalDropSet(If(lambda));
    }

    public static LeadingConditionRule DefineNormalOnlyDropSet(this ILoot loot)
    {
        return loot.DefineConditionalDropSet(new Conditions.NotExpert());
    }
}