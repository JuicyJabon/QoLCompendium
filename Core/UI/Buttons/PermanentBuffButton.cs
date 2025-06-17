namespace QoLCompendium.Core.UI.Buttons
{
    public class PermanentBuffButton : CustomUIImageButton
    {
        private readonly Asset<Texture2D> faceTexture;

        public Asset<Texture2D> drawTexture = null;

        public string Tooltip { get; set; }

        public LocalizedText ModTooltip = null;

        public bool disabled;

        public bool moddedBuff = false;

        public PermanentBuffButton(Asset<Texture2D> faceTexture) : base(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"))
        {
            this.faceTexture = faceTexture;
            //SetHoverImage(ModContent.Request<Texture2D>("QoLCompendium/Assets/Buffs/PermanentBuff_Hover"));
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


            if (moddedBuff && drawTexture != null)
            {
                if (disabled)
                    spriteBatch.Draw(drawTexture.Value, dimensions.Position(), Color.Gray * (IsMouseHovering ? VisibilityActive : VisibilityInactive));
                else
                    spriteBatch.Draw(drawTexture.Value, dimensions.Position(), Color.White * (IsMouseHovering ? VisibilityActive : VisibilityInactive));
            }
            else
            {
                if (disabled)
                    spriteBatch.Draw(faceTexture.Value, dimensions.Position(), Color.Gray * (IsMouseHovering ? VisibilityActive : VisibilityInactive));
                else
                    spriteBatch.Draw(faceTexture.Value, dimensions.Position(), Color.White * (IsMouseHovering ? VisibilityActive : VisibilityInactive));
            }

            if (moddedBuff)
            {
                if (IsMouseHovering)
                {
                    if (disabled)
                    {
                        Main.hoverItemName = ModTooltip.Value + " " + Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.Disabled");
                        Main.mouseText = true;
                    }
                    else
                    {
                        Main.hoverItemName = ModTooltip.Value;
                        Main.mouseText = true;
                    }
                }
            }
            else
            {
                if (IsMouseHovering)
                {
                    if (disabled)
                    {
                        Main.hoverItemName = Tooltip + " " + Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.Disabled");
                        Main.mouseText = true;
                    }
                    else
                    {
                        Main.hoverItemName = Tooltip;
                        Main.mouseText = true;
                    }
                }
            }
        }
    }
}
