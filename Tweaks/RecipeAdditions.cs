using QoLCompendium.Items.Placeables;

namespace QoLCompendium.Tweaks
{
    public class RecipeAdditions : ModSystem
    {
        public override void AddRecipes()
        {
            Recipe moneyTrough = Recipe.Create(ItemID.MoneyTrough);
            moneyTrough.AddIngredient(ItemID.PiggyBank);
            moneyTrough.AddTile(TileID.Anvils);
            moneyTrough.Register();

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
        }

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
