using QoLCompendium.Core;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class BannerBox : ModItem
    {
        /*
        public List<Item> bannerItems;
        public List<int> BannerItemIDList = new() { };
        internal static readonly IDictionary<int, int> itemToBanner = new Dictionary<int, int>();
        */

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 19;
            Item.height = 11;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 12);
        }

        /*
        public override void SaveData(TagCompound tag)
        {
            tag.Add("bannerItems", bannerItems);
            tag.Add("BannerItemIDList", BannerItemIDList);
        }

        public override void LoadData(TagCompound tag)
        {
            bannerItems = tag.Get<List<Item>>("bannerItems");
            BannerItemIDList = tag.Get<List<int>>("BannerItemIDList");
        }


        public override bool ConsumeItem(Player player) => false;

        public override bool CanRightClick() => true;

        public override void RightClick(Player player)
        {
            Item clone = Main.mouseItem.Clone();
            clone.stack = 1;
            if (Main.mouseItem.stack >= 1 && itemToBanner.ContainsKey(clone.type) && !BannerItemIDList.Contains(clone.type) && !bannerItems.Contains(clone))
            {
                bannerItems.Add(clone);
                BannerItemIDList.Add(clone.type);
                Main.mouseItem.stack -= 1;
                if (Main.mouseItem.stack == 0)
                {
                    Main.mouseItem.TurnToAir();
                }
            }
            else
            {
                if (bannerItems.Count == 0 && BannerItemIDList.Count == 0) return;
                if (bannerItems.Count > 0 && BannerItemIDList.Count > 0)
                {
                    Item.NewItem(Item.GetSource_FromThis(), player.position, BannerItemIDList.Last(), 1);
                    bannerItems.RemoveAt(bannerItems.Count - 1);
                    BannerItemIDList.RemoveAt(BannerItemIDList.Count - 1);
                }
            }
        }

        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                foreach (var item1 in bannerItems)
                {
                    int type = item1.type;
                    if (item1.ModItem is not UnloadedItem && ItemID.Sets.BannerStrength[type].Enabled)
                    {
                        int bannerID = itemToBanner[type];

                        Main.LocalPlayer.HasNPCBannerBuff(bannerID);
                        Main.LocalPlayer.AddBuff(BuffID.MonsterBanner, 2);
                        Main.buffNoTimeDisplay[BuffID.MonsterBanner] = true;
                        Main.SceneMetrics.NPCBannerBuff[bannerID] = true;
                        Main.SceneMetrics.hasBanner = true;
                    }
                }
            }
        }
        */

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.BannerBox, Type);
            r.AddIngredient(ItemID.Wood, 12);
            r.AddIngredient(ItemID.Silk, 2);
            r.AddTile(TileID.Loom);
            r.Register();
        }
    }
}
