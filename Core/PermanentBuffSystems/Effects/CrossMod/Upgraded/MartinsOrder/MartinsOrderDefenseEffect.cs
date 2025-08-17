using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.MartinsOrder;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.MartinsOrder
{
    public class MartinsOrderDefenseEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.martainsOrderLoaded)
                return;

            new BlackHoleEffect().ApplyEffect(player);
            new BodyEffect().ApplyEffect(player);
            new ChargingEffect().ApplyEffect(player);
            new GourmetFlavorEffect().ApplyEffect(player);
            new HealingEffect().ApplyEffect(player);
            new RockskinEffect().ApplyEffect(player);
            new ShieldingEffect().ApplyEffect(player);
            new SoulEffect().ApplyEffect(player);
            new ZincPillEffect().ApplyEffect(player);
        }
    }
}
