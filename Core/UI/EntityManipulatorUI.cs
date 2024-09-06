using static Terraria.ModLoader.ModContent;

namespace QoLCompendium.Core.UI
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
            ManipulatorPanel.Left.Set(Main.screenWidth / 2, 0f);
            ManipulatorPanel.Top.Set(200f, 0f);
            ManipulatorPanel.Width.Set(290f, 0f);
            ManipulatorPanel.Height.Set(250f, 0f);
            ManipulatorPanel.BackgroundColor = new Color(99, 25, 25);

            ManipulatorPanel.OnLeftMouseDown += new MouseEvent(DragStart);
            ManipulatorPanel.OnLeftMouseUp += new MouseEvent(DragEnd);

            UIText increaseSpawnsText = new("Increase Spawns");
            increaseSpawnsText.Left.Set(45, 0f);
            increaseSpawnsText.Top.Set(16, 0f);
            increaseSpawnsText.Width.Set(100, 0f);
            increaseSpawnsText.Height.Set(26, 0f);
            ManipulatorPanel.Append(increaseSpawnsText);

            UIText decreaseSpawnsText = new("Decrease Spawns");
            decreaseSpawnsText.Left.Set(45, 0f);
            decreaseSpawnsText.Top.Set(56, 0f);
            decreaseSpawnsText.Width.Set(50, 0f);
            decreaseSpawnsText.Height.Set(26, 0f);
            ManipulatorPanel.Append(decreaseSpawnsText);

            UIText cancelSpawnsText = new("Cancel Spawns");
            cancelSpawnsText.Left.Set(45, 0f);
            cancelSpawnsText.Top.Set(96, 0f);
            cancelSpawnsText.Width.Set(40, 0f);
            cancelSpawnsText.Height.Set(26, 0f);
            ManipulatorPanel.Append(cancelSpawnsText);

            UIText cancelEventsText = new("Cancel Events");
            cancelEventsText.Left.Set(45, 0f);
            cancelEventsText.Top.Set(136, 0f);
            cancelEventsText.Width.Set(40, 0f);
            cancelEventsText.Height.Set(26, 0f);
            ManipulatorPanel.Append(cancelEventsText);

            UIText cancelSpawnsAndEventsText = new("Cancel Events & Spawns");
            cancelSpawnsAndEventsText.Left.Set(45, 0f);
            cancelSpawnsAndEventsText.Top.Set(176, 0f);
            cancelSpawnsAndEventsText.Width.Set(40, 0f);
            cancelSpawnsAndEventsText.Height.Set(26, 0f);
            ManipulatorPanel.Append(cancelSpawnsAndEventsText);

            UIText revertText = new("Revert Changes");
            revertText.Left.Set(45, 0f);
            revertText.Top.Set(216, 0f);
            revertText.Width.Set(40, 0f);
            revertText.Height.Set(26, 0f);
            ManipulatorPanel.Append(revertText);

            Asset<Texture2D> decreaseTexture = Request<Texture2D>("QoLCompendium/Assets/UI/Decrease");
            Asset<Texture2D> increaseTexture = Request<Texture2D>("QoLCompendium/Assets/UI/Increase");
            Asset<Texture2D> cancelTexture = Request<Texture2D>("QoLCompendium/Assets/UI/Cancel");
            Asset<Texture2D> buttonDeleteTexture = Request<Texture2D>("Terraria/Images/UI/ButtonDelete");

            UIImageButton increaseSpawnsButton = new(increaseTexture);
            increaseSpawnsButton.Left.Set(10, 0f);
            increaseSpawnsButton.Top.Set(10, 0f);
            increaseSpawnsButton.Width.Set(32, 0f);
            increaseSpawnsButton.Height.Set(32, 0f);
            increaseSpawnsButton.OnLeftClick += new MouseEvent(IncreaseSpawnsButtonClicked);
            ManipulatorPanel.Append(increaseSpawnsButton);

            UIImageButton decreaseSpawnsButton = new(decreaseTexture);
            decreaseSpawnsButton.Left.Set(10, 0f);
            decreaseSpawnsButton.Top.Set(50, 0f);
            decreaseSpawnsButton.Width.Set(32, 0f);
            decreaseSpawnsButton.Height.Set(32, 0f);
            decreaseSpawnsButton.OnLeftClick += new MouseEvent(DecreaseSpawnsButtonClicked);
            ManipulatorPanel.Append(decreaseSpawnsButton);

            UIImageButton cancelSpawnsButton = new(cancelTexture);
            cancelSpawnsButton.Left.Set(10, 0f);
            cancelSpawnsButton.Top.Set(90, 0f);
            cancelSpawnsButton.Width.Set(32, 0f);
            cancelSpawnsButton.Height.Set(32, 0f);
            cancelSpawnsButton.OnLeftClick += new MouseEvent(CancelSpawnsButtonClicked);
            ManipulatorPanel.Append(cancelSpawnsButton);

            UIImageButton cancelEventsButton = new(cancelTexture);
            cancelEventsButton.Left.Set(10, 0f);
            cancelEventsButton.Top.Set(130, 0f);
            cancelEventsButton.Width.Set(32, 0f);
            cancelEventsButton.Height.Set(32, 0f);
            cancelEventsButton.OnLeftClick += new MouseEvent(CancelEventsButtonClicked);
            ManipulatorPanel.Append(cancelEventsButton);

            UIImageButton cancelSpawnsAndEventsButton = new(cancelTexture);
            cancelSpawnsAndEventsButton.Left.Set(10, 0f);
            cancelSpawnsAndEventsButton.Top.Set(170, 0f);
            cancelSpawnsAndEventsButton.Width.Set(32, 0f);
            cancelSpawnsAndEventsButton.Height.Set(32, 0f);
            cancelSpawnsAndEventsButton.OnLeftClick += new MouseEvent(CancelSpawnsAndEventsButtonClicked);
            ManipulatorPanel.Append(cancelSpawnsAndEventsButton);

            UIImageButton revertButton = new(decreaseTexture);
            revertButton.Left.Set(10, 0f);
            revertButton.Top.Set(210, 0f);
            revertButton.Width.Set(32, 0f);
            revertButton.Height.Set(32, 0f);
            revertButton.OnLeftClick += new MouseEvent(RevertButtonClicked);
            ManipulatorPanel.Append(revertButton);

            UIImageButton closeButton = new(buttonDeleteTexture);
            closeButton.Left.Set(260, 0f);
            closeButton.Top.Set(10, 0f);
            closeButton.Width.Set(22, 0f);
            closeButton.Height.Set(22, 0f);
            closeButton.OnLeftClick += new MouseEvent(CloseButtonClicked);
            ManipulatorPanel.Append(closeButton);
            Append(ManipulatorPanel);
        }

        private void IncreaseSpawnsButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetQoLCPlayer().selectedSpawnModifier = 0;
                visible = false;
            }
        }

        private void DecreaseSpawnsButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetQoLCPlayer().selectedSpawnModifier = 1;
                visible = false;
            }
        }

        private void CancelSpawnsButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetQoLCPlayer().selectedSpawnModifier = 2;
                visible = false;
            }
        }

        private void CancelEventsButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetQoLCPlayer().selectedSpawnModifier = 3;
                visible = false;
            }
        }

        private void CancelSpawnsAndEventsButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetQoLCPlayer().selectedSpawnModifier = 4;
                visible = false;
            }
        }

        private void RevertButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetQoLCPlayer().selectedSpawnModifier = 5;
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
