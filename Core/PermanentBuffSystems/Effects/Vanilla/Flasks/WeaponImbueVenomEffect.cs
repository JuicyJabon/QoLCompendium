namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Flasks
{
    public class WeaponImbueVenomEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.WeaponImbueVenom])
            {
                player.Player.meleeEnchant = 1;
                player.Player.buffImmune[BuffID.WeaponImbueVenom] = true;
                Common.HandleFlaskBuffs(player.Player);
            }
        }
    }
}
