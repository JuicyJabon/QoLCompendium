using QoLCompendium.Core.Changes.PlayerChanges;
using QoLCompendium.Core.UI.Buttons;

namespace QoLCompendium.Core.UI.Panels
{
    public class AllInOneAccessUI : UIState
    {
        public UIPanel StoragePanel;
        public static bool visible = false;
        public static uint timeStart;
        public Color color = new(63, 82, 151);

        public override void OnInitialize()
        {
            StoragePanel = new();
            StoragePanel.SetPadding(0);
            StoragePanel.HAlign = 0.615f;
            StoragePanel.VAlign = 0.53f;
            StoragePanel.Width.Set(200f, 0f);
            StoragePanel.Height.Set(46f, 0f);
            StoragePanel.BackgroundColor *= 0f;
            StoragePanel.BorderColor *= 0f;
            Append(StoragePanel);

            ImageButton piggyBank = new(ModContent.Request<Texture2D>("Terraria/Images/Item_" + ItemID.PiggyBank));
            piggyBank.Left.Set(0f, 0f);
            piggyBank.VAlign = 0.5f;
            piggyBank.Width.Set(40f, 0f);
            piggyBank.Height.Set(40f, 0f);
            piggyBank.OnLeftClick += PiggyBankClicked;
            piggyBank.TooltipText = QoLCUISystem.GetUIText("AllInOneAccessUI", "OpenStorage", Lang.GetItemName(ItemID.PiggyBank));
            StoragePanel.Append(piggyBank);

            ImageButton safe = new(ModContent.Request<Texture2D>("Terraria/Images/Item_" + ItemID.Safe));
            safe.Left.Set(40f, 0f);
            safe.VAlign = 0.5f;
            safe.Width.Set(40f, 0f);
            safe.Height.Set(40f, 0f);
            safe.OnLeftClick += SafeClicked;
            safe.TooltipText = QoLCUISystem.GetUIText("AllInOneAccessUI", "OpenStorage", Lang.GetItemName(ItemID.Safe));
            StoragePanel.Append(safe);

            ImageButton defendersForge = new(ModContent.Request<Texture2D>("Terraria/Images/Item_" + ItemID.DefendersForge));
            defendersForge.Left.Set(80f, 0f);
            defendersForge.VAlign = 0.5f;
            defendersForge.Width.Set(40f, 0f);
            defendersForge.Height.Set(40f, 0f);
            defendersForge.OnLeftClick += DefendersForgeClicked;
            defendersForge.TooltipText = QoLCUISystem.GetUIText("AllInOneAccessUI", "OpenStorage", Lang.GetItemName(ItemID.DefendersForge));
            StoragePanel.Append(defendersForge);

            ImageButton voidVault = new(ModContent.Request<Texture2D>("Terraria/Images/Item_" + ItemID.ClosedVoidBag));
            voidVault.Left.Set(120f, 0f);
            voidVault.VAlign = 0.5f;
            voidVault.Width.Set(40f, 0f);
            voidVault.Height.Set(40f, 0f);
            voidVault.OnLeftClick += VoidVaultClicked;
            voidVault.TooltipText = QoLCUISystem.GetUIText("AllInOneAccessUI", "OpenStorage", Lang.GetItemName(ItemID.VoidLens));
            StoragePanel.Append(voidVault);

            ImageButton closeButton = new(Common.GetAsset("Buttons", "Button_Small_", 3));
            closeButton.Left.Set(160f, 0f);
            closeButton.VAlign = 0.5f;
            closeButton.Width.Set(40f, 0f);
            closeButton.Height.Set(40f, 0f);
            closeButton.OnLeftClick += CloseButtonClicked;
            closeButton.TooltipText = Language.GetTextValue("LegacyInterface.52");
            StoragePanel.Append(closeButton);
        }

        private void PiggyBankClicked(UIMouseEvent evt, UIElement listeningElement) => StorageClick(BankSystem.PiggyBank, SoundID.Item59);
        private void SafeClicked(UIMouseEvent evt, UIElement listeningElement) => StorageClick(BankSystem.Safe, SoundID.MenuOpen);
        private void DefendersForgeClicked(UIMouseEvent evt, UIElement listeningElement) => StorageClick(BankSystem.DefendersForge, SoundID.MenuOpen);
        private void VoidVaultClicked(UIMouseEvent evt, UIElement listeningElement) => StorageClick(BankSystem.VoidVault, SoundID.Item130);

        private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                SoundEngine.PlaySound(SoundID.MenuClose);
                visible = false;
            }
        }

        public static void StorageClick(int bankID, SoundStyle sound)
        {
            Player Player = Main.LocalPlayer;

            if (Player.chest != bankID)
            {
                Main.playerInventory = true;

                Player.chest = bankID;
                BankSystem.LastOpenedBank = bankID;

                Point pos = Player.Center.ToTileCoordinates();
                Player.chestX = pos.X;
                Player.chestY = pos.Y;

                Player.SetTalkNPC(-1);
                Main.SetNPCShopIndex(0);

                SoundEngine.PlaySound(sound, Main.LocalPlayer.position, null);
            }
            else
            {
                Player.chest = -1;
                BankSystem.LastOpenedBank = null;
            }
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Rectangle target = new((int)StoragePanel.GetDimensions().X, (int)StoragePanel.GetDimensions().Y, (int)StoragePanel.GetDimensions().Width, (int)StoragePanel.GetDimensions().Height);
            BackgroundDrawing.DrawBackground(spriteBatch, target, color);
            BackgroundDrawing.DrawBorder(spriteBatch, target, color);
        }
    }
}
