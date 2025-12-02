namespace QoLCompendium.Content.Items.Tools.Summons.CrossMod.HomewardJourney
{
    [JITWhenModsEnabled(ModConditions.homewardJourneyName)]
    [ExtendsFromMod(ModConditions.homewardJourneyName)]
    public class LifebringerSummon : BaseSummon
    {
        public override int SortingPriority => 20;
        public override int NPCType => Common.GetModNPC(ModConditions.homewardJourneyMod, "TheLifebringerHead");
        public override int Rarity => ItemRarityID.Red;

        public override bool CanUseItem(Player player)
        {
            return ModConditions.homewardJourneyLoaded && ModConditions.DownedWallOfShadow.IsMet() && !NPC.AnyNPCs(Common.GetModNPC(ModConditions.homewardJourneyMod, "TheLifebringerHead"));
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.BossSummons, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(ModConditions.homewardJourneyMod, "LivingBar"), 5);
            r.AddIngredient(Common.GetModItem(ModConditions.homewardJourneyMod, "EssenceofLife"), 3);
            r.AddTile(Common.GetModTile(ModConditions.homewardJourneyMod, "FinalAnvil"));
            r.Register();
        }
    }
}
