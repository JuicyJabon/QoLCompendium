namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Stations.SOTS
{
    public class DigitalDisplayEffect : IPermanentModdedBuff
    {
        //Item Name = DigitalDisplay
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.secretsOfTheShadowsLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "CyberneticEnhancements")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentSOTSBuffsBools[(int)PermanentBuffPlayer.PermanentSOTSBuffs.DigitalDisplay])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "CyberneticEnhancements"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "CyberneticEnhancements")] = true;
            }
        }
    }
}
