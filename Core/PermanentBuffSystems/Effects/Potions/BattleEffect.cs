namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class BattleEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Battle] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Battle])
            {
                player.Player.enemySpawns = true;
                player.Player.buffImmune[BuffID.Battle] = true;
            }
        }
    }
}
