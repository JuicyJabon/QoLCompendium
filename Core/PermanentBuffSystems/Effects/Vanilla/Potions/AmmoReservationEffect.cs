namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Potions
{
    public class AmmoReservationEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.AmmoReservation] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.AmmoReservation])
            {
                player.Player.ammoPotion = true;
                player.Player.buffImmune[BuffID.AmmoReservation] = true;
            }
        }
    }
}
