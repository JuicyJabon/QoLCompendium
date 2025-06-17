namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class LuckyEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Lucky] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Lucky])
            {
                player.Player.luck += 0.3f;
                player.Player.buffImmune[BuffID.Lucky] = true;
            }
        }
    }
}
