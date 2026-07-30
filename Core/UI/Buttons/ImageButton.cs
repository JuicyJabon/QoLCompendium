using QoLCompendium.Core.UI;
using Terraria.ModLoader.UI;

namespace QoLCompendium.Core.UI.Buttons
{
    public class ImageButton : SafeUIElement
    {
        private Asset<Texture2D> _texture;
        
        public string TooltipText = "";

        public string IdentificationText = "";

        public bool disabled = false;

        public float VisibilityActive { get; private set; } = 1f;

        public float VisibilityInactive { get; private set; } = 1f;

        public ImageButton(Asset<Texture2D> texture)
        {
            _texture = texture;
            Width.Set(_texture.Width(), 0.0f);
            Height.Set(_texture.Height(), 0.0f);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            CalculatedStyle dimensions = GetDimensions();
            Vector2 imagePosition = dimensions.Position() + (new Vector2(dimensions.Width, dimensions.Height) - _texture.Size()) * 0.5f;

            Vector2 bottomRight = dimensions.Position() + (new Vector2(dimensions.Width, dimensions.Height) - _texture.Size());

            spriteBatch.Draw(_texture.Value, imagePosition, Color.White * (IsMouseHovering ? VisibilityActive : VisibilityInactive));

            if (disabled)
                spriteBatch.Draw(Common.GetAsset("Buttons", "Button_Small_", 0).Value, bottomRight, Color.White);

            if (!IsMouseHovering)
                return;
            
            var outlineTexture = HoverTextures.GetOutlineTexture(_texture.Value, 2);
            if (outlineTexture != null)
            {
                Vector2 origin = outlineTexture.Size() * 0.5f;
                Vector2 origCenter = imagePosition + _texture.Size() * 0.5f;

                spriteBatch.Draw(outlineTexture, origCenter, null, Color.White, 0f, origin, 1f, SpriteEffects.None, default);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (IsMouseHovering)
            {
                if (TooltipText != "")
                {
                    UICommon.TooltipMouseText(TooltipText);
                }
            }
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
