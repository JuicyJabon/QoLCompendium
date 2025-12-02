using QoLCompendium.Core.PermanentBuffSystems.Items;

namespace QoLCompendium.Core.PermanentBuffSystems
{
    public static class PermanentBuffLoader
    {
        public static void LoadTasks()
        {
            VanillaBuffItems.LoadTasks();
            if (ModConditions.calamityLoaded)
                CalamityBuffItems.LoadTasks();
            if (ModConditions.clickerClassLoaded)
                ClickerClassBuffItems.LoadTasks();
            if (ModConditions.consolariaLoaded)
                ConsolariaBuffItems.LoadTasks();
            if (ModConditions.homewardJourneyLoaded)
                HomewardJourneyBuffItems.LoadTasks();
            if (ModConditions.martainsOrderLoaded)
                MartinsOrderBuffItems.LoadTasks();
            if (ModConditions.redemptionLoaded)
                RedemptionBuffItems.LoadTasks();
            if (ModConditions.secretsOfTheShadowsLoaded)
                SOTSBuffItems.LoadTasks();
            if (ModConditions.shadowsOfAbaddonLoaded)
                ShadowsOfAbaddonBuffItems.LoadTasks();
            if (ModConditions.spiritClassicLoaded)
                SpiritClassicBuffItems.LoadTasks();
            if (ModConditions.spiritReforgedLoaded)
                SpiritReforgedBuffItems.LoadTasks();
            if (ModConditions.thoriumLoaded)
                ThoriumBuffItems.LoadTasks();
            if (ModConditions.vitalityLoaded)
                VitalityBuffItems.LoadTasks();

            //Load generic items from mods that aren't directly supported (NOT WORKING)
            //GenericBuffItems.LoadTasks();

            //Every buff from previously loaded buffs 
            EverythingBuffItem.LoadTasks();
        }
    }
}
