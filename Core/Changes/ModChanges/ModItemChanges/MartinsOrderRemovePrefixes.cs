using MartainsOrder.DamageClasses;

namespace QoLCompendium.Core.Changes.ModChanges.ModItemChanges
{
    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class MartinsOrderRemoveArtistPrefixes : GlobalItem
    {
        private static int infiniteLoopHackFix;

        public override bool AllowPrefix(Item item, int pre)
        {
            HashSet<int> prefixes =
            [
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "AbstractPrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "BoldPrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "DistortedPrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "DullPrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "DynamicPrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "EnigmaticPrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "ExpressivePrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "FinePrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "PlainPrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "PracticalPrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "ProfoundPrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "SketchyPrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "TraditionalPrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "UnevenPrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "VibrantPrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "WhimsicalPrefix")
            ];

            if (!Main.gameMenu && Main.LocalPlayer.active && !item.CountsAsClass(ModContent.GetInstance<ArtistClass>()))
            {
                if (prefixes.Contains(pre) && ++infiniteLoopHackFix < 30)
                    return false;
            }
            infiniteLoopHackFix = 0;
            return base.AllowPrefix(item, pre);
        }
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class MartinsOrderRemoveThrowerPrefixes : GlobalItem
    {
        private static int infiniteLoopHackFix;

        public override bool AllowPrefix(Item item, int pre)
        {
            HashSet<int> prefixes =
            [
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "AthleticPrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "CarelessPrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "DeliberatePrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "ErraticPrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "FlimsyPrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "OverarmPrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "UnderhandPrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "VigorousPrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "WeightedPrefix")
            ];

            if (!Main.gameMenu && Main.LocalPlayer.active && !item.CountsAsClass(DamageClass.Throwing))
            {
                if (prefixes.Contains(pre) && ++infiniteLoopHackFix < 30)
                    return false;
            }
            infiniteLoopHackFix = 0;
            return base.AllowPrefix(item, pre);
        }
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class MartinsOrderRemoveAccessoryPrefixes : GlobalItem
    {
        private static int infiniteLoopHackFix;

        public override bool AllowPrefix(Item item, int pre)
        {
            HashSet<int> prefixes =
            [
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "BouncyAccPrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "HappyAccPrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "HeartyAccPrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "HeavyAccPrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "MoldyAccPrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "StarryAccPrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "TeasingAccPrefix"),
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "ThrivingAccPrefix")
            ];

            if (!Main.gameMenu && Main.LocalPlayer.active && !item.accessory)
            {
                if (prefixes.Contains(pre) && ++infiniteLoopHackFix < 30)
                    return false;
            }
            infiniteLoopHackFix = 0;
            return base.AllowPrefix(item, pre);
        }
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class MartinsOrderRemoveToolPrefixes : GlobalItem
    {
        private static int infiniteLoopHackFix;

        public override bool AllowPrefix(Item item, int pre)
        {
            HashSet<int> prefixes =
            [
                Common.GetModPrefix(CrossModSupport.MartinsOrder.Mod, "LongerPrefix")
            ];

            if (!Main.gameMenu && Main.LocalPlayer.active && !item.IsATool())
            {
                if (prefixes.Contains(pre) && ++infiniteLoopHackFix < 30)
                    return false;
            }
            infiniteLoopHackFix = 0;
            return base.AllowPrefix(item, pre);
        }
    }
}
