using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.SpiritClassic;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.SpiritClassic
{
    public class SpiritClassicDamageEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.spiritLoaded)
                return;

            new RunescribeEffect().ApplyEffect(player);
            new SoulguardEffect().ApplyEffect(player);
            new SpiritEffect().ApplyEffect(player);
            new StarburnEffect().ApplyEffect(player);
            new ToxinEffect().ApplyEffect(player);
        }
    }
}
