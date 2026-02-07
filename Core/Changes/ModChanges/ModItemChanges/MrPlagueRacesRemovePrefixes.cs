using MrPlagueRaces;

namespace QoLCompendium.Core.Changes.ModChanges.ModItemChanges
{
    [ExtendsFromMod("MrPlagueRaces")]
    [JITWhenModsEnabled("MrPlagueRaces")]
    public class MrPlagueRacesRemovePrefixes : GlobalItem
    {
        private static int infiniteLoopHackFix;

        public override bool AllowPrefix(Item item, int pre)
        {
            if (!QoLCompendium.crossModConfig.MrPlagueRacesPrefixFix)
                return base.AllowPrefix(item, pre);

            HashSet<int> prefixes = new()
            {
                Common.GetModPrefix(CrossModSupport.MrPlagueRaces.Mod, "Accelerative"),
                Common.GetModPrefix(CrossModSupport.MrPlagueRaces.Mod, "Bewitched"),
                Common.GetModPrefix(CrossModSupport.MrPlagueRaces.Mod, "Bombarding"),
                Common.GetModPrefix(CrossModSupport.MrPlagueRaces.Mod, "Combustible"),
                Common.GetModPrefix(CrossModSupport.MrPlagueRaces.Mod, "Constructive"),
                Common.GetModPrefix(CrossModSupport.MrPlagueRaces.Mod, "Explosive"),
                Common.GetModPrefix(CrossModSupport.MrPlagueRaces.Mod, "Flawless"),
                Common.GetModPrefix(CrossModSupport.MrPlagueRaces.Mod, "Fortunate"),
                Common.GetModPrefix(CrossModSupport.MrPlagueRaces.Mod, "Hexed"),
                Common.GetModPrefix(CrossModSupport.MrPlagueRaces.Mod, "Immolating"),
                Common.GetModPrefix(CrossModSupport.MrPlagueRaces.Mod, "Impactful"),
                Common.GetModPrefix(CrossModSupport.MrPlagueRaces.Mod, "Luminescent"),
                Common.GetModPrefix(CrossModSupport.MrPlagueRaces.Mod, "Recreational"),
                Common.GetModPrefix(CrossModSupport.MrPlagueRaces.Mod, "Regenerative"),
                Common.GetModPrefix(CrossModSupport.MrPlagueRaces.Mod, "Reinforced"),
                Common.GetModPrefix(CrossModSupport.MrPlagueRaces.Mod, "Resilient"),
                Common.GetModPrefix(CrossModSupport.MrPlagueRaces.Mod, "Revitalizing"),
                Common.GetModPrefix(CrossModSupport.MrPlagueRaces.Mod, "Streamlined"),
                Common.GetModPrefix(CrossModSupport.MrPlagueRaces.Mod, "Trailblazing"),
                Common.GetModPrefix(CrossModSupport.MrPlagueRaces.Mod, "Tranquilizing"),
                Common.GetModPrefix(CrossModSupport.MrPlagueRaces.Mod, "Undying"),
                Common.GetModPrefix(CrossModSupport.MrPlagueRaces.Mod, "Volatile"),
                Common.GetModPrefix(CrossModSupport.MrPlagueRaces.Mod, "Warping")
            };

            if (!Main.gameMenu && Main.LocalPlayer.active && CrossModSupport.MrPlagueRaces.Loaded && !MrPlagueRacesConfig.Instance.raceStats)
            {
                if (prefixes.Contains(pre) && ++infiniteLoopHackFix < 30)
                    return false;
            }
            infiniteLoopHackFix = 0;
            return base.AllowPrefix(item, pre);
        }
    }
}