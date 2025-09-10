namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Arena.SpiritClassic
{
    public class SunPotEffect : IPermanentModdedBuff
    {
        //Item Name = SunPot
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.spiritClassicLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritClassicMod, "SunPotBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentSpiritClassicBuffsBools[(int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.SunPot])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritClassicMod, "SunPotBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritClassicMod, "SunPotBuff")] = true;
            }
        }
    }
}
