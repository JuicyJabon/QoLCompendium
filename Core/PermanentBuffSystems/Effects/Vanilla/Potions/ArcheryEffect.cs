namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Potions
{
    public class ArcheryEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Archery] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Archery])
            {
                player.Player.archery = true;
                player.Player.arrowDamage *= 1.1f;
                player.Player.buffImmune[BuffID.Archery] = true;
            }
        }
    }
}
