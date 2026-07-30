using QoLCompendium.Core.UI.Buttons;

namespace QoLCompendium.Core.UI.Panels
{
    public class DestinationGlobeUI : UIState
    {
        public UIPanel GlobePanel;
        public static bool visible = false;
        public static uint timeStart;
        public Color color = new(35, 130, 78);

        internal static string GetUIText(string key, string category = "DestinationGlobeUI") => QoLCUISystem.GetUIText(category, key);

        public override void OnInitialize()
        {
            GlobePanel = new();
            GlobePanel.SetPadding(0);
            GlobePanel.HAlign = 0.628f;
            GlobePanel.VAlign = 0.53f;
            GlobePanel.Width.Set(360f, 0f);
            GlobePanel.Height.Set(40f, 0f);
            GlobePanel.BackgroundColor *= 0f;
            GlobePanel.BorderColor *= 0f;
            Append(GlobePanel);

            ImageButton desertSelect = new(Common.GetAsset("Biomes", "Biome_", (int)UIEnums.BiomeTypes.Desert));
            desertSelect.Left.Set(0f, 0f);
            desertSelect.VAlign = 0.5f;
            desertSelect.Width.Set(40F, 0f);
            desertSelect.Height.Set(40F, 0f);
            desertSelect.OnLeftClick += DesertClicked;
            desertSelect.TooltipText = GetUIText("DesertText");
            GlobePanel.Append(desertSelect);

            ImageButton snowSelect = new(Common.GetAsset("Biomes", "Biome_", (int)UIEnums.BiomeTypes.Snow));
            snowSelect.Left.Set(40f, 0f);
            snowSelect.VAlign = 0.5f;
            snowSelect.Width.Set(40F, 0f);
            snowSelect.Height.Set(40F, 0f);
            snowSelect.OnLeftClick += SnowClicked;
            snowSelect.TooltipText = GetUIText("SnowText");
            GlobePanel.Append(snowSelect);

            ImageButton jungleSelect = new(Common.GetAsset("Biomes", "Biome_", (int)UIEnums.BiomeTypes.Jungle));
            jungleSelect.Left.Set(80f, 0f);
            jungleSelect.VAlign = 0.5f;
            jungleSelect.Width.Set(40F, 0f);
            jungleSelect.Height.Set(40F, 0f);
            jungleSelect.OnLeftClick += JungleClicked;
            jungleSelect.TooltipText = GetUIText("JungleText");
            GlobePanel.Append(jungleSelect);

            ImageButton mushroomSelect = new(Common.GetAsset("Biomes", "Biome_", (int)UIEnums.BiomeTypes.Glowshroom));
            mushroomSelect.Left.Set(120f, 0f);
            mushroomSelect.VAlign = 0.5f;
            mushroomSelect.Width.Set(40F, 0f);
            mushroomSelect.Height.Set(40F, 0f);
            mushroomSelect.OnLeftClick += MushroomClicked;
            mushroomSelect.TooltipText = GetUIText("GlowingMushroomText");
            GlobePanel.Append(mushroomSelect);

            ImageButton corruptionSelect = new(Common.GetAsset("Biomes", "Biome_", (int)UIEnums.BiomeTypes.Corruption));
            corruptionSelect.Left.Set(160f, 0f);
            corruptionSelect.VAlign = 0.5f;
            corruptionSelect.Width.Set(40F, 0f);
            corruptionSelect.Height.Set(40F, 0f);
            corruptionSelect.OnLeftClick += CorruptionClicked;
            corruptionSelect.TooltipText = GetUIText("CorruptionText");
            GlobePanel.Append(corruptionSelect);

            ImageButton crimsonSelect = new(Common.GetAsset("Biomes", "Biome_", (int)UIEnums.BiomeTypes.Crimson));
            crimsonSelect.Left.Set(200f, 0f);
            crimsonSelect.VAlign = 0.5f;
            crimsonSelect.Width.Set(40F, 0f);
            crimsonSelect.Height.Set(40F, 0f);
            crimsonSelect.OnLeftClick += CrimsonClicked;
            crimsonSelect.TooltipText = GetUIText("CrimsonText");
            GlobePanel.Append(crimsonSelect);

            ImageButton hallowSelect = new(Common.GetAsset("Biomes", "Biome_", (int)UIEnums.BiomeTypes.Hallow));
            hallowSelect.Left.Set(240f, 0f);
            hallowSelect.VAlign = 0.5f;
            hallowSelect.Width.Set(40F, 0f);
            hallowSelect.Height.Set(40F, 0f);
            hallowSelect.OnLeftClick += HallowClicked;
            hallowSelect.TooltipText = GetUIText("HallowText");
            GlobePanel.Append(hallowSelect);

            ImageButton resetBiome = new(Common.GetAsset("Buttons", "Button_Small_", 2));
            resetBiome.Left.Set(280f, 0f);
            resetBiome.VAlign = 0.5f;
            resetBiome.Width.Set(40F, 0f);
            resetBiome.Height.Set(40F, 0f);
            resetBiome.OnLeftClick += ResetBiomeClicked;
            resetBiome.TooltipText = GetUIText("ResetText");
            GlobePanel.Append(resetBiome);

            ImageButton closeButton = new(Common.GetAsset("Buttons", "Button_Small_", 3));
            closeButton.Left.Set(320f, 0f);
            closeButton.VAlign = 0.5f;
            closeButton.Width.Set(40F, 0f);
            closeButton.Height.Set(40F, 0f);
            closeButton.OnLeftClick += CloseButtonClicked;
            closeButton.TooltipText = Language.GetTextValue("LegacyInterface.52");
            GlobePanel.Append(closeButton);
        }

