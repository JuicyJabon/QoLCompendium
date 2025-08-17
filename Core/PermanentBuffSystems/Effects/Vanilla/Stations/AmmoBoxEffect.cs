namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Stations
{
    public class AmmoBoxEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.AmmoBox] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.AmmoBox])
            {
                player.Player.ammoBox = true;
                player.Player.buffImmune[BuffID.AmmoBox] = true;
            }
        }
    }
}
