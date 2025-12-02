using Humanizer;
using Terraria.Enums;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class PotionCrate : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.PotionCrate;

        public new string LocalizationCategory => "Items.Tools.Usables";

        public List<int> BuffIDList = [];
        public List<int> ItemIDList = [];

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 0, 20, 0));
        }

        public override void SaveData(TagCompound tag)
        {
            tag.Add("BuffIDList", BuffIDList);
            tag.Add("ItemIDList", ItemIDList);
        }

        public override void LoadData(TagCompound tag)
        {
            BuffIDList = (List<int>)tag.GetList<int>("BuffIDList");
            ItemIDList = (List<int>)tag.GetList<int>("ItemIDList");
        }

        public override bool ConsumeItem(Player player) => false;

        public override bool CanRightClick() => true;

        public override void RightClick(Player player)
        {
            if (Main.mouseItem.buffType > 0 && Main.mouseItem.stack >= QoLCompendium.mainConfig.EndlessBuffAmount && !BuffIDList.Contains(Main.mouseItem.buffType) && !ItemIDList.Contains(Main.mouseItem.type))
            {
                BuffIDList.Add(Main.mouseItem.buffType);
                ItemIDList.Add(Main.mouseItem.type);
                Main.mouseItem.stack -= QoLCompendium.mainConfig.EndlessBuffAmount;
                if (Main.mouseItem.stack == 0)
                {
                    Main.mouseItem.TurnToAir();
                }
            }
            else
            {
                if (BuffIDList.Count == 0 && ItemIDList.Count == 0) return;
                if (BuffIDList.Count > 0 && ItemIDList.Count > 0)
                {
                    Item.NewItem(Item.GetSource_FromThis(), player.position, ItemIDList.Last(), QoLCompendium.mainConfig.EndlessBuffAmount);
                    BuffIDList.RemoveAt(BuffIDList.Count - 1);
                    ItemIDList.RemoveAt(ItemIDList.Count - 1);
                }
            }
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine tip0 = tooltips.Find(l => l.Name == "Tooltip0");
            TooltipLine text = new(Mod, "PotionCrateTooltip", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.PotionCrateTooltip").FormatWith(QoLCompendium.mainConfig.EndlessBuffAmount));
            tooltips.Insert(tooltips.IndexOf(tip0), text);

            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.PotionCrate);
    }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.PotionCrate, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.Wood, 12);
            r.AddRecipeGroup(RecipeGroupID.IronBar, 4);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
