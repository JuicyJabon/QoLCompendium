namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class RemoveShopConditions : GlobalNPC
    {
        public static void RemoveBiomeRequirements(string shopName, AbstractNPCShop shop, NPC? npc)
        {
            if (!QoLCompendium.mainConfig.RemoveShopConditions)
                return;

            var toRemove = new Dictionary<AbstractNPCShop.Entry, List<Condition>>();

            // get biome conditions
            foreach (var entry in shop.ActiveEntries)
            {
                toRemove[entry] = [];
                foreach (var condition in entry.Conditions)
                {
                    // we actually don't know! but we can hack a bit.
                    Item obj = entry.Item;
                    if (!TileID.Sets.CountsAsPylon.Contains(obj.createTile))
                    {
                        if (Constants.BiomeConditions.Contains(condition))
                        {
                            toRemove[entry].Add(condition);
                        }
                    }
                }

                // actually remove the conditions!
                if (shop is TravellingMerchantShop ts)
                {
                    // get conditions list

                    // IMPORTANT: typeof(TravellingMerchantShop.Entry) is NOT the TravellingMerchantShop.Entry! It returns the AbstractNPCShop.Entry because *that one* is the public type. AND EVEN WORSE, IT WORKS IN THE DEBUGGER
                    // piss-poor API design with a hidden private type by tML, congrats
                    // never cook again
                    var entryType = ts.GetType().GetNestedType("Entry", System.Reflection.BindingFlags.NonPublic)!;
                    var conditionsField = entryType.GetField("<Conditions>k__BackingField", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!;
                    var conditionsList = (List<Condition>)conditionsField.GetValue(entry)!;
                    // remove the conditions
                    foreach (var condition in toRemove[entry])
                    {
                        conditionsList.Remove(condition);
                    }

                }
                else if (shop is NPCShop ns)
                {
                    // get conditions list
                    // private readonly List<Condition> conditions;
                    var conditionsList = (List<Condition>)typeof(NPCShop.Entry).GetField("conditions", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!.GetValue(entry as NPCShop.Entry)!;
                    // remove the conditions
                    foreach (var condition in toRemove[entry])
                    {
                        conditionsList.Remove(condition);
                    }

                }
                else
                {
                    throw new NotSupportedException(
                        $"Shop type {shop.GetType()} is not supported for removing biome requirements. WTF has happened?");
                }
            }
        }
    }
}
