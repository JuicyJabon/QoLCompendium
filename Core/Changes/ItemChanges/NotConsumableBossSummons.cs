namespace QoLCompendium.Core.Changes.ItemChanges
{
    public class NotConsumableBossSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            if ((Constants.VanillaBossSummons.Contains(entity.type) && QoLCompendium.mainConfig.EndlessBossSummons && !CrossModSupport.Calamity.Loaded) 
                || (entity.type == ItemID.LihzahrdPowerCell && QoLCompendium.mainConfig.EndlessBossSummons))
                return true;
            else if (Constants.VanillaEventSummons.Contains(entity.type) && QoLCompendium.mainConfig.EndlessBossSummons)
                return true;
            else if (Constants.ModdedBossSummons.Contains(entity.type) && QoLCompendium.mainConfig.EndlessBossSummons)
                return true;
            else if (Constants.ModdedEventSummons.Contains(entity.type) && QoLCompendium.mainConfig.EndlessBossSummons)
                return true;
            else if (Constants.FargosBossSummons.Contains(entity.type) && QoLCompendium.mainConfig.EndlessBossSummons)
                return true;
            else if (Constants.FargosEventSummons.Contains(entity.type) && QoLCompendium.mainConfig.EndlessBossSummons)
                return true;
            else if (Constants.FargosEnemySummons.Contains(entity.type) && QoLCompendium.mainConfig.EndlessBossSummons)
                return true;
            else
                return false;
        }

        public override void SetDefaults(Item item)
        {
            item.consumable = false;
            if (!Constants.FargosBossSummons.Contains(item.type) && !Constants.FargosEventSummons.Contains(item.type) && !Constants.FargosEnemySummons.Contains(item.type))
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
