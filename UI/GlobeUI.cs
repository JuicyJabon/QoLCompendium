using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QoLCompendium.Tweaks;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace QoLCompendium.UI
{
    class GlobeUI : UIState
    {
        public UIPanel GlobePanel;
        public static bool visible = false;
        public static uint timeStart;

        public override void OnInitialize()
        {
            GlobePanel = new UIPanel();
            GlobePanel.SetPadding(0);
            GlobePanel.Left.Set(575f, 0f);
            GlobePanel.Top.Set(275f, 0f);
            GlobePanel.Width.Set(290f, 0f);
            GlobePanel.Height.Set(260f, 0f);
            GlobePanel.BackgroundColor = new Color(73, 94, 171);

            GlobePanel.OnLeftMouseDown += new MouseEvent(DragStart);
            GlobePanel.OnLeftMouseUp += new MouseEvent(DragEnd);

            UIText text0 = new("Reset Biome");
            text0.Left.Set(45, 0f);
            text0.Top.Set(16, 0f);
            text0.Width.Set(100, 0f);
            text0.Height.Set(26, 0f);
            GlobePanel.Append(text0);

            UIText text1 = new("Desert");
            text1.Left.Set(45, 0f);
            text1.Top.Set(46, 0f);
            text1.Width.Set(50, 0f);
            text1.Height.Set(26, 0f);
            GlobePanel.Append(text1);

            UIText text2 = new("Snow");
            text2.Left.Set(45, 0f);
            text2.Top.Set(76, 0f);
            text2.Width.Set(40, 0f);
            text2.Height.Set(26, 0f);
            GlobePanel.Append(text2);

            UIText text3 = new("Jungle");
            text3.Left.Set(45, 0f);
            text3.Top.Set(106, 0f);
            text3.Width.Set(60, 0f);
            text3.Height.Set(26, 0f);
            GlobePanel.Append(text3);

            UIText text4 = new("Glowing Mushroom");
            text4.Left.Set(45, 0f);
            text4.Top.Set(136, 0f);
            text4.Width.Set(100, 0f);
            text4.Height.Set(26, 0f);
            GlobePanel.Append(text4);

            UIText text5 = new("Corruption");
            text5.Left.Set(45, 0f);
            text5.Top.Set(166, 0f);
            text5.Width.Set(70, 0f);
            text5.Height.Set(26, 0f);
            GlobePanel.Append(text5);

            UIText text6 = new("Crimson");
            text6.Left.Set(45, 0f);
            text6.Top.Set(196, 0f);
            text6.Width.Set(70, 0f);
            text6.Height.Set(26, 0f);
            GlobePanel.Append(text6);

            UIText text7 = new("Hallow - Requires Hardmode");
            text7.Left.Set(45, 0f);
            text7.Top.Set(226, 0f);
            text7.Width.Set(100, 0f);
            text7.Height.Set(26, 0f);
            GlobePanel.Append(text7);

            Asset<Texture2D> resetTexture = Request<Texture2D>("QoLCompendium/Assets/Globe");
            Asset<Texture2D> desertTexture = Request<Texture2D>("QoLCompendium/Assets/DesertGlobe");
            Asset<Texture2D> snowTexture = Request<Texture2D>("QoLCompendium/Assets/IceGlobe");
            Asset<Texture2D> jungleTexture = Request<Texture2D>("QoLCompendium/Assets/JungleGlobe");
            Asset<Texture2D> glowingMushroomTexture = Request<Texture2D>("QoLCompendium/Assets/GlowingMushroomGlobe");
            Asset<Texture2D> corruptionTexture = Request<Texture2D>("QoLCompendium/Assets/CorruptionGlobe");
            Asset<Texture2D> crimsonTexture = Request<Texture2D>("QoLCompendium/Assets/CrimsonGlobe");
            Asset<Texture2D> hallowTexture = Request<Texture2D>("QoLCompendium/Assets/HallowGlobe");
            Asset<Texture2D> buttonDeleteTexture = Request<Texture2D>("Terraria/Images/UI/ButtonDelete");

            UIImageButton playButton0 = new(resetTexture);
            playButton0.Left.Set(10, 0f);
            playButton0.Top.Set(10, 0f);
            playButton0.Width.Set(32, 0f);
            playButton0.Height.Set(32, 0f);
            playButton0.OnLeftClick += new MouseEvent(PlayButtonClicked0);
            GlobePanel.Append(playButton0);
            UIImageButton playButton1 = new(desertTexture);
            playButton1.Left.Set(10, 0f);
            playButton1.Top.Set(40, 0f);
            playButton1.Width.Set(32, 0f);
            playButton1.Height.Set(32, 0f);
            playButton1.OnLeftClick += new MouseEvent(PlayButtonClicked1);
            GlobePanel.Append(playButton1);
            UIImageButton playButton2 = new(snowTexture);
            playButton2.Left.Set(10, 0f);
            playButton2.Top.Set(70, 0f);
            playButton2.Width.Set(32, 0f);
            playButton2.Height.Set(32, 0f);
            playButton2.OnLeftClick += new MouseEvent(PlayButtonClicked2);
            GlobePanel.Append(playButton2);
            UIImageButton playButton3 = new(jungleTexture);
            playButton3.Left.Set(10, 0f);
            playButton3.Top.Set(100, 0f);
            playButton3.Width.Set(32, 0f);
            playButton3.Height.Set(32, 0f);
            playButton3.OnLeftClick += new MouseEvent(PlayButtonClicked3);
            GlobePanel.Append(playButton3);
            UIImageButton playButton4 = new(glowingMushroomTexture);
            playButton4.Left.Set(10, 0f);
            playButton4.Top.Set(130, 0f);
            playButton4.Width.Set(32, 0f);
            playButton4.Height.Set(32, 0f);
            playButton4.OnLeftClick += new MouseEvent(PlayButtonClicked4);
            GlobePanel.Append(playButton4);
            UIImageButton playButton5 = new(corruptionTexture);
            playButton5.Left.Set(10, 0f);
            playButton5.Top.Set(160, 0f);
            playButton5.Width.Set(32, 0f);
            playButton5.Height.Set(32, 0f);
            playButton5.OnLeftClick += new MouseEvent(PlayButtonClicked5);
            GlobePanel.Append(playButton5);
            UIImageButton playButton6 = new(crimsonTexture);
            playButton6.Left.Set(10, 0f);
            playButton6.Top.Set(190, 0f);
            playButton6.Width.Set(32, 0f);
            playButton6.Height.Set(32, 0f);
            playButton6.OnLeftClick += new MouseEvent(PlayButtonClicked6);
            GlobePanel.Append(playButton6);
            UIImageButton playButton7 = new(hallowTexture);
            playButton7.Left.Set(10, 0f);
            playButton7.Top.Set(220, 0f);
            playButton7.Width.Set(32, 0f);
            playButton7.Height.Set(32, 0f);
            playButton7.OnLeftClick += new MouseEvent(PlayButtonClicked7);
            GlobePanel.Append(playButton7);
            Append(GlobePanel);

            UIImageButton closeButton = new(buttonDeleteTexture);
            closeButton.Left.Set(260, 0f);
            closeButton.Top.Set(10, 0f);
            closeButton.Width.Set(22, 0f);
            closeButton.Height.Set(22, 0f);
            closeButton.OnLeftClick += new MouseEvent(CloseButtonClicked);
            GlobePanel.Append(closeButton);
            Append(GlobePanel);
        }

        private void PlayButtonClicked0(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetModPlayer<QoLCPlayer>().selectedBiome = 0;
                visible = false;
            }
        }

        private void PlayButtonClicked1(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetModPlayer<QoLCPlayer>().selectedBiome = 1;
                visible = false;
            }
        }

        private void PlayButtonClicked2(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetModPlayer<QoLCPlayer>().selectedBiome = 2;
                visible = false;
            }
        }

        private void PlayButtonClicked3(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetModPlayer<QoLCPlayer>().selectedBiome = 3;
                visible = false;
            }
        }

        private void PlayButtonClicked4(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetModPlayer<QoLCPlayer>().selectedBiome = 4;
                visible = false;
            }
        }

        private void PlayButtonClicked5(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetModPlayer<QoLCPlayer>().selectedBiome = 5;
                visible = false;
            }
        }

        private void PlayButtonClicked6(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetModPlayer<QoLCPlayer>().selectedBiome = 6;
                visible = false;
            }
        }

        private void PlayButtonClicked7(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetModPlayer<QoLCPlayer>().selectedBiome = 7;
                visible = false;
            }
        }

        private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                SoundEngine.PlaySound(SoundID.MenuOpen);
                visible = false;
            }
        }

        Vector2 offset;
        public bool dragging = false;
        private void DragStart(UIMouseEvent evt, UIElement listeningElement)
        {
            offset = new Vector2(evt.MousePosition.X - GlobePanel.Left.Pixels, evt.MousePosition.Y - GlobePanel.Top.Pixels);
            dragging = true;
        }

        private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            dragging = false;

            GlobePanel.Left.Set(end.X - offset.X, 0f);
            GlobePanel.Top.Set(end.Y - offset.Y, 0f);

            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 MousePosition = new(Main.mouseX, Main.mouseY);
            if (GlobePanel.ContainsPoint(MousePosition))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
            if (dragging)
            {
                GlobePanel.Left.Set(MousePosition.X - offset.X, 0f);
                GlobePanel.Top.Set(MousePosition.Y - offset.Y, 0f);
                Recalculate();
            }
        }
    }
}
