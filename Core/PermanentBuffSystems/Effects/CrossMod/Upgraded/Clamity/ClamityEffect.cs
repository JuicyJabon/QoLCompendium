using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Clamity;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.Clamity
{
    public class ClamityEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.clamityAddonLoaded)
                return;

            new ExoBaguetteEffect().ApplyEffect(player);
            new SupremeLuckEffect().ApplyEffect(player);
            new TitanScaleEffect().ApplyEffect(player);
        }
    }
}
