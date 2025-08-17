namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.MartinsOrder
{
    public class EmpowermentEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.martainsOrderLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.martainsOrderMod, "EmpowermentBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentMartinsOrderBuffsBools[(int)PermanentBuffPlayer.PermanentMartinsOrderBuffs.Empowerment])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.martainsOrderMod, "EmpowermentBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.martainsOrderMod, "EmpowermentBuff")] = true;
            }
        }
    }
}
