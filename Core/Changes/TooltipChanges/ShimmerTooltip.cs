using Terraria.Enums;

namespace QoLCompendium.Core.Changes.TooltipChanges
{
    public class ShimmerTooltip : GlobalItem
    {
        private static Item _shimmerItemDisplay;

        private static NPC _shimmerNPCDisplay;

        public override void SetStaticDefaults()
        {
            _shimmerItemDisplay = new Item();
            _shimmerNPCDisplay = new NPC();
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.ShimmerableTooltip) ShimmmerableTooltips(item, tooltips);
        }

        public void ShimmmerableTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (!item.CanShimmer())
                return;

            int countsAsIem = ItemID.Sets.ShimmerCountsAsItem[item.type];
            int type = countsAsIem != -1 ? countsAsIem : item.type;
            int transformsToItem = ItemID.Sets.ShimmerTransformToItem[type];
            int npcID = -1;

            if (type == ItemID.GelBalloon && !NPC.unlockedSlimeRainbowSpawn && !QoLCompendium.mainConfig.NoTownSlimes)
            {
                npcID = NPCID.TownSlimeRainbow;
            }
            else if (item.makeNPC > 0)
            {
                int npc = NPCID.Sets.ShimmerTransformToNPC[item.makeNPC];
                npcID = npc != -1 ? npc : item.makeNPC;
            }
            else if (type == ItemID.LunarBrick)
            {
                MoonPhase moonPhase = Main.GetMoonPhase();
                transformsToItem = (int)moonPhase switch
                {
                    5 => ItemID.StarRoyaleBrick,
                    6 => ItemID.CryocoreBrick,
                    7 => ItemID.CosmicEmberBrick,
                    0 => ItemID.HeavenforgeBrick,
                    1 => ItemID.LunarRustBrick,
                    2 => ItemID.AstraBrick,
                    3 => ItemID.DarkCelestialBrick,
                    _ => ItemID.MercuryBrick,
                };
            }
            else if (item.createTile == TileID.MusicBoxes)
            {
                transformsToItem = ItemID.MusicBox;
            }


            string shimmerTextValue = Common.GetTooltipValue("Shimmerable");
            if (transformsToItem != -1)
            {
                _shimmerItemDisplay.SetDefaults(transformsToItem);
                shimmerTextValue = Common.GetTooltipValue("ShimmerableIntoItem", transformsToItem, _shimmerItemDisplay.Name);
            }
            else if (npcID != -1)
            {
                _shimmerNPCDisplay.SetDefaults(npcID, default);
                shimmerTextValue = Common.GetTooltipValue("ShimmerableIntoNPC", _shimmerNPCDisplay.GivenOrTypeName);
            }
            else
            {
                int coinLuck = ItemID.Sets.CoinLuckValue[type];
                if (coinLuck <= 0)
                    return;
                shimmerTextValue = Common.GetTooltipValue("ShimmerCoinLuck", $"+{coinLuck:##,###}");
            }
            var tooltipLine = new TooltipLine(Mod, "ShimmerInfo", shimmerTextValue) { OverrideColor = Color.Plum };
            Common.AddLastTooltip(tooltips, tooltipLine);
        }
    }
}
