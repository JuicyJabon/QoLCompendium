namespace QoLCompendium.Content.Items.Tools.Summons.Vanilla
{
    public class CultistSummon : BaseSummon
    {
        public override int SortingPriority => 16;
        public override int NPCType => NPCID.CultistBoss;
        public override int Rarity => ItemRarityID.Red;

        public override bool CanUseItem(Player player)
        {
            return Main.hardMode && NPC.downedGolemBoss && !NPC.AnyNPCs(NPCID.CultistBoss);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.BossSummons, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.LihzahrdBrick, 5);
            r.AddIngredient(ItemID.Ectoplasm, 5);
            r.AddTile(TileID.MythrilAnvil);
            r.Register();
        }
    }
}
