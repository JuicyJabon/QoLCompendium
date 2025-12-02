using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.UI.Buttons;
using System.Linq;
using Terraria.GameInput;
using static FargowiltasSouls.FargoSoulsSets;

namespace QoLCompendium.Core.UI.Panels
{
    public class PermanentBuffTogglerUI : UIState
    {
        public static bool visible = false;
        public static uint timeStart;

        internal UIPanel MainPanel;
        public UIGrid BuffGrid;
        public FixedUIScrollbar Scrollbar;
        private static int _oldBuffCount;

        public override void OnInitialize()
        {
            MainPanel = new();
            MainPanel.HAlign = 0.5f;
            MainPanel.VAlign = 0.3f;
            MainPanel.SetSize(450, 220);
            MainPanel.BackgroundColor = new Color(73, 94, 171);
            Append(MainPanel);

            UIText nameInfo = new UIText(UISystem.BuffTogglerText);
            nameInfo.Left.Set(8f, 0f);
            nameInfo.Top.Set(8f, 0f);
            nameInfo.Width.Set(64f, 0f);
            nameInfo.Height.Set(32f, 0f);
            MainPanel.Append(nameInfo);

            BuffGrid = new UIGrid(11)
            {
                Width = StyleDimension.FromPixelsAndPercent(-18f, 1f),
                Height = StyleDimension.FromPixelsAndPercent(-40f, 1f),
                Top = StyleDimension.FromPixels(40f),
                PaddingBottom = 4f,
                PaddingTop = 4f,
                ListPadding = 4f,
            };
            BuffGrid.SetPadding(2f);
            MainPanel.Append(BuffGrid);

            Scrollbar = new()
            {
                Left = { Pixels = -10f, Percent = 1f },
                Width = { Pixels = 18f },
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
            for (int i = 0; i < QoLCPlayer.Get(Main.LocalPlayer).activeBuffs.Count; i++)
            {
                Common.AllEffects.TryGetValue(QoLCPlayer.Get(Main.LocalPlayer).activeBuffs.ElementAt(i), out BuffEffect value);
                if (value != null)
                    BuffGrid.Add(new BuffButton(QoLCPlayer.Get(Main.LocalPlayer).activeBuffs.ElementAt(i), value.EffectType));
                else
                    BuffGrid.Add(new BuffButton(QoLCPlayer.Get(Main.LocalPlayer).activeBuffs.ElementAt(i), 0));
            }
            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            BuffGrid.Recalculate();

            if (MainPanel.IsMouseHovering || Scrollbar.IsMouseHovering)
            {
                PlayerInput.LockVanillaMouseScroll("QolCompendium: Buff Toggler UI");
                Main.LocalPlayer.mouseInterface = true;
            }

            base.DrawSelf(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
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
                string text = UISystem.NoBuffText.Value;

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
            UserInterface.ActiveInstance = UISystem.permanentBuffTogglerInterface;
            base.DrawSelf(spriteBatch);
            UserInterface.ActiveInstance = temp;
        }

        public override void LeftMouseDown(UIMouseEvent evt)
        {
            UserInterface temp = UserInterface.ActiveInstance;
            UserInterface.ActiveInstance = UISystem.permanentBuffTogglerInterface;
            base.LeftMouseDown(evt);
            UserInterface.ActiveInstance = temp;
        }
    }
}
