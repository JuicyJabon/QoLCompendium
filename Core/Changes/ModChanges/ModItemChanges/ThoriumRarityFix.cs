using ThoriumMod;
using ThoriumMod.Items.Donate;

namespace QoLCompendium.Core.Changes.ModChanges.ModItemChanges
{
    [ExtendsFromMod(CrossModSupport.Thorium.Name)]
    [JITWhenModsEnabled(CrossModSupport.Thorium.Name)]
    public class ThoriumRarityFix : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return QoLCompendium.crossModConfig.ThoriumRarityFix;
        }

        public override void SetDefaults(Item entity)
        {
            if (entity.type == ModContent.ItemType<HeartOfTheJungle>() && !ThoriumConfigClient.Instance.ShowDonatorItemColor)
            {
                entity.rare = ItemRarityID.Cyan;
                entity.expert = true;
            }
        }
    }
}
