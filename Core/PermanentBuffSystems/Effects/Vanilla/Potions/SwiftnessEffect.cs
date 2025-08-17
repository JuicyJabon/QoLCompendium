namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Potions
{
    public class SwiftnessEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Swiftness] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Swiftness])
            {
                player.Player.moveSpeed += 0.25f;
                player.Player.buffImmune[BuffID.Swiftness] = true;
            }
        }
    }
}
