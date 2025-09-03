namespace QoLCompendium.Core
{
    public static class SubworldModConditions
    {
        internal static bool downedBereftVassal;
    }

    public class SubworldModConditionsPlayer : ModPlayer
    {
        public override void OnEnterWorld()
        {
            if (SubworldModConditions.downedBereftVassal || ModConditions.DownedBoss[(int)ModConditions.Downed.BereftVassal])
            {
                ModConditions.DownedBoss[(int)ModConditions.Downed.BereftVassal] = true;
            }
        }
    }
}
