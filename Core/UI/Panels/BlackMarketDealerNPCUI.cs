using QoLCompendium.Content.NPCs;

namespace QoLCompendium.Core.UI.Panels
{
    public class BlackMarketDealerNPCUI : UIState
    {
        public UIPanel ShopPanel;
        public static bool visible = false;
        public static uint timeStart;

        public UIImageButton PotionButton;
        public UIImageButton StationButton;
        public UIImageButton MaterialButton;
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
            ShopPanel.Top.Set(275f, 0f);
            ShopPanel.Width.Set(385f, 0f);
            ShopPanel.Height.Set(490f, 0f);
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
            fishText.Width.Set(30f, 0f);
            fishText.Height.Set(22f, 0f);
            ShopPanel.Append(fishText);

            UIText critterText = new(UISystem.BMCritterText);
            critterText.Left.Set(35f, 0f);
            critterText.Top.Set(400f, 0f);
            critterText.Width.Set(60f, 0f);
            critterText.Height.Set(22f, 0f);
            ShopPanel.Append(critterText);

            UIText mountText = new(UISystem.BMMountText);
            mountText.Left.Set(35f, 0f);
            mountText.Top.Set(430f, 0f);
            mountText.Width.Set(30f, 0f);
            mountText.Height.Set(22f, 0f);
            ShopPanel.Append(mountText);

            UIText ammoText = new(UISystem.BMAmmoText);
            ammoText.Left.Set(35f, 0f);
            ammoText.Top.Set(460f, 0f);
            ammoText.Width.Set(30f, 0f);
            ammoText.Height.Set(22f, 0f);
            ShopPanel.Append(ammoText);

            Asset<Texture2D> buttonPlayTexture = ModContent.Request<Texture2D>("Terraria/Images/UI/ButtonPlay");
            Asset<Texture2D> buttonDeleteTexture = ModContent.Request<Texture2D>("Terraria/Images/UI/ButtonDelete");

            PotionButton = new(buttonPlayTexture);
            PotionButton.Left.Set(10f, 0f);
            PotionButton.Top.Set(10f, 0f);
            PotionButton.Width.Set(22f, 0f);
            PotionButton.Height.Set(22f, 0f);
            PotionButton.OnLeftClick += new MouseEvent(PotionShopClicked);
            ShopPanel.Append(PotionButton);

            StationButton = new(buttonPlayTexture);
            StationButton.Left.Set(10f, 0f);
            StationButton.Top.Set(40f, 0f);
            StationButton.Width.Set(22f, 0f);
            StationButton.Height.Set(22f, 0f);
            StationButton.OnLeftClick += new MouseEvent(StationShopClicked);
            ShopPanel.Append(StationButton);

            MaterialButton = new(buttonPlayTexture);
            MaterialButton.Left.Set(10f, 0f);
            MaterialButton.Top.Set(70f, 0f);
            MaterialButton.Width.Set(22f, 0f);
            MaterialButton.Height.Set(22f, 0f);
            MaterialButton.OnLeftClick += new MouseEvent(MaterialShopClicked);
            ShopPanel.Append(MaterialButton);

            MobilityAccessoryButton = new(buttonPlayTexture);
            MobilityAccessoryButton.Left.Set(10f, 0f);
            MobilityAccessoryButton.Top.Set(100f, 0f);
            MobilityAccessoryButton.Width.Set(22f, 0f);
            MobilityAccessoryButton.Height.Set(22f, 0f);
            MobilityAccessoryButton.OnLeftClick += new MouseEvent(MovementShopClicked);
            ShopPanel.Append(MobilityAccessoryButton);

            CombatAccessoryButton = new(buttonPlayTexture);
            CombatAccessoryButton.Left.Set(10f, 0f);
            CombatAccessoryButton.Top.Set(130f, 0f);
            CombatAccessoryButton.Width.Set(22f, 0f);
            CombatAccessoryButton.Height.Set(22f, 0f);
            CombatAccessoryButton.OnLeftClick += new MouseEvent(CombatShopClicked);
            ShopPanel.Append(CombatAccessoryButton);

            ToolsAndInfoButton = new(buttonPlayTexture);
            ToolsAndInfoButton.Left.Set(10f, 0f);
            ToolsAndInfoButton.Top.Set(160f, 0f);
            ToolsAndInfoButton.Width.Set(22f, 0f);
            ToolsAndInfoButton.Height.Set(22f, 0f);
            ToolsAndInfoButton.OnLeftClick += new MouseEvent(InfoShopClicked);
            ShopPanel.Append(ToolsAndInfoButton);

            TreasureBagButton = new(buttonPlayTexture);
            TreasureBagButton.Left.Set(10f, 0f);
            TreasureBagButton.Top.Set(190f, 0f);
            TreasureBagButton.Width.Set(22f, 0f);
            TreasureBagButton.Height.Set(22f, 0f);
            TreasureBagButton.OnLeftClick += new MouseEvent(BagShopClicked);
            ShopPanel.Append(TreasureBagButton);

