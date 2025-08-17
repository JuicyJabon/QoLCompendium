using QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Stations;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Upgraded
{
    public class StationEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            new AmmoBoxEffect().ApplyEffect(player);
            new BewitchingTableEffect().ApplyEffect(player);
            new CrystalBallEffect().ApplyEffect(player);
            new SharpeningStationEffect().ApplyEffect(player);
            new SliceOfCakeEffect().ApplyEffect(player);
            new WarTableEffect().ApplyEffect(player);
        }
    }
}
