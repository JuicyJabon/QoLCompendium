namespace QoLCompendium.Tweaks
{
    public static class SubworldModConditions
    {
        internal static bool downedBereftVassal;
    }

    public class SubworldModConditionsPlayer : ModPlayer
    {
        public override void OnEnterWorld()
        {
            if (SubworldModConditions.downedBereftVassal)
            {
                ModConditions.downedBereftVassal = true;
            }
        }
    }
}
