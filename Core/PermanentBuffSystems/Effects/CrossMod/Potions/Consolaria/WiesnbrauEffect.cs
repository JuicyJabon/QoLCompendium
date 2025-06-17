namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Consolaria
{
    public class WiesnbrauEffect : IPermanentModdedBuff
    {
        //Item Name = Wiesnbrau
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.consolariaLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.consolariaMod, "Drunk")])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.consolariaMod, "Drunk"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.consolariaMod, "Drunk")] = true;
            }
        }
    }
}
