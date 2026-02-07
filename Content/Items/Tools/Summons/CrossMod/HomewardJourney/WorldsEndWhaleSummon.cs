namespace QoLCompendium.Content.Items.Tools.Summons.CrossMod.HomewardJourney
{
    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class WorldsEndWhaleSummon : BaseSummon
    {
        public override int SortingPriority => 21;
        public override int NPCType => Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "WorldsEndEverlastingFallingWhale");
        public override int Rarity => ItemRarityID.Red;

        public override bool CanUseItem(Player player)
        {
            return CrossModSupport.HomewardJourney.Loaded && ModConditions.DownedLifebringer.IsMet() && ModConditions.DownedMaterealizer.IsMet() && ModConditions.DownedOverwatcher.IsMet() && !NPC.AnyNPCs(Common.GetModNPC(CrossModSupport.HomewardJourney.Mod, "WorldsEndEverlastingFallingWhale"));
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.BossSummons, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "FinalBar"), 5);
            r.AddIngredient(Common.GetModItem(CrossModSupport.HomewardJourney.Mod, "WillToCrown"), 3);
            r.AddTile(Common.GetModTile(CrossModSupport.HomewardJourney.Mod, "FinalAnvil"));
            r.Register();
        }
    }
}
