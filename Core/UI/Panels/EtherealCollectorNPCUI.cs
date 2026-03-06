using QoLCompendium.Content.NPCs;

namespace QoLCompendium.Core.UI.Panels
{
    public class EtherealCollectorNPCUI : UIState
    {
        public UIPanel ShopPanel;
        public static bool visible = false;
        public static uint timeStart;

        public UIImageButton PotionButton;
        public UIImageButton StationButton;
        public UIImageButton MaterialButton;
        public UIImageButton MaterialButton2;
        public UIImageButton MobilityAccessoryButton;
        public UIImageButton CombatAccessoryButton;
        public UIImageButton ToolsAndInfoButton;
        public UIImageButton TreasureBagButton;
        public UIImageButton CratesAndGrabBagsButton;
        public UIImageButton OresAndBarsButton;
        public UIImageButton NaturalBlocksButton;
        public UIImageButton BuildingBlocksButton;
        public UIImageButton HerbsAndPlantsButton;
        public UIImageButton FishButton;
        public UIImageButton CritterButton;
        public UIImageButton MountsAndHooksButton;
        public UIImageButton AmmoButton;

        public override void OnInitialize()
        {
            ShopPanel = new UIPanel();
            ShopPanel.SetPadding(0);
            ShopPanel.Left.Set(575f, 0f);
            ShopPanel.Top.Set(300f, 0f);
            ShopPanel.Width.Set(385f, 0f);
            ShopPanel.Height.Set(340f, 0f);
            ShopPanel.BackgroundColor = new Color(73, 94, 171);

            ShopPanel.OnLeftMouseDown += new MouseEvent(DragStart);
            ShopPanel.OnLeftMouseUp += new MouseEvent(DragEnd);

            UIText potionText = new(UISystem.ECPotionText);
            potionText.Left.Set(35, 0f);
            potionText.Top.Set(10, 0f);
            potionText.Width.Set(60, 0f);
            potionText.Height.Set(22, 0f);
            ShopPanel.Append(potionText);

            UIText stationText = new(UISystem.ECStationText);
            stationText.Left.Set(35, 0f);
            stationText.Top.Set(40, 0f);
            stationText.Width.Set(60, 0f);
            stationText.Height.Set(22, 0f);
            ShopPanel.Append(stationText);

            UIText materialText = new(UISystem.ECMaterialText);
            materialText.Left.Set(35, 0f);
            materialText.Top.Set(70, 0f);
            materialText.Width.Set(60, 0f);
            materialText.Height.Set(22, 0f);
            ShopPanel.Append(materialText);

            UIText material2Text = new(UISystem.ECMaterial2Text);
            material2Text.Left.Set(35, 0f);
            material2Text.Top.Set(100, 0f);
            material2Text.Width.Set(60, 0f);
            material2Text.Height.Set(22, 0f);
            ShopPanel.Append(material2Text);

            UIText bagText = new(UISystem.ECBagText);
            bagText.Left.Set(35, 0f);
            bagText.Top.Set(130, 0f);
            bagText.Width.Set(60, 0f);
            bagText.Height.Set(22, 0f);
            ShopPanel.Append(bagText);

            UIText crateText = new(UISystem.ECCrateText);
            crateText.Left.Set(35, 0f);
            crateText.Top.Set(160, 0f);
            crateText.Width.Set(60, 0f);
            crateText.Height.Set(22, 0f);
            ShopPanel.Append(crateText);

            UIText oreText = new(UISystem.ECOreText);
            oreText.Left.Set(35, 0f);
            oreText.Top.Set(190, 0f);
            oreText.Width.Set(60, 0f);
            oreText.Height.Set(22, 0f);
            ShopPanel.Append(oreText);

            UIText naturalText = new(UISystem.ECNaturalBlockText);
            naturalText.Left.Set(35, 0f);
            naturalText.Top.Set(220, 0f);
            naturalText.Width.Set(60, 0f);
            naturalText.Height.Set(22, 0f);
            ShopPanel.Append(naturalText);

            UIText buildingText = new(UISystem.ECBuildingBlockText);
            buildingText.Left.Set(35, 0f);
            buildingText.Top.Set(250, 0f);
            buildingText.Width.Set(60, 0f);
            buildingText.Height.Set(22, 0f);
            ShopPanel.Append(buildingText);

            UIText herbText = new(UISystem.ECHerbText);
            herbText.Left.Set(35, 0f);
            herbText.Top.Set(280, 0f);
            herbText.Width.Set(60, 0f);
            herbText.Height.Set(22, 0f);
            ShopPanel.Append(herbText);

            UIText fishText = new(UISystem.ECFishText);
            fishText.Left.Set(35, 0f);
            fishText.Top.Set(310, 0f);
            fishText.Width.Set(60, 0f);
            fishText.Height.Set(22, 0f);
            ShopPanel.Append(fishText);

            Asset<Texture2D> buttonPlayTexture = ModContent.Request<Texture2D>("Terraria/Images/UI/ButtonPlay");
            Asset<Texture2D> buttonDeleteTexture = ModContent.Request<Texture2D>("Terraria/Images/UI/ButtonDelete");

            PotionButton = new(buttonPlayTexture);
            PotionButton.Left.Set(10, 0f);
            PotionButton.Top.Set(10, 0f);
            PotionButton.Width.Set(22, 0f);
            PotionButton.Height.Set(22, 0f);
            PotionButton.OnLeftClick += new MouseEvent(PotionShopClicked);
            ShopPanel.Append(PotionButton);

            StationButton = new(buttonPlayTexture);
            StationButton.Left.Set(10, 0f);
            StationButton.Top.Set(40, 0f);
            StationButton.Width.Set(22, 0f);
            StationButton.Height.Set(22, 0f);
            StationButton.OnLeftClick += new MouseEvent(StationShopClicked);
            ShopPanel.Append(StationButton);

            MaterialButton = new(buttonPlayTexture);
            MaterialButton.Left.Set(10, 0f);
            MaterialButton.Top.Set(70, 0f);
            MaterialButton.Width.Set(22, 0f);
            MaterialButton.Height.Set(22, 0f);
            MaterialButton.OnLeftClick += new MouseEvent(MaterialShopClicked);
            ShopPanel.Append(MaterialButton);

            MaterialButton2 = new(buttonPlayTexture);
            MaterialButton2.Left.Set(10, 0f);
            MaterialButton2.Top.Set(100, 0f);
            MaterialButton2.Width.Set(22, 0f);
            MaterialButton2.Height.Set(22, 0f);
            MaterialButton2.OnLeftClick += new MouseEvent(Material2ShopClicked);
            ShopPanel.Append(MaterialButton2);

            TreasureBagButton = new(buttonPlayTexture);
            TreasureBagButton.Left.Set(10, 0f);
            TreasureBagButton.Top.Set(130, 0f);
            TreasureBagButton.Width.Set(22, 0f);
            TreasureBagButton.Height.Set(22, 0f);
            TreasureBagButton.OnLeftClick += new MouseEvent(BagShopClicked);
            ShopPanel.Append(TreasureBagButton);

            CratesAndGrabBagsButton = new(buttonPlayTexture);
            CratesAndGrabBagsButton.Left.Set(10, 0f);
            CratesAndGrabBagsButton.Top.Set(160, 0f);
            CratesAndGrabBagsButton.Width.Set(22, 0f);
            CratesAndGrabBagsButton.Height.Set(22, 0f);
            CratesAndGrabBagsButton.OnLeftClick += new MouseEvent(CrateShopClicked);
            ShopPanel.Append(CratesAndGrabBagsButton);

            OresAndBarsButton = new(buttonPlayTexture);
            OresAndBarsButton.Left.Set(10, 0f);
            OresAndBarsButton.Top.Set(190, 0f);
            OresAndBarsButton.Width.Set(22, 0f);
            OresAndBarsButton.Height.Set(22, 0f);
            OresAndBarsButton.OnLeftClick += new MouseEvent(OreShopClicked);
            ShopPanel.Append(OresAndBarsButton);

            NaturalBlocksButton = new(buttonPlayTexture);
            NaturalBlocksButton.Left.Set(10, 0f);
            NaturalBlocksButton.Top.Set(220, 0f);
            NaturalBlocksButton.Width.Set(22, 0f);
            NaturalBlocksButton.Height.Set(22, 0f);
            NaturalBlocksButton.OnLeftClick += new MouseEvent(NaturalShopClicked);
            ShopPanel.Append(NaturalBlocksButton);

            BuildingBlocksButton = new(buttonPlayTexture);
            BuildingBlocksButton.Left.Set(10, 0f);
            BuildingBlocksButton.Top.Set(250, 0f);
            BuildingBlocksButton.Width.Set(22, 0f);
            BuildingBlocksButton.Height.Set(22, 0f);
            BuildingBlocksButton.OnLeftClick += new MouseEvent(BuildingShopClicked);
            ShopPanel.Append(BuildingBlocksButton);

            HerbsAndPlantsButton = new(buttonPlayTexture);
            HerbsAndPlantsButton.Left.Set(10, 0f);
            HerbsAndPlantsButton.Top.Set(280, 0f);
            HerbsAndPlantsButton.Width.Set(22, 0f);
            HerbsAndPlantsButton.Height.Set(22, 0f);
            HerbsAndPlantsButton.OnLeftClick += new MouseEvent(HerbShopClicked);
            ShopPanel.Append(HerbsAndPlantsButton);

            FishButton = new(buttonPlayTexture);
            FishButton.Left.Set(10, 0f);
            FishButton.Top.Set(310, 0f);
            FishButton.Width.Set(22, 0f);
            FishButton.Height.Set(22, 0f);
            FishButton.OnLeftClick += new MouseEvent(FishShopClicked);
            ShopPanel.Append(FishButton);

            UIImageButton closeButton = new(buttonDeleteTexture);
            closeButton.Left.Set(350, 0f);
            closeButton.Top.Set(10, 0f);
            closeButton.Width.Set(22, 0f);
            closeButton.Height.Set(22, 0f);
            closeButton.OnLeftClick += new MouseEvent(CloseButtonClicked);
            ShopPanel.Append(closeButton);
            Append(ShopPanel);
        }

