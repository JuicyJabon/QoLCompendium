namespace QoLCompendium.Core.Changes.ItemChanges
{
    public class EmblemLooping : GlobalItem
    {
        /*
         * ItemID.WarriorEmblem,
         * ItemID.RangerEmblem,
         * ItemID.SorcererEmblem,
         * ItemID.SummonerEmblem,
         * Common.GetModItem(ModConditions.calamityMod, "RogueEmblem"),
         * Common.GetModItem(ModConditions.clickerClassMod, "ClickerEmblem"),
         * Common.GetModItem(ModConditions.martainsOrderMod, "ThrowerEmblem"),
         * Common.GetModItem(ModConditions.martainsOrderMod, "NeutralEmblem"),
         * Common.GetModItem(ModConditions.orchidMod, "GuardianEmblem"),
         * Common.GetModItem(ModConditions.orchidMod, "ShamanEmblem"),
         * Common.GetModItem(ModConditions.shadowsOfAbaddonMod, "NinjaEmblem"),
         * Common.GetModItem(ModConditions.thoriumMod, "BardEmblem"),
         * Common.GetModItem(ModConditions.thoriumMod, "ClericEmblem"),
         * Common.GetModItem(ModConditions.thoriumMod, "NinjaEmblem"),
        */

        public override void AddRecipes()
        {
            if (!QoLCompendium.mainConfig.EmblemLooping)
                return;
            Common.CreateLoopingRecipe(Common.Emblems.ToArray(), TileID.DemonAltar);
        }
    }
}
