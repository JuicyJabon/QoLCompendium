namespace QoLCompendium.Core.UI
{
    public class CustomUIImageButton : SafeUIElement
    {
        private Asset<Texture2D> _texture;
        private Asset<Texture2D> _borderTexture;

        public float VisibilityActive { get; private set; } = 1f;
        public float VisibilityInactive { get; private set; } = 1f;

        public CustomUIImageButton(Asset<Texture2D> texture)
        {
            _texture = texture;
            Width.Set(_texture.Width(), 0.0f);
            Height.Set(_texture.Height(), 0.0f);
        }

        public void SetHoverImage(Asset<Texture2D> texture) => _borderTexture = texture;

        public void SetImage(Asset<Texture2D> texture)
        {
            _texture = texture;
            Width.Set(_texture.Width(), 0.0f);
            Height.Set(_texture.Height(), 0.0f);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            CalculatedStyle dimensions = GetDimensions();
            spriteBatch.Draw(_texture.Value, dimensions.Position(), Color.White * (IsMouseHovering ? VisibilityActive : VisibilityInactive));
            if (_borderTexture == null || !IsMouseHovering)
            {
                return;
            }

            spriteBatch.Draw(_borderTexture.Value, dimensions.Position(), Color.White);
        }

        public override void MouseOver(UIMouseEvent evt)
        {
            base.MouseOver(evt);
            SoundEngine.PlaySound(SoundID.MenuTick);
        }

        public override void SafeUpdate(GameTime gameTime)
        {
            if (ContainsPoint(Main.MouseScreen))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
        }

        public void SetVisibility(float whenActive, float whenInactive)
        {
            VisibilityActive = MathHelper.Clamp(whenActive, 0.0f, 1f);
            VisibilityInactive = MathHelper.Clamp(whenInactive, 0.0f, 1f);
        }
    }
}
