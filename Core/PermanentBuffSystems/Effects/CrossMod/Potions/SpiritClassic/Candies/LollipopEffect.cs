namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.SpiritClassic.Candies
{
    public class LollipopEffect : IPermanentModdedBuff
    {
        //Item Name = Lollipop
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.spiritLoaded)
                return;

            // && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentSpiritClassicBuffsBools[(int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.Jump]
            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritMod, "LollipopBuff")])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "LollipopBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritMod, "LollipopBuff")] = true;
            }
        }
    }
}
