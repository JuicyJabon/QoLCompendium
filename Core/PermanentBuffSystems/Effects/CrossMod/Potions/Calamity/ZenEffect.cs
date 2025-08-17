namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Calamity
{
    public class ZenEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.calamityLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.calamityMod, "Zen")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentCalamityBuffsBools[(int)PermanentBuffPlayer.PermanentCalamityBuffs.Zen])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "Zen"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.calamityMod, "Zen")] = true;
            }
        }
    }
}
