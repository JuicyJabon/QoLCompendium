using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Thorium;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.Thorium
{
    public class ThoriumMovementEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.thoriumLoaded)
                return;

            new AquaAffinityEffect().ApplyEffect(player);
            new BloodRushEffect().ApplyEffect(player);
            new KineticEffect().ApplyEffect(player);
        }
    }
}
