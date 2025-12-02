namespace QoLCompendium.Content.Items.Tools.Summons.Vanilla
{
    public class DukeFishronSummon : BaseSummon
    {
        public override int SortingPriority => 15;
        public override int NPCType => NPCID.DukeFishron;
        public override int Rarity => ItemRarityID.Yellow;

        public override bool CanUseItem(Player player)
        {
            return Main.hardMode && !NPC.AnyNPCs(NPCID.DukeFishron);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.BossSummons, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.TruffleWorm);
            r.AddIngredient(ItemID.Bowl);
            r.AddTile(TileID.DemonAltar);
            r.Register();
        }
    }
}
