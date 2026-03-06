using Terraria.GameContent.ItemDropRules;

namespace QoLCompendium.Core.Changes.ModChanges.ModItemChanges
{
    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public class CalamityNewCrateDrops : GlobalItem
    {
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            if (!QoLCompendium.mainConfig.MoreCrateDrops)
                return;

            #region Astral Infection Crates
            if (item.type == Common.GetModItem(CrossModSupport.Calamity.Mod, "MonolithCrate") || item.type == Common.GetModItem(CrossModSupport.Calamity.Mod, "AstralCrate"))
            {
                
            }

            if (item.type == Common.GetModItem(CrossModSupport.Calamity.Mod, "AstralCrate"))
            {
                if (CrossModSupport.Catalyst.Loaded)
                {
                    LeadingConditionRule Astrageldon = itemLoot.DefineConditionalDropSet(ModConditions.DownedAstrageldon.IsMet);
                    
                    Astrageldon.Add(Common.GetModItem(CrossModSupport.Catalyst.Mod, "MetanovaOre"), 5, 10, 20);
                    Astrageldon.Add(Common.GetModItem(CrossModSupport.Catalyst.Mod, "MetanovaBar"), 10, 1, 3);
                    Astrageldon.Add(Common.GetModItem(CrossModSupport.Catalyst.Mod, "AstraJelly"), 10, 1, 5);
                }
            }
            #endregion

            #region Brimstone Crags Crates
            if (item.type == Common.GetModItem(CrossModSupport.Calamity.Mod, "SlagCrate") || item.type == Common.GetModItem(CrossModSupport.Calamity.Mod, "BrimstoneCrate"))
            {
                
            }

            if (item.type == Common.GetModItem(CrossModSupport.Calamity.Mod, "BrimstoneCrate"))
            {
                
            }
            #endregion

            #region Sulphur Sea Crates
            if (item.type == Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphurousCrate") || item.type == Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"))
            {

            }

            if (item.type == Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"))
            {
                if (CrossModSupport.CalamityEntropy.Loaded)
                {
                    LeadingConditionRule Wyrm = itemLoot.DefineConditionalDropSet(ModConditions.DownedPrimordialWyrm.IsMet);
                    Wyrm.Add(Common.GetModItem(CrossModSupport.CalamityEntropy.Mod, "WyrmTooth"), 10, 1, 5);
                }
            }
            #endregion

            #region Sunken Sea Crates
            if (item.type == Common.GetModItem(CrossModSupport.Calamity.Mod, "EutrophicCrate") || item.type == Common.GetModItem(CrossModSupport.Calamity.Mod, "PrismCrate"))
            {
                
            }

            if (item.type == Common.GetModItem(CrossModSupport.Calamity.Mod, "PrismCrate"))
            {
                
            }
            #endregion

            #region Wooden Crates
            if (item.type == ItemID.WoodenCrate || item.type == ItemID.WoodenCrateHard)
            {
                
            }

            if (item.type == ItemID.WoodenCrateHard)
            {
                
            }
            #endregion

            #region Iron Crates
            if (item.type == ItemID.IronCrate || item.type == ItemID.IronCrateHard)
            {
                
            }

            if (item.type == ItemID.IronCrateHard)
            {
                
            }
            #endregion

            #region Golden Crates
            if (item.type == ItemID.GoldenCrate || item.type == ItemID.GoldenCrateHard)
            {

            }

            if (item.type == ItemID.GoldenCrateHard)
            {
                if (CrossModSupport.CalamityEntropy.Loaded)
                {
                    LeadingConditionRule Cruiser = itemLoot.DefineConditionalDropSet(ModConditions.DownedCruiser.IsMet);

                    Cruiser.Add(Common.GetModItem(CrossModSupport.CalamityEntropy.Mod, "VoidOre"), 5, 10, 20);
                    Cruiser.Add(Common.GetModItem(CrossModSupport.CalamityEntropy.Mod, "VoidBar"), 10, 1, 3);
                    Cruiser.Add(Common.GetModItem(CrossModSupport.CalamityEntropy.Mod, "VoidScales"), 10, 1, 5);
                }
            }
            #endregion

            #region Sky Crates
            if (item.type == ItemID.FloatingIslandFishingCrate || item.type == ItemID.FloatingIslandFishingCrateHard)
            {

            }

            if (item.type == ItemID.FloatingIslandFishingCrateHard)
            {

            }
            #endregion

            #region Dungeon Crates
            if (item.type == ItemID.DungeonFishingCrate || item.type == ItemID.DungeonFishingCrateHard)
            {

            }

            if (item.type == ItemID.DungeonFishingCrateHard)
            {

            }
            #endregion

            #region Evil Crates
            if (item.type == ItemID.CorruptFishingCrate || item.type == ItemID.CorruptFishingCrateHard || item.type == ItemID.CrimsonFishingCrate || item.type == ItemID.CrimsonFishingCrateHard)
            {

            }
            #endregion

            #region Ice Crates
            if (item.type == ItemID.FrozenCrate || item.type == ItemID.FrozenCrateHard)
            {

            }

            if (item.type == ItemID.FrozenCrateHard)
            {
                
            }
            #endregion

            #region Hallowed Crates
            if (item.type == ItemID.HallowedFishingCrate || item.type == ItemID.HallowedFishingCrateHard)
            {

            }

            if (item.type == ItemID.HallowedFishingCrateHard)
            {
                
            }
            #endregion

            #region Jungle Crates
            if (item.type == ItemID.JungleFishingCrate || item.type == ItemID.JungleFishingCrateHard)
            {

            }

            if (item.type == ItemID.JungleFishingCrateHard)
            {
                
            }
            #endregion
        }
    }
}
