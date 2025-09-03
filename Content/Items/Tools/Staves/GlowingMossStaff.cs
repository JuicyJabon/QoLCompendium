using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using System.Collections.ObjectModel;
using Terraria.Enums;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Content.Items.Tools.Staves
{
    public class GlowingMossStaff : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.RegrowthStaves;

        public int Mode = 0;

        public readonly HashSet<int> MossTypes = new()
        {
            TileID.ArgonMoss,
            TileID.KryptonMoss,
            TileID.LavaMoss,
            TileID.VioletMoss,
            TileID.XenonMoss,
            TileID.RainbowMoss
        };

        public readonly HashSet<int> BrickMossTypes = new()
        {
            TileID.ArgonMossBrick,
            TileID.KryptonMossBrick,
            TileID.LavaMossBrick,
            TileID.VioletMossBrick,
            TileID.XenonMossBrick,
            TileID.RainbowMossBrick
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
            Item.createTile = MossTypes.ElementAt(Mode);
            if (Main.tile[Main.mouseX, Main.mouseY].TileType == TileID.GrayBrick)
                Item.createTile = BrickMossTypes.ElementAt(Mode);
        }

        public override void RightClick(Player player)
        {
            Mode++;
            if (Mode > 5)
                Mode = 0;
        }

        public override void OnConsumeItem(Player player) => Item.stack++;

        public override void UpdateInventory(Player player)
        {
            Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.GlowingMossStaff.Moss" + Mode.ToString()));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine placeable = tooltips.Find(l => l.Name == "Placeable");
            TooltipLine text = new(Mod, "MossStaffPlaceable", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.GlowingMossStaffPlaceable"));
            tooltips.Insert(tooltips.IndexOf(placeable), text);
            tooltips.RemoveAll((x) => x.Name == "Placeable" && x.Mod == "Terraria");

            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.RegrowthStaves);
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
