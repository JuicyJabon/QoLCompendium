namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class SwiftnessEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Swiftness] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Swiftness])
            {
                player.Player.moveSpeed += 0.25f;
                player.Player.buffImmune[BuffID.Swiftness] = true;
            }
        }
    }
}
