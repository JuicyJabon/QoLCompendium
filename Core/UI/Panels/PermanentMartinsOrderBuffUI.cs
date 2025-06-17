using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.UI.Buttons;

namespace QoLCompendium.Core.UI.Panels
{
    public class PermanentMartinsOrderBuffUI : UIState
    {
        public UIPanel BuffPanel;
        public static bool visible = false;
        public static uint timeStart;

        //POTIONS
        public static PermanentBuffButton BlackHoleButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton ChargingButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton DefenderButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton EmpowermentButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton EvocationButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton GourmetFlavorButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton HasteButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton HealingButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton RockskinButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton ShooterButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton SoulButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton SpellCasterButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton StarreachButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton SweeperButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton ThrowerButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton WhipperButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton ZincPillButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));

        //STATIONS
        public static PermanentBuffButton ArcheologyButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton SporeFarmButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));

        HashSet<PermanentBuffButton> allBuffButtons = new();

        public override void OnInitialize()
        {
            BuffPanel = new UIPanel();
            BuffPanel.SetPadding(0);
            BuffPanel.Left.Set(575f, 0f);
            BuffPanel.Top.Set(275f, 0f);
            BuffPanel.Width.Set(352f, 0f);
            BuffPanel.Height.Set(176f, 0f);
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
            stationsText.Top.Set(104f, 0f);
            stationsText.Width.Set(64f, 0f);
            stationsText.Height.Set(32f, 0f);
            BuffPanel.Append(stationsText);

            #region Potions
            //Black Hole
            CreateBuffButton(BlackHoleButton, 16f, 32f);
            BlackHoleButton.OnLeftClick += BlackHoleClicked;
            BuffPanel.Append(BlackHoleButton);

            //Charging
            CreateBuffButton(ChargingButton, 48f, 32f);
            ChargingButton.OnLeftClick += ChargingClicked;
            BuffPanel.Append(ChargingButton);

            //Defender
            CreateBuffButton(DefenderButton, 80f, 32f);
            DefenderButton.OnLeftClick += DefenderClicked;
            BuffPanel.Append(DefenderButton);

            //Empowerment
            CreateBuffButton(EmpowermentButton, 112f, 32f);
            EmpowermentButton.OnLeftClick += EmpowermentClicked;
            BuffPanel.Append(EmpowermentButton);

            //Evocation
            CreateBuffButton(EvocationButton, 144f, 32f);
            EvocationButton.OnLeftClick += EvocationClicked;
            BuffPanel.Append(EvocationButton);

            //Gourmet Flavor
            CreateBuffButton(GourmetFlavorButton, 176f, 32f);
            GourmetFlavorButton.OnLeftClick += GourmetFlavorClicked;
            BuffPanel.Append(GourmetFlavorButton);

            //Haste
            CreateBuffButton(HasteButton, 208f, 32f);
            HasteButton.OnLeftClick += HasteClicked;
            BuffPanel.Append(HasteButton);

            //Healing
            CreateBuffButton(HealingButton, 240f, 32f);
            HealingButton.OnLeftClick += HealingClicked;
            BuffPanel.Append(HealingButton);

            //Rockskin
            CreateBuffButton(RockskinButton, 272f, 32f);
            RockskinButton.OnLeftClick += RockskinClicked;
            BuffPanel.Append(RockskinButton);

            //Shooter
            CreateBuffButton(ShooterButton, 304f, 32f);
            ShooterButton.OnLeftClick += ShooterClicked;
            BuffPanel.Append(ShooterButton);

            //10

            //Soul
            CreateBuffButton(SoulButton, 16f, 64f);
            SoulButton.OnLeftClick += SoulClicked;
            BuffPanel.Append(SoulButton);

            //Spell Caster
            CreateBuffButton(SpellCasterButton, 48f, 64f);
            SpellCasterButton.OnLeftClick += SpellCasterClicked;
            BuffPanel.Append(SpellCasterButton);

            //Starreach
            CreateBuffButton(StarreachButton, 80f, 64f);
            StarreachButton.OnLeftClick += StarreachClicked;
            BuffPanel.Append(StarreachButton);

            //Sweeper
            CreateBuffButton(SweeperButton, 112f, 64f);
            SweeperButton.OnLeftClick += SweeperClicked;
            BuffPanel.Append(SweeperButton);

            //Thrower
            CreateBuffButton(ThrowerButton, 144f, 64f);
            ThrowerButton.OnLeftClick += ThrowerClicked;
            BuffPanel.Append(ThrowerButton);

            //Whipper
            CreateBuffButton(WhipperButton, 176f, 64f);
            WhipperButton.OnLeftClick += WhipperClicked;
            BuffPanel.Append(WhipperButton);

            //Warmonger
            CreateBuffButton(ZincPillButton, 208f, 64f);
            ZincPillButton.OnLeftClick += ZincPillClicked;
            BuffPanel.Append(ZincPillButton);
            #endregion

            #region Stations
            //Archeology
            CreateBuffButton(ArcheologyButton, 16f, 128f);
            ArcheologyButton.OnLeftClick += ArcheologyClicked;
            BuffPanel.Append(ArcheologyButton);

            //Spore Farm
            CreateBuffButton(SporeFarmButton, 48f, 128f);
            SporeFarmButton.OnLeftClick += SporeFarmClicked;
            BuffPanel.Append(SporeFarmButton);
            #endregion

            HashSet<PermanentBuffButton> buttons = new()
            {
                //potion
                BlackHoleButton,
                ChargingButton,
                DefenderButton,
                EmpowermentButton,
                EvocationButton,
                GourmetFlavorButton,
                HasteButton,
                HealingButton,
                RockskinButton,
                ShooterButton,
                SoulButton,
                SpellCasterButton,
                StarreachButton,
                SweeperButton,
                ThrowerButton,
                WhipperButton,
                ZincPillButton,
                //station
                ArcheologyButton,
                SporeFarmButton
            };
            allBuffButtons.UnionWith(buttons);

            Append(BuffPanel);
        }

        #region Potions
        private void BlackHoleClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentMartinsOrderBuffs.BlackHole, BlackHoleButton);
        private void ChargingClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentMartinsOrderBuffs.Charging, ChargingButton);
        private void DefenderClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentMartinsOrderBuffs.Defender, DefenderButton);
        private void EmpowermentClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentMartinsOrderBuffs.Empowerment, EmpowermentButton);
        private void EvocationClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentMartinsOrderBuffs.Evocation, EvocationButton);
        private void GourmetFlavorClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentMartinsOrderBuffs.GourmetFlavor, GourmetFlavorButton);
        private void HasteClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentMartinsOrderBuffs.Haste, HasteButton);
        private void HealingClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentMartinsOrderBuffs.Healing, HealingButton);
        private void RockskinClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentMartinsOrderBuffs.Rockskin, RockskinButton);
        private void ShooterClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentMartinsOrderBuffs.Shooter, ShooterButton);
        private void SoulClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentMartinsOrderBuffs.Soul, SoulButton);
        private void SpellCasterClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentMartinsOrderBuffs.SpellCaster, SpellCasterButton);
        private void StarreachClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentMartinsOrderBuffs.Starreach, StarreachButton);
        private void SweeperClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentMartinsOrderBuffs.Sweeper, SweeperButton);
        private void ThrowerClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentMartinsOrderBuffs.Thrower, ThrowerButton);
        private void WhipperClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentMartinsOrderBuffs.Whipper, WhipperButton);
        private void ZincPillClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentMartinsOrderBuffs.ZincPill, ZincPillButton);
        #endregion

        #region Stations
        private void ArcheologyClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentMartinsOrderBuffs.Archeology, ArcheologyButton);
        private void SporeFarmClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentMartinsOrderBuffs.SporeFarm, SporeFarmButton);
        #endregion

        public static void GetMartinsOrderBuffData()
        {
            if (!ModConditions.martainsOrderLoaded)
                return;

            //TOOLTIPS
            //POTIONS
            BlackHoleButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.martainsOrderMod, "BlackHoleBuff")).DisplayName;
            ChargingButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.martainsOrderMod, "Charging")).DisplayName;
            DefenderButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.martainsOrderMod, "TurretBuff")).DisplayName;
            EmpowermentButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.martainsOrderMod, "EmpowermentBuff")).DisplayName;
            EvocationButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.martainsOrderMod, "SummonSpeedBuff")).DisplayName;
            GourmetFlavorButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.martainsOrderMod, "Gourmet")).DisplayName;
            HasteButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.martainsOrderMod, "HasteBuff")).DisplayName;
            HealingButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.martainsOrderMod, "Healing")).DisplayName;
            RockskinButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.martainsOrderMod, "RockskinBuff")).DisplayName;
            ShooterButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.martainsOrderMod, "ShooterBuff")).DisplayName;
            SoulButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.martainsOrderMod, "SoulBuff")).DisplayName;
            SpellCasterButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.martainsOrderMod, "CasterBuff")).DisplayName;
            StarreachButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.martainsOrderMod, "Starreach")).DisplayName;
            SweeperButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.martainsOrderMod, "SweepBuff")).DisplayName;
            ThrowerButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.martainsOrderMod, "ThrowerBuff")).DisplayName;
            WhipperButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.martainsOrderMod, "WhipperBuff")).DisplayName;
            ZincPillButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.martainsOrderMod, "ZincPillBuff")).DisplayName;
            //STATIONS
            ArcheologyButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.martainsOrderMod, "ReschBuff")).DisplayName;
            SporeFarmButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.martainsOrderMod, "SporeSave")).DisplayName;

            //SPRITES
            //POTIONS
            BlackHoleButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.martainsOrderMod, Common.GetModBuff(ModConditions.martainsOrderMod, "BlackHoleBuff")));
            ChargingButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.martainsOrderMod, Common.GetModBuff(ModConditions.martainsOrderMod, "Charging")));
            DefenderButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.martainsOrderMod, Common.GetModBuff(ModConditions.martainsOrderMod, "TurretBuff")));
            EmpowermentButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.martainsOrderMod, Common.GetModBuff(ModConditions.martainsOrderMod, "EmpowermentBuff")));
            EvocationButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.martainsOrderMod, Common.GetModBuff(ModConditions.martainsOrderMod, "SummonSpeedBuff")));
            GourmetFlavorButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.martainsOrderMod, Common.GetModBuff(ModConditions.martainsOrderMod, "Gourmet")));
            HasteButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.martainsOrderMod, Common.GetModBuff(ModConditions.martainsOrderMod, "HasteBuff")));
            HealingButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.martainsOrderMod, Common.GetModBuff(ModConditions.martainsOrderMod, "Healing")));
            RockskinButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.martainsOrderMod, Common.GetModBuff(ModConditions.martainsOrderMod, "RockskinBuff")));
            ShooterButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.martainsOrderMod, Common.GetModBuff(ModConditions.martainsOrderMod, "ShooterBuff")));
            SoulButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.martainsOrderMod, Common.GetModBuff(ModConditions.martainsOrderMod, "SoulBuff")));
            SpellCasterButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.martainsOrderMod, Common.GetModBuff(ModConditions.martainsOrderMod, "CasterBuff")));
            StarreachButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.martainsOrderMod, Common.GetModBuff(ModConditions.martainsOrderMod, "Starreach")));
            SweeperButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.martainsOrderMod, Common.GetModBuff(ModConditions.martainsOrderMod, "SweepBuff")));
            ThrowerButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.martainsOrderMod, Common.GetModBuff(ModConditions.martainsOrderMod, "ThrowerBuff")));
            WhipperButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.martainsOrderMod, Common.GetModBuff(ModConditions.martainsOrderMod, "WhipperBuff")));
            ZincPillButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.martainsOrderMod, Common.GetModBuff(ModConditions.martainsOrderMod, "ZincPillBuff")));
            //STATIONS
            ArcheologyButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.martainsOrderMod, Common.GetModBuff(ModConditions.martainsOrderMod, "ReschBuff")));
            SporeFarmButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.martainsOrderMod, Common.GetModBuff(ModConditions.martainsOrderMod, "SporeSave")));
        }

        public override void Update(GameTime gameTime)
        {
            if (!visible)
                return;

            for (int i = 0; i < PermanentBuffPlayer.PermanentMartinsOrderBuffsBools.Length; i++)
            {
                allBuffButtons.ElementAt(i).disabled = PermanentBuffPlayer.PermanentMartinsOrderBuffsBools[i];
                allBuffButtons.ElementAt(i).moddedBuff = true;
            }
        }

        public static void BuffClick(int buff, PermanentBuffButton button)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                PermanentBuffPlayer.PermanentMartinsOrderBuffsBools[buff] = !PermanentBuffPlayer.PermanentMartinsOrderBuffsBools[buff];
                button.disabled = PermanentBuffPlayer.PermanentMartinsOrderBuffsBools[buff];
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
