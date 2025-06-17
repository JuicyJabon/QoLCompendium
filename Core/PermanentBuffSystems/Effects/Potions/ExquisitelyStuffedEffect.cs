namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class ExquisitelyStuffedEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.WellFed3] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.ExquisitelyStuffed])
            {
                player.Player.wellFed = true;
                player.Player.statDefense += 4;
                player.Player.GetCritChance(DamageClass.Generic) += 4f;
                player.Player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
                player.Player.GetDamage(DamageClass.Generic) += 0.1f;
                player.Player.GetKnockback(DamageClass.Summon) += 1f;
                player.Player.moveSpeed += 0.4f;
                player.Player.pickSpeed -= 0.15f;
                player.Player.buffImmune[BuffID.WellFed] = true;
                player.Player.buffImmune[BuffID.WellFed2] = true;
                player.Player.buffImmune[BuffID.WellFed3] = true;
            }
        }
    }
}
