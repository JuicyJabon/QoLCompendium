﻿using Microsoft.Xna.Framework;
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
            ShopPanel.Top.Set(275f, 0f);
            ShopPanel.Width.Set(385f, 0f);
            ShopPanel.Height.Set(190f, 0f);
            ShopPanel.BackgroundColor = new Color(73, 94, 171);

            ShopPanel.OnMouseDown += new MouseEvent(DragStart);
            ShopPanel.OnMouseUp += new MouseEvent(DragEnd);

            UIText text0 = new("Modded Potions");
            text0.Left.Set(35, 0f);
            text0.Top.Set(10, 0f);
            text0.Width.Set(100, 0f);
            text0.Height.Set(22, 0f);
            ShopPanel.Append(text0);

            UIText text1 = new("Modded Materials");
            text1.Left.Set(35, 0f);
            text1.Top.Set(40, 0f);
            text1.Width.Set(100, 0f);
            text1.Height.Set(22, 0f);
            ShopPanel.Append(text1);

            UIText text2 = new("Rare Modded Materials");
            text2.Left.Set(35, 0f);
            text2.Top.Set(70, 0f);
            text2.Width.Set(100, 0f);
            text2.Height.Set(22, 0f);
            ShopPanel.Append(text2);

            UIText text3 = new("Modded Treasure Bags 1");
            text3.Left.Set(35, 0f);
            text3.Top.Set(100, 0f);
            text3.Width.Set(100, 0f);
            text3.Height.Set(22, 0f);
            ShopPanel.Append(text3);

            UIText text4 = new("Modded Treasure Bags 2");
            text4.Left.Set(35, 0f);
            text4.Top.Set(130, 0f);
            text4.Width.Set(100, 0f);
            text4.Height.Set(22, 0f);
            ShopPanel.Append(text4);

            UIText text5 = new("Modded Treasure Bags 3");
            text5.Left.Set(35, 0f);
            text5.Top.Set(160, 0f);
            text5.Width.Set(100, 0f);
            text5.Height.Set(22, 0f);
            ShopPanel.Append(text5);

            Asset<Texture2D> buttonPlayTexture = Request<Texture2D>("Terraria/Images/UI/ButtonPlay");
            UIImageButton playButton0 = new(buttonPlayTexture);
            playButton0.Left.Set(10, 0f);
            playButton0.Top.Set(10, 0f);
            playButton0.Width.Set(22, 0f);
            playButton0.Height.Set(22, 0f);
            playButton0.OnClick += new MouseEvent(PlayButtonClicked0);
            ShopPanel.Append(playButton0);
            UIImageButton playButton1 = new(buttonPlayTexture);
            playButton1.Left.Set(10, 0f);
            playButton1.Top.Set(40, 0f);
            playButton1.Width.Set(22, 0f);
            playButton1.Height.Set(22, 0f);
            playButton1.OnClick += new MouseEvent(PlayButtonClicked1);
            ShopPanel.Append(playButton1);
            UIImageButton playButton2 = new(buttonPlayTexture);
            playButton2.Left.Set(10, 0f);
            playButton2.Top.Set(70, 0f);
            playButton2.Width.Set(22, 0f);
            playButton2.Height.Set(22, 0f);
            playButton2.OnClick += new MouseEvent(PlayButtonClicked2);
            ShopPanel.Append(playButton2);
            UIImageButton playButton3 = new(buttonPlayTexture);
            playButton3.Left.Set(10, 0f);
            playButton3.Top.Set(100, 0f);
            playButton3.Width.Set(22, 0f);
            playButton3.Height.Set(22, 0f);
            playButton3.OnClick += new MouseEvent(PlayButtonClicked3);
            ShopPanel.Append(playButton3);
            UIImageButton playButton4 = new(buttonPlayTexture);
            playButton4.Left.Set(10, 0f);
            playButton4.Top.Set(130, 0f);
            playButton4.Width.Set(22, 0f);
            playButton4.Height.Set(22, 0f);
            playButton4.OnClick += new MouseEvent(PlayButtonClicked4);
            ShopPanel.Append(playButton4);
            UIImageButton playButton5 = new(buttonPlayTexture);
            playButton5.Left.Set(10, 0f);
            playButton5.Top.Set(160, 0f);
            playButton5.Width.Set(22, 0f);
            playButton5.Height.Set(22, 0f);
            playButton5.OnClick += new MouseEvent(PlayButtonClicked5);
            ShopPanel.Append(playButton5);

            Asset<Texture2D> buttonDeleteTexture = Request<Texture2D>("Terraria/Images/UI/ButtonDelete");
            UIImageButton closeButton = new(buttonDeleteTexture);
            closeButton.Left.Set(350, 0f);
            closeButton.Top.Set(10, 0f);
            closeButton.Width.Set(22, 0f);
            closeButton.Height.Set(22, 0f);
            closeButton.OnClick += new MouseEvent(CloseButtonClicked);
            ShopPanel.Append(closeButton);
            Append(ShopPanel);
        }

        private void PlayButtonClicked0(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                EtherealCollectorNPC.shopNum = 0;
                NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
                visible = false;
                Main.playerInventory = true;
                Main.npcChatText = "";
                Main.SetNPCShopIndex(Main.MaxShopIDs - 1);
                Main.instance.shop[Main.npcShop].SetupShop(npc.type);
            }
        }

        private void PlayButtonClicked1(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                EtherealCollectorNPC.shopNum = 1;
                NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
                visible = false;
                Main.playerInventory = true;
                Main.npcChatText = "";
                Main.SetNPCShopIndex(Main.MaxShopIDs - 1);
                Main.instance.shop[Main.npcShop].SetupShop(npc.type);
            }
        }

        private void PlayButtonClicked2(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                EtherealCollectorNPC.shopNum = 2;
                NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
                visible = false;
                Main.playerInventory = true;
                Main.npcChatText = "";
                Main.SetNPCShopIndex(Main.MaxShopIDs - 1);
                Main.instance.shop[Main.npcShop].SetupShop(npc.type);
            }
        }

        private void PlayButtonClicked3(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                EtherealCollectorNPC.shopNum = 3;
                NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
                visible = false;
                Main.playerInventory = true;
                Main.npcChatText = "";
                Main.SetNPCShopIndex(Main.MaxShopIDs - 1);
                Main.instance.shop[Main.npcShop].SetupShop(npc.type);
            }
        }

        private void PlayButtonClicked4(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                EtherealCollectorNPC.shopNum = 4;
                NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
                visible = false;
                Main.playerInventory = true;
                Main.npcChatText = "";
                Main.SetNPCShopIndex(Main.MaxShopIDs - 1);
                Main.instance.shop[Main.npcShop].SetupShop(npc.type);
            }
        }

        private void PlayButtonClicked5(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                EtherealCollectorNPC.shopNum = 5;
                NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
                visible = false;
                Main.playerInventory = true;
                Main.npcChatText = "";
                Main.SetNPCShopIndex(Main.MaxShopIDs - 1);
                Main.instance.shop[Main.npcShop].SetupShop(npc.type);
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