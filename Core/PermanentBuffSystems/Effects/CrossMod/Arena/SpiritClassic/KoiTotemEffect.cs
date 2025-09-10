namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Arena.SpiritClassic
{
    public class KoiTotemEffect : IPermanentModdedBuff
    {
        //Item Name = KoiTotem
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.spiritClassicLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritClassicMod, "KoiTotemBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentSpiritClassicBuffsBools[(int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.KoiTotem])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritClassicMod, "KoiTotemBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritClassicMod, "KoiTotemBuff")] = true;
            }
        }
    }
}
