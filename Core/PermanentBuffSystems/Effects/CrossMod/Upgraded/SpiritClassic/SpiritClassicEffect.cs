namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.SpiritClassic
{
    public class SpiritClassicEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.spiritClassicLoaded)
                return;

            new SpiritClassicArenaEffect().ApplyEffect(player);
            new SpiritClassicCandyEffect().ApplyEffect(player);
            new SpiritClassicDamageEffect().ApplyEffect(player);
            new SpiritClassicDefenseEffect().ApplyEffect(player);
            new SpiritClassicMovementEffect().ApplyEffect(player);
        }
    }
}