        public override void Update(GameTime gameTime)
        {
            if (visible)
            {
                Asset<Texture2D> buttonPlayTexture = ModContent.Request<Texture2D>("Terraria/Images/UI/ButtonPlay");
                Asset<Texture2D> buttonDeleteTexture = ModContent.Request<Texture2D>("Terraria/Images/UI/ButtonDelete");

                PotionButton.SetImage(QoLCompendium.shopConfig.ECPotionShop ? buttonPlayTexture : buttonDeleteTexture);
                StationButton.SetImage(QoLCompendium.shopConfig.ECStationShop ? buttonPlayTexture : buttonDeleteTexture);
                MaterialButton.SetImage(QoLCompendium.shopConfig.ECMaterialShop ? buttonPlayTexture : buttonDeleteTexture);
                MaterialButton2.SetImage(QoLCompendium.shopConfig.ECMaterialShop ? buttonPlayTexture : buttonDeleteTexture);

                //MobilityAccessoryButton.SetImage(QoLCompendium.shopConfig.ECMovementAccessoryShop ? buttonPlayTexture : buttonDeleteTexture);
                //CombatAccessoryButton.SetImage(QoLCompendium.shopConfig.ECCombatAccessoryShop ? buttonPlayTexture : buttonDeleteTexture);
                //ToolsAndInfoButton.SetImage(QoLCompendium.shopConfig.ECInformationShop ? buttonPlayTexture : buttonDeleteTexture);

                TreasureBagButton.SetImage(QoLCompendium.shopConfig.ECBagShop ? buttonPlayTexture : buttonDeleteTexture);
                CratesAndGrabBagsButton.SetImage(QoLCompendium.shopConfig.ECCrateShop ? buttonPlayTexture : buttonDeleteTexture);
                OresAndBarsButton.SetImage(QoLCompendium.shopConfig.ECOreShop ? buttonPlayTexture : buttonDeleteTexture);
                NaturalBlocksButton.SetImage(QoLCompendium.shopConfig.ECNaturalBlocksShop ? buttonPlayTexture : buttonDeleteTexture);
                BuildingBlocksButton.SetImage(QoLCompendium.shopConfig.ECBuildingBlocksShop ? buttonPlayTexture : buttonDeleteTexture);
                HerbsAndPlantsButton.SetImage(QoLCompendium.shopConfig.ECHerbShop ? buttonPlayTexture : buttonDeleteTexture);
                FishButton.SetImage(QoLCompendium.shopConfig.ECFishShop ? buttonPlayTexture : buttonDeleteTexture);
                
                //CritterButton.SetImage(QoLCompendium.shopConfig.ECCritterShop ? buttonPlayTexture : buttonDeleteTexture);
                //MountsAndHooksButton.SetImage(QoLCompendium.shopConfig.ECMountShop ? buttonPlayTexture : buttonDeleteTexture);
                //AmmoButton.SetImage(QoLCompendium.shopConfig.ECAmmoShop ? buttonPlayTexture : buttonDeleteTexture);
            }
        }

