namespace QoLCompendium.Content.Items.Tools.Summons.Vanilla
{
    public class PlanteraSummon : BaseSummon
    {
        public override int SortingPriority => 13;
        public override int NPCType => NPCID.Plantera;
        public override int Rarity => ItemRarityID.LightPurple;

        public override bool CanUseItem(Player player)
        {
            return Main.hardMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && !NPC.AnyNPCs(NPCID.Plantera);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.BossSummons, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.MudBlock, 10);
            r.AddIngredient(ItemID.Moonglow, 3);
            r.AddIngredient(ItemID.ChlorophyteOre, 5);
            r.AddTile(TileID.MythrilAnvil);
            r.Register();
        }
    }
}
