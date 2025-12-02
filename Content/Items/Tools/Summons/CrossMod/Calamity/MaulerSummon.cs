using CalamityMod.NPCs.AcidRain;
using CalamityMod.Rarities;

namespace QoLCompendium.Content.Items.Tools.Summons.CrossMod.Calamity
{
    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class MaulerSummon : BaseSummon
    {
        public override int SortingPriority => 18;
        public override int NPCType => ModContent.NPCType<Mauler>();
        public override int Rarity => ModContent.RarityType<PureGreen>();

        public override bool CanUseItem(Player player)
        {
            if (ModConditions.calamityLoaded && ModConditions.calamityMod.TryFind("SulphurousSeaBiome", out ModBiome SulphurousSeaBiome) && SulphurousSeaBiome != null && Main.LocalPlayer.InModBiome(SulphurousSeaBiome))
                return ModConditions.DownedPolterghast.IsMet() && !NPC.AnyNPCs(ModContent.NPCType<Mauler>());
            return false;
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.BossSummons, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "CorrodedFossil"), 3);
            r.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "RuinousSoul"), 2);
            r.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "SulphurousSand"), 5);
            r.AddTile(TileID.DemonAltar);
            r.Register();
        }
    }
}
