using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Calamity;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.Calamity
{
    public class CalamityMovementEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.calamityLoaded)
                return;

            new BoundingEffect().ApplyEffect(player);
            new CalciumEffect().ApplyEffect(player);
            new GravityNormalizerEffect().ApplyEffect(player);
            new SoaringEffect().ApplyEffect(player);
        }
    }
}
