namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Calamity
{
    public class ShadowEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.calamityLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.calamityMod, "ShadowBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentCalamityBuffsBools[(int)PermanentBuffPlayer.PermanentCalamityBuffs.Shadow])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "ShadowBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.calamityMod, "ShadowBuff")] = true;
            }
        }
    }
}
