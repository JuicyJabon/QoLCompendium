using static Terraria.ModLoader.NPCShop;

namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class RemovePlanterBoxConditions : GlobalNPC
    {
        public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
        {
            return entity.type == NPCID.Dryad;
        }

        public override void ModifyShop(NPCShop shop)
        {
            foreach (Entry entry in shop.Entries)
            {
                if (entry.Conditions is List<Condition> conditions)
                {
                    if (conditions.Count == 0)
                        continue;

                    if (entry.Item.type == ItemID.DayBloomPlanterBox)
                    {
                        conditions.Remove(Condition.DownedKingSlime);
                    }
                    if (entry.Item.type == ItemID.BlinkrootPlanterBox)
                    {
                        conditions.Remove(Condition.DownedEyeOfCthulhu);
                    }
                    if (entry.Item.type == ItemID.CorruptPlanterBox || entry.Item.type == ItemID.CrimsonPlanterBox)
                    {
                        conditions.Remove(Condition.DownedEowOrBoc);
                    }
                    if (entry.Item.type == ItemID.MoonglowPlanterBox)
                    {
                        conditions.Remove(Condition.DownedQueenBee);
                    }
                    if (entry.Item.type == ItemID.ShiverthornPlanterBox)
                    {
                        conditions.Remove(Condition.DownedSkeletron);
                    }
                    if (entry.Item.type == ItemID.WaterleafPlanterBox)
                    {
                        conditions.Remove(Condition.DownedSkeletron);
                    }
                    if (entry.Item.type == ItemID.FireBlossomPlanterBox)
                    {
                        conditions.Remove(Condition.Hardmode);
                    }
                }
            }
        }
    }
}
