namespace QoLCompendium.Content.Items.Tools.Summons.Vanilla
{
    public class GolemSummon : BaseSummon
    {
        public override int SortingPriority => 15;
        public override int NPCType => NPCID.Golem;
        public override int Rarity => ItemRarityID.Yellow;

        public override bool CanUseItem(Player player)
        {
            return Main.hardMode && NPC.downedPlantBoss && !NPC.AnyNPCs(NPCID.Golem);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.BossSummons, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.LihzahrdPowerCell);
            r.AddIngredient(ItemID.ChlorophyteBar, 3);
            r.AddIngredient(ItemID.Moonglow, 5);
            r.AddTile(TileID.MythrilAnvil);
            r.Register();
        }
    }
}
