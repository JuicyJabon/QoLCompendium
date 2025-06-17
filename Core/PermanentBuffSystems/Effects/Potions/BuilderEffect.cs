namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class BuilderEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Builder] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Builder])
            {
                player.Player.tileSpeed += 0.25f;
                player.Player.wallSpeed += 0.25f;
                player.Player.blockRange++;
                player.Player.buffImmune[BuffID.Builder] = true;
            }
        }
    }
}
