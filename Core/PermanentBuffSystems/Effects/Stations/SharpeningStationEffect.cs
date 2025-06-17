using QoLCompendium.Core.PermanentBuffSystems;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Stations
{
    public class SharpeningStationEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Sharpened] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.SharpeningStation])
            {
                player.Player.GetArmorPenetration(DamageClass.Melee) += 12;
                player.Player.buffImmune[BuffID.Sharpened] = true;
            }
        }
    }
}
