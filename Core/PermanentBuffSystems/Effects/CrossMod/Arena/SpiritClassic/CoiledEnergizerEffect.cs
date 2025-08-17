namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Arena.SpiritClassic
{
    public class CoiledEnergizerEffect : IPermanentModdedBuff
    {
        //Item Name = CoilEnergizerItem
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.spiritLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritMod, "OverDrive")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentSpiritClassicBuffsBools[(int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.CoiledEnergizer])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "OverDrive"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritMod, "OverDrive")] = true;
            }
        }
    }
}
