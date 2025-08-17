namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Arena
{
    public class StarInABottleEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.StarInBottle] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.StarInABottle])
            {
                if (Main.myPlayer == player.Player.whoAmI || Main.netMode == NetmodeID.Server)
                    Main.SceneMetrics.HasStarInBottle = true;
                player.Player.manaRegenBonus += 2;
                player.Player.buffImmune[BuffID.StarInBottle] = true;
            }
        }
    }
}
