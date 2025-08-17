using QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Arena;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Upgraded
{
    public class ArenaEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            new BastStatueEffect().ApplyEffect(player);
            new CampfireEffect().ApplyEffect(player);
            new GardenGnomeEffect().ApplyEffect(player);
            new HeartLanternEffect().ApplyEffect(player);
            new HoneyEffect().ApplyEffect(player);
            new PeaceCandleEffect().ApplyEffect(player);
            new ShadowCandleEffect().ApplyEffect(player);
            new StarInABottleEffect().ApplyEffect(player);
            new SunflowerEffect().ApplyEffect(player);
            new WaterCandleEffect().ApplyEffect(player);
        }
    }
}
