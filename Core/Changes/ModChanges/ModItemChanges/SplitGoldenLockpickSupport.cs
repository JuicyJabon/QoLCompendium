using QoLCompendium.Content.Items.Tools.Usables;
using Split.Content.Photography.Envelopes;

namespace QoLCompendium.Core.Changes.ModChanges.ModItemChanges
{
    [JITWhenModsEnabled(CrossModSupport.Split.Name)]
    [ExtendsFromMod(CrossModSupport.Split.Name)]
    public class SplitGoldenLockpickSupport : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.type == ModContent.ItemType<DungeonEnvelope>();
        }

        public override bool CanRightClick(Item item)
        {
            return Main.LocalPlayer.FindItem(ItemID.GoldenKey) != -1 || Main.LocalPlayer.FindItem(ModContent.ItemType<GoldenLockpick>()) != -1;
        }
    }
}
