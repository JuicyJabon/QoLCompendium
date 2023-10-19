global using static QoLCompendium.QoLCConfig;
using QoLCompendium.Tweaks;
using QoLCompendium.UI;
using System.IO;
using System.Linq;
using System.Reflection;
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
        internal WorldGlobeUI worldGlobeUI;
        private UserInterface worldGlobeInterface;
        internal EntityManipulatorUI entityManipulatorUI;
        private UserInterface entityManipulatorInterface;
        internal MoonChangeUI moonChangeUI;
        private UserInterface moonInterface;


        #pragma warning disable CA2211
        public static Mod Instance;
        internal static QoLCompendium instance;
        internal static QoLCConfig mainConfig;
        internal static ItemConfig itemConfig;
        internal static ShopConfig shopConfig;
        #pragma warning restore CA2211

        public override uint ExtraPlayerBuffSlots => mainConfig.ExtraBuffSlots;

        public override void Load()
        {
            if (mainConfig.GoHomeNPCs)
            {
                On_WorldGen.moveRoom += WorldGen_moveRoom;
            }

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

                worldGlobeUI = new WorldGlobeUI();
                worldGlobeUI.Activate();
                worldGlobeInterface = new UserInterface();
                worldGlobeInterface.SetState(worldGlobeUI);

                entityManipulatorUI = new EntityManipulatorUI();
                entityManipulatorUI.Activate();
                entityManipulatorInterface = new UserInterface();
                entityManipulatorInterface.SetState(entityManipulatorUI);

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

            foreach (var npc in from n in Main.npc where n is not null && n.active && n.townNPC && !n.homeless select n)
            {
                TownEntitiesTeleportToHome(npc, npc.homeTileX, npc.homeTileY);
            }
        }

        public enum QoLCMessageType : byte
        {
            TeleportPlayer
        }

        private void WorldGen_moveRoom(On_WorldGen.orig_moveRoom orig, int x, int y, int n)
        {
            orig.Invoke(x, y, n);
            if (Main.npc.IndexInRange(n) && Main.npc[n] is not null)
                TownEntitiesTeleportToHome(Main.npc[n], Main.npc[n].homeTileX, Main.npc[n].homeTileY);
        }

        internal static void TownEntitiesTeleportToHome(NPC npc, int homeFloorX, int homeFloorY)
        {
            npc?.GetType().GetMethod("AI_007_TownEntities_TeleportToHome",
                BindingFlags.Instance | BindingFlags.NonPublic,
                new[] { typeof(int), typeof(int) })?
                .Invoke(npc, new object[] { homeFloorX, homeFloorY });
        }
    }
}
