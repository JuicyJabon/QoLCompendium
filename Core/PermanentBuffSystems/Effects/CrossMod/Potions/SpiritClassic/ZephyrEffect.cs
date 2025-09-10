namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.SpiritClassic
{
    public class ZephyrEffect : IPermanentModdedBuff
    {
        //Item Name = DoubleJumpPotion
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.spiritClassicLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritClassicMod, "DoubleJumpPotionBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentSpiritClassicBuffsBools[(int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.Zephyr])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritClassicMod, "DoubleJumpPotionBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritClassicMod, "DoubleJumpPotionBuff")] = true;
            }
        }
    }
}
