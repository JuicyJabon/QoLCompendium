using QoLCompendium.Core.UI.Buttons;

namespace QoLCompendium.Core.UI.Panels
{
    public class EntityManipulatorUI : UIState
    {
        public UIPanel ManipulatorPanel;
        public static bool visible = false;
        public static uint timeStart;
        public Color color = new(48, 107, 184);

        internal static string GetUIText(string key, string category = "EntityManipulatorUI") => QoLCUISystem.GetUIText(category, key);

        public override void OnInitialize()
        {
            ManipulatorPanel = new();
            ManipulatorPanel.SetPadding(6);
            ManipulatorPanel.HAlign = 0.617f;
            ManipulatorPanel.VAlign = 0.53f;
            ManipulatorPanel.Width.Set(216f, 0f);
            ManipulatorPanel.Height.Set(46f, 0f);
            ManipulatorPanel.BackgroundColor *= 0f;
            ManipulatorPanel.BorderColor *= 0f;
            Append(ManipulatorPanel);

            ImageButton increasedSpawnsButton = new(Common.GetAsset("SpawnModifiers", "Modifier_", (int)UIEnums.SpawnRateManipulators.IncreasedSpawns));
            increasedSpawnsButton.Left.Set(0f, 0f);
            increasedSpawnsButton.VAlign = 0.5f;
            increasedSpawnsButton.Width.Set(34f, 0f);
            increasedSpawnsButton.Height.Set(34f, 0f);
            increasedSpawnsButton.OnLeftClick += IncreasedSpawnsClicked;
            increasedSpawnsButton.TooltipText = GetUIText("IncreaseSpawnsText");
            ManipulatorPanel.Append(increasedSpawnsButton);

            ImageButton decreasedSpawnsButton = new(Common.GetAsset("SpawnModifiers", "Modifier_", (int)UIEnums.SpawnRateManipulators.DecreasedSpawns));
            decreasedSpawnsButton.Left.Set(34f, 0f);
            decreasedSpawnsButton.VAlign = 0.5f;
            decreasedSpawnsButton.Width.Set(34f, 0f);
            decreasedSpawnsButton.Height.Set(34f, 0f);
            decreasedSpawnsButton.OnLeftClick += DecreasedSpawnsClicked;
            decreasedSpawnsButton.TooltipText = GetUIText("DecreaseSpawnsText");
            ManipulatorPanel.Append(decreasedSpawnsButton);

            ImageButton noSpawnsButton = new(Common.GetAsset("SpawnModifiers", "Modifier_", (int)UIEnums.SpawnRateManipulators.NoSpawns));
            noSpawnsButton.Left.Set(68f, 0f);
            noSpawnsButton.VAlign = 0.5f;
            noSpawnsButton.Width.Set(34f, 0f);
            noSpawnsButton.Height.Set(34f, 0f);
            noSpawnsButton.OnLeftClick += NoSpawnsClicked;
            noSpawnsButton.TooltipText = GetUIText("DisableSpawnsText");
            ManipulatorPanel.Append(noSpawnsButton);

            ImageButton noEventsButton = new(Common.GetAsset("SpawnModifiers", "Modifier_", (int)UIEnums.SpawnRateManipulators.NoEvents));
            noEventsButton.Left.Set(102f, 0f);
            noEventsButton.VAlign = 0.5f;
            noEventsButton.Width.Set(34f, 0f);
            noEventsButton.Height.Set(34f, 0f);
            noEventsButton.OnLeftClick += NoEventsClicked;
            noEventsButton.TooltipText = GetUIText("DisableEventsText");
            ManipulatorPanel.Append(noEventsButton);

            ImageButton resetButton = new(Common.GetAsset("SpawnModifiers", "Modifier_Reset"));
            resetButton.Left.Set(136f, 0f);
            resetButton.VAlign = 0.5f;
            resetButton.Width.Set(34f, 0f);
            resetButton.Height.Set(34f, 0f);
            resetButton.OnLeftClick += RevertButtonClicked;
            resetButton.TooltipText = GetUIText("ResetText");
            ManipulatorPanel.Append(resetButton);

            ImageButton closeButton = new(Common.GetAsset("SpawnModifiers", "Modifier_Close"));
            closeButton.Left.Set(170f, 0f);
            closeButton.VAlign = 0.5f;
            closeButton.Width.Set(34f, 0f);
            closeButton.Height.Set(34f, 0f);
            closeButton.OnLeftClick += CloseButtonClicked;
            closeButton.TooltipText = Language.GetTextValue("LegacyInterface.52");
            ManipulatorPanel.Append(closeButton);
        }

        private void IncreasedSpawnsClicked(UIMouseEvent evt, UIElement listeningElement) => SpawnChangeClick((int)UIEnums.SpawnRateManipulators.IncreasedSpawns);
        private void DecreasedSpawnsClicked(UIMouseEvent evt, UIElement listeningElement) => SpawnChangeClick((int)UIEnums.SpawnRateManipulators.DecreasedSpawns);
        private void NoSpawnsClicked(UIMouseEvent evt, UIElement listeningElement) => SpawnChangeClick((int)UIEnums.SpawnRateManipulators.NoSpawns);
        private void NoEventsClicked(UIMouseEvent evt, UIElement listeningElement) => SpawnChangeClick((int)UIEnums.SpawnRateManipulators.NoEvents);
        private void RevertButtonClicked(UIMouseEvent evt, UIElement listeningElement) => SpawnChangeClick((int)UIEnums.SpawnRateManipulators.NoSelection);


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
                SoundEngine.PlaySound(SoundID.MenuOpen);
                QoLCPlayer player = QoLCPlayer.Get(Main.LocalPlayer);
                switch (modifier)
                {
                    case 0:
                        player.selectedSpawnRateManipulators[(int)UIEnums.SpawnRateManipulators.IncreasedSpawns] = true;
                        break;
                    case 1:
                        player.selectedSpawnRateManipulators[(int)UIEnums.SpawnRateManipulators.DecreasedSpawns] = true;
                        break;
                    case 2:
                        player.selectedSpawnRateManipulators[(int)UIEnums.SpawnRateManipulators.NoSpawns] = true;
                        break;
                    case 3:
                        player.selectedSpawnRateManipulators[(int)UIEnums.SpawnRateManipulators.NoEvents] = true;
                        break;
                    case 4:
                        for (int i = 0; i < player.selectedSpawnRateManipulators.Length; i++)
                            player.selectedSpawnRateManipulators[i] = false;
                        break;
                    default:
                        for (int i = 0; i < player.selectedSpawnRateManipulators.Length; i++)
                            player.selectedSpawnRateManipulators[i] = false;
                        break;
                }
            }
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Rectangle target = new((int)ManipulatorPanel.GetDimensions().X, (int)ManipulatorPanel.GetDimensions().Y, (int)ManipulatorPanel.GetDimensions().Width, (int)ManipulatorPanel.GetDimensions().Height);
            BackgroundDrawing.DrawBackground(spriteBatch, target, color);
            BackgroundDrawing.DrawBorder(spriteBatch, target, color);
        }
    }
}
