namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.SOTS
{
    public class RippleEffect : IPermanentModdedBuff
    {
        //Item Name = RipplePotion
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.secretsOfTheShadowsLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "RippleBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentSOTSBuffsBools[(int)PermanentBuffPlayer.PermanentSOTSBuffs.Ripple])
            {
                player.Player.buffImmune[Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "RippleBuff")] = true;
            }
        }
    }
}
