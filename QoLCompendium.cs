global using static QoLCompendium.Core.QoLCConfig;
global using Microsoft.Xna.Framework;
global using Microsoft.Xna.Framework.Graphics;
global using ReLogic.Content;
global using System;
global using System.Collections.Generic;
global using System.IO;
global using System.Linq;
global using Terraria;
global using Terraria.Audio;
global using Terraria.GameContent;
global using Terraria.GameContent.UI.Elements;
global using Terraria.ID;
global using Terraria.Localization;
global using Terraria.ModLoader;
global using Terraria.UI;
using QoLCompendium.Core;
using QoLCompendium.Core.UI;
using System.Reflection;

namespace QoLCompendium
{
    public class QoLCompendium : Mod
    {
        internal BMNPCUI bmShopUI;
        private UserInterface bmInterface;
        internal ECNPCUI ecShopUI;
        private UserInterface ecInterface;
        internal DestinationGlobeUI destinationGlobeUI;
        private UserInterface destinationGlobeInterface;
        internal EntityManipulatorUI entityManipulatorUI;
        private UserInterface entityManipulatorInterface;
        internal MoonChangeUI moonChangeUI;
        private UserInterface moonInterface;
        internal BossUI bossUI;
        private UserInterface bossInterface;


        #pragma warning disable CA2211
        public static Mod Instance;
        internal static QoLCompendium instance;
        internal static QoLCConfig mainServerConfig;
        internal static MainClientConfig mainClientConfig;
        internal static ItemConfig itemConfig;
        internal static ShopConfig shopConfig;
        internal static TooltipConfig tooltipConfig;
        #pragma warning restore CA2211

        public override uint ExtraPlayerBuffSlots => mainServerConfig.ExtraBuffSlots;

        public override void Load()
        {
            instance = this;
            Instance = this;
            On_WorldGen.moveRoom += WorldGen_moveRoom;

            #region UI
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

                destinationGlobeUI = new DestinationGlobeUI();
                destinationGlobeUI.Activate();
                destinationGlobeInterface = new UserInterface();
                destinationGlobeInterface.SetState(destinationGlobeUI);

                entityManipulatorUI = new EntityManipulatorUI();
                entityManipulatorUI.Activate();
                entityManipulatorInterface = new UserInterface();
                entityManipulatorInterface.SetState(entityManipulatorUI);

                moonChangeUI = new MoonChangeUI();
                moonChangeUI.Activate();
                moonInterface = new UserInterface();
                moonInterface.SetState(moonChangeUI);

                bossUI = new BossUI();
                bossUI.Activate();
                bossInterface = new UserInterface();
                bossInterface.SetState(bossUI);
            }
            #endregion
        }

        public override void Unload()
        {
            instance = null;
            Instance = null;
            mainServerConfig = null;
            mainClientConfig = null;
            itemConfig = null;
            shopConfig = null;
            tooltipConfig = null;
            On_WorldGen.moveRoom -= WorldGen_moveRoom;
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            foreach (var npc in from n in Main.npc where n is not null && n.active && n.townNPC && !n.homeless select n)
                TownEntitiesTeleportToHome(npc, npc.homeTileX, npc.homeTileY);
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
