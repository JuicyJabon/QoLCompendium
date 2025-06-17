namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class BiomeSightEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.BiomeSight] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.BiomeSight])
            {
                player.Player.biomeSight = true;
                player.Player.buffImmune[BuffID.BiomeSight] = true;
            }
        }
    }
}
