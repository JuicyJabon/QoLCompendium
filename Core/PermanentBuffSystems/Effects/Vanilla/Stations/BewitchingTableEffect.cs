namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Stations
{
    public class BewitchingTableEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Bewitched] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.BewitchingTable])
            {
                player.Player.maxMinions += 1;
                player.Player.buffImmune[BuffID.Bewitched] = true;
            }
        }
    }
}
