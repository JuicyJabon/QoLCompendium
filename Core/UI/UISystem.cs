using QoLCompendium.Core.UI.Panels;

namespace QoLCompendium.Core.UI
{
    public class UISystem : ModSystem
    {
        public GameTime oldUiGameTime;

        //Black Market Dealer UI
        public BlackMarketDealerNPCUI blackMarketDealerNPCShopUI;
        public UserInterface blackMarketDealerNPCInterface;

        //Ethereal Collector UI
        public EtherealCollectorNPCUI etherealCollectorNPCShopUI;
        public UserInterface etherealCollectorNPCInterface;

        //All In One Access UI
        public AllInOneAccessUI allInOneAccessUI;
        public UserInterface allInOneAccessInterface;

        //Destination Globe UI
        public DestinationGlobeUI destinationGlobeUI;
        public UserInterface destinationGlobeInterface;

        //Entity Manipulator UI
        public EntityManipulatorUI entityManipulatorUI;
        public UserInterface entityManipulatorInterface;

        //Phase Interrupter UI
        public PhaseInterrupterUI phaseInterrupterUI;
        public UserInterface phaseInterrupterInterface;

        //Summoning Remote UI
        public SummoningRemoteUI summoningRemoteUI;
        public UserInterface summoningRemoteInterface;

        //Permanent Buff Selector UI
        public PermanentBuffSelectorUI permanentBuffSelectorUI;
        public UserInterface permanentBuffSelectorInterface;

        //Permanent Buff UI
        public PermanentBuffUI permanentBuffUI;
        public UserInterface permanentBuffInterface;

        //Permanent Calamity Buff UI
        public PermanentCalamityBuffUI permanentCalamityBuffUI;
        public UserInterface permanentCalamityBuffInterface;

        //Permanent Martin's Order Buff UI
        public PermanentMartinsOrderBuffUI permanentMartinsOrderBuffUI;
        public UserInterface permanentMartinsOrderBuffInterface;

        //Permanent Spirit Classic Buff UI
        public PermanentSpiritClassicBuffUI permanentSpiritClassicBuffUI;
        public UserInterface permanentSpiritClassicBuffInterface;

        //Permanent Thorium Buff UI
        public PermanentThoriumBuffUI permanentThoriumBuffUI;
        public UserInterface permanentThoriumBuffInterface;

        #region UI TEXT
        //BLACK MARKET DEALER
        public static LocalizedText BMPotionText { get; private set; }
        public static LocalizedText BMStationText { get; private set; }
        public static LocalizedText BMMaterialText { get; private set; }
        public static LocalizedText BMMovementAccessoryText { get; private set; }
        public static LocalizedText BMCombatAccessoryText { get; private set; }
        public static LocalizedText BMInformativeText { get; private set; }
        public static LocalizedText BMBagText { get; private set; }
        public static LocalizedText BMCrateText { get; private set; }
        public static LocalizedText BMOreText { get; private set; }
        public static LocalizedText BMNaturalBlockText { get; private set; }
        public static LocalizedText BMBuildingBlockText { get; private set; }
        public static LocalizedText BMHerbText { get; private set; }
        public static LocalizedText BMFishText { get; private set; }
        public static LocalizedText BMMountText { get; private set; }
        public static LocalizedText BMAmmoText { get; private set; }

        //ETHEREAL COLLECTOR
        public static LocalizedText ECPotionText { get; private set; }
        public static LocalizedText ECStationText { get; private set; }
        public static LocalizedText ECMaterialText { get; private set; }
        public static LocalizedText ECMaterial2Text { get; private set; }
        public static LocalizedText ECBagText { get; private set; }
        public static LocalizedText ECCrateText { get; private set; }
        public static LocalizedText ECOreText { get; private set; }
        public static LocalizedText ECNaturalBlockText { get; private set; }
        public static LocalizedText ECBuildingBlockText { get; private set; }
        public static LocalizedText ECHerbText { get; private set; }
        public static LocalizedText ECFishText { get; private set; }

        //ALL IN ONE ACCESS
        public static LocalizedText PiggyBankText { get; private set; }
        public static LocalizedText SafeText { get; private set; }
        public static LocalizedText DefendersForgeText { get; private set; }
        public static LocalizedText VoidVaultText { get; private set; }

