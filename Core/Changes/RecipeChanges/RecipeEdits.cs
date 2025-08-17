using QoLCompendium.Content.Items.Accessories.InformationAccessories;
using QoLCompendium.Content.Items.Placeables.CraftingStations.CrossMod;
using QoLCompendium.Content.Items.Tools.Mirrors;
using QoLCompendium.Content.Items.Tools.PermanentBuffs.All;
using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.Catalyst;
using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.ThoriumBossRework;
using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.Calamity;
using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.CalamityEntropy;
using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.Clamity;
using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.MartinsOrder;
using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.SOTS;
using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.SpiritClassic;
using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.Thorium;
using QoLCompendium.Content.Items.Tools.Usables;
using ThoriumRework;

namespace QoLCompendium.Core.Changes.RecipeChanges
{
    public class RecipeEdits : ModSystem
    {
        [JITWhenModsEnabled("ThoriumRework")]
        public static bool ThoriumReworkPotionsEnabled => ModContent.GetInstance<CompatConfig>().extraPotions;

        public override void PostAddRecipes()
        {
            for (int i = 0; i < Main.recipe.Length; i++)
            {
                if (QoLCompendium.itemConfig.EndlessAmmo)
                {
                    if (Main.recipe[i].HasIngredient(ItemID.MusketBall) && Main.recipe[i].HasResult(ItemID.EndlessMusketPouch) && Main.recipe[i].HasTile(TileID.CrystalBall))
                    {
                        Main.recipe[i].RemoveTile(TileID.CrystalBall);
                        Main.recipe[i].AddTile(TileID.Solidifier);
                    }
                    if (Main.recipe[i].HasIngredient(ItemID.WoodenArrow) && Main.recipe[i].HasResult(ItemID.EndlessQuiver) && Main.recipe[i].HasTile(TileID.CrystalBall))
                    {
                        Main.recipe[i].RemoveTile(TileID.CrystalBall);
                        Main.recipe[i].AddTile(TileID.Solidifier);
                    }
                }

                if ((Main.recipe[i].HasIngredient(ModContent.ItemType<GoldenLockpick>()) || Main.recipe[i].HasIngredient(ItemID.ShadowKey)) && QoLCompendium.mainConfig.NonConsumableKeys)
                    Main.recipe[i].AddConsumeIngredientCallback(DontConsumeKeys);

                if (ModConditions.calamityLoaded && ModConditions.catalystLoaded)
                {
                    if (Main.recipe[i].HasResult(ModContent.ItemType<PermanentCalamity>()))
                        Main.recipe[i].AddIngredient(ModContent.ItemType<PermanentAstracola>());

                    if (Main.recipe[i].HasResult(ModContent.ItemType<CalamityCraftingMonolith>()))
                        Main.recipe[i].AddIngredient(Common.GetModItem(ModConditions.catalystMod, "AstralTransmogrifier"));
                }

                if (ModConditions.calamityLoaded && ModConditions.clamityAddonLoaded)
                {
                    if (Main.recipe[i].HasResult(ModContent.ItemType<PermanentCalamity>()))
                        Main.recipe[i].AddIngredient(ModContent.ItemType<PermanentClamity>());
                }

                if (ModConditions.calamityLoaded && ModConditions.calamityEntropyLoaded)
                {
                    if (Main.recipe[i].HasResult(ModContent.ItemType<PermanentCalamity>()))
                        Main.recipe[i].AddIngredient(ModContent.ItemType<PermanentCalamityEntropy>());

                    if (Main.recipe[i].HasResult(ModContent.ItemType<CalamityCraftingMonolith>()))
                        Main.recipe[i].AddIngredient(Common.GetModItem(ModConditions.calamityEntropyMod, "AbyssalAltar"));
                }

                if (ModConditions.thoriumLoaded && ModConditions.thoriumBossReworkLoaded && ThoriumReworkPotionsEnabled)
                {
                    if (Main.recipe[i].HasResult(ModContent.ItemType<PermanentThoriumBard>()))
                    {
                        Main.recipe[i].AddIngredient(ModContent.ItemType<PermanentDeathsinger>());
                        Main.recipe[i].AddIngredient(ModContent.ItemType<PermanentInspirationRegeneration>());
                    }
                }

                if (QoLCompendium.itemConfig.Mirrors && QoLCompendium.itemConfig.InformationAccessories)
                {
                    if (Main.recipe[i].HasResult(ModContent.ItemType<MosaicMirror>()))
                        Main.recipe[i].AddIngredient(ModContent.ItemType<IAH>());
                }

                #region Permanent Everything
                if (ModConditions.calamityLoaded)
                {
                    if (Main.recipe[i].HasResult(ModContent.ItemType<PermanentEverything>()))
                        Main.recipe[i].AddIngredient(ModContent.ItemType<PermanentCalamity>());
                }

                if (ModConditions.homewardJourneyLoaded)
                {
                    if (Main.recipe[i].HasResult(ModContent.ItemType<PermanentEverything>()))
                        Main.recipe[i].AddIngredient(ModContent.ItemType<PermanentHomewardJourney>());
                }

                if (ModConditions.martainsOrderLoaded)
                {
                    if (Main.recipe[i].HasResult(ModContent.ItemType<PermanentEverything>()))
                        Main.recipe[i].AddIngredient(ModContent.ItemType<PermanentMartinsOrder>());
                }

                if (ModConditions.secretsOfTheShadowsLoaded)
                {
                    if (Main.recipe[i].HasResult(ModContent.ItemType<PermanentEverything>()))
                        Main.recipe[i].AddIngredient(ModContent.ItemType<PermanentSecretsOfTheShadows>());
                }

                if (ModConditions.spiritLoaded)
                {
                    if (Main.recipe[i].HasResult(ModContent.ItemType<PermanentEverything>()))
                        Main.recipe[i].AddIngredient(ModContent.ItemType<PermanentSpiritClassic>());
                }

                if (ModConditions.thoriumLoaded)
                {
                    if (Main.recipe[i].HasResult(ModContent.ItemType<PermanentEverything>()))
                        Main.recipe[i].AddIngredient(ModContent.ItemType<PermanentThorium>());
                }
                #endregion
            }
        }

        public static void DontConsumeKeys(Recipe recipe, int type, ref int amount, bool isDecrafting)
        {
            if (type == ItemID.ShadowKey || type == ModContent.ItemType<GoldenLockpick>())
                amount = 0;
        }
    }
}
