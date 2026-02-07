namespace QoLCompendium.Core.Changes.ItemChanges
{
    public class NotConsumableBossSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            if (Common.VanillaBossAndEventSummons.Contains(entity.type) && QoLCompendium.mainConfig.EndlessBossSummons && !CrossModSupport.Calamity.Loaded)
                return true;
            else if (Common.VanillaRightClickBossAndEventSummons.Contains(entity.type) && QoLCompendium.mainConfig.EndlessBossSummons)
                return true;
            else if (Common.ModdedBossAndEventSummons.Contains(entity.type) && QoLCompendium.mainConfig.EndlessBossSummons)
                return true;
            else if (Common.FargosBossAndEventSummons.Contains(entity.type) && QoLCompendium.mainConfig.EndlessBossSummons)
                return true;
            else
                return false;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            if (!Common.FargosBossAndEventSummons.Contains(item.type))
                item.maxStack = 1;
        }

        public override bool ConsumeItem(Item item, Player player) => false;

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tip = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            tooltips.Insert(tooltips.IndexOf(tip), text);
        }
    }
}
