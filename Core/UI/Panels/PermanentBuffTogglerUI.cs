using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.UI.Buttons;
using Terraria.GameInput;

namespace QoLCompendium.Core.UI.Panels
{
    public class PermanentBuffTogglerUI : UIState
    {
        public static bool visible = false;
        public static uint timeStart;

        internal static string GetUIText(string key, string category = "PermanentBuffTogglerUI") => QoLCUISystem.GetUIText(category, key);

        internal UIPanel MainPanel;
        internal UIPanel bgPanel;

        public UIGrid BuffGrid;
        public UICustomSearchBar BuffSearchBar;
        public FixedUIScrollbar Scrollbar;
        private static int _oldBuffCount;

        public Color color = new(73, 94, 171);

        public override void OnInitialize()
        {
            MainPanel = new();
            MainPanel.HAlign = 0.5f;
            MainPanel.VAlign = 0.3f;
            MainPanel.SetSize(444f, 213f);
            MainPanel.BackgroundColor *= 0f;
            MainPanel.BorderColor *= 0f;
            Append(MainPanel);

            bgPanel = new();
            bgPanel.BackgroundColor *= 0f;
            bgPanel.BorderColor *= 0f;
            bgPanel.Width = StyleDimension.FromPixelsAndPercent(-18f, 1f);
            bgPanel.Height = StyleDimension.FromPixelsAndPercent(-40f, 1f);
            bgPanel.Top = StyleDimension.FromPixels(40f);
            MainPanel.Append(bgPanel);

            BuffSearchBar = new(GetUIText("BuffSearchEmptyText"));
            BuffSearchBar.SetTextMaxLength(20);
            BuffSearchBar.SetSize(200f, 28f);
            BuffSearchBar.Top.Set(4f, 0f);
            BuffSearchBar.Left.Set(225f, 0f);
            BuffSearchBar.OnTextChanged += SetupBuffButtons;
            MainPanel.Append(BuffSearchBar);

            UIText titleText = new(GetUIText("BuffTogglerText"));
            titleText.Left.Set(8f, 0f);
            titleText.Top.Set(8f, 0f);
            titleText.Width.Set(64f, 0f);
            titleText.Height.Set(32f, 0f);
            MainPanel.Append(titleText);

            BuffGrid = new UIGrid(11)
            {
                Width = StyleDimension.FromPixelsAndPercent(-18f, 1f),
                Height = StyleDimension.FromPixelsAndPercent(-40f, 1f),
                Top = StyleDimension.FromPixels(40f),
                PaddingLeft = 4f,
                PaddingRight = 4f,
                PaddingBottom = 4f,
                PaddingTop = 4f,
                ListPadding = 4f,
            };
            BuffGrid._innerList.SetPadding(2f);
            BuffGrid.SetPadding(2f);
            MainPanel.Append(BuffGrid);

            Scrollbar = new()
            {
                Left = { Pixels = -16f, Percent = 1f },
                Width = { Pixels = 20f },
                Top = { Pixels = 44f },
                Height = { Pixels = -48f, Percent = 1f }
            };
            Scrollbar.SetView(100f, 1000f);
            MainPanel.Append(Scrollbar);
            BuffGrid.SetScrollbar(Scrollbar);
        }

        public override void ScrollWheel(UIScrollWheelEvent evt)
        {
            if (MainPanel.IsMouseHovering || Scrollbar.IsMouseHovering)
                Scrollbar.ViewPosition -= evt.ScrollWheelValue;
        }

