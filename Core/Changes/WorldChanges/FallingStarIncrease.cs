namespace QoLCompendium.Core.Changes.WorldChanges
{
    public class FallingStarIncrease : ModSystem
    {
        public override void PostUpdateWorld() => Star.starfallBoost = QoLCompendium.mainConfig.MoreFallenStars;
    }
}
