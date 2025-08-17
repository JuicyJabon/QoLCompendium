namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Stations
{
    public class SliceOfCakeEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.SugarRush] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.SliceOfCake])
            {
                player.Player.pickSpeed -= 0.2f;
                player.Player.moveSpeed += 0.2f;
                player.Player.buffImmune[BuffID.SugarRush] = true;
            }
        }
    }
}
