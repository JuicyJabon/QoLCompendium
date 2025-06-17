namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Arena
{
    public class SunflowerEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Sunflower] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Sunflower])
            {
                player.Player.moveSpeed += 0.1f;
                player.Player.moveSpeed *= 1.1f;
                player.Player.sunflower = true;
                player.Player.buffImmune[BuffID.Sunflower] = true;
            }
        }
    }
}
