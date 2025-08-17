namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.CalamityEntropy
{
    public class YharimsStimulantsEffect : IPermanentModdedBuff
    {
        //Item Name = YharimsStimulants
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.calamityEntropyLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.calamityEntropyMod, "YharimPower")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentCalamityBuffsBools[(int)PermanentBuffPlayer.PermanentCalamityBuffs.YharimsStimulants])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityEntropyMod, "YharimPower"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.calamityEntropyMod, "YharimPower")] = true;
            }
        }
    }
}
