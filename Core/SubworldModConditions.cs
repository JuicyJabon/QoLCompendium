namespace QoLCompendium.Core
{
    public static class SubworldModConditions
    {
        public static bool downedBereftVassal;
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
