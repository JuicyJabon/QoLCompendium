namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class ThornsEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Thorns] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Thorns])
            {
                player.Player.thorns = 1f;
                player.Player.buffImmune[BuffID.Thorns] = true;
            }
        }
    }
}
