using QoLCompendium.Content.Items.Tools.Fishing;

namespace QoLCompendium.Content.Projectiles.Fishing
{
    public class LegendaryBobber : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.aiStyle = ProjAIStyleID.Bobber;
            Projectile.bobber = true;
            Projectile.penetrate = -1;
            DrawOriginOffsetY = -8;
        }

        public override bool PreDrawExtras()
        {
            int num = 45;
            float num2 = 29f;
            Player val = Main.player[Projectile.owner];
            if (!Projectile.bobber || val.inventory[val.selectedItem].holdStyle <= 0)
            {
                return false;
            }
            Vector2 mountedCenter = val.MountedCenter;
            mountedCenter.Y += val.gfxOffY;
            int type = val.inventory[val.selectedItem].type;
            float gravDir = val.gravDir;
            if (type == ModContent.ItemType<LegendaryCatcher>())
            {
                mountedCenter.X += num * val.direction;
                if (val.direction < 0)
                {
                    mountedCenter.X -= 13f;
                }
                mountedCenter.Y -= num2 * gravDir;
            }
            if (gravDir == -1f)
            {
                mountedCenter.Y -= 12f;
            }
            mountedCenter = val.RotatedRelativePoint(mountedCenter + new Vector2(8f), true, true) - new Vector2(8f);
            Vector2 val2 = Projectile.Center - mountedCenter;
            bool flag = true;
            if (val2.X == 0f && val2.Y == 0f)
            {
                return false;
            }
            float num3 = val2.Length();
            num3 = 12f / num3;
            val2 *= num3;
            mountedCenter -= val2;
            val2 = Projectile.Center - mountedCenter;
            while (flag)
            {
                float num4 = 12f;
                float num5 = val2.Length();
                if (float.IsNaN(num5) || float.IsNaN(num5))
                {
                    break;
                }
                if (num5 < 20f)
                {
                    num4 = num5 - 8f;
                    flag = false;
                }
                val2 *= 12f / num5;
                mountedCenter += val2;
                val2.X = Projectile.position.X + Projectile.width * 0.5f - mountedCenter.X;
                val2.Y = Projectile.position.Y + Projectile.height * 0.1f - mountedCenter.Y;
                if (num5 > 12f)
                {
                    float num6 = 0.3f;
                    float num7 = Math.Abs(Projectile.velocity.X) + Math.Abs(Projectile.velocity.Y);
                    if (num7 > 16f)
                    {
                        num7 = 16f;
                    }
                    num7 = 1f - num7 / 16f;
                    num6 *= num7;
                    num7 = num5 / 80f;
                    if (num7 > 1f)
                    {
                        num7 = 1f;
                    }
                    num6 *= num7;
                    if (num6 < 0f)
                    {
                        num6 = 0f;
                    }
                    num7 = 1f - Projectile.localAI[0] / 100f;
                    num6 *= num7;
                    if (val2.Y > 0f)
                    {
                        val2.Y *= 1f + num6;
                        val2.X *= 1f - num6;
                    }
                    else
                    {
                        num7 = Math.Abs(Projectile.velocity.X) / 3f;
                        if (num7 > 1f)
                        {
                            num7 = 1f;
                        }
                        num7 -= 0.5f;
                        num6 *= num7;
                        if (num6 > 0f)
                        {
                            num6 *= 2f;
                        }
                        val2.Y *= 1f + num6;
                        val2.X *= 1f - num6;
                    }
                }
                float num8 = Utils.ToRotation(val2) - (float)Math.PI / 2f;
                Main.EntitySpriteDraw(TextureAssets.FishingLine.Value, new Vector2(mountedCenter.X - Main.screenPosition.X + TextureAssets.FishingLine.Width() * 0.5f, mountedCenter.Y - Main.screenPosition.Y + TextureAssets.FishingLine.Height() * 0.5f), (Rectangle?)new Rectangle(0, 0, Utils.Width(TextureAssets.FishingLine), (int)num4), Color.White, num8, new Vector2(TextureAssets.FishingLine.Width() * 0.5f, 0f), 1f, 0, 0f);
            }
            return false;
        }
    }
}
