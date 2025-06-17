using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.SpiritClassic.Candies;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.SpiritClassic
{
    public class SpiritClassicCandyEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.spiritLoaded)
                return;

            new CandyEffect().ApplyEffect(player);
            new ChocolateBarEffect().ApplyEffect(player);
            new HealthCandyEffect().ApplyEffect(player);
            new LollipopEffect().ApplyEffect(player);
            new ManaCandyEffect().ApplyEffect(player);
            new TaffyEffect().ApplyEffect(player);
        }
    }
}
