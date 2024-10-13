using QoLCompendium.Core.UI.Buttons;

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
            ManipulatorPanel.Top.Set(Main.screenHeight / 2, 0f);
            ManipulatorPanel.Left.Set(Main.screenWidth / 2 + 7, 0f);
            ManipulatorPanel.Width.Set(400f, 0f);
            ManipulatorPanel.Height.Set(400f, 0f);
            ManipulatorPanel.BackgroundColor *= 0f;
            ManipulatorPanel.BorderColor *= 0f;
            Append(ManipulatorPanel);

            SpawnModifierButton.backgroundTexture = 0;
            SpawnModifierButton increasedSpawnsButton = new(Common.GetAsset("SpawnModifiers", "Modifier_", SpawnModifierButton.modifierTexture = 0));
            increasedSpawnsButton.Left.Set(0f, 0f);
            increasedSpawnsButton.Top.Set(0f, 0f);
            increasedSpawnsButton.Width.Set(40f, 0f);
            increasedSpawnsButton.Height.Set(40f, 0f);
            increasedSpawnsButton.OnLeftClick += IncreasedSpawnsClicked;
            increasedSpawnsButton.Tooltip = UISystem.IncreaseSpawnText;
            ManipulatorPanel.Append(increasedSpawnsButton);

            SpawnModifierButton.backgroundTexture = 1;
            SpawnModifierButton decreasedSpawnsButton = new(Common.GetAsset("SpawnModifiers", "Modifier_", SpawnModifierButton.modifierTexture = 1));
            decreasedSpawnsButton.Left.Set(40f, 0f);
            decreasedSpawnsButton.Top.Set(0f, 0f);
            decreasedSpawnsButton.Width.Set(40f, 0f);
            decreasedSpawnsButton.Height.Set(40f, 0f);
            decreasedSpawnsButton.OnLeftClick += DecreasedSpawnsClicked;
            decreasedSpawnsButton.Tooltip = UISystem.DecreaseSpawnText;
            ManipulatorPanel.Append(decreasedSpawnsButton);

            SpawnModifierButton.backgroundTexture = 1;
            SpawnModifierButton noSpawnsButton = new(Common.GetAsset("SpawnModifiers", "Modifier_", SpawnModifierButton.modifierTexture = 2));
            noSpawnsButton.Left.Set(80f, 0f);
            noSpawnsButton.Top.Set(0f, 0f);
            noSpawnsButton.Width.Set(40f, 0f);
            noSpawnsButton.Height.Set(40f, 0f);
            noSpawnsButton.OnLeftClick += NoSpawnsClicked;
            noSpawnsButton.Tooltip = UISystem.CancelSpawnText;
            ManipulatorPanel.Append(noSpawnsButton);

            SpawnModifierButton.backgroundTexture = 1;
            SpawnModifierButton noEventsButton = new(Common.GetAsset("SpawnModifiers", "Modifier_", SpawnModifierButton.modifierTexture = 3));
            noEventsButton.Left.Set(120f, 0f);
            noEventsButton.Top.Set(0f, 0f);
            noEventsButton.Width.Set(40f, 0f);
            noEventsButton.Height.Set(40f, 0f);
            noEventsButton.OnLeftClick += NoEventsClicked;
            noEventsButton.Tooltip = UISystem.CancelEventText;
            ManipulatorPanel.Append(noEventsButton);

            SpawnModifierButton.backgroundTexture = 1;
            SpawnModifierButton noSpawnsOrEventsButton = new(Common.GetAsset("SpawnModifiers", "Modifier_", SpawnModifierButton.modifierTexture = 4));
            noSpawnsOrEventsButton.Left.Set(160f, 0f);
            noSpawnsOrEventsButton.Top.Set(0f, 0f);
            noSpawnsOrEventsButton.Width.Set(40f, 0f);
            noSpawnsOrEventsButton.Height.Set(40f, 0f);
            noSpawnsOrEventsButton.OnLeftClick += NoSpawnsOrEventsClicked;
            noSpawnsOrEventsButton.Tooltip = UISystem.CancelSpawnAndEventText;
            ManipulatorPanel.Append(noSpawnsOrEventsButton);

            GenericUIButton.backgroundTexture = 1;
            GenericUIButton revertButton = new(Common.GetAsset("Buttons", "Button_Small_", GenericUIButton.buttonTexture = 2));
            revertButton.Left.Set(200f, 0f);
            revertButton.Top.Set(0f, 0f);
            revertButton.Width.Set(40f, 0f);
            revertButton.Height.Set(40f, 0f);
            revertButton.OnLeftClick += RevertButtonClicked;
            revertButton.Tooltip = UISystem.ResetText;
            ManipulatorPanel.Append(revertButton);

            GenericUIButton.backgroundTexture = 2;
            GenericUIButton closeButton = new(Common.GetAsset("Buttons", "Button_Small_", GenericUIButton.buttonTexture = 3));
            closeButton.Left.Set(240f, 0f);
            closeButton.Top.Set(0f, 0f);
            closeButton.Width.Set(40f, 0f);
            closeButton.Height.Set(40f, 0f);
            closeButton.OnLeftClick += CloseButtonClicked;
            closeButton.Tooltip = UISystem.CloseText;
            ManipulatorPanel.Append(closeButton);
        }

        private void RevertButtonClicked(UIMouseEvent evt, UIElement listeningElement) => SpawnChangeClick(0);
        private void IncreasedSpawnsClicked(UIMouseEvent evt, UIElement listeningElement) => SpawnChangeClick(1);
        private void DecreasedSpawnsClicked(UIMouseEvent evt, UIElement listeningElement) => SpawnChangeClick(2);
        private void NoSpawnsClicked(UIMouseEvent evt, UIElement listeningElement) => SpawnChangeClick(3);
        private void NoEventsClicked(UIMouseEvent evt, UIElement listeningElement) => SpawnChangeClick(4);
        private void NoSpawnsOrEventsClicked(UIMouseEvent evt, UIElement listeningElement) => SpawnChangeClick(5);

        private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                SoundEngine.PlaySound(SoundID.MenuClose);
                visible = false;
            }
        }

        public static void SpawnChangeClick(int modifier)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.LocalPlayer.GetModPlayer<QoLCPlayer>().selectedSpawnModifier = modifier;
                SoundEngine.PlaySound(SoundID.MenuTick);
            }
        }
    }
}
