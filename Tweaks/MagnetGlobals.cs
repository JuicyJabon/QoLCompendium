using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    public class MagnetGlobals : GlobalItem
    {
        public const int BaseMagnetRange = 8400;
        public const int HellMagnetRange = 16800;
        public const int HallowedMagnetRange = 33600;
        public const int SpookyMagnetRange = 67200;
        public const int LunarMagnetRange = 268800;

        public override void Update(Item item, ref float gravity, ref float maxFallSpeed)
        {
            MagnetPlayer mPlayer = Main.LocalPlayer.GetModPlayer<MagnetPlayer>();

            if (item.active && item.playerIndexTheItemIsReservedFor == Main.LocalPlayer.whoAmI)
            {
                if (item.type == ItemID.Heart || item.type == ItemID.CandyApple || item.type == ItemID.CandyCane || item.type == ItemID.Star || item.type == ItemID.SoulCake || item.type == ItemID.SugarPlum || item.type == ItemID.NebulaPickup1 || item.type == ItemID.NebulaPickup2 || item.type == ItemID.NebulaPickup3)
                {
                    return;
                }

                if (Main.LocalPlayer.Distance(item.Center) <= BaseMagnetRange && mPlayer.BaseMagnet)
                {
                    item.noGrabDelay = 0;
                    item.Center = Main.LocalPlayer.Center;

                    if (Main.netMode != NetmodeID.SinglePlayer)
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item.whoAmI);
                }

                if (Main.LocalPlayer.Distance(item.Center) <= HellMagnetRange && mPlayer.HellMagnet)
                {
                    item.noGrabDelay = 0;
                    item.Center = Main.LocalPlayer.Center;

                    if (Main.netMode != NetmodeID.SinglePlayer)
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item.whoAmI);
                }

                if (Main.LocalPlayer.Distance(item.Center) <= HallowedMagnetRange && mPlayer.HallowedMagnet)
                {
                    item.noGrabDelay = 0;
                    item.Center = Main.LocalPlayer.Center;

                    if (Main.netMode != NetmodeID.SinglePlayer)
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item.whoAmI);
                }

                if (Main.LocalPlayer.Distance(item.Center) <= SpookyMagnetRange && mPlayer.SpookyMagnet)
                {
                    item.noGrabDelay = 0;
                    item.Center = Main.LocalPlayer.Center;

                    if (Main.netMode != NetmodeID.SinglePlayer)
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item.whoAmI);
                }

                if (Main.LocalPlayer.Distance(item.Center) <= LunarMagnetRange && mPlayer.LunarMagnet)
                {
                    item.noGrabDelay = 0;
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
        public bool HellMagnet = false;
        public bool HallowedMagnet = false;
        public bool SpookyMagnet = false;
        public bool LunarMagnet = false;

        public override void Initialize()
        {
            BaseMagnet = false;
            HellMagnet = false;
            HallowedMagnet = false;
            SpookyMagnet = false;
            LunarMagnet = false;
        }

        public override void ResetEffects()
        {
            BaseMagnet = false;
            HellMagnet = false;
            HallowedMagnet = false;
            SpookyMagnet = false;
            LunarMagnet = false;
        }

        public override void UpdateDead()
        {
            BaseMagnet = false;
            HellMagnet = false;
            HallowedMagnet = false;
            SpookyMagnet = false;
            LunarMagnet = false;
        }
    }
}
