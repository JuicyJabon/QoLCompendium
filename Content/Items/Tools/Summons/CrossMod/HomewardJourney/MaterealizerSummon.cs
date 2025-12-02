namespace QoLCompendium.Content.Items.Tools.Summons.CrossMod.HomewardJourney
{
    [JITWhenModsEnabled(ModConditions.homewardJourneyName)]
    [ExtendsFromMod(ModConditions.homewardJourneyName)]
    public class MaterealizerSummon : BaseSummon
    {
        public override int SortingPriority => 20;
        public override int NPCType => Common.GetModNPC(ModConditions.homewardJourneyMod, "TheMaterealizer");
        public override int Rarity => ItemRarityID.Red;

        public override bool CanUseItem(Player player)
        {
            return ModConditions.homewardJourneyLoaded && ModConditions.DownedWallOfShadow.IsMet() && !NPC.AnyNPCs(Common.GetModNPC(ModConditions.homewardJourneyMod, "TheMaterealizer"));
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.BossSummons, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(ModConditions.homewardJourneyMod, "CubistBar"), 5);
            r.AddIngredient(Common.GetModItem(ModConditions.homewardJourneyMod, "EssenceofMatter"), 3);
            r.AddTile(Common.GetModTile(ModConditions.homewardJourneyMod, "FinalAnvil"));
            r.Register();
        }
    }
}
