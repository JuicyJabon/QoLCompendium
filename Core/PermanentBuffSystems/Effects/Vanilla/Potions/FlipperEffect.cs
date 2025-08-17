namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Potions
{
    public class FlipperEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Flipper] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Flipper])
            {
                player.Player.ignoreWater = true;
                player.Player.accFlipper = true;
                player.Player.buffImmune[BuffID.Flipper] = true;
            }
        }
    }
}
