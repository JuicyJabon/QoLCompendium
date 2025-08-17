namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Arena.CalamityEntropy
{
    public class VoidCandleEffect : IPermanentModdedBuff
    {
        //Item Name = VoidCandle
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.calamityEntropyLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.calamityEntropyMod, "VoidCandleBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentCalamityBuffsBools[(int)PermanentBuffPlayer.PermanentCalamityBuffs.VoidCandle])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityEntropyMod, "VoidCandleBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.calamityEntropyMod, "VoidCandleBuff")] = true;
            }
        }
    }
}
