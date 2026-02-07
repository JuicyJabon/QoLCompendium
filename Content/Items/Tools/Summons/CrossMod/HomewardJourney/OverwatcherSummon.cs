namespace QoLCompendium.Content.Items.Tools.Summons.CrossMod.HomewardJourney
{
    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class OverwatcherSummon : BaseSummon
    {
        public override int SortingPriority => 20;
        public override int NPCType => Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "TheOverwatcher");
        public override int Rarity => ItemRarityID.Red;

        public override bool CanUseItem(Player player)
        {
            return CrossModSupport.HomewardJourney.Loaded && ModConditions.DownedWallOfShadow.IsMet() && !NPC.AnyNPCs(Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "TheOverwatcher"));
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.BossSummons, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "EternalBar"), 5);
            r.AddIngredient(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "EssenceofTime"), 3);
            r.AddTile(Common.GetModTile(CrossModSupport.HomewardJourney.Mod, "FinalAnvil"));
            r.Register();
        }
    }
}
