namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class WarmthEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Warmth] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Warmth])
            {
                player.Player.resistCold = true;
                player.Player.buffImmune[BuffID.Warmth] = true;
            }
        }
    }
}
