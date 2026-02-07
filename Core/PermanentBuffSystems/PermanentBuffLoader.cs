using QoLCompendium.Core.PermanentBuffSystems.Items;

namespace QoLCompendium.Core.PermanentBuffSystems
{
    public static class PermanentBuffLoader
    {
        public static void LoadTasks()
        {
            VanillaBuffItems.LoadTasks();
            if (CrossModSupport.Calamity.Loaded)
                CalamityBuffItems.LoadTasks();
            if (CrossModSupport.ClickerClass.Loaded)
                ClickerClassBuffItems.LoadTasks();
            if (CrossModSupport.Consolaria.Loaded)
                ConsolariaBuffItems.LoadTasks();
            if (CrossModSupport.HomewardJourney.Loaded)
                HomewardJourneyBuffItems.LoadTasks();
            if (CrossModSupport.MartinsOrder.Loaded)
                MartinsOrderBuffItems.LoadTasks();
            if (CrossModSupport.Redemption.Loaded)
                RedemptionBuffItems.LoadTasks();
            if (CrossModSupport.SecretsOfTheShadows.Loaded)
                SOTSBuffItems.LoadTasks();
            if (CrossModSupport.ShadowsOfAbaddon.Loaded)
                ShadowsOfAbaddonBuffItems.LoadTasks();
            if (CrossModSupport.SpiritClassic.Loaded)
                SpiritClassicBuffItems.LoadTasks();
            if (CrossModSupport.SpiritReforged.Loaded)
                SpiritReforgedBuffItems.LoadTasks();
            if (CrossModSupport.Thorium.Loaded)
                ThoriumBuffItems.LoadTasks();
            if (CrossModSupport.Vitality.Loaded)
                VitalityBuffItems.LoadTasks();

            //Load generic items from mods that aren't directly supported (NOT WORKING)
            //GenericBuffItems.LoadTasks();

            //Every buff from previously loaded buffs 
            EverythingBuffItem.LoadTasks();
        }
    }
}
