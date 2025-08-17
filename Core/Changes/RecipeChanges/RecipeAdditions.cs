using QoLCompendium.Content.Items.Placeables.Pylons;
using QoLCompendium.Content.Items.Tools.Usables;
using QoLCompendium.Content.Tiles.CraftingStations;

namespace QoLCompendium.Core.Changes.RecipeChanges
{
    public class RecipeAdditions : ModSystem
    {
        public override void AddRecipes()
        {
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

            if (QoLCompendium.mainConfig.FullyDisableRecipes)
                return;

            //Major Recipe Creation
            ConversionRecipes();
            CrateRecipes();
            BagRecipes();
            BannerRecipes();
            GrabBagRecipes();
            OtherRecipes();
            NewRecipes();
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
                //Common.Common.ConversionRecipe(Common.Common.GetModItem(ModConditions.confectionRebakedMod, ""), Common.Common.GetModItem(ModConditions.confectionRebakedMod, ""), TileID.Anvils);
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

            #region Martin's Order
            if (ModConditions.martainsOrderLoaded)
            {
                Common.ConversionRecipe(Common.GetModItem(ModConditions.martainsOrderMod, "CorruptedHerb"), Common.GetModItem(ModConditions.martainsOrderMod, "CrimsonHerb"), TileID.Anvils);
                Common.ConversionRecipe(ItemID.WormTooth, Common.GetModItem(ModConditions.martainsOrderMod, "BloodVein"), TileID.Anvils);
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

                //Vanilla Crate Drops
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "FrozenTiara"), ItemID.FrozenCrate, ItemID.FrozenCrateHard, 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "ForestOcarina"), ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "TheDigester"), ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "FanLetter2"), ItemID.CorruptFishingCrate, ItemID.CorruptFishingCrateHard, 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "FanLetter"), ItemID.CrimsonFishingCrate, ItemID.CrimsonFishingCrateHard, 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "DarkHeart"), ItemID.CorruptFishingCrate, ItemID.CorruptFishingCrateHard, 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "DarkHeart"), ItemID.CrimsonFishingCrate, ItemID.CrimsonFishingCrateHard, 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "LightningClaves"), ItemID.OasisCrate, ItemID.OasisCrateHard, 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "BubbleMagnet"), ItemID.OceanCrate, ItemID.OceanCrateHard, 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "Flute"), ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "RecoveryWand"), ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "EnchantedPickaxe"), ItemID.GoldenCrate, ItemID.GoldenCrateHard, 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "EnchantedCane"), ItemID.GoldenCrate, ItemID.GoldenCrateHard, 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "EnchantedStaff"), ItemID.GoldenCrate, ItemID.GoldenCrateHard, 1);
                Common.CreateCrateRecipe(Common.GetModItem(ModConditions.thoriumMod, "FishHat"), ItemID.GoldenCrate, ItemID.GoldenCrateHard, 1);
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
            Common.AddBannerToItemRecipe(ItemID.JellyfishBanner, ItemID.JellyfishNecklace, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.GreenJellyfishBanner, ItemID.JellyfishNecklace, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.SkeletonArcherBanner, ItemID.MagicQuiver, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.TitanGlove, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.PhilosophersStone, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.CrossNecklace, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.StarCloak, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.ToxicSludgeBanner, ItemID.Bezoar, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.AnglerFishBanner, ItemID.AdhesiveBandage, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.ArmoredSkeletonBanner, ItemID.ArmorPolish, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.GiantBatBanner, ItemID.TrifoldMap, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.GreenJellyfishBanner, ItemID.Megaphone, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.MedusaBanner, ItemID.PocketMirror, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.CrawdadBanner, ItemID.Compass, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.GiantShellyBanner, ItemID.Compass, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.MotherSlimeBanner, ItemID.Compass, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.PiranhaBanner, ItemID.Compass, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.SalamanderBanner, ItemID.Compass, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.BatBanner, ItemID.DepthMeter, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.CrawdadBanner, ItemID.DepthMeter, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.GiantBatBanner, ItemID.DepthMeter, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.GiantShellyBanner, ItemID.DepthMeter, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.SalamanderBanner, ItemID.DepthMeter, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.NypmhBanner, ItemID.MetalDetector, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Armor/Vanity
            Common.AddBannerToItemRecipe(ItemID.GraniteFlyerBanner, ItemID.NightVisionHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.GraniteGolemBanner, ItemID.NightVisionHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.GreekSkeletonBanner, ItemID.GladiatorLeggings, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.GreekSkeletonBanner, ItemID.GladiatorBreastplate, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.GreekSkeletonBanner, ItemID.GladiatorHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.SkeletonBanner, ItemID.AncientIronHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.SkeletonBanner, ItemID.AncientGoldHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.UndeadMinerBanner, ItemID.MiningPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.UndeadMinerBanner, ItemID.MiningShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.UndeadMinerBanner, ItemID.MiningHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.RockGolemBanner, ItemID.RockGolemHead, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.AnglerFishBanner, ItemID.RobotHat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Food
            Common.AddBannerToItemRecipe(ItemID.SalamanderBanner, ItemID.PotatoChips, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.CrawdadBanner, ItemID.PotatoChips, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.GiantShellyBanner, ItemID.PotatoChips, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerSetToItemRecipe(NPCID.Sets.Skeletons, ItemID.MilkCarton);
            Common.AddBannerToItemRecipe(ItemID.SpiderBanner, ItemID.FriedEgg, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.BlackRecluseBanner, ItemID.FriedEgg, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.GreekSkeletonBanner, ItemID.Pizza, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.MedusaBanner, ItemID.Pizza, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.GraniteGolemBanner, ItemID.Spaghetti, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.GraniteFlyerBanner, ItemID.Spaghetti, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.UndeadMinerBanner, ItemID.Steak, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Furniture
            //Materials
            //Weapons
            Common.AddBannerGroupToItemRecipe(Common.AnyBatBanner, ItemID.BatBat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.BatBanner, ItemID.ChainKnife, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.NotRemixWorld);
            Common.AddBannerToItemRecipe(ItemID.CrawdadBanner, ItemID.Rally, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.GiantShellyBanner, ItemID.Rally, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.SalamanderBanner, ItemID.Rally, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.SkeletonBanner, ItemID.BoneSword, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.UndeadMinerBanner, ItemID.BonePickaxe, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.FlowerofFrost, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.Frostbrand, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.IceBow, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.MagicDagger, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.GreekSkeletonBanner, ItemID.Gladius, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.SkeletonArcherBanner, ItemID.Marrow, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.ArmoredSkeletonBanner, ItemID.BeamSword, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.MedusaBanner, ItemID.MedusaHead, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.GiantBatBanner, ItemID.ChainKnife, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode, Condition.NotRemixWorld);
            Common.AddBannerToItemRecipe(ItemID.BlackRecluseBanner, ItemID.PoisonStaff, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Misc Equips
            Common.AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.DualHook, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.MimicBanner, ItemID.ToySled, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Misc
            Common.AddBannerToItemRecipe(ItemID.WormBanner, ItemID.WhoopieCushion, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            #endregion

            #region Underworld
            //Accessories
            Common.AddBannerToItemRecipe(ItemID.FireImpBanner, ItemID.ObsidianRose, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.HellbatBanner, ItemID.MagmaStone, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.LavaBatBanner, ItemID.MagmaStone, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Armor/Vanity
            //Food
            Common.AddBannerToItemRecipe(ItemID.BoneSerpentBanner, ItemID.Hotdog, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.RedDevilBanner, ItemID.Hotdog, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMechBossAny);
            //Furniture
            //Materials
            Common.AddBannerToItemRecipe(ItemID.RedDevilBanner, ItemID.FireFeather, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMechBossAny);
            //Weapons
            Common.AddBannerToItemRecipe(ItemID.DemonBanner, ItemID.DemonScythe, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerGroupToItemRecipe(Common.AnyUnderworldBanner, ItemID.Cascade, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedSkeletron);
            Common.AddBannerGroupToItemRecipe(Common.AnyUnderworldBanner, ItemID.HelFire, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.RedDevilBanner, ItemID.UnholyTrident, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMechBossAny);
            //Misc Equips
            //Misc
            #endregion

            #region Sky
            //Accessories
            //Armor/Vanity
            //Food
            Common.AddBannerToItemRecipe(ItemID.HarpyBanner, ItemID.ChickenNugget, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Furniture
            //Materials
            Common.AddBannerToItemRecipe(ItemID.HarpyBanner, ItemID.GiantHarpyFeather, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Weapons
            //Misc Equips
            //Misc
            #endregion

            #region Snow
            //Accessories
            Common.AddBannerToItemRecipe(ItemID.IceTortoiseBanner, ItemID.FrozenTurtleShell, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.ArmoredVikingBanner, ItemID.Compass, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.SnowFlinxBanner, ItemID.Compass, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.UndeadVikingBanner, ItemID.Compass, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.IceBatBanner, ItemID.DepthMeter, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Armor/Vanity
            Common.AddBannerToItemRecipe(ItemID.UndeadVikingBanner, ItemID.VikingHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.ArmoredVikingBanner, ItemID.VikingHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.ZombieEskimoBanner, ItemID.EskimoPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.ZombieEskimoBanner, ItemID.EskimoCoat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.ZombieEskimoBanner, ItemID.EskimoHood, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Food
            Common.AddBannerToItemRecipe(ItemID.IceSlimeBanner, ItemID.IceCream, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.IceBatBanner, ItemID.IceCream, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.SpikedIceSlimeBanner, ItemID.IceCream, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.IcyMermanBanner, ItemID.Milkshake, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.IceTortoiseBanner, ItemID.Milkshake, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.PigronBanner, ItemID.Bacon, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Furniture
            //Materials
            Common.AddBannerToItemRecipe(ItemID.IceGolemBanner, ItemID.IceFeather, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMechBossAny);
            //Weapons
            Common.AddBannerToItemRecipe(ItemID.SnowFlinxBanner, ItemID.SnowballLauncher, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerGroupToItemRecipe(Common.AnySnowBanner, ItemID.Amarok, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.ArmoredVikingBanner, ItemID.IceSickle, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.IcyMermanBanner, ItemID.FrostStaff, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.PigronBanner, ItemID.HamBat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Misc Equips
            Common.AddBannerToItemRecipe(ItemID.PigronBanner, ItemID.PigronMinecart, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.WolfBanner, ItemID.WolfMountItem, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Misc
            Common.AddBannerGroupToItemRecipe(Common.AnySnowBanner, ItemID.FrozenKey, 1, 5, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            #endregion

            #region Desert
            //Accessories
            Common.AddBannerToItemRecipe(ItemID.MummyBanner, ItemID.FastClock, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Armor/Vanity
            Common.AddBannerToItemRecipe(ItemID.DesertDjinnBanner, ItemID.DjinnsCurse, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.DesertLamiaBanner, ItemID.LamiaPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.DesertLamiaBanner, ItemID.LamiaShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.DesertLamiaBanner, ItemID.LamiaHat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.DesertLamiaBanner, ItemID.MoonMask, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.DesertLamiaBanner, ItemID.SunMask, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.MummyBanner, ItemID.MummyPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.MummyBanner, ItemID.MummyShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.MummyBanner, ItemID.MummyMask, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Food
            Common.AddBannerToItemRecipe(ItemID.AntlionBanner, ItemID.BananaSplit, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.WalkingAntlionBanner, ItemID.BananaSplit, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.FlyingAntlionBanner, ItemID.BananaSplit, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.TumbleweedBanner, ItemID.Nachos, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.RavagerScorpionBanner, ItemID.FriedEgg, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.SandsharkBanner, ItemID.Nachos, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Furniture
            //Materials
            //Weapons
            Common.AddBannerToItemRecipe(ItemID.WalkingAntlionBanner, ItemID.AntlionClaw, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Misc Equips
            Common.AddBannerToItemRecipe(ItemID.DesertBasiliskBanner, ItemID.AncientHorn, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Misc
            Common.AddBannerGroupToItemRecipe(Common.AnyDesertBanner, ItemID.DungeonDesertKey, 1, 5, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            #endregion

            #region Ocean
            //Accessories
            Common.AddBannerToItemRecipe(ItemID.SharkBanner, ItemID.DivingHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.PinkJellyfishBanner, ItemID.JellyfishNecklace, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Armor/Vanity
            //Food
            Common.AddBannerToItemRecipe(ItemID.SharkBanner, ItemID.ShrimpPoBoy, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.CrabBanner, ItemID.ShrimpPoBoy, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Furniture
            //Materials
            //Weapons
            //Misc Equips
            //Misc
            #endregion

            #region Jungle
            //Accessories
            Common.AddBannerToItemRecipe(ItemID.HornetBanner, ItemID.Bezoar, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.MossHornetBanner, ItemID.Bezoar, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.JungleBatBanner, ItemID.DepthMeter, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Armor/Vanity
            Common.AddBannerToItemRecipe(ItemID.HornetBanner, ItemID.AncientCobaltLeggings, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.HornetBanner, ItemID.AncientCobaltBreastplate, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.HornetBanner, ItemID.AncientCobaltHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.PiranhaBanner, ItemID.RobotHat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Food
            Common.AddBannerToItemRecipe(ItemID.ManEaterBanner, ItemID.CoffeeCup, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.SnatcherBanner, ItemID.CoffeeCup, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.AngryTrapperBanner, ItemID.CoffeeCup, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.GiantFlyingFoxBanner, ItemID.Grapes, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.DerplingBanner, ItemID.Grapes, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Furniture
            //Materials
            Common.AddBannerToItemRecipe(ItemID.MossHornetBanner, ItemID.TatteredBeeWing, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMechBossAny);
            Common.AddBannerToItemRecipe(ItemID.MothBanner, ItemID.ButterflyDust, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMechBossAny);
            //Weapons
            Common.AddBannerToItemRecipe(ItemID.AngryTrapperBanner, ItemID.Uzi, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerGroupToItemRecipe(Common.AnyJungleBanner, ItemID.Yelets, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMechBossAny);
            //Misc Equips
            //Misc
            Common.AddBannerGroupToItemRecipe(Common.AnyJungleBanner, ItemID.JungleKey, 1, 5, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            #endregion

            #region Temple
            //Accessories
            //Armor/Vanity
            //Food
            //Furniture
            //Materials
            //Weapons
            //Misc Equips
            Common.AddBannerToItemRecipe(ItemID.LihzahrdBanner, ItemID.LizardEgg, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            //Misc
            #endregion

            #region Glowing Mushroom
            //Accessories
            Common.AddBannerToItemRecipe(ItemID.SporeBatBanner, ItemID.DepthMeter, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Armor/Vanity
            //Food
            //Furniture
            //Materials
            //Weapons
            Common.AddBannerToItemRecipe(ItemID.SporeBatBanner, ItemID.Shroomerang, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Misc Equips
            //Misc
            #endregion

            #region Corruption
            //Accessories
            Common.AddBannerToItemRecipe(ItemID.CursedHammerBanner, ItemID.Nazar, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.DarkMummyBanner, ItemID.Blindfold, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.DarkMummyBanner, ItemID.Megaphone, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.CorruptSlimeBanner, ItemID.Blindfold, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.CorruptorBanner, ItemID.Vitamins, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Armor/Vanity
            Common.AddBannerToItemRecipe(ItemID.EaterofSoulsBanner, ItemID.AncientShadowGreaves, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.EaterofSoulsBanner, ItemID.AncientShadowScalemail, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.EaterofSoulsBanner, ItemID.AncientShadowHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.CorruptBunnyBanner, ItemID.BunnyHood, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.CorruptPenguinBanner, ItemID.PedguinPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.CorruptPenguinBanner, ItemID.PedguinShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.CorruptPenguinBanner, ItemID.PedguinHat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.DarkMummyBanner, ItemID.MummyPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.DarkMummyBanner, ItemID.MummyShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.DarkMummyBanner, ItemID.MummyMask, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Food
            Common.AddBannerToItemRecipe(ItemID.EaterofSoulsBanner, ItemID.Burger, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.SandsharkCorruptBanner, ItemID.Nachos, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Furniture
            Common.AddBannerGroupToItemRecipe(Common.AnyCorruptionBanner, ItemID.MeatGrinder, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Materials
            //Weapons
            Common.AddBannerToItemRecipe(ItemID.EaterofSoulsBanner, ItemID.TentacleSpike, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Misc Equips
            //Misc
            Common.AddBannerGroupToItemRecipe(Common.AnyCorruptionBanner, ItemID.CorruptionKey, 1, 5, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            #endregion

            #region Crimson
            //Accessories
            Common.AddBannerToItemRecipe(ItemID.CrimsonAxeBanner, ItemID.Nazar, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.BloodMummyBanner, ItemID.Blindfold, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.BloodMummyBanner, ItemID.Megaphone, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.CrimslimeBanner, ItemID.Blindfold, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.FloatyGrossBanner, ItemID.Vitamins, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Armor/Vanity
            Common.AddBannerToItemRecipe(ItemID.CrimsonBunnyBanner, ItemID.BunnyHood, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.CrimsonPenguinBanner, ItemID.PedguinPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.CrimsonPenguinBanner, ItemID.PedguinShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.CrimsonPenguinBanner, ItemID.PedguinHat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.BloodMummyBanner, ItemID.MummyPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.BloodMummyBanner, ItemID.MummyShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.BloodMummyBanner, ItemID.MummyMask, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Food
            Common.AddBannerToItemRecipe(ItemID.CrimeraBanner, ItemID.Burger, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.SandsharkCrimsonBanner, ItemID.Nachos, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Furniture
            Common.AddBannerGroupToItemRecipe(Common.AnyCrimsonBanner, ItemID.MeatGrinder, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Materials
            //Weapons
            Common.AddBannerToItemRecipe(ItemID.BloodCrawlerBanner, ItemID.TentacleSpike, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.CrimeraBanner, ItemID.TentacleSpike, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.FaceMonsterBanner, ItemID.TentacleSpike, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Misc Equips
            //Misc
            Common.AddBannerGroupToItemRecipe(Common.AnyCrimsonBanner, ItemID.CrimsonKey, 1, 5, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            #endregion

            #region Hallow
            //Accessories
            Common.AddBannerToItemRecipe(ItemID.EnchantedSwordBanner, ItemID.Nazar, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.LightMummyBanner, ItemID.TrifoldMap, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.PixieBanner, ItemID.Megaphone, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.PixieBanner, ItemID.FastClock, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Armor/Vanity
            Common.AddBannerToItemRecipe(ItemID.LightMummyBanner, ItemID.MummyPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.LightMummyBanner, ItemID.MummyShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.LightMummyBanner, ItemID.MummyMask, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Food
            Common.AddBannerToItemRecipe(ItemID.SandsharkHallowedBanner, ItemID.Nachos, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.ChaosElementalBanner, ItemID.ApplePie, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.IlluminantBatBanner, ItemID.ApplePie, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.IlluminantSlimeBanner, ItemID.ApplePie, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.GastropodBanner, ItemID.ChocolateChipCookie, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Furniture
            //Materials
            //Weapons
            //Misc Equips
            Common.AddBannerToItemRecipe(ItemID.UnicornBanner, ItemID.BlessedApple, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Misc
            Common.AddBannerToItemRecipe(ItemID.ChaosElementalBanner, ItemID.RodofDiscord, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.UnicornBanner, ItemID.UnicornonaStick, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerGroupToItemRecipe(Common.AnyHallowBanner, ItemID.HallowedKey, 1, 5, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            #endregion

            #region Dungeon
            //Accessories
            Common.AddBannerToItemRecipe(ItemID.BoneLeeBanner, ItemID.BlackBelt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.BoneLeeBanner, ItemID.Tabi, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.SkeletonSniperBanner, ItemID.RifleScope, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.PaladinBanner, ItemID.PaladinsShield, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.CursedSkullBanner, ItemID.Nazar, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.GiantCursedSkullBanner, ItemID.Nazar, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.RustyArmoredBonesBanner, ItemID.AdhesiveBandage, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.BlueArmoredBonesBanner, ItemID.ArmorPolish, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.AngryBonesBanner, ItemID.TallyCounter, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.CursedSkullBanner, ItemID.TallyCounter, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.SkeletonMageBanner, ItemID.TallyCounter, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Armor/Vanity
            Common.AddBannerToItemRecipe(ItemID.AngryBonesBanner, ItemID.AncientNecroHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.SkeletonMageBanner, ItemID.AncientNecroHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.TacticalSkeletonBanner, ItemID.SWATHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            //Food
            Common.AddBannerToItemRecipe(ItemID.CursedSkullBanner, ItemID.CreamSoda, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.BoneLeeBanner, ItemID.CoffeeCup, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.GiantCursedSkullBanner, ItemID.CreamSoda, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.SkeletonCommandoBanner, ItemID.BBQRibs, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.SkeletonSniperBanner, ItemID.BBQRibs, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.TacticalSkeletonBanner, ItemID.BBQRibs, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            //Furniture
            //Materials
            Common.AddBannerGroupToItemRecipe(Common.AnyArmoredBonesBanner, ItemID.BoneFeather, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Weapons
            Common.AddBannerGroupToItemRecipe(Common.AnyArmoredBonesBanner, ItemID.Keybrand, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerGroupToItemRecipe(Common.AnyArmoredBonesBanner, ItemID.Kraken, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerGroupToItemRecipe(Common.AnyArmoredBonesBanner, ItemID.MaceWhip, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerGroupToItemRecipe(Common.AnyArmoredBonesBanner, ItemID.MagnetSphere, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.GiantCursedSkullBanner, ItemID.ShadowJoustingLance, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.DiablolistBanner, ItemID.InfernoFork, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.PaladinBanner, ItemID.PaladinsHammer, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.NecromancerBanner, ItemID.ShadowbeamStaff, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.RaggedCasterBanner, ItemID.SpectreStaff, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.SkeletonCommandoBanner, ItemID.RocketLauncher, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.SkeletonSniperBanner, ItemID.SniperRifle, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.TacticalSkeletonBanner, ItemID.TacticalShotgun, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            //Misc Equips
            Common.AddBannerGroupToItemRecipe(Common.AnyArmoredBonesBanner, ItemID.WispinaBottle, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            //Misc
            Common.AddBannerToItemRecipe(ItemID.SkeletonMageBanner, ItemID.BoneWand, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
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
            Common.AddBannerToItemRecipe(ItemID.ZombieBanner, ItemID.Shackle, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.RaincoatZombieBanner, ItemID.Shackle, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.ZombieEskimoBanner, ItemID.Shackle, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.WerewolfBanner, ItemID.MoonCharm, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.WerewolfBanner, ItemID.AdhesiveBandage, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.WraithBanner, ItemID.FastClock, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Armor/Vanity
            //Food
            //Furniture
            //Materials
            //Weapons
            Common.AddBannerToItemRecipe(ItemID.ZombieBanner, ItemID.ZombieArm, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Misc Equips
            //Misc
            #endregion

            #region Rain
            //Accessories
            //Armor/Vanity
            Common.AddBannerToItemRecipe(ItemID.UmbrellaSlimeBanner, ItemID.UmbrellaHat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.RaincoatZombieBanner, ItemID.RainCoat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.RaincoatZombieBanner, ItemID.RainHat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Food
            Common.AddBannerToItemRecipe(ItemID.FlyingFishBanner, ItemID.Fries, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            //Furniture
            //Materials
            //Weapons
            Common.AddBannerToItemRecipe(ItemID.AngryNimbusBanner, ItemID.NimbusRod, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Misc Equips
            //Misc
            Common.AddBannerToItemRecipe(ItemID.FlyingFishBanner, ItemID.CarbonGuitar, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            #endregion

            #region Wind
            //Accessories
            //Armor/Vanity
            //Materials
            //Weapons
            //Misc Equips
            //Misc
            Common.AddBannerToItemRecipe(ItemID.BoneSerpentBanner, ItemID.KiteBoneSerpent, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.BunnyBanner, ItemID.KiteBunny, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.CorruptBunnyBanner, ItemID.KiteBunnyCorrupt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.CrimsonBunnyBanner, ItemID.KiteBunnyCrimson, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.GoldfishBanner, ItemID.KiteGoldfish, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.JellyfishBanner, ItemID.KiteJellyfishBlue, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.ManEaterBanner, ItemID.KiteManEater, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.PinkJellyfishBanner, ItemID.KiteJellyfishPink, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.RedSlimeBanner, ItemID.KiteRed, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.SharkBanner, ItemID.KiteShark, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.SlimeBanner, ItemID.KiteBlue, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.YellowSlimeBanner, ItemID.KiteYellow, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.AngryTrapperBanner, ItemID.KiteAngryTrapper, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.PigronBanner, ItemID.KitePigron, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.SandsharkBanner, ItemID.KiteSandShark, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.UnicornBanner, ItemID.KiteUnicorn, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.WanderingEyeBanner, ItemID.KiteWanderingEye, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.WorldFeederBanner, ItemID.KiteWorldFeeder, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.WyvernBanner, ItemID.KiteWyvern, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            #endregion

            #region Blood Moon
            //Accessories
            Common.AddBannerToItemRecipe(ItemID.BloodZombieBanner, ItemID.SharkToothNecklace, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.DripplerBanner, ItemID.SharkToothNecklace, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.ClownBanner, ItemID.TrifoldMap, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Armor/Vanity
            //Food
            //Furniture
            //Materials
            //Weapons
            Common.AddBannerToItemRecipe(ItemID.EyeballFlyingFishBanner, ItemID.BloodRainBow, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.EyeballFlyingFishBanner, ItemID.VampireFrogStaff, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.ZombieMermanBanner, ItemID.BloodRainBow, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.ZombieMermanBanner, ItemID.VampireFrogStaff, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.BloodZombieBanner, ItemID.KOCannon, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.ClownBanner, ItemID.KOCannon, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.GoblinSharkBanner, ItemID.SharpTears, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.GoblinSharkBanner, ItemID.BloodHamaxe, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.BloodEelBanner, ItemID.DripplerFlail, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.BloodEelBanner, ItemID.BloodHamaxe, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.AddBannerToItemRecipe(ItemID.BloodNautilusBanner, ItemID.SanguineStaff, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            //Misc Equips
            //Misc
            Common.AddBannerToItemRecipe(ItemID.DripplerBanner, ItemID.MoneyTrough, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.EyeballFlyingFishBanner, ItemID.BloodFishingRod, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.ZombieMermanBanner, ItemID.BloodFishingRod, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.AddBannerToItemRecipe(ItemID.BloodNautilusBanner, ItemID.BloodMoonMonolith, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            #endregion

            #region Goblins
            //Accessories
            //Armor/Vanity
            //Food
            //Furniture
            //Materials
            //Weapons
            Common.AddBannerToItemRecipe(ItemID.GoblinArcherBanner, ItemID.Harpoon, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes));
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
            Common.AddBannerGroupToItemRecipe(Common.AnyPirateBanner, ItemID.DiscountCard, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPirates);
            Common.AddBannerGroupToItemRecipe(Common.AnyPirateBanner, ItemID.GoldRing, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPirates);
            Common.AddBannerGroupToItemRecipe(Common.AnyPirateBanner, ItemID.LuckyCoin, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPirates);
            //Armor/Vanity
            Common.AddBannerGroupToItemRecipe(Common.AnyPirateBanner, ItemID.SailorPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPirates);
            Common.AddBannerGroupToItemRecipe(Common.AnyPirateBanner, ItemID.SailorShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPirates);
            Common.AddBannerGroupToItemRecipe(Common.AnyPirateBanner, ItemID.SailorHat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPirates);
            Common.AddBannerGroupToItemRecipe(Common.AnyPirateBanner, ItemID.EyePatch, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPirates);
            Common.AddBannerGroupToItemRecipe(Common.AnyPirateBanner, ItemID.BuccaneerPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPirates);
            Common.AddBannerGroupToItemRecipe(Common.AnyPirateBanner, ItemID.BuccaneerShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPirates);
            Common.AddBannerGroupToItemRecipe(Common.AnyPirateBanner, ItemID.BuccaneerBandana, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPirates);
            //Food
            //Furniture
            //Materials
            //Weapons
            Common.AddBannerGroupToItemRecipe(Common.AnyPirateBanner, ItemID.Cutlass, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPirates);
            Common.AddBannerGroupToItemRecipe(Common.AnyPirateBanner, ItemID.PirateStaff, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPirates);
            Common.AddBannerToItemRecipe(ItemID.PirateCaptainBanner, ItemID.CoinGun, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPirates);
            //Misc Equips
            //Misc
            #endregion

            #region Eclipse
            //Accessories
            Common.AddBannerToItemRecipe(ItemID.CreatureFromTheDeepBanner, ItemID.NeptunesShell, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMechBossAny);
            Common.AddBannerToItemRecipe(ItemID.VampireBanner, ItemID.MoonStone, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMechBossAny);
            Common.AddBannerToItemRecipe(ItemID.MothronBanner, ItemID.MothronWings, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            //Armor/Vanity
            Common.AddBannerToItemRecipe(ItemID.ButcherBanner, ItemID.ButcherPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.ButcherBanner, ItemID.ButcherApron, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.ButcherBanner, ItemID.ButcherPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.DrManFlyBanner, ItemID.DrManFlyLabCoat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.DrManFlyBanner, ItemID.DrManFlyMask, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            //Food
            Common.AddBannerToItemRecipe(ItemID.ThePossessedBanner, ItemID.Steak, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMechBossAny);
            //Furniture
            //Materials
            Common.AddBannerToItemRecipe(ItemID.VampireBanner, ItemID.BrokenBatWing, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMechBossAny);
            Common.AddBannerToItemRecipe(ItemID.MothronBanner, ItemID.BrokenHeroSword, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            //Weapons
            Common.AddBannerToItemRecipe(ItemID.ReaperBanner, ItemID.DeathSickle, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMechBossAll);
            Common.AddBannerToItemRecipe(ItemID.ButcherBanner, ItemID.ButchersChainsaw, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.DeadlySphereBanner, ItemID.DeadlySphereStaff, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.DrManFlyBanner, ItemID.ToxicFlask, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.MothronBanner, ItemID.TheEyeOfCthulhu, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.NailheadBanner, ItemID.NailGun, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.PsychoBanner, ItemID.PsychoKnife, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            //Misc Equips
            Common.AddBannerToItemRecipe(ItemID.EyezorBanner, ItemID.EyeSpring, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMechBossAny);
            //Misc
            #endregion

            #region Pumpkin Moon
            //Accessories
            //Armor/Vanity
            Common.AddBannerToItemRecipe(ItemID.ScarecrowBanner, ItemID.ScarecrowPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.ScarecrowBanner, ItemID.ScarecrowShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.ScarecrowBanner, ItemID.ScarecrowHat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.HeadlessHorsemanBanner, ItemID.JackOLanternMask, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
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
            Common.AddBannerToItemRecipe(ItemID.ZombieElfBanner, ItemID.ElfPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.ZombieElfBanner, ItemID.ElfShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
            Common.AddBannerToItemRecipe(ItemID.ZombieElfBanner, ItemID.ElfHat, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedPlantera);
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
            Common.AddBannerToItemRecipe(ItemID.MartianGreyGruntBanner, ItemID.MartianCostumePants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            Common.AddBannerToItemRecipe(ItemID.MartianGreyGruntBanner, ItemID.MartianCostumeShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            Common.AddBannerToItemRecipe(ItemID.MartianGreyGruntBanner, ItemID.MartianCostumeMask, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            Common.AddBannerToItemRecipe(ItemID.MartianRaygunnerBanner, ItemID.MartianCostumePants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            Common.AddBannerToItemRecipe(ItemID.MartianRaygunnerBanner, ItemID.MartianCostumeShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            Common.AddBannerToItemRecipe(ItemID.MartianRaygunnerBanner, ItemID.MartianCostumeMask, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            Common.AddBannerToItemRecipe(ItemID.MartianBrainscramblerBanner, ItemID.MartianCostumePants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            Common.AddBannerToItemRecipe(ItemID.MartianBrainscramblerBanner, ItemID.MartianCostumeShirt, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            Common.AddBannerToItemRecipe(ItemID.MartianBrainscramblerBanner, ItemID.MartianCostumeMask, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            Common.AddBannerToItemRecipe(ItemID.MartianOfficerBanner, ItemID.MartianUniformPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            Common.AddBannerToItemRecipe(ItemID.MartianOfficerBanner, ItemID.MartianUniformTorso, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            Common.AddBannerToItemRecipe(ItemID.MartianOfficerBanner, ItemID.MartianUniformHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            Common.AddBannerToItemRecipe(ItemID.MartianEngineerBanner, ItemID.MartianUniformPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            Common.AddBannerToItemRecipe(ItemID.MartianEngineerBanner, ItemID.MartianUniformTorso, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            Common.AddBannerToItemRecipe(ItemID.MartianEngineerBanner, ItemID.MartianUniformHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            Common.AddBannerToItemRecipe(ItemID.MartianGigazapperBanner, ItemID.MartianUniformPants, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            Common.AddBannerToItemRecipe(ItemID.MartianGigazapperBanner, ItemID.MartianUniformTorso, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            Common.AddBannerToItemRecipe(ItemID.MartianGigazapperBanner, ItemID.MartianUniformHelmet, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedGolem);
            //Food
            //Furniture
            //Materials
            //Weapons
            //Misc Equips
            Common.AddBannerToItemRecipe(ItemID.MartianScutlixGunnerBanner, ItemID.BrainScrambler, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMartians);
            Common.AddBannerToItemRecipe(ItemID.ScutlixBanner, ItemID.BrainScrambler, 1, 1, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Banners", () => QoLCompendium.mainConfig.EasierRecipes), Condition.DownedMartians);
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
            Common.CreateSimpleRecipe(ItemID.GoodieBag, ItemID.UnluckyYarn, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.CreateSimpleRecipe(ItemID.GoodieBag, ItemID.BatHook, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.CreateSimpleRecipe(ItemID.GoodieBag, ItemID.RottenEgg, TileID.WorkBenches, 1, 50, disableDecraft: true, usesRecipeGroup: false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.EasierRecipes));

            //Present Recipes
            Common.CreateSimpleRecipe(ItemID.Present, ItemID.SnowGlobe, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.EasierRecipes), Condition.Hardmode);
            Common.CreateSimpleRecipe(ItemID.Present, ItemID.DogWhistle, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.CreateSimpleRecipe(ItemID.Present, ItemID.RedRyder, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.CreateSimpleRecipe(ItemID.Present, ItemID.CandyCaneSword, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.CreateSimpleRecipe(ItemID.Present, ItemID.CnadyCanePickaxe, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.CreateSimpleRecipe(ItemID.Present, ItemID.CandyCaneHook, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.CreateSimpleRecipe(ItemID.Present, ItemID.FruitcakeChakram, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.CreateSimpleRecipe(ItemID.Present, ItemID.HandWarmer, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.CreateSimpleRecipe(ItemID.Present, ItemID.Toolbox, TileID.WorkBenches, 5, 1, disableDecraft: true, usesRecipeGroup: false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.EasierRecipes));
            Common.CreateSimpleRecipe(ItemID.Present, ItemID.StarAnise, TileID.WorkBenches, 1, 50, disableDecraft: true, usesRecipeGroup: false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.Crates", () => QoLCompendium.mainConfig.EasierRecipes));
        }

        public static void OtherRecipes()
        {
            #region Biome Keys
            #region Vanilla
            Common.CreateSimpleRecipe(ItemID.CorruptionKey, ItemID.ScourgeoftheCorruptor, TileID.MythrilAnvil, 1, 1, true, false, Condition.DownedPlantera);
            Common.CreateSimpleRecipe(ItemID.CrimsonKey, ItemID.VampireKnives, TileID.MythrilAnvil, 1, 1, true, false, Condition.DownedPlantera);
            Common.CreateSimpleRecipe(ItemID.DungeonDesertKey, ItemID.StormTigerStaff, TileID.MythrilAnvil, 1, 1, true, false, Condition.DownedPlantera);
            Common.CreateSimpleRecipe(ItemID.FrozenKey, ItemID.StaffoftheFrostHydra, TileID.MythrilAnvil, 1, 1, true, false, Condition.DownedPlantera);
            Common.CreateSimpleRecipe(ItemID.HallowedKey, ItemID.RainbowGun, TileID.MythrilAnvil, 1, 1, true, false, Condition.DownedPlantera);
            Common.CreateSimpleRecipe(ItemID.JungleKey, ItemID.PiranhaGun, TileID.MythrilAnvil, 1, 1, true, false, Condition.DownedPlantera);
            #endregion

            #region Modded
            #region Spooky
            if (ModConditions.spookyLoaded)
            {
                Common.CreateSimpleRecipe(Common.GetModItem(ModConditions.spookyMod, "SpookyBiomeKe"), Common.GetModItem(ModConditions.spookyMod, "ElGourdo"), TileID.MythrilAnvil, 1, 1, true, false, Condition.DownedPlantera);
                Common.CreateSimpleRecipe(Common.GetModItem(ModConditions.spookyMod, "CemeteryKey"), Common.GetModItem(ModConditions.spookyMod, "DiscoSkull"), TileID.MythrilAnvil, 1, 1, true, false, Condition.DownedPlantera);
                Common.CreateSimpleRecipe(Common.GetModItem(ModConditions.spookyMod, "SpiderKey"), Common.GetModItem(ModConditions.spookyMod, "VenomHarpoon"), TileID.MythrilAnvil, 1, 1, true, false, Condition.DownedPlantera);
                Common.CreateSimpleRecipe(Common.GetModItem(ModConditions.spookyMod, "SpookyHellKey"), Common.GetModItem(ModConditions.spookyMod, "BrainJar"), TileID.MythrilAnvil, 1, 1, true, false, Condition.DownedPlantera);
            }
            #endregion

            #region Thorium
            if (ModConditions.thoriumLoaded)
            {
                Common.CreateSimpleRecipe(Common.GetModItem(ModConditions.thoriumMod, "AquaticDepthsBiomeKey"), Common.GetModItem(ModConditions.thoriumMod, "Fishbone"), TileID.MythrilAnvil, 1, 1, true, false, Condition.DownedPlantera);
                Common.CreateSimpleRecipe(Common.GetModItem(ModConditions.thoriumMod, "DesertBiomeKey"), Common.GetModItem(ModConditions.thoriumMod, "PharaohsSlab"), TileID.MythrilAnvil, 1, 1, true, false, Condition.DownedPlantera);
                Common.CreateSimpleRecipe(Common.GetModItem(ModConditions.thoriumMod, "UnderworldBiomeKey"), Common.GetModItem(ModConditions.thoriumMod, "PhoenixStaff"), TileID.MythrilAnvil, 1, 1, true, false, Condition.DownedPlantera);
            }
            #endregion
            #endregion
            #endregion
        }

        public static void NewRecipes()
        {
            #region Prime Rework / Confection Fix
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
            #endregion

            #region Calamity Effigy Recipes
            if (ModConditions.calamityLoaded && QoLCompendium.crossModConfig.CalamityEffigyRecipes)
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
            #endregion

            #region Parity
            //Mobile Storage
            if (!QoLCompendium.itemConfig.DisableModdedItems)
                Common.CreateSimpleRecipe(ItemID.PiggyBank, ItemID.MoneyTrough, TileID.Anvils, 1, 1, false, false, ModConditions.ItemToggled("Mods.QoLCompendium.ItemToggledConditions.MobileStorages", () => QoLCompendium.itemConfig.MobileStorages));
            #endregion

            #region Config Specific
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
            #endregion
        }
    }
}