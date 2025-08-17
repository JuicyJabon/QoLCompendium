namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Potions
{
    public class BuilderEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Builder] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Builder])
            {
                player.Player.tileSpeed += 0.25f;
                player.Player.wallSpeed += 0.25f;
                player.Player.blockRange++;
                player.Player.buffImmune[BuffID.Builder] = true;
            }
        }
    }
}
