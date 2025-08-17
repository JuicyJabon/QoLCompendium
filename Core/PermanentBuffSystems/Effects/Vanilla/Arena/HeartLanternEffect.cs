namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Arena
{
    public class HeartLanternEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.HeartLamp] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.HeartLantern])
            {
                if (Main.myPlayer == player.Player.whoAmI || Main.netMode == NetmodeID.Server)
                    Main.SceneMetrics.HasHeartLantern = true;
                player.Player.buffImmune[BuffID.HeartLamp] = true;
            }
        }
    }
}
