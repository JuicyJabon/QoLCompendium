namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Thorium
{
    public class ConflagrationEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.thoriumLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.thoriumMod, "ConflagrationPotionBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentThoriumBuffsBools[(int)PermanentBuffPlayer.PermanentThoriumBuffs.Conflagration])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "ConflagrationPotionBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.thoriumMod, "ConflagrationPotionBuff")] = true;
            }
        }
    }
}
