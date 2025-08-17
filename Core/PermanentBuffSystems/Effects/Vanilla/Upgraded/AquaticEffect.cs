using QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Potions;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Upgraded
{
    public class AquaticEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            new GillsEffect().ApplyEffect(player);
            new FlipperEffect().ApplyEffect(player);
            new WaterWalkingEffect().ApplyEffect(player);
        }
    }
}
