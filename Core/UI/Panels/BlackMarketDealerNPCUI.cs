using QoLCompendium.Content.NPCs;

namespace QoLCompendium.Core.UI.Panels
{
    public class BlackMarketDealerNPCUI : UIState
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
            ShopPanel.Height.Set(460f, 0f);
            ShopPanel.BackgroundColor = new Color(73, 94, 171);

            ShopPanel.OnLeftMouseDown += new MouseEvent(DragStart);
            ShopPanel.OnLeftMouseUp += new MouseEvent(DragEnd);

            UIText potionText = new(UISystem.BMPotionText);
            potionText.Left.Set(35f, 0f);
            potionText.Top.Set(10f, 0f);
            potionText.Width.Set(60f, 0f);
            potionText.Height.Set(22f, 0f);
            ShopPanel.Append(potionText);

            UIText stationText = new(UISystem.BMStationText);
            stationText.Left.Set(35f, 0f);
            stationText.Top.Set(40f, 0f);
            stationText.Width.Set(60f, 0f);
            stationText.Height.Set(22f, 0f);
            ShopPanel.Append(stationText);

            UIText materialText = new(UISystem.BMMaterialText);
            materialText.Left.Set(35f, 0f);
            materialText.Top.Set(70f, 0f);
            materialText.Width.Set(60f, 0f);
            materialText.Height.Set(22f, 0f);
            ShopPanel.Append(materialText);

            UIText movementText = new(UISystem.BMMovementAccessoryText);
            movementText.Left.Set(35f, 0f);
            movementText.Top.Set(100f, 0f);
            movementText.Width.Set(60f, 0f);
            movementText.Height.Set(22f, 0f);
            ShopPanel.Append(movementText);

            UIText combatText = new(UISystem.BMCombatAccessoryText);
            combatText.Left.Set(35f, 0f);
            combatText.Top.Set(130f, 0f);
            combatText.Width.Set(60f, 0f);
            combatText.Height.Set(22f, 0f);
            ShopPanel.Append(combatText);

            UIText infoText = new(UISystem.BMInformativeText);
            infoText.Left.Set(35f, 0f);
            infoText.Top.Set(160f, 0f);
            infoText.Width.Set(60f, 0f);
            infoText.Height.Set(22f, 0f);
            ShopPanel.Append(infoText);

            UIText bagText = new(UISystem.BMBagText);
            bagText.Left.Set(35f, 0f);
            bagText.Top.Set(190f, 0f);
            bagText.Width.Set(60f, 0f);
            bagText.Height.Set(22f, 0f);
            ShopPanel.Append(bagText);

            UIText crateText = new(UISystem.BMCrateText);
            crateText.Left.Set(35f, 0f);
            crateText.Top.Set(220f, 0f);
            crateText.Width.Set(60f, 0f);
            crateText.Height.Set(22f, 0f);
            ShopPanel.Append(crateText);

            UIText oreText = new(UISystem.BMOreText);
            oreText.Left.Set(35f, 0f);
            oreText.Top.Set(250f, 0f);
            oreText.Width.Set(60f, 0f);
            oreText.Height.Set(22f, 0f);
            ShopPanel.Append(oreText);

            UIText naturalText = new(UISystem.BMNaturalBlockText);
            naturalText.Left.Set(35f, 0f);
            naturalText.Top.Set(280f, 0f);
            naturalText.Width.Set(60f, 0f);
            naturalText.Height.Set(22f, 0f);
            ShopPanel.Append(naturalText);

            UIText buildingText = new(UISystem.BMBuildingBlockText);
            buildingText.Left.Set(35f, 0f);
            buildingText.Top.Set(310f, 0f);
            buildingText.Width.Set(60f, 0f);
            buildingText.Height.Set(22f, 0f);
            ShopPanel.Append(buildingText);

