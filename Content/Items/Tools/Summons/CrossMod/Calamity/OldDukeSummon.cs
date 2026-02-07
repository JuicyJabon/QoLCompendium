using CalamityMod.NPCs.OldDuke;
using CalamityMod.Rarities;

namespace QoLCompendium.Content.Items.Tools.Summons.CrossMod.Calamity
{
    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public class OldDukeSummon : BaseSummon
    {
        public override int SortingPriority => 18;
        public override int NPCType => ModContent.NPCType<OldDuke>();
        public override int Rarity => ModContent.RarityType<PureGreen>();

        public override bool CanUseItem(Player player)
        {
            return CrossModSupport.Calamity.Loaded && ModConditions.DownedPolterghast.IsMet() && player.ZoneBeach && !NPC.AnyNPCs(ModContent.NPCType<OldDuke>());
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.BossSummons, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(CrossModSupport.Calamity.Mod, "BloodwormItem"));
            r.AddIngredient(ItemID.Bowl);
            r.AddTile(TileID.LunarCraftingStation);
            r.Register();
        }
    }
}
