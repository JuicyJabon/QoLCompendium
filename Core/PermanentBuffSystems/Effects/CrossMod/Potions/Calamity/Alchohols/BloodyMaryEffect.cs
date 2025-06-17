namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Calamity.Alchohols
{
    public class BloodyMaryEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.calamityLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.calamityMod, "BloodyMaryBuff")])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "BloodyMaryBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.calamityMod, "BloodyMaryBuff")] = true;
            }
        }
    }
}
