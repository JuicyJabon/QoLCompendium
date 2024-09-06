using QoLCompendium.Content.Items.Dedicated;
using QoLCompendium.Content.Items.Placeables.CraftingStations;
using QoLCompendium.Content.Items.Placeables.Pylons;
using QoLCompendium.Content.Items.Tools.Usables;
using QoLCompendium.Content.Tiles.CraftingStations;

namespace QoLCompendium.Core
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
                    Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.CraftingStations, ItemID.Sets.ShimmerTransformToItem[i]);
                    r.AddIngredient(i);
                    r.AddTile(ModContent.TileType<AetherAltarTile>());
                    r.Register();
                }
            }

            //Conversion Recipe Creation
            Common.ConversionRecipe(ItemID.CopperBar, ItemID.TinBar, TileID.Anvils);
            Common.ConversionRecipe(ItemID.IronBar, ItemID.LeadBar, TileID.Anvils);
            Common.ConversionRecipe(ItemID.SilverBar, ItemID.TungstenBar, TileID.Anvils);
            Common.ConversionRecipe(ItemID.GoldBar, ItemID.PlatinumBar, TileID.Anvils);
            Common.ConversionRecipe(ItemID.DemoniteBar, ItemID.CrimtaneBar, TileID.Anvils);
            Common.ConversionRecipe(ItemID.CobaltBar, ItemID.PalladiumBar, TileID.Anvils);
            Common.ConversionRecipe(ItemID.MythrilBar, ItemID.OrichalcumBar, TileID.MythrilAnvil);
            Common.ConversionRecipe(ItemID.AdamantiteBar, ItemID.TitaniumBar, TileID.MythrilAnvil);
            Common.ConversionRecipe(ItemID.RottenChunk, ItemID.Vertebrae, TileID.Anvils);
            Common.ConversionRecipe(ItemID.ShadowScale, ItemID.TissueSample, TileID.Anvils);
            Common.ConversionRecipe(ItemID.CursedFlame, ItemID.Ichor, TileID.Anvils);
            Common.ConversionRecipe(ItemID.SoulofNight, ItemID.SoulofLight, TileID.Anvils);
            Common.ConversionRecipe(ItemID.EbonstoneBlock, ItemID.CrimstoneBlock, TileID.Anvils);
            Common.ConversionRecipe(ItemID.EbonsandBlock, ItemID.CrimsandBlock, TileID.Anvils);
            Common.ConversionRecipe(ItemID.CorruptSandstone, ItemID.CrimsonSandstone, TileID.Anvils);
            Common.ConversionRecipe(ItemID.CorruptHardenedSand, ItemID.CrimsonHardenedSand, TileID.Anvils);
            Common.ConversionRecipe(ItemID.PurpleIceBlock, ItemID.RedIceBlock, TileID.Anvils);
            Common.ConversionRecipe(ItemID.CorruptSeeds, ItemID.CrimsonSeeds, TileID.Anvils);
            Common.ConversionRecipe(ItemID.VileMushroom, ItemID.ViciousMushroom, TileID.Anvils);
            Common.ConversionRecipe(ItemID.Ebonkoi, ItemID.Hemopiranha, TileID.Anvils);
            Common.ConversionRecipe(ItemID.CorruptionKey, ItemID.CrimsonKey, TileID.MythrilAnvil);
            Common.ConversionRecipe(ItemID.CorruptFishingCrate, ItemID.CrimsonFishingCrate, TileID.Anvils);
            Common.ConversionRecipe(ItemID.CorruptFishingCrateHard, ItemID.CrimsonFishingCrateHard, TileID.Anvils);
            Common.ConversionRecipe(ItemID.DartRifle, ItemID.DartPistol, TileID.Anvils);
            Common.ConversionRecipe(ItemID.ClingerStaff, ItemID.SoulDrain, TileID.Anvils);
            Common.ConversionRecipe(ItemID.ChainGuillotines, ItemID.FetidBaghnakhs, TileID.Anvils);
            Common.ConversionRecipe(ItemID.PutridScent, ItemID.FleshKnuckles, TileID.Anvils);
            Common.ConversionRecipe(ItemID.WormHook, ItemID.TendonHook, TileID.Anvils);
            Common.ConversionRecipe(ItemID.EatersBone, ItemID.BoneRattle, TileID.Anvils);

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

            //Crate Recipe Creation
            //Wooden Crate
            Common.CreateCrateRecipe(ItemID.SailfishBoots, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.TsunamiInABottle, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.Aglet, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.PortableStool, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.ClimbingClaws, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.CordageGuide, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.Radar, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 3);
            Common.CreateCrateHardmodeRecipe(ItemID.Anchor, ItemID.WoodenCrateHard, 3);
            //Iron Crate
            Common.CreateCrateRecipe(ItemID.FalconBlade, ItemID.IronCrate, ItemID.IronCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.TartarSauce, ItemID.IronCrate, ItemID.IronCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.GingerBeard, ItemID.IronCrate, ItemID.IronCrateHard, 3);
            //Golden Crate
            Common.CreateCrateRecipe(ItemID.HardySaddle, ItemID.GoldenCrate, ItemID.GoldenCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.EnchantedSword, ItemID.GoldenCrate, ItemID.GoldenCrateHard, 3);
            //Jungle Crate
            Common.CreateCrateRecipe(ItemID.FlowerBoots, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.AnkletoftheWind, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.Boomstick, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.FeralClaws, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.StaffofRegrowth, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.FiberglassFishingPole, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.Seaweed, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 3);
            //Sky Crate
            Common.CreateCrateRecipe(ItemID.Starfury, ItemID.FloatingIslandFishingCrate, ItemID.FloatingIslandFishingCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.LuckyHorseshoe, ItemID.FloatingIslandFishingCrate, ItemID.FloatingIslandFishingCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.ShinyRedBalloon, ItemID.FloatingIslandFishingCrate, ItemID.FloatingIslandFishingCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.CelestialMagnet, ItemID.FloatingIslandFishingCrate, ItemID.FloatingIslandFishingCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.CreativeWings, ItemID.FloatingIslandFishingCrate, ItemID.FloatingIslandFishingCrateHard, 3);
            //Frozen Crate
            Common.CreateCrateRecipe(ItemID.IceBoomerang, ItemID.FrozenCrate, ItemID.FrozenCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.IceBlade, ItemID.FrozenCrate, ItemID.FrozenCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.IceSkates, ItemID.FrozenCrate, ItemID.FrozenCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.SnowballCannon, ItemID.FrozenCrate, ItemID.FrozenCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.BlizzardinaBottle, ItemID.FrozenCrate, ItemID.FrozenCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.FlurryBoots, ItemID.FrozenCrate, ItemID.FrozenCrateHard, 3);
            //Oasis Crate
            Common.CreateCrateRecipe(ItemID.AncientChisel, ItemID.OasisCrate, ItemID.OasisCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.ScarabFishingRod, ItemID.OasisCrate, ItemID.OasisCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.SandBoots, ItemID.OasisCrate, ItemID.OasisCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.ThunderSpear, ItemID.OasisCrate, ItemID.OasisCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.ThunderStaff, ItemID.OasisCrate, ItemID.OasisCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.MysticCoilSnake, ItemID.OasisCrate, ItemID.OasisCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.MagicConch, ItemID.OasisCrate, ItemID.OasisCrateHard, 3);
            //Corrupt Crate
            Common.CreateCrateRecipe(ItemID.BallOHurt, ItemID.CorruptFishingCrate, ItemID.CorruptFishingCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.BandofStarpower, ItemID.CorruptFishingCrate, ItemID.CorruptFishingCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.Musket, ItemID.CorruptFishingCrate, ItemID.CorruptFishingCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.ShadowOrb, ItemID.CorruptFishingCrate, ItemID.CorruptFishingCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.Vilethorn, ItemID.CorruptFishingCrate, ItemID.CorruptFishingCrateHard, 3);
            //Crimson Crate
            Common.CreateCrateRecipe(ItemID.TheUndertaker, ItemID.CrimsonFishingCrate, ItemID.CrimsonFishingCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.TheRottedFork, ItemID.CrimsonFishingCrate, ItemID.CrimsonFishingCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.CrimsonRod, ItemID.CrimsonFishingCrate, ItemID.CrimsonFishingCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.PanicNecklace, ItemID.CrimsonFishingCrate, ItemID.CrimsonFishingCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.CrimsonHeart, ItemID.CrimsonFishingCrate, ItemID.CrimsonFishingCrateHard, 3);
            //Ocean Crate
            Common.CreateCrateRecipe(ItemID.BreathingReed, ItemID.OceanCrate, ItemID.OceanCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.FloatingTube, ItemID.OceanCrate, ItemID.OceanCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.Trident, ItemID.OceanCrate, ItemID.OceanCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.Flipper, ItemID.OceanCrate, ItemID.OceanCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.WaterWalkingBoots, ItemID.OceanCrate, ItemID.OceanCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.SharkBait, ItemID.OceanCrate, ItemID.OceanCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.SandcastleBucket, ItemID.OceanCrate, ItemID.OceanCrateHard, 3);
            //Obsidian Crate
            Common.CreateCrateRecipe(ItemID.LavaCharm, ItemID.LavaCrate, ItemID.LavaCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.FlameWakerBoots, ItemID.LavaCrate, ItemID.LavaCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.SuperheatedBlood, ItemID.LavaCrate, ItemID.LavaCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.LavaFishbowl, ItemID.LavaCrate, ItemID.LavaCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.LavaFishingHook, ItemID.LavaCrate, ItemID.LavaCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.OrnateShadowKey, ItemID.LavaCrate, ItemID.LavaCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.HellCake, ItemID.LavaCrate, ItemID.LavaCrateHard, 3);
            Common.CreateCrateRecipe(ItemID.HellMinecart, ItemID.LavaCrate, ItemID.LavaCrateHard, 3);
            Common.CreateCrateWithKeyRecipe(ItemID.DarkLance, ItemID.LavaCrate, ItemID.LavaCrateHard, 3, ItemID.ShadowKey);
            Common.CreateCrateWithKeyRecipe(ItemID.Sunfury, ItemID.LavaCrate, ItemID.LavaCrateHard, 3, ItemID.ShadowKey);
            Common.CreateCrateWithKeyRecipe(ItemID.FlowerofFire, ItemID.LavaCrate, ItemID.LavaCrateHard, 3, ItemID.ShadowKey);
            Common.CreateCrateWithKeyRecipe(ItemID.Flamelash, ItemID.LavaCrate, ItemID.LavaCrateHard, 3, ItemID.ShadowKey);
            Common.CreateCrateWithKeyRecipe(ItemID.HellwingBow, ItemID.LavaCrate, ItemID.LavaCrateHard, 3, ItemID.ShadowKey);
            Common.CreateCrateWithKeyRecipe(ItemID.TreasureMagnet, ItemID.LavaCrate, ItemID.LavaCrateHard, 3, ItemID.ShadowKey);
            //Dungeon Crate
            Common.CreateCrateWithKeyRecipe(ItemID.Valor, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 3, ItemID.GoldenKey);
            Common.CreateCrateWithKeyRecipe(ItemID.Muramasa, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 3, ItemID.GoldenKey);
            Common.CreateCrateWithKeyRecipe(ItemID.CobaltShield, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 3, ItemID.GoldenKey);
            Common.CreateCrateWithKeyRecipe(ItemID.AquaScepter, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 3, ItemID.GoldenKey);
            Common.CreateCrateWithKeyRecipe(ItemID.BlueMoon, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 3, ItemID.GoldenKey);
            Common.CreateCrateWithKeyRecipe(ItemID.MagicMissile, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 3, ItemID.GoldenKey);
            Common.CreateCrateWithKeyRecipe(ItemID.Handgun, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 3, ItemID.GoldenKey);
            Common.CreateCrateWithKeyRecipe(ItemID.ShadowKey, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 3, ItemID.GoldenKey);
            //Stations
            Common.CreateCrateRecipe(ItemID.Extractinator, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.LivingLoom, ItemID.WoodenCrate, ItemID.WoodenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.HoneyDispenser, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.SkyMill, ItemID.FloatingIslandFishingCrate, ItemID.FloatingIslandFishingCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.IceMachine, ItemID.FrozenCrate, ItemID.FrozenCrateHard, 1);
            Common.CreateCrateRecipe(ItemID.CatBast, ItemID.OasisCrate, ItemID.OasisCrateHard, 1);
            Common.CreateCrateWithKeyRecipe(ItemID.AlchemyTable, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ItemID.GoldenKey);
            Common.CreateCrateWithKeyRecipe(ItemID.BoneWelder, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, 1, ItemID.GoldenKey);
            Common.CreateCrateHardmodeRecipe(ItemID.Sundial, ItemID.GoldenCrateHard, 1);

            //Mobile Storage Parity
            Recipe moneyTrough = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.MobileStorages, ItemID.MoneyTrough);
            moneyTrough.AddIngredient(ItemID.PiggyBank);
            moneyTrough.AddTile(TileID.Anvils);
            moneyTrough.Register();

            //Easier Universal Pylon
            Recipe universalPylon = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.Pylons, ItemID.TeleportationPylonVictory);
            universalPylon.AddIngredient(ItemID.TeleportationPylonPurity);
            universalPylon.AddIngredient(ModContent.ItemType<SkyPylon>());
            universalPylon.AddIngredient(ItemID.TeleportationPylonUnderground);
            universalPylon.AddIngredient(ItemID.TeleportationPylonDesert);
            universalPylon.AddIngredient(ItemID.TeleportationPylonSnow);
            universalPylon.AddIngredient(ModContent.ItemType<CorruptionPylon>());
            universalPylon.AddIngredient(ModContent.ItemType<CrimsonPylon>());
            universalPylon.AddIngredient(ItemID.TeleportationPylonJungle);
            universalPylon.AddIngredient(ItemID.TeleportationPylonMushroom);
            universalPylon.AddIngredient(ModContent.ItemType<HellPylon>());
            universalPylon.AddIngredient(ItemID.TeleportationPylonHallow);
            universalPylon.AddIngredient(ItemID.TeleportationPylonOcean);
            universalPylon.AddIngredient(ModContent.ItemType<DungeonPylon>());
            universalPylon.AddIngredient(ModContent.ItemType<TemplePylon>());
            universalPylon.AddIngredient(ModContent.ItemType<AetherPylon>());
            universalPylon.AddTile(TileID.Anvils);
            universalPylon.Register();
        }
    }

    public class RecipeGroups : ModSystem
    {
        public override void AddRecipeGroups()
        {
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
            #endregion

            RecipeGroup anvils = new(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.IronAnvil)}", anvilItems);
            RecipeGroup.RegisterGroup("QoLCompendium:Anvils", anvils);

            RecipeGroup hmAnvils = new(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.MythrilAnvil)}", hardmodeAnvilItems);
            RecipeGroup.RegisterGroup("QoLCompendium:HardmodeAnvils", hmAnvils);

            RecipeGroup hmForges = new(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.AdamantiteForge)}", hardmodeForgeItems);
            RecipeGroup.RegisterGroup("QoLCompendium:HardmodeForges", hmForges);

            RecipeGroup altars = new(() => $"{Language.GetTextValue("LegacyMisc.37")} {Language.GetTextValue("MapObject.DemonAltar")}", altarItems);
            RecipeGroup.RegisterGroup("QoLCompendium:Altars", altars);

            RecipeGroup tombstones = new(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.Tombstone)}", 
                ItemID.Tombstone, ItemID.GraveMarker, 
                ItemID.CrossGraveMarker, ItemID.Headstone, 
                ItemID.Gravestone, ItemID.Obelisk, 
                ItemID.RichGravestone1, ItemID.RichGravestone2, 
                ItemID.RichGravestone3, ItemID.RichGravestone4, 
                ItemID.RichGravestone5);
            RecipeGroup.RegisterGroup("QoLCompendium:Tombstones", tombstones);

            RecipeGroup bookcases = new(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.Bookcase)}",
                ItemID.Bookcase, ItemID.BlueDungeonBookcase, ItemID.BoneBookcase, ItemID.BorealWoodBookcase,
                ItemID.CactusBookcase, ItemID.CrystalBookCase, ItemID.DynastyBookcase, ItemID.EbonwoodBookcase,
                ItemID.FleshBookcase, ItemID.FrozenBookcase, ItemID.GlassBookcase, ItemID.GoldenBookcase,
                ItemID.GothicBookcase, ItemID.GraniteBookcase, ItemID.GreenDungeonBookcase, ItemID.HoneyBookcase,
                ItemID.LivingWoodBookcase, ItemID.MarbleBookcase, ItemID.MeteoriteBookcase, ItemID.MushroomBookcase,
                ItemID.ObsidianBookcase, ItemID.PalmWoodBookcase, ItemID.PearlwoodBookcase, ItemID.PinkDungeonBookcase,
                ItemID.PumpkinBookcase, ItemID.RichMahoganyBookcase, ItemID.ShadewoodBookcase, ItemID.SkywareBookcase,
                ItemID.SlimeBookcase, ItemID.SpookyBookcase, ItemID.SteampunkBookcase, ItemID.AshWoodBookcase);
            RecipeGroup.RegisterGroup("QoLCompendium:Bookcases", bookcases);

            RecipeGroup tables = new(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.WoodenTable)}",
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

            RecipeGroup chairs = new(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.WoodenChair)}",
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

            RecipeGroup sinks = new(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.WoodenSink)}",
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
        }
    }

    public class AdditionalRecipes : ModSystem
    {
        public override void PostUpdatePlayers()
        {
            if (QoLCompendium.itemConfig.DedicatedItems)
                ItemID.Sets.ShimmerTransformToItem[ItemID.RottenEgg] = ModContent.ItemType<LittleEgg>();
            else
                ItemID.Sets.ShimmerTransformToItem[ItemID.RottenEgg] = ItemID.None;

            if (QoLCompendium.itemConfig.GoldenLockpick)
                ItemID.Sets.ShimmerTransformToItem[ItemID.GoldenKey] = ModContent.ItemType<GoldenLockpick>();
            else
                ItemID.Sets.ShimmerTransformToItem[ItemID.GoldenKey] = ItemID.None;

            ItemID.Sets.ShimmerTransformToItem[Common.GetModItem(ModConditions.redemptionMod, "Keycard2")] = Common.GetModItem(ModConditions.redemptionMod, "Keycard");
        }
    }
}

