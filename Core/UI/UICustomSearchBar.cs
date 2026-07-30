using Microsoft.Xna.Framework.Input;
using ReLogic.Graphics;
using Terraria.GameInput;

namespace QoLCompendium.Core.UI
{
    public class UICustomSearchBar : UIPanel
    {
        internal bool focused = false;

        private int _maxLength = 60;

        public string hintText;
        internal string currentString = "";
        private int textBlinkerCount;
        private int textBlinkerState;

        public event Action OnFocus;

        public event Action OnUnfocus;

        public event Action OnTextChanged;

        public event Action OnTabPressed;

        public event Action OnEnterPressed;

        internal bool unfocusOnEnter = true;

        internal bool unfocusOnTab = true;

        public Color bgColor = Color.White;

        public UICustomSearchBar(string hintText, string text = "")
        {
            this.hintText = hintText;
            currentString = text;
            SetPadding(0);
            BackgroundColor *= 0f;
            BorderColor *= 0f;
        }

        public override void LeftClick(UIMouseEvent evt)
        {
            Focus();
            base.LeftClick(evt);
        }

        public override void RightClick(UIMouseEvent evt)
        {
            base.RightClick(evt);
            SetText("");
        }

        public void SetUnfocusKeys(bool unfocusOnEnter, bool unfocusOnTab)
        {
            this.unfocusOnEnter = unfocusOnEnter;
            this.unfocusOnTab = unfocusOnTab;
        }

        public void Unfocus()
        {
            if (focused)
            {
                focused = false;
                Main.blockInput = false;

                OnUnfocus?.Invoke();
            }
        }

        public void Focus()
        {
            if (!focused)
            {
                Main.clrInput();
                focused = true;
                Main.blockInput = true;

                OnFocus?.Invoke();
            }
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 MousePosition = new((float)Main.mouseX, (float)Main.mouseY);
            if (!ContainsPoint(MousePosition) && (Main.mouseLeft || Main.mouseRight))
            {
                Unfocus();
            }
            SetText(currentString);
            base.Update(gameTime);
        }

        public void SetText(string text)
        {
            if (text.ToString().Length > this._maxLength)
            {
                text = text.ToString()[..this._maxLength];
            }
            if (currentString != text)
            {
                currentString = text;
                OnTextChanged?.Invoke();
            }
        }

        public void SetTextMaxLength(int maxLength)
        {
            this._maxLength = maxLength;
        }
        private static bool JustPressed(Keys key)
        {
            return Main.inputText.IsKeyDown(key) && !Main.oldInputText.IsKeyDown(key);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Rectangle hitbox = GetInnerDimensions().ToRectangle();

            base.DrawSelf(spriteBatch);

            Rectangle target = new((int)this.GetDimensions().X, (int)this.GetDimensions().Y, (int)this.GetDimensions().Width, (int)this.GetDimensions().Height);
            BackgroundDrawing.DrawBackground(spriteBatch, target, bgColor, "DefaultNoShading");
            BackgroundDrawing.DrawBorder(spriteBatch, target, bgColor, "DefaultNoShading");

            if (focused)
            {
                PlayerInput.WritingText = true;
                Main.instance.HandleIME();
                string newString = Main.GetInputText(currentString);
                if (!newString.Equals(currentString))
                {
                    currentString = newString;
                    OnTextChanged?.Invoke();
                }
                else
                {
                    currentString = newString;
                }

                if (JustPressed(Keys.Tab))
                {
                    if (unfocusOnTab) Unfocus();
                    OnTabPressed?.Invoke();
                }
                if (JustPressed(Keys.Enter))
                {
                    Main.drawingPlayerChat = false;
                    if (unfocusOnEnter) Unfocus();
                    OnEnterPressed?.Invoke();
                }
                if (++textBlinkerCount >= 20)
                {
                    textBlinkerState = (textBlinkerState + 1) % 2;
                    textBlinkerCount = 0;
                }
                Main.instance.DrawWindowsIMEPanel(new Vector2(98f, (float)(Main.screenHeight - 36)), 0f);
            }
            string displayString = currentString;
            if (this.textBlinkerState == 1 && focused)
            {
                displayString = displayString + "|";
            }
            CalculatedStyle space = base.GetDimensions();
            Color color = Color.Black;
            if (currentString.Length == 0)
            {
            }
            Vector2 drawPos = space.Position() + new Vector2(4, 2);
            if (currentString.Length == 0 && !focused)
            {
                color *= 0.5f;
                spriteBatch.DrawString(FontAssets.MouseText.Value, hintText, drawPos, color);
            }
            else
            {
                spriteBatch.DrawString(FontAssets.MouseText.Value, displayString, drawPos, color);
            }
        }
    }
}