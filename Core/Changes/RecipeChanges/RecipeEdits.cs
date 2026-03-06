using QoLCompendium.Content.Items.Accessories.Informational;
using QoLCompendium.Content.Items.Placeables.CraftingStations;
using QoLCompendium.Content.Items.Placeables.CraftingStations.CrossMod.Calamity;
using QoLCompendium.Content.Items.Placeables.CraftingStations.CrossMod.HomewardJourney;
using QoLCompendium.Content.Items.Placeables.CraftingStations.CrossMod.MartinsOrder;
using QoLCompendium.Content.Items.Placeables.CraftingStations.CrossMod.Thorium;
using QoLCompendium.Content.Items.Tools.Mirrors;
using QoLCompendium.Content.Items.Tools.Usables;
using ThoriumRework;

namespace QoLCompendium.Core.Changes.RecipeChanges
{
    public class RecipeEdits : ModSystem
    {
        [JITWhenModsEnabled(CrossModSupport.ThoriumHelheim.Name)]
        public static bool ThoriumReworkPotionsEnabled => ModContent.GetInstance<CompatConfig>().extraPotions;

        public override void PostAddRecipes()
        {
            for (int i = 0; i < Main.recipe.Length; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (QoLCompendium.itemConfig.EndlessAmmo)
                {
                    if (recipe.HasIngredient(ItemID.MusketBall) && recipe.HasResult(ItemID.EndlessMusketPouch) && recipe.HasTile(TileID.CrystalBall))
                    {
                        recipe.RemoveTile(TileID.CrystalBall);
                        recipe.AddTile(TileID.Solidifier);
                    }
                    if (recipe.HasIngredient(ItemID.WoodenArrow) && recipe.HasResult(ItemID.EndlessQuiver) && recipe.HasTile(TileID.CrystalBall))
                    {
                        recipe.RemoveTile(TileID.CrystalBall);
                        recipe.AddTile(TileID.Solidifier);
                    }
                }

                if ((recipe.HasIngredient(ModContent.ItemType<GoldenLockpick>()) || recipe.HasIngredient(ItemID.ShadowKey)) && QoLCompendium.mainConfig.NonConsumableKeys)
                    recipe.AddConsumeIngredientCallback(DontConsumeKeys);

                if (CrossModSupport.Calamity.Loaded && CrossModSupport.Catalyst.Loaded)
                {
                    if (recipe.HasResult(ModContent.ItemType<HardmodeCalamityCraftingMonolith>()))
                        recipe.AddIngredient(Common.GetModItem(CrossModSupport.Catalyst.Mod, "AstralTransmogrifier"));
                }

                if (CrossModSupport.Calamity.Loaded && CrossModSupport.CalamityEntropy.Loaded)
                {
                    if (recipe.HasResult(ModContent.ItemType<CalamityCraftingMonolith>()))
                    {
                        recipe.AddIngredient(Common.GetModItem(CrossModSupport.CalamityEntropy.Mod, "AbyssalAltar"));
                        recipe.AddIngredient(Common.GetModItem(CrossModSupport.CalamityEntropy.Mod, "VoidWell"));
                    }
                }

                if (CrossModSupport.Calamity.Loaded && CrossModSupport.CalamityVanities.Loaded)
                {
                    if (recipe.HasResult(ModContent.ItemType<HardmodeCalamityCraftingMonolith>()))
                        recipe.AddIngredient(Common.GetModItem(CrossModSupport.CalamityVanities.Mod, "StarstruckSynthesizer"));

                    if (recipe.HasResult(ModContent.ItemType<CalamityCraftingMonolith>()))
                        recipe.AddIngredient(Common.GetModItem(CrossModSupport.CalamityVanities.Mod, "AuricManufacturer"));
                }

                if (QoLCompendium.itemConfig.Mirrors && QoLCompendium.itemConfig.InformationAccessories)
                {
                    if (recipe.HasResult(ModContent.ItemType<MosaicMirror>()))
                        recipe.AddIngredient(ModContent.ItemType<IAH>());
                }

                if (recipe.HasResult(Common.GetModItem(QoLCompendium.Instance, "PermanentTipsy")))
                {
                    recipe.RemoveIngredient(ItemID.Sake);
                    recipe.AddRecipeGroup("QoLCompendium:Ale", 30);
                }

                if (recipe.HasResult(Common.GetModItem(QoLCompendium.Instance, "PermanentCampfire")))
                {
                    recipe.RemoveIngredient(ItemID.Campfire);
                    recipe.AddRecipeGroup("QoLCompendium:AnyCampfire", 3);
                }

                if (recipe.HasResult(Common.GetModItem(QoLCompendium.Instance, "PermanentWellFed")))
                {
                    recipe.RemoveIngredient(ItemID.Apple);
                    recipe.AddRecipeGroup("QoLCompendium:WellFed", 30);
                }

                if (recipe.HasResult(Common.GetModItem(QoLCompendium.Instance, "PermanentPlentySatisfied")))
                {
                    recipe.RemoveIngredient(ItemID.LobsterTail);
                    recipe.AddRecipeGroup("QoLCompendium:PlentySatisfied", 30);
                }

                if (recipe.HasResult(Common.GetModItem(QoLCompendium.Instance, "PermanentExquisitelyStuffed")))
                {
                    recipe.RemoveIngredient(ItemID.GoldenDelight);
                    recipe.AddRecipeGroup("QoLCompendium:ExquisitelyStuffed", 30);
                }

                if (recipe.HasResult(Common.GetModItem(QoLCompendium.Instance, "PermanentLucky")))
                {
                    recipe.RemoveIngredient(ItemID.LuckPotionGreater);
                    recipe.AddIngredient(ItemID.LuckPotionLesser, 30);
                    recipe.AddIngredient(ItemID.LuckPotion, 20);
                    recipe.AddIngredient(ItemID.LuckPotionGreater, 10);
                }

                if (CrossModSupport.Calamity.Loaded)
                {
                    if (CrossModSupport.CalamityEntropy.Loaded)
                    {
                        if (recipe.HasResult(Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityDamage")))
                            recipe.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentSoyMilk"));

                        if (recipe.HasResult(Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityDefense")))
                            recipe.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentYharimsStimulants"));

                        if (recipe.HasResult(Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityArena")))
                            recipe.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentVoidCandle"));
                    }

                    if (CrossModSupport.CalamityRekindled.Loaded)
                    {
                        if (recipe.HasResult(Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityDamage")))
                        {
                            recipe.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentBeetleJuice"));
                            recipe.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentPenumbra"));
                            recipe.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentProfanedRage"));
                            recipe.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentProfanedWrath"));
                            recipe.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentShattering"));
                        }

                        if (recipe.HasResult(Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityDefense")))
                        {
                            recipe.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentCadence"));
                            recipe.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentDraconicElixir"));
                            recipe.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentRevivify"));
                            recipe.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentCRTitanScale"));
                            recipe.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentTriumph"));
                            recipe.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentCRYharimsStimulants"));
                        }
                    }

                    if (CrossModSupport.Catalyst.Loaded && recipe.HasResult(Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityDamage")))
                    {
                        recipe.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentAstracola"));
                    }

                    if (CrossModSupport.Clamity.Loaded)
                    {
                        if (recipe.HasResult(Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityDamage")))
                            recipe.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentSupremeLuck"));

                        if (recipe.HasResult(Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityDefense")))
                        {
                            recipe.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentTitanScale"));
                            recipe.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentExoBaguette"));
                        }
                    }

                    if (CrossModSupport.DraedonExpansion.Loaded && recipe.HasResult(Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityFlasks")))
                    {
                        recipe.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskOfElectricity"));
                    }

                    if (CrossModSupport.WrathOfTheGods.Loaded && recipe.HasResult(Common.GetModItem(QoLCompendium.Instance, "PermanentCalamityDefense")))
                    {
                        recipe.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentStarstrikinglySatiated"));
                    }
                }

                if (CrossModSupport.MartinsOrder.Loaded)
                {
                    if (recipe.HasResult(Common.GetModItem(QoLCompendium.Instance, "PermanentGourmetFlavor")))
                    {
                        recipe.RemoveIngredient(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "FastFood"));
                        recipe.AddRecipeGroup("QoLCompendium:GourmetFlavor", 30);
                    }
                }

                if (CrossModSupport.SpiritReforged.Loaded)
                {
                    if (recipe.HasResult(Common.GetModItem(QoLCompendium.Instance, "PermanentSRKoiTotem")))
                    {
                        recipe.RemoveIngredient(Common.GetModItem(CrossModSupport.SpiritReforged.Mod, "KoiTotem"));
                        recipe.AddRecipeGroup("QoLCompendium:KoiTotem", 3);
                    }
                }

                if (CrossModSupport.Thorium.Loaded && CrossModSupport.ThoriumHelheim.Loaded)
                {
                    if (recipe.HasResult(Common.GetModItem(QoLCompendium.Instance, "PermanentThoriumBard")) && ThoriumReworkPotionsEnabled)
                    {
                        if (!CrossModSupport.InfernalEclipse.Loaded)
                            recipe.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentDeathsinger"));
                        recipe.AddIngredient(Common.GetModItem(QoLCompendium.Instance, "PermanentInspirationRegeneration"));
                    }
                }

                #region Ultimate Crafting Monolith
                if (CrossModSupport.Calamity.Loaded)
                {
                    if (recipe.HasResult(ModContent.ItemType<UltimateCraftingMonolith>()))
                        recipe.AddIngredient(ModContent.ItemType<CalamityCraftingMonolith>());
                }
                if (CrossModSupport.HomewardJourney.Loaded)
                {
                    if (recipe.HasResult(ModContent.ItemType<UltimateCraftingMonolith>()))
                        recipe.AddIngredient(ModContent.ItemType<HomewardJourneyCraftingMonolith>());
                }
                if (CrossModSupport.MartinsOrder.Loaded)
                {
                    if (recipe.HasResult(ModContent.ItemType<UltimateCraftingMonolith>()))
                        recipe.AddIngredient(ModContent.ItemType<MartinsOrderCraftingMonolith>());
                }
                if (CrossModSupport.Thorium.Loaded)
                {
                    if (recipe.HasResult(ModContent.ItemType<UltimateCraftingMonolith>()))
                        recipe.AddIngredient(ModContent.ItemType<ThoriumCraftingMonolith>());
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
