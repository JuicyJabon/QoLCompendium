using QoLCompendium.Content.Items.Tools.Mirrors;
using QoLCompendium.Core.Changes.PlayerChanges;
using QoLCompendium.Core.UI.Panels;
using Terraria.GameInput;
using Terraria.ModLoader.Config;
using Terraria.ObjectData;

namespace QoLCompendium.Core
{
    public class KeybindPlayer : ModPlayer
    {
        public int originalSelectedItem;

        public bool autoRevertSelectedItem;

        public int dashTimeMod;

        public static byte timeout;

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

            if (KeybindSystem.QuickRod.JustPressed)
                AutoUseRod();

            if (KeybindSystem.Dash.JustPressed)
            {
                if (Player.GetModPlayer<DashPlayer>().LeftLastPressed || (Player.direction == -1 && Player.velocity.X == 0))
                {
                    for (int i = 0; i < 60; i++)
                    {
                        if (i < 2 || i > 58)
                            Player.controlLeft = Player.releaseLeft = true;
                    }
                }
                if (Player.GetModPlayer<DashPlayer>().RightLastPressed || (Player.direction == 1 && Player.velocity.X == 0))
                {
                    for (int i = 0; i < 60; i++)
                    {
                        if (i < 2 || i > 58)
                            Player.controlRight = Player.releaseRight = true;
                    }
                }
            }

            if (Main.netMode == NetmodeID.SinglePlayer && timeout > 0)
                timeout--;

            if (KeybindSystem.AddTileToWhitelist.JustPressed)
            {
                Tile target = Main.tile[Player.tileTargetX, Player.tileTargetY];
                ModTile modTile = TileLoader.GetTile(target.TileType);
                int style = TileObjectData.GetTileStyle(target);

                if (target.HasTile)
                {
                    Common.UpdateWhitelist(target.TileType, Common.GetFullNameById(target.TileType, style), style);
                    Main.NewText(Language.GetTextValue("Mods.QoLCompendium.Messages.Whitelisted") + " " + new TileDefinition(target.TileType).Name);
                }
            }

            if (KeybindSystem.RemoveTileFromWhitelist.JustPressed)
            {
                Tile target = Main.tile[Player.tileTargetX, Player.tileTargetY];
                ModTile modTile = TileLoader.GetTile(target.TileType);
                int style = TileObjectData.GetTileStyle(target);

                if (target.HasTile)
                {
                    Common.UpdateWhitelist(target.TileType, Common.GetFullNameById(target.TileType, style), style, remove: true);
                    Main.NewText(Language.GetTextValue("Mods.QoLCompendium.Messages.Removed") + " " + new TileDefinition(target.TileType).Name);
                }
            }

            if (KeybindSystem.PermanentBuffUIToggle.JustPressed)
            {
                PermanentBuffTogglerUI.timeStart = Main.GameUpdateCount;
                PermanentBuffTogglerUI.visible = !PermanentBuffTogglerUI.visible;

                if (PermanentBuffTogglerUI.visible)
                    SoundEngine.PlaySound(SoundID.MenuOpen, Main.LocalPlayer.position, null);
                else
                    SoundEngine.PlaySound(SoundID.MenuClose, Main.LocalPlayer.position, null);
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

        public void AutoUseRod()
        {
            if (Player.HasItem(ItemID.RodOfHarmony))
                QuickUseItemAt(Common.GetSlotItemIsIn(new(ItemID.RodOfHarmony), Player.inventory));
            if (Player.HasItem(ItemID.RodofDiscord))
                QuickUseItemAt(Common.GetSlotItemIsIn(new(ItemID.RodofDiscord), Player.inventory));
        }

        public void AutoUseMirror()
        {
            if (Player.HasItem(ItemID.PotionOfReturn))
                QuickUseItemAt(Common.GetSlotItemIsIn(new(ItemID.PotionOfReturn), Player.inventory));
            else if (Player.HasItem(ItemID.RecallPotion))
                QuickUseItemAt(Common.GetSlotItemIsIn(new(ItemID.RecallPotion), Player.inventory));
            else if (Player.HasItem(ItemID.MagicMirror))
                QuickUseItemAt(Common.GetSlotItemIsIn(new(ItemID.MagicMirror), Player.inventory));
            else if (Player.HasItem(ItemID.IceMirror))
                QuickUseItemAt(Common.GetSlotItemIsIn(new(ItemID.IceMirror), Player.inventory));
            else if (Player.HasItem(ItemID.CellPhone))
                QuickUseItemAt(Common.GetSlotItemIsIn(new(ItemID.CellPhone), Player.inventory));
            else if (Player.HasItem(ItemID.Shellphone))
                QuickUseItemAt(Common.GetSlotItemIsIn(new(ItemID.Shellphone), Player.inventory));
        }

        public void AutoUseMosaicMirror()
        {
            if (Player.HasItem(ModContent.ItemType<MosaicMirror>()))
                QuickUseItemAt(Common.GetSlotItemIsIn(new(ModContent.ItemType<MosaicMirror>()), Player.inventory));
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
        public static ModKeybind PermanentBuffUIToggle { get; private set; }
        public static ModKeybind QuickRod { get; private set; }
        public static ModKeybind Veinmine { get; private set; }

        public override void Load()
        {
            SendNPCsHome = KeybindLoader.RegisterKeybind(Mod, "SendNPCsHomeBind", "I");
            QuickRecall = KeybindLoader.RegisterKeybind(Mod, "RecallBind", "K");
            QuickMosaicMirror = KeybindLoader.RegisterKeybind(Mod, "MosaicMirrorBind", "L");
            Dash = KeybindLoader.RegisterKeybind(Mod, "DashBind", "C");
            AddTileToWhitelist = KeybindLoader.RegisterKeybind(Mod, "WhitelistTileBind", "O");
            RemoveTileFromWhitelist = KeybindLoader.RegisterKeybind(Mod, "RemoveWhitelistedTileBind", "P");
            PermanentBuffUIToggle = KeybindLoader.RegisterKeybind(Mod, "PermanentBuffUIToggleBind", "L");
            QuickRod = KeybindLoader.RegisterKeybind(Mod, "QuickRodBind", "Z");
            Veinmine = KeybindLoader.RegisterKeybind(Mod, "VeinmineBind", "^");

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
            PermanentBuffUIToggle = null;
            QuickRod = null;
            Veinmine = null;
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
