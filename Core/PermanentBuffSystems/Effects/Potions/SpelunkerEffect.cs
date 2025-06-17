namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class SpelunkerEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Spelunker] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Spelunker])
            {
                player.Player.findTreasure = true;
                player.Player.buffImmune[BuffID.Spelunker] = true;
            }
        }
    }
}
