namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.SpiritClassic.Candies
{
    public class ChocolateBarEffect : IPermanentModdedBuff
    {
        //Item Name = ChocolateBar
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.spiritLoaded)
                return;

            // && !PermanentBuffPlayer.PermanentSpiritClassicBuffsBools[(int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.Jump]
            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritMod, "ChocolateBuff")])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "ChocolateBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritMod, "ChocolateBuff")] = true;
            }
        }
    }
}
