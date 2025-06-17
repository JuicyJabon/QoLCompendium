namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Clicker
{
    public class InfluenceEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.clickerClassLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.clickerClassMod, "InfluenceBuff")])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.clickerClassMod, "InfluenceBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.clickerClassMod, "InfluenceBuff")] = true;
            }
        }
    }
}
