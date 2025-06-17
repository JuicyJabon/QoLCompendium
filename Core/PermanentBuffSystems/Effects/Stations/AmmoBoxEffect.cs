using QoLCompendium.Core.PermanentBuffSystems;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Stations
{
    public class AmmoBoxEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.AmmoBox] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.AmmoBox])
            {
                player.Player.ammoBox = true;
                player.Player.buffImmune[BuffID.AmmoBox] = true;
            }
        }
    }
}
