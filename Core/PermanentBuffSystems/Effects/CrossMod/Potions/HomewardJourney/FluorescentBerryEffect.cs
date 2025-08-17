namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.HomewardJourney
{
    public class FluorescentBerryEffect : IPermanentModdedBuff
    {
        //Item Name = FluorescentBerryCan
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.homewardJourneyLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.homewardJourneyMod, "FluorescentBerryBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentHomewardJourneyBuffsBools[(int)PermanentBuffPlayer.PermanentHomewardJourneyBuffs.FluorescentBerry])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.homewardJourneyMod, "FluorescentBerryBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.homewardJourneyMod, "FluorescentBerryBuff")] = true;
                Common.HandleFlaskBuffs(player.Player);
            }
        }
    }
}
