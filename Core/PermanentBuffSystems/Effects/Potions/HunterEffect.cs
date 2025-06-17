namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class HunterEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Hunter] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Hunter])
            {
                player.Player.detectCreature = true;
                player.Player.buffImmune[BuffID.Hunter] = true;
            }
        }
    }
}
