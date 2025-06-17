namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Flasks.Calamity
{
    public class WeaponImbueBrimstoneEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.calamityLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.calamityMod, "WeaponImbueBrimstone")])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "WeaponImbueBrimstone"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.calamityMod, "WeaponImbueBrimstone")] = true;
                Common.HandleFlaskBuffs(player.Player);
            }
        }
    }
}
