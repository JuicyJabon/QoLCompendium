namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class RageEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Rage] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Rage])
            {
                player.Player.GetCritChance(DamageClass.Generic) += 10f;
                player.Player.buffImmune[BuffID.Rage] = true;
            }
        }
    }
}
