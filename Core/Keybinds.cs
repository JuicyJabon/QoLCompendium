using QoLCompendium.Content.Items.Mirrors;
using QoLCompendium.Core.Changes;
using Terraria.GameInput;
using Terraria.ModLoader.Config;

namespace QoLCompendium.Core
{
    public class KeybindPlayer : ModPlayer
    {
        public int originalSelectedItem;

        public bool autoRevertSelectedItem;

        public int dashTimeMod;

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (KeybindSystem.SendNPCsHome.JustPressed)
            {
                foreach (var npc in from n in Main.npc where n is not null && n.active && n.townNPC && !n.homeless select n)
                {
                    QoLCompendium.TownEntitiesTeleportToHome(npc, npc.homeTileX, npc.homeTileY);
                }
                Main.NewText(Language.GetTextValue("Mods.QoLCompendium.Messages.TeleportNPCsHome"));
            }

            if (KeybindSystem.QuickRecall.JustPressed)
                AutoUseMirror();

            if (KeybindSystem.QuickMosaicMirror.JustPressed)
                AutoUseMosaicMirror();

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

            if (KeybindSystem.Dash.JustPressed)
            {
                int directionPressed = Player.GetModPlayer<DashPlayer>().latestXDirPressed;
                int directionReleased = Player.GetModPlayer<DashPlayer>().latestXDirReleased;
                //directionPressed == -1 || directionReleased == -1 || 
                //directionPressed == 1 || directionReleased == 1 || 
                if (Player.GetModPlayer<DashPlayer>().LeftLastPressed || (Player.direction == -1 && Player.velocity.X == 0))
                {
                    Player.doubleTapCardinalTimer[3] = 15;
                    Player.KeyDoubleTap(3);
                    bool flag = false;
                    Player.dashTime = -15;
                    Player.controlLeft = true;
                    Player.releaseLeft = true;
                    for (int i = 0; i < 10; i++)
                    {
                        if (flag)
                            break;
                        if (i >= 9)
                            flag = true;
                    }
                    if (flag)
                    {
                        Player.controlLeft = true;
                        Player.releaseLeft = true;
                    }
                }
                if (Player.GetModPlayer<DashPlayer>().RightLastPressed || (Player.direction == 1 && Player.velocity.X == 0))
                {
                    Player.doubleTapCardinalTimer[2] = 15;
                    Player.KeyDoubleTap(2);
                    bool flag = false;
                    Player.dashTime = 15;
                    Player.controlRight = true;
                    Player.releaseRight = true;
                    for (int i = 0; i < 10; i++)
                    {
                        if (flag)
                            break;
                        if (i >= 9)
                            flag = true;
                    }
                    if (flag)
                    {
                        Player.controlRight = true;
                        Player.releaseRight = true;
                    }
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

        public void AutoUseMosaicMirror()
        {
            int mosaicMirror = -1;

            for (int i = 0; i < Player.inventory.Length; i++)
            {
                if (Player.inventory[i].type == ModContent.ItemType<MosaicMirror>())
                {
                    mosaicMirror = i;
                    break;
                }
            }

            if (mosaicMirror != -1)
                QuickUseItemAt(mosaicMirror);
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
        public static ModKeybind SendNPCsHome { get; private set; }
        public static ModKeybind QuickRecall { get; private set; }
        public static ModKeybind QuickMosaicMirror { get; private set; }
        public static ModKeybind Dash { get; private set; }
        public static ModKeybind AddTileToWhitelist { get; private set; }
        public static ModKeybind RemoveTileFromWhitelist { get; private set; }

        public override void Load()
        {
            SendNPCsHome = KeybindLoader.RegisterKeybind(Mod, "SendNPCsHomeBind", "I");
            QuickRecall = KeybindLoader.RegisterKeybind(Mod, "RecallBind", "K");
            QuickMosaicMirror = KeybindLoader.RegisterKeybind(Mod, "MosaicMirrorBind", "L");
            Dash = KeybindLoader.RegisterKeybind(Mod, "DashBind", "C");
            AddTileToWhitelist = KeybindLoader.RegisterKeybind(Mod, "WhitelistTileBind", "O");
            RemoveTileFromWhitelist = KeybindLoader.RegisterKeybind(Mod, "RemoveWhitelistedTileBind", "P");

            On_Player.DoCommonDashHandle += OnVanillaDash;
        }

        public override void Unload()
        {
            SendNPCsHome = null;
            QuickRecall = null;
            QuickMosaicMirror = null;
            Dash = null;
            AddTileToWhitelist = null;
            RemoveTileFromWhitelist = null;
            On_Player.DoCommonDashHandle -= OnVanillaDash;
        }

        public static void OnVanillaDash(On_Player.orig_DoCommonDashHandle orig, Player player, out int dir, out bool dashing, Player.DashStartAction dashStartAction)
        {
            if (QoLCompendium.mainClientConfig.DisableDashDoubleTap)
                player.dashTime = 0;

            orig.Invoke(player, out dir, out dashing, dashStartAction);
            if (player.whoAmI == Main.myPlayer && Dash.JustPressed && !player.CCed)
            {
                DashPlayer modPlayer = player.GetModPlayer<DashPlayer>();
                if (player.controlRight && player.controlLeft)
                {
                    dir = modPlayer.latestXDirPressed;
                }
                else if (player.controlRight)
                {
                    dir = 1;
                }
                else if (player.controlLeft)
                {
                    dir = -1;
                }
                if (dir == 0)
                    return;
                player.direction = dir;
                dashing = true;
                if (player.dashTime > 0)
                {
                    player.dashTime--;
                }
                if (player.dashTime < 0)
                {
                    player.dashTime++;
                }
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
