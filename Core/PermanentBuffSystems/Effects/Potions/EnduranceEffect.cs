namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class EnduranceEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Endurance] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Endurance])
            {
                player.Player.endurance += 0.1f;
                player.Player.buffImmune[BuffID.Endurance] = true;
            }
        }
    }
}