        //DESTINATION GLOBE
        public static LocalizedText DesertText { get; private set; }
        public static LocalizedText SnowText { get; private set; }
        public static LocalizedText JungleText { get; private set; }
        public static LocalizedText GlowingMushroomText { get; private set; }
        public static LocalizedText CorruptionText { get; private set; }
        public static LocalizedText CrimsonText { get; private set; }
        public static LocalizedText HallowText { get; private set; }
        public static LocalizedText PurityText { get; private set; }

        //SUMMONING REMOTE
        public static LocalizedText BossText { get; private set; }
        public static LocalizedText EventText { get; private set; }
        public static LocalizedText MinibossText { get; private set; }

        //ENTITY MANIPULATOR
        public static LocalizedText IncreaseSpawnText { get; private set; }
        public static LocalizedText DecreaseSpawnText { get; private set; }
        public static LocalizedText CancelSpawnText { get; private set; }
        public static LocalizedText CancelEventText { get; private set; }
        public static LocalizedText CancelSpawnAndEventText { get; private set; }
        public static LocalizedText RevertText { get; private set; }

        //PHASE INTERRUPTER
        public static LocalizedText FullMoonText { get; private set; }
        public static LocalizedText WaningGibbousText { get; private set; }
        public static LocalizedText ThirdQuarterText { get; private set; }
        public static LocalizedText WaningCrescentText { get; private set; }
        public static LocalizedText NewMoonText { get; private set; }
        public static LocalizedText WaxingCrescentText { get; private set; }
        public static LocalizedText FirstQuarterText { get; private set; }
        public static LocalizedText WaxingGibbousText { get; private set; }

        //PERMANENT BUFF SELECTOR UI
        public static LocalizedText VanillaText { get; private set; }
        public static LocalizedText CalamityText { get; private set; }
        public static LocalizedText MartinsOrderText { get; private set; }
        public static LocalizedText SpiritClassicText { get; private set; }
        public static LocalizedText ThoriumText { get; private set; }

        //PERMANENT BUFF UI
        public static LocalizedText ArenaText { get; private set; }
        public static LocalizedText PotionText { get; private set; }
        public static LocalizedText StationText { get; private set; }
        public static LocalizedText AddonText { get; private set; }
        public static LocalizedText RepellentText { get; private set; }


        //GENERIC
        public static LocalizedText CloseText { get; private set; }
        public static LocalizedText ResetText { get; private set; }
        public static LocalizedText UnloadedText { get; private set; }
        #endregion

