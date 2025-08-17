using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.UI.Buttons;

namespace QoLCompendium.Core.UI.Panels
{
    public class PermanentHomewardJourneyBuffUI : UIState
    {
        public UIPanel BuffPanel;
        public static bool visible = false;
        public static uint timeStart;

        //ARENA
        public static PermanentBuffButton BushOfLifeButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton LifeLanternButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));

        //POTIONS
        public static PermanentBuffButton FlightButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton FluorescentBerryButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton HasteButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton ReanimationButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton YangButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton YinButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));

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

            UIText arenaText = new(UISystem.ArenaText);
            arenaText.Left.Set(16f, 0f);
            arenaText.Top.Set(8f, 0f);
            arenaText.Width.Set(64f, 0f);
            arenaText.Height.Set(32f, 0f);
            BuffPanel.Append(arenaText);

            UIText potionText = new(UISystem.PotionText);
            potionText.Left.Set(16f, 0f);
            potionText.Top.Set(72f, 0f);
            potionText.Width.Set(64f, 0f);
            potionText.Height.Set(32f, 0f);
            BuffPanel.Append(potionText);

            #region Arena
            //Bush of Life
            CreateBuffButton(BushOfLifeButton, 16f, 32f);
            BushOfLifeButton.OnLeftClick += BushOfLifeClicked;
            BuffPanel.Append(BushOfLifeButton);

            //Life Lantern
            CreateBuffButton(LifeLanternButton, 48f, 32f);
            LifeLanternButton.OnLeftClick += LifeLanternClicked;
            BuffPanel.Append(LifeLanternButton);
            #endregion

            #region Potions
            //Flight
            CreateBuffButton(FlightButton, 16f, 96f);
            FlightButton.OnLeftClick += FlightClicked;
            BuffPanel.Append(FlightButton);

            //Fluorescent Berry
            CreateBuffButton(FluorescentBerryButton, 48f, 96f);
            FluorescentBerryButton.OnLeftClick += FluorescentBerryClicked;
            BuffPanel.Append(FluorescentBerryButton);

            //Haste
            CreateBuffButton(HasteButton, 80f, 96f);
            HasteButton.OnLeftClick += HasteClicked;
            BuffPanel.Append(HasteButton);

            //Reanimation
            CreateBuffButton(ReanimationButton, 112f, 96f);
            ReanimationButton.OnLeftClick += ReanimationClicked;
            BuffPanel.Append(ReanimationButton);

            //Yang
            CreateBuffButton(YangButton, 144f, 96f);
            YangButton.OnLeftClick += YangClicked;
            BuffPanel.Append(YangButton);

            //Yin
            CreateBuffButton(YinButton, 176f, 96f);
            YinButton.OnLeftClick += YinClicked;
            BuffPanel.Append(YinButton);
            #endregion

            HashSet<PermanentBuffButton> buttons = new()
            {
                //arena
                BushOfLifeButton,
                LifeLanternButton,
                //potion
                FlightButton,
                FluorescentBerryButton,
                HasteButton,
                ReanimationButton,
                YangButton,
                YinButton
            };
            allBuffButtons.UnionWith(buttons);

            Append(BuffPanel);
        }

        #region Arena
        private void BushOfLifeClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentHomewardJourneyBuffs.BushOfLife, BushOfLifeButton);
        private void LifeLanternClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentHomewardJourneyBuffs.LifeLantern, LifeLanternButton);
        #endregion

        #region Potions
        private void FlightClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentHomewardJourneyBuffs.Flight, FlightButton);
        private void FluorescentBerryClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentHomewardJourneyBuffs.FluorescentBerry, FluorescentBerryButton);
        private void HasteClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentHomewardJourneyBuffs.Haste, HasteButton);
        private void ReanimationClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentHomewardJourneyBuffs.Reanimation, ReanimationButton);
        private void YangClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentHomewardJourneyBuffs.Yang, YangButton);
        private void YinClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentHomewardJourneyBuffs.Yin, YinButton);
        #endregion

        public static void GetHomewardJourneyBuffData()
        {
            if (!ModConditions.homewardJourneyLoaded)
                return;

            //TOOLTIPS
            //ARENA
            BushOfLifeButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.homewardJourneyMod, "BushOfLifeBuff")).DisplayName;
            LifeLanternButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.homewardJourneyMod, "LifeLanternBuff")).DisplayName;
            //POTIONS
            FlightButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.homewardJourneyMod, "FlightBuff")).DisplayName;
            FluorescentBerryButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.homewardJourneyMod, "FluorescentBerryBuff")).DisplayName;
            HasteButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.homewardJourneyMod, "HasteBuff")).DisplayName;
            ReanimationButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.homewardJourneyMod, "ReanimationBuff")).DisplayName;
            YangButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.homewardJourneyMod, "YangPotionBuff")).DisplayName;
            YinButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.homewardJourneyMod, "NerveFibreBuff")).DisplayName;

            //SPRITES
            //ARENA
            BushOfLifeButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.homewardJourneyMod, Common.GetModBuff(ModConditions.homewardJourneyMod, "BushOfLifeBuff")));
            LifeLanternButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.homewardJourneyMod, Common.GetModBuff(ModConditions.homewardJourneyMod, "LifeLanternBuff")));
            //POTIONS
            FlightButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.homewardJourneyMod, Common.GetModBuff(ModConditions.homewardJourneyMod, "FlightBuff")));
            FluorescentBerryButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.homewardJourneyMod, Common.GetModBuff(ModConditions.homewardJourneyMod, "FluorescentBerryBuff")));
            HasteButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.homewardJourneyMod, Common.GetModBuff(ModConditions.homewardJourneyMod, "HasteBuff")));
            ReanimationButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.homewardJourneyMod, Common.GetModBuff(ModConditions.homewardJourneyMod, "ReanimationBuff")));
            YangButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.homewardJourneyMod, Common.GetModBuff(ModConditions.homewardJourneyMod, "YangPotionBuff")));
            YinButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.homewardJourneyMod, Common.GetModBuff(ModConditions.homewardJourneyMod, "NerveFibreBuff")));
        }

        public override void Update(GameTime gameTime)
        {
            if (!visible)
                return;

            for (int i = 0; i < Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentHomewardJourneyBuffsBools.Length; i++)
            {
                allBuffButtons.ElementAt(i).disabled = Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentHomewardJourneyBuffsBools[i];
                allBuffButtons.ElementAt(i).moddedBuff = true;
            }
        }

        public static void BuffClick(int buff, PermanentBuffButton button)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentHomewardJourneyBuffsBools[buff] = !Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentHomewardJourneyBuffsBools[buff];
                button.disabled = Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentHomewardJourneyBuffsBools[buff];
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
