namespace QoLCompendium.Core.Changes.WorldChanges
{
    public class FallingStarIncrease : ModSystem
    {
        public override void PostUpdateWorld() => Star.starfallBoost = Math.Max(Star.starfallBoost, QoLCompendium.mainConfig.MoreFallenStars);
    }
}
