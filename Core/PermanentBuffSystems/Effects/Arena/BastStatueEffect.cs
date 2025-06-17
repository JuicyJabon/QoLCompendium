namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Arena
{
    public class BastStatueEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.CatBast] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.BastStatue])
            {
                player.Player.statDefense += 5;
                player.Player.buffImmune[BuffID.CatBast] = true;
            }
        }
    }
}
