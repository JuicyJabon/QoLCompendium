namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.HomewardJourney
{
    public class YinEffect : IPermanentModdedBuff
    {
        //Item Name = YinPotion
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.homewardJourneyLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.homewardJourneyMod, "NerveFibreBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentHomewardJourneyBuffsBools[(int)PermanentBuffPlayer.PermanentHomewardJourneyBuffs.Yin])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.homewardJourneyMod, "NerveFibreBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.homewardJourneyMod, "NerveFibreBuff")] = true;
                Common.HandleFlaskBuffs(player.Player);
            }
        }
    }
}
