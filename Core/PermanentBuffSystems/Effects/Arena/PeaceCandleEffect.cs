﻿namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Arena
{
    public class PeaceCandleEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.PeaceCandle] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.PeaceCandle])
            {
                player.Player.ZonePeaceCandle = true; 
                if (Main.myPlayer == player.Player.whoAmI)
                    Main.SceneMetrics.PeaceCandleCount = 0;
                player.Player.buffImmune[BuffID.PeaceCandle] = true;
            }
        }
    }
}
