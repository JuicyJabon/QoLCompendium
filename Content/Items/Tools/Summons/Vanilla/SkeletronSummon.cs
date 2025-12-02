namespace QoLCompendium.Content.Items.Tools.Summons.Vanilla
{
    public class SkeletronSummon : BaseSummon
    {
        public override int SortingPriority => 5;
        public override int NPCType => NPCID.SkeletronHead;
        public override int Rarity => ItemRarityID.Orange;

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(NPCID.SkeletronHead);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.BossSummons, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.Silk, 5);
            r.AddIngredient(ItemID.RedHusk);
            r.AddTile(TileID.DemonAltar);
            r.Register();
        }
    }
}
