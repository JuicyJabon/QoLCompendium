namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Potions
{
    public class WellFedEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.WellFed] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.WellFed])
            {
                player.Player.wellFed = true;
                player.Player.statDefense += 2;
                player.Player.GetCritChance(DamageClass.Generic) += 2f;
                player.Player.GetAttackSpeed(DamageClass.Melee) += 0.05f;
                player.Player.GetDamage(DamageClass.Generic) += 0.05f;
                player.Player.GetKnockback(DamageClass.Summon) += 0.5f;
                player.Player.moveSpeed += 0.2f;
                player.Player.pickSpeed -= 0.05f;
                player.Player.buffImmune[BuffID.WellFed] = true;
            }
        }
    }
}
