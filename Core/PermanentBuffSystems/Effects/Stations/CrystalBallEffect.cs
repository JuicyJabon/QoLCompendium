using QoLCompendium.Core.PermanentBuffSystems;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Stations
{
    public class CrystalBallEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Clairvoyance] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.CrystalBall])
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
