using QoLCompendium.Core.UI.Buttons;

namespace QoLCompendium.Core.UI.Panels
{
    public class PhaseInterrupterUI : UIState
    {
        public UIPanel MoonPanel;
        public static bool visible = false;
        public static uint timeStart;
        public Color color = new(64, 70, 74);

        public override void OnInitialize()
        {
            MoonPanel = new();
            MoonPanel.SetPadding(0);
            MoonPanel.HAlign = 0.628f;
            MoonPanel.VAlign = 0.53f;
            MoonPanel.Width.Set(360f, 0f);
            MoonPanel.Height.Set(42f, 0f);
            MoonPanel.BackgroundColor *= 0f;
            MoonPanel.BorderColor *= 0f;
            Append(MoonPanel);

            ImageButton fullMoon = new(Common.GetAsset("Moons", "Moon_", (int)UIEnums.MoonPhases.Full));
            fullMoon.Left.Set(0f, 0f);
            fullMoon.VAlign = 0.5f;
            fullMoon.Width.Set(40f, 0f);
            fullMoon.Height.Set(40f, 0f);
            fullMoon.OnLeftClick += FullMoonClicked;
            fullMoon.TooltipText = Language.GetTextValue("GameUI.FullMoon");
            MoonPanel.Append(fullMoon);

            ImageButton waningGibbous = new(Common.GetAsset("Moons", "Moon_", (int)UIEnums.MoonPhases.WaningGibbous));
            waningGibbous.Left.Set(40f, 0f);
            waningGibbous.VAlign = 0.5f;
            waningGibbous.Width.Set(40f, 0f);
            waningGibbous.Height.Set(40f, 0f);
            waningGibbous.OnLeftClick += WaningGibbousClicked;
            waningGibbous.TooltipText = Language.GetTextValue("GameUI.WaningGibbous");
            MoonPanel.Append(waningGibbous);

            ImageButton thirdQuarter = new(Common.GetAsset("Moons", "Moon_", (int)UIEnums.MoonPhases.ThirdQuarter));
            thirdQuarter.Left.Set(80f, 0f);
            thirdQuarter.VAlign = 0.5f;
            thirdQuarter.Width.Set(40f, 0f);
            thirdQuarter.Height.Set(40f, 0f);
            thirdQuarter.OnLeftClick += ThirdQuarterClicked;
            thirdQuarter.TooltipText = Language.GetTextValue("GameUI.ThirdQuarter");
            MoonPanel.Append(thirdQuarter);

            ImageButton waningCrescent = new(Common.GetAsset("Moons", "Moon_", (int)UIEnums.MoonPhases.WaningCrescent));
            waningCrescent.Left.Set(120f, 0f);
            waningCrescent.VAlign = 0.5f;
            waningCrescent.Width.Set(40f, 0f);
            waningCrescent.Height.Set(40f, 0f);
            waningCrescent.OnLeftClick += WaningCrescentClicked;
            waningCrescent.TooltipText = Language.GetTextValue("GameUI.WaningCrescent");
            MoonPanel.Append(waningCrescent);

            ImageButton newMoon = new(Common.GetAsset("Moons", "Moon_", (int)UIEnums.MoonPhases.New));
            newMoon.Left.Set(160f, 0f);
            newMoon.VAlign = 0.5f;
            newMoon.Width.Set(40f, 0f);
            newMoon.Height.Set(40f, 0f);
            newMoon.OnLeftClick += NewMoonClicked;
            newMoon.TooltipText = Language.GetTextValue("GameUI.NewMoon");
            MoonPanel.Append(newMoon);

            ImageButton waxingCrescent = new(Common.GetAsset("Moons", "Moon_", (int)UIEnums.MoonPhases.WaxingCrescent));
            waxingCrescent.Left.Set(200f, 0f);
            waxingCrescent.VAlign = 0.5f;
            waxingCrescent.Width.Set(40f, 0f);
            waxingCrescent.Height.Set(40f, 0f);
            waxingCrescent.OnLeftClick += WaxingCrescentClicked;
            waxingCrescent.TooltipText = Language.GetTextValue("GameUI.WaxingCrescent");
            MoonPanel.Append(waxingCrescent);

            ImageButton firstQuarter = new(Common.GetAsset("Moons", "Moon_", (int)UIEnums.MoonPhases.FirstQuarter));
            firstQuarter.Left.Set(240f, 0f);
            firstQuarter.VAlign = 0.5f;
            firstQuarter.Width.Set(40f, 0f);
            firstQuarter.Height.Set(40f, 0f);
            firstQuarter.OnLeftClick += FirstQuarterClicked;
            firstQuarter.TooltipText = Language.GetTextValue("GameUI.FirstQuarter");
            MoonPanel.Append(firstQuarter);

            ImageButton waxingGibbous = new(Common.GetAsset("Moons", "Moon_", (int)UIEnums.MoonPhases.WaxingGibbous));
            waxingGibbous.Left.Set(280f, 0f);
            waxingGibbous.VAlign = 0.5f;
            waxingGibbous.Width.Set(40f, 0f);
            waxingGibbous.Height.Set(40f, 0f);
            waxingGibbous.OnLeftClick += WaxingGibbousClicked;
            waxingGibbous.TooltipText = Language.GetTextValue("GameUI.WaxingGibbous");
            MoonPanel.Append(waxingGibbous);

            ImageButton closeButton = new(Common.GetAsset("Buttons", "Button_Small_", 3));
            closeButton.Left.Set(320f, 0f);
            closeButton.VAlign = 0.5f;
            closeButton.Width.Set(40f, 0f);
            closeButton.Height.Set(40f, 0f);
            closeButton.OnLeftClick += CloseButtonClicked;
            closeButton.TooltipText = Language.GetTextValue("LegacyInterface.52");
            MoonPanel.Append(closeButton);
        }

