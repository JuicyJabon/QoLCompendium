namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class FeatherfallEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Featherfall] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Featherfall])
            {
                player.Player.slowFall = true;
                player.Player.buffImmune[BuffID.Featherfall] = true;
            }
        }
    }
}
