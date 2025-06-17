using QoLCompendium.Core.PermanentBuffSystems.Effects.Potions;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Upgraded
{
    public class DamageEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            new AmmoReservationEffect().ApplyEffect(player);
            new ArcheryEffect().ApplyEffect(player);
            new BattleEffect().ApplyEffect(player);
            new LuckyEffect().ApplyEffect(player);
            new MagicPowerEffect().ApplyEffect(player);
            new ManaRegenerationEffect().ApplyEffect(player);
            new SummoningEffect().ApplyEffect(player);
            new TipsyEffect().ApplyEffect(player);
            new TitanEffect().ApplyEffect(player);
            new RageEffect().ApplyEffect(player);
            new WrathEffect().ApplyEffect(player);
        }
    }
}