/*
            if (ModConditions.qwertyLoaded)
            {
                if (ModConditions.qwertyMod.TryFind("FortressBossSummon", out ModItem FortressBossSummon) 
                    && ModConditions.qwertyMod.TryFind("FortressHarpyBeak", out ModItem FortressHarpyBeak)
                    && ModConditions.qwertyMod.TryFind("FortressBrick", out ModItem FortressBrick))
                {
                    Recipe skyPendant = Recipe.Create(FortressBossSummon.Type);
                    skyPendant.AddIngredient(FortressHarpyBeak.Type);
                    skyPendant.AddIngredient(FortressBrick.Type, 2);
                    skyPendant.AddTile(TileID.Anvils);
                    skyPendant.Register();
                }

                if (ModConditions.qwertyMod.TryFind("GodSealKeycard", out ModItem GodSealKeycard)
                    && ModConditions.qwertyMod.TryFind("InvaderPlating", out ModItem InvaderPlating)
                    && ModConditions.qwertyMod.TryFind("FortressBrick", out ModItem FortressBrick2))
                {
                    Recipe godKeycard = Recipe.Create(GodSealKeycard.Type);
                    godKeycard.AddIngredient(InvaderPlating.Type);
                    godKeycard.AddIngredient(FortressBrick2.Type, 2);
                    godKeycard.AddTile(TileID.Anvils);
                    godKeycard.Register();
                }
            }
*/