using QoLCompendium.Content.Items.Placeables.CraftingStations;
using QoLCompendium.Content.Items.Placeables.Pylons;
using QoLCompendium.Content.Tiles.CraftingStations;

namespace QoLCompendium.Core
{
    public class RecipeAdditions : ModSystem
    {
        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.CraftingStations)
            {
                for (int i = 0; i < ItemLoader.ItemCount; i++)
                {
                    if (ItemID.Sets.ShimmerTransformToItem[i] > ItemID.None)
                    {
                        Recipe r = Recipe.Create(ItemID.Sets.ShimmerTransformToItem[i]);
                        r.AddIngredient(i);
                        r.AddTile(ModContent.TileType<AetherAltarTile>());
                        r.Register();
                    }
                }
            }

            if (QoLCompendium.mainConfig.ItemConversions)
            {
                ConversionRecipe(ItemID.CopperBar, ItemID.TinBar);
                ConversionRecipe(ItemID.TinBar, ItemID.CopperBar);

                ConversionRecipe(ItemID.IronBar, ItemID.LeadBar);
                ConversionRecipe(ItemID.LeadBar, ItemID.IronBar);

                ConversionRecipe(ItemID.SilverBar, ItemID.TungstenBar);
                ConversionRecipe(ItemID.TungstenBar, ItemID.SilverBar);

                ConversionRecipe(ItemID.GoldBar, ItemID.PlatinumBar);
                ConversionRecipe(ItemID.PlatinumBar, ItemID.GoldBar);

                ConversionRecipe(ItemID.DemoniteBar, ItemID.CrimtaneBar);
                ConversionRecipe(ItemID.CrimtaneBar, ItemID.DemoniteBar);

                ConversionRecipe(ItemID.CobaltBar, ItemID.PalladiumBar);
                ConversionRecipe(ItemID.PalladiumBar, ItemID.CobaltBar);

                ConversionRecipe(ItemID.MythrilBar, ItemID.OrichalcumBar);
                ConversionRecipe(ItemID.OrichalcumBar, ItemID.MythrilBar);

                ConversionRecipe(ItemID.AdamantiteBar, ItemID.TitaniumBar);
                ConversionRecipe(ItemID.TitaniumBar, ItemID.AdamantiteBar);

                ConversionRecipe(ItemID.RottenChunk, ItemID.Vertebrae);
                ConversionRecipe(ItemID.Vertebrae, ItemID.RottenChunk);

                ConversionRecipe(ItemID.ShadowScale, ItemID.TissueSample);
                ConversionRecipe(ItemID.TissueSample, ItemID.ShadowScale);

                ConversionRecipe(ItemID.CursedFlame, ItemID.Ichor);
                ConversionRecipe(ItemID.Ichor, ItemID.CursedFlame);

                ConversionRecipe(ItemID.SoulofNight, ItemID.SoulofLight);
                ConversionRecipe(ItemID.SoulofLight, ItemID.SoulofNight);

                ConversionRecipe(ItemID.EbonstoneBlock, ItemID.CrimstoneBlock);
                ConversionRecipe(ItemID.CrimstoneBlock, ItemID.EbonstoneBlock);

                ConversionRecipe(ItemID.EbonsandBlock, ItemID.CrimsandBlock);
                ConversionRecipe(ItemID.CrimsandBlock, ItemID.EbonsandBlock);

                ConversionRecipe(ItemID.CorruptSandstone, ItemID.CrimsonSandstone);
                ConversionRecipe(ItemID.CrimsonSandstone, ItemID.CorruptSandstone);

                ConversionRecipe(ItemID.CorruptHardenedSand, ItemID.CrimsonHardenedSand);
                ConversionRecipe(ItemID.CrimsonHardenedSand, ItemID.CorruptHardenedSand);

                ConversionRecipe(ItemID.PurpleIceBlock, ItemID.RedIceBlock);
                ConversionRecipe(ItemID.RedIceBlock, ItemID.PurpleIceBlock);

                ConversionRecipe(ItemID.CorruptSeeds, ItemID.CrimsonSeeds);
                ConversionRecipe(ItemID.CrimsonSeeds, ItemID.CorruptSeeds);

                ConversionRecipe(ItemID.VileMushroom, ItemID.ViciousMushroom);
                ConversionRecipe(ItemID.ViciousMushroom, ItemID.VileMushroom);

                ConversionRecipe(ItemID.CorruptionKey, ItemID.CrimsonKey);
                ConversionRecipe(ItemID.CrimsonKey, ItemID.CorruptionKey);

                ConversionRecipe(ItemID.CorruptFishingCrate, ItemID.CrimsonFishingCrate);
                ConversionRecipe(ItemID.CrimsonFishingCrate, ItemID.CorruptFishingCrate);

                ConversionRecipe(ItemID.CorruptFishingCrateHard, ItemID.CrimsonFishingCrateHard);
                ConversionRecipe(ItemID.CrimsonFishingCrateHard, ItemID.CorruptFishingCrateHard);
            }

