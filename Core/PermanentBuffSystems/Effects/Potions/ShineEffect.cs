namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class ShineEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Shine] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Shine])
            {
                Lighting.AddLight((int)(player.Player.position.X + player.Player.width / 2) / 16, (int)(player.Player.position.Y + player.Player.height / 2) / 16, 0.8f, 0.95f, 1f);
                player.Player.buffImmune[BuffID.Shine] = true;
            }
        }
    }
}
