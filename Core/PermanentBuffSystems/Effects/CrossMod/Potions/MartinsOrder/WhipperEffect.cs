namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.MartinsOrder
{
    public class WhipperEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.martainsOrderLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.martainsOrderMod, "WhipperBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentMartinsOrderBuffsBools[(int)PermanentBuffPlayer.PermanentMartinsOrderBuffs.Whipper])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.martainsOrderMod, "WhipperBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.martainsOrderMod, "WhipperBuff")] = true;
            }
        }
    }
}
