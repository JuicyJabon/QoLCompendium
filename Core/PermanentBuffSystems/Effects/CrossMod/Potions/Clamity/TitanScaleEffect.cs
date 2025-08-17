namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Clamity
{
    public class TitanScaleEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.clamityAddonLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.clamityAddonMod, "TitanScalePotionBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentCalamityBuffsBools[(int)PermanentBuffPlayer.PermanentCalamityBuffs.TitanScale])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.clamityAddonMod, "TitanScalePotionBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.clamityAddonMod, "TitanScalePotionBuff")] = true;
            }
        }
    }
}
