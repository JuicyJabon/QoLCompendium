using CrystalDragons.Content;

namespace QoLCompendium.Core.Changes.ModChanges.ModItemChanges
{
    [ExtendsFromMod(CrossModSupport.CrystalDragonsRace.Name)]
    [JITWhenModsEnabled(CrossModSupport.CrystalDragonsRace.Name)]
    public class CrystalDragonsRaceRemovePrefixes : GlobalItem
    {
        private static int infiniteLoopHackFix;

        public override bool AllowPrefix(Item item, int pre)
        {
            if (!QoLCompendium.crossModConfig.CrystalDragonsTopazPrefixFix)
                return base.AllowPrefix(item, pre);

            HashSet<int> prefixes = new()
            {
                Common.GetModPrefix(CrossModSupport.CrystalDragonsRace.Mod, "TopazHardened"),
                Common.GetModPrefix(CrossModSupport.CrystalDragonsRace.Mod, "TopazWarding"),
                Common.GetModPrefix(CrossModSupport.CrystalDragonsRace.Mod, "TopazBulwark"),
                Common.GetModPrefix(CrossModSupport.CrystalDragonsRace.Mod, "TopazGenin"),
                Common.GetModPrefix(CrossModSupport.CrystalDragonsRace.Mod, "TopazShinobi"),
                Common.GetModPrefix(CrossModSupport.CrystalDragonsRace.Mod, "TopazIai"),
                Common.GetModPrefix(CrossModSupport.CrystalDragonsRace.Mod, "TopazDiverse"),
                Common.GetModPrefix(CrossModSupport.CrystalDragonsRace.Mod, "TopazBalanced"),
                Common.GetModPrefix(CrossModSupport.CrystalDragonsRace.Mod, "TopazEqualized"),
                Common.GetModPrefix(CrossModSupport.CrystalDragonsRace.Mod, "TopazMartial"),
                Common.GetModPrefix(CrossModSupport.CrystalDragonsRace.Mod, "TopazStriking"),
                Common.GetModPrefix(CrossModSupport.CrystalDragonsRace.Mod, "TopazEviscerating"),
                Common.GetModPrefix(CrossModSupport.CrystalDragonsRace.Mod, "TopazViolent"),
                Common.GetModPrefix(CrossModSupport.CrystalDragonsRace.Mod, "TopazDestructive"),
                Common.GetModPrefix(CrossModSupport.CrystalDragonsRace.Mod, "TopazAnnihilating"),
                Common.GetModPrefix(CrossModSupport.CrystalDragonsRace.Mod, "TopazFit"),
                Common.GetModPrefix(CrossModSupport.CrystalDragonsRace.Mod, "TopazStrong"),
                Common.GetModPrefix(CrossModSupport.CrystalDragonsRace.Mod, "TopazMighty"),
                Common.GetModPrefix(CrossModSupport.CrystalDragonsRace.Mod, "TopazBrisk"),
                Common.GetModPrefix(CrossModSupport.CrystalDragonsRace.Mod, "TopazFleet"),
                Common.GetModPrefix(CrossModSupport.CrystalDragonsRace.Mod, "TopazQuantum"),
                Common.GetModPrefix(CrossModSupport.CrystalDragonsRace.Mod, "L A K E")
            };

            if (!Main.gameMenu && Main.LocalPlayer.active && CrossModSupport.MrPlagueRaces.Loaded && !Main.LocalPlayer.GetModPlayer<CrystalDragonPlayer>().topaz)
            {
                if (prefixes.Contains(pre) && ++infiniteLoopHackFix < 30)
                    return false;
            }
            infiniteLoopHackFix = 0;
            return base.AllowPrefix(item, pre);
        }
    }
}