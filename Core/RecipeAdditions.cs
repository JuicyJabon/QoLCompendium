using QoLCompendium.Content.Items.Accessories.InformationAccessories;
using QoLCompendium.Content.Items.Placeables.CraftingStations;
using QoLCompendium.Content.Items.Placeables.Pylons;
using QoLCompendium.Content.Items.Tools.Mirrors;
using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.Catalyst;
using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.ThoriumBossRework;
using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.Calamity;
using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.Clamity;
using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.Thorium;
using QoLCompendium.Content.Items.Tools.Usables;
using QoLCompendium.Content.Tiles.CraftingStations;
using System.Text.RegularExpressions;
using ThoriumRework;
using static QoLCompendium.Core.Common;


namespace QoLCompendium.Core
{
    public class RecipeAdditions : ModSystem
    {
        public static readonly Regex chestItemRegex = new(@"\b(?!fake_)(.*chest)\b", RegexOptions.Compiled);
        public static readonly Regex workBenchItemRegex = new(@"\b(.*workbench)\b", RegexOptions.Compiled);
        public static readonly Regex sinkItemRegex = new(@"\b(.*sink)(?:does)?\b", RegexOptions.Compiled);
        public static readonly Regex tableItemRegex = new(@"\b(.*table)(?:withcloth)?\b", RegexOptions.Compiled);
        public static readonly Regex chairItemRegex = new(@"\b(.*chair)\b", RegexOptions.Compiled);
        public static readonly Regex bookcaseItemRegex = new(@"\b(.*bookcase)\b", RegexOptions.Compiled);
        public static readonly Regex campfireItemRegex = new(@"\b(.*campfire)\b", RegexOptions.Compiled);

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

                if (Main.recipe[i].HasIngredient(ModContent.ItemType<GoldenLockpick>()) && QoLCompendium.mainConfig.NonConsumableKeys)
                {
                    Main.recipe[i].AddConsumeIngredientCallback((Recipe recipe, int type, ref int amount, bool isDecrafting) => {
                        if (type == ModContent.ItemType<GoldenLockpick>())
                            amount = 0;
                    });
                }

                if (Main.recipe[i].HasIngredient(ItemID.ShadowKey) && QoLCompendium.mainConfig.NonConsumableKeys)
                {
                    Main.recipe[i].AddConsumeIngredientCallback((Recipe recipe, int type, ref int amount, bool isDecrafting) => {
                        if (type == ItemID.ShadowKey)
                            amount = 0;
                    });
                }

                if (ModConditions.calamityLoaded && ModConditions.catalystLoaded)
                {
                    if (Main.recipe[i].HasResult(ModContent.ItemType<PermanentCalamity>()))
                        Main.recipe[i].AddIngredient(ModContent.ItemType<PermanentAstracola>());
                }

                if (ModConditions.calamityLoaded && ModConditions.clamityAddonLoaded)
                {
                    if (Main.recipe[i].HasResult(ModContent.ItemType<PermanentCalamity>()))
                        Main.recipe[i].AddIngredient(ModContent.ItemType<PermanentClamity>());
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
            }
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.mainConfig.FullyDisableRecipes)
                return;

