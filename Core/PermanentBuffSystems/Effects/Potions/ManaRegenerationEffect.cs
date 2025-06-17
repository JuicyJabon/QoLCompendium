namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class ManaRegenerationEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.ManaRegeneration] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.ManaRegeneration])
            {
                player.Player.manaRegenBuff = true;
                player.Player.buffImmune[BuffID.ManaRegeneration] = true;
            }
        }
    }
}
