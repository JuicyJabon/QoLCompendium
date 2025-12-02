namespace QoLCompendium.Core
{
    public static class SubworldModConditions
    {
        internal static bool downedBereftVassal;
        internal static bool downedSelfsimilarSentinel;
    }

    public class SubworldModConditionsPlayer : ModPlayer
    {
        public override void OnEnterWorld()
        {
            if (SubworldModConditions.downedBereftVassal || ModConditions.DownedBoss[(int)ModConditions.Downed.BereftVassal])
            {
                ModConditions.DownedBoss[(int)ModConditions.Downed.BereftVassal] = true;
            }
            if (SubworldModConditions.downedSelfsimilarSentinel || ModConditions.DownedBoss[(int)ModConditions.Downed.SelfsimilarSentinel])
            {
                ModConditions.DownedBoss[(int)ModConditions.Downed.SelfsimilarSentinel] = true;
            }
        }
    }
}