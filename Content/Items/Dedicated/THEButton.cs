using Terraria.Enums;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Content.Items.Dedicated
{
    public class THEButton : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.DedicatedItems;

        public new string LocalizationCategory => "Items.Dedicated";

        public static bool used;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 18;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.SetShopValues(ItemRarityColor.StrongRed10, Item.buyPrice(0, 5, 0, 0));
        }

        public override bool? UseItem(Player player)
        {
            used = true;
            TextHelper.PrintText(Language.GetTextValue("Mods.QoLCompendium.Messages.THEButton"));
            return true;
        }

        public override void SaveData(TagCompound tag)
        {
            tag.Add("itemUsed", used);
        }

        public override void LoadData(TagCompound tag)
        {
            used = tag.GetBool("itemUsed");
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine dedicated = new(Mod, "Dedicated", Language.GetTextValue("Mods.QoLCompendium.DedicatedTooltips.Jack"))
            {
                OverrideColor = Common.ColorSwap(Color.LightSeaGreen, Color.Aquamarine, 3)
            };
            tooltips.Add(dedicated);

            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.DedicatedItems);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.DedicatedItems, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddRecipeGroup(RecipeGroupID.IronBar, 12);
            r.AddIngredient(ItemID.CyanHusk);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