            UIText herbText = new(UISystem.BMHerbText);
            herbText.Left.Set(35f, 0f);
            herbText.Top.Set(340f, 0f);
            herbText.Width.Set(60f, 0f);
            herbText.Height.Set(22f, 0f);
            ShopPanel.Append(herbText);

            UIText fishText = new(UISystem.BMFishText);
            fishText.Left.Set(35f, 0f);
            fishText.Top.Set(370f, 0f);
            fishText.Width.Set(60f, 0f);
            fishText.Height.Set(22f, 0f);
            ShopPanel.Append(fishText);

            UIText mountText = new(UISystem.BMMountText);
            mountText.Left.Set(35f, 0f);
            mountText.Top.Set(400f, 0f);
            mountText.Width.Set(60f, 0f);
            mountText.Height.Set(22f, 0f);
            ShopPanel.Append(mountText);

            UIText ammoText = new(UISystem.BMAmmoText);
            ammoText.Left.Set(35f, 0f);
            ammoText.Top.Set(430f, 0f);
            ammoText.Width.Set(30f, 0f);
            ammoText.Height.Set(22f, 0f);
            ShopPanel.Append(ammoText);

            Asset<Texture2D> buttonPlayTexture = ModContent.Request<Texture2D>("Terraria/Images/UI/ButtonPlay");
            Asset<Texture2D> buttonDeleteTexture = ModContent.Request<Texture2D>("Terraria/Images/UI/ButtonDelete");

            UIImageButton potionButton = new(buttonPlayTexture);
            if (QoLCompendium.shopConfig.BMPotionShop == false)
            {
                potionButton = new(buttonDeleteTexture);
            }
            potionButton.Left.Set(10f, 0f);
            potionButton.Top.Set(10f, 0f);
            potionButton.Width.Set(22f, 0f);
            potionButton.Height.Set(22f, 0f);
            potionButton.OnLeftClick += new MouseEvent(PotionShopClicked);
            ShopPanel.Append(potionButton);

            UIImageButton stationButton = new(buttonPlayTexture);
            if (QoLCompendium.shopConfig.BMStationShop == false)
            {
                stationButton = new(buttonDeleteTexture);
            }
            stationButton.Left.Set(10f, 0f);
            stationButton.Top.Set(40f, 0f);
            stationButton.Width.Set(22f, 0f);
            stationButton.Height.Set(22f, 0f);
            stationButton.OnLeftClick += new MouseEvent(StationShopClicked);
            ShopPanel.Append(stationButton);

            UIImageButton materialButton = new(buttonPlayTexture);
            if (QoLCompendium.shopConfig.BMMaterialShop == false)
            {
                materialButton = new(buttonDeleteTexture);
            }
            materialButton.Left.Set(10f, 0f);
            materialButton.Top.Set(70f, 0f);
            materialButton.Width.Set(22f, 0f);
            materialButton.Height.Set(22f, 0f);
            materialButton.OnLeftClick += new MouseEvent(MaterialShopClicked);
            ShopPanel.Append(materialButton);

            UIImageButton movementButton = new(buttonPlayTexture);
            if (QoLCompendium.shopConfig.BMMovementAccessoryShop == false)
            {
                movementButton = new(buttonDeleteTexture);
            }
            movementButton.Left.Set(10f, 0f);
            movementButton.Top.Set(100f, 0f);
            movementButton.Width.Set(22f, 0f);
            movementButton.Height.Set(22f, 0f);
            movementButton.OnLeftClick += new MouseEvent(MovementShopClicked);
            ShopPanel.Append(movementButton);

            UIImageButton combatButton = new(buttonPlayTexture);
            if (QoLCompendium.shopConfig.BMCombatAccessoryShop == false)
            {
                combatButton = new(buttonDeleteTexture);
            }
            combatButton.Left.Set(10f, 0f);
            combatButton.Top.Set(130f, 0f);
            combatButton.Width.Set(22f, 0f);
            combatButton.Height.Set(22f, 0f);
            combatButton.OnLeftClick += new MouseEvent(CombatShopClicked);
            ShopPanel.Append(combatButton);

