using QoLCompendium.Core.PermanentBuffSystems.Effects.Potions;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Upgraded
{
    public class MovementEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            new FeatherfallEffect().ApplyEffect(player);
            new GravitationEffect().ApplyEffect(player);
            new SwiftnessEffect().ApplyEffect(player);
        }
    }
}