        private void FullMoonClicked(UIMouseEvent evt, UIElement listeningElement) => PhaseClick((int)UIEnums.MoonPhases.Full);
        private void WaningGibbousClicked(UIMouseEvent evt, UIElement listeningElement) => PhaseClick((int)UIEnums.MoonPhases.WaningGibbous);
        private void ThirdQuarterClicked(UIMouseEvent evt, UIElement listeningElement) => PhaseClick((int)UIEnums.MoonPhases.ThirdQuarter);
        private void WaningCrescentClicked(UIMouseEvent evt, UIElement listeningElement) => PhaseClick((int)UIEnums.MoonPhases.WaningCrescent);
        private void NewMoonClicked(UIMouseEvent evt, UIElement listeningElement) => PhaseClick((int)UIEnums.MoonPhases.New);
        private void WaxingCrescentClicked(UIMouseEvent evt, UIElement listeningElement) => PhaseClick((int)UIEnums.MoonPhases.WaxingCrescent);
        private void FirstQuarterClicked(UIMouseEvent evt, UIElement listeningElement) => PhaseClick((int)UIEnums.MoonPhases.FirstQuarter);
        private void WaxingGibbousClicked(UIMouseEvent evt, UIElement listeningElement) => PhaseClick((int)UIEnums.MoonPhases.WaxingGibbous);

        private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                SoundEngine.PlaySound(SoundID.MenuClose);
                visible = false;
            }
        }

        public static void PhaseClick(int phase)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.moonPhase = phase;
                SoundEngine.PlaySound(SoundID.Item4);
            }
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Rectangle target = new((int)MoonPanel.GetDimensions().X, (int)MoonPanel.GetDimensions().Y, (int)MoonPanel.GetDimensions().Width, (int)MoonPanel.GetDimensions().Height);
            BackgroundDrawing.DrawBackground(spriteBatch, target, color);
            BackgroundDrawing.DrawBorder(spriteBatch, target, color);
        }
    }
}
