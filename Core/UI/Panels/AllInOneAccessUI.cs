using QoLCompendium.Core.UI.Buttons;

namespace QoLCompendium.Core.UI.Panels
{
    public class AllInOneAccessUI : UIState
    {
        public static bool visible = false;
        public static uint timeStart;

        public override void OnInitialize()
        {
            UIPanel StoragePanel = new();
            StoragePanel.SetPadding(0);
            StoragePanel.HAlign = 0.615f;
            StoragePanel.VAlign = 0.53f;
            StoragePanel.Width.Set(200f, 0f);
            StoragePanel.Height.Set(40f, 0f);
            StoragePanel.BackgroundColor *= 0f;
            StoragePanel.BorderColor *= 0f;
            Append(StoragePanel);

            AllInOneAccessButton.backgroundTexture = 0;
            AllInOneAccessButton piggyBank = new(Common.GetAsset("Storages", "Storage_", AllInOneAccessButton.storageTexture = 0));
            piggyBank.Left.Set(0f, 0f);
            piggyBank.Top.Set(0f, 0f);
            piggyBank.Width.Set(40f, 0f);
            piggyBank.Height.Set(40f, 0f);
            piggyBank.OnLeftClick += PiggyBankClicked;
            piggyBank.Tooltip = UISystem.PiggyBankText;
            StoragePanel.Append(piggyBank);

            AllInOneAccessButton.backgroundTexture = 1;
            AllInOneAccessButton safe = new(Common.GetAsset("Storages", "Storage_", AllInOneAccessButton.storageTexture = 1));
            safe.Left.Set(40f, 0f);
            safe.Top.Set(0f, 0f);
            safe.Width.Set(40f, 0f);
            safe.Height.Set(40f, 0f);
            safe.OnLeftClick += SafeClicked;
            safe.Tooltip = UISystem.SafeText;
            StoragePanel.Append(safe);

            AllInOneAccessButton.backgroundTexture = 1;
            AllInOneAccessButton defendersForge = new(Common.GetAsset("Storages", "Storage_", AllInOneAccessButton.storageTexture = 2));
            defendersForge.Left.Set(80f, 0f);
            defendersForge.Top.Set(0f, 0f);
            defendersForge.Width.Set(40f, 0f);
            defendersForge.Height.Set(40f, 0f);
            defendersForge.OnLeftClick += DefendersForgeClicked;
            defendersForge.Tooltip = UISystem.DefendersForgeText;
            StoragePanel.Append(defendersForge);

            AllInOneAccessButton.backgroundTexture = 1;
            AllInOneAccessButton voidVault = new(Common.GetAsset("Storages", "Storage_", AllInOneAccessButton.storageTexture = 3));
            voidVault.Left.Set(120f, 0f);
            voidVault.Top.Set(0f, 0f);
            voidVault.Width.Set(40f, 0f);
            voidVault.Height.Set(40f, 0f);
            voidVault.OnLeftClick += VoidVaultClicked;
            voidVault.Tooltip = UISystem.VoidVaultText;
            StoragePanel.Append(voidVault);

            GenericUIButton.backgroundTexture = 2;
            GenericUIButton closeButton = new(Common.GetAsset("Buttons", "Button_Small_", GenericUIButton.buttonTexture = 3));
            closeButton.Left.Set(160f, 0f);
            closeButton.Top.Set(0f, 0f);
            closeButton.Width.Set(40f, 0f);
            closeButton.Height.Set(40f, 0f);
            closeButton.OnLeftClick += CloseButtonClicked;
            closeButton.Tooltip = UISystem.CloseText;
            StoragePanel.Append(closeButton);
        }

        private void PiggyBankClicked(UIMouseEvent evt, UIElement listeningElement) => StorageClick(-2, SoundID.Item59);
        private void SafeClicked(UIMouseEvent evt, UIElement listeningElement) => StorageClick(-3, SoundID.MenuOpen);
        private void DefendersForgeClicked(UIMouseEvent evt, UIElement listeningElement) => StorageClick(-4, SoundID.MenuOpen);
        private void VoidVaultClicked(UIMouseEvent evt, UIElement listeningElement) => StorageClick(-5, SoundID.Item130);

        private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                SoundEngine.PlaySound(SoundID.MenuClose);
                visible = false;
            }
        }

        public static void StorageClick(int chest, SoundStyle sound)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.playerInventory = true;
                Main.LocalPlayer.chest = chest;
                QoLCompendium.LastOpenedBank = chest;
                Point pos = Main.LocalPlayer.Center.ToTileCoordinates();
                Main.LocalPlayer.chestX = pos.X;
                Main.LocalPlayer.chestY = pos.Y;
                Main.oldNPCShop = 0;
                Main.LocalPlayer.SetTalkNPC(-1);
                Main.SetNPCShopIndex(0);
                SoundEngine.PlaySound(sound, Main.LocalPlayer.position, null);
                Recipe.FindRecipes(false);
            }
        }
    }
}