        private void PurityClicked(UIMouseEvent evt, UIElement listeningElement) => BiomeClick((int)UIEnums.BiomeTypes.Purity);
        private void DesertClicked(UIMouseEvent evt, UIElement listeningElement) => BiomeClick((int)UIEnums.BiomeTypes.Desert);
        private void SnowClicked(UIMouseEvent evt, UIElement listeningElement) => BiomeClick((int)UIEnums.BiomeTypes.Snow);
        private void JungleClicked(UIMouseEvent evt, UIElement listeningElement) => BiomeClick((int)UIEnums.BiomeTypes.Jungle);
        private void MushroomClicked(UIMouseEvent evt, UIElement listeningElement) => BiomeClick((int)UIEnums.BiomeTypes.Glowshroom);
        private void CorruptionClicked(UIMouseEvent evt, UIElement listeningElement) => BiomeClick((int)UIEnums.BiomeTypes.Corruption);
        private void CrimsonClicked(UIMouseEvent evt, UIElement listeningElement) => BiomeClick((int)UIEnums.BiomeTypes.Crimson);
        private void HallowClicked(UIMouseEvent evt, UIElement listeningElement) => BiomeClick((int)UIEnums.BiomeTypes.Hallow);
        private void ResetBiomeClicked(UIMouseEvent evt, UIElement listeningElement) => BiomeClick((int)UIEnums.BiomeTypes.NoSelection);

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
                QoLCPlayer player = QoLCPlayer.Get(Main.LocalPlayer);
                switch (biome)
                {
                    case 0:
                        player.selectedBiomes[(int)UIEnums.BiomeTypes.Purity] = true;
                        break;
                    case 1:
                        player.selectedBiomes[(int)UIEnums.BiomeTypes.Desert] = true;
                        break;
                    case 2:
                        player.selectedBiomes[(int)UIEnums.BiomeTypes.Snow] = true;
                        break;
                    case 3:
                        player.selectedBiomes[(int)UIEnums.BiomeTypes.Jungle] = true;
                        break;
                    case 4:
                        player.selectedBiomes[(int)UIEnums.BiomeTypes.Glowshroom] = true;
                        break;
                    case 5:
                        player.selectedBiomes[(int)UIEnums.BiomeTypes.Corruption] = true;
                        break;
                    case 6:
                        player.selectedBiomes[(int)UIEnums.BiomeTypes.Crimson] = true;
                        break;
                    case 7:
                        player.selectedBiomes[(int)UIEnums.BiomeTypes.Hallow] = true;
                        break;
                    case 8:
                        for (int i = 0; i < player.selectedBiomes.Length; i++)
                            player.selectedBiomes[i] = false;
                        break;
                    default:
                        for (int i = 0; i < player.selectedBiomes.Length; i++)
                            player.selectedBiomes[i] = false;
                        break;
                }
                SoundEngine.PlaySound(SoundID.MenuTick);
            }
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Rectangle target = new((int)GlobePanel.GetDimensions().X, (int)GlobePanel.GetDimensions().Y, (int)GlobePanel.GetDimensions().Width, (int)GlobePanel.GetDimensions().Height);
            BackgroundDrawing.DrawBackground(spriteBatch, target, color);
            BackgroundDrawing.DrawBorder(spriteBatch, target, color);
        }
    }
}
