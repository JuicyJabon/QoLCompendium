namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.SpiritClassic.Candies
{
    public class HealthCandyEffect : IPermanentModdedBuff
    {
        //Item Name = HealthCandy
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.spiritLoaded)
                return;

            // && !PermanentBuffPlayer.PermanentSpiritClassicBuffsBools[(int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.Jump]
            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritMod, "HealthBuffC")])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "HealthBuffC"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritMod, "HealthBuffC")] = true;
            }
        }
    }
}
