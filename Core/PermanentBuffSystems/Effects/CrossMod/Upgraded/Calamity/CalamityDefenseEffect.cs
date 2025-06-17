using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Calamity;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.Calamity
{
    public class CalamityDefenseEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.calamityLoaded)
                return;

            new BaguetteEffect().ApplyEffect(player);
            new BloodfinEffect().ApplyEffect(player);
            new PhotosynthesisEffect().ApplyEffect(player);
            new TeslaEffect().ApplyEffect(player);
        }
    }
}
