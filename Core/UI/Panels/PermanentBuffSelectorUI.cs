using QoLCompendium.Core.UI.Buttons;

namespace QoLCompendium.Core.UI.Panels
{
    public class PermanentBuffSelectorUI : UIState
    {
        public UIPanel SelectorPanel;
        public static bool visible = false;
        public static uint timeStart;

        PermanentUpgradedBuffButton VanillaButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentEverything"));
        PermanentUpgradedBuffButton CalamityButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentCalamity"));
        PermanentUpgradedBuffButton MartinsOrderButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentMartinsOrder"));
        PermanentUpgradedBuffButton SpiritButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentSpiritClassic"));
        PermanentUpgradedBuffButton ThoriumButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentThorium"));

        public override void OnInitialize()
        {
            SelectorPanel = new UIPanel();
            SelectorPanel.SetPadding(0);
            SelectorPanel.Top.Set(Main.screenHeight / 2, 0f);
            SelectorPanel.Left.Set(Main.screenWidth / 2 + 35f, 0f);
            SelectorPanel.Width.Set(256f, 0f);
            SelectorPanel.Height.Set(64f, 0f);
            SelectorPanel.BackgroundColor = new Color(73, 94, 171);

            //Vanilla
            CreateBuffButton(VanillaButton, 16f, 16f);
            VanillaButton.OnLeftClick += VanillaClicked;
            VanillaButton.Tooltip = UISystem.VanillaText;
            SelectorPanel.Append(VanillaButton);

            //Calamity
            CreateBuffButton(CalamityButton, 64f, 16f);
            CalamityButton.OnLeftClick += CalamityClicked;
            CalamityButton.Tooltip = UISystem.CalamityText;
            SelectorPanel.Append(CalamityButton);

            //Martin's Order
            CreateBuffButton(MartinsOrderButton, 112f, 16f);
            MartinsOrderButton.OnLeftClick += MartinsOrderClicked;
            MartinsOrderButton.Tooltip = UISystem.MartinsOrderText;
            SelectorPanel.Append(MartinsOrderButton);

            //Spirit Classic
            CreateBuffButton(SpiritButton, 160f, 16f);
            SpiritButton.OnLeftClick += SpiritClicked;
            SpiritButton.Tooltip = UISystem.SpiritClassicText;
            SelectorPanel.Append(SpiritButton);

            //Thorium
            CreateBuffButton(ThoriumButton, 208f, 16f);
            ThoriumButton.OnLeftClick += ThoriumClicked;
            ThoriumButton.Tooltip = UISystem.ThoriumText;
            SelectorPanel.Append(ThoriumButton);

            Append(SelectorPanel);
        }

        private void VanillaClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick(0);
        private void CalamityClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick(1);
        private void MartinsOrderClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick(2);
        private void SpiritClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick(3);
        private void ThoriumClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick(4);

        public static void BuffClick(int ui)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                SoundEngine.PlaySound(SoundID.MenuOpen, Main.LocalPlayer.position, null);
                
                if (ui == 0) // Vanilla
                {
                    PermanentBuffUI.timeStart = Main.GameUpdateCount;
                    PermanentBuffUI.visible = !PermanentBuffUI.visible;
                }
                else if (ui == 1 && ModConditions.calamityLoaded) // Calamity
                {
                    PermanentCalamityBuffUI.timeStart = Main.GameUpdateCount;
                    PermanentCalamityBuffUI.visible = !PermanentCalamityBuffUI.visible;
                }
                else if (ui == 2 && ModConditions.martainsOrderLoaded) // Martin's Order
                {
                    PermanentMartinsOrderBuffUI.timeStart = Main.GameUpdateCount;
                    PermanentMartinsOrderBuffUI.visible = !PermanentMartinsOrderBuffUI.visible;
                }
                else if (ui == 3 && ModConditions.spiritLoaded) // Spirit
                {
                    PermanentSpiritClassicBuffUI.timeStart = Main.GameUpdateCount;
                    PermanentSpiritClassicBuffUI.visible = !PermanentSpiritClassicBuffUI.visible;
                }
                else if (ui == 4 && ModConditions.thoriumLoaded) // Thorium
                {
                    PermanentThoriumBuffUI.timeStart = Main.GameUpdateCount;
                    PermanentThoriumBuffUI.visible = !PermanentThoriumBuffUI.visible;
                }
            }
        }

        private static void CreateBuffButton(PermanentUpgradedBuffButton button, float left, float top)
        {
            button.Left.Set(left, 0f);
            button.Top.Set(top, 0f);
            button.Width.Set(32f, 0f);
            button.Height.Set(32f, 0f);
        }
    }
}
