namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class TitanEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Titan] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Titan])
            {
                player.Player.kbBuff = true;
                player.Player.buffImmune[BuffID.Titan] = true;
            }
        }
    }
}
