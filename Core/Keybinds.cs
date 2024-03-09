using Terraria.GameInput;
using Terraria.ModLoader.Config;

namespace QoLCompendium.Core
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

            if (KeybindSystem.AddTileToWhitelist.JustPressed)
            {
                int tileTargetX = Player.tileTargetX;
                int tileTargetY = Player.tileTargetY;
                Tile target = Main.tile[tileTargetX, tileTargetY];

                if (target != null && target.HasTile && !QoLCompendium.mainConfig.VeinMinerWhitelist.Contains(new TileDefinition(target.TileType)))
                {
                    QoLCompendium.mainConfig.VeinMinerWhitelist.Add(new TileDefinition(target.TileType));
                    Main.NewText(Language.GetTextValue("Mods.QoLCompendium.TileStuff.Whitelisted") + " " + new TileDefinition(target.TileType).Name);
                }
            }

            if (KeybindSystem.RemoveTileFromWhitelist.JustPressed)
            {
                int tileTargetX = Player.tileTargetX;
                int tileTargetY = Player.tileTargetY;
                Tile target = Main.tile[tileTargetX, tileTargetY];
                
                if (target != null && target.HasTile && QoLCompendium.mainConfig.VeinMinerWhitelist.Contains(new TileDefinition(target.TileType)))
                {
                    QoLCompendium.mainConfig.VeinMinerWhitelist.Remove(new TileDefinition(target.TileType));
                    Main.NewText(Language.GetTextValue("Mods.QoLCompendium.TileStuff.Removed") + " " + new TileDefinition(target.TileType).Name);
                }
            }
        }
    }

    public class KeybindSystem : ModSystem
    {
        public static ModKeybind GoHome { get; private set; }
        public static ModKeybind AddTileToWhitelist { get; private set; }
        public static ModKeybind RemoveTileFromWhitelist { get; private set; }

        public override void Load()
        {
            GoHome = KeybindLoader.RegisterKeybind(Mod, "HomeBind", "I");
            AddTileToWhitelist = KeybindLoader.RegisterKeybind(Mod, "WhitelistTileBind", "O");
            RemoveTileFromWhitelist = KeybindLoader.RegisterKeybind(Mod, "RemoveWhitelistedTileBind", "P");
        }

        public override void Unload()
        {
            GoHome = null;
            AddTileToWhitelist = null;
            RemoveTileFromWhitelist = null;
        }
    }
}
