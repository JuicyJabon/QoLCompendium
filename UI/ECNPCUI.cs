using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QoLCompendium.NPCs;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace QoLCompendium.UI
{
    class ECNPCUI : UIState
    {
        public UIPanel ShopPanel;
        public static bool visible = false;
        public static uint timeStart;

        public override void OnInitialize()
        {
            ShopPanel = new UIPanel();
            ShopPanel.SetPadding(0);
            ShopPanel.Left.Set(575f, 0f);
            ShopPanel.Top.Set(300f, 0f);
            ShopPanel.Width.Set(385f, 0f);
            ShopPanel.Height.Set(280f, 0f);
            ShopPanel.BackgroundColor = new Color(73, 94, 171);

            ShopPanel.OnLeftMouseDown += new MouseEvent(DragStart);
            ShopPanel.OnLeftMouseUp += new MouseEvent(DragEnd);

            UIText text0 = new("Modded Potions");
            text0.Left.Set(35, 0f);
            text0.Top.Set(10, 0f);
            text0.Width.Set(100, 0f);
            text0.Height.Set(22, 0f);
            ShopPanel.Append(text0);

            UIText text1 = new("Modded Materials 1");
            text1.Left.Set(35, 0f);
            text1.Top.Set(40, 0f);
            text1.Width.Set(100, 0f);
            text1.Height.Set(22, 0f);
            ShopPanel.Append(text1);

            UIText text2 = new("Modded Materials 2");
            text2.Left.Set(35, 0f);
            text2.Top.Set(70, 0f);
            text2.Width.Set(100, 0f);
            text2.Height.Set(22, 0f);
            ShopPanel.Append(text2);

            UIText text3 = new("Modded Materials 3");
            text3.Left.Set(35, 0f);
            text3.Top.Set(100, 0f);
            text3.Width.Set(100, 0f);
            text3.Height.Set(22, 0f);
            ShopPanel.Append(text3);

            UIText text4 = new("Modded Treasure Bags 1");
            text4.Left.Set(35, 0f);
            text4.Top.Set(130, 0f);
            text4.Width.Set(100, 0f);
            text4.Height.Set(22, 0f);
            ShopPanel.Append(text4);

            UIText text5 = new("Modded Treasure Bags 2");
            text5.Left.Set(35, 0f);
            text5.Top.Set(160, 0f);
            text5.Width.Set(100, 0f);
            text5.Height.Set(22, 0f);
            ShopPanel.Append(text5);

            UIText text6 = new("Modded Treasure Bags 3");
            text6.Left.Set(35, 0f);
            text6.Top.Set(190, 0f);
            text6.Width.Set(100, 0f);
            text6.Height.Set(22, 0f);
            ShopPanel.Append(text6);

            UIText text7 = new("Modded Crates & Grab Bags");
            text7.Left.Set(35, 0f);
            text7.Top.Set(220, 0f);
            text7.Width.Set(100, 0f);
            text7.Height.Set(22, 0f);
            ShopPanel.Append(text7);

            UIText text8 = new("Modded Ores & Bars");
            text8.Left.Set(35, 0f);
            text8.Top.Set(250, 0f);
            text8.Width.Set(100, 0f);
            text8.Height.Set(22, 0f);
            ShopPanel.Append(text8);

            Asset<Texture2D> buttonPlayTexture = Request<Texture2D>("Terraria/Images/UI/ButtonPlay");
            UIImageButton playButton0 = new(buttonPlayTexture);
            playButton0.Left.Set(10, 0f);
            playButton0.Top.Set(10, 0f);
            playButton0.Width.Set(22, 0f);
            playButton0.Height.Set(22, 0f);
            playButton0.OnLeftClick += new MouseEvent(PlayButtonClicked0);
            ShopPanel.Append(playButton0);
            UIImageButton playButton1 = new(buttonPlayTexture);
            playButton1.Left.Set(10, 0f);
            playButton1.Top.Set(40, 0f);
            playButton1.Width.Set(22, 0f);
            playButton1.Height.Set(22, 0f);
            playButton1.OnLeftClick += new MouseEvent(PlayButtonClicked1);
            ShopPanel.Append(playButton1);
            UIImageButton playButton2 = new(buttonPlayTexture);
            playButton2.Left.Set(10, 0f);
            playButton2.Top.Set(70, 0f);
            playButton2.Width.Set(22, 0f);
            playButton2.Height.Set(22, 0f);
            playButton2.OnLeftClick += new MouseEvent(PlayButtonClicked2);
            ShopPanel.Append(playButton2);
            UIImageButton playButton3 = new(buttonPlayTexture);
            playButton3.Left.Set(10, 0f);
            playButton3.Top.Set(100, 0f);
            playButton3.Width.Set(22, 0f);
            playButton3.Height.Set(22, 0f);
            playButton3.OnLeftClick += new MouseEvent(PlayButtonClicked3);
            ShopPanel.Append(playButton3);
            UIImageButton playButton4 = new(buttonPlayTexture);
            playButton4.Left.Set(10, 0f);
            playButton4.Top.Set(130, 0f);
            playButton4.Width.Set(22, 0f);
            playButton4.Height.Set(22, 0f);
            playButton4.OnLeftClick += new MouseEvent(PlayButtonClicked4);
            ShopPanel.Append(playButton4);
            UIImageButton playButton5 = new(buttonPlayTexture);
            playButton5.Left.Set(10, 0f);
            playButton5.Top.Set(160, 0f);
            playButton5.Width.Set(22, 0f);
            playButton5.Height.Set(22, 0f);
            playButton5.OnLeftClick += new MouseEvent(PlayButtonClicked5);
            ShopPanel.Append(playButton5);
            UIImageButton playButton6 = new(buttonPlayTexture);
            playButton6.Left.Set(10, 0f);
            playButton6.Top.Set(190, 0f);
            playButton6.Width.Set(22, 0f);
            playButton6.Height.Set(22, 0f);
            playButton6.OnLeftClick += new MouseEvent(PlayButtonClicked6);
            ShopPanel.Append(playButton6);
            UIImageButton playButton7 = new(buttonPlayTexture);
            playButton7.Left.Set(10, 0f);
            playButton7.Top.Set(220, 0f);
            playButton7.Width.Set(22, 0f);
            playButton7.Height.Set(22, 0f);
            playButton7.OnLeftClick += new MouseEvent(PlayButtonClicked7);
            ShopPanel.Append(playButton7);
            UIImageButton playButton8 = new(buttonPlayTexture);
            playButton8.Left.Set(10, 0f);
            playButton8.Top.Set(250, 0f);
            playButton8.Width.Set(22, 0f);
            playButton8.Height.Set(22, 0f);
            playButton8.OnLeftClick += new MouseEvent(PlayButtonClicked8);
            ShopPanel.Append(playButton8);

            Asset<Texture2D> buttonDeleteTexture = Request<Texture2D>("Terraria/Images/UI/ButtonDelete");
            UIImageButton closeButton = new(buttonDeleteTexture);
            closeButton.Left.Set(350, 0f);
            closeButton.Top.Set(10, 0f);
            closeButton.Width.Set(22, 0f);
            closeButton.Height.Set(22, 0f);
            closeButton.OnLeftClick += new MouseEvent(CloseButtonClicked);
            ShopPanel.Append(closeButton);
            Append(ShopPanel);
        }

        private void PlayButtonClicked0(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                EtherealCollectorNPC.shopNum = 0;
                visible = false;
            }
        }

        private void PlayButtonClicked1(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                EtherealCollectorNPC.shopNum = 1;
                visible = false;
            }
        }

        private void PlayButtonClicked2(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                EtherealCollectorNPC.shopNum = 2;
                visible = false;
            }
        }

        private void PlayButtonClicked3(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                EtherealCollectorNPC.shopNum = 3;
                visible = false;
            }
        }

        private void PlayButtonClicked4(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                EtherealCollectorNPC.shopNum = 4;
                visible = false;
            }
        }

        private void PlayButtonClicked5(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                EtherealCollectorNPC.shopNum = 5;
                visible = false;
            }
        }

        private void PlayButtonClicked6(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                EtherealCollectorNPC.shopNum = 6;
                visible = false;
            }
        }

        private void PlayButtonClicked7(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                EtherealCollectorNPC.shopNum = 7;
                visible = false;
            }
        }

        private void PlayButtonClicked8(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                EtherealCollectorNPC.shopNum = 8;
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
            offset = new Vector2(evt.MousePosition.X - ShopPanel.Left.Pixels, evt.MousePosition.Y - ShopPanel.Top.Pixels);
            dragging = true;
        }

        private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            dragging = false;

            ShopPanel.Left.Set(end.X - offset.X, 0f);
            ShopPanel.Top.Set(end.Y - offset.Y, 0f);

            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 MousePosition = new(Main.mouseX, Main.mouseY);
            if (ShopPanel.ContainsPoint(MousePosition))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
            if (dragging)
            {
                ShopPanel.Left.Set(MousePosition.X - offset.X, 0f);
                ShopPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
                Recalculate();
            }
        }
    }
}
