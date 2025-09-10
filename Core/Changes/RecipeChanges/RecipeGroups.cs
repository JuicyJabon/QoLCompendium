using QoLCompendium.Content.Items.Placeables.CraftingStations;
using System.Text.RegularExpressions;

namespace QoLCompendium.Core.Changes.RecipeChanges
{
    public class RecipeGroups : ModSystem
    {
        public static readonly Regex chestItemRegex = new(@"\b(?!fake_)(.*chest)\b", RegexOptions.Compiled);
        public static readonly Regex workBenchItemRegex = new(@"\b(.*workbench)\b", RegexOptions.Compiled);
        public static readonly Regex sinkItemRegex = new(@"\b(.*sink)(?:does)?\b", RegexOptions.Compiled);
        public static readonly Regex tableItemRegex = new(@"\b(.*table)(?:withcloth)?\b", RegexOptions.Compiled);
        public static readonly Regex chairItemRegex = new(@"\b(.*chair)\b", RegexOptions.Compiled);
        public static readonly Regex bookcaseItemRegex = new(@"\b(.*bookcase)\b", RegexOptions.Compiled);
        public static readonly Regex campfireItemRegex = new(@"\b(.*campfire)\b", RegexOptions.Compiled);

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
                if (ModConditions.martainsOrderLoaded && item.buffType == Common.GetModBuff(ModConditions.martainsOrderMod, "Gourmet"))
                    gourmetFlavorItems.Add(item.type);

                if (!item.consumable || item.createTile < TileID.Dirt || item.ModItem != null && item.ModItem.Mod == Mod)
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

            items = GetItems(ItemID.Campfire, campfireItemRegex);
            RecipeGroup campfires = new RecipeGroup(() => $"{any} {Lang.GetItemNameValue(ItemID.Campfire)}", items);
            RecipeGroup.RegisterGroup("QoLCompendium:AnyCampfire", campfires);
            RegisterGroupClone(campfires, nameof(ItemID.Campfire));

            RecipeGroup tombstones = new(() => $"{any} {Lang.GetItemNameValue(ItemID.Tombstone)}",
                ItemID.Tombstone, 
                ItemID.GraveMarker,
                ItemID.CrossGraveMarker, 
                ItemID.Headstone,
                ItemID.Gravestone, 
                ItemID.Obelisk,
                ItemID.RichGravestone1, 
                ItemID.RichGravestone2,
                ItemID.RichGravestone3, 
                ItemID.RichGravestone4,
                ItemID.RichGravestone5);
            RecipeGroup.RegisterGroup("QoLCompendium:AnyTombstone", tombstones);

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

            if (ModConditions.thoriumLoaded)
                RecipeGroup.RegisterGroup("QoLCompendium:GrimPedestals", new(() => $"{any} {Lang.GetItemNameValue(Common.GetModItem(ModConditions.thoriumMod, "GrimPedestal"))}", Common.GetModItem(ModConditions.thoriumMod, "GrimPedestal"), Common.GetModItem(ModConditions.thoriumMod, "GrimPedestalCrimson")));

            RecipeGroup.RegisterGroup("QoLCompendium:Ale", new(() => $"{any} {Lang.GetItemNameValue(ItemID.Ale)}", ItemID.Ale, ItemID.Sake));
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
