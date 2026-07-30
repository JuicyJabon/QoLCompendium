using QoLCompendium.Core.UI.Panels;

namespace QoLCompendium.Core.UI
{
    public class QoLCUISystem : ModSystem
    {
        public GameTime _lastUpdateUiGameTime;

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

        //Time Wrinkler UI
        public TimeWrinklerUI timeWrinklerUI;
        public UserInterface timeWrinklerInterface;

        //Permanent Buff Toggler UI
        public PermanentBuffTogglerUI permanentBuffTogglerUI;
        public UserInterface permanentBuffTogglerInterface;

        public static string GetUIText(string category, string key, params object[] args)
        {
            if (args == null || args.Length == 0)
                return Language.GetTextValue($"Mods.QoLCompendium.UIText.{category}.{key}");
            return Language.GetTextValue($"Mods.QoLCompendium.UIText.{category}.{key}", args);
        }

        public static string GetNPCUIText(string npc, string key, params object[] args)
        {
            if (args == null || args.Length == 0)
                return Language.GetTextValue($"Mods.QoLCompendium.NPCs.{npc}.ShopName.{key}");
            return Language.GetTextValue($"Mods.QoLCompendium.NPCs.{npc}.ShopName.{key}", args);
        }

        public override void OnWorldLoad()
        {
            if (!Main.dedServ)
            {
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

                timeWrinklerUI = new TimeWrinklerUI();
                timeWrinklerUI.Activate();
                timeWrinklerInterface = new UserInterface();
                timeWrinklerInterface.SetState(timeWrinklerUI);

                permanentBuffTogglerUI = new PermanentBuffTogglerUI();
                permanentBuffTogglerUI.Activate();
                permanentBuffTogglerInterface = new UserInterface();
                permanentBuffTogglerInterface.SetState(permanentBuffTogglerUI);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (MouseTextIndex != -1)
            {
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
                //TIME WRINKLER
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "QoLC: Time Wrinkler",
                    delegate
                    {
                        if (TimeWrinklerUI.visible)
                        {
                            timeWrinklerUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
                //PERMANENT BUFF TOGGLER
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "QoLC: Buff Toggler",
                    delegate
                    {
                        if (_lastUpdateUiGameTime != null && permanentBuffTogglerInterface?.CurrentState != null)
                        {
                            permanentBuffTogglerInterface.Draw(Main.spriteBatch, _lastUpdateUiGameTime);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }

        public override void UpdateUI(GameTime gameTime)
        {
            _lastUpdateUiGameTime = gameTime;

            if (allInOneAccessInterface?.CurrentState != null && AllInOneAccessUI.visible)
                allInOneAccessInterface.Update(gameTime);

            if (destinationGlobeInterface?.CurrentState != null && DestinationGlobeUI.visible)
                destinationGlobeInterface.Update(gameTime);

            if (entityManipulatorInterface?.CurrentState != null && EntityManipulatorUI.visible)
                entityManipulatorInterface.Update(gameTime);

            if (phaseInterrupterInterface?.CurrentState != null && PhaseInterrupterUI.visible)
                phaseInterrupterInterface.Update(gameTime);

            if (summoningRemoteInterface?.CurrentState != null && SummoningRemoteUI.visible)
                summoningRemoteInterface.Update(gameTime);

            if (timeWrinklerInterface?.CurrentState != null && TimeWrinklerUI.visible)
                timeWrinklerInterface.Update(gameTime);

            if (permanentBuffTogglerInterface?.CurrentState != null && PermanentBuffTogglerUI.visible)
                permanentBuffTogglerInterface.Update(gameTime);
        }
    }
}
