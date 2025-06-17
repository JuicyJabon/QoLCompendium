namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class RegenerationEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Regeneration] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Regeneration])
            {
                player.Player.lifeRegen += 4;
                player.Player.buffImmune[BuffID.Regeneration] = true;
            }
        }
    }
}
