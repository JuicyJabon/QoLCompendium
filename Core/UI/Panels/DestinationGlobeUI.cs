using QoLCompendium.Core.UI.Buttons;

namespace QoLCompendium.Core.UI.Panels
{
    public class DestinationGlobeUI : UIState
    {
        public UIPanel GlobePanel;
        public static bool visible = false;
        public static uint timeStart;

        public override void OnInitialize()
        {
            GlobePanel = new UIPanel();
            GlobePanel.Top.Set(Main.screenHeight / 2, 0f);
            GlobePanel.Left.Set(Main.screenWidth / 2 - 32, 0f);
            GlobePanel.Width.Set(400f, 0f);
            GlobePanel.Height.Set(400f, 0f);
            GlobePanel.BackgroundColor *= 0f;
            GlobePanel.BorderColor *= 0f;
            Append(GlobePanel);

            BiomeButton.backgroundTexture = 0;
            BiomeButton desertSelect = new(Common.GetAsset("Biomes", "Biome_", BiomeButton.biomeTexture = 0));
            desertSelect.Left.Set(0f, 0f);
            desertSelect.Top.Set(0f, 0f);
            desertSelect.Width.Set(40F, 0f);
            desertSelect.Height.Set(40F, 0f);
            desertSelect.OnLeftClick += DesertClicked;
            desertSelect.Tooltip = UISystem.DesertText;
            GlobePanel.Append(desertSelect);

            BiomeButton.backgroundTexture = 1;
            BiomeButton snowSelect = new(Common.GetAsset("Biomes", "Biome_", BiomeButton.biomeTexture = 1));
            snowSelect.Left.Set(40f, 0f);
            snowSelect.Top.Set(0f, 0f);
            snowSelect.Width.Set(40F, 0f);
            snowSelect.Height.Set(40F, 0f);
            snowSelect.OnLeftClick += SnowClicked;
            snowSelect.Tooltip = UISystem.SnowText;
            GlobePanel.Append(snowSelect);

            BiomeButton.backgroundTexture = 1;
            BiomeButton jungleSelect = new(Common.GetAsset("Biomes", "Biome_", BiomeButton.biomeTexture = 2));
            jungleSelect.Left.Set(80f, 0f);
            jungleSelect.Top.Set(0f, 0f);
            jungleSelect.Width.Set(40F, 0f);
            jungleSelect.Height.Set(40F, 0f);
            jungleSelect.OnLeftClick += JungleClicked;
            jungleSelect.Tooltip = UISystem.JungleText;
            GlobePanel.Append(jungleSelect);

            BiomeButton.backgroundTexture = 1;
            BiomeButton mushroomSelect = new(Common.GetAsset("Biomes", "Biome_", BiomeButton.biomeTexture = 3));
            mushroomSelect.Left.Set(120f, 0f);
            mushroomSelect.Top.Set(0f, 0f);
            mushroomSelect.Width.Set(40F, 0f);
            mushroomSelect.Height.Set(40F, 0f);
            mushroomSelect.OnLeftClick += MushroomClicked;
            mushroomSelect.Tooltip = UISystem.GlowingMushroomText;
            GlobePanel.Append(mushroomSelect);

            BiomeButton.backgroundTexture = 1;
            BiomeButton corruptionSelect = new(Common.GetAsset("Biomes", "Biome_", BiomeButton.biomeTexture = 4));
            corruptionSelect.Left.Set(160f, 0f);
            corruptionSelect.Top.Set(0f, 0f);
            corruptionSelect.Width.Set(40F, 0f);
            corruptionSelect.Height.Set(40F, 0f);
            corruptionSelect.OnLeftClick += CorruptionClicked;
            corruptionSelect.Tooltip = UISystem.CorruptionText;
            GlobePanel.Append(corruptionSelect);

            BiomeButton.backgroundTexture = 1;
            BiomeButton crimsonSelect = new(Common.GetAsset("Biomes", "Biome_", BiomeButton.biomeTexture = 5));
            crimsonSelect.Left.Set(200f, 0f);
            crimsonSelect.Top.Set(0f, 0f);
            crimsonSelect.Width.Set(40F, 0f);
            crimsonSelect.Height.Set(40F, 0f);
            crimsonSelect.OnLeftClick += CrimsonClicked;
            crimsonSelect.Tooltip = UISystem.CrimsonText;
            GlobePanel.Append(crimsonSelect);

            BiomeButton.backgroundTexture = 1;
            BiomeButton hallowSelect = new(Common.GetAsset("Biomes", "Biome_", BiomeButton.biomeTexture = 6));
            hallowSelect.Left.Set(240f, 0f);
            hallowSelect.Top.Set(0f, 0f);
            hallowSelect.Width.Set(40F, 0f);
            hallowSelect.Height.Set(40F, 0f);
            hallowSelect.OnLeftClick += HallowClicked;
            hallowSelect.Tooltip = UISystem.HallowText;
            GlobePanel.Append(hallowSelect);

            /*
            BiomeButton.backgroundTexture = 1;
            BiomeButton forestSelect = new(Common.GetAsset("Biomes", "Biome_", BiomeButton.biomeTexture = 7));
            forestSelect.Left.Set(260f, 0f);
            forestSelect.Top.Set(0f, 0f);
            forestSelect.Width.Set(40F, 0f);
            forestSelect.Height.Set(40F, 0f);
            forestSelect.OnLeftClick += ForestClicked;
            forestSelect.Tooltip = "Forest";
            GlobePanel.Append(forestSelect);
            */

            GenericUIButton.backgroundTexture = 1;
            GenericUIButton resetBiome = new(Common.GetAsset("Buttons", "Button_Small_", GenericUIButton.buttonTexture = 2));
            resetBiome.Left.Set(280f, 0f);
            resetBiome.Top.Set(0f, 0f);
            resetBiome.Width.Set(40F, 0f);
            resetBiome.Height.Set(40F, 0f);
            resetBiome.OnLeftClick += ResetBiomeClicked;
            resetBiome.Tooltip = UISystem.ResetText;
            GlobePanel.Append(resetBiome);

            GenericUIButton.backgroundTexture = 2;
            GenericUIButton closeButton = new(Common.GetAsset("Buttons", "Button_Small_", GenericUIButton.buttonTexture = 3));
            closeButton.Left.Set(320f, 0f);
            closeButton.Top.Set(0f, 0f);
            closeButton.Width.Set(40F, 0f);
            closeButton.Height.Set(40F, 0f);
            closeButton.OnLeftClick += CloseButtonClicked;
            closeButton.Tooltip = UISystem.CloseText;
            GlobePanel.Append(closeButton);
        }

