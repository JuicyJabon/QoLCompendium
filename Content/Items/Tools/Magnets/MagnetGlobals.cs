namespace QoLCompendium.Content.Items.Tools.Magnets
{
    public class MagnetGlobals : GlobalItem
    {
        public const int BaseMagnetRange = 8400;
        public const int HellstoneMagnetRange = 16800;
        public const int SoulMagnetMagnetRange = 33600;
        public const int SpectreMagnetRange = 67200;
        public const int LunarMagnetRange = 268800;

        public override void Update(Item item, ref float gravity, ref float maxFallSpeed)
        {
            MagnetPlayer mPlayer = Main.LocalPlayer.GetModPlayer<MagnetPlayer>();
            if (item.active && Main.LocalPlayer.whoAmI == Main.myPlayer)
            {
                if (Common.PowerUpItems.Contains(item.type))
                    return;

                if (item.noGrabDelay != 0 || item.playerIndexTheItemIsReservedFor != Main.LocalPlayer.whoAmI)
                    return;

                if (Main.LocalPlayer.Distance(item.Center) <= BaseMagnetRange && mPlayer.BaseMagnet)
                {
                    item.beingGrabbed = true;
                    item.Center = Main.LocalPlayer.Center;

                    if (Main.netMode != NetmodeID.SinglePlayer)
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item.whoAmI, 1);
                }

                if (Main.LocalPlayer.Distance(item.Center) <= HellstoneMagnetRange && mPlayer.HellstoneMagnet)
                {
                    item.beingGrabbed = true;
                    item.Center = Main.LocalPlayer.Center;

                    if (Main.netMode != NetmodeID.SinglePlayer)
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item.whoAmI, 1);
                }

                if (Main.LocalPlayer.Distance(item.Center) <= SoulMagnetMagnetRange && mPlayer.SoulMagnet)
                {
                    item.beingGrabbed = true;
                    item.Center = Main.LocalPlayer.Center;

                    if (Main.netMode != NetmodeID.SinglePlayer)
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item.whoAmI, 1);
                }

                if (Main.LocalPlayer.Distance(item.Center) <= SpectreMagnetRange && mPlayer.SpectreMagnet)
                {
                    item.beingGrabbed = true;
                    item.Center = Main.LocalPlayer.Center;

                    if (Main.netMode != NetmodeID.SinglePlayer)
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item.whoAmI, 1);
                }

                if (Main.LocalPlayer.Distance(item.Center) <= LunarMagnetRange && mPlayer.LunarMagnet)
                {
                    item.beingGrabbed = true;
                    item.Center = Main.LocalPlayer.Center;

                    if (Main.netMode != NetmodeID.SinglePlayer)
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item.whoAmI, 1);
                }
            }
        }
    }

    public class MagnetPlayer : ModPlayer
    {
        public bool BaseMagnet;
        public bool HellstoneMagnet;
        public bool SoulMagnet;
        public bool SpectreMagnet;
        public bool LunarMagnet;

        public override void Initialize() => Reset();

        public override void ResetEffects() => Reset();

        public override void UpdateDead() => Reset();

        public override void UpdateEquips()
        {
            UpdateMagnets(Common.GetAllInventoryItemsList(Player).ToArray());
        }

        private void UpdateMagnets(Item[] items)
        {
            foreach (var item in items)
            {
                if (item.ModItem is Magnet magnet && magnet.Enabled)
                    BaseMagnet = true;

                if (item.ModItem is HellstoneMagnet hellstoneMagnet && hellstoneMagnet.Enabled)
                    HellstoneMagnet = true;

                if (item.ModItem is SoulMagnet soulMagnet && soulMagnet.Enabled)
                    SoulMagnet = true;

                if (item.ModItem is SpectreMagnet spectreMagnet && spectreMagnet.Enabled)
                    SpectreMagnet = true;

                if (item.ModItem is LunarMagnet lunarMagnet && lunarMagnet.Enabled)
                    LunarMagnet = true;
            }
        }

        private void Reset()
        {
            BaseMagnet = false;
            HellstoneMagnet = false;
            SoulMagnet = false;
            SpectreMagnet = false;
            LunarMagnet = false;
        }
    }
}
