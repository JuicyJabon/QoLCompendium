namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class SummoningEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Summoning] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Summoning])
            {
                player.Player.maxMinions += 1;
                player.Player.buffImmune[BuffID.Summoning] = true;
            }
        }
    }
}
