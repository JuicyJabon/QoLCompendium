using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.MartinsOrder;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.MartinsOrder
{
    public class MartinsOrderDamageEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.martainsOrderLoaded)
                return;

            new DefenderEffect().ApplyEffect(player);
            new EmpowermentEffect().ApplyEffect(player);
            new EvocationEffect().ApplyEffect(player);
            new HasteEffect().ApplyEffect(player);
            new ShooterEffect().ApplyEffect(player);
            new SpellCasterEffect().ApplyEffect(player);
            new StarreachEffect().ApplyEffect(player);
            new SweeperEffect().ApplyEffect(player);
            new ThrowerEffect().ApplyEffect(player);
            new WhipperEffect().ApplyEffect(player);
        }
    }
}
