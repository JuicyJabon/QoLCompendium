namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.SpiritClassic.Candies
{
    public class HealthCandyEffect : IPermanentModdedBuff
    {
        //Item Name = HealthCandy
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.spiritClassicLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritClassicMod, "HealthBuffC")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentSpiritClassicBuffsBools[(int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.HealthCandy])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritClassicMod, "HealthBuffC"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritClassicMod, "HealthBuffC")] = true;
            }
        }
    }
}
