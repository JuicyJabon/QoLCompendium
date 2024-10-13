using QoLCompendium.Core;
using QoLCompendium.Core.Changes;
using Terraria.Enums;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Content.Items.Tools.Staves
{
    public class MossStaff : ModItem
    {
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
            Item.createTile = TileID.BlueMoss;
            Item.UseSound = SoundID.Item1;
            Item.knockBack = 3f;
            Item.SetShopValues(ItemRarityColor.LightPurple6, Item.sellPrice(0, 0, 50));
            Item.DamageType = DamageClass.Melee;
        }

        public override void SaveData(TagCompound tag)
        {
            tag["MossStaffMode"] = Mode;
        }

        public override void LoadData(TagCompound tag)
        {
            Mode = tag.GetInt("MossStaffMode");
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void HoldItem(Player player)
        {
            if (Mode == 0)
            {
                Item.createTile = TileID.BlueMoss;
                if (Main.tile[Main.mouseX, Main.mouseY].TileType == TileID.GrayBrick)
                    Item.createTile = TileID.BlueMossBrick;
            }
            if (Mode == 1)
            {
                Item.createTile = TileID.BrownMoss;
                if (Main.tile[Main.mouseX, Main.mouseY].TileType == TileID.GrayBrick)
                    Item.createTile = TileID.BrownMossBrick;
            }
            if (Mode == 2)
            {
                Item.createTile = TileID.GreenMoss;
                if (Main.tile[Main.mouseX, Main.mouseY].TileType == TileID.GrayBrick)
                    Item.createTile = TileID.GreenMossBrick;
            }
            if (Mode == 3)
            {
                Item.createTile = TileID.PurpleMoss;
                if (Main.tile[Main.mouseX, Main.mouseY].TileType == TileID.GrayBrick)
                    Item.createTile = TileID.PurpleMossBrick;
            }
            if (Mode == 4)
            {
                Item.createTile = TileID.RedMoss;
                if (Main.tile[Main.mouseX, Main.mouseY].TileType == TileID.GrayBrick)
                    Item.createTile = TileID.RedMossBrick;
            }
        }

        public override void UpdateInventory(Player player)
        {
            if (Mode == 0)
            {
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.MossStaff.BlueMoss"));
            }
            if (Mode == 1)
            {
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.MossStaff.BrownMoss"));
            }
            if (Mode == 2)
            {
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.MossStaff.GreenMoss"));
            }
            if (Mode == 3)
            {
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.MossStaff.PurpleMoss"));
            }
            if (Mode == 4)
            {
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.MossStaff.RedMoss"));
            }
        }

        public override void RightClick(Player player)
        {
            Mode++;
            if (Mode > 4)
            {
                Mode = 0;
            }
        }

        public override void OnConsumeItem(Player player) => Item.stack++;

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine placeable = tooltips.Find(l => l.Name == "Placeable");
            TooltipLine text = new(Mod, "MossStaffPlaceable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.MossStaffPlaceable"));
            tooltips.Insert(tooltips.IndexOf(placeable), text);
            tooltips.RemoveAll((x) => x.Name == "Placeable" && x.Mod == "Terraria");

            TooltipChanges.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.RegrowthStaves);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.RegrowthStaves, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.StoneBlock, 12);
            r.AddIngredient(ItemID.GrayBrick, 12);
            r.AddIngredient(ItemID.BlueMoss, 5);
            r.AddIngredient(ItemID.BrownMoss, 5);
            r.AddIngredient(ItemID.GreenMoss, 5);
            r.AddIngredient(ItemID.PurpleMoss, 5);
            r.AddIngredient(ItemID.RedMoss, 5);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
