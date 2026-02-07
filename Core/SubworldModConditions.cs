namespace QoLCompendium.Core
{
    public static class SubworldModConditions
    {
        //Homeward Journey
        internal static bool downedDiver;
        internal static bool downedWallOfShadow;

        //Infernum
        internal static bool downedBereftVassal;

        //Polarities
        internal static bool downedSelfsimilarSentinel;
    }

    public class SubworldModConditionsPlayer : ModPlayer
    {
        public override void OnEnterWorld()
        {
            if (SubworldModConditions.downedDiver || ModConditions.DownedBoss[(int)ModConditions.Downed.Diver])
                ModConditions.DownedBoss[(int)ModConditions.Downed.Diver] = true;

            if (SubworldModConditions.downedWallOfShadow || ModConditions.DownedBoss[(int)ModConditions.Downed.WallOfShadow])
                ModConditions.DownedBoss[(int)ModConditions.Downed.WallOfShadow] = true;

            if (SubworldModConditions.downedBereftVassal || ModConditions.DownedBoss[(int)ModConditions.Downed.BereftVassal])
                ModConditions.DownedBoss[(int)ModConditions.Downed.BereftVassal] = true;

            if (SubworldModConditions.downedSelfsimilarSentinel || ModConditions.DownedBoss[(int)ModConditions.Downed.SelfsimilarSentinel])
                ModConditions.DownedBoss[(int)ModConditions.Downed.SelfsimilarSentinel] = true;
        }
    }
}