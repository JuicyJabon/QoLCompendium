using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Thorium;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.Thorium
{
    public class ThoriumDamageEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.thoriumLoaded)
                return;

            new ArtilleryEffect().ApplyEffect(player);
            new BouncingFlameEffect().ApplyEffect(player);
            new CactusFruitEffect().ApplyEffect(player);
            new ConflagrationEffect().ApplyEffect(player);
            new FrenzyEffect().ApplyEffect(player);
            new WarmongerEffect().ApplyEffect(player);
        }
    }
}
