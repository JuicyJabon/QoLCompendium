using QoLCompendium.NPCs;

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
            ShopPanel.Height.Set(310f, 0f);
            ShopPanel.BackgroundColor = new Color(73, 94, 171);

            ShopPanel.OnLeftMouseDown += new MouseEvent(DragStart);
            ShopPanel.OnLeftMouseUp += new MouseEvent(DragEnd);

            UIText potionText = new("Modded Potions");
            potionText.Left.Set(35, 0f);
            potionText.Top.Set(10, 0f);
            potionText.Width.Set(60, 0f);
            potionText.Height.Set(22, 0f);
            ShopPanel.Append(potionText);

            UIText stationText = new("Modded Flasks, Stations & Foods");
            stationText.Left.Set(35, 0f);
            stationText.Top.Set(40, 0f);
            stationText.Width.Set(60, 0f);
            stationText.Height.Set(22, 0f);
            ShopPanel.Append(stationText);

            UIText materialText = new("Modded Materials");
            materialText.Left.Set(35, 0f);
            materialText.Top.Set(70, 0f);
            materialText.Width.Set(60, 0f);
            materialText.Height.Set(22, 0f);
            ShopPanel.Append(materialText);

            UIText bagText = new("Modded Treasure Bags");
            bagText.Left.Set(35, 0f);
            bagText.Top.Set(100, 0f);
            bagText.Width.Set(60, 0f);
            bagText.Height.Set(22, 0f);
            ShopPanel.Append(bagText);

            UIText crateText = new("Modded Crates & Grab Bags");
            crateText.Left.Set(35, 0f);
            crateText.Top.Set(130, 0f);
            crateText.Width.Set(60, 0f);
            crateText.Height.Set(22, 0f);
            ShopPanel.Append(crateText);

            UIText oreText = new("Modded Ores & Bars");
            oreText.Left.Set(35, 0f);
            oreText.Top.Set(160, 0f);
            oreText.Width.Set(60, 0f);
            oreText.Height.Set(22, 0f);
            ShopPanel.Append(oreText);

            UIText naturalText = new("Modded Natural Blocks");
            naturalText.Left.Set(35, 0f);
            naturalText.Top.Set(190, 0f);
            naturalText.Width.Set(60, 0f);
            naturalText.Height.Set(22, 0f);
            ShopPanel.Append(naturalText);

            UIText buildingText = new("Modded Building Blocks");
            buildingText.Left.Set(35, 0f);
            buildingText.Top.Set(220, 0f);
            buildingText.Width.Set(60, 0f);
            buildingText.Height.Set(22, 0f);
            ShopPanel.Append(buildingText);

            UIText herbText = new("Modded Herbs & Plants");
            herbText.Left.Set(35, 0f);
            herbText.Top.Set(250, 0f);
            herbText.Width.Set(60, 0f);
            herbText.Height.Set(22, 0f);
            ShopPanel.Append(herbText);

            UIText fishText = new("Modded Fish & Fishing Gear");
            fishText.Left.Set(35, 0f);
            fishText.Top.Set(280, 0f);
            fishText.Width.Set(60, 0f);
            fishText.Height.Set(22, 0f);
            ShopPanel.Append(fishText);

            Asset<Texture2D> buttonPlayTexture = ModContent.Request<Texture2D>("Terraria/Images/UI/ButtonPlay");
            Asset<Texture2D> buttonDeleteTexture = ModContent.Request<Texture2D>("Terraria/Images/UI/ButtonDelete");

            UIImageButton potionButton = new(buttonPlayTexture);
            if (QoLCompendium.shopConfig.ECPotionShop == false)
            {
                potionButton = new(buttonDeleteTexture);
            }
            potionButton.Left.Set(10, 0f);
            potionButton.Top.Set(10, 0f);
            potionButton.Width.Set(22, 0f);
            potionButton.Height.Set(22, 0f);
            potionButton.OnLeftClick += new MouseEvent(PotionShopClicked);
            ShopPanel.Append(potionButton);

            UIImageButton stationButton = new(buttonPlayTexture);
            if (QoLCompendium.shopConfig.ECStationShop == false)
            {
                stationButton = new(buttonDeleteTexture);
            }
            stationButton.Left.Set(10, 0f);
            stationButton.Top.Set(40, 0f);
            stationButton.Width.Set(22, 0f);
            stationButton.Height.Set(22, 0f);
            stationButton.OnLeftClick += new MouseEvent(StationShopClicked);
            ShopPanel.Append(stationButton);

            UIImageButton materialButton = new(buttonPlayTexture);
            if (QoLCompendium.shopConfig.ECMaterialShop == false)
            {
                materialButton = new(buttonDeleteTexture);
            }
            materialButton.Left.Set(10, 0f);
            materialButton.Top.Set(70, 0f);
            materialButton.Width.Set(22, 0f);
            materialButton.Height.Set(22, 0f);
            materialButton.OnLeftClick += new MouseEvent(MaterialShopClicked);
            ShopPanel.Append(materialButton);

            UIImageButton bagButton = new(buttonPlayTexture);
            if (QoLCompendium.shopConfig.ECBagShop == false)
            {
                bagButton = new(buttonDeleteTexture);
            }
            bagButton.Left.Set(10, 0f);
            bagButton.Top.Set(100, 0f);
            bagButton.Width.Set(22, 0f);
            bagButton.Height.Set(22, 0f);
            bagButton.OnLeftClick += new MouseEvent(BagShopClicked);
            ShopPanel.Append(bagButton);

            UIImageButton crateButton = new(buttonPlayTexture);
            if (QoLCompendium.shopConfig.ECCrateShop == false)
            {
                crateButton = new(buttonDeleteTexture);
            }
            crateButton.Left.Set(10, 0f);
            crateButton.Top.Set(130, 0f);
            crateButton.Width.Set(22, 0f);
            crateButton.Height.Set(22, 0f);
            crateButton.OnLeftClick += new MouseEvent(CrateShopClicked);
            ShopPanel.Append(crateButton);

            UIImageButton oreButton = new(buttonPlayTexture);
            if (QoLCompendium.shopConfig.ECOreShop == false)
            {
                oreButton = new(buttonDeleteTexture);
            }
            oreButton.Left.Set(10, 0f);
            oreButton.Top.Set(160, 0f);
            oreButton.Width.Set(22, 0f);
            oreButton.Height.Set(22, 0f);
            oreButton.OnLeftClick += new MouseEvent(OreShopClicked);
            ShopPanel.Append(oreButton);

            UIImageButton naturalButton = new(buttonPlayTexture);
            if (QoLCompendium.shopConfig.ECNaturalBlocksShop == false)
            {
                naturalButton = new(buttonDeleteTexture);
            }
            naturalButton.Left.Set(10, 0f);
            naturalButton.Top.Set(190, 0f);
            naturalButton.Width.Set(22, 0f);
            naturalButton.Height.Set(22, 0f);
            naturalButton.OnLeftClick += new MouseEvent(NaturalShopClicked);
            ShopPanel.Append(naturalButton);

            UIImageButton buildingButton = new(buttonPlayTexture);
            if (QoLCompendium.shopConfig.ECBuildingBlocksShop == false)
            {
                buildingButton = new(buttonDeleteTexture);
            }
            buildingButton.Left.Set(10, 0f);
            buildingButton.Top.Set(220, 0f);
            buildingButton.Width.Set(22, 0f);
            buildingButton.Height.Set(22, 0f);
            buildingButton.OnLeftClick += new MouseEvent(BuildingShopClicked);
            ShopPanel.Append(buildingButton);

            UIImageButton herbButton = new(buttonPlayTexture);
            if (QoLCompendium.shopConfig.ECHerbShop == false)
            {
                herbButton = new(buttonDeleteTexture);
            }
            herbButton.Left.Set(10, 0f);
            herbButton.Top.Set(250, 0f);
            herbButton.Width.Set(22, 0f);
            herbButton.Height.Set(22, 0f);
            herbButton.OnLeftClick += new MouseEvent(HerbShopClicked);
            ShopPanel.Append(herbButton);

            UIImageButton fishButton = new(buttonPlayTexture);
            if (QoLCompendium.shopConfig.ECFishShop == false)
            {
                herbButton = new(buttonDeleteTexture);
            }
            fishButton.Left.Set(10, 0f);
            fishButton.Top.Set(280, 0f);
            fishButton.Width.Set(22, 0f);
            fishButton.Height.Set(22, 0f);
            fishButton.OnLeftClick += new MouseEvent(FishShopClicked);
            ShopPanel.Append(fishButton);

            UIImageButton closeButton = new(buttonDeleteTexture);
            closeButton.Left.Set(350, 0f);
            closeButton.Top.Set(10, 0f);
            closeButton.Width.Set(22, 0f);
            closeButton.Height.Set(22, 0f);
            closeButton.OnLeftClick += new MouseEvent(CloseButtonClicked);
            ShopPanel.Append(closeButton);
            Append(ShopPanel);
        }

        private void PotionShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.ECPotionShop)
            {
                EtherealCollectorNPC.shopNum = 0;
                visible = false;
            }
        }

        private void StationShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.ECStationShop)
            {
                EtherealCollectorNPC.shopNum = 1;
                visible = false;
            }
        }

        private void MaterialShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.ECMaterialShop)
            {
                EtherealCollectorNPC.shopNum = 2;
                visible = false;
            }
        }

        private void BagShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.ECBagShop)
            {
                EtherealCollectorNPC.shopNum = 3;
                visible = false;
            }
        }

        private void CrateShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.ECCrateShop)
            {
                EtherealCollectorNPC.shopNum = 4;
                visible = false;
            }
        }

        private void OreShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.ECOreShop)
            {
                EtherealCollectorNPC.shopNum = 5;
                visible = false;
            }
        }

        private void NaturalShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.ECNaturalBlocksShop)
            {
                EtherealCollectorNPC.shopNum = 6;
                visible = false;
            }
        }

        private void BuildingShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.ECBuildingBlocksShop)
            {
                EtherealCollectorNPC.shopNum = 7;
                visible = false;
            }
        }

        private void HerbShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.ECHerbShop)
            {
                EtherealCollectorNPC.shopNum = 8;
                visible = false;
            }
        }
        
        private void FishShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.ECFishShop)
            {
                EtherealCollectorNPC.shopNum = 9;
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
