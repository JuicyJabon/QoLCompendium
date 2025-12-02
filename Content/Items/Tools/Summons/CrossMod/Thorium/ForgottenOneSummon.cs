using ThoriumMod.NPCs.BossForgottenOne;

namespace QoLCompendium.Content.Items.Tools.Summons.CrossMod.Thorium
{
    [JITWhenModsEnabled(ModConditions.thoriumName)]
    [ExtendsFromMod(ModConditions.thoriumName)]
    public class ForgottenOneSummon : BaseSummon
    {
        public override int SortingPriority => 13;
        public override int NPCType => ModContent.NPCType<ForgottenOne>();
        public override int Rarity => ItemRarityID.Pink;

        public override bool CanUseItem(Player player)
        {
            return ModConditions.thoriumLoaded && NPC.downedPlantBoss && player.ZoneBeach && !NPC.AnyNPCs(ModContent.NPCType<ForgottenOne>());
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.BossSummons, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(ModConditions.thoriumMod, "MarineBlock"), 12);
            r.AddIngredient(Common.GetModItem(ModConditions.thoriumMod, "MossyMarineBlock"), 12);
            r.AddIngredient(ItemID.Ectoplasm, 5);
            r.AddTile(TileID.MythrilAnvil);
            r.Register();
        }
    }
}
