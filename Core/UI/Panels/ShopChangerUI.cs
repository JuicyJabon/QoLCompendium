using QoLCompendium.Content.NPCs.Town;
using QoLCompendium.Core.UI.Buttons;

namespace QoLCompendium.Core.UI.Panels
{
    public class ShopChangerUI : UIState
    {
        public UIPanel MainPanel;
        public int talkNPCIndex;

        public override void OnInitialize()
        {
            MainPanel = new();
            MainPanel.SetPadding(0);
            MainPanel.SetAlign(0.5f, 0.04f);
            MainPanel.SetSize(new(850f, 60f));
            MainPanel.BackgroundColor *= 0f;
            MainPanel.BorderColor *= 0f;
            Append(MainPanel);
        }

        public override void OnActivate()
        {
            MainPanel.RemoveAllChildren();
            PopulateButtons();
        }

        public void PopulateButtons()
        {
            if (Main.npc[talkNPCIndex].ModNPC is QoLCTownNPC townNPC)
            {
                for (int i = 0; i < townNPC.AllShops.Count; i++)
                {
                    string match = townNPC.AllShops.ElementAt(i).Replace("Modded", "");
                    int itemID = QoLCShopUISystem.shopIcons.FirstOrDefault(x => x.Key.Contains(match)).Value;
                    ImageButton shopButton = new(ModContent.Request<Texture2D>("Terraria/Images/Item_" + itemID));
                    shopButton.Left.Set(i * 50, 0f);
                    shopButton.VAlign = 0.5f;
                    shopButton.Width.Set(50f, 0f);
                    shopButton.Height.Set(50f, 0f);
                    shopButton.TooltipText = QoLCUISystem.GetNPCUIText(Main.npc[talkNPCIndex].ModNPC.Name, townNPC.AllShops.ElementAt(i));
                    shopButton.IdentificationText = townNPC.AllShops.ElementAt(i);
                    shopButton.OnLeftClick += ShopClicked;
                    MainPanel.Append(shopButton);
                }
            }
        }

        private void ShopClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            ImageButton button = listeningElement as ImageButton;
            if (Main.npc[talkNPCIndex].ModNPC is QoLCTownNPC townNPC)
            {
                townNPC.ChangeShopName(button.IdentificationText);
                SoundEngine.PlaySound(SoundID.MenuOpen);
            }
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            if (Main.LocalPlayer.chest != -1 || Main.LocalPlayer.sign != -1 || Main.LocalPlayer.TalkNPC != Main.npc[talkNPCIndex] || Main.playerInventory || Main.InGuideCraftMenu)
                ModContent.GetInstance<QoLCShopUISystem>().HideShopChanger();

            Rectangle target = new((int)MainPanel.GetDimensions().X, (int)MainPanel.GetDimensions().Y, (int)MainPanel.GetDimensions().Width, (int)MainPanel.GetDimensions().Height);
            BackgroundDrawing.DrawBackground(spriteBatch, target, default);
            BackgroundDrawing.DrawBorder(spriteBatch, target, default);
        }

        public void UpdateTalkNPC(int newIndex)
        {
            talkNPCIndex = newIndex;
        }
    }
}
