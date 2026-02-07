using CalamityMod;
using CalamityMod.BiomeManagers;
using CalamityMod.Items.Placeables.Furniture.Fountains;
using MonoMod.RuntimeDetour;
using System.Reflection;

namespace QoLCompendium.Core.Changes.ModChanges.ModTileChanges
{
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    public class CalamityFountainChanges : ModSystem
    {
        public delegate bool Orig_AstralInfectionActive(AstralInfectionBiome self, Player player);

        public delegate bool Orig_BrimstoneCragsActive(BrimstoneCragsBiome self, Player player);

        public delegate bool Orig_SulphurousSeaActive(SulphurousSeaBiome self, Player player);

        public delegate bool Orig_SunkenSeaActive(SunkenSeaBiome self, Player player);

        private static readonly MethodInfo AstralInfectionActiveMethod = typeof(AstralInfectionBiome).GetMethod("IsBiomeActive", Common.UniversalBindingFlags);

        private static readonly MethodInfo BrimstoneCragsActiveMethod = typeof(BrimstoneCragsBiome).GetMethod("IsBiomeActive", Common.UniversalBindingFlags);

        private static readonly MethodInfo SulphurousSeaActiveMethod = typeof(SulphurousSeaBiome).GetMethod("IsBiomeActive", Common.UniversalBindingFlags);

        private static readonly MethodInfo SunkenSeaActiveMethod = typeof(SunkenSeaBiome).GetMethod("IsBiomeActive", Common.UniversalBindingFlags);

        public override void Load()
        {
            Hook astralInfection = new(AstralInfectionActiveMethod, new Func<Orig_AstralInfectionActive, AstralInfectionBiome, Player, bool>(AstralInfectionActive_Detour));
            astralInfection.Apply();
            Common.detours.Add(astralInfection);

            Hook brimstoneCrags = new(BrimstoneCragsActiveMethod, new Func<Orig_BrimstoneCragsActive, BrimstoneCragsBiome, Player, bool>(BrimstoneCragsActive_Detour));
            brimstoneCrags.Apply();
            Common.detours.Add(brimstoneCrags);

            Hook sulphurousSea = new(SulphurousSeaActiveMethod, new Func<Orig_SulphurousSeaActive, SulphurousSeaBiome, Player, bool>(SulphurousSeaActive_Detour));
            sulphurousSea.Apply();
            Common.detours.Add(sulphurousSea);

            Hook sunkenSea = new(SunkenSeaActiveMethod, new Func<Orig_SunkenSeaActive, SunkenSeaBiome, Player, bool>(SunkenSeaActive_Detour));
            sunkenSea.Apply();
            Common.detours.Add(sunkenSea);
        }

        internal static bool AstralInfectionActive_Detour(Orig_AstralInfectionActive orig, AstralInfectionBiome self, Player player)
        {
            bool result = orig(self, player);
            if (QoLCompendium.mainConfig.FountainsCauseBiomes && Main.SceneMetrics.ActiveFountainColor == ModContent.Find<ModWaterStyle>("CalamityMod/AstralWater").Slot)
            {
                return true;
            }
            if (QoLCompendium.mainConfig.FountainsWorkFromInventories && player.HasItemInAnyInventory(ModContent.ItemType<AstralFountainItem>()))
            {
                Main.SceneMetrics.ActiveFountainColor = ModContent.Find<ModWaterStyle>("CalamityMod/AstralWater").Slot;
                return true;
            }
            return result;
        }

        internal static bool BrimstoneCragsActive_Detour(Orig_BrimstoneCragsActive orig, BrimstoneCragsBiome self, Player player)
        {
            bool result = orig(self, player);
            if (QoLCompendium.mainConfig.FountainsCauseBiomes && player.Calamity().BrimstoneLavaFountainCounter > 0)
            {
                return true;
            }
            if (QoLCompendium.mainConfig.FountainsWorkFromInventories && player.HasItemInAnyInventory(ModContent.ItemType<BrimstoneLavaFountainItem>()))
            {
                player.Calamity().BrimstoneLavaFountainCounter = 1;
                return true;
            }
            return result;
        }

        internal static bool SulphurousSeaActive_Detour(Orig_SulphurousSeaActive orig, SulphurousSeaBiome self, Player player)
        {
            bool result = orig(self, player);
            string text = Main.zenithWorld ? "CalamityMod/PissWater" : "CalamityMod/SulphuricWater";
            if (QoLCompendium.mainConfig.FountainsCauseBiomes && Main.SceneMetrics.ActiveFountainColor == ModContent.Find<ModWaterStyle>(text).Slot)
            {
                return true;
            }
            if (QoLCompendium.mainConfig.FountainsWorkFromInventories && player.HasItemInAnyInventory(ModContent.ItemType<SulphurousFountainItem>()))
            {
                Main.SceneMetrics.ActiveFountainColor = ModContent.Find<ModWaterStyle>(text).Slot;
                return true;
            }
            return result;
        }

        internal static bool SunkenSeaActive_Detour(Orig_SunkenSeaActive orig, SunkenSeaBiome self, Player player)
        {
            bool result = orig(self, player);
            if (QoLCompendium.mainConfig.FountainsCauseBiomes && Main.SceneMetrics.ActiveFountainColor == ModContent.Find<ModWaterStyle>("CalamityMod/BasaltGullyWater").Slot)
            {
                return true;
            }
            if (QoLCompendium.mainConfig.FountainsWorkFromInventories && player.HasItemInAnyInventory(ModContent.ItemType<SunkenSeaFountain>()))
            {
                Main.SceneMetrics.ActiveFountainColor = ModContent.Find<ModWaterStyle>("CalamityMod/BasaltGullyWater").Slot;
                return true;
            }
            return result;
        }
    }
}
