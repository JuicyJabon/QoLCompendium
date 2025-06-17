namespace QoLCompendium.Core.Changes.WorldChanges
{
    public class AlwaysSeasonalEvents : ModSystem
    {
        public override void PostUpdateWorld()
        {
            if (QoLCompendium.mainConfig.HalloweenActive)
                Main.halloween = true;
            if (QoLCompendium.mainConfig.ChristmasActive)
                Main.xMas = true;
        }
    }
}
