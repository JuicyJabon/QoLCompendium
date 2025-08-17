namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Thorium
{
    public class GlowingEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.thoriumLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.thoriumMod, "GlowingPotionBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentThoriumBuffsBools[(int)PermanentBuffPlayer.PermanentThoriumBuffs.Glowing])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "GlowingPotionBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.thoriumMod, "GlowingPotionBuff")] = true;
            }
        }
    }
}
