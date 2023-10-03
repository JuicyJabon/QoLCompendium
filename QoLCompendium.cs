global using static QoLCompendium.QoLCConfig;
using QoLCompendium.Tweaks;
using QoLCompendium.UI;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace QoLCompendium
{
    public class QoLCompendium : Mod
    {
        internal BMNPCUI bmShopUI;
        private UserInterface bmInterface;
        internal ECNPCUI ecShopUI;
        private UserInterface ecInterface;
        internal GlobeUI globeUI;
        private UserInterface globeInterface;
        internal EMUI emUI;
        private UserInterface emInterface;
        internal MoonChangeUI moonChangeUI;
        private UserInterface moonInterface;

        public static Mod Instance;
        internal static QoLCompendium instance;
        internal static QoLCConfig mainConfig;
        internal static ItemConfig itemConfig;
        internal static ShopConfig shopConfig;

        public override uint ExtraPlayerBuffSlots => mainConfig.ExtraBuffSlots;

        public override void Load()
        {
            instance = this;
            Instance = this;

            if (!Main.dedServ)
            {
                bmShopUI = new BMNPCUI();
                bmShopUI.Activate();
                bmInterface = new UserInterface();
                bmInterface.SetState(bmShopUI);

                ecShopUI = new ECNPCUI();
                ecShopUI.Activate();
                ecInterface = new UserInterface();
                ecInterface.SetState(ecShopUI);

                globeUI = new GlobeUI();
                globeUI.Activate();
                globeInterface = new UserInterface();
                globeInterface.SetState(globeUI);

                emUI = new EMUI();
                emUI.Activate();
                emInterface = new UserInterface();
                emInterface.SetState(emUI);

                moonChangeUI = new MoonChangeUI();
                moonChangeUI.Activate();
                moonInterface = new UserInterface();
                moonInterface.SetState(moonChangeUI);
            }
        }

        public override void Unload()
        {
            instance = null;
            Instance = null;
            mainConfig = null;
            itemConfig = null;
            shopConfig = null;
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            QoLCMessageType msgType = (QoLCMessageType)reader.ReadByte();
            switch (msgType)
            {
                case QoLCMessageType.TeleportPlayer:
                    TeleportClass.HandleTeleport(reader.ReadInt32(), true, whoAmI);
                    break;
                default:
                    Logger.Error("QoLCompendium: Unknown Message type: " + msgType);
                    break;
            }
        }

        public enum QoLCMessageType : byte
        {
            TeleportPlayer
        }
    }
}
