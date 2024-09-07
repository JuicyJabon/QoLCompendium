﻿namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class StarterBag : ModItem
    {
        public int type;
        public int curItem;
        public bool loadCount;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
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
            if (QoLCompendium.itemConfig.CustomItems != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void RightClick(Player player)
        {
            if (QoLCompendium.itemConfig.CustomItems != null)
            {
                if (QoLCompendium.itemConfig.CustomItemQuantities != null)
                {
                    loadCount = true;
                }
                for (int i = 0; i < QoLCompendium.itemConfig.CustomItems.Count; i++)
                {
                    type = QoLCompendium.itemConfig.CustomItems[i].Type;
                    if (loadCount)
                    {
                        if (i <= QoLCompendium.itemConfig.CustomItemQuantities.Count - 1)
                        {
                            player.QuickSpawnItem(null, type, QoLCompendium.itemConfig.CustomItemQuantities[i]);
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
}
