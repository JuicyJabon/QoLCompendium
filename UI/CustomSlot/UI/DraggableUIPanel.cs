﻿// Code modified from tModLoader ExampleMod
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace CustomSlot.UI {
    public class DraggableUIPanel : UIPanel {
        public const byte DefaultBackgroundAlpha = 178;

        private readonly Color defaultBackgroundColor = new(44, 57, 105, DefaultBackgroundAlpha);
        private readonly Color defaultBorderColor = Color.Black;

        private Vector2 offset;
        private bool dragging = false;
        private bool visible = true;

        public event PanelDragEventHandler OnDragBegin;
        public event PanelDragEventHandler OnDragEnd;
        public event PanelDragEventHandler OnDrag;

        public bool CanDrag { get; set; } = true;

        public bool Visible {
            get => visible;
            set {
                visible = value;

                BackgroundColor = visible ? defaultBackgroundColor : Color.Transparent;
                BorderColor = visible ? defaultBorderColor : Color.Transparent;
            }
        }

        public override void LeftMouseDown(UIMouseEvent evt) {
            if(!visible) return;

            base.LeftMouseDown(evt);

            if(!CanDrag) return;

            if(ContainsPoint(evt.MousePosition) &&
               !GetInnerDimensions().ToRectangle().Contains(evt.MousePosition.ToPoint())) {
                DragBegin(evt);
            }
        }

        public override void LeftMouseUp(UIMouseEvent evt) {
            if(!visible) return;

            base.LeftMouseUp(evt);

            if(!CanDrag) return;

            if(dragging)
                DragEnd(evt);
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            if(!visible) return;

            if(ContainsPoint(Main.MouseScreen)) {
                Main.LocalPlayer.mouseInterface = true;
            }

            if(dragging) {
                Left.Set(Main.mouseX - offset.X, 0);
                Top.Set(Main.mouseY - offset.Y, 0);

                OnDrag?.Invoke(this, new PanelDragEventArgs(Left, Top));
            }

            Rectangle parentDimensions = Parent.GetDimensions().ToRectangle();

            if(!GetDimensions().ToRectangle().Intersects(parentDimensions)) {
                Left.Pixels = Utils.Clamp(Left.Pixels, 0, parentDimensions.Right - Width.Pixels);
                Top.Pixels = Utils.Clamp(Top.Pixels, 0, parentDimensions.Bottom - Height.Pixels);
            }
        }

        private void DragBegin(UIMouseEvent e) {
            offset = new Vector2(e.MousePosition.X - Left.Pixels, e.MousePosition.Y - Top.Pixels);
            dragging = true;

            OnDragBegin?.Invoke(this, new PanelDragEventArgs(Left, Top));
        }

        private void DragEnd(UIMouseEvent e) {
            Vector2 end = e.MousePosition;
            dragging = false;

            Left.Set(end.X - offset.X, 0);
            Top.Set(end.Y - offset.Y, 0);

            OnDragEnd?.Invoke(this, new PanelDragEventArgs(Left, Top));
        }
    }
}
