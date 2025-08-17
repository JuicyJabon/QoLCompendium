using QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Flasks;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Upgraded
{
    public class FlaskEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (player.Player.GetModPlayer<QoLCPlayer>().flaskEffectMode == 0)
                new WeaponImbueCursedFlamesEffect().ApplyEffect(player);

            if (player.Player.GetModPlayer<QoLCPlayer>().flaskEffectMode == 1)
                new WeaponImbueFireEffect().ApplyEffect(player);

            if (player.Player.GetModPlayer<QoLCPlayer>().flaskEffectMode == 2)
                new WeaponImbueGoldEffect().ApplyEffect(player);

            if (player.Player.GetModPlayer<QoLCPlayer>().flaskEffectMode == 3)
                new WeaponImbueIchorEffect().ApplyEffect(player);

            if (player.Player.GetModPlayer<QoLCPlayer>().flaskEffectMode == 4)
                new WeaponImbueNanitesEffect().ApplyEffect(player);

            if (player.Player.GetModPlayer<QoLCPlayer>().flaskEffectMode == 5)
                new WeaponImbueConfettiEffect().ApplyEffect(player);

            if (player.Player.GetModPlayer<QoLCPlayer>().flaskEffectMode == 6)
                new WeaponImbuePoisonEffect().ApplyEffect(player);

            if (player.Player.GetModPlayer<QoLCPlayer>().flaskEffectMode == 7)
                new WeaponImbueVenomEffect().ApplyEffect(player);
        }
    }
}
