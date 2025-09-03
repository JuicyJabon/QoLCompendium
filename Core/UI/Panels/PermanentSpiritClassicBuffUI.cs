using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.UI.Buttons;

namespace QoLCompendium.Core.UI.Panels
{
    public class PermanentSpiritClassicBuffUI : UIState
    {
        public UIPanel BuffPanel;
        public static bool visible = false;
        public static uint timeStart;

        //ARENA
        public static PermanentBuffButton CoiledEnergizerButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton KoiTotemButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton SunPotButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton TheCouchButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));

        //POTIONS
        public static PermanentBuffButton JumpButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton MirrorCoatButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton MoonJellyButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton RunescribeButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton SoulguardButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton SpiritButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton SoaringButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton SporecoidButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton StarburnButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton SteadfastButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton ToxinButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton ZephyrButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));

        //CANDIES
        public static PermanentBuffButton CandyButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton ChocolateBarButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton HealthCandyButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton LollipopButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton ManaCandyButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton TaffyButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));

        public static HashSet<PermanentBuffButton> allBuffButtons = new();

        public override void OnInitialize()
        {
            BuffPanel = new UIPanel();
            BuffPanel.SetPadding(0);
            BuffPanel.Left.Set(575f, 0f);
            BuffPanel.Top.Set(275f, 0f);
            BuffPanel.Width.Set(352f, 0f);
            BuffPanel.Height.Set(240f, 0f);
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

            UIText candyText = new(UISystem.CandyText);
            candyText.Left.Set(16f, 0f);
            candyText.Top.Set(168f, 0f);
            candyText.Width.Set(64f, 0f);
            candyText.Height.Set(32f, 0f);
            BuffPanel.Append(candyText);

            #region Arena
            //Coiled Energizer
            CreateBuffButton(CoiledEnergizerButton, 16f, 32f);
            CoiledEnergizerButton.OnLeftClick += CoiledEnergizerClicked;
            BuffPanel.Append(CoiledEnergizerButton);

            //Koi Totem
            CreateBuffButton(KoiTotemButton, 48f, 32f);
            KoiTotemButton.OnLeftClick += KoiTotemClicked;
            BuffPanel.Append(KoiTotemButton);

            //Sun Pot
            CreateBuffButton(SunPotButton, 80f, 32f);
            SunPotButton.OnLeftClick += SunPotClicked;
            BuffPanel.Append(SunPotButton);

            //The Couch
            CreateBuffButton(TheCouchButton, 112f, 32f);
            TheCouchButton.OnLeftClick += TheCouchClicked;
            BuffPanel.Append(TheCouchButton);
            #endregion

            #region Potions
            //Jump
            CreateBuffButton(JumpButton, 16f, 96f);
            JumpButton.OnLeftClick += JumpClicked;
            BuffPanel.Append(JumpButton);

            //Mirror Coat
            CreateBuffButton(MirrorCoatButton, 48f, 96f);
            MirrorCoatButton.OnLeftClick += MirrorCoatClicked;
            BuffPanel.Append(MirrorCoatButton);

            //Moon Jelly
            CreateBuffButton(MoonJellyButton, 80f, 96f);
            MoonJellyButton.OnLeftClick += MoonJellyClicked;
            BuffPanel.Append(MoonJellyButton);

            //Runescribe
            CreateBuffButton(RunescribeButton, 112f, 96f);
            RunescribeButton.OnLeftClick += RunescribeClicked;
            BuffPanel.Append(RunescribeButton);

            //Soulguard
            CreateBuffButton(SoulguardButton, 144f, 96f);
            SoulguardButton.OnLeftClick += SoulguardClicked;
            BuffPanel.Append(SoulguardButton);

            //Spirit
            CreateBuffButton(SpiritButton, 176f, 96f);
            SpiritButton.OnLeftClick += SpiritClicked;
            BuffPanel.Append(SpiritButton);

            //Soaring
            CreateBuffButton(SoaringButton, 208f, 96f);
            SoaringButton.OnLeftClick += SoaringClicked;
            BuffPanel.Append(SoaringButton);

            //Sporecoid
            CreateBuffButton(SporecoidButton, 240f, 96f);
            SporecoidButton.OnLeftClick += SporecoidClicked;
            BuffPanel.Append(SporecoidButton);

            //Starburn
            CreateBuffButton(StarburnButton, 272f, 96f);
            StarburnButton.OnLeftClick += StarburnClicked;
            BuffPanel.Append(StarburnButton);

            //Steadfast
            CreateBuffButton(SteadfastButton, 304f, 96f);
            SteadfastButton.OnLeftClick += SteadfastClicked;
            BuffPanel.Append(SteadfastButton);

            //10

            //Toxin
            CreateBuffButton(ToxinButton, 16f, 128f);
            ToxinButton.OnLeftClick += ToxinClicked;
            BuffPanel.Append(ToxinButton);

            //Zephyr
            CreateBuffButton(ZephyrButton, 48f, 128f);
            ZephyrButton.OnLeftClick += ZephyrClicked;
            BuffPanel.Append(ZephyrButton);
            #endregion

            #region Candies
            //Candy
            CreateBuffButton(CandyButton, 16f, 192f);
            CandyButton.OnLeftClick += CandyClicked;
            BuffPanel.Append(CandyButton);

            //Chocolate Bar
            CreateBuffButton(ChocolateBarButton, 48f, 192f);
            ChocolateBarButton.OnLeftClick += ChocolateBarClicked;
            BuffPanel.Append(ChocolateBarButton);

            //Health Candy
            CreateBuffButton(HealthCandyButton, 80f, 192f);
            HealthCandyButton.OnLeftClick += HealthCandyClicked;
            BuffPanel.Append(HealthCandyButton);

            //Lollipop
            CreateBuffButton(LollipopButton, 112f, 192f);
            LollipopButton.OnLeftClick += LollipopClicked;
            BuffPanel.Append(LollipopButton);

            //Mana Candy
            CreateBuffButton(ManaCandyButton, 144f, 192f);
            ManaCandyButton.OnLeftClick += ManaCandyClicked;
            BuffPanel.Append(ManaCandyButton);

            //Taffy
            CreateBuffButton(TaffyButton, 176f, 192f);
            TaffyButton.OnLeftClick += TaffyClicked;
            BuffPanel.Append(TaffyButton);
            #endregion

            HashSet<PermanentBuffButton> buttons = new()
            {
                //arena
                CoiledEnergizerButton,
                KoiTotemButton,
                SunPotButton,
                TheCouchButton,
                //potion
                JumpButton,
                MirrorCoatButton,
                MoonJellyButton,
                RunescribeButton,
                SoulguardButton,
                SpiritButton,
                SoaringButton,
                SporecoidButton,
                StarburnButton,
                SteadfastButton,
                ToxinButton,
                ZephyrButton,
                //Candies
                CandyButton,
                ChocolateBarButton,
                HealthCandyButton,
                LollipopButton,
                ManaCandyButton,
                TaffyButton
            };
            allBuffButtons.UnionWith(buttons);

            Append(BuffPanel);
        }

        #region Arena
        private void CoiledEnergizerClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.CoiledEnergizer, CoiledEnergizerButton);
        private void KoiTotemClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.KoiTotem, KoiTotemButton);
        private void SunPotClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.SunPot, SunPotButton);
        private void TheCouchClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.TheCouch, TheCouchButton);
        #endregion

        #region Potions
        private void JumpClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.Jump, JumpButton);
        private void MirrorCoatClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.MirrorCoat, MirrorCoatButton);
        private void MoonJellyClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.MoonJelly, MoonJellyButton);
        private void RunescribeClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.Runescribe, RunescribeButton);
        private void SoulguardClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.Soulguard, SoulguardButton);
        private void SpiritClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.Spirit, SpiritButton);
        private void SoaringClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.Soaring, SoaringButton);
        private void SporecoidClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.Sporecoid, SporecoidButton);
        private void StarburnClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.Starburn, StarburnButton);
        private void SteadfastClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.Steadfast, SteadfastButton);
        private void ToxinClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.Toxin, ToxinButton);
        private void ZephyrClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.Zephyr, ZephyrButton);
        #endregion

        #region Candies
        private void CandyClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.Candy, CandyButton);
        private void ChocolateBarClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.ChocolateBar, ChocolateBarButton);
        private void HealthCandyClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.HealthCandy, HealthCandyButton);
        private void LollipopClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.Lollipop, LollipopButton);
        private void ManaCandyClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.ManaCandy, ManaCandyButton);
        private void TaffyClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.Taffy, TaffyButton);

        #endregion

        public static void GetSpiritClassicBuffData()
        {
            if (!ModConditions.spiritLoaded)
                return;

            //TOOLTIPS
            //ARENA
            CoiledEnergizerButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "OverDrive")).DisplayName;
            KoiTotemButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "KoiTotemBuff")).DisplayName;
            SunPotButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "SunPotBuff")).DisplayName;
            TheCouchButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "CouchPotato")).DisplayName;
            //POTIONS
            JumpButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "PinkPotionBuff")).DisplayName;
            MirrorCoatButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "MirrorCoatBuff")).DisplayName;
            MoonJellyButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "MoonBlessing")).DisplayName;
            RunescribeButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "RunePotionBuff")).DisplayName;
            SoulguardButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "SoulPotionBuff")).DisplayName;
            SpiritButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "SpiritBuff")).DisplayName;
            SoaringButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "FlightPotionBuff")).DisplayName;
            SporecoidButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "MushroomPotionBuff")).DisplayName;
            StarburnButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "StarPotionBuff")).DisplayName;
            SteadfastButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "TurtlePotionBuff")).DisplayName;
            ToxinButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "BismitePotionBuff")).DisplayName;
            ZephyrButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "DoubleJumpPotionBuff")).DisplayName;
            //CANDIES
            CandyButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "CandyBuff")).DisplayName;
            ChocolateBarButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "ChocolateBuff")).DisplayName;
            HealthCandyButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "HealthBuffC")).DisplayName;
            LollipopButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "LollipopBuff")).DisplayName;
            ManaCandyButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "ManaBuffC")).DisplayName;
            TaffyButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "TaffyBuff")).DisplayName;

            //SPRITES
            //ARENA
            CoiledEnergizerButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.spiritMod, Common.GetModBuff(ModConditions.spiritMod, "OverDrive")));
            KoiTotemButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.spiritMod, Common.GetModBuff(ModConditions.spiritMod, "KoiTotemBuff")));
            SunPotButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.spiritMod, Common.GetModBuff(ModConditions.spiritMod, "SunPotBuff")));
            TheCouchButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.spiritMod, Common.GetModBuff(ModConditions.spiritMod, "CouchPotato")));
            //POTIONS
            JumpButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.spiritMod, Common.GetModBuff(ModConditions.spiritMod, "PinkPotionBuff")));
            MirrorCoatButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.spiritMod, Common.GetModBuff(ModConditions.spiritMod, "MirrorCoatBuff")));
            MoonJellyButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.spiritMod, Common.GetModBuff(ModConditions.spiritMod, "MoonBlessing")));
            RunescribeButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.spiritMod, Common.GetModBuff(ModConditions.spiritMod, "RunePotionBuff")));
            SoulguardButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.spiritMod, Common.GetModBuff(ModConditions.spiritMod, "SoulPotionBuff")));
            SpiritButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.spiritMod, Common.GetModBuff(ModConditions.spiritMod, "SpiritBuff")));
            SoaringButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.spiritMod, Common.GetModBuff(ModConditions.spiritMod, "FlightPotionBuff")));
            SporecoidButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.spiritMod, Common.GetModBuff(ModConditions.spiritMod, "MushroomPotionBuff")));
            StarburnButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.spiritMod, Common.GetModBuff(ModConditions.spiritMod, "StarPotionBuff")));
            SteadfastButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.spiritMod, Common.GetModBuff(ModConditions.spiritMod, "TurtlePotionBuff")));
            ToxinButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.spiritMod, Common.GetModBuff(ModConditions.spiritMod, "BismitePotionBuff")));
            ZephyrButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.spiritMod, Common.GetModBuff(ModConditions.spiritMod, "DoubleJumpPotionBuff")));
            //CANDIES
            CandyButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.spiritMod, Common.GetModBuff(ModConditions.spiritMod, "CandyBuff")));
            ChocolateBarButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.spiritMod, Common.GetModBuff(ModConditions.spiritMod, "ChocolateBuff")));
            HealthCandyButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.spiritMod, Common.GetModBuff(ModConditions.spiritMod, "HealthBuffC")));
            LollipopButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.spiritMod, Common.GetModBuff(ModConditions.spiritMod, "LollipopBuff")));
            ManaCandyButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.spiritMod, Common.GetModBuff(ModConditions.spiritMod, "ManaBuffC")));
            TaffyButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.spiritMod, Common.GetModBuff(ModConditions.spiritMod, "TaffyBuff")));
        }

        public override void Update(GameTime gameTime)
        {
            if (!visible)
                return;

            for (int i = 0; i < Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentSpiritClassicBuffsBools.Length; i++)
            {
                allBuffButtons.ElementAt(i).disabled = Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentSpiritClassicBuffsBools[i];
                allBuffButtons.ElementAt(i).moddedBuff = true;
            }
        }

        public static void BuffClick(int buff, PermanentBuffButton button)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentSpiritClassicBuffsBools[buff] = !Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentSpiritClassicBuffsBools[buff];
                button.disabled = Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentSpiritClassicBuffsBools[buff];
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
