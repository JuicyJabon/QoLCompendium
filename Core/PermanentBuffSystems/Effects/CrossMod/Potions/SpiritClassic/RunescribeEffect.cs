namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.SpiritClassic
{
    public class RunescribeEffect : IPermanentModdedBuff
    {
        //Item Name = RunePotion
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.spiritLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritMod, "RunePotionBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentSpiritClassicBuffsBools[(int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.Runescribe])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "RunePotionBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritMod, "RunePotionBuff")] = true;
            }
        }
    }
}
