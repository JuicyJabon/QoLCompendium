using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class StarterBag : ModItem
    {
        public int type;
        public int curItem;
        public bool loadCount;

        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<ItemConfig>().StarterBag;
        }

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 15;
            Item.height = 12;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.rare = ItemRarityID.White;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            if (ModContent.GetInstance<QoLCConfig>().CustomItemQuantities != null)
            {
                loadCount = true;
            }
            for (int i = 0; i < ModContent.GetInstance<QoLCConfig>().CustomItems.Count; i++)
            {
                type = ModContent.GetInstance<QoLCConfig>().CustomItems[i].Type;
                if (loadCount)
                {
                    if (i <= ModContent.GetInstance<QoLCConfig>().CustomItemQuantities.Count - 1)
                    {
                        player.QuickSpawnItem(null, type, ModContent.GetInstance<QoLCConfig>().CustomItemQuantities[i]);
                    }
                    else
                    {
                        player.QuickSpawnItem(null, type, 1);
                    }
                }
                else
                {
                    player.QuickSpawnItem(null, type, 1);
                }
            }
        }
    }
}
