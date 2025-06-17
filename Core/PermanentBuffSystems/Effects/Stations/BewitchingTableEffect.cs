using QoLCompendium.Core.PermanentBuffSystems;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Stations
{
    public class BewitchingTableEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Bewitched] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.BewitchingTable])
            {
                player.Player.maxMinions += 1;
                player.Player.buffImmune[BuffID.Bewitched] = true;
            }
        }
    }
}
