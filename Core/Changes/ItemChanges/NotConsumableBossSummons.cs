namespace QoLCompendium.Core.Changes.ItemChanges
{
    public class NotConsumableBossSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            if ((Common.VanillaBossSummons.Contains(entity.type) && QoLCompendium.mainConfig.EndlessBossSummons && !CrossModSupport.Calamity.Loaded) 
                || (entity.type == ItemID.LihzahrdPowerCell && QoLCompendium.mainConfig.EndlessBossSummons))
                return true;
            else if (Common.VanillaEventSummons.Contains(entity.type) && QoLCompendium.mainConfig.EndlessBossSummons)
                return true;
            else if (Common.ModdedBossSummons.Contains(entity.type) && QoLCompendium.mainConfig.EndlessBossSummons)
                return true;
            else if (Common.ModdedEventSummons.Contains(entity.type) && QoLCompendium.mainConfig.EndlessBossSummons)
                return true;
            else if (Common.FargosBossSummons.Contains(entity.type) && QoLCompendium.mainConfig.EndlessBossSummons)
                return true;
            else if (Common.FargosEventSummons.Contains(entity.type) && QoLCompendium.mainConfig.EndlessBossSummons)
                return true;
            else if (Common.FargosEnemySummons.Contains(entity.type) && QoLCompendium.mainConfig.EndlessBossSummons)
                return true;
            else
                return false;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            if (!Common.FargosBossSummons.Contains(item.type) && !Common.FargosEventSummons.Contains(item.type) && !Common.FargosEnemySummons.Contains(item.type))
                item.maxStack = 1;
        }

        public override bool ConsumeItem(Item item, Player player) => false;

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine text = new(Mod, "NotConsumable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.NotConsumable"));
            Common.AddLastTooltip(tooltips, text);
        }
    }
}
