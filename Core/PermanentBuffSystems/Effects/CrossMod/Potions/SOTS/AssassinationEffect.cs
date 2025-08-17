namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.SOTS
{
    public class AssassinationEffect : IPermanentModdedBuff
    {
        //Item Name = AssassinationPotion
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.secretsOfTheShadowsLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "Assassination")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentSOTSBuffsBools[(int)PermanentBuffPlayer.PermanentSOTSBuffs.Assassination])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "Assassination"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "Assassination")] = true;
            }
        }
    }
}
