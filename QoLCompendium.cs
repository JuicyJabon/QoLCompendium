global using static QoLCompendium.QoLCConfig;
using QoLCompendium.UI;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace QoLCompendium
{
    public class QoLCompendium : Mod
    {
        internal BMNPCUI bmShopUI;
        private UserInterface bmInterface;
        internal ECNPCUI ecShopUI;
        private UserInterface ecInterface;
        internal GlobeUI globeUI;
        private UserInterface globeInterface;
        internal EMUI emUI;
        private UserInterface emInterface;
        internal MoonChangeUI moonChangeUI;
        private UserInterface moonInterface;

        public override uint ExtraPlayerBuffSlots => ModContent.GetInstance<QoLCConfig>().ExtraBuffSlots;

        public override void Load()
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

                moonChangeUI = new MoonChangeUI();
                moonChangeUI.Activate();
                moonInterface = new UserInterface();
                moonInterface.SetState(moonChangeUI);
            }
        }
    }
}
