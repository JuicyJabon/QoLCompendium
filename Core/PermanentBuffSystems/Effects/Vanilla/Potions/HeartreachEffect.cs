namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Potions
{
    public class HeartreachEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Heartreach] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Heartreach])
            {
                player.Player.lifeMagnet = true;
                player.Player.buffImmune[BuffID.Heartreach] = true;
            }
        }
    }
}
