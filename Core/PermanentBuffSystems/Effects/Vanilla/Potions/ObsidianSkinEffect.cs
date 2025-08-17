namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Potions
{
    public class ObsidianSkinEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.ObsidianSkin] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.ObsidianSkin])
            {
                player.Player.lavaImmune = true;
                player.Player.fireWalk = true;
                player.Player.buffImmune[BuffID.OnFire] = true;
                player.Player.buffImmune[BuffID.ObsidianSkin] = true;
            }
        }
    }
}
