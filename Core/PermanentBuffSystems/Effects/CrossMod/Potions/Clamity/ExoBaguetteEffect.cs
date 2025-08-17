namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Clamity
{
    public class ExoBaguetteEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.clamityAddonLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.clamityAddonMod, "ExoBaguetteBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentCalamityBuffsBools[(int)PermanentBuffPlayer.PermanentCalamityBuffs.ExoBaguette])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.clamityAddonMod, "ExoBaguetteBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.clamityAddonMod, "ExoBaguetteBuff")] = true;
            }
        }
    }
}