        private void PotionShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.ECPotionShop)
            {
                EtherealCollectorNPC.shopNum = (int)EtherealCollectorNPC.ShopType.ModdedPotionShop;
                visible = false;
            }
        }

        private void StationShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.ECStationShop)
            {
                EtherealCollectorNPC.shopNum = (int)EtherealCollectorNPC.ShopType.ModdedStationsAndUpgradesShop;
                visible = false;
            }
        }

        private void MaterialShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.ECMaterialShop)
            {
                EtherealCollectorNPC.shopNum = (int)EtherealCollectorNPC.ShopType.ModdedMaterialShop;
                visible = false;
            }
        }

        private void Material2ShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.ECMaterialShop)
            {
                EtherealCollectorNPC.shopNum = (int)EtherealCollectorNPC.ShopType.ModdedMaterialShop2;
                visible = false;
            }
        }

        private void BagShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.ECBagShop)
            {
                EtherealCollectorNPC.shopNum = (int)EtherealCollectorNPC.ShopType.ModdedTreasureBagShop;
                visible = false;
            }
        }

        private void CrateShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.ECCrateShop)
            {
                EtherealCollectorNPC.shopNum = (int)EtherealCollectorNPC.ShopType.ModdedCratesAndGrabBagsShop;
                visible = false;
            }
        }

        private void OreShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.ECOreShop)
            {
                EtherealCollectorNPC.shopNum = (int)EtherealCollectorNPC.ShopType.ModdedOresAndBarsShop;
                visible = false;
            }
        }

        private void NaturalShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.ECNaturalBlocksShop)
            {
                EtherealCollectorNPC.shopNum = (int)EtherealCollectorNPC.ShopType.ModdedNaturalBlockShop;
                visible = false;
            }
        }

        private void BuildingShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.ECBuildingBlocksShop)
            {
                EtherealCollectorNPC.shopNum = (int)EtherealCollectorNPC.ShopType.ModdedBuildingBlockShop;
                visible = false;
            }
        }

        private void HerbShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.ECHerbShop)
            {
                EtherealCollectorNPC.shopNum = (int)EtherealCollectorNPC.ShopType.ModdedHerbsAndPlantsShop;
                visible = false;
            }
        }

        private void FishShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.ECFishShop)
            {
                EtherealCollectorNPC.shopNum = (int)EtherealCollectorNPC.ShopType.ModdedFishShop;
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
