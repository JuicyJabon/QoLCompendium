namespace QoLCompendium.Core.UI.Buttons
{
    public class MoonPhaseButton : CustomUIImageButton
    {
        private readonly Asset<Texture2D> faceTexture;
        public LocalizedText Tooltip { get; set; }

        //0 = Full Moon
        //1 = Waning Gibbous
        //2 = Third Quarter
        //3 = Waning Crescent
        //4 = New Moon
        //5 = Waxing Crescent
        //6 = First Quarter
        //7 = Waxing Gibbous
        public static int moonTexture;

        public MoonPhaseButton(Asset<Texture2D> faceTexture) : base(ModContent.Request<Texture2D>("QoLCompendium/Assets/Moons/Moon_" + moonTexture))
        {
            this.faceTexture = faceTexture;
            SetHoverImage(ModContent.Request<Texture2D>("QoLCompendium/Assets/Hover/Moon_" + moonTexture));
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
