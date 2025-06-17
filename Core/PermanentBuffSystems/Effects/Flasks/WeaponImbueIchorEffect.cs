namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Flasks
{
    public class WeaponImbueIchorEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.WeaponImbueIchor])
            {
                player.Player.meleeEnchant = 5;
                player.Player.buffImmune[BuffID.WeaponImbueIchor] = true;
                Common.HandleFlaskBuffs(player.Player);
            }
        }
    }
}
