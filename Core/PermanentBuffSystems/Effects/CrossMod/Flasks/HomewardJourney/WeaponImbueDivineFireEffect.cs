namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Flasks.HomewardJourney
{
    public class WeaponImbueDivineFireEffect : IPermanentModdedBuff
    {
        //Item Name = DivineFireFlask
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.homewardJourneyLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.homewardJourneyMod, "Flask_DivineFireBuff")])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.homewardJourneyMod, "Flask_DivineFireBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.homewardJourneyMod, "Flask_DivineFireBuff")] = true;
                Common.HandleFlaskBuffs(player.Player);
            }
        }
    }
}
