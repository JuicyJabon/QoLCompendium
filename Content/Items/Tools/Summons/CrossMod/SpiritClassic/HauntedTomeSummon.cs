using SpiritMod.Items.Material;
using SpiritMod.Items.Sets.BismiteSet;
using SpiritMod.NPCs.HauntedTome;

namespace QoLCompendium.Content.Items.Tools.Summons.CrossMod.SpiritClassic
{
    [JITWhenModsEnabled(CrossModSupport.SpiritClassic.Name)]
    [ExtendsFromMod(CrossModSupport.SpiritClassic.Name)]
    public class HauntedTomeSummon : BaseSummon
    {
        public override int SortingPriority => 0;
        public override int NPCType => ModContent.NPCType<HauntedTome>();
        public override int Rarity => ItemRarityID.Blue;

        public override bool CanUseItem(Player player)
        {
            return !Main.IsItDay() && !NPC.AnyNPCs(ModContent.NPCType<HauntedTome>());
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.BossSummons, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<BismiteCrystal>(), 5);
            r.AddIngredient(ModContent.ItemType<OldLeather>(), 2);
            r.AddIngredient(ItemID.Book);
            r.AddTile(TileID.DemonAltar);
            r.Register();
        }
    }
}
