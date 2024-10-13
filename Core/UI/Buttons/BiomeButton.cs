namespace QoLCompendium.Core.UI.Buttons
{
    public class BiomeButton : CustomUIImageButton
    {
        private readonly Asset<Texture2D> faceTexture;
        public LocalizedText Tooltip { get; set; }

        //0 = Desert
        //1 = Snow
        //2 = Jungle
        //3 = Glowing Mushroom
        //4 = Corruption
        //5 = Crimson
        //6 = Hallow
        //7 = Purity/Forest
        public static int biomeTexture;

        //0 = Left
        //1 = Center
        //2 = Right
        public static int backgroundTexture;

        public BiomeButton(Asset<Texture2D> faceTexture) : base(ModContent.Request<Texture2D>("QoLCompendium/Assets/Backgrounds/Background_" + backgroundTexture))
        {
            this.faceTexture = faceTexture;
            SetHoverImage(ModContent.Request<Texture2D>("QoLCompendium/Assets/Biomes/Biome_Hover_" + biomeTexture));
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
