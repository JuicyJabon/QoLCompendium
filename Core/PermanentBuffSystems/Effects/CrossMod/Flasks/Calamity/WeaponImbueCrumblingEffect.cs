namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Flasks.Calamity
{
    public class WeaponImbueCrumblingEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.calamityLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.calamityMod, "WeaponImbueCrumbling")])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "WeaponImbueCrumbling"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.calamityMod, "WeaponImbueCrumbling")] = true;
                Common.HandleFlaskBuffs(player.Player);
            }
        }
    }
}
