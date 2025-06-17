namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class FlipperEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Flipper] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Flipper])
            {
                player.Player.ignoreWater = true;
                player.Player.accFlipper = true;
                player.Player.buffImmune[BuffID.Flipper] = true;
            }
        }
    }
}
