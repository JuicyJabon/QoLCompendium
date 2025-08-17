namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.MartinsOrder
{
    public class DefenderEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.martainsOrderLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.martainsOrderMod, "TurretBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentMartinsOrderBuffsBools[(int)PermanentBuffPlayer.PermanentMartinsOrderBuffs.Defender])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.martainsOrderMod, "TurretBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.martainsOrderMod, "TurretBuff")] = true;
            }
        }
    }
}
