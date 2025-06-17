namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Flasks
{
    public class WeaponImbuePoisonEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.WeaponImbuePoison])
            {
                player.Player.meleeEnchant = 8;
                player.Player.buffImmune[BuffID.WeaponImbuePoison] = true;
                Common.HandleFlaskBuffs(player.Player);
            }
        }
    }
}
