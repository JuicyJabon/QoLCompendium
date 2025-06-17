using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Thorium;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.Thorium
{
    public class ThoriumHealerEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.thoriumLoaded)
                return;

            new ArcaneEffect().ApplyEffect(player);
            new GlowingEffect().ApplyEffect(player);
            new HolyEffect().ApplyEffect(player);
        }
    }
}
