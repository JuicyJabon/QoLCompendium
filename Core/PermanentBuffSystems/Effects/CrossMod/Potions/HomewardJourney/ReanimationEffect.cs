namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.HomewardJourney
{
    public class ReanimationEffect : IPermanentModdedBuff
    {
        //Item Name = ReanimationPotion
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.homewardJourneyLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.homewardJourneyMod, "ReanimationBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentHomewardJourneyBuffsBools[(int)PermanentBuffPlayer.PermanentHomewardJourneyBuffs.Reanimation])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.homewardJourneyMod, "ReanimationBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.homewardJourneyMod, "ReanimationBuff")] = true;
                Common.HandleFlaskBuffs(player.Player);
            }
        }
    }
}
