namespace QoLCompendium.Core.UI.Buttons
{
    public class GenericUIButton : CustomUIImageButton
    {
        private readonly Asset<Texture2D> faceTexture;
        public LocalizedText Tooltip { get; set; }

        //0 = Cancel
        //1 = Add
        //2 = Subtract
        public static int buttonTexture;

        public GenericUIButton(Asset<Texture2D> faceTexture) : base(ModContent.Request<Texture2D>("QoLCompendium/Assets/UI/UI_" + buttonTexture))
        {
            this.faceTexture = faceTexture;
            SetHoverImage(ModContent.Request<Texture2D>("QoLCompendium/Assets/Hover/UI_" + buttonTexture));
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);

            CalculatedStyle dimensions = GetDimensions();
            spriteBatch.Draw(faceTexture.Value, dimensions.Position(), Color.White * (IsMouseHovering ? VisibilityActive : VisibilityInactive));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            if (IsMouseHovering)
            {
                Main.hoverItemName = Tooltip.Value;
                Main.mouseText = true;
            }
        }
    }
}
