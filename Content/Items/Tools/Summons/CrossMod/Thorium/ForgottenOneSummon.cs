using ThoriumMod.NPCs.BossForgottenOne;

namespace QoLCompendium.Content.Items.Tools.Summons.CrossMod.Thorium
{
    [JITWhenModsEnabled(CrossModSupport.Thorium.Name)]
    [ExtendsFromMod(CrossModSupport.Thorium.Name)]
    public class ForgottenOneSummon : BaseSummon
    {
        public override int SortingPriority => 13;
        public override int NPCType => ModContent.NPCType<ForgottenOne>();
        public override int Rarity => ItemRarityID.Pink;

        public override bool CanUseItem(Player player)
        {
            if (CrossModSupport.Thorium.Loaded && CrossModSupport.Thorium.Mod.TryFind("DepthsBiome", out ModBiome DepthsBiome) && DepthsBiome != null && Main.LocalPlayer.InModBiome(DepthsBiome))
                return NPC.downedPlantBoss && !NPC.AnyNPCs(ModContent.NPCType<ForgottenOne>());
            return false;
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.BossSummons, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(CrossModSupport.Thorium.Mod, "MarineBlock"), 6);
            r.AddIngredient(Common.GetModItem(CrossModSupport.Thorium.Mod, "MossyMarineBlock"), 6);
            r.AddIngredient(ItemID.Ectoplasm, 2);
            r.AddTile(TileID.MythrilAnvil);
            r.Register();
        }
    }
}
