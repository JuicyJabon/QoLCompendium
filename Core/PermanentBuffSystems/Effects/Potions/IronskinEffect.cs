namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class IronskinEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Ironskin] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Ironskin])
            {
                player.Player.statDefense += 8;
                player.Player.buffImmune[BuffID.Ironskin] = true;
            }
        }
    }
}
