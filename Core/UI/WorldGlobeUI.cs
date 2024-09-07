using static Terraria.ModLoader.ModContent;

namespace QoLCompendium.Core.UI
{
    class WorldGlobeUI : UIState
    {
        public UIPanel GlobePanel;
        public static bool visible = false;

        public override void OnInitialize()
        {
            GlobePanel = new UIPanel();
            GlobePanel.Left.Set(575f, 0f);
            GlobePanel.Top.Set(300f, 0f);
            GlobePanel.Width.Set(132f, 0f);
            GlobePanel.Height.Set(132f, 0f);
            GlobePanel.BackgroundColor = new Color(50, 168, 82);

            UIImageButton resetBiome = new(Request<Texture2D>("QoLCompendium/Assets/UI/Cancel"));
            resetBiome.Left.Set(36f, 0f);
            resetBiome.Top.Set(0f, 0f);
            resetBiome.Width.Set(32, 0f);
            resetBiome.Height.Set(32, 0f);
            resetBiome.OnLeftClick += new MouseEvent(ResetBiomeClicked);
            GlobePanel.Append(resetBiome);

            UIImageButton desertSelect = new(Request<Texture2D>("QoLCompendium/Assets/Biomes/Desert"));
            desertSelect.Left.Set(0, 0f);
            desertSelect.Top.Set(0f, 0f);
            desertSelect.Width.Set(32, 0f);
            desertSelect.Height.Set(32, 0f);
            desertSelect.OnLeftClick += new MouseEvent(DesertClicked);
            GlobePanel.Append(desertSelect);

            UIImageButton iceSelect = new(Request<Texture2D>("QoLCompendium/Assets/Biomes/Ice"));
            iceSelect.Left.Set(0f, 0f);
            iceSelect.Top.Set(42f, 0f);
            iceSelect.Width.Set(32, 0f);
            iceSelect.Height.Set(32, 0f);
            iceSelect.OnLeftClick += new MouseEvent(IceClicked);
            GlobePanel.Append(iceSelect);

            UIImageButton jungleSelect = new(Request<Texture2D>("QoLCompendium/Assets/Biomes/Jungle"));
            jungleSelect.Left.Set(0f, 0f);
            jungleSelect.Top.Set(84f, 0f);
            jungleSelect.Width.Set(32, 0f);
            jungleSelect.Height.Set(32, 0f);
            jungleSelect.OnLeftClick += new MouseEvent(JungleClicked);
            GlobePanel.Append(jungleSelect);

            UIImageButton mushroomSelect = new(Request<Texture2D>("QoLCompendium/Assets/Biomes/GlowingMushroom"));
            mushroomSelect.Left.Set(84f, 0f);
            mushroomSelect.Top.Set(0f, 0f);
            mushroomSelect.Width.Set(32, 0f);
            mushroomSelect.Height.Set(32, 0f);
            mushroomSelect.OnLeftClick += new MouseEvent(MushroomClicked);
            GlobePanel.Append(mushroomSelect);

            UIImageButton corruptionSelect = new(Request<Texture2D>("QoLCompendium/Assets/Biomes/Corruption"));
            corruptionSelect.Left.Set(42f, 0f);
            corruptionSelect.Top.Set(84f, 0f);
            corruptionSelect.Width.Set(32, 0f);
            corruptionSelect.Height.Set(32, 0f);
            corruptionSelect.OnLeftClick += new MouseEvent(CorruptionClicked);
            GlobePanel.Append(corruptionSelect);

            UIImageButton crimsonSelect = new(Request<Texture2D>("QoLCompendium/Assets/Biomes/Crimson"));
            crimsonSelect.Left.Set(84f, 0f);
            crimsonSelect.Top.Set(42f, 0f);
            crimsonSelect.Width.Set(32, 0f);
            crimsonSelect.Height.Set(32, 0f);
            crimsonSelect.OnLeftClick += new MouseEvent(CrimsonClicked);
            GlobePanel.Append(crimsonSelect);

            UIImageButton hallowSelect = new(Request<Texture2D>("QoLCompendium/Assets/Biomes/Hallow"));
            hallowSelect.Left.Set(84f, 0f);
            hallowSelect.Top.Set(84f, 0f);
            hallowSelect.Width.Set(32f, 0f);
            hallowSelect.Height.Set(32f, 0f);
            hallowSelect.OnLeftClick += new MouseEvent(HallowClicked);
            GlobePanel.Append(hallowSelect);

            UIImageButton forestSelect = new(Request<Texture2D>("QoLCompendium/Assets/Biomes/Forest"));
            forestSelect.Left.Set(42f, 0f);
            forestSelect.Top.Set(42f, 0f);
            forestSelect.Width.Set(32f, 0f);
            forestSelect.Height.Set(32f, 0f);
            forestSelect.OnLeftClick += new MouseEvent(ForestClicked);
            GlobePanel.Append(forestSelect);

            Append(GlobePanel);
        }

        private void ResetBiomeClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            Player p = Main.LocalPlayer;
            p.GetModPlayer<QoLCPlayer>().selectedBiome = 0;
            SoundEngine.PlaySound(SoundID.MenuClose);
            visible = false;
        }

        private void DesertClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            Player p = Main.LocalPlayer;
            p.GetModPlayer<QoLCPlayer>().selectedBiome = 1;
            SoundEngine.PlaySound(SoundID.MenuClose);
            visible = false;
        }

        private void IceClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            Player p = Main.LocalPlayer;
            p.GetModPlayer<QoLCPlayer>().selectedBiome = 2;
            SoundEngine.PlaySound(SoundID.MenuClose);
            visible = false;
        }

        private void JungleClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            Player p = Main.LocalPlayer;
            p.GetModPlayer<QoLCPlayer>().selectedBiome = 3;
            SoundEngine.PlaySound(SoundID.MenuClose);
            visible = false;
        }

        private void MushroomClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            Player p = Main.LocalPlayer;
            p.GetModPlayer<QoLCPlayer>().selectedBiome = 4;
            SoundEngine.PlaySound(SoundID.MenuClose);
            visible = false;
        }

        private void CorruptionClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            Player p = Main.LocalPlayer;
            p.GetModPlayer<QoLCPlayer>().selectedBiome = 5;
            SoundEngine.PlaySound(SoundID.MenuClose);
            visible = false;
        }

        private void CrimsonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            Player p = Main.LocalPlayer;
            p.GetModPlayer<QoLCPlayer>().selectedBiome = 6;
            SoundEngine.PlaySound(SoundID.MenuClose);
            visible = false;
        }

        private void HallowClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            Player p = Main.LocalPlayer;
            p.GetModPlayer<QoLCPlayer>().selectedBiome = 7;
            SoundEngine.PlaySound(SoundID.MenuClose);
            visible = false;
        }

        private void ForestClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            Player p = Main.LocalPlayer;
            p.GetModPlayer<QoLCPlayer>().selectedBiome = 8;
            SoundEngine.PlaySound(SoundID.MenuClose);
            visible = false;
        }
    }
}
