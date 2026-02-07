using CalamityMod.NPCs.Abyss;
using CalamityMod.Rarities;

namespace QoLCompendium.Content.Items.Tools.Summons.CrossMod.Calamity
{
    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public class GiantSquidSummon : BaseSummon
    {
        public override int SortingPriority => 18;
        public override int NPCType => ModContent.NPCType<GiantSquid>();
        public override int Rarity => ModContent.RarityType<PureGreen>();

        public override bool CanUseItem(Player player)
        {
            if (CrossModSupport.Calamity.Loaded && CrossModSupport.Calamity.Mod.TryFind("AbyssLayer4Biome", out ModBiome AbyssLayer4Biome) && AbyssLayer4Biome != null && Main.LocalPlayer.InModBiome(AbyssLayer4Biome))
                return !NPC.AnyNPCs(ModContent.NPCType<GiantSquid>());
            return false;
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.BossSummons, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(CrossModSupport.Calamity.Mod, "Lumenyl"), 3);
            r.AddIngredient(Common.GetModItem(CrossModSupport.Calamity.Mod, "RuinousSoul"), 2);
            r.AddIngredient(Common.GetModItem(CrossModSupport.Calamity.Mod, "Voidstone"), 5);
            r.AddTile(TileID.DemonAltar);
            r.Register();
        }
    }
}
