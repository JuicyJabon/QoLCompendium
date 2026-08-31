using Terraria.DataStructures;

namespace QoLCompendium.Content.Projectiles.Other
{
    public class BuildIndicatorProjectile : ModProjectile
    {
        public Vector2 oldMouse;

        public Item item;

        public bool previouslyLookingLeft;

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
            if (source is EntitySource_ItemUse itemUseSource)
            {
                item = itemUseSource.Item;
                previouslyLookingLeft = itemUseSource.Player.direction < 0;
            }
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            Projectile.hide = Projectile.owner != Main.myPlayer;

            Projectile.Center += Main.MouseWorld - oldMouse;
            oldMouse = Main.MouseWorld;

            if (Projectile.ai[0] == 1f)
            {
                if (previouslyLookingLeft && player.direction == 1) //right
                {
                    Projectile.Center = new Vector2(Math.Abs(Projectile.Center.X - oldMouse.X), Projectile.Center.Y - oldMouse.Y);
                    previouslyLookingLeft = false;
                }
                else if (!previouslyLookingLeft && player.direction == -1) //left
                {
                    Projectile.Center = new Vector2(-Math.Abs(Projectile.Center.X - oldMouse.X), Projectile.Center.Y - oldMouse.Y);
                    previouslyLookingLeft = true;
                }
            }

            Projectile.timeLeft++;
            if (player.HeldItem == null || player.HeldItem.type != item.type)
            {
                Projectile.Kill();
            }
        }
    }
}
