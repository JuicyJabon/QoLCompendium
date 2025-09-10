namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.SpiritClassic
{
    public class MoonJellyEffect : IPermanentModdedBuff
    {
        //Item Name = MoonJelly
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.spiritClassicLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritClassicMod, "MoonBlessing")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentSpiritClassicBuffsBools[(int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.MoonJelly])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritClassicMod, "MoonBlessing"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritClassicMod, "MoonBlessing")] = true;
            }
        }
    }
}
