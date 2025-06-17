namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class AmmoReservationEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.AmmoReservation] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.AmmoReservation])
            {
                player.Player.ammoPotion = true;
                player.Player.buffImmune[BuffID.AmmoReservation] = true;
            }
        }
    }
}
