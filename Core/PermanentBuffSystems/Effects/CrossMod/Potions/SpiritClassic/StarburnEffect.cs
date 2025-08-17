namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.SpiritClassic
{
    public class StarburnEffect : IPermanentModdedBuff
    {
        //Item Name = StarPotion
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.spiritLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritMod, "StarPotionBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentSpiritClassicBuffsBools[(int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.Starburn])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "StarPotionBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritMod, "StarPotionBuff")] = true;
            }
        }
    }
}
