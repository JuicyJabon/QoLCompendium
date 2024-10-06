namespace QoLCompendium.Core.UI
{
    public class MouseCenteredUIPanel : UIPanel
    {
        private bool centeredOnMouse;

        public override void OnActivate()
        {
            base.OnActivate();
            centeredOnMouse = true;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (!centeredOnMouse)
            {
                return;
            }

            centeredOnMouse = false;
            Left.Set(Main.mouseX - Width.Pixels / 2f, 0f);
            Top.Set(Main.mouseY - Height.Pixels / 2f, 0f);
            Recalculate();
        }

        protected override void DrawChildren(SpriteBatch spriteBatch)
        {
            if (!centeredOnMouse)
            {
                base.DrawChildren(spriteBatch);
            }
        }
    }
}
