namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Stations
{
    public class CrystalBallEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Clairvoyance] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.CrystalBall])
            {
                player.Player.GetDamage(DamageClass.Magic) += 0.05f;
                player.Player.GetCritChance(DamageClass.Magic) += 2f;
                player.Player.statManaMax2 += 20;
                player.Player.manaCost -= 0.02f;
                player.Player.buffImmune[BuffID.Clairvoyance] = true;
            }
        }
    }
}
