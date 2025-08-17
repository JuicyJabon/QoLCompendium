namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Flasks.HomewardJourney
{
    public class WeaponImbuePlagueEffect : IPermanentModdedBuff
    {
        //Item Name = PlagueFlask
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.homewardJourneyLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.homewardJourneyMod, "Flask_PlagueBuff")])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.homewardJourneyMod, "Flask_PlagueBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.homewardJourneyMod, "Flask_PlagueBuff")] = true;
                Common.HandleFlaskBuffs(player.Player);
            }
        }
    }
}
