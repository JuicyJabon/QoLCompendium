using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace QoLCompendium.UI
{
    class MoonChangeUI : UIState
    {
        public UIPanel MoonPanel;
        public static bool visible = false;
        public static uint timeStart;

        public override void OnInitialize()
        {
            MoonPanel = new UIPanel();
            MoonPanel.SetPadding(0);
            MoonPanel.Left.Set(575f, 0f);
            MoonPanel.Top.Set(275f, 0f);
            MoonPanel.Width.Set(290f, 0f);
            MoonPanel.Height.Set(490f, 0f);
            MoonPanel.BackgroundColor = new Color(73, 94, 171);

            MoonPanel.OnLeftMouseDown += new MouseEvent(DragStart);
            MoonPanel.OnLeftMouseUp += new MouseEvent(DragEnd);

            UIText text0 = new("Full Moon");
            text0.Left.Set(65, 0f);
            text0.Top.Set(22.5f, 0f);
            text0.Width.Set(60, 0f);
            text0.Height.Set(25, 0f);
            MoonPanel.Append(text0);

            UIText text1 = new("Waning Gibbous");
            text1.Left.Set(65, 0f);
            text1.Top.Set(82.5f, 0f);
            text1.Width.Set(60, 0f);
            text1.Height.Set(25, 0f);
            MoonPanel.Append(text1);

            UIText text2 = new("Third Quarter");
            text2.Left.Set(65, 0f);
            text2.Top.Set(142.5f, 0f);
            text2.Width.Set(60, 0f);
            text2.Height.Set(25, 0f);
            MoonPanel.Append(text2);

            UIText text3 = new("Waning Crescent");
            text3.Left.Set(65, 0f);
            text3.Top.Set(202.5f, 0f);
            text3.Width.Set(60, 0f);
            text3.Height.Set(25, 0f);
            MoonPanel.Append(text3);

            UIText text4 = new("New Moon");
            text4.Left.Set(65, 0f);
            text4.Top.Set(262.5f, 0f);
            text4.Width.Set(60, 0f);
            text4.Height.Set(25, 0f);
            MoonPanel.Append(text4);

            UIText text5 = new("Waxing Crescent");
            text5.Left.Set(65, 0f);
            text5.Top.Set(322.5f, 0f);
            text5.Width.Set(60, 0f);
            text5.Height.Set(25, 0f);
            MoonPanel.Append(text5);

            UIText text6 = new("First Quarter");
            text6.Left.Set(65, 0f);
            text6.Top.Set(382.5f, 0f);
            text6.Width.Set(60, 0f);
            text6.Height.Set(25, 0f);
            MoonPanel.Append(text6);

            UIText text7 = new("Waxing Gibbous");
            text7.Left.Set(65, 0f);
            text7.Top.Set(442.5f, 0f);
            text7.Width.Set(60, 0f);
            text7.Height.Set(25, 0f);
            MoonPanel.Append(text7);

            Asset<Texture2D> moonFullTexture = Request<Texture2D>("QoLCompendium/Assets/Moons/MoonFull");
            Asset<Texture2D> moonWaningGibbousTexture = Request<Texture2D>("QoLCompendium/Assets/Moons/MoonWaningGibbous");
            Asset<Texture2D> moonThirdQuarterTexture = Request<Texture2D>("QoLCompendium/Assets/Moons/MoonThirdQuarter");
            Asset<Texture2D> moonWaningCrescentTexture = Request<Texture2D>("QoLCompendium/Assets/Moons/MoonWaningCrescent");
            Asset<Texture2D> moonNewTexture = Request<Texture2D>("QoLCompendium/Assets/Moons/MoonNew");
            Asset<Texture2D> moonWaxingCrescentTexture = Request<Texture2D>("QoLCompendium/Assets/Moons/MoonWaxingCrescent");
            Asset<Texture2D> moonFirstQuarterTexture = Request<Texture2D>("QoLCompendium/Assets/Moons/MoonFirstQuarter");
            Asset<Texture2D> moonWaxingGibbousTexture = Request<Texture2D>("QoLCompendium/Assets/Moons/MoonWaxingGibbous");
            Asset<Texture2D> buttonDeleteTexture = Request<Texture2D>("Terraria/Images/UI/ButtonDelete");

            UIImageButton playButton0 = new(moonFullTexture);
            playButton0.Left.Set(10, 0f);
            playButton0.Top.Set(10, 0f);
            playButton0.Width.Set(50, 0f);
            playButton0.Height.Set(50, 0f);
            playButton0.OnLeftClick += new MouseEvent(PlayButtonClicked0);
            MoonPanel.Append(playButton0);
            UIImageButton playButton1 = new(moonWaningGibbousTexture);
            playButton1.Left.Set(10, 0f);
            playButton1.Top.Set(70, 0f);
            playButton1.Width.Set(50, 0f);
            playButton1.Height.Set(50, 0f);
            playButton1.OnLeftClick += new MouseEvent(PlayButtonClicked1);
            MoonPanel.Append(playButton1);
            UIImageButton playButton2 = new(moonThirdQuarterTexture);
            playButton2.Left.Set(10, 0f);
            playButton2.Top.Set(130, 0f);
            playButton2.Width.Set(50, 0f);
            playButton2.Height.Set(50, 0f);
            playButton2.OnLeftClick += new MouseEvent(PlayButtonClicked2);
            MoonPanel.Append(playButton2);
            UIImageButton playButton3 = new(moonWaningCrescentTexture);
            playButton3.Left.Set(10, 0f);
            playButton3.Top.Set(190, 0f);
            playButton3.Width.Set(50, 0f);
            playButton3.Height.Set(50, 0f);
            playButton3.OnLeftClick += new MouseEvent(PlayButtonClicked3);
            MoonPanel.Append(playButton3);
            UIImageButton playButton4 = new(moonNewTexture);
            playButton4.Left.Set(10, 0f);
            playButton4.Top.Set(250, 0f);
            playButton4.Width.Set(50, 0f);
            playButton4.Height.Set(50, 0f);
            playButton4.OnLeftClick += new MouseEvent(PlayButtonClicked4);
            MoonPanel.Append(playButton4);
            UIImageButton playButton5 = new(moonWaxingCrescentTexture);
            playButton5.Left.Set(10, 0f);
            playButton5.Top.Set(310, 0f);
            playButton5.Width.Set(50, 0f);
            playButton5.Height.Set(50, 0f);
            playButton5.OnLeftClick += new MouseEvent(PlayButtonClicked5);
            MoonPanel.Append(playButton5);
            UIImageButton playButton6 = new(moonFirstQuarterTexture);
            playButton6.Left.Set(10, 0f);
            playButton6.Top.Set(370, 0f);
            playButton6.Width.Set(50, 0f);
            playButton6.Height.Set(50, 0f);
            playButton6.OnLeftClick += new MouseEvent(PlayButtonClicked6);
            MoonPanel.Append(playButton6);
            UIImageButton playButton7 = new(moonWaxingGibbousTexture);
            playButton7.Left.Set(10, 0f);
            playButton7.Top.Set(430, 0f);
            playButton7.Width.Set(50, 0f);
            playButton7.Height.Set(50, 0f);
            playButton7.OnLeftClick += new MouseEvent(PlayButtonClicked7);
            MoonPanel.Append(playButton7);
            Append(MoonPanel);

            UIImageButton closeButton = new(buttonDeleteTexture);
            closeButton.Left.Set(250, 0f);
            closeButton.Top.Set(10, 0f);
            closeButton.Width.Set(22, 0f);
            closeButton.Height.Set(22, 0f);
            closeButton.OnLeftClick += new MouseEvent(CloseButtonClicked);
            MoonPanel.Append(closeButton);
            Append(MoonPanel);
        }

        private void PlayButtonClicked0(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.moonPhase = 0;
                visible = false;
            }
        }

        private void PlayButtonClicked1(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.moonPhase = 1;
                visible = false;
            }
        }

        private void PlayButtonClicked2(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.moonPhase = 2;
                visible = false;
            }
        }

        private void PlayButtonClicked3(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.moonPhase = 3;
                visible = false;
            }
        }

        private void PlayButtonClicked4(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.moonPhase = 4;
                visible = false;
            }
        }

        private void PlayButtonClicked5(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.moonPhase = 5;
                visible = false;
            }
        }

        private void PlayButtonClicked6(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.moonPhase = 6;
                visible = false;
            }
        }

        private void PlayButtonClicked7(UIMouseEvent evt, UIElement listeningElement)
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
                SoundEngine.PlaySound(SoundID.MenuOpen);
                visible = false;
            }
        }

        Vector2 offset;
        public bool dragging = false;
        private void DragStart(UIMouseEvent evt, UIElement listeningElement)
        {
            offset = new Vector2(evt.MousePosition.X - MoonPanel.Left.Pixels, evt.MousePosition.Y - MoonPanel.Top.Pixels);
            dragging = true;
        }

        private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            dragging = false;

            MoonPanel.Left.Set(end.X - offset.X, 0f);
            MoonPanel.Top.Set(end.Y - offset.Y, 0f);

            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 MousePosition = new(Main.mouseX, Main.mouseY);
            if (MoonPanel.ContainsPoint(MousePosition))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
            if (dragging)
            {
                MoonPanel.Left.Set(MousePosition.X - offset.X, 0f);
                MoonPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
                Recalculate();
            }
        }
    }
}
