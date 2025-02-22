﻿using QoLCompendium.Content.Tiles.Pylons;
using QoLCompendium.Core.Changes;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Placeables.Pylons
{
    public class CorruptionPylon : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<CorruptionPylonTile>(), 0);
            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 10, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipChanges.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.Pylons);
        }
    }
}
