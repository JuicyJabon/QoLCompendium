using Terraria.DataStructures;

namespace QoLCompendium.Content.Projectiles.Other
{
    public class BuildIndicatorProjectile : ModProjectile
    {
        private Vector2 oldMouse;

        private Item item;

        private bool previouslyLookingLeft;

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 10;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(0, 0, 0, 100);
        }

        public override void OnSpawn(IEntitySource source)
        {
            oldMouse = Main.MouseWorld;
            if (source is EntitySource_ItemUse itemuseSource)
            {
                item = itemuseSource.Item;
                previouslyLookingLeft = itemuseSource.Player.direction < 0;
            }
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            Vector2 mouse = Main.MouseWorld;
            Vector2 delta = mouse - oldMouse;
            Projectile projectile = Projectile;
            projectile.position += delta;
            oldMouse = mouse;
            if (previouslyLookingLeft && player.direction == 1)
            {
                Projectile.position.X += Projectile.position.X + oldMouse.X;
                previouslyLookingLeft = false;
            }
            else if (!previouslyLookingLeft && player.direction == -1)
            {
                Projectile.position.X += Projectile.position.X + oldMouse.X;
                previouslyLookingLeft = true;
            }
            Projectile projectile2 = Projectile;
            projectile2.timeLeft++;
            if (player.HeldItem.type != item.type)
            {
                Projectile.Kill();
            }
            Projectile.hide = Projectile.owner != Main.myPlayer;
        }
    }
}
