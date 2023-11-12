using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace QoLCompendium.UI
{
    public class UISystem : ModSystem
    {
        internal BMNPCUI bmShopUI;
        private UserInterface bmInterface;
        internal ECNPCUI ecShopUI;
        private UserInterface ecInterface;
        internal WorldGlobeUI worldGlobeUI;
        private UserInterface worldGlobeInterface;
        internal EntityManipulatorUI entityManipulatorUI;
        private UserInterface entityManipulatorInterface;
        internal MoonChangeUI moonChangeUI;
        private UserInterface moonInterface;
        internal BossUI bossUI;
        private UserInterface bossInterface;

        public override void OnWorldLoad()
        {
            if (!Main.dedServ)
            {
                bmShopUI = new BMNPCUI();
                bmShopUI.Activate();
                bmInterface = new UserInterface();
                bmInterface.SetState(bmShopUI);

                ecShopUI = new ECNPCUI();
                ecShopUI.Activate();
                ecInterface = new UserInterface();
                ecInterface.SetState(ecShopUI);

                worldGlobeUI = new WorldGlobeUI();
                worldGlobeUI.Activate();
                worldGlobeInterface = new UserInterface();
                worldGlobeInterface.SetState(worldGlobeUI);

                entityManipulatorUI = new EntityManipulatorUI();
                entityManipulatorUI.Activate();
                entityManipulatorInterface = new UserInterface();
                entityManipulatorInterface.SetState(entityManipulatorUI);

                moonChangeUI = new MoonChangeUI();
                moonChangeUI.Activate();
                moonInterface = new UserInterface();
                moonInterface.SetState(moonChangeUI);

                bossUI = new BossUI();
                bossUI.Activate();
                bossInterface = new UserInterface();
                bossInterface.SetState(bossUI);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (MouseTextIndex != -1)
            {
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "QoLC: Shop Selector",
                    delegate
                    {
                        if (BMNPCUI.visible)
                        {
                            bmShopUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
            if (MouseTextIndex != -1)
            {
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "QoLC: Shop Selector",
                    delegate
                    {
                        if (ECNPCUI.visible)
                        {
                            ecShopUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
            if (MouseTextIndex != -1)
            {
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "QoLC: Globe Selector",
                    delegate
                    {
                        if (WorldGlobeUI.visible)
                        {
                            worldGlobeUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
            if (MouseTextIndex != -1)
            {
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
            }
            if (MouseTextIndex != -1)
            {
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "QoLC: Moon Selector",
                    delegate
                    {
                        if (MoonChangeUI.visible)
                        {
                            moonChangeUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
            if (MouseTextIndex != -1)
            {
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "QoLC: Moon Selector",
                    delegate
                    {
                        if (BossUI.visible)
                        {
                            bossUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }

        public override void UpdateUI(GameTime gameTime)
        {
            if (bmInterface != null && BMNPCUI.visible)
            {
                bmInterface.Update(gameTime);
            }

            if (ecInterface != null && ECNPCUI.visible)
            {
                ecInterface.Update(gameTime);
            }

            if (worldGlobeInterface != null && WorldGlobeUI.visible)
            {
                worldGlobeInterface.Update(gameTime);
            }

            if (entityManipulatorInterface != null && EntityManipulatorUI.visible)
            {
                entityManipulatorInterface.Update(gameTime);
            }

            if (moonInterface != null && MoonChangeUI.visible)
            {
                moonInterface.Update(gameTime);
            }

            if (bossInterface != null && BossUI.visible)
            {
                bossInterface.Update(gameTime);
            }
        }
    }
}
