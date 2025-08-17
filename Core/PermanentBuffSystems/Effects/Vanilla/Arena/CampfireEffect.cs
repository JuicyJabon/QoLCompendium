namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Arena
{
    public class CampfireEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Campfire] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Campfire])
            {
                if (Main.myPlayer == player.Player.whoAmI || Main.netMode == NetmodeID.Server)
                    Main.SceneMetrics.HasCampfire = true;
                player.Player.buffImmune[BuffID.Campfire] = true;
            }
        }
    }
}
