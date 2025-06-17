namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Flasks
{
    public class WeaponImbueFireEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.WeaponImbueFire])
            {
                player.Player.meleeEnchant = 3;
                player.Player.buffImmune[BuffID.WeaponImbueFire] = true;
                Common.HandleFlaskBuffs(player.Player);
            }
        }
    }
}
