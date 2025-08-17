namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Flasks
{
    public class WeaponImbueCursedFlamesEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.WeaponImbueCursedFlames])
            {
                player.Player.meleeEnchant = 2;
                player.Player.buffImmune[BuffID.WeaponImbueCursedFlames] = true;
                Common.HandleFlaskBuffs(player.Player);
            }
        }
    }
}
