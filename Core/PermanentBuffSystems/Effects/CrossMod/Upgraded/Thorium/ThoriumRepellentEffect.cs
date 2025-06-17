using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Thorium;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.Thorium
{
    public class ThoriumRepellentEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.thoriumLoaded)
                return;

            new BatRepellentEffect().ApplyEffect(player);
            new FishRepellentEffect().ApplyEffect(player);
            new InsectRepellentEffect().ApplyEffect(player);
            new SkeletonRepellentEffect().ApplyEffect(player);
            new ZombieRepellentEffect().ApplyEffect(player);
        }
    }
}
