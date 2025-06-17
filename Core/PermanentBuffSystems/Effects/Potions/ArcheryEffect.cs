namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class ArcheryEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Archery] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Archery])
            {
                player.Player.archery = true;
                player.Player.arrowDamage *= 1.1f;
                player.Player.buffImmune[BuffID.Archery] = true;
            }
        }
    }
}