        public override void Load()
        {
            #region UI TEXT
            //BLACK MARKET DEALER
            BMPotionText = Mod.GetLocalization($"UIText.BMPotionText");
            BMStationText = Mod.GetLocalization($"UIText.BMStationText");
            BMMaterialText = Mod.GetLocalization($"UIText.BMMaterialText");
            BMMovementAccessoryText = Mod.GetLocalization($"UIText.BMMovementAccessoryText");
            BMCombatAccessoryText = Mod.GetLocalization($"UIText.BMCombatAccessoryText");
            BMInformativeText = Mod.GetLocalization($"UIText.BMInformativeText");
            BMBagText = Mod.GetLocalization($"UIText.BMBagText");
            BMCrateText = Mod.GetLocalization($"UIText.BMCrateText");
            BMOreText = Mod.GetLocalization($"UIText.BMOreText");
            BMNaturalBlockText = Mod.GetLocalization($"UIText.BMNaturalBlockText");
            BMBuildingBlockText = Mod.GetLocalization($"UIText.BMBuildingBlockText");
            BMHerbText = Mod.GetLocalization($"UIText.BMHerbText");
            BMFishText = Mod.GetLocalization($"UIText.BMFishText");
            BMMountText = Mod.GetLocalization($"UIText.BMMountText");
            BMAmmoText = Mod.GetLocalization($"UIText.BMAmmoText");

            //ETHEREAL COLLECTOR
            ECPotionText = Mod.GetLocalization($"UIText.ECPotionText");
            ECStationText = Mod.GetLocalization($"UIText.ECStationText");
            ECMaterialText = Mod.GetLocalization($"UIText.ECMaterialText");
            ECMaterial2Text = Mod.GetLocalization($"UIText.ECMaterial2Text");
            ECBagText = Mod.GetLocalization($"UIText.ECBagText");
            ECCrateText = Mod.GetLocalization($"UIText.ECCrateText");
            ECOreText = Mod.GetLocalization($"UIText.ECOreText");
            ECNaturalBlockText = Mod.GetLocalization($"UIText.ECNaturalBlockText");
            ECBuildingBlockText = Mod.GetLocalization($"UIText.ECBuildingBlockText");
            ECHerbText = Mod.GetLocalization($"UIText.ECHerbText");
            ECFishText = Mod.GetLocalization($"UIText.ECFishText");

            //ALL IN ONE ACCESS
            PiggyBankText = Mod.GetLocalization($"UIText.PiggyBankText");
            SafeText = Mod.GetLocalization($"UIText.SafeText");
            DefendersForgeText = Mod.GetLocalization($"UIText.DefendersForgeText");
            VoidVaultText = Mod.GetLocalization($"UIText.VoidVaultText");

            //DESTINATION GLOBE
            DesertText = Mod.GetLocalization($"UIText.DesertText");
            SnowText = Mod.GetLocalization($"UIText.SnowText");
            JungleText = Mod.GetLocalization($"UIText.JungleText");
            GlowingMushroomText = Mod.GetLocalization($"UIText.GlowingMushroomText");
            CorruptionText = Mod.GetLocalization($"UIText.CorruptionText");
            CrimsonText = Mod.GetLocalization($"UIText.CrimsonText");
            HallowText = Mod.GetLocalization($"UIText.HallowText");
            PurityText = Mod.GetLocalization($"UIText.PurityText");

            //SUMMONING REMOTE
            BossText = Mod.GetLocalization($"UIText.BossText");
            EventText = Mod.GetLocalization($"UIText.EventText");
            MinibossText = Mod.GetLocalization($"UIText.MinibossText");

            //ENTITY MANIPULATOR
            IncreaseSpawnText = Mod.GetLocalization($"UIText.IncreaseSpawnText");
            DecreaseSpawnText = Mod.GetLocalization($"UIText.DecreaseSpawnText");
            CancelSpawnText = Mod.GetLocalization($"UIText.CancelSpawnText");
            CancelEventText = Mod.GetLocalization($"UIText.CancelEventText");
            CancelSpawnAndEventText = Mod.GetLocalization($"UIText.CancelSpawnAndEventText");
            RevertText = Mod.GetLocalization($"UIText.RevertText");

            //PHASE INTERRUPTER
            FullMoonText = Mod.GetLocalization($"UIText.FullMoonText");
            WaningGibbousText = Mod.GetLocalization($"UIText.WaningGibbousText");
            ThirdQuarterText = Mod.GetLocalization($"UIText.ThirdQuarterText");
            WaningCrescentText = Mod.GetLocalization($"UIText.WaningCrescentText");
            NewMoonText = Mod.GetLocalization($"UIText.NewMoonText");
            WaxingCrescentText = Mod.GetLocalization($"UIText.WaxingCrescentText");
            FirstQuarterText = Mod.GetLocalization($"UIText.FirstQuarterText");
            WaxingGibbousText = Mod.GetLocalization($"UIText.WaxingGibbousText");

            //PERMANENT BUFF SELECTOR UI
            VanillaText = Mod.GetLocalization($"UIText.VanillaText");
            CalamityText = Mod.GetLocalization($"UIText.CalamityText");
            MartinsOrderText = Mod.GetLocalization($"UIText.MartinsOrderText");
            SpiritClassicText = Mod.GetLocalization($"UIText.SpiritClassicText");
            ThoriumText = Mod.GetLocalization($"UIText.ThoriumText");

            //PERMANENT BUFFS
            ArenaText = Mod.GetLocalization($"UIText.ArenaText");
            PotionText = Mod.GetLocalization($"UIText.PotionText");
            StationText = Mod.GetLocalization($"UIText.StationText");
            AddonText = Mod.GetLocalization($"UIText.AddonText");
            RepellentText = Mod.GetLocalization($"UIText.RepellentText");

            //GENERIC
            CloseText = Mod.GetLocalization($"UIText.CloseText");
            ResetText = Mod.GetLocalization($"UIText.ResetText");
            UnloadedText = Mod.GetLocalization($"UIText.UnloadedText");
            #endregion

            if (!Main.dedServ)
            {
                blackMarketDealerNPCShopUI = new BlackMarketDealerNPCUI();
                blackMarketDealerNPCShopUI.Activate();
                blackMarketDealerNPCInterface = new UserInterface();
                blackMarketDealerNPCInterface.SetState(blackMarketDealerNPCShopUI);

                etherealCollectorNPCShopUI = new EtherealCollectorNPCUI();
                etherealCollectorNPCShopUI.Activate();
                etherealCollectorNPCInterface = new UserInterface();
                etherealCollectorNPCInterface.SetState(etherealCollectorNPCShopUI);

                allInOneAccessUI = new AllInOneAccessUI();
                allInOneAccessUI.Activate();
                allInOneAccessInterface = new UserInterface();
                allInOneAccessInterface.SetState(allInOneAccessUI);

                destinationGlobeUI = new DestinationGlobeUI();
                destinationGlobeUI.Activate();
                destinationGlobeInterface = new UserInterface();
                destinationGlobeInterface.SetState(destinationGlobeUI);

                entityManipulatorUI = new EntityManipulatorUI();
                entityManipulatorUI.Activate();
                entityManipulatorInterface = new UserInterface();
                entityManipulatorInterface.SetState(entityManipulatorUI);

                phaseInterrupterUI = new PhaseInterrupterUI();
                phaseInterrupterUI.Activate();
                phaseInterrupterInterface = new UserInterface();
                phaseInterrupterInterface.SetState(phaseInterrupterUI);

                summoningRemoteUI = new SummoningRemoteUI();
                summoningRemoteUI.Activate();
                summoningRemoteInterface = new UserInterface();
                summoningRemoteInterface.SetState(summoningRemoteUI);

                permanentBuffUI = new PermanentBuffUI();
                permanentBuffUI.Activate();
                permanentBuffInterface = new UserInterface();
                permanentBuffInterface.SetState(permanentBuffUI);

                permanentCalamityBuffUI = new PermanentCalamityBuffUI();
                permanentCalamityBuffUI.Activate();
                permanentCalamityBuffInterface = new UserInterface();
                permanentCalamityBuffInterface.SetState(permanentCalamityBuffUI);

                permanentMartinsOrderBuffUI = new PermanentMartinsOrderBuffUI();
                permanentMartinsOrderBuffUI.Activate();
                permanentMartinsOrderBuffInterface = new UserInterface();
                permanentMartinsOrderBuffInterface.SetState(permanentMartinsOrderBuffUI);

                permanentSpiritClassicBuffUI = new PermanentSpiritClassicBuffUI();
                permanentSpiritClassicBuffUI.Activate();
                permanentSpiritClassicBuffInterface = new UserInterface();
                permanentSpiritClassicBuffInterface.SetState(permanentSpiritClassicBuffUI);

                permanentThoriumBuffUI = new PermanentThoriumBuffUI();
                permanentThoriumBuffUI.Activate();
                permanentThoriumBuffInterface = new UserInterface();
                permanentThoriumBuffInterface.SetState(permanentThoriumBuffUI);

                permanentBuffSelectorUI = new PermanentBuffSelectorUI();
                permanentBuffSelectorUI.Activate();
                permanentBuffSelectorInterface = new UserInterface();
                permanentBuffSelectorInterface.SetState(permanentBuffSelectorUI);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (MouseTextIndex != -1)
            {
                //BLACK MARKET DEALER
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "QoLC: Shop Selector",
                    delegate
                    {
                        if (BlackMarketDealerNPCUI.visible)
                        {
                            blackMarketDealerNPCShopUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
                //ETHEREAL COLLECTOR
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "QoLC: Modded Shop Selector",
                    delegate
                    {
                        if (EtherealCollectorNPCUI.visible)
                        {
                            etherealCollectorNPCShopUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
                //ALL IN ONE ACCESS
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "QoLC: Storage Selector",
                    delegate
                    {
                        if (AllInOneAccessUI.visible)
                        {
                            allInOneAccessUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
                //DESTINATION GLOBE
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "QoLC: Biome Selector",
                    delegate
                    {
                        if (DestinationGlobeUI.visible)
                        {
                            destinationGlobeUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
                //ENTITY MANIPULATOR
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "QoLC: Spawn Selector",
                    delegate
                    {
                        if (EntityManipulatorUI.visible)
                        {
                            entityManipulatorUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
                //PHASE INTERRUPTER
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "QoLC: Moon Selector",
                    delegate
                    {
                        if (PhaseInterrupterUI.visible)
                        {
                            phaseInterrupterUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
                //SUMMONING REMOTE
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "QoLC: Summon Selector",
                    delegate
                    {
                        if (SummoningRemoteUI.visible)
                        {
                            summoningRemoteUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
                //PERMANENT BUFF SELECTOR
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "QoLC: Buff Selector",
                    delegate
                    {
                        if (PermanentBuffSelectorUI.visible)
                        {
                            permanentBuffSelectorUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
                //PERMANENT BUFFS
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "QoLC: Buff Toggles",
                    delegate
                    {
                        if (PermanentBuffUI.visible)
                        {
                            permanentBuffUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
                //PERMANENT CALAMITY BUFFS
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "QoLC: Calamity Buff Toggles",
                    delegate
                    {
                        if (PermanentCalamityBuffUI.visible)
                        {
                            permanentCalamityBuffUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
                //PERMANENT MARTIN'S ORDER BUFFS
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "QoLC: Calamity Buff Toggles",
                    delegate
                    {
                        if (PermanentMartinsOrderBuffUI.visible)
                        {
                            permanentMartinsOrderBuffUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
                //PERMANENT SPIRIT CLASSIC BUFFS
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "QoLC: Calamity Buff Toggles",
                    delegate
                    {
                        if (PermanentSpiritClassicBuffUI.visible)
                        {
                            permanentSpiritClassicBuffUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
                //PERMANENT THORIUM BUFFS
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "QoLC: Thorium Buff Toggles",
                    delegate
                    {
                        if (PermanentThoriumBuffUI.visible)
                        {
                            permanentThoriumBuffUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }

        public override void UpdateUI(GameTime gameTime)
        {
            oldUiGameTime = gameTime;

            if (blackMarketDealerNPCInterface.CurrentState is not null && BlackMarketDealerNPCUI.visible)
                blackMarketDealerNPCInterface.Update(gameTime);

            if (etherealCollectorNPCInterface.CurrentState is not null && EtherealCollectorNPCUI.visible)
                etherealCollectorNPCInterface.Update(gameTime);

            if (allInOneAccessInterface.CurrentState is not null && AllInOneAccessUI.visible)
                allInOneAccessInterface.Update(gameTime);

            if (destinationGlobeInterface.CurrentState is not null && DestinationGlobeUI.visible)
                destinationGlobeInterface.Update(gameTime);

            if (entityManipulatorInterface.CurrentState is not null && EntityManipulatorUI.visible)
                entityManipulatorInterface.Update(gameTime);

            if (phaseInterrupterInterface.CurrentState is not null && PhaseInterrupterUI.visible)
                phaseInterrupterInterface.Update(gameTime);

            if (summoningRemoteInterface.CurrentState is not null && SummoningRemoteUI.visible)
                summoningRemoteInterface.Update(gameTime);

            if (permanentBuffInterface.CurrentState is not null && PermanentBuffUI.visible)
                permanentBuffInterface.Update(gameTime);
            
            if (permanentCalamityBuffInterface.CurrentState is not null && PermanentCalamityBuffUI.visible)
                permanentCalamityBuffInterface.Update(gameTime);

            if (permanentMartinsOrderBuffInterface.CurrentState is not null && PermanentMartinsOrderBuffUI.visible)
                permanentMartinsOrderBuffInterface.Update(gameTime);

            if (permanentSpiritClassicBuffInterface.CurrentState is not null && PermanentSpiritClassicBuffUI.visible)
                permanentSpiritClassicBuffInterface.Update(gameTime);

            if (permanentThoriumBuffInterface.CurrentState is not null && PermanentThoriumBuffUI.visible)
                permanentThoriumBuffInterface.Update(gameTime);

            if (permanentBuffSelectorInterface.CurrentState is not null && PermanentBuffSelectorUI.visible)
                permanentBuffSelectorInterface.Update(gameTime);
        }
    }
}
