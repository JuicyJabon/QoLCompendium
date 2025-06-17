namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class DangersenseEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Dangersense] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Dangersense])
            {
                player.Player.dangerSense = true;
                player.Player.buffImmune[BuffID.Dangersense] = true;
            }
        }
    }
}
