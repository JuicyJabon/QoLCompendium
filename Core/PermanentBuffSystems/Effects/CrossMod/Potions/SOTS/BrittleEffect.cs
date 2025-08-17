namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.SOTS
{
    public class BrittleEffect : IPermanentModdedBuff
    {
        //Item Name = BrittlePotion
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.secretsOfTheShadowsLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "Brittle")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentSOTSBuffsBools[(int)PermanentBuffPlayer.PermanentSOTSBuffs.Brittle])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "Brittle"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "Brittle")] = true;
            }
        }
    }
}
