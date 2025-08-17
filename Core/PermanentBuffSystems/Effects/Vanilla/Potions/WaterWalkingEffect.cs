namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Potions
{
    public class WaterWalkingEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.WaterWalking] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.WaterWalking])
            {
                player.Player.waterWalk = true;
                player.Player.buffImmune[BuffID.WaterWalking] = true;
            }
        }
    }
}
