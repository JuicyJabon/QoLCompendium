using Terraria.GameContent.ItemDropRules;

namespace QoLCompendium.Core.Changes.ItemChanges
{
    public class NewCrateDrops : GlobalItem
    {
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            if (!QoLCompendium.mainConfig.MoreCrateDrops)
                return;

            #region Jungle Crates
            if (item.type == ItemID.JungleFishingCrate || item.type == ItemID.JungleFishingCrateHard)
            {

            }

            if (item.type == ItemID.JungleFishingCrateHard)
            {
                LeadingConditionRule Mechs = itemLoot.DefineConditionalDropSet(Condition.DownedMechBossAll.IsMet);
                Mechs.Add(ItemID.ChlorophyteOre, 5, 16, 28);
                Mechs.Add(ItemID.ChlorophyteBar, 10, 1, 3);
            }
            #endregion

            #region Dungeon Crates
            if (item.type == ItemID.DungeonFishingCrate || item.type == ItemID.DungeonFishingCrateHard)
            {

            }

            if (item.type == ItemID.DungeonFishingCrateHard)
            {
                itemLoot.AddIf(Condition.DownedPlantera.IsMet, ItemID.Ectoplasm, 10, 1, 5);
            }
            #endregion

            #region Hallowed Crates
            if (item.type == ItemID.HallowedFishingCrate || item.type == ItemID.HallowedFishingCrateHard)
            {

            }

            if (item.type == ItemID.HallowedFishingCrateHard)
            {
                LeadingConditionRule Mechs = itemLoot.DefineConditionalDropSet(Condition.DownedMechBossAll.IsMet);
                if (CrossModSupport.Calamity.Loaded)
                    Mechs.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "HallowedOre"), 5, 16, 28);
                Mechs.Add(ItemID.HallowedBar, 10, 1, 3);
            }
            #endregion
        }
    }
}
