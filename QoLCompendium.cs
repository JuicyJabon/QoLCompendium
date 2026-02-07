global using Microsoft.Xna.Framework;
global using Microsoft.Xna.Framework.Graphics;
global using QoLCompendium.Core;
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
using QoLCompendium.Core.Changes.BuffChanges;
using QoLCompendium.Core.Changes.ItemChanges.ReforgeSystems;
using QoLCompendium.Core.Changes.NPCChanges;
using QoLCompendium.Core.Configs;
using QoLCompendium.Core.PermanentBuffSystems;

namespace QoLCompendium
{
    public class QoLCompendium : Mod
    {
        #pragma warning disable CA2211
        public static Mod Instance;
        public static QoLCompendium instance;
        public static MainConfig mainConfig;
        public static MainClientConfig mainClientConfig;
        public static ItemConfig itemConfig;
        public static ShopConfig shopConfig;
        public static TooltipConfig tooltipConfig;
        public static CrossModConfig crossModConfig;
        public static VeinminerConfig veinminerConfig;
#pragma warning restore CA2211

        public override uint ExtraPlayerBuffSlots => (uint)mainConfig.ExtraBuffSlots;

        public override void PostSetupContent()
        {
            BuffSystem.DoBuffIntegration();
            Common.PostSetupTasks();
            Prefixes.PostSetupTasks();
        }

        public override void Load()
        {
            instance = this;
            Instance = this;

            //Permanent Buffs
            if (!itemConfig.DisableModdedItems || itemConfig.PermanentBuffs)
                PermanentBuffLoader.LoadTasks();
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
            crossModConfig = null;
            veinminerConfig = null;
            Common.UnloadTasks();
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            foreach (var npc in from n in Main.npc where n is not null && n.active && n.townNPC && !n.homeless select n)
                TeleportNPCsHome.TownEntitiesTeleportToHome(npc, npc.homeTileX, npc.homeTileY);
        }
    }
}
