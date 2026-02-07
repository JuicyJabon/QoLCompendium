using QoLCompendium.Content.Items.Tools.Usables;
using QoLCompendium.Core.PermanentBuffSystems;

namespace QoLCompendium.Core.Changes.BuffChanges
{
    public class InfiniteBannerBuffs : ModSystem
    {
        public static void AddBannerBuff(Item item)
        {
            if (item.IsAir || item == null)
                return;

            if (item.type == ModContent.ItemType<BannerBox>())
            {
                if (!NewPermanentBuffPlayer.Get(Main.LocalPlayer).InfBuffDisabledVanilla.Contains(BuffID.MonsterBanner))
                {
                    for (int i = 0; i < NPCLoader.NPCCount; i++)
                    {
                        int bItem = ContentSamples.NpcsByNetId[i].BannerID();
                        if (NPC.killCount[i] >= ItemID.Sets.KillsToBanner[Item.BannerToItem(bItem)])
                        {
                            Main.SceneMetrics.NPCBannerBuff[bItem] = true;
                            Main.SceneMetrics.hasBanner = true;
                        }
                    }
                }
                return;
            }

            if (!QoLCompendium.mainConfig.EndlessBanners)
                return;

            int bannerID = ItemToBanner(item);
            if (bannerID != -1 && item.createTile > -1 && item.stack >= QoLCompendium.mainConfig.EndlessBannerAmount)
            {
                if (!NewPermanentBuffPlayer.Get(Main.LocalPlayer).InfBuffDisabledVanilla.Contains(BuffID.MonsterBanner))
                {
                    Main.SceneMetrics.NPCBannerBuff[bannerID] = true;
                    Main.SceneMetrics.hasBanner = true;
                }
            }
        }

        public static void AddBannerTooltip(Item item)
        {
            if (item.IsAir || item == null)
                return;

            if (item.type == ModContent.ItemType<BannerBox>())
            {
                if (!QoLCPlayer.Get(Main.LocalPlayer).activeBuffs.Contains(BuffID.MonsterBanner))
                    QoLCPlayer.Get(Main.LocalPlayer).activeBuffs.Add(BuffID.MonsterBanner);
                QoLCPlayer.Get(Main.LocalPlayer).activeBuffItems.Add(ModContent.ItemType<BannerBox>());
            }

            if (!QoLCompendium.mainConfig.EndlessBanners)
                return;

            int bannerID = ItemToBanner(item);
            if (bannerID != -1 && item.createTile > -1 && item.stack >= QoLCompendium.mainConfig.EndlessBannerAmount)
            {
                if (!QoLCPlayer.Get(Main.LocalPlayer).activeBuffs.Contains(BuffID.MonsterBanner))
                    QoLCPlayer.Get(Main.LocalPlayer).activeBuffs.Add(BuffID.MonsterBanner);
                QoLCPlayer.Get(Main.LocalPlayer).activeBannerItems.Add(item.type);
            }
        }

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            if (Main.netMode != NetmodeID.Server)
                CheckBanners(Common.GetAllInventoryItemsList(Main.LocalPlayer));
        }

        public static void CheckBanners(IEnumerable<Item> items)
        {
            foreach (var item in items)
                AddBannerBuff(item);
        }

        public static void CheckBannerTooltips(IEnumerable<Item> items)
        {
            foreach (var item in items)
                AddBannerTooltip(item);
        }

        public static int ItemToBanner(Item item)
        {
            if (!ItemID.Sets.BannerStrength.IndexInRange(item.type) || !ItemID.Sets.BannerStrength[item.type].Enabled)
                return -1;

            if (item.createTile == TileID.Banners)
            {
                int style = item.placeStyle;
                int frameX = style * 18;
                int frameY = 0;
                if (style >= 90)
                {
                    frameX -= 1620;
                    frameY += 54;
                }

                if (frameX >= 396 || frameY >= 54)
                {
                    int styleX = frameX / 18 - 21;
                    for (int num4 = frameY; num4 >= 54; num4 -= 54)
                    {
                        styleX += 90;
                    }

                    return styleX;
                }
            }

            if (NPCLoader.BannerItemToNPC(item.type) != -1 && Main.SceneMetrics.NPCBannerBuff.IndexInRange(NPCLoader.BannerItemToNPC(item.type)))
                return NPCLoader.BannerItemToNPC(item.type);

            return -1;
        }
    }
}
