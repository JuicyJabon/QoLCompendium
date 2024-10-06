using QoLCompendium.Core.UI.Buttons;
using static Terraria.ModLoader.ModContent;

namespace QoLCompendium.Core.UI.Panels
{
    public class DestinationGlobeUI : UIState
    {
        public UIPanel GlobePanel;
        public static bool visible = false;

        public override void OnInitialize()
        {
            GlobePanel = new UIPanel();
            GlobePanel.Top.Set(Main.screenHeight / 2 - 30, 0f);
            GlobePanel.Left.Set(Main.screenWidth / 2 + 35, 0f);
            GlobePanel.Width.Set(256f, 0f);
            GlobePanel.Height.Set(128f, 0f);
            GlobePanel.BackgroundColor *= 0f;
            GlobePanel.BorderColor *= 0f;
            Append(GlobePanel);

            BiomeButton.biomeTexture = 0;
            BiomeButton desertSelect = new(Request<Texture2D>("QoLCompendium/Assets/Biomes/Biome_" + BiomeButton.biomeTexture));
            desertSelect.Left.Set(0, 0f);
            desertSelect.Top.Set(0f, 0f);
            desertSelect.Width.Set(32, 0f);
            desertSelect.Height.Set(32, 0f);
            desertSelect.OnLeftClick += DesertClicked;
            desertSelect.Tooltip = UISystem.DesertText;
            GlobePanel.Append(desertSelect);

            BiomeButton.biomeTexture = 1;
            BiomeButton snowSelect = new(Request<Texture2D>("QoLCompendium/Assets/Biomes/Biome_" + BiomeButton.biomeTexture));
            snowSelect.Left.Set(32f, 0f);
            snowSelect.Top.Set(0f, 0f);
            snowSelect.Width.Set(32, 0f);
            snowSelect.Height.Set(32, 0f);
            snowSelect.OnLeftClick += SnowClicked;
            snowSelect.Tooltip = UISystem.SnowText;
            GlobePanel.Append(snowSelect);

            BiomeButton.biomeTexture = 2;
            BiomeButton jungleSelect = new(Request<Texture2D>("QoLCompendium/Assets/Biomes/Biome_" + BiomeButton.biomeTexture));
            jungleSelect.Left.Set(64f, 0f);
            jungleSelect.Top.Set(0f, 0f);
            jungleSelect.Width.Set(32, 0f);
            jungleSelect.Height.Set(32, 0f);
            jungleSelect.OnLeftClick += JungleClicked;
            jungleSelect.Tooltip = UISystem.JungleText;
            GlobePanel.Append(jungleSelect);

            BiomeButton.biomeTexture = 3;
            BiomeButton mushroomSelect = new(Request<Texture2D>("QoLCompendium/Assets/Biomes/Biome_" + BiomeButton.biomeTexture));
            mushroomSelect.Left.Set(96f, 0f);
            mushroomSelect.Top.Set(0f, 0f);
            mushroomSelect.Width.Set(32, 0f);
            mushroomSelect.Height.Set(32, 0f);
            mushroomSelect.OnLeftClick += MushroomClicked;
            mushroomSelect.Tooltip = UISystem.GlowingMushroomText;
            GlobePanel.Append(mushroomSelect);

            BiomeButton.biomeTexture = 4;
            BiomeButton corruptionSelect = new(Request<Texture2D>("QoLCompendium/Assets/Biomes/Biome_" + BiomeButton.biomeTexture));
            corruptionSelect.Left.Set(128f, 0f);
            corruptionSelect.Top.Set(0f, 0f);
            corruptionSelect.Width.Set(32, 0f);
            corruptionSelect.Height.Set(32, 0f);
            corruptionSelect.OnLeftClick += CorruptionClicked;
            corruptionSelect.Tooltip = UISystem.CorruptionText;
            GlobePanel.Append(corruptionSelect);

            BiomeButton.biomeTexture = 5;
            BiomeButton crimsonSelect = new(Request<Texture2D>("QoLCompendium/Assets/Biomes/Biome_" + BiomeButton.biomeTexture));
            crimsonSelect.Left.Set(160f, 0f);
            crimsonSelect.Top.Set(0f, 0f);
            crimsonSelect.Width.Set(32, 0f);
            crimsonSelect.Height.Set(32, 0f);
            crimsonSelect.OnLeftClick += CrimsonClicked;
            crimsonSelect.Tooltip = UISystem.CrimsonText;
            GlobePanel.Append(crimsonSelect);

            BiomeButton.biomeTexture = 6;
            BiomeButton hallowSelect = new(Request<Texture2D>("QoLCompendium/Assets/Biomes/Biome_" + BiomeButton.biomeTexture));
            hallowSelect.Left.Set(192f, 0f);
            hallowSelect.Top.Set(0f, 0f);
            hallowSelect.Width.Set(32f, 0f);
            hallowSelect.Height.Set(32f, 0f);
            hallowSelect.OnLeftClick += HallowClicked;
            hallowSelect.Tooltip = UISystem.HallowText;
            GlobePanel.Append(hallowSelect);

            /*
            BiomeButton.biomeTexture = 7;
            BiomeButton forestSelect = new(Request<Texture2D>("QoLCompendium/Assets/Biomes/Biome_" + BiomeButton.biomeTexture));
            forestSelect.Left.Set(42f, 0f);
            forestSelect.Top.Set(42f, 0f);
            forestSelect.Width.Set(32f, 0f);
            forestSelect.Height.Set(32f, 0f);
            forestSelect.OnLeftClick += new MouseEvent(ForestClicked);
            forestSelect.Tooltip = "Forest";
            GlobePanel.Append(forestSelect);
            */

            GenericUIButton.buttonTexture = 0;
            GenericUIButton resetBiome = new(Request<Texture2D>("QoLCompendium/Assets/UI/UI_" + GenericUIButton.buttonTexture));
            resetBiome.Left.Set(94f, 0f);
            resetBiome.Top.Set(36f, 0f);
            resetBiome.Width.Set(36, 0f);
            resetBiome.Height.Set(36, 0f);
            resetBiome.OnLeftClick += ResetBiomeClicked;
            resetBiome.Tooltip = UISystem.ResetText;
            GlobePanel.Append(resetBiome);
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

        public static void BiomeClick(int biome)
        {
            Main.LocalPlayer.GetModPlayer<QoLCPlayer>().selectedBiome = biome;
            SoundEngine.PlaySound(SoundID.MenuClose);
            visible = false;
        }
    }
}
