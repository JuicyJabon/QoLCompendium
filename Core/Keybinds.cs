using QoLCompendium.Core.Changes;
using Terraria.Chat;
using Terraria.GameInput;
using Terraria.ModLoader.Config;

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
                    QoLCompendium.TownEntitiesTeleportToHome(npc, npc.homeTileX, npc.homeTileY);
                ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Mods.QoLCompendium.Messages.TeleportNPCsHome"), Color.White);
            }

            if (KeybindSystem.AutoRecall.JustPressed)
                AutoUseMirror();

            if (KeybindSystem.AddTileToWhitelist.JustPressed)
            {
                if (QoLCompendium.mainServerConfig.VeinMinerWhitelist == null)
                    Main.NewText(Language.GetTextValue("Mods.QoLCompendium.TileStuff.Failed"));

                int tileTargetX = Player.tileTargetX;
                int tileTargetY = Player.tileTargetY;
                Tile target = Main.tile[tileTargetX, tileTargetY];
                if (target != null && target.HasTile && !QoLCompendium.mainServerConfig.VeinMinerWhitelist.Contains(new TileDefinition(target.TileType)))
                {
                    QoLCompendium.mainServerConfig.VeinMinerWhitelist.Add(new TileDefinition(target.TileType));
                    Main.NewText(Language.GetTextValue("Mods.QoLCompendium.TileStuff.Whitelisted") + " " + new TileDefinition(target.TileType).Name);
                }
            }

            if (KeybindSystem.RemoveTileFromWhitelist.JustPressed)
            {
                if (QoLCompendium.mainServerConfig.VeinMinerWhitelist == null)
                    Main.NewText(Language.GetTextValue("Mods.QoLCompendium.TileStuff.Failed"));

                int tileTargetX = Player.tileTargetX;
                int tileTargetY = Player.tileTargetY;
                Tile target = Main.tile[tileTargetX, tileTargetY];
                if (target != null && target.HasTile && QoLCompendium.mainServerConfig.VeinMinerWhitelist.Contains(new TileDefinition(target.TileType)))
                {
                    QoLCompendium.mainServerConfig.VeinMinerWhitelist.Remove(new TileDefinition(target.TileType));
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
        public static ModKeybind Dash { get; private set; }
        public static ModKeybind AddTileToWhitelist { get; private set; }
        public static ModKeybind RemoveTileFromWhitelist { get; private set; }

        public override void Load()
        {
            GoHome = KeybindLoader.RegisterKeybind(Mod, "HomeBind", "I");
            AutoRecall = KeybindLoader.RegisterKeybind(Mod, "RecallBind", "K");
            Dash = KeybindLoader.RegisterKeybind(Mod, "DashBind", "C");
            AddTileToWhitelist = KeybindLoader.RegisterKeybind(Mod, "WhitelistTileBind", "O");
            RemoveTileFromWhitelist = KeybindLoader.RegisterKeybind(Mod, "RemoveWhitelistedTileBind", "P");
            On_Player.DoCommonDashHandle += OnVanillaDash;
        }

        public override void Unload()
        {
            GoHome = null;
            AutoRecall = null;
            Dash = null;
            AddTileToWhitelist = null;
            RemoveTileFromWhitelist = null;
            On_Player.DoCommonDashHandle -= OnVanillaDash;
        }

        private static void OnVanillaDash(On_Player.orig_DoCommonDashHandle orig, Player player, out int dir, out bool dashing, Player.DashStartAction dashStartAction)
        {
            if (QoLCompendium.mainClientConfig.DisableDashing)
                player.dashTime = 0;
            orig.Invoke(player, out dir, out dashing, dashStartAction);
            if (player.whoAmI == Main.myPlayer && Dash.JustPressed && !player.CCed)
            {
                DashPlayer modPlayer = player.GetModPlayer<DashPlayer>();
                if (player.controlRight && player.controlLeft)
                    dir = modPlayer.latestXDirPressed;
                else if (player.controlRight)
                    dir = 1;
                else if (player.controlLeft)
                    dir = -1;
                if (dir == 0)
                    return;
                player.direction = dir;
                dashing = true;
                if (player.dashTime > 0)
                    player.dashTime--;
                if (player.dashTime < 0)
                    player.dashTime++;
                if ((player.dashTime <= 0 && player.direction == -1) || (player.dashTime >= 0 && player.direction == 1))
                {
                    player.dashTime = 15;
                    return;
                }
                dashing = true;
                player.dashTime = 0;
                player.timeSinceLastDashStarted = 0;
                if (dashStartAction != null)
                    dashStartAction?.Invoke(dir);
            }
        }
    }
}
