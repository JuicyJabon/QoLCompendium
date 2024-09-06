using QoLCompendium.Core;

namespace QoLCompendium.Content.Items.Magnets
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
            List<int> ThoriumPowerUpItems = new()
            {
                Common.GetModItem(ModConditions.thoriumMod, "InspirationNote"),
                Common.GetModItem(ModConditions.thoriumMod, "InspirationNoteStatue"),
                Common.GetModItem(ModConditions.thoriumMod, "InspirationNoteNoble"),
                Common.GetModItem(ModConditions.thoriumMod, "InspirationNoteRhapsodist"),
                Common.GetModItem(ModConditions.thoriumMod, "MeatSlab"),
                Common.GetModItem(ModConditions.thoriumMod, "GreatFlesh")
            };
            List<int> VitalityPowerUpItems = new() { Common.GetModItem(ModConditions.vitalityMod, "BloodClot") };

            MagnetPlayer mPlayer = Main.LocalPlayer.GetMagnetPlayer();
            if (item.active && Main.LocalPlayer.whoAmI == Main.myPlayer)
            {
                if (Common.PowerUpItems.Contains(item.type) || ThoriumPowerUpItems.Contains(item.type) || VitalityPowerUpItems.Contains(item.type))
                    return;

                if (item.noGrabDelay != 0 || item.playerIndexTheItemIsReservedFor != Main.LocalPlayer.whoAmI)
                    return;

                if (Main.LocalPlayer.Distance(item.Center) <= BaseMagnetRange && mPlayer.BaseMagnet)
                {
                    item.beingGrabbed = true;
                    item.Center = Main.LocalPlayer.Center;

                    if (Main.netMode != NetmodeID.SinglePlayer)
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item.whoAmI);
                }

                if (Main.LocalPlayer.Distance(item.Center) <= HellstoneMagnetRange && mPlayer.HellstoneMagnet)
                {
                    item.beingGrabbed = true;
                    item.Center = Main.LocalPlayer.Center;

                    if (Main.netMode != NetmodeID.SinglePlayer)
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item.whoAmI);
                }

                if (Main.LocalPlayer.Distance(item.Center) <= SoulMagnetMagnetRange && mPlayer.SoulMagnet)
                {
                    item.beingGrabbed = true;
                    item.Center = Main.LocalPlayer.Center;

                    if (Main.netMode != NetmodeID.SinglePlayer)
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item.whoAmI);
                }

                if (Main.LocalPlayer.Distance(item.Center) <= SpectreMagnetRange && mPlayer.SpectreMagnet)
                {
                    item.beingGrabbed = true;
                    item.Center = Main.LocalPlayer.Center;

                    if (Main.netMode != NetmodeID.SinglePlayer)
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item.whoAmI);
                }

                if (Main.LocalPlayer.Distance(item.Center) <= LunarMagnetRange && mPlayer.LunarMagnet)
                {
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
        public bool SoulMagnet = false;
        public bool SpectreMagnet = false;
        public bool LunarMagnet = false;

        public override void Initialize() => Reset();

        public override void ResetEffects() => Reset();

        public override void UpdateDead() => Reset();

        private void Reset()
        {
            BaseMagnet = false;
            HellstoneMagnet = false;
            SoulMagnet = false;
            SpectreMagnet = false;
            LunarMagnet = false;
            PlayerHelper.SetLocalMagnetPlayer(this);
        }
    }
}
