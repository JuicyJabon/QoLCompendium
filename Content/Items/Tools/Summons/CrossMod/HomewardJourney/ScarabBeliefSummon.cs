namespace QoLCompendium.Content.Items.Tools.Summons.CrossMod.HomewardJourney
{
    [JITWhenModsEnabled(ModConditions.homewardJourneyName)]
    [ExtendsFromMod(ModConditions.homewardJourneyName)]
    public class ScarabBeliefSummon : BaseSummon
    {
        public override int SortingPriority => 21;
        public override int NPCType => Common.GetModNPC(ModConditions.homewardJourneyMod, "ScarabBelief");
        public override int Rarity => ItemRarityID.Red;

        public override bool CanUseItem(Player player)
        {
            return ModConditions.homewardJourneyLoaded && ModConditions.DownedLifebringer.IsMet() && ModConditions.DownedMaterealizer.IsMet() && ModConditions.DownedOverwatcher.IsMet() && !NPC.AnyNPCs(Common.GetModNPC(ModConditions.homewardJourneyMod, "ScarabBelief"));
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.BossSummons, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(ModConditions.homewardJourneyMod, "FinalBar"), 5);
            r.AddIngredient(Common.GetModItem(ModConditions.homewardJourneyMod, "WillToCrown"), 3);
            r.AddTile(Common.GetModTile(ModConditions.homewardJourneyMod, "FinalAnvil"));
            r.Register();
        }
    }
}
