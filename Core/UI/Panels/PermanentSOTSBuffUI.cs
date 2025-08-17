using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.UI.Buttons;

namespace QoLCompendium.Core.UI.Panels
{
    public class PermanentSOTSBuffUI : UIState
    {
        public UIPanel BuffPanel;
        public static bool visible = false;
        public static uint timeStart;

        //POTIONS
        public static PermanentBuffButton AssassinationButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton BluefireButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton BrittleButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton DoubleVisionButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton HarmonyButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton NightmareButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton RippleButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton RoughskinButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton SoulAccessButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton VibeButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));

        //STATIONS
        public static PermanentBuffButton DigitalDisplayButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));

        public static HashSet<PermanentBuffButton> allBuffButtons = new();

        public override void OnInitialize()
        {
            BuffPanel = new UIPanel();
            BuffPanel.SetPadding(0);
            BuffPanel.Left.Set(575f, 0f);
            BuffPanel.Top.Set(275f, 0f);
            BuffPanel.Width.Set(352f, 0f);
            BuffPanel.Height.Set(144f, 0f);
            BuffPanel.BackgroundColor = new Color(73, 94, 171);

            BuffPanel.OnLeftMouseDown += new MouseEvent(DragStart);
            BuffPanel.OnLeftMouseUp += new MouseEvent(DragEnd);

            UIText potionText = new(UISystem.PotionText);
            potionText.Left.Set(16f, 0f);
            potionText.Top.Set(8f, 0f);
            potionText.Width.Set(64f, 0f);
            potionText.Height.Set(32f, 0f);
            BuffPanel.Append(potionText);

            UIText stationsText = new(UISystem.StationText);
            stationsText.Left.Set(16f, 0f);
            stationsText.Top.Set(72f, 0f);
            stationsText.Width.Set(64f, 0f);
            stationsText.Height.Set(32f, 0f);
            BuffPanel.Append(stationsText);

            #region Potions
            //Assassination
            CreateBuffButton(AssassinationButton, 16f, 32f);
            AssassinationButton.OnLeftClick += AssassinationClicked;
            BuffPanel.Append(AssassinationButton);

            //Bluefire
            CreateBuffButton(BluefireButton, 48f, 32f);
            BluefireButton.OnLeftClick += BluefireClicked;
            BuffPanel.Append(BluefireButton);

            //Brittle
            CreateBuffButton(BrittleButton, 80f, 32f);
            BrittleButton.OnLeftClick += BrittleClicked;
            BuffPanel.Append(BrittleButton);

            //Double Vision
            CreateBuffButton(DoubleVisionButton, 112f, 32f);
            DoubleVisionButton.OnLeftClick += DoubleVisionClicked;
            BuffPanel.Append(DoubleVisionButton);

            //Harmony
            CreateBuffButton(HarmonyButton, 144f, 32f);
            HarmonyButton.OnLeftClick += HarmonyClicked;
            BuffPanel.Append(HarmonyButton);

            //Nightmare
            CreateBuffButton(NightmareButton, 176f, 32f);
            NightmareButton.OnLeftClick += NightmareClicked;
            BuffPanel.Append(NightmareButton);

            //Ripple
            CreateBuffButton(RippleButton, 208f, 32f);
            RippleButton.OnLeftClick += RippleClicked;
            BuffPanel.Append(RippleButton);

            //Roughskin
            CreateBuffButton(RoughskinButton, 240f, 32f);
            RoughskinButton.OnLeftClick += RoughskinClicked;
            BuffPanel.Append(RoughskinButton);

            //Soul Access
            CreateBuffButton(SoulAccessButton, 272f, 32f);
            SoulAccessButton.OnLeftClick += SoulAccessClicked;
            BuffPanel.Append(SoulAccessButton);

            //Vibe
            CreateBuffButton(VibeButton, 304f, 32f);
            VibeButton.OnLeftClick += VibeClicked;
            BuffPanel.Append(VibeButton);
            #endregion

            #region Stations
            //Digital Display
            CreateBuffButton(DigitalDisplayButton, 16f, 96f);
            DigitalDisplayButton.OnLeftClick += DigitalDisplayClicked;
            BuffPanel.Append(DigitalDisplayButton);
            #endregion

            HashSet<PermanentBuffButton> buttons = new()
            {
                //potion
                AssassinationButton,
                BluefireButton,
                BrittleButton,
                DoubleVisionButton,
                HarmonyButton,
                NightmareButton,
                RippleButton,
                RoughskinButton,
                SoulAccessButton,
                VibeButton,
                //station
                DigitalDisplayButton
            };
            allBuffButtons.UnionWith(buttons);

            Append(BuffPanel);
        }

        #region Potions
        private void AssassinationClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSOTSBuffs.Assassination, AssassinationButton);
        private void BluefireClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSOTSBuffs.Bluefire, BluefireButton);
        private void BrittleClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSOTSBuffs.Brittle, BrittleButton);
        private void DoubleVisionClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSOTSBuffs.DoubleVision, DoubleVisionButton);
        private void HarmonyClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSOTSBuffs.Harmony, HarmonyButton);
        private void NightmareClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSOTSBuffs.Nightmare, NightmareButton);
        private void RippleClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSOTSBuffs.Ripple, RippleButton);
        private void RoughskinClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSOTSBuffs.Roughskin, RoughskinButton);
        private void SoulAccessClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSOTSBuffs.SoulAccess, SoulAccessButton);
        private void VibeClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSOTSBuffs.Vibe, VibeButton);
        #endregion

        #region Stations
        private void DigitalDisplayClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSOTSBuffs.DigitalDisplay, DigitalDisplayButton);
        #endregion

        public static void GetSOTSBuffData()
        {
            if (!ModConditions.secretsOfTheShadowsLoaded)
                return;

            //TOOLTIPS
            //POTIONS
            AssassinationButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "Assassination")).DisplayName;
            BluefireButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "Bluefire")).DisplayName;
            BrittleButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "Brittle")).DisplayName;
            DoubleVisionButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "DoubleVision")).DisplayName;
            HarmonyButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "Harmony")).DisplayName;
            NightmareButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "Nightmare")).DisplayName;
            RippleButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "RippleBuff")).DisplayName;
            RoughskinButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "Roughskin")).DisplayName;
            SoulAccessButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "SoulAccess")).DisplayName;
            VibeButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "GoodVibes")).DisplayName;
            //STATIONS
            DigitalDisplayButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "CyberneticEnhancements")).DisplayName;

            //SPRITES
            //POTIONS
            AssassinationButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.secretsOfTheShadowsMod, Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "Assassination")));
            BluefireButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.secretsOfTheShadowsMod, Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "Bluefire")));
            BrittleButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.secretsOfTheShadowsMod, Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "Brittle")));
            DoubleVisionButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.secretsOfTheShadowsMod, Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "DoubleVision")));
            HarmonyButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.secretsOfTheShadowsMod, Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "Harmony")));
            NightmareButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.secretsOfTheShadowsMod, Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "Nightmare")));
            RippleButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.secretsOfTheShadowsMod, Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "RippleBuff")));
            RoughskinButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.secretsOfTheShadowsMod, Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "Roughskin")));
            SoulAccessButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.secretsOfTheShadowsMod, Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "SoulAccess")));
            VibeButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.secretsOfTheShadowsMod, Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "GoodVibes")));
            //STATIONS
            DigitalDisplayButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.secretsOfTheShadowsMod, Common.GetModBuff(ModConditions.secretsOfTheShadowsMod, "CyberneticEnhancements")));
        }

        public override void Update(GameTime gameTime)
        {
            if (!visible)
                return;

            for (int i = 0; i < Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentSOTSBuffsBools.Length; i++)
            {
                allBuffButtons.ElementAt(i).disabled = Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentSOTSBuffsBools[i];
                allBuffButtons.ElementAt(i).moddedBuff = true;
            }
        }

        public static void BuffClick(int buff, PermanentBuffButton button)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentSOTSBuffsBools[buff] = !Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentSOTSBuffsBools[buff];
                button.disabled = Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentSOTSBuffsBools[buff];
            }
        }

        private static void CreateBuffButton(PermanentBuffButton button, float left, float top)
        {
            button.Left.Set(left, 0f);
            button.Top.Set(top, 0f);
            button.Width.Set(32f, 0f);
            button.Height.Set(32f, 0f);
        }

        Vector2 offset;
        public bool dragging = false;
        private void DragStart(UIMouseEvent evt, UIElement listeningElement)
        {
            offset = new Vector2(evt.MousePosition.X - BuffPanel.Left.Pixels, evt.MousePosition.Y - BuffPanel.Top.Pixels);
            dragging = true;
        }

        private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            dragging = false;

            BuffPanel.Left.Set(end.X - offset.X, 0f);
            BuffPanel.Top.Set(end.Y - offset.Y, 0f);

            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 MousePosition = new(Main.mouseX, Main.mouseY);
            if (BuffPanel.ContainsPoint(MousePosition))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
            if (dragging)
            {
                BuffPanel.Left.Set(MousePosition.X - offset.X, 0f);
                BuffPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
                Recalculate();
            }
        }
    }
}
