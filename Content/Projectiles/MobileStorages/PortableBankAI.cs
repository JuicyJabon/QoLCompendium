using QoLCompendium.Core;
using QoLCompendium.Core.Changes;
using Terraria.GameInput;

namespace QoLCompendium.Content.Projectiles.MobileStorages
{
    public class PortableBankAI
    {
        public static void BankAI(Projectile projectile, int itemType, int chestType, ref int playerBank, Player player, BankPlayer bankPlayer)
        {
            if (Main.gamePaused && !Main.gameMenu || Main.SmartCursorIsUsed)
                return;

            Vector2 projectileWorldPosition = projectile.position - Main.screenPosition;
            Vector2 playerWorldPosition = player.Center;
            int playerCenterX = (int)(player.Center.X / 16.0);
            int playerCenterY = (int)(player.Center.Y / 16.0);
            int projectileCenterX = (int)projectile.Center.X / 16;
            int projectileCenterY = (int)projectile.Center.Y / 16;
            int lastTileRangeX = player.lastTileRangeX;
            int lastTileRangeY = player.lastTileRangeY;

            if ((playerCenterX < projectileCenterX - lastTileRangeX || playerCenterX > projectileCenterX + lastTileRangeX + 1 || playerCenterY < projectileCenterY - lastTileRangeY || playerCenterY > projectileCenterY + lastTileRangeY + 1) && playerBank == projectile.whoAmI)
            {
                playerBank = -1;
                bankPlayer.chests = false;
                return;
            }
            else
            {
                if (Main.mouseX <= projectileWorldPosition.X || Main.mouseX >= projectileWorldPosition.X + projectile.width || Main.mouseY <= projectileWorldPosition.Y || Main.mouseY >= projectileWorldPosition.Y + projectile.height)
                    return;

                player.noThrow = 2;
                player.cursorItemIconEnabled = true;
                player.cursorItemIconID = itemType;

                if (PlayerInput.UsingGamepad)
                    player.GamepadEnableGrappleCooldown();

                if (!Main.mouseRight || !Main.mouseRightRelease || Player.BlockInteractionWithProjectiles != 0)
                    return;

                Main.mouseRightRelease = false;
                if (player.chest == chestType)
                {
                    SoundEngine.PlaySound(SoundID.MenuClose, Main.LocalPlayer.position, null);
                    player.chest = -1;
                    Recipe.FindRecipes(false);
                    return;
                }

                bool flag = false;
                playerCenterX = player.SpawnX == -1 ? Main.spawnTileX : player.SpawnX;
                playerCenterY = player.SpawnY == -1 ? Main.spawnTileY : player.SpawnY;
                if (!Common.SolidTile(projectileCenterX, projectileCenterY))
                {
                    for (int i = 0; i < 5000; i++)
                    {
                        for (int j = 0; j < 2000; j++)
                        {
                            if (playerCenterX - i > 40 && playerCenterY + j < Main.maxTilesY - 40 && Common.SolidTile(playerCenterX - i, playerCenterY + j))
                            {
                                projectileCenterX = playerCenterX - i;
                                projectileCenterY = playerCenterY + j;
                                flag = true;
                                break;
                            }
                            if (playerCenterX + i < Main.maxTilesX - 40 && playerCenterY + j < Main.maxTilesY - 40 && Common.SolidTile(playerCenterX + i, playerCenterY + j))
                            {
                                projectileCenterX = playerCenterX + i;
                                projectileCenterY = playerCenterY + j;
                                flag = true;
                                break;
                            }
                            if (playerCenterX + i < Main.maxTilesX - 40 && playerCenterY - j > 40 && Common.SolidTile(playerCenterX + i, playerCenterY - j))
                            {
                                projectileCenterX = playerCenterX + i;
                                projectileCenterY = playerCenterY - j;
                                flag = true;
                                break;
                            }
                            if (playerCenterX - i > 40 && playerCenterY - j > 40 && Common.SolidTile(playerCenterX - i, playerCenterY - j))
                            {
                                projectileCenterX = playerCenterX - i;
                                projectileCenterY = playerCenterY - j;
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
                playerBank = projectile.whoAmI;
                bankPlayer.chests = true;
                player.chest = chestType;
                player.chestX = projectileCenterX;
                player.chestY = projectileCenterY;
                player.SetTalkNPC(playerBank, false);
                Main.oldNPCShop = 0;
                Main.playerInventory = true;
                SoundEngine.PlaySound(SoundID.MenuOpen, Main.LocalPlayer.position, null);
                Recipe.FindRecipes(false);
            }
        }
    }
}