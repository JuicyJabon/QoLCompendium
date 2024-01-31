namespace QoLCompendium.Tweaks
{
    public class TooltipChanges : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine fav = tooltips.Find(l => l.Name == "Favorite");
            TooltipLine favDescr = tooltips.Find(l => l.Name == "FavoriteDesc");

            if (QoLCompendium.tooltipConfig.NoFavoriteTooltip) tooltips.Remove(fav);
            if (QoLCompendium.tooltipConfig.NoFavoriteTooltip) tooltips.Remove(favDescr);
            if (QoLCompendium.tooltipConfig.ShimmerableTooltip) ShimmmerableTooltips(item, tooltips);
        }

        public static void AddShimmerTooltip(List<TooltipLine> tooltips, TooltipLine tooltip)
        {
            var materialTooltip = tooltips.FindLast(t => t.Mod == "Terraria" && t.Name != "Expert" && t.Name != "Master")!;
            tooltips.AddAfter(materialTooltip, tooltip);
        }

        public bool CanShimmer(Item item)
        {
            var shimmerEquivalentType = ItemID.Sets.ShimmerCountsAsItem[item.type] != -1
                ? ItemID.Sets.ShimmerCountsAsItem[item.type]
                : item.type;

            return ItemID.Sets.ShimmerTransformToItem[shimmerEquivalentType] > 0 ||
                   ShimmerTransforms.GetDecraftingRecipeIndex(shimmerEquivalentType) > -1 ||
                   ItemID.Sets.CoinLuckValue[item.type] > 0 || item.makeNPC > 0;
        }

        public void ShimmmerableTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (!CanShimmer(item))
            {
                return;
            }

            string tooltip = "";
            int itemTransform = ItemID.Sets.ShimmerCountsAsItem[item.type];
            int sourceItem = itemTransform == -1 ? item.type : itemTransform;
            int targetItem = ItemID.Sets.ShimmerTransformToItem[sourceItem];
            var NPCTransform = NPCID.Sets.ShimmerTransformToNPC[item.makeNPC];
            var targetNPC = NPCTransform == -1 ? item.makeNPC : NPCTransform;
            int coinLuckValue = ItemID.Sets.CoinLuckValue[sourceItem];
            int decraftingRecipeIndex = ShimmerTransforms.GetDecraftingRecipeIndex(sourceItem);

            if (targetItem > 0)
            {
                tooltip = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.Shimmerable");
            }

            if (sourceItem == ItemID.GelBalloon)
            {
                tooltip = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.Shimmerable");
            }

            if (targetNPC > 0)
            {
                tooltip = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.Shimmerable");
            }

            if (coinLuckValue > 0)
            {
                tooltip = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.Shimmerable");
            }

            var tooltipLine = new TooltipLine(Mod, "ShimmerInfo", tooltip);
            tooltipLine.OverrideColor = Color.Plum;
            AddShimmerTooltip(tooltips, tooltipLine);
        }

        public NPC NPCIDtoNPC(int id)
        {
            return ContentSamples.NpcsByNetId[id];
        }
    }

    public static class ListExtension
    {
        public static void AddAfter<T>(this List<T> list, T element, T item)
        {
            var idx = list.IndexOf(element);
            list.Insert(idx + 1, item);
        }
    }
}