            CratesAndGrabBagsButton = new(buttonPlayTexture);
            CratesAndGrabBagsButton.Left.Set(10f, 0f);
            CratesAndGrabBagsButton.Top.Set(220f, 0f);
            CratesAndGrabBagsButton.Width.Set(22f, 0f);
            CratesAndGrabBagsButton.Height.Set(22f, 0f);
            CratesAndGrabBagsButton.OnLeftClick += new MouseEvent(CrateShopClicked);
            ShopPanel.Append(CratesAndGrabBagsButton);

            OresAndBarsButton = new(buttonPlayTexture);
            OresAndBarsButton.Left.Set(10f, 0f);
            OresAndBarsButton.Top.Set(250f, 0f);
            OresAndBarsButton.Width.Set(22f, 0f);
            OresAndBarsButton.Height.Set(22f, 0f);
            OresAndBarsButton.OnLeftClick += new MouseEvent(OreShopClicked);
            ShopPanel.Append(OresAndBarsButton);

            NaturalBlocksButton = new(buttonPlayTexture);
            NaturalBlocksButton.Left.Set(10f, 0f);
            NaturalBlocksButton.Top.Set(280f, 0f);
            NaturalBlocksButton.Width.Set(22f, 0f);
            NaturalBlocksButton.Height.Set(22f, 0f);
            NaturalBlocksButton.OnLeftClick += new MouseEvent(NaturalShopClicked);
            ShopPanel.Append(NaturalBlocksButton);

            BuildingBlocksButton = new(buttonPlayTexture);
            BuildingBlocksButton.Left.Set(10f, 0f);
            BuildingBlocksButton.Top.Set(310f, 0f);
            BuildingBlocksButton.Width.Set(22f, 0f);
            BuildingBlocksButton.Height.Set(22f, 0f);
            BuildingBlocksButton.OnLeftClick += new MouseEvent(BuildingShopClicked);
            ShopPanel.Append(BuildingBlocksButton);

            HerbsAndPlantsButton = new(buttonPlayTexture);
            HerbsAndPlantsButton.Left.Set(10f, 0f);
            HerbsAndPlantsButton.Top.Set(340f, 0f);
            HerbsAndPlantsButton.Width.Set(22f, 0f);
            HerbsAndPlantsButton.Height.Set(22f, 0f);
            HerbsAndPlantsButton.OnLeftClick += new MouseEvent(HerbShopClicked);
            ShopPanel.Append(HerbsAndPlantsButton);

            FishButton = new(buttonPlayTexture);
            FishButton.Left.Set(10f, 0f);
            FishButton.Top.Set(370f, 0f);
            FishButton.Width.Set(22f, 0f);
            FishButton.Height.Set(22f, 0f);
            FishButton.OnLeftClick += new MouseEvent(FishShopClicked);
            ShopPanel.Append(FishButton);

            CritterButton = new(buttonPlayTexture);
            CritterButton.Left.Set(10f, 0f);
            CritterButton.Top.Set(400f, 0f);
            CritterButton.Width.Set(22f, 0f);
            CritterButton.Height.Set(22f, 0f);
            CritterButton.OnLeftClick += new MouseEvent(CritterShopClicked);
            ShopPanel.Append(CritterButton);

            MountsAndHooksButton = new(buttonPlayTexture);
            MountsAndHooksButton.Left.Set(10f, 0f);
            MountsAndHooksButton.Top.Set(430f, 0f);
            MountsAndHooksButton.Width.Set(22f, 0f);
            MountsAndHooksButton.Height.Set(22f, 0f);
            MountsAndHooksButton.OnLeftClick += new MouseEvent(MountShopClicked);
            ShopPanel.Append(MountsAndHooksButton);

            AmmoButton = new(buttonPlayTexture);
            AmmoButton.Left.Set(10f, 0f);
            AmmoButton.Top.Set(460f, 0f);
            AmmoButton.Width.Set(22f, 0f);
            AmmoButton.Height.Set(22f, 0f);
            AmmoButton.OnLeftClick += new MouseEvent(AmmoShopClicked);
            ShopPanel.Append(AmmoButton);

            UIImageButton closeButton = new(buttonDeleteTexture);
            closeButton.Left.Set(350f, 0f);
            closeButton.Top.Set(10f, 0f);
            closeButton.Width.Set(22f, 0f);
            closeButton.Height.Set(22f, 0f);
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

