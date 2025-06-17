using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.SpiritClassic;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.SpiritClassic
{
    public class SpiritClassicDefenseEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.spiritLoaded)
                return;

            new MirrorCoatEffect().ApplyEffect(player);
            //new MoonJellyEffect().ApplyEffect(player);
            new SporecoidEffect().ApplyEffect(player);
            new SteadfastEffect().ApplyEffect(player);
        }
    }
}
