namespace QoLCompendium.Content.Items.Tools.Summons.Vanilla
{
    public class EmpressOfLightSummon : BaseSummon
    {
        public override int SortingPriority => 15;
        public override int NPCType => NPCID.HallowBoss;
        public override int Rarity => ItemRarityID.Yellow;

        public override bool CanUseItem(Player player)
        {
            return Main.hardMode && NPC.downedPlantBoss && !NPC.AnyNPCs(NPCID.HallowBoss);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.BossSummons, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.CrystalShard, 5);
            r.AddIngredient(ItemID.Ectoplasm, 3);
            r.AddTile(TileID.MythrilAnvil);
            r.Register();
        }
    }
}
