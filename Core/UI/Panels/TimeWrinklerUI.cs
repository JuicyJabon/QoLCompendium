using QoLCompendium.Core.UI.Buttons;

namespace QoLCompendium.Core.UI.Panels
{
    public class TimeWrinklerUI : UIState
    {
        public UIPanel MainPanel;
        public static bool visible = false;
        public static uint timeStart;
        public Color color = new(232, 178, 60);

        internal static string GetUIText(string key, string category = "TimeWrinklerUI") => QoLCUISystem.GetUIText(category, key);

        public override void OnInitialize()
        {
            MainPanel = new();
            MainPanel.SetPadding(0);
            MainPanel.HAlign = 0.615f;
            MainPanel.VAlign = 0.53f;
            MainPanel.Width.Set(210f, 0f);
            MainPanel.Height.Set(35f, 0f);
            MainPanel.BackgroundColor *= 0f;
            MainPanel.BorderColor *= 0f;
            Append(MainPanel);

            ImageButton alwaysDay = new(Common.GetAsset("TimeManipulators", "TimeWrinkler_", (int)UIEnums.TimeManipulators.AlwaysDay));
            alwaysDay.Left.Set(0f, 0f);
            alwaysDay.VAlign = 0.5f;
            alwaysDay.SetSize(new Vector2(30f ,30f));
            alwaysDay.OnLeftClick += AlwaysDayClicked;
            alwaysDay.TooltipText = GetUIText("AlwaysDay");
            MainPanel.Append(alwaysDay);

            ImageButton alwaysNight = new(Common.GetAsset("TimeManipulators", "TimeWrinkler_", (int)UIEnums.TimeManipulators.AlwaysNight));
            alwaysNight.Left.Set(30f, 0f);
            alwaysNight.VAlign = 0.5f;
            alwaysNight.SetSize(new Vector2(30f, 30f));
            alwaysNight.OnLeftClick += AlwaysNightClicked;
            alwaysNight.TooltipText = GetUIText("AlwaysNight");
            MainPanel.Append(alwaysNight);

            ImageButton alwaysBloodMoon = new(Common.GetAsset("TimeManipulators", "TimeWrinkler_", (int)UIEnums.TimeManipulators.AlwaysBloodMoon));
            alwaysBloodMoon.Left.Set(60f, 0f);
            alwaysBloodMoon.VAlign = 0.5f;
            alwaysBloodMoon.SetSize(new Vector2(30f, 30f));
            alwaysBloodMoon.OnLeftClick += AlwaysBloodMoonClicked;
            alwaysBloodMoon.TooltipText = GetUIText("AlwaysBloodMoon");
            MainPanel.Append(alwaysBloodMoon);

            ImageButton alwaysEclipse = new(Common.GetAsset("TimeManipulators", "TimeWrinkler_", (int)UIEnums.TimeManipulators.AlwaysEclipse));
            alwaysEclipse.Left.Set(90f, 0f);
            alwaysEclipse.VAlign = 0.5f;
            alwaysEclipse.SetSize(new Vector2(30f, 30f));
            alwaysEclipse.OnLeftClick += AlwaysEclipseClicked;
            alwaysEclipse.TooltipText = GetUIText("AlwaysEclipse");
            MainPanel.Append(alwaysEclipse);

            ImageButton timePaused = new(Common.GetAsset("TimeManipulators", "TimeWrinkler_", (int)UIEnums.TimeManipulators.TimePaused));
            timePaused.Left.Set(120f, 0f);
            timePaused.VAlign = 0.5f;
            timePaused.SetSize(new Vector2(30f, 30f));
            timePaused.OnLeftClick += TimePausedClicked;
            timePaused.TooltipText = GetUIText("TimePaused");
            MainPanel.Append(timePaused);

            ImageButton resetButton = new(Common.GetAsset("Buttons", "Button_Small_", 0));
            resetButton.Left.Set(150f, 0f);
            resetButton.VAlign = 0.5f;
            resetButton.SetSize(new Vector2(30f, 30f));
            resetButton.OnLeftClick += NoSelectionClicked;
            resetButton.TooltipText = GetUIText("ResetText");
            MainPanel.Append(resetButton);

            ImageButton closeButton = new(Common.GetAsset("TimeManipulators", "TimeWrinkler_Close"));
            closeButton.Left.Set(180f, 0f);
            closeButton.VAlign = 0.5f;
            closeButton.SetSize(new Vector2(30f, 30f));
            closeButton.OnLeftClick += CloseButtonClicked;
            closeButton.TooltipText = Language.GetTextValue("LegacyInterface.52");
            MainPanel.Append(closeButton);
        }

        private void AlwaysDayClicked(UIMouseEvent evt, UIElement listeningElement) => TimeClick((int)UIEnums.TimeManipulators.AlwaysDay);
        private void AlwaysNightClicked(UIMouseEvent evt, UIElement listeningElement) => TimeClick((int)UIEnums.TimeManipulators.AlwaysNight);
        private void AlwaysBloodMoonClicked(UIMouseEvent evt, UIElement listeningElement) => TimeClick((int)UIEnums.TimeManipulators.AlwaysBloodMoon);
        private void AlwaysEclipseClicked(UIMouseEvent evt, UIElement listeningElement) => TimeClick((int)UIEnums.TimeManipulators.AlwaysEclipse);
        private void TimePausedClicked(UIMouseEvent evt, UIElement listeningElement) => TimeClick((int)UIEnums.TimeManipulators.TimePaused);
        private void NoSelectionClicked(UIMouseEvent evt, UIElement listeningElement) => TimeClick((int)UIEnums.TimeManipulators.NoSelection);

        private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                SoundEngine.PlaySound(SoundID.MenuClose);
                visible = false;
            }
        }

        public static void TimeClick(int time)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                SoundEngine.PlaySound(SoundID.MenuOpen);
                QoLCPlayer player = QoLCPlayer.Get(Main.LocalPlayer);
                switch (time)
                {
                    case 0:
                        player.selectedTimeManipulators[(int)UIEnums.TimeManipulators.AlwaysDay] = true;
                        break;
                    case 1:
                        player.selectedTimeManipulators[(int)UIEnums.TimeManipulators.AlwaysNight] = true;
                        break;
                    case 2:
                        player.selectedTimeManipulators[(int)UIEnums.TimeManipulators.AlwaysBloodMoon] = true;
                        break;
                    case 3:
                        player.selectedTimeManipulators[(int)UIEnums.TimeManipulators.AlwaysEclipse] = true;
                        break;
                    case 4:
                        player.selectedTimeManipulators[(int)UIEnums.TimeManipulators.TimePaused] = true;
                        break;
                    case 5:
                        for (int i = 0; i < player.selectedTimeManipulators.Length; i++)
                            player.selectedTimeManipulators[i] = false;
                        break;
                    default:
                        for (int i = 0; i < player.selectedTimeManipulators.Length; i++)
                            player.selectedTimeManipulators[i] = false;
                        break;
                }
            }
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Rectangle target = new((int)MainPanel.GetDimensions().X, (int)MainPanel.GetDimensions().Y, (int)MainPanel.GetDimensions().Width, (int)MainPanel.GetDimensions().Height);
            BackgroundDrawing.DrawBackground(spriteBatch, target, color);
            BackgroundDrawing.DrawBorder(spriteBatch, target, color);
        }
    }
}
