using QoLCompendium.Tweaks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class BannerBox : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<QoLCConfig>().BBox;
        }

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 17;
            Item.height = 15;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<BannerBox>(), 1).AddIngredient(ItemID.Wood, 12).AddIngredient(ItemID.Cobweb, 4).AddTile(TileID.WorkBenches).Register();
        }

        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                for (int i = 0; i < NPCID.Count; i++)
                {
                    int bItem = ContentSamples.NpcsByNetId[i].BannerID();

                    if (NPC.killCount[i] >= ItemID.Sets.KillsToBanner[bItem])
                    {
                        player.HasNPCBannerBuff(bItem);
                        player.AddBuff(BuffID.MonsterBanner, 2);
                        Main.buffNoTimeDisplay[BuffID.MonsterBanner] = true;
                        Main.SceneMetrics.NPCBannerBuff[bItem] = true;
                        Main.SceneMetrics.hasBanner = true;
                    }
                }
            }
        }
    }
}
