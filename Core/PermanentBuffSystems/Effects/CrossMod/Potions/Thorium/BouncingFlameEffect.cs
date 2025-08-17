namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Thorium
{
    public class BouncingFlameEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.thoriumLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.thoriumMod, "BouncingFlamePotionBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentThoriumBuffsBools[(int)PermanentBuffPlayer.PermanentThoriumBuffs.BouncingFlame])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "BouncingFlamePotionBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.thoriumMod, "BouncingFlamePotionBuff")] = true;
            }
        }
    }
}
