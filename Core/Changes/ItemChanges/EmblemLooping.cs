namespace QoLCompendium.Core.Changes.ItemChanges
{
    public class EmblemLooping : GlobalItem
    {
        /*
         * ItemID.WarriorEmblem,
         * ItemID.RangerEmblem,
         * ItemID.SorcererEmblem,
         * ItemID.SummonerEmblem,
         * Common.GetModItem(CrossModSupport.Calamity.Mod, "RogueEmblem"),
         * Common.GetModItem(CrossModSupport.ClickerClass.Mod, "ClickerEmblem"),
         * Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "ThrowerEmblem"),
         * Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "NeutralEmblem"),
         * Common.GetModItem(CrossModSupport.Orchid.Mod, "GuardianEmblem"),
         * Common.GetModItem(CrossModSupport.Orchid.Mod, "ShamanEmblem"),
         * Common.GetModItem(CrossModSupport.ShadowsOfAbaddon.Mod, "NinjaEmblem"),
         * Common.GetModItem(CrossModSupport.Thorium.Mod, "BardEmblem"),
         * Common.GetModItem(CrossModSupport.Thorium.Mod, "ClericEmblem"),
         * Common.GetModItem(CrossModSupport.Thorium.Mod, "NinjaEmblem"),
        */

        public override void AddRecipes()
        {
            if (!QoLCompendium.mainConfig.EmblemLooping)
                return;
            Common.CreateLoopingRecipe(Common.Emblems.ToArray(), TileID.DemonAltar);
        }
    }
}
