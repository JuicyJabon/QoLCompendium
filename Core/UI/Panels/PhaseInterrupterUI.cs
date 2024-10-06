using QoLCompendium.Core.UI.Buttons;
using static Terraria.ModLoader.ModContent;

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
            MoonPanel.Top.Set(Main.screenHeight / 2 - 30, 0f);
            MoonPanel.Left.Set(Main.screenWidth / 2 + 21, 0f);
            MoonPanel.Width.Set(288f, 0f);
            MoonPanel.Height.Set(128f, 0f);
            MoonPanel.BackgroundColor *= 0f;
            MoonPanel.BorderColor *= 0f;
            Append(MoonPanel);

            MoonPhaseButton.moonTexture = 0;
            MoonPhaseButton fullMoon = new(Request<Texture2D>("QoLCompendium/Assets/Moons/Moon_" + MoonPhaseButton.moonTexture));
            fullMoon.Left.Set(0f, 0f);
            fullMoon.Top.Set(0f, 0f);
            fullMoon.Width.Set(32f, 0f);
            fullMoon.Height.Set(32f, 0f);
            fullMoon.OnLeftClick += FullMoonClicked;
            fullMoon.Tooltip = UISystem.FullMoonText;
            MoonPanel.Append(fullMoon);

            MoonPhaseButton.moonTexture = 1;
            MoonPhaseButton waningGibbous = new(Request<Texture2D>("QoLCompendium/Assets/Moons/Moon_" + MoonPhaseButton.moonTexture));
            waningGibbous.Left.Set(32f, 0f);
            waningGibbous.Top.Set(0f, 0f);
            waningGibbous.Width.Set(32f, 0f);
            waningGibbous.Height.Set(32f, 0f);
            waningGibbous.OnLeftClick += WaningGibbousClicked;
            waningGibbous.Tooltip = UISystem.WaningGibbousText;
            MoonPanel.Append(waningGibbous);

            MoonPhaseButton.moonTexture = 2;
            MoonPhaseButton thirdQuarter = new(Request<Texture2D>("QoLCompendium/Assets/Moons/Moon_" + MoonPhaseButton.moonTexture));
            thirdQuarter.Left.Set(64f, 0f);
            thirdQuarter.Top.Set(0f, 0f);
            thirdQuarter.Width.Set(32f, 0f);
            thirdQuarter.Height.Set(32f, 0f);
            thirdQuarter.OnLeftClick += ThirdQuarterClicked;
            thirdQuarter.Tooltip = UISystem.ThirdQuarterText;
            MoonPanel.Append(thirdQuarter);

            MoonPhaseButton.moonTexture = 3;
            MoonPhaseButton waningCrescent = new(Request<Texture2D>("QoLCompendium/Assets/Moons/Moon_" + MoonPhaseButton.moonTexture));
            waningCrescent.Left.Set(96f, 0f);
            waningCrescent.Top.Set(0f, 0f);
            waningCrescent.Width.Set(32f, 0f);
            waningCrescent.Height.Set(32f, 0f);
            waningCrescent.OnLeftClick += WaningCrescentClicked;
            waningCrescent.Tooltip = UISystem.WaningCrescentText;
            MoonPanel.Append(waningCrescent);

            MoonPhaseButton.moonTexture = 4;
            MoonPhaseButton newMoon = new(Request<Texture2D>("QoLCompendium/Assets/Moons/Moon_" + MoonPhaseButton.moonTexture));
            newMoon.Left.Set(128f, 0f);
            newMoon.Top.Set(0f, 0f);
            newMoon.Width.Set(32f, 0f);
            newMoon.Height.Set(32f, 0f);
            newMoon.OnLeftClick += NewMoonClicked;
            newMoon.Tooltip = UISystem.NewMoonText;
            MoonPanel.Append(newMoon);

            MoonPhaseButton.moonTexture = 5;
            MoonPhaseButton waxingCrescent = new(Request<Texture2D>("QoLCompendium/Assets/Moons/Moon_" + MoonPhaseButton.moonTexture));
            waxingCrescent.Left.Set(160f, 0f);
            waxingCrescent.Top.Set(0f, 0f);
            waxingCrescent.Width.Set(32f, 0f);
            waxingCrescent.Height.Set(32f, 0f);
            waxingCrescent.OnLeftClick += WaxingCrescentClicked;
            waxingCrescent.Tooltip = UISystem.WaxingCrescentText;
            MoonPanel.Append(waxingCrescent);

            MoonPhaseButton.moonTexture = 6;
            MoonPhaseButton firstQuarter = new(Request<Texture2D>("QoLCompendium/Assets/Moons/Moon_" + MoonPhaseButton.moonTexture));
            firstQuarter.Left.Set(192f, 0f);
            firstQuarter.Top.Set(0f, 0f);
            firstQuarter.Width.Set(32f, 0f);
            firstQuarter.Height.Set(32f, 0f);
            firstQuarter.OnLeftClick += FirstQuarterClicked;
            firstQuarter.Tooltip = UISystem.FirstQuarterText;
            MoonPanel.Append(firstQuarter);

            MoonPhaseButton.moonTexture = 7;
            MoonPhaseButton waxingGibbous = new(Request<Texture2D>("QoLCompendium/Assets/Moons/Moon_" + MoonPhaseButton.moonTexture));
            waxingGibbous.Left.Set(224f, 0f);
            waxingGibbous.Top.Set(0f, 0f);
            waxingGibbous.Width.Set(32f, 0f);
            waxingGibbous.Height.Set(32f, 0f);
            waxingGibbous.OnLeftClick += WaxingGibbousClicked;
            waxingGibbous.Tooltip = UISystem.WaxingGibbousText;
            MoonPanel.Append(waxingGibbous);

            GenericUIButton.buttonTexture = 0;
            GenericUIButton closeButton = new(Request<Texture2D>("QoLCompendium/Assets/UI/UI_" + GenericUIButton.buttonTexture));
            closeButton.Left.Set(108f, 0f);
            closeButton.Top.Set(36f, 0f);
            closeButton.Width.Set(36f, 0f);
            closeButton.Height.Set(36f, 0f);
            closeButton.OnLeftClick += CloseButtonClicked;
            closeButton.Tooltip = UISystem.CloseText;
            MoonPanel.Append(closeButton);
        }

        private void FullMoonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.moonPhase = 0;
                visible = false;
            }
        }

        private void WaningGibbousClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.moonPhase = 1;
                visible = false;
            }
        }

        private void ThirdQuarterClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.moonPhase = 2;
                visible = false;
            }
        }

        private void WaningCrescentClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.moonPhase = 3;
                visible = false;
            }
        }

        private void NewMoonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.moonPhase = 4;
                visible = false;
            }
        }

        private void WaxingCrescentClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.moonPhase = 5;
                visible = false;
            }
        }

        private void FirstQuarterClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.moonPhase = 6;
                visible = false;
            }
        }

        private void WaxingGibbousClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.moonPhase = 7;
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
