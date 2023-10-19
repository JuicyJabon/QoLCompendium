using System.Linq;
using Terraria;
using Terraria.GameInput;
using Terraria.Localization;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    public class KeybindPlayer : ModPlayer
    {
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (KeybindSystem.GoHome.JustPressed)
            {
                foreach (var npc in from n in Main.npc where n is not null && n.active && n.townNPC && !n.homeless select n)
                {
                    if (QoLCompendium.mainConfig.GoHomeNPCs)
                    {
                        QoLCompendium.TownEntitiesTeleportToHome(npc, npc.homeTileX, npc.homeTileY);
                    }
                }
                if (QoLCompendium.mainConfig.GoHomeNPCs)
                {
                    Main.NewText(Language.GetTextValue("Mods.QoLCompendium.NPCStuff.GoHome"));
                }
            }
        }
    }

    public class KeybindSystem : ModSystem
    {
        public static ModKeybind GoHome { get; private set; }

        public override void Load()
        {
            GoHome = KeybindLoader.RegisterKeybind(Mod, "HomeBind", "I");
        }

        public override void Unload()
        {
            GoHome = null;
        }
    }
}
