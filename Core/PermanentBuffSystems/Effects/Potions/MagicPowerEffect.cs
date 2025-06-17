namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class MagicPowerEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.MagicPower] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.MagicPower])
            {
                player.Player.GetDamage(DamageClass.Magic) += 0.2f;
                player.Player.buffImmune[BuffID.MagicPower] = true;
            }
        }
    }
}
