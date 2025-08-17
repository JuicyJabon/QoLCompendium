namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.SpiritClassic.Candies
{
    public class TaffyEffect : IPermanentModdedBuff
    {
        //Item Name = Taffy
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.spiritLoaded)
                return;

            // && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentSpiritClassicBuffsBools[(int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.Jump]
            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritMod, "TaffyBuff")])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "TaffyBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritMod, "TaffyBuff")] = true;
            }
        }
    }
}
