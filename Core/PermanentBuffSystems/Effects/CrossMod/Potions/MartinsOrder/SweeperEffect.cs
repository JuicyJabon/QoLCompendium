namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.MartinsOrder
{
    public class SweeperEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.martainsOrderLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.martainsOrderMod, "SweepBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentMartinsOrderBuffsBools[(int)PermanentBuffPlayer.PermanentMartinsOrderBuffs.Sweeper])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.martainsOrderMod, "SweepBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.martainsOrderMod, "SweepBuff")] = true;
            }
        }
    }
}
