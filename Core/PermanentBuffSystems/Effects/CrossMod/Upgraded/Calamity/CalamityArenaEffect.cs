using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Arena.Calamity;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.Calamity
{
    public class CalamityArenaEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.calamityLoaded)
                return;

            new CorruptionEffigyEffect().ApplyEffect(player);
            new CrimsonEffigyEffect().ApplyEffect(player);
            new EffigyOfDecayEffect().ApplyEffect(player);
            new ResilientCandleEffect().ApplyEffect(player);
            new SpitefulCandleEffect().ApplyEffect(player);
            new VigorousCandleEffect().ApplyEffect(player);
            new WeightlessCandleEffect().ApplyEffect(player);
        }
    }
}
