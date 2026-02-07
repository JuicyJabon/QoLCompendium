using ContinentOfJourney.Items.Armor;

namespace QoLCompendium.Core.Changes.ModChanges.ModItemChanges
{
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    public class HomewardJourneyRarityFix : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.type == ModContent.ItemType<FlinxFurHat>() && QoLCompendium.crossModConfig.HomewardJourneyRarityFix;
        }

        public override void SetDefaults(Item entity)
        {
            entity.rare = ItemRarityID.Green;
        }
    }
}