            UIImageButton infoButton = new(buttonPlayTexture);
            if (QoLCompendium.shopConfig.BMInformationShop == false)
            {
                infoButton = new(buttonDeleteTexture);
            }
            infoButton.Left.Set(10f, 0f);
            infoButton.Top.Set(160f, 0f);
            infoButton.Width.Set(22f, 0f);
            infoButton.Height.Set(22f, 0f);
            infoButton.OnLeftClick += new MouseEvent(InfoShopClicked);
            ShopPanel.Append(infoButton);

            UIImageButton bagButton = new(buttonPlayTexture);
            if (QoLCompendium.shopConfig.BMBagShop == false)
            {
                bagButton = new(buttonDeleteTexture);
            }
            bagButton.Left.Set(10f, 0f);
            bagButton.Top.Set(190f, 0f);
            bagButton.Width.Set(22f, 0f);
            bagButton.Height.Set(22f, 0f);
            bagButton.OnLeftClick += new MouseEvent(BagShopClicked);
            ShopPanel.Append(bagButton);

            UIImageButton crateButton = new(buttonPlayTexture);
            if (QoLCompendium.shopConfig.BMCrateShop == false)
            {
                crateButton = new(buttonDeleteTexture);
            }
            crateButton.Left.Set(10f, 0f);
            crateButton.Top.Set(220f, 0f);
            crateButton.Width.Set(22f, 0f);
            crateButton.Height.Set(22f, 0f);
            crateButton.OnLeftClick += new MouseEvent(CrateShopClicked);
            ShopPanel.Append(crateButton);

            UIImageButton oreButton = new(buttonPlayTexture);
            if (QoLCompendium.shopConfig.BMOreShop == false)
            {
                oreButton = new(buttonDeleteTexture);
            }
            oreButton.Left.Set(10f, 0f);
            oreButton.Top.Set(250f, 0f);
            oreButton.Width.Set(22f, 0f);
            oreButton.Height.Set(22f, 0f);
            oreButton.OnLeftClick += new MouseEvent(OreShopClicked);
            ShopPanel.Append(oreButton);

            UIImageButton naturalButton = new(buttonPlayTexture);
            if (QoLCompendium.shopConfig.BMNaturalBlockShop == false)
            {
                naturalButton = new(buttonDeleteTexture);
            }
            naturalButton.Left.Set(10f, 0f);
            naturalButton.Top.Set(280f, 0f);
            naturalButton.Width.Set(22f, 0f);
            naturalButton.Height.Set(22f, 0f);
            naturalButton.OnLeftClick += new MouseEvent(NaturalShopClicked);
            ShopPanel.Append(naturalButton);

            UIImageButton buildingButton = new(buttonPlayTexture);
            if (QoLCompendium.shopConfig.BMBuildingBlockShop == false)
            {
                buildingButton = new(buttonDeleteTexture);
            }
            buildingButton.Left.Set(10f, 0f);
            buildingButton.Top.Set(310f, 0f);
            buildingButton.Width.Set(22f, 0f);
            buildingButton.Height.Set(22f, 0f);
            buildingButton.OnLeftClick += new MouseEvent(BuildingShopClicked);
            ShopPanel.Append(buildingButton);

            UIImageButton herbButton = new(buttonPlayTexture);
            if (QoLCompendium.shopConfig.BMHerbShop == false)
            {
                herbButton = new(buttonDeleteTexture);
            }
            herbButton.Left.Set(10f, 0f);
            herbButton.Top.Set(340f, 0f);
            herbButton.Width.Set(22f, 0f);
            herbButton.Height.Set(22f, 0f);
            herbButton.OnLeftClick += new MouseEvent(HerbShopClicked);
            ShopPanel.Append(herbButton);

