using QoLCompendium.Core.PermanentBuffSystems.Effects.Potions;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Upgraded
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
