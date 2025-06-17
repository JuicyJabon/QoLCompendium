namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Arena
{
    public class WaterCandleEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.WaterCandle] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.WaterCandle])
            {
                player.Player.ZoneWaterCandle = true; 
                if (Main.myPlayer == player.Player.whoAmI)
                    Main.SceneMetrics.WaterCandleCount = 0;
                player.Player.buffImmune[BuffID.WaterCandle] = true;
            }
        }
    }
}
