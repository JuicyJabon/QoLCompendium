namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Potions
{
    public class LifeforceEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Lifeforce] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Lifeforce])
            {
                player.Player.lifeForce = true;
                player.Player.statLifeMax2 += player.Player.statLifeMax / 5;
                player.Player.buffImmune[BuffID.Lifeforce] = true;
            }
        }
    }
}
