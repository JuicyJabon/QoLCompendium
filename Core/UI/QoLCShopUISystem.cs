using QoLCompendium.Core.UI.Panels;

namespace QoLCompendium.Core.UI
{
    public class QoLCShopUISystem : ModSystem
    {
        public GameTime _lastUpdateUiGameTime;

        public ShopChangerUI shopChangerUI;
        public UserInterface shopChangerInterface;

        public static Dictionary<string, int> shopIcons = new()
        {
            { "PotionShop", ItemID.IronskinPotion },
            { "StationsAndUpgradesShop", ItemID.SharpeningStation },
            { "MaterialShop", ItemID.CursedFlame },
            { "MaterialShop2", ItemID.Ichor },
            { "MobilityAccessoryShop", ItemID.HermesBoots },
            { "CombatAccessoryShop", ItemID.SharkToothNecklace },
            { "ToolsAndInfoShop", ItemID.PDA },
            { "TreasureBagShop", ItemID.EyeOfCthulhuBossBag },
            { "CratesAndGrabBagsShop", ItemID.WoodenCrate },
            { "OresAndBarsShop", ItemID.GoldBar },
            { "NaturalBlockShop", ItemID.DirtBlock },
            { "BuildingBlockShop", ItemID.GrayBrick },
            { "HerbsAndPlantsShop", ItemID.Daybloom },
            { "FishShop", ItemID.Bass },
            { "CritterShop", ItemID.Bunny },
            { "MountsAndHooksShop", ItemID.GrapplingHook },
            { "AmmoShop", ItemID.EndlessMusketPouch }
        };

        public override void OnWorldLoad()
        {
            if (!Main.dedServ)
            {
                shopChangerUI = new ShopChangerUI();
                shopChangerUI.Activate();
                shopChangerInterface = new UserInterface();
                shopChangerInterface.SetState(shopChangerUI);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));

            if (MouseTextIndex != -1)
            {
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "QoLCompendium: Shop Changer",
                    delegate
                    {
                        if (_lastUpdateUiGameTime != null && shopChangerInterface?.CurrentState != null)
                        {
                            shopChangerInterface.Draw(Main.spriteBatch, _lastUpdateUiGameTime);
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

            if (shopChangerInterface?.CurrentState != null)
                shopChangerInterface.Update(gameTime);
        }

        public void ShowShopChanger(int npcWhoAmI)
        {
            shopChangerUI.UpdateTalkNPC(npcWhoAmI);
            shopChangerInterface.SetState(shopChangerUI);
        }

        public void HideShopChanger()
        {
            shopChangerInterface.SetState(null);
        }
    }
}
