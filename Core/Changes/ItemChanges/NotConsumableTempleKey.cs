namespace QoLCompendium.Core.Changes.ItemChanges
{
    public class NotConsumableTempleKey : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            if (entity.type == ItemID.TempleKey && QoLCompendium.mainConfig.NonConsumableKeys)
                return true;
            return false;
        }

        public override void SetDefaults(Item entity)
        {
            entity.consumable = false;
        }

        public override bool ConsumeItem(Item item, Player player) => false;
    }
}
