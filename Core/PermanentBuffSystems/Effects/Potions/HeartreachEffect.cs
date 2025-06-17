namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class HeartreachEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Heartreach] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Heartreach])
            {
                player.Player.lifeMagnet = true;
                player.Player.buffImmune[BuffID.Heartreach] = true;
            }
        }
    }
}
