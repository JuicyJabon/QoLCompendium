namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Flasks
{
    public class WeaponImbueNanitesEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.WeaponImbueNanites])
            {
                player.Player.meleeEnchant = 6;
                player.Player.buffImmune[BuffID.WeaponImbueNanites] = true;
                Common.HandleFlaskBuffs(player.Player);
            }
        }
    }
}
