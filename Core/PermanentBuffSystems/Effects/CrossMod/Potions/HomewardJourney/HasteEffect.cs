namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.HomewardJourney
{
    public class HasteEffect : IPermanentModdedBuff
    {
        //Item Name = HastePotion
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.homewardJourneyLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.homewardJourneyMod, "HasteBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentHomewardJourneyBuffsBools[(int)PermanentBuffPlayer.PermanentHomewardJourneyBuffs.Haste])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.homewardJourneyMod, "HasteBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.homewardJourneyMod, "HasteBuff")] = true;
                Common.HandleFlaskBuffs(player.Player);
            }
        }
    }
}
