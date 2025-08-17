namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.SOTS
{
    public class DoubleVisionEffect : IPermanentModdedBuff
    {
        //Item Name = DoubleVisionPotion
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.secretsOfTheShadowsLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "DoubleVision")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentSOTSBuffsBools[(int)PermanentBuffPlayer.PermanentSOTSBuffs.DoubleVision])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "DoubleVision"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "DoubleVision")] = true;
            }
        }
    }
}
