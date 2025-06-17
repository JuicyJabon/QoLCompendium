namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class GravitationEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Gravitation] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Gravitation])
            {
                player.Player.gravControl = true;
                player.Player.buffImmune[BuffID.Gravitation] = true;
            }
        }
    }
}
