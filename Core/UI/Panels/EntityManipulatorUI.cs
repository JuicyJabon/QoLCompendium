using QoLCompendium.Core.UI.Buttons;
using static Terraria.ModLoader.ModContent;

namespace QoLCompendium.Core.UI.Panels
{
    public class EntityManipulatorUI : UIState
    {
        public UIPanel ManipulatorPanel;
        public static bool visible = false;
        public static uint timeStart;

        public override void OnInitialize()
        {
            ManipulatorPanel = new UIPanel();
            ManipulatorPanel.Top.Set(Main.screenHeight / 2 - 30, 0f);
            ManipulatorPanel.Left.Set(Main.screenWidth / 2 + 95, 0f);
            ManipulatorPanel.Width.Set(144f, 0f);
            ManipulatorPanel.Height.Set(144f, 0f);
            ManipulatorPanel.BackgroundColor *= 0f;
            ManipulatorPanel.BorderColor *= 0f;
            Append(ManipulatorPanel);

            GenericUIButton.buttonTexture = 1;
            GenericUIButton increasedSpawnsButton = new(Request<Texture2D>("QoLCompendium/Assets/UI/UI_" + GenericUIButton.buttonTexture));
            increasedSpawnsButton.Left.Set(0f, 0f);
            increasedSpawnsButton.Top.Set(0f, 0f);
            increasedSpawnsButton.Width.Set(36f, 0f);
            increasedSpawnsButton.Height.Set(36f, 0f);
            increasedSpawnsButton.OnLeftClick += IncreasedSpawnsClicked;
            increasedSpawnsButton.Tooltip = UISystem.IncreaseSpawnText;
            ManipulatorPanel.Append(increasedSpawnsButton);

            GenericUIButton.buttonTexture = 2;
            GenericUIButton decreasedSpawnsButton = new(Request<Texture2D>("QoLCompendium/Assets/UI/UI_" + GenericUIButton.buttonTexture));
            decreasedSpawnsButton.Left.Set(36f, 0f);
            decreasedSpawnsButton.Top.Set(0f, 0f);
            decreasedSpawnsButton.Width.Set(36f, 0f);
            decreasedSpawnsButton.Height.Set(36f, 0f);
            decreasedSpawnsButton.OnLeftClick += DecreasedSpawnsClicked;
            decreasedSpawnsButton.Tooltip = UISystem.DecreaseSpawnText;
            ManipulatorPanel.Append(decreasedSpawnsButton);

            GenericUIButton.buttonTexture = 2;
            GenericUIButton revertButton = new(Request<Texture2D>("QoLCompendium/Assets/UI/UI_" + GenericUIButton.buttonTexture));
            revertButton.Left.Set(72f, 0f);
            revertButton.Top.Set(0f, 0f);
            revertButton.Width.Set(36f, 0f);
            revertButton.Height.Set(36f, 0f);
            revertButton.OnLeftClick += RevertButtonClicked;
            revertButton.Tooltip = UISystem.ResetText;
            ManipulatorPanel.Append(revertButton);

            GenericUIButton.buttonTexture = 0;
            GenericUIButton closeButton = new(Request<Texture2D>("QoLCompendium/Assets/UI/UI_" + GenericUIButton.buttonTexture));
            closeButton.Left.Set(36f, 0f);
            closeButton.Top.Set(36f, 0f);
            closeButton.Width.Set(36f, 0f);
            closeButton.Height.Set(36f, 0f);
            closeButton.OnLeftClick += CloseButtonClicked;
            closeButton.Tooltip = UISystem.CloseText;
            ManipulatorPanel.Append(closeButton);
        }

        private void IncreasedSpawnsClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.LocalPlayer.GetModPlayer<QoLCPlayer>().selectedSpawnModifier = 1;
                visible = false;
            }
        }

        private void DecreasedSpawnsClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.LocalPlayer.GetModPlayer<QoLCPlayer>().selectedSpawnModifier = 2;
                visible = false;
            }
        }

        private void RevertButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.LocalPlayer.GetModPlayer<QoLCPlayer>().selectedSpawnModifier = 0;
                visible = false;
            }
        }

        private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                SoundEngine.PlaySound(SoundID.MenuClose);
                visible = false;
            }
        }
    }
}
