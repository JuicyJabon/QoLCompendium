namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    public static class ConsolariaBuffItems
    {
        public static void LoadTasks()
        {
            if (!CrossModSupport.Consolaria.Loaded)
                return;

            NewBuffEffect[] ConsolariaEffects = [new NewBuffEffect(Common.GetModBuff(CrossModSupport.Consolaria.Mod, "Drunk"))];

            foreach (var newEffect in ConsolariaEffects)
                ItemUtils.CreatePermanentBuffEffect(newEffect);

            NewBuffItem[] BuffItems = [new NewBuffItem(Common.GetModItem(CrossModSupport.Consolaria.Mod, "Wiesnbrau"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Consolaria.Mod, "Drunk")], 30, "PermanentWiesnbrau")];

            foreach (var newBuffItem in BuffItems)
                ItemUtils.CreatePermanentBuffItem(newBuffItem);
        }
    }
}
