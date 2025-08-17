using QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Potions;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Upgraded
{
    public class ConstructionEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            new BuilderEffect().ApplyEffect(player);
            new CalmEffect().ApplyEffect(player);
            new MiningEffect().ApplyEffect(player);
        }
    }
}
