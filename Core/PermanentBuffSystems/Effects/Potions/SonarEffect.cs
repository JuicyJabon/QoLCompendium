namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class SonarEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Sonar] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Sonar])
            {
                player.Player.sonarPotion = true;
                player.Player.buffImmune[BuffID.Sonar] = true;
            }
        }
    }
}
