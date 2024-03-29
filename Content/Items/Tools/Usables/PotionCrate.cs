using QoLCompendium.Core;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class PotionCrate : ModItem
    {
#pragma warning disable CA2211
        public static List<int> BuffIDList = new() { };
        public static List<int> ItemIDList = new() { };
#pragma warning restore CA2211

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 15;
            Item.height = 12;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(gold: 4);
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
            if (Main.mouseItem.buffType > 0 && Main.mouseItem.stack >= 30 && !BuffIDList.Contains(Main.mouseItem.buffType) && !ItemIDList.Contains(Main.mouseItem.type))
            {
                BuffIDList.Add(Main.mouseItem.buffType);
                ItemIDList.Add(Main.mouseItem.type);
                Main.mouseItem.stack -= 30;
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
                    Item.NewItem(Item.GetSource_FromThis(), player.position, ItemIDList.Last(), 30);
                    BuffIDList.RemoveAt(BuffIDList.Count - 1);
                    ItemIDList.RemoveAt(ItemIDList.Count - 1);
                }
            }
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.PotionCrate, Type);
            r.AddIngredient(ItemID.Wood, 12);
            r.AddRecipeGroup(RecipeGroupID.IronBar, 4);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
