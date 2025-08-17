namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Potions
{
    public class BiomeSightEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.BiomeSight] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.BiomeSight])
            {
                player.Player.biomeSight = true;
                player.Player.buffImmune[BuffID.BiomeSight] = true;
            }
        }
    }
}