            //Aether Altar Recipe Creation
            for (int i = 0; i < ItemLoader.ItemCount; i++)
            {
                if (ItemID.Sets.ShimmerTransformToItem[i] > ItemID.None)
                {
                    Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.CraftingStations, ItemID.Sets.ShimmerTransformToItem[i], 1, "Mods.QoLCompendium.ItemToggledConditions.CraftingStations");
                    r.AddIngredient(i);
                    r.AddTile(ModContent.TileType<AetherAltarTile>());
                    r.Register();
                }
            }
            
            //Prime Rework / Confection Fix
            if (ModConditions.confectionRebakedLoaded && ModConditions.mechReworkLoaded)
            {
                Recipe deathsRaze = Recipe.Create(Common.GetModItem(ModConditions.confectionRebakedMod, "DeathsRaze"), 1);
                deathsRaze.AddIngredient(ItemID.BloodButcherer);
                deathsRaze.AddIngredient(ItemID.Muramasa);
                deathsRaze.AddIngredient(ItemID.BladeofGrass);
                deathsRaze.AddIngredient(ItemID.FieryGreatsword);
                deathsRaze.AddTile(TileID.DemonAltar);
                deathsRaze.Register();

                if (ModConditions.depthsLoaded)
                {
                    Recipe deathsRaze2 = Recipe.Create(Common.GetModItem(ModConditions.confectionRebakedMod, "DeathsRaze"), 1);
                    deathsRaze2.AddIngredient(ItemID.BloodButcherer);
                    deathsRaze2.AddIngredient(ItemID.Muramasa);
                    deathsRaze2.AddIngredient(ItemID.BladeofGrass);
                    deathsRaze2.AddIngredient(Common.GetModItem(ModConditions.depthsMod, "Terminex"));
                    deathsRaze2.AddTile(TileID.DemonAltar);
                    deathsRaze2.Register();
                }
            }

            //Calamity Effigy Recipes
            if (ModConditions.calamityLoaded)
            {
                Recipe crimsonEffigy = Recipe.Create(Common.GetModItem(ModConditions.calamityMod, "CrimsonEffigy"), 1);
                crimsonEffigy.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "BloodSample"), 10);
                crimsonEffigy.AddIngredient(ItemID.Vertebrae, 10);
                crimsonEffigy.AddIngredient(ItemID.CrimtaneBar, 6);
                crimsonEffigy.AddTile(TileID.DemonAltar);
                crimsonEffigy.Register();

                Recipe corruptionEffigy = Recipe.Create(Common.GetModItem(ModConditions.calamityMod, "CorruptionEffigy"), 1);
                corruptionEffigy.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "RottenMatter"), 10);
                corruptionEffigy.AddIngredient(ItemID.RottenChunk, 10);
                corruptionEffigy.AddIngredient(ItemID.DemoniteBar, 6);
                corruptionEffigy.AddTile(TileID.DemonAltar);
                corruptionEffigy.Register();
            }

            //Major Recipe Creation
            ConversionRecipes();
            CrateRecipes();
            BagRecipes();
            BannerRecipes();
            GrabBagRecipes();

            //Mobile Storage Parity
            if (!QoLCompendium.itemConfig.DisableModdedItems)
                Common.CreateSimpleRecipe(ItemID.PiggyBank, ItemID.MoneyTrough, TileID.Anvils, 1, 1, false, false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.MobileStorages", () => QoLCompendium.itemConfig.MobileStorages));

            //Golden Delight With Golden Carp
            Common.CreateSimpleRecipe(ItemID.GoldenCarp, ItemID.GoldenDelight, TileID.CookingPots, 1, 1, false, false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.RecipeEnabled", () => QoLCompendium.mainConfig.GoldenCarpDelight));

            //Easier Universal Pylon
            Recipe universalPylon = ModConditions.GetItemRecipe(() => QoLCompendium.mainConfig.EasierUniversalPylon, ItemID.TeleportationPylonVictory, 1, "Mods.QoLCompendium.ItemToggledConditions.Pylons");
            universalPylon.AddIngredient(ItemID.TeleportationPylonUnderground);
            universalPylon.AddIngredient(ItemID.TeleportationPylonDesert);
            universalPylon.AddIngredient(ItemID.TeleportationPylonPurity);
            universalPylon.AddIngredient(ItemID.TeleportationPylonHallow);
            universalPylon.AddIngredient(ItemID.TeleportationPylonJungle);
            universalPylon.AddIngredient(ItemID.TeleportationPylonMushroom);
            universalPylon.AddIngredient(ItemID.TeleportationPylonOcean);
            universalPylon.AddIngredient(ItemID.TeleportationPylonSnow);
            if (!QoLCompendium.itemConfig.DisableModdedItems)
            {
                universalPylon.AddIngredient(ModContent.ItemType<AetherPylon>());
                universalPylon.AddIngredient(ModContent.ItemType<CorruptionPylon>());
                universalPylon.AddIngredient(ModContent.ItemType<CrimsonPylon>());
                universalPylon.AddIngredient(ModContent.ItemType<DungeonPylon>());
                universalPylon.AddIngredient(ModContent.ItemType<SkyPylon>());
                universalPylon.AddIngredient(ModContent.ItemType<TemplePylon>());
                universalPylon.AddIngredient(ModContent.ItemType<HellPylon>());
            }
            universalPylon.AddTile(TileID.Anvils);
            universalPylon.Register();
        }

        public static void ConversionRecipes()
        {
            //Conversion Recipe Creation
            //Ores
            Common.ConversionRecipe(ItemID.CopperOre, ItemID.TinOre, TileID.Anvils);
            Common.ConversionRecipe(ItemID.IronOre, ItemID.LeadOre, TileID.Anvils);
            Common.ConversionRecipe(ItemID.SilverOre, ItemID.TungstenOre, TileID.Anvils);
            Common.ConversionRecipe(ItemID.GoldOre, ItemID.PlatinumOre, TileID.Anvils);
            Common.ConversionRecipe(ItemID.DemoniteOre, ItemID.CrimtaneOre, TileID.Anvils);
            Common.ConversionRecipe(ItemID.CobaltOre, ItemID.PalladiumOre, TileID.Anvils);
            Common.ConversionRecipe(ItemID.MythrilOre, ItemID.OrichalcumOre, TileID.MythrilAnvil);
            Common.ConversionRecipe(ItemID.AdamantiteOre, ItemID.TitaniumOre, TileID.MythrilAnvil);
            //Bars
            Common.ConversionRecipe(ItemID.CopperBar, ItemID.TinBar, TileID.Anvils);
            Common.ConversionRecipe(ItemID.IronBar, ItemID.LeadBar, TileID.Anvils);
            Common.ConversionRecipe(ItemID.SilverBar, ItemID.TungstenBar, TileID.Anvils);
            Common.ConversionRecipe(ItemID.GoldBar, ItemID.PlatinumBar, TileID.Anvils);
            Common.ConversionRecipe(ItemID.DemoniteBar, ItemID.CrimtaneBar, TileID.Anvils);
            Common.ConversionRecipe(ItemID.CobaltBar, ItemID.PalladiumBar, TileID.Anvils);
            Common.ConversionRecipe(ItemID.MythrilBar, ItemID.OrichalcumBar, TileID.MythrilAnvil);
            Common.ConversionRecipe(ItemID.AdamantiteBar, ItemID.TitaniumBar, TileID.MythrilAnvil);
            //Materials
            Common.ConversionRecipe(ItemID.RottenChunk, ItemID.Vertebrae, TileID.Anvils);
            Common.ConversionRecipe(ItemID.ShadowScale, ItemID.TissueSample, TileID.Anvils);
            Common.ConversionRecipe(ItemID.CursedFlame, ItemID.Ichor, TileID.Anvils);
            Common.ConversionRecipe(ItemID.SoulofNight, ItemID.SoulofLight, TileID.Anvils);
            Common.ConversionRecipe(ItemID.VileMushroom, ItemID.ViciousMushroom, TileID.Anvils);
            Common.ConversionRecipe(ItemID.Ebonkoi, ItemID.Hemopiranha, TileID.Anvils);
            Common.ConversionRecipe(ItemID.Ebonkoi, ItemID.CrimsonTigerfish, TileID.Anvils);
            Common.ConversionRecipe(ItemID.DarkShard, ItemID.LightShard, TileID.Anvils);
            Common.CreateSimpleRecipe(ItemID.SoulofFright, ItemID.SoulofMight, TileID.MythrilAnvil, 1, 1, false, false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.ItemConversions", () => QoLCompendium.mainConfig.ItemConversions), Condition.DownedMechBossAll);
            Common.CreateSimpleRecipe(ItemID.SoulofMight, ItemID.SoulofSight, TileID.MythrilAnvil, 1, 1, false, false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.ItemConversions", () => QoLCompendium.mainConfig.ItemConversions), Condition.DownedMechBossAll);
            Common.CreateSimpleRecipe(ItemID.SoulofSight, ItemID.SoulofFright, TileID.MythrilAnvil, 1, 1, false, false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.ItemConversions", () => QoLCompendium.mainConfig.ItemConversions), Condition.DownedMechBossAll);
            //Blocks
            Common.ConversionRecipe(ItemID.Ebonwood, ItemID.Shadewood, TileID.Anvils);
            Common.ConversionRecipe(ItemID.EbonstoneBlock, ItemID.CrimstoneBlock, TileID.Anvils);
            Common.ConversionRecipe(ItemID.EbonsandBlock, ItemID.CrimsandBlock, TileID.Anvils);
            Common.ConversionRecipe(ItemID.CorruptSandstone, ItemID.CrimsonSandstone, TileID.Anvils);
            Common.ConversionRecipe(ItemID.CorruptHardenedSand, ItemID.CrimsonHardenedSand, TileID.Anvils);
            Common.ConversionRecipe(ItemID.PurpleIceBlock, ItemID.RedIceBlock, TileID.Anvils);
            Common.ConversionRecipe(ItemID.CorruptSeeds, ItemID.CrimsonSeeds, TileID.Anvils);
            //Tiles
            Common.ConversionRecipe(ItemID.CorruptFishingCrate, ItemID.CrimsonFishingCrate, TileID.Anvils);
            Common.ConversionRecipe(ItemID.CorruptFishingCrateHard, ItemID.CrimsonFishingCrateHard, TileID.Anvils);
            //Weapons
            Common.ConversionRecipe(ItemID.Terragrim, ItemID.Arkhalis, TileID.CrystalBall);
            Common.ConversionRecipe(ItemID.DartRifle, ItemID.DartPistol, TileID.Anvils);
            Common.ConversionRecipe(ItemID.ClingerStaff, ItemID.SoulDrain, TileID.Anvils);
            Common.ConversionRecipe(ItemID.ChainGuillotines, ItemID.FetidBaghnakhs, TileID.Anvils);
            //Equipables
            Common.ConversionRecipe(ItemID.PutridScent, ItemID.FleshKnuckles, TileID.Anvils);
            Common.ConversionRecipe(ItemID.WormHook, ItemID.TendonHook, TileID.Anvils);
            Common.ConversionRecipe(ItemID.EatersBone, ItemID.BoneRattle, TileID.Anvils);
            //Misc
            Common.ConversionRecipe(ItemID.CorruptionKey, ItemID.CrimsonKey, TileID.MythrilAnvil);

            #region Calamity
            if (ModConditions.calamityLoaded)
            {
                Common.ConversionRecipe(Common.GetModItem(ModConditions.calamityMod, "RottenMatter"), Common.GetModItem(ModConditions.calamityMod, "BloodSample"), TileID.DemonAltar);
                Common.ConversionRecipe(Common.GetModItem(ModConditions.calamityMod, "FilthyGlove"), Common.GetModItem(ModConditions.calamityMod, "BloodstainedGlove"), TileID.DemonAltar);
                Common.ConversionRecipe(Common.GetModItem(ModConditions.calamityMod, "RottenBrain"), Common.GetModItem(ModConditions.calamityMod, "BloodyWormTooth"), TileID.DemonAltar);
                Common.ConversionRecipe(Common.GetModItem(ModConditions.calamityMod, "RottingEyeball"), Common.GetModItem(ModConditions.calamityMod, "BloodyVein"), TileID.DemonAltar);
                Common.ConversionRecipe(Common.GetModItem(ModConditions.calamityMod, "CorruptionEffigy"), Common.GetModItem(ModConditions.calamityMod, "CrimsonEffigy"), TileID.DemonAltar);
            }
            #endregion

            #region Confection
            if (ModConditions.confectionRebakedLoaded)
            {
                //Common.ConversionRecipe(Common.GetModItem(ModConditions.confectionRebakedMod, ""), Common.GetModItem(ModConditions.confectionRebakedMod, ""), TileID.Anvils);
            }
            #endregion

            #region Depths
            if (ModConditions.depthsLoaded)
            {
                Common.ConversionRecipe(Common.GetModItem(ModConditions.depthsMod, "ShadowShrub"), ItemID.Fireblossom, TileID.Anvils);
                Common.ConversionRecipe(Common.GetModItem(ModConditions.depthsMod, "ShadowShrubSeeds"), ItemID.FireblossomSeeds, TileID.Anvils);
                Common.ConversionRecipe(Common.GetModItem(ModConditions.depthsMod, "ShadowShrubPlanterBox"), ItemID.FireBlossomPlanterBox, TileID.Anvils);
                Common.ConversionRecipe(Common.GetModItem(ModConditions.depthsMod, "Quartz"), ItemID.Obsidian, TileID.Anvils);
                Common.ConversionRecipe(Common.GetModItem(ModConditions.depthsMod, "ArqueriteOre"), ItemID.Hellstone, TileID.Anvils);
                Common.ConversionRecipe(Common.GetModItem(ModConditions.depthsMod, "QuartzCrate"), ItemID.LavaCrate, TileID.Anvils);
                Common.ConversionRecipe(Common.GetModItem(ModConditions.depthsMod, "ArqueriteCrate"), ItemID.LavaCrateHard, TileID.Anvils);
                Common.ConversionRecipe(Common.GetModItem(ModConditions.depthsMod, "ShadowFightingFish"), ItemID.FlarefinKoi, TileID.Anvils);
                Common.ConversionRecipe(Common.GetModItem(ModConditions.depthsMod, "QuartzFeeder"), ItemID.Obsidifish, TileID.Anvils);

                Common.ConversionRecipe(Common.GetModItem(ModConditions.depthsMod, "LodeStone"), ItemID.TreasureMagnet, TileID.Anvils);
                Common.ConversionRecipe(Common.GetModItem(ModConditions.depthsMod, "StoneRose"), ItemID.ObsidianRose, TileID.Anvils);
                Common.ConversionRecipe(Common.GetModItem(ModConditions.depthsMod, "AmalgamAmulet"), ItemID.LavaCharm, TileID.Anvils);
                Common.ConversionRecipe(Common.GetModItem(ModConditions.depthsMod, "CrystalSkull"), ItemID.ObsidianSkull, TileID.Anvils);
                Common.ConversionRecipe(Common.GetModItem(ModConditions.depthsMod, "QuicksilverproofFishingHook"), ItemID.LavaFishingHook, TileID.Anvils);
                Common.ConversionRecipe(Common.GetModItem(ModConditions.depthsMod, "QuicksilverproofTackleBag"), ItemID.LavaproofTackleBag, TileID.Anvils);
                Common.ConversionRecipe(Common.GetModItem(ModConditions.depthsMod, "PalladiumShield"), ItemID.CobaltShield, TileID.Anvils);

                Common.ConversionRecipe(Common.GetModItem(ModConditions.depthsMod, "CrystalCrown"), Common.GetModItem(ModConditions.depthsMod, "CharredCrown"), TileID.Anvils);

                Common.ConversionRecipe(Common.GetModItem(ModConditions.depthsMod, "WhiteLightning"), ItemID.Flamelash, TileID.Anvils);
                Common.ConversionRecipe(Common.GetModItem(ModConditions.depthsMod, "Skyfall"), ItemID.Cascade, TileID.Anvils);
                Common.ConversionRecipe(Common.GetModItem(ModConditions.depthsMod, "BlueSphere"), ItemID.HelFire, TileID.Anvils);
                Common.ConversionRecipe(Common.GetModItem(ModConditions.depthsMod, "SilverStar"), ItemID.Sunfury, TileID.Anvils);
                Common.ConversionRecipe(Common.GetModItem(ModConditions.depthsMod, "NightFury"), ItemID.HellwingBow, TileID.Anvils);
                Common.ConversionRecipe(Common.GetModItem(ModConditions.depthsMod, "ShadowSphere"), ItemID.DemonScythe, TileID.Anvils);
                Common.ConversionRecipe(Common.GetModItem(ModConditions.depthsMod, "Steelocanth"), ItemID.ObsidianSwordfish, TileID.Anvils);

                Common.ConversionRecipe(Common.GetModItem(ModConditions.depthsMod, "ChasmeBag"), ItemID.WallOfFleshBossBag, TileID.Anvils);
            }
            #endregion
        }

        public static void BagRecipes()
        {
            //Bag Recipe Creation
            Common.CreateBagRecipe(Common.kingSlimeDrops, ItemID.KingSlimeBossBag);
            Common.CreateBagRecipe(Common.eyeOfCthulhuDrops, ItemID.EyeOfCthulhuBossBag);
            Common.CreateBagRecipe(Common.eaterOfWorldsDrops, ItemID.EaterOfWorldsBossBag);
            Common.CreateBagRecipe(Common.brainOfCthulhuDrops, ItemID.BrainOfCthulhuBossBag);
            Common.CreateBagRecipe(Common.queenBeeDrops, ItemID.QueenBeeBossBag);
            Common.CreateBagRecipe(Common.deerclopsDrops, ItemID.DeerclopsBossBag);
            Common.CreateBagRecipe(Common.skeletronDrops, ItemID.SkeletronBossBag);
            Common.CreateBagRecipe(Common.wallOfFleshDrops, ItemID.WallOfFleshBossBag);
            Common.CreateBagRecipe(Common.queenSlimeDrops, ItemID.QueenSlimeBossBag);
            Common.CreateBagRecipe(Common.planteraDrops, ItemID.PlanteraBossBag);
            Common.CreateBagRecipe(Common.golemDrops, ItemID.GolemBossBag);
            Common.CreateBagRecipe(Common.betsyDrops, ItemID.BossBagBetsy);
            Common.CreateBagRecipe(Common.dukeFishronDrops, ItemID.FishronBossBag);
            Common.CreateBagRecipe(Common.empressOfLightDrops, ItemID.FairyQueenBossBag);
            Common.CreateBagRecipe(Common.moonLordDrops, ItemID.MoonLordBossBag);
        }

        public static void CrateRecipes()
        {
            //Crate Recipe Creation
            #region Vanilla
            //Wooden Crate
            Common.CreateCrateRecipe(ItemID.SailfishBoots, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.TsunamiInABottle, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.Aglet, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.PortableStool, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.ClimbingClaws, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.CordageGuide, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.Radar, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            Common.CreateCrateHardmodeRecipe(ItemID.Anchor, ItemID.WoodenCrateHard, 1);
            //Wooden Chest Loot
            Common.CreateCrateRecipe(ItemID.Spear, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.Blowpipe, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.WoodenBoomerang, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.Umbrella, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.WandofSparking, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1, Condition.NotRemixWorld, Condition.NotZenithWorld);
            Common.CreateCrateRecipe(ItemID.LivingWoodWand, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.LeafWand, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.BabyBirdStaff, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.SunflowerMinecart, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.LadybugMinecart, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);

            //Iron Crate
            Common.CreateCrateRecipe(ItemID.FalconBlade, ItemID.IronCrate, ItemID.IronCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.TartarSauce, ItemID.IronCrate, ItemID.IronCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.GingerBeard, ItemID.IronCrate, ItemID.IronCrateHard, 1);

            //Golden Crate
            Common.CreateCrateRecipe(ItemID.HardySaddle, ItemID.GoldenCrate, ItemID.GoldenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.EnchantedSword, ItemID.GoldenCrate, ItemID.GoldenCrateHard, 1);
            //Golden Chest Loot
            Common.CreateCrateRecipe(ItemID.BandofRegeneration, ItemID.GoldenCrate, ItemID.GoldenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.MagicMirror, ItemID.GoldenCrate, ItemID.GoldenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.CloudinaBottle, ItemID.GoldenCrate, ItemID.GoldenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.HermesBoots, ItemID.GoldenCrate, ItemID.GoldenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.Mace, ItemID.GoldenCrate, ItemID.GoldenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.ShoeSpikes, ItemID.GoldenCrate, ItemID.GoldenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.FlareGun, ItemID.GoldenCrate, ItemID.GoldenCrateHard, 1);

            //Jungle Crate
            Common.CreateCrateRecipe(ItemID.FlowerBoots, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.AnkletoftheWind, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.Boomstick, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.FeralClaws, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.StaffofRegrowth, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.FiberglassFishingPole, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.Seaweed, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 1);
            //Ivy Chest Loot
            Common.CreateCrateRecipe(ItemID.LivingMahoganyWand, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.LivingMahoganyLeafWand, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.BeeMinecart, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 1);

            //Sky Crate
            Common.CreateCrateRecipe(ItemID.Starfury, ItemID.FloatingIslandFishingCrate, ItemID.FloatingIslandFishingCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.LuckyHorseshoe, ItemID.FloatingIslandFishingCrate, ItemID.FloatingIslandFishingCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.ShinyRedBalloon, ItemID.FloatingIslandFishingCrate, ItemID.FloatingIslandFishingCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.CelestialMagnet, ItemID.FloatingIslandFishingCrate, ItemID.FloatingIslandFishingCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.CreativeWings, ItemID.FloatingIslandFishingCrate, ItemID.FloatingIslandFishingCrateHard, 1);

            //Frozen Crate
            Common.CreateCrateRecipe(ItemID.IceBoomerang, ItemID.FrozenCrate, ItemID.FrozenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.IceBlade, ItemID.FrozenCrate, ItemID.FrozenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.IceSkates, ItemID.FrozenCrate, ItemID.FrozenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.SnowballCannon, ItemID.FrozenCrate, ItemID.FrozenCrateHard, 1, Condition.NotRemixWorld, Condition.NotZenithWorld);
            Common.CreateCrateRecipe(ItemID.BlizzardinaBottle, ItemID.FrozenCrate, ItemID.FrozenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.FlurryBoots, ItemID.FrozenCrate, ItemID.FrozenCrateHard, 1);

            //Oasis Crate
            Common.CreateCrateRecipe(ItemID.AncientChisel, ItemID.OasisCrate, ItemID.OasisCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.ScarabFishingRod, ItemID.OasisCrate, ItemID.OasisCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.SandBoots, ItemID.OasisCrate, ItemID.OasisCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.ThunderSpear, ItemID.OasisCrate, ItemID.OasisCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.ThunderStaff, ItemID.OasisCrate, ItemID.OasisCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.MysticCoilSnake, ItemID.OasisCrate, ItemID.OasisCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.MagicConch, ItemID.OasisCrate, ItemID.OasisCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.SandstorminaBottle, ItemID.OasisCrate, ItemID.OasisCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.PharaohsMask, ItemID.OasisCrate, ItemID.OasisCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.PharaohsRobe, ItemID.OasisCrate, ItemID.OasisCrateHard, 1);

            //Corrupt Crate
            Common.CreateCrateRecipe(ItemID.BallOHurt, ItemID.CorruptFishingCrate, ItemID.CorruptFishingCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.BandofStarpower, ItemID.CorruptFishingCrate, ItemID.CorruptFishingCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.Musket, ItemID.CorruptFishingCrate, ItemID.CorruptFishingCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.ShadowOrb, ItemID.CorruptFishingCrate, ItemID.CorruptFishingCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.Vilethorn, ItemID.CorruptFishingCrate, ItemID.CorruptFishingCrateHard, 1);
            //Other
            Common.CreateCrateRecipe(ItemID.PurpleClubberfish, ItemID.CorruptFishingCrate, ItemID.CorruptFishingCrateHard, 1);
            Common.CreateCrateHardmodeRecipe(ItemID.Toxikarp, ItemID.CorruptFishingCrateHard, 1);

            //Crimson Crate
            Common.CreateCrateRecipe(ItemID.TheUndertaker, ItemID.CrimsonFishingCrate, ItemID.CrimsonFishingCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.TheRottedFork, ItemID.CrimsonFishingCrate, ItemID.CrimsonFishingCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.CrimsonRod, ItemID.CrimsonFishingCrate, ItemID.CrimsonFishingCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.PanicNecklace, ItemID.CrimsonFishingCrate, ItemID.CrimsonFishingCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.CrimsonHeart, ItemID.CrimsonFishingCrate, ItemID.CrimsonFishingCrateHard, 1);
            //Other
            Common.CreateCrateHardmodeRecipe(ItemID.Bladetongue, ItemID.CrimsonFishingCrateHard, 1);

            //Hallow
            //Other
            Common.CreateCrateHardmodeRecipe(ItemID.CrystalSerpent, ItemID.HallowedFishingCrateHard, 1);

            //Ocean Crate
            Common.CreateCrateRecipe(ItemID.BreathingReed, ItemID.OceanCrate, ItemID.OceanCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.FloatingTube, ItemID.OceanCrate, ItemID.OceanCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.Trident, ItemID.OceanCrate, ItemID.OceanCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.Flipper, ItemID.OceanCrate, ItemID.OceanCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.WaterWalkingBoots, ItemID.OceanCrate, ItemID.OceanCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.SharkBait, ItemID.OceanCrate, ItemID.OceanCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.SandcastleBucket, ItemID.OceanCrate, ItemID.OceanCrateHard, 1);
            //Other
            Common.CreateCrateRecipe(ItemID.ReaverShark, ItemID.OceanCrate, ItemID.OceanCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.SawtoothShark, ItemID.OceanCrate, ItemID.OceanCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.Swordfish, ItemID.OceanCrate, ItemID.OceanCrateHard, 1);

            //Obsidian Crate
            Common.CreateCrateRecipe(ItemID.LavaCharm, ItemID.LavaCrate, ItemID.LavaCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.FlameWakerBoots, ItemID.LavaCrate, ItemID.LavaCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.SuperheatedBlood, ItemID.LavaCrate, ItemID.LavaCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.LavaFishbowl, ItemID.LavaCrate, ItemID.LavaCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.LavaFishingHook, ItemID.LavaCrate, ItemID.LavaCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.OrnateShadowKey, ItemID.LavaCrate, ItemID.LavaCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.HellCake, ItemID.LavaCrate, ItemID.LavaCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.HellMinecart, ItemID.LavaCrate, ItemID.LavaCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.DemonConch, ItemID.LavaCrate, ItemID.LavaCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.BottomlessLavaBucket, ItemID.LavaCrate, ItemID.LavaCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.LavaAbsorbantSponge, ItemID.LavaCrate, ItemID.LavaCrateHard, 1);
            Common.CreateCrateHardmodeRecipe(ItemID.ObsidianSwordfish, ItemID.LavaCrateHard, 1);
            Common.CreateCrateWithKeyRecipe(ItemID.DarkLance, ItemID.LavaCrate, ItemID.LavaCrateHard, 1, ItemID.ShadowKey);
            Common.CreateCrateWithKeyRecipe(ItemID.Sunfury, ItemID.LavaCrate, ItemID.LavaCrateHard, 1, ItemID.ShadowKey);
            Common.CreateCrateWithKeyRecipe(ItemID.FlowerofFire, ItemID.LavaCrate, ItemID.LavaCrateHard, 1, ItemID.ShadowKey, Condition.NotRemixWorld, Condition.NotZenithWorld);
            Common.CreateCrateWithKeyRecipe(ItemID.Flamelash, ItemID.LavaCrate, ItemID.LavaCrateHard, 1, ItemID.ShadowKey);
            Common.CreateCrateWithKeyRecipe(ItemID.HellwingBow, ItemID.LavaCrate, ItemID.LavaCrateHard, 1, ItemID.ShadowKey);
            Common.CreateCrateWithKeyRecipe(ItemID.TreasureMagnet, ItemID.LavaCrate, ItemID.LavaCrateHard, 1, ItemID.ShadowKey);

            //Dungeon Crate Normal
            Common.CreateCrateWithKeyRecipe(ItemID.Valor, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ItemID.GoldenKey);
            Common.CreateCrateWithKeyRecipe(ItemID.Muramasa, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ItemID.GoldenKey);
            Common.CreateCrateWithKeyRecipe(ItemID.CobaltShield, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ItemID.GoldenKey);
            Common.CreateCrateWithKeyRecipe(ItemID.AquaScepter, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ItemID.GoldenKey, Condition.NotRemixWorld, Condition.NotZenithWorld);
            Common.CreateCrateWithKeyRecipe(ItemID.BlueMoon, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ItemID.GoldenKey);
            Common.CreateCrateWithKeyRecipe(ItemID.MagicMissile, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ItemID.GoldenKey);
            Common.CreateCrateWithKeyRecipe(ItemID.Handgun, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ItemID.GoldenKey);
            Common.CreateCrateWithKeyRecipe(ItemID.ShadowKey, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ItemID.GoldenKey);
            //Dungeon Crate Lockpick
            Common.CreateCrateWithKeyRecipe(ItemID.Valor, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ModContent.ItemType<GoldenLockpick>());
            Common.CreateCrateWithKeyRecipe(ItemID.Muramasa, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ModContent.ItemType<GoldenLockpick>());
            Common.CreateCrateWithKeyRecipe(ItemID.CobaltShield, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ModContent.ItemType<GoldenLockpick>());
            Common.CreateCrateWithKeyRecipe(ItemID.AquaScepter, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ModContent.ItemType<GoldenLockpick>(), Condition.NotRemixWorld, Condition.NotZenithWorld);
            Common.CreateCrateWithKeyRecipe(ItemID.BlueMoon, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ModContent.ItemType<GoldenLockpick>());
            Common.CreateCrateWithKeyRecipe(ItemID.MagicMissile, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ModContent.ItemType<GoldenLockpick>());
            Common.CreateCrateWithKeyRecipe(ItemID.Handgun, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ModContent.ItemType<GoldenLockpick>());
            Common.CreateCrateWithKeyRecipe(ItemID.ShadowKey, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ModContent.ItemType<GoldenLockpick>());

            //Stations
            Common.CreateCrateRecipe(ItemID.Extractinator, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.LivingLoom, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.HoneyDispenser, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.SkyMill, ItemID.FloatingIslandFishingCrate, ItemID.FloatingIslandFishingCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.IceMachine, ItemID.FrozenCrate, ItemID.FrozenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.CatBast, ItemID.OasisCrate, ItemID.OasisCrateHard, 1);
            Common.CreateCrateWithKeyRecipe(ItemID.AlchemyTable, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ItemID.GoldenKey);
            Common.CreateCrateWithKeyRecipe(ItemID.BoneWelder, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ItemID.GoldenKey);
            Common.CreateCrateWithKeyRecipe(ItemID.AlchemyTable, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ModContent.ItemType<GoldenLockpick>());
            Common.CreateCrateWithKeyRecipe(ItemID.BoneWelder, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ModContent.ItemType<GoldenLockpick>());
            Common.CreateCrateHardmodeRecipe(ItemID.Sundial, ItemID.GoldenCrateHard, 1);
            #endregion

            #region Modded
            #region Calamity
            if (ModConditions.calamityLoaded)
            {
                //Astral Crates
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.calamityMod, "AstrophageItem"), Common.GetModItem(ModConditions.calamityMod, "MonolithCrate"), Common.GetModItem(ModConditions.calamityMod, "AstralCrate"), 1);
                Common.CreateCrateHardmodeRecipe(Common.GetModItem(ModConditions.calamityMod, "AstralScythe"), Common.GetModItem(ModConditions.calamityMod, "AstralCrate"), 1, ModConditions.DownedAstrumAureus);
                Common.CreateCrateHardmodeRecipe(Common.GetModItem(ModConditions.calamityMod, "TitanArm"), Common.GetModItem(ModConditions.calamityMod, "AstralCrate"), 1, ModConditions.DownedAstrumAureus);
                Common.CreateCrateHardmodeRecipe(Common.GetModItem(ModConditions.calamityMod, "StellarCannon"), Common.GetModItem(ModConditions.calamityMod, "AstralCrate"), 1, ModConditions.DownedAstrumAureus);
                Common.CreateCrateHardmodeRecipe(Common.GetModItem(ModConditions.calamityMod, "AstralachneaStaff"), Common.GetModItem(ModConditions.calamityMod, "AstralCrate"), 1, ModConditions.DownedAstrumAureus);
                Common.CreateCrateHardmodeRecipe(Common.GetModItem(ModConditions.calamityMod, "HivePod"), Common.GetModItem(ModConditions.calamityMod, "AstralCrate"), 1, ModConditions.DownedAstrumAureus);
                Common.CreateCrateHardmodeRecipe(Common.GetModItem(ModConditions.calamityMod, "StellarKnife"), Common.GetModItem(ModConditions.calamityMod, "AstralCrate"), 1, ModConditions.DownedAstrumAureus);
                Common.CreateCrateHardmodeRecipe(Common.GetModItem(ModConditions.calamityMod, "StarbusterCore"), Common.GetModItem(ModConditions.calamityMod, "AstralCrate"), 1, ModConditions.DownedAstrumAureus);

                //Brimstone Crag Crates
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.calamityMod, "AshenStalactite"), Common.GetModItem(ModConditions.calamityMod, "SlagCrate"), Common.GetModItem(ModConditions.calamityMod, "BrimstoneCrate"), 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.calamityMod, "BladecrestOathsword"), Common.GetModItem(ModConditions.calamityMod, "SlagCrate"), Common.GetModItem(ModConditions.calamityMod, "BrimstoneCrate"), 1);
                Common.CreateCrateHardmodeRecipe(Common.GetModItem(ModConditions.calamityMod, "LiliesOfFinality"), Common.GetModItem(ModConditions.calamityMod, "BrimstoneCrate"), 1, ModConditions.DownedYharon);

                //Sulphurous Sea Crates
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.calamityMod, "AbyssalAmulet"), Common.GetModItem(ModConditions.calamityMod, "SulphurousCrate"), Common.GetModItem(ModConditions.calamityMod, "HydrothermalCrate"), 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.calamityMod, "AlluringBait"), Common.GetModItem(ModConditions.calamityMod, "SulphurousCrate"), Common.GetModItem(ModConditions.calamityMod, "HydrothermalCrate"), 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.calamityMod, "BrokenWaterFilter"), Common.GetModItem(ModConditions.calamityMod, "SulphurousCrate"), Common.GetModItem(ModConditions.calamityMod, "HydrothermalCrate"), 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.calamityMod, "EffigyOfDecay"), Common.GetModItem(ModConditions.calamityMod, "SulphurousCrate"), Common.GetModItem(ModConditions.calamityMod, "HydrothermalCrate"), 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.calamityMod, "RustyBeaconPrototype"), Common.GetModItem(ModConditions.calamityMod, "SulphurousCrate"), Common.GetModItem(ModConditions.calamityMod, "HydrothermalCrate"), 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.calamityMod, "RustyMedallion"), Common.GetModItem(ModConditions.calamityMod, "SulphurousCrate"), Common.GetModItem(ModConditions.calamityMod, "HydrothermalCrate"), 1);
                Common.CreateCrateRecipe(ItemID.ReaverShark, Common.GetModItem(ModConditions.calamityMod, "SulphurousCrate"), Common.GetModItem(ModConditions.calamityMod, "HydrothermalCrate"), 1);
                Common.CreateCrateRecipe(ItemID.SawtoothShark, Common.GetModItem(ModConditions.calamityMod, "SulphurousCrate"), Common.GetModItem(ModConditions.calamityMod, "HydrothermalCrate"), 1);
                Common.CreateCrateRecipe(ItemID.Swordfish, Common.GetModItem(ModConditions.calamityMod, "SulphurousCrate"), Common.GetModItem(ModConditions.calamityMod, "HydrothermalCrate"), 1);
                //Post Slime God
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.calamityMod, "BallOFugu"), Common.GetModItem(ModConditions.calamityMod, "SulphurousCrate"), Common.GetModItem(ModConditions.calamityMod, "HydrothermalCrate"), 1, ModConditions.DownedSlimeGod);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.calamityMod, "Archerfish"), Common.GetModItem(ModConditions.calamityMod, "SulphurousCrate"), Common.GetModItem(ModConditions.calamityMod, "HydrothermalCrate"), 1, ModConditions.DownedSlimeGod);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.calamityMod, "BlackAnurian"), Common.GetModItem(ModConditions.calamityMod, "SulphurousCrate"), Common.GetModItem(ModConditions.calamityMod, "HydrothermalCrate"), 1, ModConditions.DownedSlimeGod);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.calamityMod, "HerringStaff"), Common.GetModItem(ModConditions.calamityMod, "SulphurousCrate"), Common.GetModItem(ModConditions.calamityMod, "HydrothermalCrate"), 1, ModConditions.DownedSlimeGod);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.calamityMod, "Lionfish"), Common.GetModItem(ModConditions.calamityMod, "SulphurousCrate"), Common.GetModItem(ModConditions.calamityMod, "HydrothermalCrate"), 1, ModConditions.DownedSlimeGod);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.calamityMod, "AnechoicPlating"), Common.GetModItem(ModConditions.calamityMod, "SulphurousCrate"), Common.GetModItem(ModConditions.calamityMod, "HydrothermalCrate"), 1, ModConditions.DownedSlimeGod);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.calamityMod, "DepthCharm"), Common.GetModItem(ModConditions.calamityMod, "SulphurousCrate"), Common.GetModItem(ModConditions.calamityMod, "HydrothermalCrate"), 1, ModConditions.DownedSlimeGod);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.calamityMod, "IronBoots"), Common.GetModItem(ModConditions.calamityMod, "SulphurousCrate"), Common.GetModItem(ModConditions.calamityMod, "HydrothermalCrate"), 1, ModConditions.DownedSlimeGod);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.calamityMod, "StrangeOrb"), Common.GetModItem(ModConditions.calamityMod, "SulphurousCrate"), Common.GetModItem(ModConditions.calamityMod, "HydrothermalCrate"), 1, ModConditions.DownedSlimeGod);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.calamityMod, "TorrentialTear"), Common.GetModItem(ModConditions.calamityMod, "SulphurousCrate"), Common.GetModItem(ModConditions.calamityMod, "HydrothermalCrate"), 1, ModConditions.DownedSlimeGod);
                //Hardmode Post Acid Rain
                Common.CreateCrateHardmodeRecipe(Common.GetModItem(ModConditions.calamityMod, "SulphurousGrabber"), Common.GetModItem(ModConditions.calamityMod, "HydrothermalCrate"), 1, ModConditions.DownedAcidRain2);
                Common.CreateCrateHardmodeRecipe(Common.GetModItem(ModConditions.calamityMod, "FlakToxicannon"), Common.GetModItem(ModConditions.calamityMod, "HydrothermalCrate"), 1, ModConditions.DownedAcidRain2);
                Common.CreateCrateHardmodeRecipe(Common.GetModItem(ModConditions.calamityMod, "BelchingSaxophone"), Common.GetModItem(ModConditions.calamityMod, "HydrothermalCrate"), 1, ModConditions.DownedAcidRain2);
                Common.CreateCrateHardmodeRecipe(Common.GetModItem(ModConditions.calamityMod, "SlitheringEels"), Common.GetModItem(ModConditions.calamityMod, "HydrothermalCrate"), 1, ModConditions.DownedAcidRain2);
                Common.CreateCrateHardmodeRecipe(Common.GetModItem(ModConditions.calamityMod, "SkyfinBombers"), Common.GetModItem(ModConditions.calamityMod, "HydrothermalCrate"), 1, ModConditions.DownedAcidRain2);
                Common.CreateCrateHardmodeRecipe(Common.GetModItem(ModConditions.calamityMod, "SpentFuelContainer"), Common.GetModItem(ModConditions.calamityMod, "HydrothermalCrate"), 1, ModConditions.DownedAcidRain2);
                Common.CreateCrateHardmodeRecipe(Common.GetModItem(ModConditions.calamityMod, "NuclearFuelRod"), Common.GetModItem(ModConditions.calamityMod, "HydrothermalCrate"), 1, ModConditions.DownedAcidRain2);

                //Sunken Sea Crates
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.calamityMod, "RustedJingleBell"), Common.GetModItem(ModConditions.calamityMod, "EutrophicCrate"), Common.GetModItem(ModConditions.calamityMod, "PrismCrate"), 1);
                //Post Desert Scourge
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.calamityMod, "SparklingEmpress"), Common.GetModItem(ModConditions.calamityMod, "EutrophicCrate"), Common.GetModItem(ModConditions.calamityMod, "PrismCrate"), 1, ModConditions.DownedDesertScourge);
                //Hardmode
                Common.CreateCrateHardmodeRecipe(Common.GetModItem(ModConditions.calamityMod, "SerpentsBite"), Common.GetModItem(ModConditions.calamityMod, "PrismCrate"), 1);
            }
            #endregion

            #region Spirit
            if (ModConditions.spiritLoaded)
            {
                //Briar Crates
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.spiritMod, "ReachBrooch"), Common.GetModItem(ModConditions.spiritMod, "ReachCrate"), Common.GetModItem(ModConditions.spiritMod, "BriarCrate"), 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.spiritMod, "ReachBoomerang"), Common.GetModItem(ModConditions.spiritMod, "ReachCrate"), Common.GetModItem(ModConditions.spiritMod, "BriarCrate"), 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.spiritMod, "ThornHook"), Common.GetModItem(ModConditions.spiritMod, "ReachCrate"), Common.GetModItem(ModConditions.spiritMod, "BriarCrate"), 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.spiritMod, "ReachChestMagic"), Common.GetModItem(ModConditions.spiritMod, "ReachCrate"), Common.GetModItem(ModConditions.spiritMod, "BriarCrate"), 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.spiritMod, "LivingElderbarkWand"), Common.GetModItem(ModConditions.spiritMod, "ReachCrate"), Common.GetModItem(ModConditions.spiritMod, "BriarCrate"), 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.spiritMod, "ThornyRod"), Common.GetModItem(ModConditions.spiritMod, "ReachCrate"), Common.GetModItem(ModConditions.spiritMod, "BriarCrate"), 1);
            }
            #endregion

            #region Thorium
            if (ModConditions.thoriumLoaded)
            {
                //Aquatic Depths Crates
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "MagicConch"), Common.GetModItem(ModConditions.thoriumMod, "AquaticDepthsCrate"), Common.GetModItem(ModConditions.thoriumMod, "AbyssalCrate"), 1, Condition.DownedEowOrBoc);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "AnglerBowl"), Common.GetModItem(ModConditions.thoriumMod, "AquaticDepthsCrate"), Common.GetModItem(ModConditions.thoriumMod, "AbyssalCrate"), 1, Condition.DownedEowOrBoc);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "RainStone"), Common.GetModItem(ModConditions.thoriumMod, "AquaticDepthsCrate"), Common.GetModItem(ModConditions.thoriumMod, "AbyssalCrate"), 1, Condition.DownedEowOrBoc);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "SteelDrum"), Common.GetModItem(ModConditions.thoriumMod, "AquaticDepthsCrate"), Common.GetModItem(ModConditions.thoriumMod, "AbyssalCrate"), 1, Condition.DownedEowOrBoc);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "SeaTurtlesBulwark"), Common.GetModItem(ModConditions.thoriumMod, "AquaticDepthsCrate"), Common.GetModItem(ModConditions.thoriumMod, "AbyssalCrate"), 1, Condition.DownedEowOrBoc);

                //Scarlet Crates
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "MixTape"), Common.GetModItem(ModConditions.thoriumMod, "ScarletCrate"), Common.GetModItem(ModConditions.thoriumMod, "SinisterCrate"), 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "LootRang"), Common.GetModItem(ModConditions.thoriumMod, "ScarletCrate"), Common.GetModItem(ModConditions.thoriumMod, "SinisterCrate"), 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "MagmaCharm"), Common.GetModItem(ModConditions.thoriumMod, "ScarletCrate"), Common.GetModItem(ModConditions.thoriumMod, "SinisterCrate"), 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "SpringSteps"), Common.GetModItem(ModConditions.thoriumMod, "ScarletCrate"), Common.GetModItem(ModConditions.thoriumMod, "SinisterCrate"), 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "DeepStaff"), Common.GetModItem(ModConditions.thoriumMod, "ScarletCrate"), Common.GetModItem(ModConditions.thoriumMod, "SinisterCrate"), 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "MagmaLocket"), Common.GetModItem(ModConditions.thoriumMod, "ScarletCrate"), Common.GetModItem(ModConditions.thoriumMod, "SinisterCrate"), 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "SpringHook"), Common.GetModItem(ModConditions.thoriumMod, "ScarletCrate"), Common.GetModItem(ModConditions.thoriumMod, "SinisterCrate"), 1);
                Common.CreateCrateRecipe(ItemID.LavaCharm, Common.GetModItem(ModConditions.thoriumMod, "ScarletCrate"), Common.GetModItem(ModConditions.thoriumMod, "SinisterCrate"), 1);

                //Strange Crates
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "HightechSonarDevice"), Common.GetModItem(ModConditions.thoriumMod, "StrangeCrate"), Common.GetModItem(ModConditions.thoriumMod, "WondrousCrate"), 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "DrownedDoubloon"), Common.GetModItem(ModConditions.thoriumMod, "StrangeCrate"), Common.GetModItem(ModConditions.thoriumMod, "WondrousCrate"), 1);

            }
            #endregion
            #endregion
        }

        public static void BannerRecipes()
        {
            //Banner Recipe Creation
            #region Biomes
            #region Forest
            //Accessories
            //Armor/Vanity
            //Food
            //Furniture
            //Materials
            //Weapons
            //Misc Equips
            //Misc
            #endregion

            #region Underground/Caverns
            //Accessories
            AddBannerToItemRecipe(ItemID.JellyfishBanner, ItemID.JellyfishNecklace, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.GreenJellyfishBanner, ItemID.JellyfishNecklace, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.SkeletonArcherBanner, ItemID.MagicQuiver, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.TitanGlove, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.PhilosophersStone, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.CrossNecklace, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.StarCloak, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.ToxicSludgeBanner, ItemID.Bezoar, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.AnglerFishBanner, ItemID.AdhesiveBandage, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.ArmoredSkeletonBanner, ItemID.ArmorPolish, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.GiantBatBanner, ItemID.TrifoldMap, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.GreenJellyfishBanner, ItemID.Megaphone, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.MedusaBanner, ItemID.PocketMirror, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.CrawdadBanner, ItemID.Compass, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.GiantShellyBanner, ItemID.Compass, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.MotherSlimeBanner, ItemID.Compass, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.PiranhaBanner, ItemID.Compass, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.SalamanderBanner, ItemID.Compass, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.BatBanner, ItemID.DepthMeter, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.CrawdadBanner, ItemID.DepthMeter, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.GiantBatBanner, ItemID.DepthMeter, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.GiantShellyBanner, ItemID.DepthMeter, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.SalamanderBanner, ItemID.DepthMeter, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.NypmhBanner, ItemID.MetalDetector, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            //Armor/Vanity
            AddBannerToItemRecipe(ItemID.GraniteFlyerBanner, ItemID.NightVisionHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.GraniteGolemBanner, ItemID.NightVisionHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.GreekSkeletonBanner, ItemID.GladiatorLeggings, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.GreekSkeletonBanner, ItemID.GladiatorBreastplate, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.GreekSkeletonBanner, ItemID.GladiatorHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.SkeletonBanner, ItemID.AncientIronHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.SkeletonBanner, ItemID.AncientGoldHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.UndeadMinerBanner, ItemID.MiningPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.UndeadMinerBanner, ItemID.MiningShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.UndeadMinerBanner, ItemID.MiningHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.RockGolemBanner, ItemID.RockGolemHead, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.AnglerFishBanner, ItemID.RobotHat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Food
            AddBannerToItemRecipe(ItemID.SalamanderBanner, ItemID.PotatoChips, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.CrawdadBanner, ItemID.PotatoChips, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.GiantShellyBanner, ItemID.PotatoChips, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerSetToItemRecipe(NPCID.Sets.Skeletons, ItemID.MilkCarton);
            AddBannerToItemRecipe(ItemID.SpiderBanner, ItemID.FriedEgg, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.BlackRecluseBanner, ItemID.FriedEgg, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.GreekSkeletonBanner, ItemID.Pizza, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.MedusaBanner, ItemID.Pizza, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.GraniteGolemBanner, ItemID.Spaghetti, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.GraniteFlyerBanner, ItemID.Spaghetti, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.UndeadMinerBanner, ItemID.Steak, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            //Furniture
            //Materials
            //Weapons
            AddBannerGroupToItemRecipe(AnyBatBanner, ItemID.BatBat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.BatBanner, ItemID.ChainKnife, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.NotRemixWorld);
            AddBannerToItemRecipe(ItemID.CrawdadBanner, ItemID.Rally, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.GiantShellyBanner, ItemID.Rally, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.SalamanderBanner, ItemID.Rally, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.SkeletonBanner, ItemID.BoneSword, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.UndeadMinerBanner, ItemID.BonePickaxe, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.FlowerofFrost, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.Frostbrand, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.IceBow, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.MagicDagger, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.GreekSkeletonBanner, ItemID.Gladius, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.SkeletonArcherBanner, ItemID.Marrow, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.ArmoredSkeletonBanner, ItemID.BeamSword, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.MedusaBanner, ItemID.MedusaHead, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.GiantBatBanner, ItemID.ChainKnife, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode, Condition.NotRemixWorld);
            AddBannerToItemRecipe(ItemID.BlackRecluseBanner, ItemID.PoisonStaff, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Misc Equips
            AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.DualHook, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.ToySled, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Misc
            AddBannerToItemRecipe(ItemID.WormBanner, ItemID.WhoopieCushion, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            #endregion

            #region Underworld
            //Accessories
            AddBannerToItemRecipe(ItemID.FireImpBanner, ItemID.ObsidianRose, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.HellbatBanner, ItemID.MagmaStone, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.LavaBatBanner, ItemID.MagmaStone, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            //Armor/Vanity
            //Food
            AddBannerToItemRecipe(ItemID.BoneSerpentBanner, ItemID.Hotdog, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.RedDevilBanner, ItemID.Hotdog, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedMechBossAny);
            //Furniture
            //Materials
            AddBannerToItemRecipe(ItemID.RedDevilBanner, ItemID.FireFeather, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedMechBossAny);
            //Weapons
            AddBannerToItemRecipe(ItemID.DemonBanner, ItemID.DemonScythe, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerGroupToItemRecipe(AnyUnderworldBanner, ItemID.Cascade, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedSkeletron);
            AddBannerGroupToItemRecipe(AnyUnderworldBanner, ItemID.HelFire, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.RedDevilBanner, ItemID.UnholyTrident, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedMechBossAny);
            //Misc Equips
            //Misc
            #endregion

            #region Sky
            //Accessories
            //Armor/Vanity
            //Food
            AddBannerToItemRecipe(ItemID.HarpyBanner, ItemID.ChickenNugget, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            //Furniture
            //Materials
            AddBannerToItemRecipe(ItemID.HarpyBanner, ItemID.GiantHarpyFeather, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Weapons
            //Misc Equips
            //Misc
            #endregion

            #region Snow
            //Accessories
            AddBannerToItemRecipe(ItemID.IceTortoiseBanner, ItemID.FrozenTurtleShell, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.ArmoredVikingBanner, ItemID.Compass, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.SnowFlinxBanner, ItemID.Compass, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.UndeadVikingBanner, ItemID.Compass, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.IceBatBanner, ItemID.DepthMeter, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            //Armor/Vanity
            AddBannerToItemRecipe(ItemID.UndeadVikingBanner, ItemID.VikingHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.ArmoredVikingBanner, ItemID.VikingHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.ZombieEskimoBanner, ItemID.EskimoPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.ZombieEskimoBanner, ItemID.EskimoCoat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.ZombieEskimoBanner, ItemID.EskimoHood, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            //Food
            AddBannerToItemRecipe(ItemID.IceSlimeBanner, ItemID.IceCream, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.IceBatBanner, ItemID.IceCream, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.SpikedIceSlimeBanner, ItemID.IceCream, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.IcyMermanBanner, ItemID.Milkshake, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.IceTortoiseBanner, ItemID.Milkshake, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.PigronBanner, ItemID.Bacon, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Furniture
            //Materials
            AddBannerToItemRecipe(ItemID.IceGolemBanner, ItemID.IceFeather, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedMechBossAny);
            //Weapons
            AddBannerToItemRecipe(ItemID.SnowFlinxBanner, ItemID.SnowballLauncher, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerGroupToItemRecipe(AnySnowBanner, ItemID.Amarok, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.ArmoredVikingBanner, ItemID.IceSickle, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.IcyMermanBanner, ItemID.FrostStaff, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.PigronBanner, ItemID.HamBat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Misc Equips
            AddBannerToItemRecipe(ItemID.PigronBanner, ItemID.PigronMinecart, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.WolfBanner, ItemID.WolfMountItem, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Misc
            AddBannerGroupToItemRecipe(AnySnowBanner, ItemID.FrozenKey, 1, 5, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            #endregion

            #region Desert
            //Accessories
            AddBannerToItemRecipe(ItemID.MummyBanner, ItemID.FastClock, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Armor/Vanity
            AddBannerToItemRecipe(ItemID.DesertDjinnBanner, ItemID.DjinnsCurse, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.DesertLamiaBanner, ItemID.LamiaPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.DesertLamiaBanner, ItemID.LamiaShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.DesertLamiaBanner, ItemID.LamiaHat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.DesertLamiaBanner, ItemID.MoonMask, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.DesertLamiaBanner, ItemID.SunMask, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.MummyBanner, ItemID.MummyPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.MummyBanner, ItemID.MummyShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.MummyBanner, ItemID.MummyMask, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Food
            AddBannerToItemRecipe(ItemID.AntlionBanner, ItemID.BananaSplit, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.WalkingAntlionBanner, ItemID.BananaSplit, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.FlyingAntlionBanner, ItemID.BananaSplit, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.TumbleweedBanner, ItemID.Nachos, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.RavagerScorpionBanner, ItemID.FriedEgg, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.SandsharkBanner, ItemID.Nachos, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Furniture
            //Materials
            //Weapons
            AddBannerToItemRecipe(ItemID.WalkingAntlionBanner, ItemID.AntlionClaw, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            //Misc Equips
            AddBannerToItemRecipe(ItemID.DesertBasiliskBanner, ItemID.AncientHorn, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Misc
            AddBannerGroupToItemRecipe(AnyDesertBanner, ItemID.DungeonDesertKey, 1, 5, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            #endregion

            #region Ocean
            //Accessories
            AddBannerToItemRecipe(ItemID.SharkBanner, ItemID.DivingHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.PinkJellyfishBanner, ItemID.JellyfishNecklace, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            //Armor/Vanity
            //Food
            AddBannerToItemRecipe(ItemID.SharkBanner, ItemID.ShrimpPoBoy, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.CrabBanner, ItemID.ShrimpPoBoy, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            //Furniture
            //Materials
            //Weapons
            //Misc Equips
            //Misc
            #endregion

            #region Jungle
            //Accessories
            AddBannerToItemRecipe(ItemID.HornetBanner, ItemID.Bezoar, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.MossHornetBanner, ItemID.Bezoar, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.JungleBatBanner, ItemID.DepthMeter, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            //Armor/Vanity
            AddBannerToItemRecipe(ItemID.HornetBanner, ItemID.AncientCobaltLeggings, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.HornetBanner, ItemID.AncientCobaltBreastplate, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.HornetBanner, ItemID.AncientCobaltHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.PiranhaBanner, ItemID.RobotHat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            //Food
            AddBannerToItemRecipe(ItemID.ManEaterBanner, ItemID.CoffeeCup, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.SnatcherBanner, ItemID.CoffeeCup, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.AngryTrapperBanner, ItemID.CoffeeCup, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.GiantFlyingFoxBanner, ItemID.Grapes, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.DerplingBanner, ItemID.Grapes, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Furniture
            //Materials
            AddBannerToItemRecipe(ItemID.MossHornetBanner, ItemID.TatteredBeeWing, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedMechBossAny);
            AddBannerToItemRecipe(ItemID.MothBanner, ItemID.ButterflyDust, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedMechBossAny);
            //Weapons
            AddBannerToItemRecipe(ItemID.AngryTrapperBanner, ItemID.Uzi, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerGroupToItemRecipe(AnyJungleBanner, ItemID.Yelets, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedMechBossAny);
            //Misc Equips
            //Misc
            AddBannerGroupToItemRecipe(AnyJungleBanner, ItemID.JungleKey, 1, 5, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            #endregion

            #region Temple
            //Accessories
            //Armor/Vanity
            //Food
            //Furniture
            //Materials
            //Weapons
            //Misc Equips
            AddBannerToItemRecipe(ItemID.LihzahrdBanner, ItemID.LizardEgg, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedGolem);
            //Misc
            #endregion

            #region Glowing Mushroom
            //Accessories
            AddBannerToItemRecipe(ItemID.SporeBatBanner, ItemID.DepthMeter, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            //Armor/Vanity
            //Food
            //Furniture
            //Materials
            //Weapons
            AddBannerToItemRecipe(ItemID.SporeBatBanner, ItemID.Shroomerang, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            //Misc Equips
            //Misc
            #endregion

            #region Corruption
            //Accessories
            AddBannerToItemRecipe(ItemID.CursedHammerBanner, ItemID.Nazar, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.DarkMummyBanner, ItemID.Blindfold, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.DarkMummyBanner, ItemID.Megaphone, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.CorruptSlimeBanner, ItemID.Blindfold, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.CorruptorBanner, ItemID.Vitamins, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Armor/Vanity
            AddBannerToItemRecipe(ItemID.EaterofSoulsBanner, ItemID.AncientShadowGreaves, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.EaterofSoulsBanner, ItemID.AncientShadowScalemail, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.EaterofSoulsBanner, ItemID.AncientShadowHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.CorruptBunnyBanner, ItemID.BunnyHood, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.CorruptPenguinBanner, ItemID.PedguinPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.CorruptPenguinBanner, ItemID.PedguinShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.CorruptPenguinBanner, ItemID.PedguinHat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.DarkMummyBanner, ItemID.MummyPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.DarkMummyBanner, ItemID.MummyShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.DarkMummyBanner, ItemID.MummyMask, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Food
            AddBannerToItemRecipe(ItemID.EaterofSoulsBanner, ItemID.Burger, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.SandsharkCorruptBanner, ItemID.Nachos, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Furniture
            AddBannerGroupToItemRecipe(AnyCorruptionBanner, ItemID.MeatGrinder, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Materials
            //Weapons
            AddBannerToItemRecipe(ItemID.EaterofSoulsBanner, ItemID.TentacleSpike, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            //Misc Equips
            //Misc
            AddBannerGroupToItemRecipe(AnyCorruptionBanner, ItemID.CorruptionKey, 1, 5, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            #endregion

            #region Crimson
            //Accessories
            AddBannerToItemRecipe(ItemID.CrimsonAxeBanner, ItemID.Nazar, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.BloodMummyBanner, ItemID.Blindfold, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.BloodMummyBanner, ItemID.Megaphone, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.CrimslimeBanner, ItemID.Blindfold, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.FloatyGrossBanner, ItemID.Vitamins, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Armor/Vanity
            AddBannerToItemRecipe(ItemID.CrimsonBunnyBanner, ItemID.BunnyHood, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.CrimsonPenguinBanner, ItemID.PedguinPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.CrimsonPenguinBanner, ItemID.PedguinShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.CrimsonPenguinBanner, ItemID.PedguinHat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.BloodMummyBanner, ItemID.MummyPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.BloodMummyBanner, ItemID.MummyShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.BloodMummyBanner, ItemID.MummyMask, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Food
            AddBannerToItemRecipe(ItemID.CrimeraBanner, ItemID.Burger, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.SandsharkCrimsonBanner, ItemID.Nachos, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Furniture
            AddBannerGroupToItemRecipe(AnyCrimsonBanner, ItemID.MeatGrinder, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Materials
            //Weapons
            AddBannerToItemRecipe(ItemID.BloodCrawlerBanner, ItemID.TentacleSpike, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.CrimeraBanner, ItemID.TentacleSpike, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.FaceMonsterBanner, ItemID.TentacleSpike, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            //Misc Equips
            //Misc
            AddBannerGroupToItemRecipe(AnyCrimsonBanner, ItemID.CrimsonKey, 1, 5, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            #endregion

            #region Hallow
            //Accessories
            AddBannerToItemRecipe(ItemID.EnchantedSwordBanner, ItemID.Nazar, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.LightMummyBanner, ItemID.TrifoldMap, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.PixieBanner, ItemID.Megaphone, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.PixieBanner, ItemID.FastClock, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Armor/Vanity
            AddBannerToItemRecipe(ItemID.LightMummyBanner, ItemID.MummyPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.LightMummyBanner, ItemID.MummyShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.LightMummyBanner, ItemID.MummyMask, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Food
            AddBannerToItemRecipe(ItemID.SandsharkHallowedBanner, ItemID.Nachos, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.ChaosElementalBanner, ItemID.ApplePie, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.IlluminantBatBanner, ItemID.ApplePie, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.IlluminantSlimeBanner, ItemID.ApplePie, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.GastropodBanner, ItemID.ChocolateChipCookie, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Furniture
            //Materials
            //Weapons
            //Misc Equips
            AddBannerToItemRecipe(ItemID.UnicornBanner, ItemID.BlessedApple, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Misc
            AddBannerToItemRecipe(ItemID.ChaosElementalBanner, ItemID.RodofDiscord, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.UnicornBanner, ItemID.UnicornonaStick, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerGroupToItemRecipe(AnyHallowBanner, ItemID.HallowedKey, 1, 5, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            #endregion

            #region Dungeon
            //Accessories
            AddBannerToItemRecipe(ItemID.BoneLeeBanner, ItemID.BlackBelt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.BoneLeeBanner, ItemID.Tabi, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.SkeletonSniperBanner, ItemID.RifleScope, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.PaladinBanner, ItemID.PaladinsShield, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.CursedSkullBanner, ItemID.Nazar, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.GiantCursedSkullBanner, ItemID.Nazar, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.RustyArmoredBonesBanner, ItemID.AdhesiveBandage, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.BlueArmoredBonesBanner, ItemID.ArmorPolish, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.AngryBonesBanner, ItemID.TallyCounter, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.CursedSkullBanner, ItemID.TallyCounter, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.SkeletonMageBanner, ItemID.TallyCounter, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            //Armor/Vanity
            AddBannerToItemRecipe(ItemID.AngryBonesBanner, ItemID.AncientNecroHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.SkeletonMageBanner, ItemID.AncientNecroHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.TacticalSkeletonBanner, ItemID.SWATHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            //Food
            AddBannerToItemRecipe(ItemID.CursedSkullBanner, ItemID.CreamSoda, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.BoneLeeBanner, ItemID.CoffeeCup, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.GiantCursedSkullBanner, ItemID.CreamSoda, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.SkeletonCommandoBanner, ItemID.BBQRibs, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.SkeletonSniperBanner, ItemID.BBQRibs, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.TacticalSkeletonBanner, ItemID.BBQRibs, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            //Furniture
            //Materials
            AddBannerGroupToItemRecipe(AnyArmoredBonesBanner, ItemID.BoneFeather, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Weapons
            AddBannerGroupToItemRecipe(AnyArmoredBonesBanner, ItemID.Keybrand, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerGroupToItemRecipe(AnyArmoredBonesBanner, ItemID.Kraken, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerGroupToItemRecipe(AnyArmoredBonesBanner, ItemID.MaceWhip, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerGroupToItemRecipe(AnyArmoredBonesBanner, ItemID.MagnetSphere, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.GiantCursedSkullBanner, ItemID.ShadowJoustingLance, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.DiablolistBanner, ItemID.InfernoFork, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.PaladinBanner, ItemID.PaladinsHammer, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.NecromancerBanner, ItemID.ShadowbeamStaff, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.RaggedCasterBanner, ItemID.SpectreStaff, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.SkeletonCommandoBanner, ItemID.RocketLauncher, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.SkeletonSniperBanner, ItemID.SniperRifle, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.TacticalSkeletonBanner, ItemID.TacticalShotgun, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            //Misc Equips
            AddBannerGroupToItemRecipe(AnyArmoredBonesBanner, ItemID.WispinaBottle, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            //Misc
            AddBannerToItemRecipe(ItemID.SkeletonMageBanner, ItemID.BoneWand, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            #endregion
            #endregion

            #region Events
            #region Day
            //Accessories
            //Armor/Vanity
            //Food
            //Furniture
            //Materials
            //Weapons
            //Misc Equips
            //Misc
            #endregion

            #region Night
            //Accessories
            AddBannerToItemRecipe(ItemID.ZombieBanner, ItemID.Shackle, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.RaincoatZombieBanner, ItemID.Shackle, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.ZombieEskimoBanner, ItemID.Shackle, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.WerewolfBanner, ItemID.MoonCharm, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.WerewolfBanner, ItemID.AdhesiveBandage, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.WraithBanner, ItemID.FastClock, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Armor/Vanity
            //Food
            //Furniture
            //Materials
            //Weapons
            AddBannerToItemRecipe(ItemID.ZombieBanner, ItemID.ZombieArm, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            //Misc Equips
            //Misc
            #endregion

            #region Rain
            //Accessories
            //Armor/Vanity
            AddBannerToItemRecipe(ItemID.UmbrellaSlimeBanner, ItemID.UmbrellaHat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.RaincoatZombieBanner, ItemID.RainCoat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.RaincoatZombieBanner, ItemID.RainHat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            //Food
            AddBannerToItemRecipe(ItemID.FlyingFishBanner, ItemID.Fries, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            //Furniture
            //Materials
            //Weapons
            AddBannerToItemRecipe(ItemID.AngryNimbusBanner, ItemID.NimbusRod, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Misc Equips
            //Misc
            AddBannerToItemRecipe(ItemID.FlyingFishBanner, ItemID.CarbonGuitar, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            #endregion

            #region Wind
            //Accessories
            //Armor/Vanity
            //Materials
            //Weapons
            //Misc Equips
            //Misc
            AddBannerToItemRecipe(ItemID.BoneSerpentBanner, ItemID.KiteBoneSerpent, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.BunnyBanner, ItemID.KiteBunny, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.CorruptBunnyBanner, ItemID.KiteBunnyCorrupt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.CrimsonBunnyBanner, ItemID.KiteBunnyCrimson, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.GoldfishBanner, ItemID.KiteGoldfish, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.JellyfishBanner, ItemID.KiteJellyfishBlue, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.ManEaterBanner, ItemID.KiteManEater, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.PinkJellyfishBanner, ItemID.KiteJellyfishPink, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.RedSlimeBanner, ItemID.KiteRed, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.SharkBanner, ItemID.KiteShark, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.SlimeBanner, ItemID.KiteBlue, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.YellowSlimeBanner, ItemID.KiteYellow, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.AngryTrapperBanner, ItemID.KiteAngryTrapper, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.PigronBanner, ItemID.KitePigron, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.SandsharkBanner, ItemID.KiteSandShark, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.UnicornBanner, ItemID.KiteUnicorn, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.WanderingEyeBanner, ItemID.KiteWanderingEye, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.WorldFeederBanner, ItemID.KiteWorldFeeder, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.WyvernBanner, ItemID.KiteWyvern, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            #endregion

            #region Blood Moon
            //Accessories
            AddBannerToItemRecipe(ItemID.BloodZombieBanner, ItemID.SharkToothNecklace, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.DripplerBanner, ItemID.SharkToothNecklace, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.ClownBanner, ItemID.TrifoldMap, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Armor/Vanity
            //Food
            //Furniture
            //Materials
            //Weapons
            AddBannerToItemRecipe(ItemID.EyeballFlyingFishBanner, ItemID.BloodRainBow, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.EyeballFlyingFishBanner, ItemID.VampireFrogStaff, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.ZombieMermanBanner, ItemID.BloodRainBow, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.ZombieMermanBanner, ItemID.VampireFrogStaff, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.BloodZombieBanner, ItemID.KOCannon, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.ClownBanner, ItemID.KOCannon, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.GoblinSharkBanner, ItemID.SharpTears, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.GoblinSharkBanner, ItemID.BloodHamaxe, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.BloodEelBanner, ItemID.DripplerFlail, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.BloodEelBanner, ItemID.BloodHamaxe, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            AddBannerToItemRecipe(ItemID.BloodNautilusBanner, ItemID.SanguineStaff, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            //Misc Equips
            //Misc
            AddBannerToItemRecipe(ItemID.DripplerBanner, ItemID.MoneyTrough, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.EyeballFlyingFishBanner, ItemID.BloodFishingRod, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.ZombieMermanBanner, ItemID.BloodFishingRod, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            AddBannerToItemRecipe(ItemID.BloodNautilusBanner, ItemID.BloodMoonMonolith, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.Hardmode);
            #endregion

            #region Goblins
            //Accessories
            //Armor/Vanity
            //Food
            //Furniture
            //Materials
            //Weapons
            AddBannerToItemRecipe(ItemID.GoblinArcherBanner, ItemID.Harpoon, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes));
            //Misc Equips
            //Misc
            #endregion

            #region Frost Legion
            //Accessories
            //Armor/Vanity
            //Food
            //Furniture
            //Materials
            //Weapons
            //Misc Equips
            //Misc
            #endregion

            #region Pirates
            //Accessories
            AddBannerGroupToItemRecipe(AnyPirateBanner, ItemID.DiscountCard, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPirates);
            AddBannerGroupToItemRecipe(AnyPirateBanner, ItemID.GoldRing, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPirates);
            AddBannerGroupToItemRecipe(AnyPirateBanner, ItemID.LuckyCoin, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPirates);
            //Armor/Vanity
            AddBannerGroupToItemRecipe(AnyPirateBanner, ItemID.SailorPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPirates);
            AddBannerGroupToItemRecipe(AnyPirateBanner, ItemID.SailorShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPirates);
            AddBannerGroupToItemRecipe(AnyPirateBanner, ItemID.SailorHat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPirates);
            AddBannerGroupToItemRecipe(AnyPirateBanner, ItemID.EyePatch, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPirates);
            AddBannerGroupToItemRecipe(AnyPirateBanner, ItemID.BuccaneerPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPirates);
            AddBannerGroupToItemRecipe(AnyPirateBanner, ItemID.BuccaneerShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPirates);
            AddBannerGroupToItemRecipe(AnyPirateBanner, ItemID.BuccaneerBandana, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPirates);
            //Food
            //Furniture
            //Materials
            //Weapons
            AddBannerGroupToItemRecipe(AnyPirateBanner, ItemID.Cutlass, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPirates);
            AddBannerGroupToItemRecipe(AnyPirateBanner, ItemID.PirateStaff, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPirates);
            AddBannerToItemRecipe(ItemID.PirateCaptainBanner, ItemID.CoinGun, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPirates);
            //Misc Equips
            //Misc
            #endregion

            #region Eclipse
            //Accessories
            AddBannerToItemRecipe(ItemID.CreatureFromTheDeepBanner, ItemID.NeptunesShell, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedMechBossAny);
            AddBannerToItemRecipe(ItemID.VampireBanner, ItemID.MoonStone, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedMechBossAny);
            AddBannerToItemRecipe(ItemID.MothronBanner, ItemID.MothronWings, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            //Armor/Vanity
            AddBannerToItemRecipe(ItemID.ButcherBanner, ItemID.ButcherPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.ButcherBanner, ItemID.ButcherApron, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.ButcherBanner, ItemID.ButcherPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.DrManFlyBanner, ItemID.DrManFlyLabCoat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.DrManFlyBanner, ItemID.DrManFlyMask, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            //Food
            AddBannerToItemRecipe(ItemID.ThePossessedBanner, ItemID.Steak, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedMechBossAny);
            //Furniture
            //Materials
            AddBannerToItemRecipe(ItemID.VampireBanner, ItemID.BrokenBatWing, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedMechBossAny);
            AddBannerToItemRecipe(ItemID.MothronBanner, ItemID.BrokenHeroSword, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            //Weapons
            AddBannerToItemRecipe(ItemID.ReaperBanner, ItemID.DeathSickle, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedMechBossAll);
            AddBannerToItemRecipe(ItemID.ButcherBanner, ItemID.ButchersChainsaw, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.DeadlySphereBanner, ItemID.DeadlySphereStaff, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.DrManFlyBanner, ItemID.ToxicFlask, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.MothronBanner, ItemID.TheEyeOfCthulhu, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.NailheadBanner, ItemID.NailGun, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.PsychoBanner, ItemID.PsychoKnife, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            //Misc Equips
            AddBannerToItemRecipe(ItemID.EyezorBanner, ItemID.EyeSpring, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedMechBossAny);
            //Misc
            #endregion

            #region Pumpkin Moon
            //Accessories
            //Armor/Vanity
            AddBannerToItemRecipe(ItemID.ScarecrowBanner, ItemID.ScarecrowPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.ScarecrowBanner, ItemID.ScarecrowShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.ScarecrowBanner, ItemID.ScarecrowHat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.HeadlessHorsemanBanner, ItemID.JackOLanternMask, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            //Food
            //Furniture
            //Materials
            //Weapons
            //Misc Equips
            //Misc
            #endregion

            #region Frost Moon
            //Accessories
            //Armor/Vanity
            AddBannerToItemRecipe(ItemID.ZombieElfBanner, ItemID.ElfPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.ZombieElfBanner, ItemID.ElfShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            AddBannerToItemRecipe(ItemID.ZombieElfBanner, ItemID.ElfHat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedPlantera);
            //Food
            //Furniture
            //Materials
            //Weapons
            //Misc Equips
            //Misc
            #endregion

            #region Martian Madness
            //Accessories
            //Armor/Vanity
            AddBannerToItemRecipe(ItemID.MartianGreyGruntBanner, ItemID.MartianCostumePants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedGolem);
            AddBannerToItemRecipe(ItemID.MartianGreyGruntBanner, ItemID.MartianCostumeShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedGolem);
            AddBannerToItemRecipe(ItemID.MartianGreyGruntBanner, ItemID.MartianCostumeMask, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedGolem);
            AddBannerToItemRecipe(ItemID.MartianRaygunnerBanner, ItemID.MartianCostumePants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedGolem);
            AddBannerToItemRecipe(ItemID.MartianRaygunnerBanner, ItemID.MartianCostumeShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedGolem);
            AddBannerToItemRecipe(ItemID.MartianRaygunnerBanner, ItemID.MartianCostumeMask, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedGolem);
            AddBannerToItemRecipe(ItemID.MartianBrainscramblerBanner, ItemID.MartianCostumePants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedGolem);
            AddBannerToItemRecipe(ItemID.MartianBrainscramblerBanner, ItemID.MartianCostumeShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedGolem);
            AddBannerToItemRecipe(ItemID.MartianBrainscramblerBanner, ItemID.MartianCostumeMask, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedGolem);
            AddBannerToItemRecipe(ItemID.MartianOfficerBanner, ItemID.MartianUniformPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedGolem);
            AddBannerToItemRecipe(ItemID.MartianOfficerBanner, ItemID.MartianUniformTorso, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedGolem);
            AddBannerToItemRecipe(ItemID.MartianOfficerBanner, ItemID.MartianUniformHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedGolem);
            AddBannerToItemRecipe(ItemID.MartianEngineerBanner, ItemID.MartianUniformPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedGolem);
            AddBannerToItemRecipe(ItemID.MartianEngineerBanner, ItemID.MartianUniformTorso, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedGolem);
            AddBannerToItemRecipe(ItemID.MartianEngineerBanner, ItemID.MartianUniformHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedGolem);
            AddBannerToItemRecipe(ItemID.MartianGigazapperBanner, ItemID.MartianUniformPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedGolem);
            AddBannerToItemRecipe(ItemID.MartianGigazapperBanner, ItemID.MartianUniformTorso, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedGolem);
            AddBannerToItemRecipe(ItemID.MartianGigazapperBanner, ItemID.MartianUniformHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedGolem);
            //Food
            //Furniture
            //Materials
            //Weapons
            //Misc Equips
            AddBannerToItemRecipe(ItemID.MartianScutlixGunnerBanner, ItemID.BrainScrambler, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedMartians);
            AddBannerToItemRecipe(ItemID.ScutlixBanner, ItemID.BrainScrambler, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.BannerRecipes), Condition.DownedMartians);
            //Misc
            #endregion

            #region Lunar Pillars
            //Accessories
            //Armor/Vanity
            //Food
            //Furniture
            //Materials
            //Weapons
            //Misc Equips
            //Misc
            #endregion
            #endregion
        }

        public static void GrabBagRecipes()
        {
            //Goodie Bag Recipes
            Common.CreateSimpleRecipe(ItemID.GoodieBag, ItemID.UnluckyYarn, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.CrateRecipes));
            Common.CreateSimpleRecipe(ItemID.GoodieBag, ItemID.BatHook, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.CrateRecipes));
            Common.CreateSimpleRecipe(ItemID.GoodieBag, ItemID.RottenEgg, TileID.WorkBenches, 1, 50, disableDecraft: true, usesRecipeGroup: false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.CrateRecipes));

            //Present Recipes
            Common.CreateSimpleRecipe(ItemID.Present, ItemID.SnowGlobe, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.CrateRecipes), Condition.Hardmode);
            Common.CreateSimpleRecipe(ItemID.Present, ItemID.DogWhistle, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.CrateRecipes));
            Common.CreateSimpleRecipe(ItemID.Present, ItemID.RedRyder, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.CrateRecipes));
            Common.CreateSimpleRecipe(ItemID.Present, ItemID.CandyCaneSword, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.CrateRecipes));
            Common.CreateSimpleRecipe(ItemID.Present, ItemID.CnadyCanePickaxe, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.CrateRecipes));
            Common.CreateSimpleRecipe(ItemID.Present, ItemID.CandyCaneHook, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.CrateRecipes));
            Common.CreateSimpleRecipe(ItemID.Present, ItemID.FruitcakeChakram, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.CrateRecipes));
            Common.CreateSimpleRecipe(ItemID.Present, ItemID.HandWarmer, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.CrateRecipes));
            Common.CreateSimpleRecipe(ItemID.Present, ItemID.Toolbox, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.CrateRecipes));
            Common.CreateSimpleRecipe(ItemID.Present, ItemID.StarAnise, TileID.WorkBenches, 1, 50, disableDecraft: true, usesRecipeGroup: false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.CrateRecipes));
        }

        public override void AddRecipeGroups()
        {
            IEnumerable<int> allItems = Enumerable.Range(0, ItemLoader.ItemCount);

            int[] GetItems(int iconicItem, Regex regex, params int[] ignore)
            {
                List<int> ids = allItems.Where(id => regex.IsMatch(ItemID.Search.GetName(id).ToLower())).ToList();

                ids.Remove(iconicItem);
                ids.Insert(0, iconicItem);

                foreach (int id in ignore)
                    ids.Remove(id);

                return ids.ToArray();
            }

            string any = Language.GetTextValue("LegacyMisc.37");

            #region Chairs, Doors, Torches
            List<int> chairItems = new();
            List<int> doorItems = new();
            List<int> torchItems = new();
            List<int> wellFedItems = new();
            List<int> plentySatisfiedItems = new();
            List<int> exquisitelyStuffedItems = new();
            List<int> gourmetFlavorItems = new();
            for (int i = 0; i < TextureAssets.Item.Length; i++)
            {
                Item item = new();
                item.SetDefaults(i);

                if (item.buffType == BuffID.WellFed)
                    wellFedItems.Add(item.type);
                else if (item.buffType == BuffID.WellFed2)
                    plentySatisfiedItems.Add(item.type);
                else if (item.buffType == BuffID.WellFed3)
                    exquisitelyStuffedItems.Add(item.type);
                else if (ModConditions.martainsOrderLoaded && item.buffType == Common.GetModBuff(ModConditions.martainsOrderMod, "Gourmet"))
                    gourmetFlavorItems.Add(item.type);

                if (!item.consumable || item.createTile < TileID.Dirt || (item.ModItem != null && item.ModItem.Mod == Mod))
                    continue;

                if (TileID.Sets.RoomNeeds.CountsAsChair.Contains(item.createTile))
                    chairItems.Add(item.type);

                if (TileID.Sets.RoomNeeds.CountsAsDoor.Contains(item.createTile))
                    doorItems.Add(item.type);

                if (TileID.Sets.RoomNeeds.CountsAsTorch.Contains(item.createTile))
                    torchItems.Add(item.type);
            }

            #endregion

            #region Anvils
            int[] anvilItems = { ItemID.IronAnvil, ItemID.LeadAnvil };
            if (ModConditions.exxoAvalonOriginsLoaded)
            {
                Array.Resize(ref anvilItems, anvilItems.Length + 1);
                anvilItems[^1] = Common.GetModItem(ModConditions.exxoAvalonOriginsMod, "NickelAnvil");
            }
            #endregion

            #region Hardmode Anvils
            int[] hardmodeAnvilItems = { ItemID.MythrilAnvil, ItemID.OrichalcumAnvil };
            if (ModConditions.exxoAvalonOriginsLoaded)
            {
                Array.Resize(ref hardmodeAnvilItems, hardmodeAnvilItems.Length + 1);
                hardmodeAnvilItems[^1] = Common.GetModItem(ModConditions.exxoAvalonOriginsMod, "NaquadahAnvil");
            }
            #endregion

            #region Hardmode Forges
            int[] hardmodeForgeItems = { ItemID.AdamantiteForge, ItemID.TitaniumForge };
            if (ModConditions.exxoAvalonOriginsLoaded)
            {
                Array.Resize(ref hardmodeForgeItems, hardmodeForgeItems.Length + 1);
                hardmodeForgeItems[^1] = Common.GetModItem(ModConditions.exxoAvalonOriginsMod, "TroxiniumForge");
            }
            #endregion

            #region Demon/Crimson Altars
            int[] altarItems = { ModContent.ItemType<DemonAltar>(), ModContent.ItemType<CrimsonAltar>() };
            if (ModConditions.exxoAvalonOriginsLoaded)
            {
                Array.Resize(ref altarItems, altarItems.Length + 3);
                altarItems[^3] = Common.GetModItem(ModConditions.exxoAvalonOriginsMod, "DemonAltar");
                altarItems[^2] = Common.GetModItem(ModConditions.exxoAvalonOriginsMod, "CrimsonAltar");
                altarItems[^1] = Common.GetModItem(ModConditions.exxoAvalonOriginsMod, "IckyAltar");
            }
            if (ModConditions.fargosMutantLoaded)
            {
                Array.Resize(ref altarItems, altarItems.Length + 2);
                altarItems[^2] = Common.GetModItem(ModConditions.fargosMutantMod, "DemonAltar");
                altarItems[^1] = Common.GetModItem(ModConditions.fargosMutantMod, "CrimsonAltar");
            }
            if (ModConditions.luiAFKLoaded)
            {
                Array.Resize(ref altarItems, altarItems.Length + 2);
                altarItems[^2] = Common.GetModItem(ModConditions.luiAFKMod, "CorruptionAltar");
                altarItems[^1] = Common.GetModItem(ModConditions.luiAFKMod, "CrimsonAltar");
            }
            if (ModConditions.magicStorageLoaded)
            {
                Array.Resize(ref altarItems, altarItems.Length + 2);
                altarItems[^2] = Common.GetModItem(ModConditions.magicStorageMod, "DemonAltar");
                altarItems[^1] = Common.GetModItem(ModConditions.magicStorageMod, "CrimsonAltar");
            }
            if (ModConditions.martainsOrderLoaded)
            {
                Array.Resize(ref altarItems, altarItems.Length + 1);
                altarItems[^1] = Common.GetModItem(ModConditions.martainsOrderMod, "DemonAltar");
            }
            if (ModConditions.thoriumLoaded)
            {
                Array.Resize(ref altarItems, altarItems.Length + 2);
                altarItems[^2] = Common.GetModItem(ModConditions.thoriumMod, "GrimPedestal");
                altarItems[^1] = Common.GetModItem(ModConditions.thoriumMod, "GrimPedestalCrimson");
            }
            #endregion

            RecipeGroup anvils = new(() => $"{any} {Lang.GetItemNameValue(ItemID.IronAnvil)}", anvilItems);
            RecipeGroup.RegisterGroup("QoLCompendium:Anvils", anvils);

            RecipeGroup hmAnvils = new(() => $"{any} {Lang.GetItemNameValue(ItemID.MythrilAnvil)}", hardmodeAnvilItems);
            RecipeGroup.RegisterGroup("QoLCompendium:HardmodeAnvils", hmAnvils);

            RecipeGroup hmForges = new(() => $"{any} {Lang.GetItemNameValue(ItemID.AdamantiteForge)}", hardmodeForgeItems);
            RecipeGroup.RegisterGroup("QoLCompendium:HardmodeForges", hmForges);

            RecipeGroup altars = new(() => $"{any} {Language.GetTextValue("MapObject.DemonAltar")}", altarItems);
            RecipeGroup.RegisterGroup("QoLCompendium:Altars", altars);

            int[] items = GetItems(ItemID.Chest, chestItemRegex);
            RecipeGroup chests = new(() => $"{any} {Lang.GetItemNameValue(ItemID.Chest)}", items);
            RecipeGroup.RegisterGroup("QoLCompendium:AnyChest", chests);
            RegisterGroupClone(chests, nameof(ItemID.Chest));

            items = GetItems(ItemID.WorkBench, workBenchItemRegex, ItemID.HeavyWorkBench);
            RecipeGroup workBenches = new(() => $"{any} {Lang.GetItemNameValue(ItemID.WorkBench)}", items);
            RecipeGroup.RegisterGroup("QoLCompendium:AnyWorkBench", workBenches);
            RegisterGroupClone(workBenches, nameof(ItemID.WorkBench));

            items = new int[] { ItemID.Bottle, ItemID.PinkVase, ItemID.Mug, ItemID.DynastyCup, ItemID.WineGlass, ItemID.HoneyCup, ItemID.SteampunkCup };
            RecipeGroup bottles = new(() => $"{any} {Lang.GetItemNameValue(ItemID.Bottle)}", items);
            RecipeGroup.RegisterGroup("QoLCompendium:AnyBottle", bottles);
            RegisterGroupClone(bottles, nameof(ItemID.Bottle));

            items = GetItems(ItemID.MetalSink, sinkItemRegex);
            RecipeGroup sinks = new(() => $"{any} {Language.GetTextValue("Mods.QoLCompendium.RecipeGroupNames.Sinks")}", items);
            RecipeGroup.RegisterGroup("QoLCompendium:AnySink", sinks);
            RegisterGroupClone(sinks, nameof(ItemID.MetalSink));

            items = GetItems(ItemID.WoodenTable, tableItemRegex, ItemID.BewitchingTable, ItemID.AlchemyTable, ItemID.WarTable);
            RecipeGroup tables = new(() => $"{any} {Language.GetTextValue("Mods.QoLCompendium.RecipeGroupNames.Tables")}", items);
            RecipeGroup.RegisterGroup("QoLCompendium:AnyTable", tables);
            RegisterGroupClone(tables, nameof(ItemID.WoodenTable));

            items = GetItems(ItemID.WoodenChair, chairItemRegex);
            RecipeGroup chairs = new(() => $"{any} {Language.GetTextValue("Mods.QoLCompendium.RecipeGroupNames.Chairs")}", items);
            RecipeGroup.RegisterGroup("QoLCompendium:AnyChair", chairs);
            RegisterGroupClone(chairs, nameof(ItemID.WoodenChair));

            RecipeGroup doors = new(() => $"{any} {Language.GetTextValue("Mods.QoLCompendium.RecipeGroupNames.Doors")}", doorItems.ToArray());
            RecipeGroup.RegisterGroup("QoLCompendium:AnyDoor", doors);
            RegisterGroupClone(doors, nameof(ItemID.WoodenDoor));
            
            RecipeGroup torches = new(() => $"{any} {Lang.GetItemNameValue(ItemID.Torch)}", torchItems.ToArray());
            RecipeGroup.RegisterGroup("QoLCompendium:AnyTorch", torches);
            RegisterGroupClone(torches, nameof(ItemID.Torch));

            items = new int[] { ItemID.CookingPot, ItemID.Cauldron };
            RecipeGroup cookingPots = new RecipeGroup(() => $"{any} {Lang.GetItemNameValue(ItemID.CookingPot)}", items);
            RecipeGroup.RegisterGroup("QoLCompendium:AnyCookingPot", cookingPots);
            RegisterGroupClone(cookingPots, nameof(ItemID.CookingPot));

            items = GetItems(ItemID.Bookcase, bookcaseItemRegex);
            RecipeGroup bookcases = new RecipeGroup(() => $"{any} {Lang.GetItemNameValue(ItemID.Bookcase)}", items);
            RecipeGroup.RegisterGroup("QoLCompendium:AnyBookcase", bookcases);
            RegisterGroupClone(bookcases, nameof(ItemID.Bookcase));

            RecipeGroup tombstones = new(() => $"{any} {Lang.GetItemNameValue(ItemID.Tombstone)}",
                ItemID.Tombstone, ItemID.GraveMarker,
                ItemID.CrossGraveMarker, ItemID.Headstone,
                ItemID.Gravestone, ItemID.Obelisk,
                ItemID.RichGravestone1, ItemID.RichGravestone2,
                ItemID.RichGravestone3, ItemID.RichGravestone4,
                ItemID.RichGravestone5);
            RecipeGroup.RegisterGroup("QoLCompendium:AnyTombstone", tombstones);

            /*
            RecipeGroup bookcases = new(() => $"{any} {Lang.GetItemNameValue(ItemID.Bookcase)}",
                ItemID.Bookcase, ItemID.BlueDungeonBookcase, ItemID.BoneBookcase, ItemID.BorealWoodBookcase,
                ItemID.CactusBookcase, ItemID.CrystalBookCase, ItemID.DynastyBookcase, ItemID.EbonwoodBookcase,
                ItemID.FleshBookcase, ItemID.FrozenBookcase, ItemID.GlassBookcase, ItemID.GoldenBookcase,
                ItemID.GothicBookcase, ItemID.GraniteBookcase, ItemID.GreenDungeonBookcase, ItemID.HoneyBookcase,
                ItemID.LivingWoodBookcase, ItemID.MarbleBookcase, ItemID.MeteoriteBookcase, ItemID.MushroomBookcase,
                ItemID.ObsidianBookcase, ItemID.PalmWoodBookcase, ItemID.PearlwoodBookcase, ItemID.PinkDungeonBookcase,
                ItemID.PumpkinBookcase, ItemID.RichMahoganyBookcase, ItemID.ShadewoodBookcase, ItemID.SkywareBookcase,
                ItemID.SlimeBookcase, ItemID.SpookyBookcase, ItemID.SteampunkBookcase, ItemID.AshWoodBookcase);
            RecipeGroup.RegisterGroup("QoLCompendium:Bookcases", bookcases);
            */

            /*
            RecipeGroup tables = new(() => $"{any} {Lang.GetItemNameValue(ItemID.WoodenTable)}",
                ItemID.WoodenTable,
                ItemID.BorealWoodTable,
                ItemID.AshWoodTable,
                ItemID.RichMahoganyTable,
                ItemID.LivingWoodTable,
                ItemID.PearlwoodTable,
                ItemID.SpookyTable,
                ItemID.EbonwoodTable,
                ItemID.ShadewoodTable,
                ItemID.PalmWoodTable,
                ItemID.DynastyTable,
                ItemID.BambooTable);
            RecipeGroup.RegisterGroup("QoLCompendium:WoodenTables", tables);
            */

            /*
            RecipeGroup chairs = new(() => $"{any} {Lang.GetItemNameValue(ItemID.WoodenChair)}",
                ItemID.WoodenChair,
                ItemID.BorealWoodChair,
                ItemID.AshWoodChair,
                ItemID.RichMahoganyChair,
                ItemID.LivingWoodChair,
                ItemID.PearlwoodChair,
                ItemID.SpookyChair,
                ItemID.EbonwoodChair,
                ItemID.ShadewoodChair,
                ItemID.PalmWoodChair,
                ItemID.DynastyChair,
                ItemID.BambooChair);
            RecipeGroup.RegisterGroup("QoLCompendium:WoodenChairs", chairs);
            */

            /*
            RecipeGroup sinks = new(() => $"{any} {Lang.GetItemNameValue(ItemID.WoodenSink)}",
                ItemID.WoodenSink,
                ItemID.BorealWoodSink,
                ItemID.AshWoodSink,
                ItemID.RichMahoganySink,
                ItemID.LivingWoodSink,
                ItemID.PearlwoodSink,
                ItemID.SpookySink,
                ItemID.EbonwoodSink,
                ItemID.ShadewoodSink,
                ItemID.PalmWoodSink,
                ItemID.DynastySink,
                ItemID.BambooSink);
            RecipeGroup.RegisterGroup("QoLCompendium:WoodenSinks", sinks);
            */

            RecipeGroup goldBars = new(() => $"{any} {Lang.GetItemNameValue(ItemID.GoldBar)}",
                ItemID.GoldBar, ItemID.PlatinumBar);
            RecipeGroup.RegisterGroup("QoLCompendium:GoldBars", goldBars);

            #region BANNER GROUPS
            RecipeGroup pirateBanners = new(() => $"{any} {Language.GetTextValue("Mods.QoLCompendium.RecipeGroupNames.AnyPirateBanner")}",
                ItemID.PirateDeadeyeBanner,
                ItemID.PirateCorsairBanner,
                ItemID.PirateCrossbowerBanner,
                ItemID.PirateBanner);
            Common.AnyPirateBanner = RecipeGroup.RegisterGroup("QoLCompendium:AnyPirateBanner", pirateBanners);

            RecipeGroup armoredBonesBanners = new(() => $"{any} {Language.GetTextValue("Mods.QoLCompendium.RecipeGroupNames.AnyArmoredBonesBanner")}",
                ItemID.BlueArmoredBonesBanner,
                ItemID.HellArmoredBonesBanner,
                ItemID.RustyArmoredBonesBanner);
            Common.AnyArmoredBonesBanner = RecipeGroup.RegisterGroup("QoLCompendium:AnyArmoredBonesBanner", armoredBonesBanners);

            RecipeGroup slimeBanners = new(() => $"{any} {Language.GetTextValue("Mods.QoLCompendium.RecipeGroupNames.AnySlimeBanner")}",
                ItemID.SlimeBanner,
                ItemID.GreenSlimeBanner,
                ItemID.RedSlimeBanner,
                ItemID.PurpleSlimeBanner,
                ItemID.YellowSlimeBanner,
                ItemID.BlackSlimeBanner,
                ItemID.IceSlimeBanner,
                ItemID.SandSlimeBanner,
                ItemID.JungleSlimeBanner,
                ItemID.SpikedIceSlimeBanner,
                ItemID.SpikedJungleSlimeBanner,
                ItemID.MotherSlimeBanner,
                ItemID.UmbrellaSlimeBanner,
                ItemID.ToxicSludgeBanner,
                ItemID.CorruptSlimeBanner,
                ItemID.SlimerBanner,
                ItemID.CrimslimeBanner,
                ItemID.GastropodBanner,
                ItemID.IlluminantSlimeBanner,
                ItemID.RainbowSlimeBanner);
            Common.AnySlimeBanner = RecipeGroup.RegisterGroup("QoLCompendium:AnySlimeBanner", slimeBanners);

            RecipeGroup hallowBanners = new(() => $"{any} {Language.GetTextValue("Mods.QoLCompendium.RecipeGroupNames.AnyHallowBanner")}",
                ItemID.PixieBanner,
                ItemID.UnicornBanner,
                ItemID.RainbowSlimeBanner,
                ItemID.GastropodBanner,
                ItemID.LightMummyBanner,
                ItemID.IlluminantBatBanner,
                ItemID.IlluminantSlimeBanner,
                ItemID.ChaosElementalBanner,
                ItemID.EnchantedSwordBanner,
                ItemID.BigMimicHallowBanner);
            Common.AnyHallowBanner = RecipeGroup.RegisterGroup("QoLCompendium:AnyHallowBanner", hallowBanners);

            RecipeGroup corruptionBanners = new(() => $"{any} {Language.GetTextValue("Mods.QoLCompendium.RecipeGroupNames.AnyCorruptionBanner")}",
                ItemID.EaterofSoulsBanner,
                ItemID.CorruptorBanner,
                ItemID.CorruptSlimeBanner,
                ItemID.SlimerBanner,
                ItemID.DevourerBanner,
                ItemID.WorldFeederBanner,
                ItemID.DarkMummyBanner,
                ItemID.CursedHammerBanner,
                ItemID.ClingerBanner,
                ItemID.BigMimicCorruptionBanner);
            Common.AnyCorruptionBanner = RecipeGroup.RegisterGroup("QoLCompendium:AnyCorruptionBanner", corruptionBanners);

            RecipeGroup crimsonBanners = new(() => $"{any} {Language.GetTextValue("Mods.QoLCompendium.RecipeGroupNames.AnyCrimsonBanner")}",
                ItemID.BloodCrawlerBanner,
                ItemID.FaceMonsterBanner,
                ItemID.CrimeraBanner,
                ItemID.HerplingBanner,
                ItemID.CrimslimeBanner,
                ItemID.BloodJellyBanner,
                ItemID.BloodFeederBanner,
                ItemID.BloodMummyBanner,
                ItemID.CrimsonAxeBanner,
                ItemID.IchorStickerBanner,
                ItemID.FloatyGrossBanner,
                ItemID.BigMimicCrimsonBanner);
            Common.AnyCrimsonBanner = RecipeGroup.RegisterGroup("QoLCompendium:AnyCrimsonBanner", crimsonBanners);

            RecipeGroup jungleBanners = new(() => $"{any} {Language.GetTextValue("Mods.QoLCompendium.RecipeGroupNames.AnyJungleBanner")}",
                ItemID.PiranhaBanner,
                ItemID.SnatcherBanner,
                ItemID.JungleBatBanner,
                ItemID.JungleSlimeBanner,
                ItemID.DoctorBonesBanner,
                ItemID.AnglerFishBanner,
                ItemID.ArapaimaBanner,
                ItemID.TortoiseBanner,
                ItemID.AngryTrapperBanner,
                ItemID.DerplingBanner,
                ItemID.GiantFlyingFoxBanner,
                ItemID.HornetBanner,
                ItemID.SpikedJungleSlimeBanner,
                ItemID.JungleCreeperBanner,
                ItemID.MothBanner,
                ItemID.ManEaterBanner,
                ItemID.MossHornetBanner);
            Common.AnyJungleBanner = RecipeGroup.RegisterGroup("QoLCompendium:AnyJungleBanner", jungleBanners);

            RecipeGroup snowBanners = new(() => $"{any} {Language.GetTextValue("Mods.QoLCompendium.RecipeGroupNames.AnySnowBanner")}",
                ItemID.IceSlimeBanner,
                ItemID.ZombieEskimoBanner,
                ItemID.IceElementalBanner,
                ItemID.WolfBanner,
                ItemID.IceGolemBanner,
                ItemID.IceBatBanner,
                ItemID.SnowFlinxBanner,
                ItemID.SpikedIceSlimeBanner,
                ItemID.UndeadVikingBanner,
                ItemID.ArmoredVikingBanner,
                ItemID.IceTortoiseBanner,
                ItemID.IcyMermanBanner,
                ItemID.PigronBanner);
            Common.AnySnowBanner = RecipeGroup.RegisterGroup("QoLCompendium:AnySnowBanner", snowBanners);

            RecipeGroup desertBanners = new(() => $"{any} {Language.GetTextValue("Mods.QoLCompendium.RecipeGroupNames.AnyDesertBanner")}",
                ItemID.VultureBanner,
                ItemID.MummyBanner,
                ItemID.BloodMummyBanner,
                ItemID.DarkMummyBanner,
                ItemID.LightMummyBanner,
                ItemID.FlyingAntlionBanner,
                ItemID.WalkingAntlionBanner,
                ItemID.LarvaeAntlionBanner,
                ItemID.AntlionBanner,
                ItemID.SandSlimeBanner,
                ItemID.TombCrawlerBanner,
                ItemID.DesertBasiliskBanner,
                ItemID.RavagerScorpionBanner,
                ItemID.DesertLamiaBanner,
                ItemID.DesertGhoulBanner,
                ItemID.DesertDjinnBanner,
                ItemID.DuneSplicerBanner,
                ItemID.SandElementalBanner,
                ItemID.SandsharkBanner,
                ItemID.SandsharkCorruptBanner,
                ItemID.SandsharkCrimsonBanner,
                ItemID.SandsharkHallowedBanner,
                ItemID.TumbleweedBanner);
            Common.AnyDesertBanner = RecipeGroup.RegisterGroup("QoLCompendium:AnyDesertBanner", desertBanners);

            RecipeGroup underworldBanners = new(() => $"{any} {Language.GetTextValue("Mods.QoLCompendium.RecipeGroupNames.AnyUnderworldBanner")}",
                ItemID.HellbatBanner,
                ItemID.LavaSlimeBanner,
                ItemID.FireImpBanner,
                ItemID.DemonBanner,
                ItemID.BoneSerpentBanner,
                ItemID.LavaBatBanner,
                ItemID.RedDevilBanner);
            Common.AnyUnderworldBanner = RecipeGroup.RegisterGroup("QoLCompendium:AnyUnderworldBanner", underworldBanners);

            RecipeGroup batBanners = new(() => $"{any} {Language.GetTextValue("Mods.QoLCompendium.RecipeGroupNames.AnyBatBanner")}",
                ItemID.BatBanner,
                ItemID.GiantBatBanner,
                ItemID.GiantFlyingFoxBanner,
                ItemID.IceBatBanner,
                ItemID.IlluminantBatBanner,
                ItemID.JungleBatBanner,
                ItemID.HellbatBanner,
                ItemID.LavaBatBanner,
                ItemID.SporeBatBanner);
            Common.AnyBatBanner = RecipeGroup.RegisterGroup("QoLCompendium:AnyBatBanner", batBanners);

            RecipeGroup fishingBobbers = new(() => $"{any} {Lang.GetItemNameValue(ItemID.FishingBobber)}",
                ItemID.FishingBobber,
                ItemID.FishingBobberGlowingStar,
                ItemID.FishingBobberGlowingArgon,
                ItemID.FishingBobberGlowingKrypton,
                ItemID.FishingBobberGlowingLava,
                ItemID.FishingBobberGlowingRainbow,
                ItemID.FishingBobberGlowingViolet,
                ItemID.FishingBobberGlowingXenon);
            RecipeGroup.RegisterGroup("QoLCompendium:FishingBobbers", fishingBobbers);

            RecipeGroup.RegisterGroup("QoLCompendium:WellFed", new(() => $"{any} {Language.GetTextValue("Mods.QoLCompendium.RecipeGroupNames.WellFed")}", wellFedItems.ToArray()));
            RecipeGroup.RegisterGroup("QoLCompendium:PlentySatisfied", new(() => $"{any} {Language.GetTextValue("Mods.QoLCompendium.RecipeGroupNames.PlentySatisfied")}", plentySatisfiedItems.ToArray()));
            RecipeGroup.RegisterGroup("QoLCompendium:ExquisitelyStuffed", new(() => $"{any} {Language.GetTextValue("Mods.QoLCompendium.RecipeGroupNames.ExquisitelyStuffed")}", exquisitelyStuffedItems.ToArray()));
            if (ModConditions.martainsOrderLoaded && gourmetFlavorItems.Count > 0)
                RecipeGroup.RegisterGroup("QoLCompendium:GourmetFlavor", new(() => $"{any} {Language.GetTextValue("Mods.QoLCompendium.RecipeGroupNames.GourmetFlavor")}", gourmetFlavorItems.ToArray()));
            #endregion
        }

        //Magic Storage
        private static void RegisterGroupClone(RecipeGroup original, string groupName)
        {
            // If the group already exists, union the sets and overwrite the reference
            // Otherwise, make a new group that's a copy of the original group
            if (RecipeGroup.recipeGroupIDs.TryGetValue(groupName, out int groupID))
            {
                RecipeGroup group = RecipeGroup.recipeGroups[groupID];
                original.ValidItems.UnionWith(group.ValidItems);
                group.ValidItems = original.ValidItems;
            }
            else
            {
                RecipeGroup group = new RecipeGroup(original.GetText, new int[1]);
                group.ValidItems = original.ValidItems;
                RecipeGroup.RegisterGroup(groupName, group);
            }
        }
    }
}