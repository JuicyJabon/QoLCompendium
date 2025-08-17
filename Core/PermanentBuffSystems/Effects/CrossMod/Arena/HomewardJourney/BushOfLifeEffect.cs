namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.HomewardJourney
{
    public class BushOfLifeEffect : IPermanentModdedBuff
    {
        //Item Name = BushOfLife
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.homewardJourneyLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.homewardJourneyMod, "BushOfLifeBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentHomewardJourneyBuffsBools[(int)PermanentBuffPlayer.PermanentHomewardJourneyBuffs.BushOfLife])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.homewardJourneyMod, "BushOfLifeBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.homewardJourneyMod, "BushOfLifeBuff")] = true;
                Common.HandleFlaskBuffs(player.Player);
            }
        }
    }
}