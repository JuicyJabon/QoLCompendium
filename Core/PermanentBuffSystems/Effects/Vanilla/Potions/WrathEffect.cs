namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Potions
{
    public class WrathEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Wrath] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Wrath])
            {
                player.Player.GetDamage(DamageClass.Generic) += 0.1f;
                player.Player.buffImmune[BuffID.Wrath] = true;
            }
        }
    }
}
