namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Flasks
{
    public class WeaponImbueGoldEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.WeaponImbueGold])
            {
                player.Player.meleeEnchant = 4;
                player.Player.buffImmune[BuffID.WeaponImbueGold] = true;
                Common.HandleFlaskBuffs(player.Player);
            }
        }
    }
}
