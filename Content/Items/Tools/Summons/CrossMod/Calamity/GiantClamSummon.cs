using CalamityMod.NPCs.SunkenSea;

namespace QoLCompendium.Content.Items.Tools.Summons.CrossMod.Calamity
{
    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class GiantClamSummon : BaseSummon
    {
        public override int SortingPriority => 2;
        public override int NPCType => ModContent.NPCType<GiantClam>();
        public override int Rarity => ItemRarityID.Blue;

        public override bool CanUseItem(Player player)
        {
            if (ModConditions.calamityLoaded && ModConditions.calamityMod.TryFind("SunkenSeaBiome", out ModBiome SunkenSeaBiome) && SunkenSeaBiome != null && Main.LocalPlayer.InModBiome(SunkenSeaBiome))
                return ModConditions.DownedDesertScourge.IsMet() && !NPC.AnyNPCs(ModContent.NPCType<GiantClam>());
            return false;
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.BossSummons, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "SeaPrism"), 3);
            r.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "Navystone"), 5);
            r.Register();
        }
    }
}
