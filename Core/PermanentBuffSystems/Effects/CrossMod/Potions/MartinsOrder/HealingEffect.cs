namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.MartinsOrder
{
    public class HealingEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.martainsOrderLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.martainsOrderMod, "Healing")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentMartinsOrderBuffsBools[(int)PermanentBuffPlayer.PermanentMartinsOrderBuffs.Healing])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.martainsOrderMod, "Healing"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.martainsOrderMod, "Healing")] = true;
            }
        }
    }
}
