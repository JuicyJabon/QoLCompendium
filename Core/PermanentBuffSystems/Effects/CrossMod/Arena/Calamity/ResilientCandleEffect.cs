namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Arena.Calamity
{
    public class ResilientCandleEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.calamityLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.calamityMod, "PurpleCandleBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentCalamityBuffsBools[(int)PermanentBuffPlayer.PermanentCalamityBuffs.ResilientCandle])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "PurpleCandleBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.calamityMod, "PurpleCandleBuff")] = true;
            }
        }
    }
}
