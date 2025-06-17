namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class MiningEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Mining] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Mining])
            {
                player.Player.pickSpeed -= 0.25f;
                player.Player.buffImmune[BuffID.Mining] = true;
            }
        }
    }
}
