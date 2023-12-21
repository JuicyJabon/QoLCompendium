namespace QoLCompendium.Items.Tools
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
            if (QoLCompendium.mainConfig.CustomItems != null)
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
            if (QoLCompendium.mainConfig.CustomItems != null)
            {
                if (QoLCompendium.mainConfig.CustomItemQuantities != null)
                {
                    loadCount = true;
                }
                for (int i = 0; i < QoLCompendium.mainConfig.CustomItems.Count; i++)
                {
                    type = QoLCompendium.mainConfig.CustomItems[i].Type;
                    if (loadCount)
                    {
                        if (i <= QoLCompendium.mainConfig.CustomItemQuantities.Count - 1)
                        {
                            player.QuickSpawnItem(null, type, QoLCompendium.mainConfig.CustomItemQuantities[i]);
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
