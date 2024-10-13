using QoLCompendium.Core;
using QoLCompendium.Core.Changes;
using Terraria.Enums;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Content.Items.Tools.Staves
{
    public class GlowingMossStaff : ModItem
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
            Item.createTile = TileID.ArgonMoss;
            Item.UseSound = SoundID.Item1;
            Item.knockBack = 3f;
            Item.SetShopValues(ItemRarityColor.LightPurple6, Item.sellPrice(0, 0, 50));
            Item.DamageType = DamageClass.Melee;
        }

        public override void SaveData(TagCompound tag)
        {
            tag["GlowingMossStaffMode"] = Mode;
        }

        public override void LoadData(TagCompound tag)
        {
            Mode = tag.GetInt("GlowingMossStaffMode");
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void HoldItem(Player player)
        {
            if (Mode == 0)
            {
                Item.createTile = TileID.ArgonMoss;
                if (Main.tile[Main.mouseX, Main.mouseY].TileType == TileID.GrayBrick)
                    Item.createTile = TileID.ArgonMossBrick;
            }
            if (Mode == 1)
            {
                Item.createTile = TileID.KryptonMoss;
                if (Main.tile[Main.mouseX, Main.mouseY].TileType == TileID.GrayBrick)
                    Item.createTile = TileID.KryptonMossBrick;
            }
            if (Mode == 2)
            {
                Item.createTile = TileID.LavaMoss;
                if (Main.tile[Main.mouseX, Main.mouseY].TileType == TileID.GrayBrick)
                    Item.createTile = TileID.LavaMossBrick;
            }
            if (Mode == 3)
            {
                Item.createTile = TileID.VioletMoss;
                if (Main.tile[Main.mouseX, Main.mouseY].TileType == TileID.GrayBrick)
                    Item.createTile = TileID.VioletMossBrick;
            }
            if (Mode == 4)
            {
                Item.createTile = TileID.XenonMoss;
                if (Main.tile[Main.mouseX, Main.mouseY].TileType == TileID.GrayBrick)
                    Item.createTile = TileID.XenonMossBrick;
            }
            if (Mode == 5)
            {
                Item.createTile = TileID.RainbowMoss;
                if (Main.tile[Main.mouseX, Main.mouseY].TileType == TileID.GrayBrick)
                    Item.createTile = TileID.RainbowMossBrick;
            }
        }

        public override void UpdateInventory(Player player)
        {
            if (Mode == 0)
            {
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.GlowingMossStaff.ArgonMoss"));
            }
            if (Mode == 1)
            {
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.GlowingMossStaff.KryptonMoss"));
            }
            if (Mode == 2)
            {
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.GlowingMossStaff.LavaMoss"));
            }
            if (Mode == 3)
            {
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.GlowingMossStaff.NeonMoss"));
            }
            if (Mode == 4)
            {
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.GlowingMossStaff.XenonMoss"));
            }
            if (Mode == 5)
            {
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.GlowingMossStaff.HeliumMoss"));
            }
        }

        public override void RightClick(Player player)
        {
            Mode++;
            if (Mode > 5)
            {
                Mode = 0;
            }
        }

        public override void OnConsumeItem(Player player) => Item.stack++;

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine placeable = tooltips.Find(l => l.Name == "Placeable");
            TooltipLine text = new(Mod, "MossStaffPlaceable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.GlowingMossStaffPlaceable"));
            tooltips.Insert(tooltips.IndexOf(placeable), text);
            tooltips.RemoveAll((x) => x.Name == "Placeable" && x.Mod == "Terraria");

            TooltipChanges.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.RegrowthStaves);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.RegrowthStaves, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.StoneBlock, 12);
            r.AddIngredient(ItemID.GrayBrick, 12);
            r.AddIngredient(ItemID.ArgonMoss, 5);
            r.AddIngredient(ItemID.KryptonMoss, 5);
            r.AddIngredient(ItemID.LavaMoss, 5);
            r.AddIngredient(ItemID.VioletMoss, 5);
            r.AddIngredient(ItemID.XenonMoss, 5);
            r.AddIngredient(ItemID.RainbowMoss, 5);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
