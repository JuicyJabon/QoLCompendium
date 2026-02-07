using QoLCompendium.Core.UI.Panels;
using Terraria.GameInput;

namespace QoLCompendium.Content.Projectiles.MobileStorages
{
    public class PortableBankAI
    {
        public static void BankAI(Projectile projectile, int itemType, int chestType, Player player)
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

            if (playerCenterX < projectileCenterX - lastTileRangeX || playerCenterX > projectileCenterX + lastTileRangeX + 1 || playerCenterY < projectileCenterY - lastTileRangeY || playerCenterY > projectileCenterY + lastTileRangeY + 1)
            {
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

                AllInOneAccessUI.StorageClick(chestType, SoundID.MenuOpen);
            }
        }
    }

    public class MobileStorageFollowing : GlobalProjectile
    {
        public override bool InstancePerEntity => true;

        public override bool AppliesToEntity(Projectile entity, bool lateInstantiation)
        {
            return entity.type == ProjectileID.FlyingPiggyBank || entity.type == ProjectileID.VoidLens || entity.type == ModContent.ProjectileType<EtherianConstructProjectile>() || entity.type == ModContent.ProjectileType<FlyingSafeProjectile>();
        }

        public override bool PreAI(Projectile projectile)
        {
            if (QoLCompendium.mainConfig.MobileStoragesFollowThePlayer)
            {
                Player player = Main.player[projectile.owner];
                float distance = Vector2.Distance(projectile.Center, player.Center);
                if (distance > 3000f)
                {
                    projectile.Center = player.Top;
                }
                else if (projectile.Center != player.Center)
                {
                    Vector2 val2 = (player.Center + projectile.DirectionFrom(player.Center) * 3f * 16f - projectile.Center) / ((distance < 48f) ? 30f : 60f);
                    projectile.position = projectile.position + val2;
                }
                if (projectile.timeLeft < 2 && projectile.timeLeft > 0)
                {
                    projectile.timeLeft = 2;
                }
            }
            return base.PreAI(projectile);
        }
    }
}