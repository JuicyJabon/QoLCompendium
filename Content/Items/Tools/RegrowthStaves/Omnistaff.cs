using Terraria.Enums;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Content.Items.Tools.RegrowthStaves
{
    public class Omnistaff : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.RegrowthStaves;

        public new string LocalizationCategory => "Items.Tools.RegrowthStaves";


        public int Mode = 0;

        public readonly HashSet<int> GrassTypes = new()
        {
            TileID.Grass,
            TileID.CorruptGrass,
            TileID.CrimsonGrass,
            TileID.HallowedGrass,
            TileID.JungleGrass,
            TileID.MushroomGrass,
            TileID.AshGrass,
        };

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 25;
            Item.useTime = 13;
            Item.autoReuse = true;
            Item.width = 24;
            Item.height = 28;
            Item.damage = 14;
            Item.createTile = TileID.Grass;
            Item.UseSound = SoundID.Item1;
            Item.knockBack = 3f;
            Item.SetShopValues(ItemRarityColor.LightPurple6, Item.sellPrice(0, 0, 50));
            Item.DamageType = DamageClass.Melee;
        }

        public override void SaveData(TagCompound tag)
        {
            tag["OmnistaffMode"] = Mode;
        }

        public override void LoadData(TagCompound tag)
        {
            Mode = tag.GetInt("OmnistaffMode");
        }

        public override bool CanRightClick() => true;

        public override void HoldItem(Player player)
        {
            Item.createTile = GrassTypes.ElementAt(Mode);
            if (Main.tile[Main.mouseX, Main.mouseY].TileType == TileID.Mud && GrassTypes.ElementAt(Mode) == TileID.CorruptGrass)
                Item.createTile = TileID.CorruptJungleGrass;
            else if (Main.tile[Main.mouseX, Main.mouseY].TileType == TileID.Mud && GrassTypes.ElementAt(Mode) == TileID.CrimsonGrass)
                Item.createTile = TileID.CrimsonJungleGrass;
        }

        public override void RightClick(Player player)
        {
            Mode++;
            if (Mode > 6)
                Mode = 0;
        }

        public override void OnConsumeItem(Player player) => Item.stack++;

        public override void UpdateInventory(Player player)
        {
            Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.Omnistaff.Grass" + Mode.ToString()));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine placeable = tooltips.Find(l => l.Name == "Placeable");
            TooltipLine text = new(Mod, "OmnistaffEffect", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.OmnistaffPlaceable"));
            tooltips.Insert(tooltips.IndexOf(placeable), text);
            tooltips.RemoveAll((x) => x.Name == "Placeable" && x.Mod == "Terraria");

            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.RegrowthStaves);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.RegrowthStaves, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<StaffOfAshing>());
            r.AddIngredient(ModContent.ItemType<StaffOfCysting>());
            r.AddIngredient(ModContent.ItemType<StaffOfHallowing>());
            r.AddIngredient(ModContent.ItemType<StaffOfHemorrhaging>());
            r.AddIngredient(ModContent.ItemType<StaffOfOvergrowth>());
            r.AddIngredient(ItemID.StaffofRegrowth);
            r.AddIngredient(ModContent.ItemType<StaffOfShrooming>());
            r.AddTile(TileID.HeavyWorkBench);
            r.Register();
        }
    }
}
