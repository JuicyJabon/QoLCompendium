namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Stations
{
    public class WarTableEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.WarTable] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.WarTable])
            {
                player.Player.maxTurrets += 1;
                player.Player.buffImmune[BuffID.WarTable] = true;
            }
        }
    }
}
