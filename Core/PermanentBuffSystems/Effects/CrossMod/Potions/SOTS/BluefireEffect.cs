namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.SOTS
{
    public class BluefireEffect : IPermanentModdedBuff
    {
        //Item Name = BluefirePotion
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.secretsOfTheShadowsLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "Bluefire")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentSOTSBuffsBools[(int)PermanentBuffPlayer.PermanentSOTSBuffs.Bluefire])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "Bluefire"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "Bluefire")] = true;
            }
        }
    }
}
