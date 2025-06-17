namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class TipsyEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Tipsy] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Tipsy])
            {
                if (player.Player.HeldItem.DamageType == DamageClass.Melee)
                {
                    player.Player.tipsy = true;
                    player.Player.statDefense -= 4;
                    player.Player.GetCritChance(DamageClass.Melee) += 2f;
                    player.Player.GetDamage(DamageClass.Melee) += 0.1f;
                    player.Player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
                }
                player.Player.buffImmune[BuffID.Tipsy] = true;
            }
        }
    }
}