        public void SetupBuffButtons()
        {
            BuffGrid.Clear();

            string search = BuffSearchBar.currentString.Trim().ToLower();

            for (int i = 0; i < QoLCPlayer.Get(Main.LocalPlayer).activeBuffs.Count; i++)
            {
                Constants.AllEffects.TryGetValue(QoLCPlayer.Get(Main.LocalPlayer).activeBuffs.ElementAt(i), out BuffEffect effect);

                if (string.IsNullOrEmpty(search) || Match(search, QoLCPlayer.Get(Main.LocalPlayer).activeBuffs.ElementAt(i)))
                {
                    if (effect != null)
                        BuffGrid.Add(new BuffButton(QoLCPlayer.Get(Main.LocalPlayer).activeBuffs.ElementAt(i), effect.EffectType));
                    else
                        BuffGrid.Add(new BuffButton(QoLCPlayer.Get(Main.LocalPlayer).activeBuffs.ElementAt(i), 0));
                }
            }
            Recalculate();
        }

        private static bool Match(string searchString, int buffId)
        {
            string name = Lang.GetBuffName(buffId).ToLower();
            return name.Contains(searchString);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            BuffGrid.Recalculate();

            if (MainPanel.IsMouseHovering || Scrollbar.IsMouseHovering)
            {
                PlayerInput.LockVanillaMouseScroll("QolCompendium: Buff Toggler UI");
                Main.LocalPlayer.mouseInterface = true;
            }

            Rectangle target = new((int)MainPanel.GetDimensions().X, (int)MainPanel.GetDimensions().Y, (int)MainPanel.GetDimensions().Width, (int)MainPanel.GetDimensions().Height);
            BackgroundDrawing.DrawBackground(spriteBatch, target, color);
            BackgroundDrawing.DrawBorder(spriteBatch, target, color);

            Rectangle bgTarget = new((int)bgPanel.GetDimensions().X, (int)bgPanel.GetDimensions().Y, (int)bgPanel.GetDimensions().Width, (int)bgPanel.GetDimensions().Height);
            BackgroundDrawing.DrawBackground(spriteBatch, bgTarget, new Color(color.R - 30, color.G - 30, color.B - 30), "SquareNoShading");
            BackgroundDrawing.DrawBorder(spriteBatch, bgTarget, new Color(color.R - 30, color.G - 30, color.B - 30), "SquareNoShading");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            BuffSearchBar.hintText = GetUIText("BuffSearchEmptyText");

            if (_oldBuffCount != QoLCPlayer.Get(Main.LocalPlayer).activeBuffs.Count)
            {
                _oldBuffCount = QoLCPlayer.Get(Main.LocalPlayer).activeBuffs.Count;
                SetupBuffButtons();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Player player = Main.LocalPlayer;
            if (player.dead || !player.active || !visible)
                return;

            base.Draw(spriteBatch);

            var panelDimensions = MainPanel.GetDimensions();

            if (QoLCPlayer.Get(Main.LocalPlayer).activeBuffs.Count < 1)
            {
                Vector2 drawCenter = panelDimensions.Center();
                drawCenter.Y += 10f;
                const float scale = 0.5f;
                string text = GetUIText("NoBuffText");

                float textWidth = FontAssets.DeathText.Value.MeasureString(text).X * 0.5f;
                Vector2 origin = new(textWidth, 0f);
                Utils.DrawBorderStringFourWay(spriteBatch, FontAssets.DeathText.Value, text, drawCenter.X, drawCenter.Y,
                    Color.White, Color.Black, origin, scale);
            }
        }
    }

    public class FixedUIScrollbar : UIScrollbar
    {
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            UserInterface temp = UserInterface.ActiveInstance;
            UserInterface.ActiveInstance = ModContent.GetInstance<QoLCUISystem>().permanentBuffTogglerInterface;
            base.DrawSelf(spriteBatch);
            UserInterface.ActiveInstance = temp;
        }

        public override void LeftMouseDown(UIMouseEvent evt)
        {
            UserInterface temp = UserInterface.ActiveInstance;
            UserInterface.ActiveInstance = ModContent.GetInstance<QoLCUISystem>().permanentBuffTogglerInterface;
            base.LeftMouseDown(evt);
            UserInterface.ActiveInstance = temp;
        }
    }
}
