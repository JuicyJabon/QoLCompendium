using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Arena.Calamity;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Calamity;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.Calamity
{
    public class CalamityFarmingEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.calamityLoaded)
                return;

            new ZenEffect().ApplyEffect(player);
            new TranquilityCandleEffect().ApplyEffect(player);
            new ZergEffect().ApplyEffect(player);
            new ChaosCandleEffect().ApplyEffect(player);
            new CeaselessHungerEffect().ApplyEffect(player);
        }
    }
}
