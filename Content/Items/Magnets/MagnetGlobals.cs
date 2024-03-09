namespace QoLCompendium.Content.Items.Magnets
{
    public class MagnetGlobals : GlobalItem
    {
        public const int BaseMagnetRange = 8400;
        public const int HellstoneMagnetRange = 16800;
        public const int ChlorophyteMagnetRange = 33600;
        public const int SpectreMagnetRange = 67200;
        public const int LunarMagnetRange = 268800;

        public override void Update(Item item, ref float gravity, ref float maxFallSpeed)
        {
            MagnetPlayer mPlayer = Main.LocalPlayer.GetModPlayer<MagnetPlayer>();
            if (item.active && item.playerIndexTheItemIsReservedFor == Main.myPlayer)
            {
                if (item.type == ItemID.Heart || item.type == ItemID.CandyApple || item.type == ItemID.CandyCane || item.type == ItemID.Star || item.type == ItemID.SoulCake || item.type == ItemID.SugarPlum || item.type == ItemID.NebulaPickup1 || item.type == ItemID.NebulaPickup2 || item.type == ItemID.NebulaPickup3)
                {
                    return;
                }

                if (Main.LocalPlayer.Distance(item.Center) <= BaseMagnetRange && mPlayer.BaseMagnet)
                {
                    item.noGrabDelay = 0;
                    item.beingGrabbed = true;
                    item.Center = Main.LocalPlayer.Center;

                    if (Main.netMode != NetmodeID.SinglePlayer)
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item.whoAmI);
                }

                if (Main.LocalPlayer.Distance(item.Center) <= HellstoneMagnetRange && mPlayer.HellstoneMagnet)
                {
                    item.noGrabDelay = 0;
                    item.beingGrabbed = true;
                    item.Center = Main.LocalPlayer.Center;

                    if (Main.netMode != NetmodeID.SinglePlayer)
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item.whoAmI);
                }

                if (Main.LocalPlayer.Distance(item.Center) <= ChlorophyteMagnetRange && mPlayer.ChlorophyteMagnet)
                {
                    item.noGrabDelay = 0;
                    item.beingGrabbed = true;
                    item.Center = Main.LocalPlayer.Center;

                    if (Main.netMode != NetmodeID.SinglePlayer)
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item.whoAmI);
                }

                if (Main.LocalPlayer.Distance(item.Center) <= SpectreMagnetRange && mPlayer.SpectreMagnet)
                {
                    item.noGrabDelay = 0;
                    item.beingGrabbed = true;
                    item.Center = Main.LocalPlayer.Center;

                    if (Main.netMode != NetmodeID.SinglePlayer)
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item.whoAmI);
                }

                if (Main.LocalPlayer.Distance(item.Center) <= LunarMagnetRange && mPlayer.LunarMagnet)
                {
                    item.noGrabDelay = 0;
                    item.beingGrabbed = true;
                    item.Center = Main.LocalPlayer.Center;

                    if (Main.netMode != NetmodeID.SinglePlayer)
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item.whoAmI);
                }
            }
        }
    }

    public class MagnetPlayer : ModPlayer
    {
        public bool BaseMagnet = false;
        public bool HellstoneMagnet = false;
        public bool ChlorophyteMagnet = false;
        public bool SpectreMagnet = false;
        public bool LunarMagnet = false;

        public override void Initialize()
        {
            BaseMagnet = false;
            HellstoneMagnet = false;
            ChlorophyteMagnet = false;
            SpectreMagnet = false;
            LunarMagnet = false;
        }

        public override void ResetEffects()
        {
            BaseMagnet = false;
            HellstoneMagnet = false;
            ChlorophyteMagnet = false;
            SpectreMagnet = false;
            LunarMagnet = false;
        }

        public override void UpdateDead()
        {
            BaseMagnet = false;
            HellstoneMagnet = false;
            ChlorophyteMagnet = false;
            SpectreMagnet = false;
            LunarMagnet = false;
        }
    }
}
