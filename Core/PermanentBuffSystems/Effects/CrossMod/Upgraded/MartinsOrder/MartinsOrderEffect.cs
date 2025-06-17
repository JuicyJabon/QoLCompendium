namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.MartinsOrder
{
    public class MartinsOrderEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.martainsOrderLoaded)
                return;

            new MartinsOrderDamageEffect().ApplyEffect(player);
            new MartinsOrderDefenseEffect().ApplyEffect(player);
            new MartinsOrderStationsEffect().ApplyEffect(player);
        }
    }
}
