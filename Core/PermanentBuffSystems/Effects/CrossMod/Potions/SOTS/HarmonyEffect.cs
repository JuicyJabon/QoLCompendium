namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.SOTS
{
    public class HarmonyEffect : IPermanentModdedBuff
    {
        //Item Name = HarmonyPotion
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.secretsOfTheShadowsLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "Harmony")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentSOTSBuffsBools[(int)PermanentBuffPlayer.PermanentSOTSBuffs.Harmony])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "Harmony"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "Harmony")] = true;
            }
        }
    }
}
