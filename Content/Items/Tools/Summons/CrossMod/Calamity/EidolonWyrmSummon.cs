using CalamityMod.NPCs.Abyss;

namespace QoLCompendium.Content.Items.Tools.Summons.CrossMod.Calamity
{
    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class EidolonWyrmSummon : BaseSummon
    {
        public override int SortingPriority => 16;
        public override int NPCType => ModContent.NPCType<EidolonWyrmHead>();
        public override int Rarity => ItemRarityID.Yellow;

        public override bool CanUseItem(Player player)
        {
            if (ModConditions.calamityLoaded && ModConditions.calamityMod.TryFind("AbyssLayer4Biome", out ModBiome AbyssLayer4Biome) && AbyssLayer4Biome != null && Main.LocalPlayer.InModBiome(AbyssLayer4Biome))
                return !NPC.AnyNPCs(ModContent.NPCType<EidolonWyrmHead>());
            return false;
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.BossSummons, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "Lumenyl"), 3);
            r.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "Voidstone"), 5);
            r.AddTile(TileID.DemonAltar);
            r.Register();
        }
    }
}
