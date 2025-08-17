namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Arena
{
    public class BastStatueEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.CatBast] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.BastStatue])
            {
                player.Player.statDefense += 5;
                player.Player.buffImmune[BuffID.CatBast] = true;
            }
        }
    }
}