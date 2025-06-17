namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class PlentySatisfiedEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.WellFed2] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.PlentySatisfied])
            {
                player.Player.wellFed = true;
                player.Player.statDefense += 3;
                player.Player.GetCritChance(DamageClass.Generic) += 3f;
                player.Player.GetAttackSpeed(DamageClass.Melee) += 0.075f;
                player.Player.GetDamage(DamageClass.Generic) += 0.075f;
                player.Player.GetKnockback(DamageClass.Summon) += 0.75f;
                player.Player.moveSpeed += 0.3f;
                player.Player.pickSpeed -= 0.1f;
                player.Player.buffImmune[BuffID.WellFed] = true;
                player.Player.buffImmune[BuffID.WellFed2] = true;
            }
        }
    }
}
