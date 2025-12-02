using QoLCompendium.Core.PermanentBuffSystems;
using Terraria.ModLoader.UI;

namespace QoLCompendium.Core.UI.Buttons
{
    internal class BuffButton : UIElement
    {
        internal readonly int BuffId;
        internal readonly int EffectType;

        public BuffButton(int buffId, int effectType = 0)
        {
            BuffId = buffId;
            this.SetSize(32f, 32f);
            EffectType = effectType;
        }

        public override void MouseOver(UIMouseEvent evt)
        {
            SoundEngine.PlaySound(SoundID.MenuTick);
            base.MouseOver(evt);
        }

        public override void LeftMouseDown(UIMouseEvent evt)
        {
            SoundEngine.PlaySound(SoundID.MenuTick);
            NewPermanentBuffPlayer.Get(Main.LocalPlayer).ToggleInfiniteBuff(BuffId);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            bool buffEnabled = !NewPermanentBuffPlayer.Get(Main.LocalPlayer).CheckImmune(BuffId);

            var drawPosition = GetDimensions().Position();
            Asset<Texture2D> buffAsset = BuffId > BuffID.Count - 1 ? ModContent.Request<Texture2D>(BuffLoader.GetBuff(BuffId).Texture) : ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffId);
            Texture2D texture = buffAsset.Value;
            float grayScale = buffEnabled ? 1f : .4f;

            spriteBatch.Draw(texture, GetDimensions().Position(), new Color(grayScale, grayScale, grayScale));

            if (!IsMouseHovering)
                return;

            drawPosition.X -= 2;
            drawPosition.Y -= 2;
            spriteBatch.Draw(Common.GetAsset("Buffs", "PermanentBuff_Hover").Value, drawPosition, Color.White);

            string buffName = Lang.GetBuffName(BuffId);
            string buffTooltip = Main.GetBuffTooltip(Main.LocalPlayer, BuffId);
            int rare = 0;
            if (Main.meleeBuff[BuffId])
                rare = -10;

            BuffLoader.ModifyBuffText(BuffId, ref buffName, ref buffTooltip, ref rare);

            string mouseText = $"{buffName}\n{buffTooltip}";

            if (buffEnabled)
                mouseText += $"\n{UISystem.DisableText}";
            else
                mouseText += $"\n{UISystem.EnableText}";

            UICommon.TooltipMouseText(mouseText);
        }
    }
}
