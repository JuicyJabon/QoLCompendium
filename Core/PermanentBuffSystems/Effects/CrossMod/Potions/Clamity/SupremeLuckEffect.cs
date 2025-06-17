namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Clamity
{
    public class SupremeLuckEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.clamityAddonLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.clamityAddonMod, "SupremeLucky")] && !PermanentBuffPlayer.PermanentCalamityBuffsBools[(int)PermanentBuffPlayer.PermanentCalamityBuffs.SupremeLuck])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.clamityAddonMod, "SupremeLucky"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.clamityAddonMod, "SupremeLucky")] = true;
            }
        }
    }
}
