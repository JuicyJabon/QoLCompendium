namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class WaterWalkingEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.WaterWalking] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.WaterWalking])
            {
                player.Player.waterWalk = true;
                player.Player.buffImmune[BuffID.WaterWalking] = true;
            }
        }
    }
}
