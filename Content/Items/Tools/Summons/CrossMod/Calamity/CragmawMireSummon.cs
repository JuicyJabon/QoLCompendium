using CalamityMod.NPCs.AcidRain;

namespace QoLCompendium.Content.Items.Tools.Summons.CrossMod.Calamity
{
    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class CragmawMireSummon : BaseSummon
    {
        public override int SortingPriority => 8;
        public override int NPCType => ModContent.NPCType<CragmawMire>();
        public override int Rarity => ItemRarityID.Pink;

        public override bool CanUseItem(Player player)
        {
            if (ModConditions.calamityLoaded && ModConditions.calamityMod.TryFind("SulphurousSeaBiome", out ModBiome SulphurousSeaBiome) && SulphurousSeaBiome != null && Main.LocalPlayer.InModBiome(SulphurousSeaBiome))
                return ModConditions.DownedAquaticScourge.IsMet() && !NPC.AnyNPCs(ModContent.NPCType<CragmawMire>());
            return false;
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.BossSummons, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "CorrodedFossil"), 3);
            r.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "SulphurousSand"), 5);
            r.AddTile(TileID.DemonAltar);
            r.Register();
        }
    }
}
