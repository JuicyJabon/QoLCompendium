namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Arena
{
    public class HoneyEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Honey] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Honey])
            {
                player.Player.lifeRegenTime += 2f;
                player.Player.lifeRegen += 2;
                player.Player.buffImmune[BuffID.Honey] = true;
            }
        }
    }
}
