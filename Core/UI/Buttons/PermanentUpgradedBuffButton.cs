namespace QoLCompendium.Core.UI.Buttons
{
    public class PermanentUpgradedBuffButton : CustomUIImageButton
    {
        private readonly Asset<Texture2D> faceTexture;
        public LocalizedText Tooltip { get; set; }

        public PermanentUpgradedBuffButton(Asset<Texture2D> faceTexture) : base(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentUpgradedBuff"))
        {
            this.faceTexture = faceTexture;
            //SetHoverImage(ModContent.Request<Texture2D>("QoLCompendium/Assets/Buffs/PermanentUpgradedBuff_Hover"));
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
            UpdateDraw(spriteBatch);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            UpdateDraw(spriteBatch);
        }

        private void UpdateDraw(SpriteBatch spriteBatch)
        {
            CalculatedStyle dimensions = GetDimensions();
            spriteBatch.Draw(faceTexture.Value, dimensions.Position(), Color.White * (IsMouseHovering ? VisibilityActive : VisibilityInactive));

            if (IsMouseHovering)
            {
                Main.hoverItemName = Tooltip.Value;
                Main.mouseText = true;
            }
        }
    }
}
