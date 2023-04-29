using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QoLCompendium.Items;
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
        public UIPanel ShopPanel;
        public static bool visible = false;
        public static uint timeStart;

        public override void OnInitialize()
        {
            ShopPanel = new UIPanel();
            ShopPanel.SetPadding(0);
            ShopPanel.Left.Set(575f, 0f);
            ShopPanel.Top.Set(275f, 0f);
            ShopPanel.Width.Set(290f, 0f);
            ShopPanel.Height.Set(260f, 0f);
            ShopPanel.BackgroundColor = new Color(73, 94, 171);

            ShopPanel.OnMouseDown += new MouseEvent(DragStart);
            ShopPanel.OnMouseUp += new MouseEvent(DragEnd);

            UIText text0 = new("Reset Biome");
            text0.Left.Set(45, 0f);
            text0.Top.Set(16, 0f);
            text0.Width.Set(100, 0f);
            text0.Height.Set(26, 0f);
            ShopPanel.Append(text0);

            UIText text1 = new("Desert");
            text1.Left.Set(45, 0f);
            text1.Top.Set(46, 0f);
            text1.Width.Set(50, 0f);
            text1.Height.Set(26, 0f);
            ShopPanel.Append(text1);

            UIText text2 = new("Snow");
            text2.Left.Set(45, 0f);
            text2.Top.Set(76, 0f);
            text2.Width.Set(40, 0f);
            text2.Height.Set(26, 0f);
            ShopPanel.Append(text2);

            UIText text3 = new("Jungle");
            text3.Left.Set(45, 0f);
            text3.Top.Set(106, 0f);
            text3.Width.Set(60, 0f);
            text3.Height.Set(26, 0f);
            ShopPanel.Append(text3);

            UIText text4 = new("Glowing Mushroom");
            text4.Left.Set(45, 0f);
            text4.Top.Set(136, 0f);
            text4.Width.Set(100, 0f);
            text4.Height.Set(26, 0f);
            ShopPanel.Append(text4);

            UIText text5 = new("Corruption");
            text5.Left.Set(45, 0f);
            text5.Top.Set(166, 0f);
            text5.Width.Set(70, 0f);
            text5.Height.Set(26, 0f);
            ShopPanel.Append(text5);

            UIText text6 = new("Crimson");
            text6.Left.Set(45, 0f);
            text6.Top.Set(196, 0f);
            text6.Width.Set(70, 0f);
            text6.Height.Set(26, 0f);
            ShopPanel.Append(text6);

            UIText text7 = new("Hallow - Requires Hardmode");
            text7.Left.Set(45, 0f);
            text7.Top.Set(226, 0f);
            text7.Width.Set(100, 0f);
            text7.Height.Set(26, 0f);
            ShopPanel.Append(text7);

            Asset<Texture2D> resetTexture = Request<Texture2D>("QoLCompendium/Items/Globe");
            Asset<Texture2D> desertTexture = Request<Texture2D>("QoLCompendium/Items/DesertGlobe");
            Asset<Texture2D> snowTexture = Request<Texture2D>("QoLCompendium/Items/IceGlobe");
            Asset<Texture2D> jungleTexture = Request<Texture2D>("QoLCompendium/Items/JungleGlobe");
            Asset<Texture2D> glowingMushroomTexture = Request<Texture2D>("QoLCompendium/Items/GlowingMushroomGlobe");
            Asset<Texture2D> corruptionTexture = Request<Texture2D>("QoLCompendium/Items/CorruptionGlobe");
            Asset<Texture2D> crimsonTexture = Request<Texture2D>("QoLCompendium/Items/CrimsonGlobe");
            Asset<Texture2D> hallowTexture = Request<Texture2D>("QoLCompendium/Items/HallowGlobe");

            UIImageButton playButton0 = new(resetTexture);
            playButton0.Left.Set(10, 0f);
            playButton0.Top.Set(10, 0f);
            playButton0.Width.Set(32, 0f);
            playButton0.Height.Set(32, 0f);
            playButton0.OnClick += new MouseEvent(PlayButtonClicked0);
            ShopPanel.Append(playButton0);
            UIImageButton playButton1 = new(desertTexture);
            playButton1.Left.Set(10, 0f);
            playButton1.Top.Set(40, 0f);
            playButton1.Width.Set(32, 0f);
            playButton1.Height.Set(32, 0f);
            playButton1.OnClick += new MouseEvent(PlayButtonClicked1);
            ShopPanel.Append(playButton1);
            UIImageButton playButton2 = new(snowTexture);
            playButton2.Left.Set(10, 0f);
            playButton2.Top.Set(70, 0f);
            playButton2.Width.Set(32, 0f);
            playButton2.Height.Set(32, 0f);
            playButton2.OnClick += new MouseEvent(PlayButtonClicked2);
            ShopPanel.Append(playButton2);
            UIImageButton playButton3 = new(jungleTexture);
            playButton3.Left.Set(10, 0f);
            playButton3.Top.Set(100, 0f);
            playButton3.Width.Set(32, 0f);
            playButton3.Height.Set(32, 0f);
            playButton3.OnClick += new MouseEvent(PlayButtonClicked3);
            ShopPanel.Append(playButton3);
            UIImageButton playButton4 = new(glowingMushroomTexture);
            playButton4.Left.Set(10, 0f);
            playButton4.Top.Set(130, 0f);
            playButton4.Width.Set(32, 0f);
            playButton4.Height.Set(32, 0f);
            playButton4.OnClick += new MouseEvent(PlayButtonClicked4);
            ShopPanel.Append(playButton4);
            UIImageButton playButton5 = new(corruptionTexture);
            playButton5.Left.Set(10, 0f);
            playButton5.Top.Set(160, 0f);
            playButton5.Width.Set(32, 0f);
            playButton5.Height.Set(32, 0f);
            playButton5.OnClick += new MouseEvent(PlayButtonClicked5);
            ShopPanel.Append(playButton5);
            UIImageButton playButton6 = new(crimsonTexture);
            playButton6.Left.Set(10, 0f);
            playButton6.Top.Set(190, 0f);
            playButton6.Width.Set(32, 0f);
            playButton6.Height.Set(32, 0f);
            playButton6.OnClick += new MouseEvent(PlayButtonClicked6);
            ShopPanel.Append(playButton6);
            UIImageButton playButton7 = new(hallowTexture);
            playButton7.Left.Set(10, 0f);
            playButton7.Top.Set(220, 0f);
            playButton7.Width.Set(32, 0f);
            playButton7.Height.Set(32, 0f);
            playButton7.OnClick += new MouseEvent(PlayButtonClicked7);
            ShopPanel.Append(playButton7);
            Append(ShopPanel);
        }

        private void PlayButtonClicked0(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetModPlayer<QolCPlayer>().selectedBiome = 0;
                visible = false;
            }
        }

        private void PlayButtonClicked1(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetModPlayer<QolCPlayer>().selectedBiome = 1;
                visible = false;
            }
        }

        private void PlayButtonClicked2(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetModPlayer<QolCPlayer>().selectedBiome = 2;
                visible = false;
            }
        }

        private void PlayButtonClicked3(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetModPlayer<QolCPlayer>().selectedBiome = 3;
                visible = false;
            }
        }

        private void PlayButtonClicked4(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetModPlayer<QolCPlayer>().selectedBiome = 4;
                visible = false;
            }
        }

        private void PlayButtonClicked5(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetModPlayer<QolCPlayer>().selectedBiome = 5;
                visible = false;
            }
        }

        private void PlayButtonClicked6(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetModPlayer<QolCPlayer>().selectedBiome = 6;
                visible = false;
            }
        }

        private void PlayButtonClicked7(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Player p = Main.LocalPlayer;
                p.GetModPlayer<QolCPlayer>().selectedBiome = 7;
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
