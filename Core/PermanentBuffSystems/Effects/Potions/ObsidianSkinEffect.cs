namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class ObsidianSkinEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.ObsidianSkin] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.ObsidianSkin])
            {
                player.Player.lavaImmune = true;
                player.Player.fireWalk = true;
                player.Player.buffImmune[BuffID.OnFire] = true;
                player.Player.buffImmune[BuffID.ObsidianSkin] = true;
            }
        }
    }
}
