using CalamityMod.NPCs.Leviathan;

namespace QoLCompendium.Content.Items.Tools.Summons.CrossMod.Calamity
{
    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class LeviathanAnahitaSummon : BaseSummon
    {
        public override int SortingPriority => 14;
        public override int NPCType => ModContent.NPCType<Anahita>();
        public override int Rarity => ItemRarityID.Pink;

        public override bool CanUseItem(Player player)
        {
            return ModConditions.calamityLoaded && NPC.downedPlantBoss && player.ZoneBeach && !NPC.AnyNPCs(Common.GetModNPC(ModConditions.calamityMod, "Anahita"));
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.BossSummons, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.WhitePearl, 3);
            r.AddIngredient(ItemID.Ectoplasm, 5);
            r.AddTile(TileID.MythrilAnvil);
            r.Register();
        }
    }
}
