using QoLCompendium.Core.PermanentBuffSystems;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Stations
{
    public class SliceOfCakeEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.SugarRush] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.SliceOfCake])
            {
                player.Player.pickSpeed -= 0.2f;
                player.Player.moveSpeed += 0.2f;
                player.Player.buffImmune[BuffID.SugarRush] = true;
            }
        }
    }
}
