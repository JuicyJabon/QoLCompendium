namespace QoLCompendium.Core.UI.Buttons
{
    public class MinibossButton : CustomUIImageButton
    {
        private readonly Asset<Texture2D> faceTexture;
        public LocalizedText Tooltip { get; set; }

        public static int minibossTexture;

        public static int backgroundTexture;

        public MinibossButton(Asset<Texture2D> faceTexture) : base(ModContent.Request<Texture2D>("QoLCompendium/Assets/Backgrounds/Background_Red_" + backgroundTexture))
        {
            this.faceTexture = faceTexture;
            SetHoverImage(ModContent.Request<Texture2D>("QoLCompendium/Assets/Summons/Miniboss_Hover_" + minibossTexture));
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
