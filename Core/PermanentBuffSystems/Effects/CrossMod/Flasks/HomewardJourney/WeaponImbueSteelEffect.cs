namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Flasks.HomewardJourney
{
    public class WeaponImbueSteelEffect : IPermanentModdedBuff
    {
        //Item Name = SteelFlask
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.homewardJourneyLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.homewardJourneyMod, "Flask_SteelBuff")])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.homewardJourneyMod, "Flask_SteelBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.homewardJourneyMod, "Flask_SteelBuff")] = true;
                Common.HandleFlaskBuffs(player.Player);
            }
        }
    }
}
