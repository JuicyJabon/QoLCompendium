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
using System.Reflection;
using QoLCompendium.Core.Changes.BuffChanges;

namespace QoLCompendium
{
    public class QoLCompendium : Mod
    {
        #pragma warning disable CA2211
        public static Mod Instance;
        internal static QoLCompendium instance;
        internal static QoLCConfig mainConfig;
        internal static MainClientConfig mainClientConfig;
        internal static ItemConfig itemConfig;
        internal static ShopConfig shopConfig;
        internal static TooltipConfig tooltipConfig;

        internal static int? LastOpenedBank;
#pragma warning restore CA2211

        public override uint ExtraPlayerBuffSlots => (uint)mainConfig.ExtraBuffSlots;

        public override void PostSetupContent()
        {
            BuffSystem.DoBuffIntegration();
            Common.PostSetupTasks();
            LoadModSupport.PostSetupTasks();
        }

        public override void Load()
        {
            On_Player.HandleBeingInChestRange += ChestRange;
            On_WorldGen.moveRoom += WorldGen_moveRoom;
            instance = this;
            Instance = this;
            ModConditions.LoadSupportedMods();
            LoadModSupport.LoadTasks();
        }

        public override void Unload()
        {
            instance = null;
            Instance = null;
            mainConfig = null;
            mainClientConfig = null;
            itemConfig = null;
            shopConfig = null;
            tooltipConfig = null;
            On_Player.HandleBeingInChestRange -= ChestRange;
            On_WorldGen.moveRoom -= WorldGen_moveRoom;
            Common.UnloadTasks();
            LoadModSupport.UnloadTasks();
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

        private void ChestRange(On_Player.orig_HandleBeingInChestRange orig, Player player)
        {
            if (player.chest == LastOpenedBank) return;
            if (LastOpenedBank != null) LastOpenedBank = null;

            orig.Invoke(player);
        }
    }
}
