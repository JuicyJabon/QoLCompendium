namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.CalamityEntropy
{
    public class SoyMilkEffect : IPermanentModdedBuff
    {
        //Item Name = SoyMilk
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.calamityEntropyLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.calamityEntropyMod, "SoyMilkBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentCalamityBuffsBools[(int)PermanentBuffPlayer.PermanentCalamityBuffs.SoyMilk])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityEntropyMod, "SoyMilkBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.calamityEntropyMod, "SoyMilkBuff")] = true;
            }
        }
    }
}
