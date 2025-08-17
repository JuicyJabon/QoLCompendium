using CrystalDragons.Content;

namespace QoLCompendium.Core.Changes.ModChanges
{
    [ExtendsFromMod("CrystalDragons")]
    [JITWhenModsEnabled("CrystalDragons")]
    public class CrystalDragonsRaceRemovePrefixes : GlobalItem
    {
        private static int infiniteLoopHackFix;

        public override bool AllowPrefix(Item item, int pre)
        {
            if (!QoLCompendium.crossModConfig.CrystalDragonsTopazPrefixFix)
                return base.AllowPrefix(item, pre);

            HashSet<int> prefixes = new()
            {
                Common.GetModPrefix(ModConditions.crystalDragonsMod, "TopazHardened"),
                Common.GetModPrefix(ModConditions.crystalDragonsMod, "TopazWarding"),
                Common.GetModPrefix(ModConditions.crystalDragonsMod, "TopazBulwark"),
                Common.GetModPrefix(ModConditions.crystalDragonsMod, "TopazGenin"),
                Common.GetModPrefix(ModConditions.crystalDragonsMod, "TopazShinobi"),
                Common.GetModPrefix(ModConditions.crystalDragonsMod, "TopazIai"),
                Common.GetModPrefix(ModConditions.crystalDragonsMod, "TopazDiverse"),
                Common.GetModPrefix(ModConditions.crystalDragonsMod, "TopazBalanced"),
                Common.GetModPrefix(ModConditions.crystalDragonsMod, "TopazEqualized"),
                Common.GetModPrefix(ModConditions.crystalDragonsMod, "TopazMartial"),
                Common.GetModPrefix(ModConditions.crystalDragonsMod, "TopazStriking"),
                Common.GetModPrefix(ModConditions.crystalDragonsMod, "TopazEviscerating"),
                Common.GetModPrefix(ModConditions.crystalDragonsMod, "TopazViolent"),
                Common.GetModPrefix(ModConditions.crystalDragonsMod, "TopazDestructive"),
                Common.GetModPrefix(ModConditions.crystalDragonsMod, "TopazAnnihilating"),
                Common.GetModPrefix(ModConditions.crystalDragonsMod, "TopazFit"),
                Common.GetModPrefix(ModConditions.crystalDragonsMod, "TopazStrong"),
                Common.GetModPrefix(ModConditions.crystalDragonsMod, "TopazMighty"),
                Common.GetModPrefix(ModConditions.crystalDragonsMod, "TopazBrisk"),
                Common.GetModPrefix(ModConditions.crystalDragonsMod, "TopazFleet"),
                Common.GetModPrefix(ModConditions.crystalDragonsMod, "TopazQuantum"),
                Common.GetModPrefix(ModConditions.crystalDragonsMod, "L A K E")
            };

            if (!Main.gameMenu && Main.LocalPlayer.active && ModConditions.mrPlagueRacesLoaded && !Main.LocalPlayer.GetModPlayer<CrystalDragonPlayer>().topaz)
            {
                if (prefixes.Contains(pre) && ++infiniteLoopHackFix < 30)
                    return false;
            }
            infiniteLoopHackFix = 0;
            return base.AllowPrefix(item, pre);
        }
    }
}