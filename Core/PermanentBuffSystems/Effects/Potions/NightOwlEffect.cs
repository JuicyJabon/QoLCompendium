namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class NightOwlEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.NightOwl] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.NightOwl])
            {
                player.Player.nightVision = true;
                player.Player.buffImmune[BuffID.NightOwl] = true;
            }
        }
    }
}
