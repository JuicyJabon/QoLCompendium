namespace QoLCompendium.Core.Changes.ModChanges.ModItemChanges
{
    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class MartinsOrderItemTransmutation : GlobalItem
    {
        public override void SetStaticDefaults()
        {
            if (QoLCompendium.mainConfig.ItemConversions)
            {
                Common.TransmuteItems([Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "AquaRock"), Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "Charcoal"), Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "MagmaRock")]);
            }
        }
    }
}