                PotionButton.SetImage(QoLCompendium.shopConfig.BMPotionShop ? buttonPlayTexture : buttonDeleteTexture);
                StationButton.SetImage(QoLCompendium.shopConfig.BMStationShop ? buttonPlayTexture : buttonDeleteTexture);
                MaterialButton.SetImage(QoLCompendium.shopConfig.BMMaterialShop ? buttonPlayTexture : buttonDeleteTexture);
                MobilityAccessoryButton.SetImage(QoLCompendium.shopConfig.BMMovementAccessoryShop ? buttonPlayTexture : buttonDeleteTexture);
                CombatAccessoryButton.SetImage(QoLCompendium.shopConfig.BMCombatAccessoryShop ? buttonPlayTexture : buttonDeleteTexture);
                ToolsAndInfoButton.SetImage(QoLCompendium.shopConfig.BMInformationShop ? buttonPlayTexture : buttonDeleteTexture);
                TreasureBagButton.SetImage(QoLCompendium.shopConfig.BMBagShop ? buttonPlayTexture : buttonDeleteTexture);
                CratesAndGrabBagsButton.SetImage(QoLCompendium.shopConfig.BMCrateShop ? buttonPlayTexture : buttonDeleteTexture);
                OresAndBarsButton.SetImage(QoLCompendium.shopConfig.BMOreShop ? buttonPlayTexture : buttonDeleteTexture);
                NaturalBlocksButton.SetImage(QoLCompendium.shopConfig.BMNaturalBlockShop ? buttonPlayTexture : buttonDeleteTexture);
                BuildingBlocksButton.SetImage(QoLCompendium.shopConfig.BMBuildingBlockShop ? buttonPlayTexture : buttonDeleteTexture);
                HerbsAndPlantsButton.SetImage(QoLCompendium.shopConfig.BMHerbShop ? buttonPlayTexture : buttonDeleteTexture);
                FishButton.SetImage(QoLCompendium.shopConfig.BMFishShop ? buttonPlayTexture : buttonDeleteTexture);
                CritterButton.SetImage(QoLCompendium.shopConfig.BMCritterShop ? buttonPlayTexture : buttonDeleteTexture);
                MountsAndHooksButton.SetImage(QoLCompendium.shopConfig.BMMountShop ? buttonPlayTexture : buttonDeleteTexture);
                AmmoButton.SetImage(QoLCompendium.shopConfig.BMAmmoShop ? buttonPlayTexture : buttonDeleteTexture);
            }
        }

        private void PotionShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMPotionShop)
            {
                BMDealerNPC.shopNum = (int)BMDealerNPC.ShopType.PotionShop;
                visible = false;
            }
        }

        private void StationShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMStationShop)
            {
                BMDealerNPC.shopNum = (int)BMDealerNPC.ShopType.StationsAndUpgradesShop;
                visible = false;
            }
        }

        private void MaterialShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMMaterialShop)
            {
                BMDealerNPC.shopNum = (int)BMDealerNPC.ShopType.MaterialShop;
                visible = false;
            }
        }

        private void MovementShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMMovementAccessoryShop)
            {
                BMDealerNPC.shopNum = (int)BMDealerNPC.ShopType.MobilityAccessoryShop;
                visible = false;
            }
        }

        private void CombatShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMCombatAccessoryShop)
            {
                BMDealerNPC.shopNum = (int)BMDealerNPC.ShopType.CombatAccessoryShop;
                visible = false;
            }
        }

        private void InfoShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMInformationShop)
            {
                BMDealerNPC.shopNum = (int)BMDealerNPC.ShopType.ToolsAndInfoShop;
                visible = false;
            }
        }

        private void BagShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMBagShop)
            {
                BMDealerNPC.shopNum = (int)BMDealerNPC.ShopType.TreasureBagShop;
                visible = false;
            }
        }

        private void CrateShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMCrateShop)
            {
                BMDealerNPC.shopNum = (int)BMDealerNPC.ShopType.CratesAndGrabBagsShop;
                visible = false;
            }
        }

        private void OreShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMOreShop)
            {
                BMDealerNPC.shopNum = (int)BMDealerNPC.ShopType.OresAndBarsShop;
                visible = false;
            }
        }

        private void NaturalShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMNaturalBlockShop)
            {
                BMDealerNPC.shopNum = (int)BMDealerNPC.ShopType.NaturalBlockShop;
                visible = false;
            }
        }

        private void BuildingShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMBuildingBlockShop)
            {
                BMDealerNPC.shopNum = (int)BMDealerNPC.ShopType.BuildingBlockShop;
                visible = false;
            }
        }

        private void HerbShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMHerbShop)
            {
                BMDealerNPC.shopNum = (int)BMDealerNPC.ShopType.HerbsAndPlantsShop;
                visible = false;
            }
        }

        private void FishShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMFishShop)
            {
                BMDealerNPC.shopNum = (int)BMDealerNPC.ShopType.FishShop;
                visible = false;
            }
        }

        private void CritterShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMCritterShop)
            {
                BMDealerNPC.shopNum = (int)BMDealerNPC.ShopType.CritterShop;
                visible = false;
            }
        }

        private void MountShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMMountShop)
            {
                BMDealerNPC.shopNum = (int)BMDealerNPC.ShopType.MountsAndHooksShop;
                visible = false;
            }
        }

        private void AmmoShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10 && QoLCompendium.shopConfig.BMAmmoShop)
            {
                BMDealerNPC.shopNum = (int)BMDealerNPC.ShopType.AmmoShop;
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
