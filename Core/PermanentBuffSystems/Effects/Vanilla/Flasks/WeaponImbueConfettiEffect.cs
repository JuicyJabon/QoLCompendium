namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Flasks
{
    public class WeaponImbueConfettiEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.WeaponImbueConfetti])
            {
                player.Player.meleeEnchant = 7;
                player.Player.buffImmune[BuffID.WeaponImbueConfetti] = true;
                Common.HandleFlaskBuffs(player.Player);
            }
        }
    }
}
