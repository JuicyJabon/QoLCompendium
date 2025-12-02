using Terraria.DataStructures;
using Terraria.Utilities;

namespace QoLCompendium.Core.Changes.ItemChanges.ReforgeSystems
{
    public class ReforgeReworkItem : GlobalItem
    {
        public static int storedPrefix = -1;

        public override void OnCreated(Item item, ItemCreationContext context)
        {
            // ChoosePrefix also happens on craft so go reset it here too
            storedPrefix = -1;
        }

        public override void PreReforge(Item item)
        {
            storedPrefix = item.prefix;
        }

        public override void PostReforge(Item item)
        {
            storedPrefix = -1;
        }

        public override int ChoosePrefix(Item item, UnifiedRandom rand)
        {
            if (!QoLCompendium.mainConfig.ReworkReforging || Main.gameMenu || storedPrefix == -1)
                return -1;

            // Pick a prefix using the new system.
            return ReforgeRework.GetReworkedReforge(item, rand, storedPrefix);
        }
    }
}