        private void ResetBiomeClicked(UIMouseEvent evt, UIElement listeningElement) => BiomeClick(0);
        private void DesertClicked(UIMouseEvent evt, UIElement listeningElement) => BiomeClick(1);
        private void SnowClicked(UIMouseEvent evt, UIElement listeningElement) => BiomeClick(2);
        private void JungleClicked(UIMouseEvent evt, UIElement listeningElement) => BiomeClick(3);
        private void MushroomClicked(UIMouseEvent evt, UIElement listeningElement) => BiomeClick(4);
        private void CorruptionClicked(UIMouseEvent evt, UIElement listeningElement) => BiomeClick(5);
        private void CrimsonClicked(UIMouseEvent evt, UIElement listeningElement) => BiomeClick(6);
        private void HallowClicked(UIMouseEvent evt, UIElement listeningElement) => BiomeClick(7);
        private void ForestClicked(UIMouseEvent evt, UIElement listeningElement) => BiomeClick(8);

        private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                SoundEngine.PlaySound(SoundID.MenuClose);
                visible = false;
            }
        }

        public static void BiomeClick(int biome)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.LocalPlayer.GetModPlayer<QoLCPlayer>().selectedBiome = biome;
                SoundEngine.PlaySound(SoundID.MenuTick);
            }
        }
    }
}
