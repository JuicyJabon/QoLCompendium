namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Arena
{
    public class HeartLanternEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.HeartLamp] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.HeartLantern])
            {
                if (Main.myPlayer == player.Player.whoAmI || Main.netMode == NetmodeID.Server)
                    Main.SceneMetrics.HasHeartLantern = true;
                player.Player.buffImmune[BuffID.HeartLamp] = true;
            }
        }
    }
}
