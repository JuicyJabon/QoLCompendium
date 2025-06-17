namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.Thorium
{
    public class ThoriumEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.thoriumLoaded)
                return;

            new ThoriumBardEffect().ApplyEffect(player);
            new ThoriumDamageEffect().ApplyEffect(player);
            new ThoriumHealerEffect().ApplyEffect(player);
            new ThoriumMovementEffect().ApplyEffect(player);
            new ThoriumRepellentEffect().ApplyEffect(player);
            new ThoriumStationsEffect().ApplyEffect(player);
            new ThoriumThrowerEffect().ApplyEffect(player);
        }
    }
}
