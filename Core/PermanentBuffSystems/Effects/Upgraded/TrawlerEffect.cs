using QoLCompendium.Core.PermanentBuffSystems.Effects.Potions;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Upgraded
{
    public class TrawlerEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            new CrateEffect().ApplyEffect(player);
            new FishingEffect().ApplyEffect(player);
            new SonarEffect().ApplyEffect(player);
        }
    }
}
