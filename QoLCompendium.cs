global using static QoLCompendium.QoLCConfig;
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
using QoLCompendium.Items.FavoriteEffectItems;
using QoLCompendium.Tweaks;
using QoLCompendium.UI;
using System.Reflection;

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
        internal BossUI bossUI;
        private UserInterface bossInterface;


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

                bossUI = new BossUI();
                bossUI.Activate();
                bossInterface = new UserInterface();
                bossInterface.SetState(bossUI);
            }
        }

        public override void Unload()
        {
            instance = null;
            Instance = null;
            mainConfig = null;
            itemConfig = null;
            shopConfig = null;
            BannerBox.itemToBanner.Clear();
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

        public override void PostSetupContent()
        {
            BannerBox.itemToBanner.Clear();
            FieldInfo bannerToItemField = typeof(NPCLoader).GetField("bannerToItem", BindingFlags.NonPublic | BindingFlags.Static);
            Dictionary<int, int> bannerToItem = (Dictionary<int, int>)bannerToItemField.GetValue(null);
            foreach (var item in bannerToItem)
            {
                if (!BannerBox.itemToBanner.ContainsKey(item.Value))
                {
                    BannerBox.itemToBanner.Add(item.Value, item.Key);
                }
            }

            for (int i = -10; i < NPCID.Count; i++)
            {
                int vanillaBannerID = Item.NPCtoBanner(i);
                if (vanillaBannerID > 0 && !NPCID.Sets.PositiveNPCTypesExcludedFromDeathTally[NPCID.FromNetId(i)])
                {
                    int vanillaBannerItemID = Item.BannerToItem(vanillaBannerID);
                    if (ItemID.Sets.BannerStrength[vanillaBannerItemID].Enabled)
                    {
                        if (!BannerBox.itemToBanner.ContainsKey(vanillaBannerItemID))
                        {
                            BannerBox.itemToBanner.Add(vanillaBannerItemID, vanillaBannerID);
                        }
                    }
                }
            }
        }
    }
}
