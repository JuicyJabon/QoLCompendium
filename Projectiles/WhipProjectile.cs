namespace QoLCompendium.Projectiles
{
    public abstract class WhipProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.IsAWhip[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ownerHitCheck = true;
            Projectile.extraUpdates = 1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;
            Projectile.DamageType = DamageClass.Generic;
            whipSegment = (Texture2D)ModContent.Request<Texture2D>($"{nameof(QoLCompendium)}/Projectiles/SillySlapperWhip_Segment", AssetRequestMode.AsyncLoad);
            whipTip = (Texture2D)ModContent.Request<Texture2D>($"{nameof(QoLCompendium)}/Projectiles/SillySlapperWhip_Tip", AssetRequestMode.AsyncLoad);
            SetWhipStats();
        }

        public override bool PreAI()
        {
            if ((double)(Timer % 2f) < 0.001)
            {
                whipPoints.Clear();
                Projectile.FillWhipControlPoints(Projectile, whipPoints);
            }
            return true;
        }

        public virtual void SetWhipStats()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.WhipSettings.Segments = 30;
            Projectile.WhipSettings.RangeMultiplier = 1f;
        }

        internal float Timer
        {
            get
            {
                return Projectile.ai[0];
            }
            set
            {
                Projectile.ai[0] = value;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            return DrawWhip(fishingLineColor);
        }

        internal bool DrawWhip(Color lineColor)
        {
            if (whipPoints == null || whipPoints.Count < 1)
            {
                return false;
            }
            DrawFishingLineBetweenPoints(whipPoints, lineColor, true);
            SpriteEffects spriteEffects = (SpriteEffects)((Projectile.spriteDirection > 0) ? 0 : 2);
            Main.instance.LoadProjectile(Type);
            Texture2D value = TextureAssets.Projectile[Type].Value;
            Rectangle rectangle = new(0, 0, value.Width, value.Height);
            Vector2 vector = Utils.Size(rectangle) / 2f;
            Vector2 vector2 = whipPoints[0];
            for (int i = 0; i < whipPoints.Count - 1; i++)
            {
                float num = 1f;
                if (i == whipPoints.Count - 2)
                {
                    value = whipTip;
                    rectangle = new(0, 0, value.Width, value.Height);
                    vector = Utils.Size(rectangle) / 2f;
                    Projectile.GetWhipSettings(Projectile, out float num2, out _, out _);
                    float num5 = Timer / num2;
                    num = MathHelper.Lerp(0.5f, 1.5f, Utils.GetLerpValue(0.1f, 0.7f, num5, true) * Utils.GetLerpValue(0.9f, 0.7f, num5, true));
                }
                else if (i > 0)
                {
                    value = whipSegment;
                    rectangle = new(0, 0, value.Width, value.Height);
                    vector = Utils.Size(rectangle) / 2f;
                }
                Vector2 vector3 = whipPoints[i];
                Vector2 vector4 = whipPoints[i + 1] - vector3;
                float num6 = Utils.ToRotation(vector4) + segmentRotation;
                if (i == 0)
                {
                    num6 = Utils.ToRotation(vector4);
                }
                Color color = Lighting.GetColor(Utils.ToTileCoordinates(vector3));
                if (drawColor != null)
                {
                    color = drawColor.Value;
                }
                Main.EntitySpriteDraw(value, vector2 - Main.screenPosition, new Rectangle?(rectangle), color, num6, vector, num, spriteEffects, 0);
                vector2 += vector4;
            }
            return false;
        }

        public virtual void WhipAIMotion()
        {
            Player player = Main.player[Projectile.owner];
            float num = player.itemAnimationMax * Projectile.MaxUpdates;
            if (runOnce)
            {
                Projectile.WhipSettings.Segments = (int)((player.whipRangeMultiplier + 1f) * Projectile.WhipSettings.Segments);
                runOnce = false;
            }
            Projectile.rotation = Utils.ToRotation(Projectile.velocity) + 1.5707964f;
            Projectile.Center = Vector2.Lerp(Projectile.Center, whipPoints[^1], 1f);
            Projectile.spriteDirection = ((Projectile.velocity.X >= 0f) ? 1 : -1);
            float timer = Timer;
            Timer = timer + 1f;
            if (Timer >= num || player.itemAnimation <= 0)
            {
                Projectile.Kill();
                return;
            }
        }

        public virtual void WhipSFX(Color lightingCol, int? dustID, int dustNum, SoundStyle? sound)
        {
            Player player = Main.player[Projectile.owner];
            float num = player.itemAnimationMax * Projectile.MaxUpdates;
            player.heldProj = Projectile.whoAmI;
            Vector2 tipPosition = GetTipPosition();
            if (Timer == num / 2f && sound != null)
            {
                SoundEngine.PlaySound(sound, new Vector2?(tipPosition));
            }
            if (Timer >= num * 0.5f)
            {
                if (dustID != null)
                {
                    for (int i = 0; i < dustNum; i++)
                    {
                        Dust.NewDust(tipPosition, 2, 2, dustID.Value, 0f, 0f, 0, default, 0.5f);
                    }
                }
                if (lightingCol != Color.Transparent)
                {
                    Lighting.AddLight(tipPosition, lightingCol.R / 255f, lightingCol.G / 255f, lightingCol.B / 255f);
                }
            }
        }

        public override void AI()
        {
            WhipAIMotion();
            WhipSFX(lightingColor, swingDust, dustAmount, whipCrackSound);
        }

        internal static void DrawFishingLineBetweenPoints(List<Vector2> list, Color lineCol, bool useLighCol = true)
        {
            Texture2D value = TextureAssets.FishingLine.Value;
            Rectangle rectangle = Utils.Frame(value, 1, 1, 0, 0, 0, 0);
            Vector2 vector = new(rectangle.Width / 2, 2f);
            Vector2 vector2 = list[0];
            for (int i = 0; i < list.Count - 2; i++)
            {
                Vector2 vector3 = list[i];
                Vector2 vector4 = list[i + 1] - vector3;
                float num = Utils.ToRotation(vector4) - 1.5707964f;
                Color color = lineCol;
                if (useLighCol)
                {
                    color = Lighting.GetColor(Utils.ToTileCoordinates(vector3), lineCol);
                }
                Vector2 vector5 = new(1f, (vector4.Length() + 2f) / rectangle.Height);
                Main.EntitySpriteDraw(value, vector2 - Main.screenPosition, new Rectangle?(rectangle), color, num, vector, vector5, 0, 0);
                vector2 += vector4;
            }
        }

        internal Vector2 GetTipPosition()
        {
            return whipPoints[^2];
        }

        public Color fishingLineColor = Color.White;

        public Color lightingColor = Color.Transparent;

        public Color? drawColor;

        public int? swingDust;

        public int dustAmount;

        public SoundStyle? whipCrackSound = new SoundStyle?(SoundID.Item153);

        public Texture2D whipSegment;

        public Texture2D whipTip;

        public List<Vector2> whipPoints = new();

        public int? tagType;

        public int tagDuration = 240;

        public float multihitModifier = 0.8f;

        public float segmentRotation;

        private bool runOnce = true;
    }
}
