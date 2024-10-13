using QoLCompendium.Core.UI.Buttons;

namespace QoLCompendium.Core.UI.Panels
{
    public class PhaseInterrupterUI : UIState
    {
        public UIPanel MoonPanel;
        public static bool visible = false;
        public static uint timeStart;

        public override void OnInitialize()
        {
            MoonPanel = new UIPanel();
            MoonPanel.Top.Set(Main.screenHeight / 2, 0f);
            MoonPanel.Left.Set(Main.screenWidth / 2 - 32, 0f);
            MoonPanel.Width.Set(400f, 0f);
            MoonPanel.Height.Set(400f, 0f);
            MoonPanel.BackgroundColor *= 0f;
            MoonPanel.BorderColor *= 0f;
            Append(MoonPanel);

            MoonPhaseButton.backgroundTexture = 0;
            MoonPhaseButton fullMoon = new(Common.GetAsset("Moons", "Moon_", MoonPhaseButton.moonTexture = 0));
            fullMoon.Left.Set(0f, 0f);
            fullMoon.Top.Set(0f, 0f);
            fullMoon.Width.Set(40f, 0f);
            fullMoon.Height.Set(40f, 0f);
            fullMoon.OnLeftClick += FullMoonClicked;
            fullMoon.Tooltip = UISystem.FullMoonText;
            MoonPanel.Append(fullMoon);

            MoonPhaseButton.backgroundTexture = 1;
            MoonPhaseButton waningGibbous = new(Common.GetAsset("Moons", "Moon_", MoonPhaseButton.moonTexture = 1));
            waningGibbous.Left.Set(40f, 0f);
            waningGibbous.Top.Set(0f, 0f);
            waningGibbous.Width.Set(40f, 0f);
            waningGibbous.Height.Set(40f, 0f);
            waningGibbous.OnLeftClick += WaningGibbousClicked;
            waningGibbous.Tooltip = UISystem.WaningGibbousText;
            MoonPanel.Append(waningGibbous);

            MoonPhaseButton.backgroundTexture = 1;
            MoonPhaseButton thirdQuarter = new(Common.GetAsset("Moons", "Moon_", MoonPhaseButton.moonTexture = 2));
            thirdQuarter.Left.Set(80f, 0f);
            thirdQuarter.Top.Set(0f, 0f);
            thirdQuarter.Width.Set(40f, 0f);
            thirdQuarter.Height.Set(40f, 0f);
            thirdQuarter.OnLeftClick += ThirdQuarterClicked;
            thirdQuarter.Tooltip = UISystem.ThirdQuarterText;
            MoonPanel.Append(thirdQuarter);

            MoonPhaseButton.backgroundTexture = 1;
            MoonPhaseButton waningCrescent = new(Common.GetAsset("Moons", "Moon_", MoonPhaseButton.moonTexture = 3));
            waningCrescent.Left.Set(120f, 0f);
            waningCrescent.Top.Set(0f, 0f);
            waningCrescent.Width.Set(40f, 0f);
            waningCrescent.Height.Set(40f, 0f);
            waningCrescent.OnLeftClick += WaningCrescentClicked;
            waningCrescent.Tooltip = UISystem.WaningCrescentText;
            MoonPanel.Append(waningCrescent);

            MoonPhaseButton.backgroundTexture = 1;
            MoonPhaseButton newMoon = new(Common.GetAsset("Moons", "Moon_", MoonPhaseButton.moonTexture = 4));
            newMoon.Left.Set(160f, 0f);
            newMoon.Top.Set(0f, 0f);
            newMoon.Width.Set(40f, 0f);
            newMoon.Height.Set(40f, 0f);
            newMoon.OnLeftClick += NewMoonClicked;
            newMoon.Tooltip = UISystem.NewMoonText;
            MoonPanel.Append(newMoon);

            MoonPhaseButton.backgroundTexture = 1;
            MoonPhaseButton waxingCrescent = new(Common.GetAsset("Moons", "Moon_", MoonPhaseButton.moonTexture = 5));
            waxingCrescent.Left.Set(200f, 0f);
            waxingCrescent.Top.Set(0f, 0f);
            waxingCrescent.Width.Set(40f, 0f);
            waxingCrescent.Height.Set(40f, 0f);
            waxingCrescent.OnLeftClick += WaxingCrescentClicked;
            waxingCrescent.Tooltip = UISystem.WaxingCrescentText;
            MoonPanel.Append(waxingCrescent);

            MoonPhaseButton.backgroundTexture = 1;
            MoonPhaseButton firstQuarter = new(Common.GetAsset("Moons", "Moon_", MoonPhaseButton.moonTexture = 6));
            firstQuarter.Left.Set(240f, 0f);
            firstQuarter.Top.Set(0f, 0f);
            firstQuarter.Width.Set(40f, 0f);
            firstQuarter.Height.Set(40f, 0f);
            firstQuarter.OnLeftClick += FirstQuarterClicked;
            firstQuarter.Tooltip = UISystem.FirstQuarterText;
            MoonPanel.Append(firstQuarter);

            MoonPhaseButton.backgroundTexture = 1;
            MoonPhaseButton waxingGibbous = new(Common.GetAsset("Moons", "Moon_", MoonPhaseButton.moonTexture = 7));
            waxingGibbous.Left.Set(280f, 0f);
            waxingGibbous.Top.Set(0f, 0f);
            waxingGibbous.Width.Set(40f, 0f);
            waxingGibbous.Height.Set(40f, 0f);
            waxingGibbous.OnLeftClick += WaxingGibbousClicked;
            waxingGibbous.Tooltip = UISystem.WaxingGibbousText;
            MoonPanel.Append(waxingGibbous);

            GenericUIButton.backgroundTexture = 2;
            GenericUIButton closeButton = new(Common.GetAsset("Buttons", "Button_Small_", GenericUIButton.buttonTexture = 3));
            closeButton.Left.Set(320f, 0f);
            closeButton.Top.Set(0f, 0f);
            closeButton.Width.Set(40f, 0f);
            closeButton.Height.Set(40f, 0f);
            closeButton.OnLeftClick += CloseButtonClicked;
            closeButton.Tooltip = UISystem.CloseText;
            MoonPanel.Append(closeButton);
        }

        private void FullMoonClicked(UIMouseEvent evt, UIElement listeningElement) => PhaseClick(0);
        private void WaningGibbousClicked(UIMouseEvent evt, UIElement listeningElement) => PhaseClick(1);
        private void ThirdQuarterClicked(UIMouseEvent evt, UIElement listeningElement) => PhaseClick(2);
        private void WaningCrescentClicked(UIMouseEvent evt, UIElement listeningElement) => PhaseClick(3);
        private void NewMoonClicked(UIMouseEvent evt, UIElement listeningElement) => PhaseClick(4);
        private void WaxingCrescentClicked(UIMouseEvent evt, UIElement listeningElement) => PhaseClick(5);
        private void FirstQuarterClicked(UIMouseEvent evt, UIElement listeningElement) => PhaseClick(6);
        private void WaxingGibbousClicked(UIMouseEvent evt, UIElement listeningElement) => PhaseClick(7);

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
                SoundEngine.PlaySound(SoundID.MenuTick);
            }
        }
    }
}
