namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Potions
{
    public class CalmEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Calm] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Calm])
            {
                player.Player.calmed = true;
                player.Player.buffImmune[BuffID.Calm] = true;
            }
        }
    }
}
