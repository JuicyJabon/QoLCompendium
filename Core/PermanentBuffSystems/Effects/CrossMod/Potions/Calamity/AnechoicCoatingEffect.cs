namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Calamity
{
    public class AnechoicCoatingEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.calamityLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.calamityMod, "AnechoicCoatingBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentCalamityBuffsBools[(int)PermanentBuffPlayer.PermanentCalamityBuffs.AnechoicCoating])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "AnechoicCoatingBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.calamityMod, "AnechoicCoatingBuff")] = true;
            }
        }
    }
}
