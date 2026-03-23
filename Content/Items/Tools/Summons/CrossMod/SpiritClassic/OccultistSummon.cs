using SpiritMod.Items.Material;
using SpiritMod.Items.Sets.BloodcourtSet;

namespace QoLCompendium.Content.Items.Tools.Summons.CrossMod.SpiritClassic
{
    [JITWhenModsEnabled(CrossModSupport.SpiritClassic.Name)]
    [ExtendsFromMod(CrossModSupport.SpiritClassic.Name)]
    public class OccultistSummon : BaseSummon
    {
        public override int SortingPriority => 1;
        public override int NPCType => Common.GetModNPC(CrossModSupport.SpiritClassic.Mod, "OccultistBoss");
        public override int Rarity => ItemRarityID.Green;

        public override bool CanUseItem(Player player)
        {
            return !Main.IsItDay() && Main.bloodMoon && !NPC.AnyNPCs(Common.GetModNPC(CrossModSupport.SpiritClassic.Mod, "OccultistBoss"));
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.BossSummons, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<DreamstrideEssence>(), 3);
            r.AddIngredient(ModContent.ItemType<OldLeather>(), 2);
            r.AddTile(TileID.DemonAltar);
            r.Register();
        }
    }
}
