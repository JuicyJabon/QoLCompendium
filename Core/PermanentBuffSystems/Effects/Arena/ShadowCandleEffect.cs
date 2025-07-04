﻿namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Arena
{
    public class ShadowCandleEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.ShadowCandle] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.ShadowCandle])
            {
                player.Player.ZoneShadowCandle = true; 
                if (Main.myPlayer == player.Player.whoAmI)
                    Main.SceneMetrics.ShadowCandleCount = 0;
                player.Player.buffImmune[BuffID.ShadowCandle] = true;
            }
        }
    }
}
