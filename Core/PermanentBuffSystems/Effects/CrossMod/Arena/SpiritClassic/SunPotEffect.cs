namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Arena.SpiritClassic
{
    public class SunPotEffect : IPermanentModdedBuff
    {
        //Item Name = SunPot
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.spiritLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritMod, "SunPotBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentSpiritClassicBuffsBools[(int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.SunPot])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "SunPotBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritMod, "SunPotBuff")] = true;
            }
        }
    }
}
