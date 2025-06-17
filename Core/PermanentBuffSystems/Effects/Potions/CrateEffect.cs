namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class CrateEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Crate] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Crate])
            {
                player.Player.cratePotion = true;
                player.Player.buffImmune[BuffID.Crate] = true;
            }
        }
    }
}
