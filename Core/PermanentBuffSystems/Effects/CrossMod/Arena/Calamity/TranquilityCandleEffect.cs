namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Arena.Calamity
{
    public class TranquilityCandleEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.calamityLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.calamityMod, "TranquilityCandleBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentCalamityBuffsBools[(int)PermanentBuffPlayer.PermanentCalamityBuffs.TranquilityCandle])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "TranquilityCandleBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.calamityMod, "TranquilityCandleBuff")] = true;
            }
        }
    }
}
