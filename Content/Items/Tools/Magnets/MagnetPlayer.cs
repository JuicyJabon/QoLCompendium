namespace QoLCompendium.Content.Items.Tools.Magnets
{
    public class MagnetPlayer : ModPlayer
    {
        public int currentAdditionalRange = 0;

        public override void Initialize() => Reset();

        public override void ResetEffects() => Reset();

        public override void UpdateDead() => Reset();

        public override void UpdateEquips()
        {
            UpdateMagnets(ItemUtils.GetAllInventoryItemsList(Player).ToArray());
        }

        public override void PostUpdate()
        {
            if (currentAdditionalRange > 0)
            {
                currentAdditionalRange = Math.Clamp(currentAdditionalRange, 0, 134400);

                foreach (Item item in Main.item)
                {
                    if (item == null || !item.active || item.IsAir || item.shimmerTime > 0f || (item.shimmered && !((double)item.velocity.Length() < 0.2)))
                        continue;

                    if (Constants.PowerUpItems.Contains(item.type))
                        continue;

                    if (item.noGrabDelay != 0 || item.playerIndexTheItemIsReservedFor != Player.whoAmI)
                        continue;

                    Player.ItemSpaceStatus itemSpaceStatus = Player.ItemSpace(item);
                    if (!Player.CanPullItem(item, itemSpaceStatus))
                        continue;

                    if (Player.Distance(item.Center) <= currentAdditionalRange)
                    {
                        item.beingGrabbed = true;
                        item.Center = Player.Center;

                        if (Main.netMode == NetmodeID.MultiplayerClient)
                            NetMessage.SendData(MessageID.SyncItem, number: item.whoAmI);
                    }
                }
            }
        }

        private void UpdateMagnets(Item[] items)
        {
            foreach (var item in items)
            {
                if (item.ModItem is BaseMagnet magnet && magnet.Enabled)
                    currentAdditionalRange += magnet.Range;
            }
        }

        private void Reset()
        {
            currentAdditionalRange = 0;
        }
    }
}
