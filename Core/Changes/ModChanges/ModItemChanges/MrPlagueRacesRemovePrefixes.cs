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
                Common.GetModPrefix(ModConditions.mrPlagueRacesMod, "Accelerative"),
                Common.GetModPrefix(ModConditions.mrPlagueRacesMod, "Bewitched"),
                Common.GetModPrefix(ModConditions.mrPlagueRacesMod, "Bombarding"),
                Common.GetModPrefix(ModConditions.mrPlagueRacesMod, "Combustible"),
                Common.GetModPrefix(ModConditions.mrPlagueRacesMod, "Constructive"),
                Common.GetModPrefix(ModConditions.mrPlagueRacesMod, "Explosive"),
                Common.GetModPrefix(ModConditions.mrPlagueRacesMod, "Flawless"),
                Common.GetModPrefix(ModConditions.mrPlagueRacesMod, "Fortunate"),
                Common.GetModPrefix(ModConditions.mrPlagueRacesMod, "Hexed"),
                Common.GetModPrefix(ModConditions.mrPlagueRacesMod, "Immolating"),
                Common.GetModPrefix(ModConditions.mrPlagueRacesMod, "Impactful"),
                Common.GetModPrefix(ModConditions.mrPlagueRacesMod, "Luminescent"),
                Common.GetModPrefix(ModConditions.mrPlagueRacesMod, "Recreational"),
                Common.GetModPrefix(ModConditions.mrPlagueRacesMod, "Regenerative"),
                Common.GetModPrefix(ModConditions.mrPlagueRacesMod, "Reinforced"),
                Common.GetModPrefix(ModConditions.mrPlagueRacesMod, "Resilient"),
                Common.GetModPrefix(ModConditions.mrPlagueRacesMod, "Revitalizing"),
                Common.GetModPrefix(ModConditions.mrPlagueRacesMod, "Streamlined"),
                Common.GetModPrefix(ModConditions.mrPlagueRacesMod, "Trailblazing"),
                Common.GetModPrefix(ModConditions.mrPlagueRacesMod, "Tranquilizing"),
                Common.GetModPrefix(ModConditions.mrPlagueRacesMod, "Undying"),
                Common.GetModPrefix(ModConditions.mrPlagueRacesMod, "Volatile"),
                Common.GetModPrefix(ModConditions.mrPlagueRacesMod, "Warping")
            };

            if (!Main.gameMenu && Main.LocalPlayer.active && ModConditions.mrPlagueRacesLoaded && !MrPlagueRacesConfig.Instance.raceStats)
            {
                if (prefixes.Contains(pre) && ++infiniteLoopHackFix < 30)
                    return false;
            }
            infiniteLoopHackFix = 0;
            return base.AllowPrefix(item, pre);
        }
    }
}