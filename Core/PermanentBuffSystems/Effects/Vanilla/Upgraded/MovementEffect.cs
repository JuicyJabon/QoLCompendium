using QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Potions;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Upgraded
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
