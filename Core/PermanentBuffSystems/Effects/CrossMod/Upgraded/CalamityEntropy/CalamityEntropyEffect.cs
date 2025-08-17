using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Arena.CalamityEntropy;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.CalamityEntropy;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.CalamityEntropy
{
    public class CalamityEntropyEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.calamityEntropyLoaded)
                return;

            new VoidCandleEffect().ApplyEffect(player);
            new YharimsStimulantsEffect().ApplyEffect(player);
            new SoyMilkEffect().ApplyEffect(player);
        }
    }
}
