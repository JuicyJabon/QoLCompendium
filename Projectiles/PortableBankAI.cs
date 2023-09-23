using Microsoft.Xna.Framework;
using QoLCompendium.Tiles;
using QoLCompendium.Tweaks;
using Terraria;
using Terraria.Audio;
using Terraria.GameInput;
using Terraria.ID;

namespace QoLCompendium.Projectiles
{
    public class PortableBankAI
    {
        internal static void BankAI(Projectile proj, int itemType, int chestType, ref int playerBank, Player p, QoLCPlayer qoLCplayer)
        {
            if ((Main.gamePaused && !Main.gameMenu) || Main.SmartCursorIsUsed)
            {
                return;
            }
            Vector2 vector = proj.position - Main.screenPosition;
            int num = (int)(p.Center.X / 16.0);
            int num2 = (int)(p.Center.Y / 16.0);
            int num3 = (int)proj.Center.X / 16;
            int num4 = (int)proj.Center.Y / 16;
            int lastTileRangeX = p.lastTileRangeX;
            int lastTileRangeY = p.lastTileRangeY;
            if (num < num3 - lastTileRangeX || num > num3 + lastTileRangeX + 1 || num2 < num4 - lastTileRangeY || num2 > num4 + lastTileRangeY + 1)
            {
                if (playerBank == proj.whoAmI)
                {
                    playerBank = -1;
                    qoLCplayer.chests = false;
                    return;
                }
            }
            else
            {
                if (Main.mouseX <= vector.X || Main.mouseX >= vector.X + proj.width || Main.mouseY <= vector.Y || Main.mouseY >= vector.Y + proj.height)
                {
                    return;
                }
                p.noThrow = 2;
                p.cursorItemIconEnabled = true;
                p.cursorItemIconID = itemType;
                if (PlayerInput.UsingGamepad)
                {
                    p.GamepadEnableGrappleCooldown();
                }
                if (!Main.mouseRight || !Main.mouseRightRelease || Player.BlockInteractionWithProjectiles != 0)
                {
                    return;
                }
                Main.mouseRightRelease = false;
                if (p.chest == chestType)
                {
                    SoundEngine.PlaySound(SoundID.MenuClose, Main.LocalPlayer.position, null);
                    p.chest = -1;
                    Recipe.FindRecipes(false);
                    return;
                }
                bool flag = false;
                num = ((p.SpawnX == -1) ? Main.spawnTileX : p.SpawnX);
                num2 = ((p.SpawnY == -1) ? Main.spawnTileY : p.SpawnY);
                int num5 = (int)proj.Center.X / 16;
                int num6 = (int)proj.Center.Y / 16;
                if (!TileChecks.SolidTile(num5, num6))
                {
                    for (int i = 0; i < 5000; i++)
                    {
                        for (int j = 0; j < 2000; j++)
                        {
                            if (num - i > 40 && num2 + j < Main.maxTilesY - 40 && TileChecks.SolidTile(num - i, num2 + j))
                            {
                                num5 = num - i;
                                num6 = num2 + j;
                                flag = true;
                                break;
                            }
                            if (num + i < Main.maxTilesX - 40 && num2 + j < Main.maxTilesY - 40 && TileChecks.SolidTile(num + i, num2 + j))
                            {
                                num5 = num + i;
                                num6 = num2 + j;
                                flag = true;
                                break;
                            }
                            if (num + i < Main.maxTilesX - 40 && num2 - j > 40 && TileChecks.SolidTile(num + i, num2 - j))
                            {
                                num5 = num + i;
                                num6 = num2 - j;
                                flag = true;
                                break;
                            }
                            if (num - i > 40 && num2 - j > 40 && TileChecks.SolidTile(num - i, num2 - j))
                            {
                                num5 = num - i;
                                num6 = num2 - j;
                                flag = true;
                                break;
                            }
                        }
                        if (flag)
                        {
                            break;
                        }
                    }
                }
                playerBank = proj.whoAmI;
                qoLCplayer.chests = true;
                p.chest = chestType;
                p.chestX = num5;
                p.chestY = num6;
                p.SetTalkNPC(playerBank, false);
                Main.oldNPCShop = 0;
                Main.playerInventory = true;
                SoundEngine.PlaySound(SoundID.MenuOpen, Main.LocalPlayer.position, null);
                Recipe.FindRecipes(false);
            }
        }
    }
}