            if (QoLCompendium.itemConfig.MobileStorages)
            {
                Recipe moneyTrough = Recipe.Create(ItemID.MoneyTrough);
                moneyTrough.AddIngredient(ItemID.PiggyBank);
                moneyTrough.AddTile(TileID.Anvils);
                moneyTrough.Register();
            }

            if (QoLCompendium.itemConfig.Pylons)
            {
                Recipe universalPylon = Recipe.Create(ItemID.TeleportationPylonVictory);
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
                universalPylon.AddTile(TileID.HeavyWorkBench);
                universalPylon.Register();
            }
        }

        private static void ConversionRecipe(int ingredient, int result)
        {
            Recipe conversion = Recipe.Create(result);
            conversion.AddIngredient(ingredient);
            conversion.AddTile(TileID.Anvils);
            conversion.Register();
        }
    }

    public class RecipeGroups : ModSystem
    {
        public override void AddRecipeGroups()
        {
            RecipeGroup anvils = new(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.IronAnvil)}",
                ItemID.IronAnvil, ItemID.LeadAnvil);
            RecipeGroup.RegisterGroup(nameof(ItemID.IronAnvil), anvils);

            RecipeGroup hmAnvils = new(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.MythrilAnvil)}",
                ItemID.MythrilAnvil, ItemID.OrichalcumAnvil);
            RecipeGroup.RegisterGroup(nameof(ItemID.MythrilAnvil), hmAnvils);

            RecipeGroup hmForges = new(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.AdamantiteForge)}",
                ItemID.AdamantiteForge, ItemID.TitaniumForge);
            RecipeGroup.RegisterGroup(nameof(ItemID.AdamantiteForge), hmForges);

            RecipeGroup altars = new(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ModContent.ItemType<DemonAltar>())}",
                ModContent.ItemType<DemonAltar>(), ModContent.ItemType<CrimsonAltar>());
            RecipeGroup.RegisterGroup("Altars", altars);

            RecipeGroup tombstones = new(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.Tombstone)}", 
                ItemID.Tombstone, ItemID.GraveMarker, 
                ItemID.CrossGraveMarker, ItemID.Headstone, 
                ItemID.Gravestone, ItemID.Obelisk, 
                ItemID.RichGravestone1, ItemID.RichGravestone2, 
                ItemID.RichGravestone3, ItemID.RichGravestone4, 
                ItemID.RichGravestone5);
            RecipeGroup.RegisterGroup(nameof(ItemID.Tombstone), tombstones);

            RecipeGroup bookcases = new(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.Bookcase)}",
                ItemID.Bookcase, ItemID.BlueDungeonBookcase, ItemID.BoneBookcase, ItemID.BorealWoodBookcase,
                ItemID.CactusBookcase, ItemID.CrystalBookCase, ItemID.DynastyBookcase, ItemID.EbonwoodBookcase,
                ItemID.FleshBookcase, ItemID.FrozenBookcase, ItemID.GlassBookcase, ItemID.GoldenBookcase,
                ItemID.GothicBookcase, ItemID.GraniteBookcase, ItemID.GreenDungeonBookcase, ItemID.HoneyBookcase,
                ItemID.LivingWoodBookcase, ItemID.MarbleBookcase, ItemID.MeteoriteBookcase, ItemID.MushroomBookcase,
                ItemID.ObsidianBookcase, ItemID.PalmWoodBookcase, ItemID.PearlwoodBookcase, ItemID.PinkDungeonBookcase,
                ItemID.PumpkinBookcase, ItemID.RichMahoganyBookcase, ItemID.ShadewoodBookcase, ItemID.SkywareBookcase,
                ItemID.SlimeBookcase, ItemID.SpookyBookcase, ItemID.SteampunkBookcase, ItemID.AshWoodBookcase);
            RecipeGroup.RegisterGroup(nameof(ItemID.Bookcase), bookcases);

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
            RecipeGroup.RegisterGroup(nameof(ItemID.WoodenTable), tables);

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
            RecipeGroup.RegisterGroup(nameof(ItemID.WoodenChair), chairs);

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
            RecipeGroup.RegisterGroup(nameof(ItemID.WoodenSink), sinks);
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