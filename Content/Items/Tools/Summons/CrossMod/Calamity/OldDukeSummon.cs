using CalamityMod.NPCs.OldDuke;
using CalamityMod.Rarities;

namespace QoLCompendium.Content.Items.Tools.Summons.CrossMod.Calamity
{
    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class OldDukeSummon : BaseSummon
    {
        public override int SortingPriority => 18;
        public override int NPCType => ModContent.NPCType<OldDuke>();
        public override int Rarity => ModContent.RarityType<PureGreen>();

        public override bool CanUseItem(Player player)
        {
            return ModConditions.calamityLoaded && ModConditions.DownedPolterghast.IsMet() && player.ZoneBeach && !NPC.AnyNPCs(ModContent.NPCType<OldDuke>());
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.BossSummons, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "BloodwormItem"));
            r.AddIngredient(ItemID.Bowl);
            r.AddTile(TileID.LunarCraftingStation);
            r.Register();
        }
    }
}
