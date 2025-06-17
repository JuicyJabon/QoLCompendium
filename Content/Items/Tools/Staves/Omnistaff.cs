using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using Terraria.Enums;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Content.Items.Tools.Staves
{
    public class Omnistaff : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.RegrowthStaves;

        public int Mode = 0;

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
            Item.createTile = TileID.AshGrass;
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

        public override bool CanRightClick()
        {
            return true;
        }

        public override void UpdateInventory(Player player)
        {
            if (Mode == 0)
            {
                Item.createTile = TileID.Grass;
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.Omnistaff.StaffOfRegrowth"));
            }
            if (Mode == 1)
            {
                Item.createTile = TileID.CorruptGrass;
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.Omnistaff.StaffOfCysting"));
            }
            if (Mode == 2)
            {
                Item.createTile = TileID.CrimsonGrass;
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.Omnistaff.StaffOfHemorrhaging"));
            }
            if (Mode == 3)
            {
                Item.createTile = TileID.HallowedGrass;
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.Omnistaff.StaffOfHallowing"));
            }
            if (Mode == 4)
            {
                Item.createTile = TileID.JungleGrass;
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.Omnistaff.StaffOfOvergrowth"));
            }
            if (Mode == 5)
            {
                Item.createTile = TileID.CorruptJungleGrass;
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.Omnistaff.StaffOfOvergrownCysting"));
            }
            if (Mode == 6)
            {
                Item.createTile = TileID.CrimsonJungleGrass;
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.Omnistaff.StaffOfOvergrownHemorrhaging"));
            }
            if (Mode == 7)
            {
                Item.createTile = TileID.MushroomGrass;
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.Omnistaff.StaffOfShrooming"));
            }
            if (Mode == 8)
            {
                Item.createTile = TileID.AshGrass;
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.Omnistaff.StaffOfAshing"));
            }
        }

        public override void RightClick(Player player)
        {
            Mode++;
            if (Mode > 8)
            {
                Mode = 0;
            }
        }

        public override void OnConsumeItem(Player player) => Item.stack++;

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine placeable = tooltips.Find(l => l.Name == "Placeable");
            TooltipLine text = new(Mod, "OmnistaffEffect", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.OmnistaffPlaceable"));
            tooltips.Insert(tooltips.IndexOf(placeable), text);
            tooltips.RemoveAll((x) => x.Name == "Placeable" && x.Mod == "Terraria");

            TooltipChanges.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.RegrowthStaves);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.RegrowthStaves, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<StaffOfAshing>());
            r.AddIngredient(ModContent.ItemType<StaffOfCysting>());
            r.AddIngredient(ModContent.ItemType<StaffOfHallowing>());
            r.AddIngredient(ModContent.ItemType<StaffOfHemorrhaging>());
            r.AddIngredient(ModContent.ItemType<StaffOfOvergrownCysting>());
            r.AddIngredient(ModContent.ItemType<StaffOfOvergrownHemorrhaging>());
            r.AddIngredient(ModContent.ItemType<StaffOfOvergrowth>());
            r.AddIngredient(ItemID.StaffofRegrowth);
            r.AddIngredient(ModContent.ItemType<StaffOfShrooming>());
            r.AddTile(TileID.HeavyWorkBench);
            r.Register();
        }
    }
}
