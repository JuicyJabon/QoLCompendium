using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Flasks.Thorium;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.Thorium
{
    public class ThoriumCoatingEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.thoriumLoaded)
                return;

            if (player.Player.GetModPlayer<QoLCPlayer>().thoriumCoatingMode == 0)
                new ThrownWeaponImbueDeepFreezeEffect().ApplyEffect(player);

            if (player.Player.GetModPlayer<QoLCPlayer>().thoriumCoatingMode == 1)
                new ThrownWeaponImbueExplosiveEffect().ApplyEffect(player);

            if (player.Player.GetModPlayer<QoLCPlayer>().thoriumCoatingMode == 2)
                new ThrownWeaponImbueGorgonJuiceEffect().ApplyEffect(player);

            if (player.Player.GetModPlayer<QoLCPlayer>().thoriumCoatingMode == 3)
                new ThrownWeaponImbueSporesEffect().ApplyEffect(player);

            if (player.Player.GetModPlayer<QoLCPlayer>().thoriumCoatingMode == 4)
                new ThrownWeaponImbueToxicEffect().ApplyEffect(player);
        }
    }
}