            UIImageButton fishButton = new(buttonPlayTexture);
            if (QoLCompendium.shopConfig.BMFishShop == false)
            {
                fishButton = new(buttonDeleteTexture);
            }
            fishButton.Left.Set(10f, 0f);
            fishButton.Top.Set(370f, 0f);
            fishButton.Width.Set(22f, 0f);
            fishButton.Height.Set(22f, 0f);
            fishButton.OnLeftClick += new MouseEvent(FishShopClicked);
            ShopPanel.Append(fishButton);

            UIImageButton mountButton = new(buttonPlayTexture);
            if (QoLCompendium.shopConfig.BMMountShop == false)
            {
                mountButton = new(buttonDeleteTexture);
            }
            mountButton.Left.Set(10f, 0f);
            mountButton.Top.Set(400f, 0f);
            mountButton.Width.Set(22f, 0f);
            mountButton.Height.Set(22f, 0f);
            mountButton.OnLeftClick += new MouseEvent(MountShopClicked);
            ShopPanel.Append(mountButton);

            UIImageButton ammoButton = new(buttonPlayTexture);
            if (QoLCompendium.shopConfig.BMAmmoShop == false)
            {
                ammoButton = new(buttonDeleteTexture);
            }
            ammoButton.Left.Set(10f, 0f);
            ammoButton.Top.Set(430f, 0f);
            ammoButton.Width.Set(22f, 0f);
            ammoButton.Height.Set(22f, 0f);
            ammoButton.OnLeftClick += new MouseEvent(AmmoShopClicked);
            ShopPanel.Append(ammoButton);

            UIImageButton closeButton = new(buttonDeleteTexture);
            closeButton.Left.Set(350f, 0f);
            closeButton.Top.Set(10f, 0f);
            closeButton.Width.Set(22f, 0f);
            closeButton.Height.Set(22f, 0f);
            closeButton.OnLeftClick += new MouseEvent(CloseButtonClicked);
            ShopPanel.Append(closeButton);
            Append(ShopPanel);
        }

        private void PotionShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMPotionShop)
            {
                BMDealerNPC.shopNum = 0;
                visible = false;
            }
        }

        private void StationShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMStationShop)
            {
                BMDealerNPC.shopNum = 1;
                visible = false;
            }
        }

        private void MaterialShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMMaterialShop)
            {
                BMDealerNPC.shopNum = 2;
                visible = false;
            }
        }

        private void MovementShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMMovementAccessoryShop)
            {
                BMDealerNPC.shopNum = 3;
                visible = false;
            }
        }

        private void CombatShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMCombatAccessoryShop)
            {
                BMDealerNPC.shopNum = 4;
                visible = false;
            }
        }

        private void InfoShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMInformationShop)
            {
                BMDealerNPC.shopNum = 5;
                visible = false;
            }
        }

        private void BagShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMBagShop)
            {
                BMDealerNPC.shopNum = 6;
                visible = false;
            }
        }

        private void CrateShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMCrateShop)
            {
                BMDealerNPC.shopNum = 7;
                visible = false;
            }
        }

        private void OreShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMOreShop)
            {
                BMDealerNPC.shopNum = 8;
                visible = false;
            }
        }

        private void NaturalShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMNaturalBlockShop)
            {
                BMDealerNPC.shopNum = 9;
                visible = false;
            }
        }

        private void BuildingShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMBuildingBlockShop)
            {
                BMDealerNPC.shopNum = 10;
                visible = false;
            }
        }

        private void HerbShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMHerbShop)
            {
                BMDealerNPC.shopNum = 11;
                visible = false;
            }
        }

        private void FishShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMFishShop)
            {
                BMDealerNPC.shopNum = 12;
                visible = false;
            }
        }

        private void MountShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMMountShop)
            {
                BMDealerNPC.shopNum = 13;
                visible = false;
            }
        }

        private void AmmoShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMAmmoShop)
            {
                BMDealerNPC.shopNum = 14;
                visible = false;
            }
        }

        private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                SoundEngine.PlaySound(SoundID.MenuClose);
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
