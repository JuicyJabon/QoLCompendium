using QoLCompendium.Core.Changes;
using QoLCompendium.Core.UI.Buttons;
using static Terraria.ModLoader.ModContent;

namespace QoLCompendium.Core.UI.Panels
{
    public class AllInOneAccessUI : UIState
    {
        public UIPanel StoragePanel;
        public static bool visible = false;
        public static uint timeStart;

        public override void OnInitialize()
        {
            StoragePanel = new UIPanel();
            StoragePanel.Top.Set(Main.screenHeight / 2 - 30, 0f);
            StoragePanel.Left.Set(Main.screenWidth / 2 + 75, 0f);
            StoragePanel.Width.Set(200f, 0f);
            StoragePanel.Height.Set(200f, 0f);
            StoragePanel.BackgroundColor *= 0f;
            StoragePanel.BorderColor *= 0f;
            Append(StoragePanel);

            AllInOneAccessButton.storageTexture = 0;
            AllInOneAccessButton piggyBank = new(Request<Texture2D>("QoLCompendium/Assets/Storages/Storage_" + AllInOneAccessButton.storageTexture));
            piggyBank.Left.Set(0f, 0f);
            piggyBank.Top.Set(0f, 0f);
            piggyBank.Width.Set(36f, 0f);
            piggyBank.Height.Set(36f, 0f);
            piggyBank.OnLeftClick += PiggyBankClicked;
            piggyBank.Tooltip = UISystem.PiggyBankText;
            StoragePanel.Append(piggyBank);

            AllInOneAccessButton.storageTexture = 1;
            AllInOneAccessButton safe = new(Request<Texture2D>("QoLCompendium/Assets/Storages/Storage_" + AllInOneAccessButton.storageTexture));
            safe.Left.Set(36f, 0f);
            safe.Top.Set(0f, 0f);
            safe.Width.Set(36f, 0f);
            safe.Height.Set(36f, 0f);
            safe.OnLeftClick += SafeClicked;
            safe.Tooltip = UISystem.SafeText;
            StoragePanel.Append(safe);

            AllInOneAccessButton.storageTexture = 2;
            AllInOneAccessButton defendersForge = new(Request<Texture2D>("QoLCompendium/Assets/Storages/Storage_" + AllInOneAccessButton.storageTexture));
            defendersForge.Left.Set(72f, 0f);
            defendersForge.Top.Set(0f, 0f);
            defendersForge.Width.Set(36f, 0f);
            defendersForge.Height.Set(36f, 0f);
            defendersForge.OnLeftClick += DefendersForgeClicked;
            defendersForge.Tooltip = UISystem.DefendersForgeText;
            StoragePanel.Append(defendersForge);

            AllInOneAccessButton.storageTexture = 3;
            AllInOneAccessButton voidVault = new(Request<Texture2D>("QoLCompendium/Assets/Storages/Storage_" + AllInOneAccessButton.storageTexture));
            voidVault.Left.Set(108f, 0f);
            voidVault.Top.Set(0f, 0f);
            voidVault.Width.Set(36f, 0f);
            voidVault.Height.Set(36f, 0f);
            voidVault.OnLeftClick += VoidVaultClicked;
            voidVault.Tooltip = UISystem.VoidVaultText;
            StoragePanel.Append(voidVault);

            GenericUIButton.buttonTexture = 0;
            GenericUIButton closeButton = new(Request<Texture2D>("QoLCompendium/Assets/UI/UI_" + GenericUIButton.buttonTexture));
            closeButton.Left.Set(54f, 0f);
            closeButton.Top.Set(36f, 0f);
            closeButton.Width.Set(36f, 0f);
            closeButton.Height.Set(36f, 0f);
            closeButton.OnLeftClick += CloseButtonClicked;
            closeButton.Tooltip = UISystem.CloseText;
            StoragePanel.Append(closeButton);
        }

        private void PiggyBankClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.LocalPlayer.GetModPlayer<BankPlayer>().chests = true;
                Main.LocalPlayer.chest = -2;
                Main.oldNPCShop = 0;
                Main.playerInventory = true;
                SoundEngine.PlaySound(SoundID.Item59, Main.LocalPlayer.position, null);
                Recipe.FindRecipes(false);
            }
        }

        private void SafeClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.LocalPlayer.GetModPlayer<BankPlayer>().chests = true;
                Main.LocalPlayer.chest = -3;
                Main.oldNPCShop = 0;
                Main.playerInventory = true;
                SoundEngine.PlaySound(SoundID.MenuOpen, Main.LocalPlayer.position, null);
                Recipe.FindRecipes(false);
            }
        }

        private void DefendersForgeClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.LocalPlayer.GetModPlayer<BankPlayer>().chests = true;
                Main.LocalPlayer.chest = -4;
                Main.oldNPCShop = 0;
                Main.playerInventory = true;
                SoundEngine.PlaySound(SoundID.MenuOpen, Main.LocalPlayer.position, null);
                Recipe.FindRecipes(false);
            }
        }

        private void VoidVaultClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.LocalPlayer.GetModPlayer<BankPlayer>().chests = true;
                Main.LocalPlayer.chest = -5;
                Main.oldNPCShop = 0;
                Main.playerInventory = true;
                SoundEngine.PlaySound(SoundID.Item130, Main.LocalPlayer.position, null);
                Recipe.FindRecipes(false);
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
    }
}
