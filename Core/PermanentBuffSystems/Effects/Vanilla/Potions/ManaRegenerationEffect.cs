namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Potions
{
    public class ManaRegenerationEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.ManaRegeneration] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.ManaRegeneration])
            {
                player.Player.manaRegenBuff = true;
                player.Player.buffImmune[BuffID.ManaRegeneration] = true;
            }
        }
    }
}
