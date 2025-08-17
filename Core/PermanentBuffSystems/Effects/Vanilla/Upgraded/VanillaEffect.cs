namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Upgraded
{
    public class VanillaEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            new AquaticEffect().ApplyEffect(player);
            new ArenaEffect().ApplyEffect(player);
            new ConstructionEffect().ApplyEffect(player);
            new DamageEffect().ApplyEffect(player);
            new DefenseEffect().ApplyEffect(player);
            new MovementEffect().ApplyEffect(player);
            new StationEffect().ApplyEffect(player);
            new TrawlerEffect().ApplyEffect(player);
            new VisionEffect().ApplyEffect(player);
        }
    }
}
