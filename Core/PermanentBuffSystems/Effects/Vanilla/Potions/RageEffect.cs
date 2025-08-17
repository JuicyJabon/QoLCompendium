namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Potions
{
    public class RageEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Rage] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Rage])
            {
                player.Player.GetCritChance(DamageClass.Generic) += 10f;
                player.Player.buffImmune[BuffID.Rage] = true;
            }
        }
    }
}
