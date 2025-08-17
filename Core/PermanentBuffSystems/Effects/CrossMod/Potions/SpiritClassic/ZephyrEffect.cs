namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.SpiritClassic
{
    public class ZephyrEffect : IPermanentModdedBuff
    {
        //Item Name = DoubleJumpPotion
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.spiritLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritMod, "DoubleJumpPotionBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentSpiritClassicBuffsBools[(int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.Zephyr])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "DoubleJumpPotionBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritMod, "DoubleJumpPotionBuff")] = true;
            }
        }
    }
}
