using QoLCompendium.Tweaks;
using static Terraria.ModLoader.ModContent;

namespace QoLCompendium.UI
{
    class EntityManipulatorUI : UIState
    {
        public UIPanel ManipulatorPanel;
        public static bool visible = false;
        public static uint timeStart;

        public override void OnInitialize()
        {
            ManipulatorPanel = new UIPanel();
            ManipulatorPanel.SetPadding(0);
            ManipulatorPanel.Left.Set(575f, 0f);
            ManipulatorPanel.Top.Set(275f, 0f);
            ManipulatorPanel.Width.Set(290f, 0f);
            ManipulatorPanel.Height.Set(250f, 0f);
            ManipulatorPanel.BackgroundColor = new Color(73, 94, 171);

            ManipulatorPanel.OnLeftMouseDown += new MouseEvent(DragStart);
            ManipulatorPanel.OnLeftMouseUp += new MouseEvent(DragEnd);

            UIText text0 = new("Increase Spawns");
            text0.Left.Set(45, 0f);
            text0.Top.Set(16, 0f);
            text0.Width.Set(100, 0f);
            text0.Height.Set(26, 0f);
            ManipulatorPanel.Append(text0);

            UIText text1 = new("Decrease Spawns");
            text1.Left.Set(45, 0f);
            text1.Top.Set(56, 0f);
            text1.Width.Set(50, 0f);
            text1.Height.Set(26, 0f);
            ManipulatorPanel.Append(text1);

            UIText text2 = new("Cancel Spawns");
            text2.Left.Set(45, 0f);
            text2.Top.Set(96, 0f);
            text2.Width.Set(40, 0f);
            text2.Height.Set(26, 0f);
            ManipulatorPanel.Append(text2);

            UIText text3 = new("Cancel Events");
            text3.Left.Set(45, 0f);
            text3.Top.Set(136, 0f);
            text3.Width.Set(40, 0f);
            text3.Height.Set(26, 0f);
            ManipulatorPanel.Append(text3);

            UIText text4 = new("Cancel Events & Spawns");
            text4.Left.Set(45, 0f);
            text4.Top.Set(176, 0f);
            text4.Width.Set(40, 0f);
            text4.Height.Set(26, 0f);
            ManipulatorPanel.Append(text4);

            UIText text5 = new("Revert Changes");
            text5.Left.Set(45, 0f);
            text5.Top.Set(216, 0f);
            text5.Width.Set(40, 0f);
            text5.Height.Set(26, 0f);
            ManipulatorPanel.Append(text5);

            Asset<Texture2D> decreaseTexture = Request<Texture2D>("QoLCompendium/Assets/UI/Decrease");
            Asset<Texture2D> increaseTexture = Request<Texture2D>("QoLCompendium/Assets/UI/Increase");
            Asset<Texture2D> cancelTexture = Request<Texture2D>("QoLCompendium/Assets/UI/Cancel");
            Asset<Texture2D> buttonDeleteTexture = Request<Texture2D>("Terraria/Images/UI/ButtonDelete");

            UIImageButton playButton0 = new(increaseTexture);
            playButton0.Left.Set(10, 0f);
            playButton0.Top.Set(10, 0f);
            playButton0.Width.Set(32, 0f);
            playButton0.Height.Set(32, 0f);
            playButton0.OnLeftClick += new MouseEvent(PlayButtonClicked0);
            ManipulatorPanel.Append(playButton0);

            UIImageButton playButton1 = new(decreaseTexture);
            playButton1.Left.Set(10, 0f);
            playButton1.Top.Set(50, 0f);
            playButton1.Width.Set(32, 0f);
            playButton1.Height.Set(32, 0f);
            playButton1.OnLeftClick += new MouseEvent(PlayButtonClicked1);
            ManipulatorPanel.Append(playButton1);

            UIImageButton playButton2 = new(cancelTexture);
            playButton2.Left.Set(10, 0f);
            playButton2.Top.Set(90, 0f);
            playButton2.Width.Set(32, 0f);
            playButton2.Height.Set(32, 0f);
            playButton2.OnLeftClick += new MouseEvent(PlayButtonClicked2);
            ManipulatorPanel.Append(playButton2);

            UIImageButton playButton3 = new(cancelTexture);
            playButton3.Left.Set(10, 0f);
            playButton3.Top.Set(130, 0f);
            playButton3.Width.Set(32, 0f);
            playButton3.Height.Set(32, 0f);
            playButton3.OnLeftClick += new MouseEvent(PlayButtonClicked3);
            ManipulatorPanel.Append(playButton3);

            UIImageButton playButton4 = new(cancelTexture);
            playButton4.Left.Set(10, 0f);
            playButton4.Top.Set(170, 0f);
            playButton4.Width.Set(32, 0f);
            playButton4.Height.Set(32, 0f);
            playButton4.OnLeftClick += new MouseEvent(PlayButtonClicked4);
            ManipulatorPanel.Append(playButton4);

            UIImageButton playButton5 = new(cancelTexture);
            playButton5.Left.Set(10, 0f);
            playButton5.Top.Set(210, 0f);
            playButton5.Width.Set(32, 0f);
            playButton5.Height.Set(32, 0f);
            playButton5.OnLeftClick += new MouseEvent(PlayButtonClicked5);
            ManipulatorPanel.Append(playButton5);

            UIImageButton closeButton = new(buttonDeleteTexture);
            closeButton.Left.Set(260, 0f);
            closeButton.Top.Set(10, 0f);
            closeButton.Width.Set(22, 0f);
            closeButton.Height.Set(22, 0f);
            closeButton.OnLeftClick += new MouseEvent(CloseButtonClicked);
            ManipulatorPanel.Append(closeButton);
            Append(ManipulatorPanel);
        }

        private void PlayButtonClicked0(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetModPlayer<QoLCPlayer>().selectedSpawnModifier = 0;
                visible = false;
            }
        }

        private void PlayButtonClicked1(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetModPlayer<QoLCPlayer>().selectedSpawnModifier = 1;
                visible = false;
            }
        }

        private void PlayButtonClicked2(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetModPlayer<QoLCPlayer>().selectedSpawnModifier = 2;
                visible = false;
            }
        }

        private void PlayButtonClicked3(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetModPlayer<QoLCPlayer>().selectedSpawnModifier = 3;
                visible = false;
            }
        }

        private void PlayButtonClicked4(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetModPlayer<QoLCPlayer>().selectedSpawnModifier = 4;
                visible = false;
            }
        }

        private void PlayButtonClicked5(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetModPlayer<QoLCPlayer>().selectedSpawnModifier = 5;
                visible = false;
            }
        }

        private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                SoundEngine.PlaySound(SoundID.MenuOpen);
                visible = false;
            }
        }

        Vector2 offset;
        public bool dragging = false;
        private void DragStart(UIMouseEvent evt, UIElement listeningElement)
        {
            offset = new Vector2(evt.MousePosition.X - ManipulatorPanel.Left.Pixels, evt.MousePosition.Y - ManipulatorPanel.Top.Pixels);
            dragging = true;
        }

        private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            dragging = false;

            ManipulatorPanel.Left.Set(end.X - offset.X, 0f);
            ManipulatorPanel.Top.Set(end.Y - offset.Y, 0f);

            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 MousePosition = new(Main.mouseX, Main.mouseY);
            if (ManipulatorPanel.ContainsPoint(MousePosition))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
            if (dragging)
            {
                ManipulatorPanel.Left.Set(MousePosition.X - offset.X, 0f);
                ManipulatorPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
                Recalculate();
            }
        }
    }
}
