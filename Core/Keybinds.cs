using Terraria.GameInput;
using Terraria.ModLoader.Config;
using Terraria.ID;
using Terraria;

namespace QoLCompendium.Core
{
    public class KeybindPlayer : ModPlayer
    {
        internal int originalSelectedItem;

        internal bool autoRevertSelectedItem;

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

            if (KeybindSystem.AutoRecall.JustPressed)
            {
                AutoUseMirror();
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

        public override void PostUpdate()
        {
            if (autoRevertSelectedItem)
            {
                if (Player.itemTime == 0 && Player.itemAnimation == 0)
                {
                    Player.selectedItem = originalSelectedItem;
                    autoRevertSelectedItem = false;
                }
            }
        }

        public void AutoUseMirror()
        {
            int potionofReturn = -1;
            int recallPotion = -1;
            int magicMirror = -1;

            for (int i = 0; i < Player.inventory.Length; i++)
            {
                switch (Player.inventory[i].type)
                {
                    case ItemID.PotionOfReturn:
                        potionofReturn = i;
                        break;

                    case ItemID.RecallPotion:
                        recallPotion = i;
                        break;

                    case ItemID.MagicMirror:
                    case ItemID.IceMirror:
                    case ItemID.CellPhone:
                    case ItemID.Shellphone:
                        magicMirror = i;
                        break;
                }
            }

            if (potionofReturn != -1)
                QuickUseItemAt(potionofReturn);
            else if (recallPotion != -1)
                QuickUseItemAt(recallPotion);
            else if (magicMirror != -1)
                QuickUseItemAt(magicMirror);
        }

        public void QuickUseItemAt(int index, bool use = true)
        {
            if (!autoRevertSelectedItem && Player.selectedItem != index && Player.inventory[index].type != ItemID.None)
            {
                originalSelectedItem = Player.selectedItem;
                autoRevertSelectedItem = true;
                Player.selectedItem = index;
                Player.controlUseItem = true;
                if (use && CombinedHooks.CanUseItem(Player, Player.inventory[Player.selectedItem]))
                {
                    if (Player.whoAmI == Main.myPlayer)
                        Player.ItemCheck();
                }
            }
        }
    }

    public class KeybindSystem : ModSystem
    {
        public static ModKeybind GoHome { get; private set; }
        public static ModKeybind AutoRecall { get; private set; }
        public static ModKeybind AddTileToWhitelist { get; private set; }
        public static ModKeybind RemoveTileFromWhitelist { get; private set; }

        public override void Load()
        {
            GoHome = KeybindLoader.RegisterKeybind(Mod, "HomeBind", "I");
            AutoRecall = KeybindLoader.RegisterKeybind(Mod, "RecallBind", "K");
            AddTileToWhitelist = KeybindLoader.RegisterKeybind(Mod, "WhitelistTileBind", "O");
            RemoveTileFromWhitelist = KeybindLoader.RegisterKeybind(Mod, "RemoveWhitelistedTileBind", "P");
        }

        public override void Unload()
        {
            GoHome = null;
            AutoRecall = null;
            AddTileToWhitelist = null;
            RemoveTileFromWhitelist = null;
        }
    }
}
