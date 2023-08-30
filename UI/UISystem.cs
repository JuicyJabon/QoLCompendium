﻿using Microsoft.Xna.Framework;
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
        internal GlobeUI globeUI;
        private UserInterface globeInterface;
        internal EMUI emUI;
        private UserInterface emInterface;
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

                globeUI = new GlobeUI();
                globeUI.Activate();
                globeInterface = new UserInterface();
                globeInterface.SetState(globeUI);

                emUI = new EMUI();
                emUI.Activate();
                emInterface = new UserInterface();
                emInterface.SetState(emUI);
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
                        if (GlobeUI.visible)
                        {
                            globeUI.Draw(Main.spriteBatch);
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
                        if (EMUI.visible)
                        {
                            emUI.Draw(Main.spriteBatch);
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

            if (globeInterface != null && GlobeUI.visible)
            {
                globeInterface.Update(gameTime);
            }

            if (emInterface != null && EMUI.visible)
            {
                emInterface.Update(gameTime);
            }
        }
    }

}
