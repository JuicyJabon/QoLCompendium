using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.UI.Buttons;

namespace QoLCompendium.Core.UI.Panels
{
    public class PermanentCalamityBuffUI : UIState
    {
        public UIPanel BuffPanel;
        public static bool visible = false;
        public static uint timeStart;

        //ARENA
        public static PermanentBuffButton ChaosCandleButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "ChaosCandleBuff"))));
        public static PermanentBuffButton CorruptionEffigyButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "CorruptionEffigyBuff"))));
        public static PermanentBuffButton CrimsonEffigyButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "CrimsonEffigyBuff"))));
        public static PermanentBuffButton EffigyOfDecayButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "EffigyOfDecayBuff"))));
        public static PermanentBuffButton ResilientCandleButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "PurpleCandleBuff"))));
        public static PermanentBuffButton SpitefulCandleButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "YellowCandleBuff"))));
        public static PermanentBuffButton TranquilityCandleButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "TranquilityCandleBuff"))));
        public static PermanentBuffButton VigorousCandleButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "PinkCandleBuff"))));
        public static PermanentBuffButton WeightlessCandleButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "BlueCandleBuff"))));

        //POTIONS
        public static PermanentBuffButton AnechoicCoatingButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "AnechoicCoatingBuff"))));
        public static PermanentBuffButton AstralInjectionButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "AstralInjectionBuff"))));
        public static PermanentBuffButton BaguetteButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "BaguetteBuff"))));
        public static PermanentBuffButton BloodfinButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "BloodfinBoost"))));
        public static PermanentBuffButton BoundingButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "BoundingBuff"))));
        public static PermanentBuffButton CalciumButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "CalciumBuff"))));
        public static PermanentBuffButton CeaselessHungerButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "CeaselessHunger"))));
        public static PermanentBuffButton GravityNormalizerButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "GravityNormalizerBuff"))));
        public static PermanentBuffButton OmniscienceButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "Omniscience"))));
        public static PermanentBuffButton PhotosynthesisButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "PhotosynthesisBuff"))));
        public static PermanentBuffButton ShadowButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "ShadowBuff"))));
        public static PermanentBuffButton SoaringButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "Soaring"))));
        public static PermanentBuffButton SulphurskinButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "SulphurskinBuff"))));
        public static PermanentBuffButton TeslaButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "TeslaBuff"))));
        public static PermanentBuffButton ZenButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "Zen"))));
        public static PermanentBuffButton ZergButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "Zerg"))));

        //CATALYST
        public static PermanentBuffButton AstraJellyButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.catalystMod, Common.GetModBuff(ModConditions.catalystMod, "AstralJellyBuff"))));
        public static PermanentBuffButton AstracolaButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.catalystMod, Common.GetModBuff(ModConditions.catalystMod, "AstralJellyBuff"))));

        //CLAMITY
        public static PermanentBuffButton ExoBaguetteButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.clamityAddonMod, Common.GetModBuff(ModConditions.clamityAddonMod, "ExoBaguetteBuff"))));
        public static PermanentBuffButton SupremeLuckButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.clamityAddonMod, Common.GetModBuff(ModConditions.clamityAddonMod, "SupremeLucky"))));
        public static PermanentBuffButton TitanScaleButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.clamityAddonMod, Common.GetModBuff(ModConditions.clamityAddonMod, "TitanScalePotionBuff"))));

        //CALAMITY ENTROPY
        public static PermanentBuffButton VoidCandleButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityEntropyMod, Common.GetModBuff(ModConditions.calamityEntropyMod, "VoidCandleBuff"))));
        public static PermanentBuffButton SoyMilkButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityEntropyMod, Common.GetModBuff(ModConditions.calamityEntropyMod, "SoyMilkBuff"))));
        public static PermanentBuffButton YharimsStimulantsButton = new(ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityEntropyMod, Common.GetModBuff(ModConditions.calamityEntropyMod, "YharimPower"))));

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

            UIText addonsText = new(UISystem.AddonText);
            addonsText.Left.Set(16f, 0f);
            addonsText.Top.Set(168f, 0f);
            addonsText.Width.Set(64f, 0f);
            addonsText.Height.Set(32f, 0f);
            BuffPanel.Append(addonsText);

            #region Arena
            //Chaos Candle
            CreateBuffButton(ChaosCandleButton, 16f, 32f);
            ChaosCandleButton.OnLeftClick += ChaosCandleClicked;
            BuffPanel.Append(ChaosCandleButton);

            //Corruption Effigy
            CreateBuffButton(CorruptionEffigyButton, 48f, 32f);
            CorruptionEffigyButton.OnLeftClick += CorruptionEffigyClicked;
            BuffPanel.Append(CorruptionEffigyButton);

            //Crimson Effigy
            CreateBuffButton(CrimsonEffigyButton, 80f, 32f);
            CrimsonEffigyButton.OnLeftClick += CrimsonEffigyClicked;
            BuffPanel.Append(CrimsonEffigyButton);

            //Effigy of Decay
            CreateBuffButton(EffigyOfDecayButton, 112f, 32f);
            EffigyOfDecayButton.OnLeftClick += EffigyOfDecayClicked;
            BuffPanel.Append(EffigyOfDecayButton);

            //Resilient Candle
            CreateBuffButton(ResilientCandleButton, 144f, 32f);
            ResilientCandleButton.OnLeftClick += ResilientCandleClicked;
            BuffPanel.Append(ResilientCandleButton);

            //Spiteful Candle
            CreateBuffButton(SpitefulCandleButton, 176f, 32f);
            SpitefulCandleButton.OnLeftClick += SpitefulCandleClicked;
            BuffPanel.Append(SpitefulCandleButton);

            //Tranquility Candle
            CreateBuffButton(TranquilityCandleButton, 208f, 32f);
            TranquilityCandleButton.OnLeftClick += TranquilityCandleClicked;
            BuffPanel.Append(TranquilityCandleButton);

            //Vigorous Candle
            CreateBuffButton(VigorousCandleButton, 240f, 32f);
            VigorousCandleButton.OnLeftClick += VigorousCandleClicked;
            BuffPanel.Append(VigorousCandleButton);

            //Weightless Candle
            CreateBuffButton(WeightlessCandleButton, 272f, 32f);
            WeightlessCandleButton.OnLeftClick += WeightlessCandleClicked;
            BuffPanel.Append(WeightlessCandleButton);
            #endregion

            #region Potions
            //Anechoic Coating
            CreateBuffButton(AnechoicCoatingButton, 16f, 96f);
            AnechoicCoatingButton.OnLeftClick += AnechoicCoatingClicked;
            BuffPanel.Append(AnechoicCoatingButton);

            //Astral Injection
            CreateBuffButton(AstralInjectionButton, 48f, 96f);
            AstralInjectionButton.OnLeftClick += AstralInjectionClicked;
            BuffPanel.Append(AstralInjectionButton);

            //Baguette
            CreateBuffButton(BaguetteButton, 80f, 96f);
            BaguetteButton.OnLeftClick += BaguetteClicked;
            BuffPanel.Append(BaguetteButton);

            //Bloodfin
            CreateBuffButton(BloodfinButton, 112f, 96f);
            BloodfinButton.OnLeftClick += BloodfinClicked;
            BuffPanel.Append(BloodfinButton);

            //Bounding
            CreateBuffButton(BoundingButton, 144f, 96f);
            BoundingButton.OnLeftClick += BoundingClicked;
            BuffPanel.Append(BoundingButton);

            //Calcium
            CreateBuffButton(CalciumButton, 176f, 96f);
            CalciumButton.OnLeftClick += CalciumClicked;
            BuffPanel.Append(CalciumButton);

            //Ceaseless Hunger
            CreateBuffButton(CeaselessHungerButton, 208f, 96f);
            CeaselessHungerButton.OnLeftClick += CeaselessHungerClicked;
            BuffPanel.Append(CeaselessHungerButton);

            //Gravity Normalizer
            CreateBuffButton(GravityNormalizerButton, 240f, 96f);
            GravityNormalizerButton.OnLeftClick += GravityNormalizerClicked;
            BuffPanel.Append(GravityNormalizerButton);

            //Omniscience
            CreateBuffButton(OmniscienceButton, 272f, 96f);
            OmniscienceButton.OnLeftClick += OmniscienceClicked;
            BuffPanel.Append(OmniscienceButton);

            //Photosynthesis
            CreateBuffButton(PhotosynthesisButton, 304f, 96f);
            PhotosynthesisButton.OnLeftClick += PhotosynthesisClicked;
            BuffPanel.Append(PhotosynthesisButton);

            //10

            //Shadow
            CreateBuffButton(ShadowButton, 16f, 128f);
            ShadowButton.OnLeftClick += ShadowClicked;
            BuffPanel.Append(ShadowButton);

            //Soaring
            CreateBuffButton(SoaringButton, 48f, 128f);
            SoaringButton.OnLeftClick += SoaringClicked;
            BuffPanel.Append(SoaringButton);

            //Sulphurskin
            CreateBuffButton(SulphurskinButton, 80f, 128f);
            SulphurskinButton.OnLeftClick += SulphurskinClicked;
            BuffPanel.Append(SulphurskinButton);

            //Tesla
            CreateBuffButton(TeslaButton, 112f, 128f);
            TeslaButton.OnLeftClick += TeslaClicked;
            BuffPanel.Append(TeslaButton);

            //Zen
            CreateBuffButton(ZenButton, 144f, 128f);
            ZenButton.OnLeftClick += ZenClicked;
            BuffPanel.Append(ZenButton);

            //Zerg
            CreateBuffButton(ZergButton, 176f, 128f);
            ZergButton.OnLeftClick += ZergClicked;
            BuffPanel.Append(ZergButton);
            #endregion

            #region Addons
            //CATALYST
            //Astra Jelly
            CreateBuffButton(AstraJellyButton, 16f, 192f);
            AstraJellyButton.OnLeftClick += AstraJellyClicked;
            AstraJellyButton.ModTooltip = UISystem.UnloadedText;
            BuffPanel.Append(AstraJellyButton);

            //Astracola
            CreateBuffButton(AstracolaButton, 48f, 192f);
            AstracolaButton.OnLeftClick += AstracolaClicked;
            AstracolaButton.ModTooltip = UISystem.UnloadedText;
            BuffPanel.Append(AstracolaButton);


            //CLAMITY
            //Exo Baguette
            CreateBuffButton(ExoBaguetteButton, 80f, 192f);
            ExoBaguetteButton.OnLeftClick += ExoBaguetteClicked;
            ExoBaguetteButton.ModTooltip = UISystem.UnloadedText;
            BuffPanel.Append(ExoBaguetteButton);

            //Supreme Luck
            CreateBuffButton(SupremeLuckButton, 112f, 192f);
            SupremeLuckButton.OnLeftClick += SupremeLuckClicked;
            SupremeLuckButton.ModTooltip = UISystem.UnloadedText;
            BuffPanel.Append(SupremeLuckButton);

            //Titan Scale
            CreateBuffButton(TitanScaleButton, 144f, 192f);
            TitanScaleButton.OnLeftClick += TitanScaleClicked;
            TitanScaleButton.ModTooltip = UISystem.UnloadedText;
            BuffPanel.Append(TitanScaleButton);

            //CALAMITY ENTROPY
            //Void Candle
            CreateBuffButton(VoidCandleButton, 176f, 192f);
            VoidCandleButton.OnLeftClick += VoidCandleClicked;
            VoidCandleButton.ModTooltip = UISystem.UnloadedText;
            BuffPanel.Append(VoidCandleButton);

            //Soy Milk
            CreateBuffButton(SoyMilkButton, 208f, 192f);
            SoyMilkButton.OnLeftClick += SoyMilkClicked;
            SoyMilkButton.ModTooltip = UISystem.UnloadedText;
            BuffPanel.Append(SoyMilkButton);

            //Yharim's Stimulants
            CreateBuffButton(YharimsStimulantsButton, 240f, 192f);
            YharimsStimulantsButton.OnLeftClick += YharimsStimulantsClicked;
            YharimsStimulantsButton.ModTooltip = UISystem.UnloadedText;
            BuffPanel.Append(YharimsStimulantsButton);
            #endregion

            HashSet<PermanentBuffButton> buttons = new()
            {
                //calamity
                //arena
                ChaosCandleButton,
                CorruptionEffigyButton,
                CrimsonEffigyButton,
                EffigyOfDecayButton,
                ResilientCandleButton,
                SpitefulCandleButton,
                TranquilityCandleButton,
                VigorousCandleButton,
                WeightlessCandleButton,
                //potion
                AnechoicCoatingButton,
                AstralInjectionButton,
                BaguetteButton,
                BloodfinButton,
                BoundingButton,
                CalciumButton,
                CeaselessHungerButton,
                GravityNormalizerButton,
                OmniscienceButton,
                PhotosynthesisButton,
                ShadowButton,
                SoaringButton,
                SulphurskinButton,
                TeslaButton,
                ZenButton,
                ZergButton,

                //catalyst
                AstraJellyButton,
                AstracolaButton,

                //clamity
                ExoBaguetteButton,
                SupremeLuckButton,
                TitanScaleButton,

                //calamity entropy
                VoidCandleButton,
                SoyMilkButton,
                YharimsStimulantsButton
            };
            allBuffButtons.UnionWith(buttons);

            Append(BuffPanel);
        }

        #region Arena
        private void ChaosCandleClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.ChaosCandle, ChaosCandleButton);
        private void CorruptionEffigyClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.CorruptionEffigy, CorruptionEffigyButton);
        private void CrimsonEffigyClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.CrimsonEffigy, CrimsonEffigyButton);
        private void EffigyOfDecayClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.EffigyOfDecay, EffigyOfDecayButton);
        private void ResilientCandleClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.ResilientCandle, ResilientCandleButton);
        private void SpitefulCandleClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.SpitefulCandle, SpitefulCandleButton);
        private void TranquilityCandleClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.TranquilityCandle, TranquilityCandleButton);
        private void VigorousCandleClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.VigorousCandle, VigorousCandleButton);
        private void WeightlessCandleClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.WeightlessCandle, WeightlessCandleButton);
        #endregion

        #region Potions
        private void AnechoicCoatingClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.AnechoicCoating, AnechoicCoatingButton);
        private void AstralInjectionClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.AstralInjection, AstralInjectionButton);
        private void BaguetteClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.Baguette, BaguetteButton);
        private void BloodfinClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.Bloodfin, BloodfinButton);
        private void BoundingClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.Bounding, BoundingButton);
        private void CalciumClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.Calcium, CalciumButton);
        private void CeaselessHungerClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.CeaselessHunger, CeaselessHungerButton);
        private void GravityNormalizerClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.GravityNormalizer, GravityNormalizerButton);
        private void OmniscienceClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.Omniscience, OmniscienceButton);
        private void PhotosynthesisClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.Photosynthesis, PhotosynthesisButton);
        private void ShadowClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.Shadow, ShadowButton);
        private void SoaringClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.Soaring, SoaringButton);
        private void SulphurskinClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.Sulphurskin, SulphurskinButton);
        private void TeslaClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.Tesla, TeslaButton);
        private void ZenClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.Zen, ZenButton);
        private void ZergClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.Zerg, ZergButton);
        #endregion

        #region Addons
        //CATALYST
        private void AstraJellyClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.AstraJelly, AstraJellyButton);
        private void AstracolaClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.Astracola, AstracolaButton);

        //CLAMITY
        private void ExoBaguetteClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.ExoBaguette, ExoBaguetteButton);
        private void SupremeLuckClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.SupremeLuck, SupremeLuckButton);
        private void TitanScaleClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.TitanScale, TitanScaleButton);
        
        //CALAMITY ENTROPY
        private void VoidCandleClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.VoidCandle, VoidCandleButton);
        private void SoyMilkClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.SoyMilk, SoyMilkButton);
        private void YharimsStimulantsClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentCalamityBuffs.YharimsStimulants, YharimsStimulantsButton);
        #endregion

        public static void GetCalamityBuffData()
        {
            if (!ModConditions.calamityLoaded)
                return;

            //TOOLTIPS
            //ARENA
            ChaosCandleButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "ChaosCandleBuff")).DisplayName;
            CorruptionEffigyButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "CorruptionEffigyBuff")).DisplayName;
            CrimsonEffigyButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "CrimsonEffigyBuff")).DisplayName;
            EffigyOfDecayButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "EffigyOfDecayBuff")).DisplayName;
            ResilientCandleButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "PurpleCandleBuff")).DisplayName;
            SpitefulCandleButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "YellowCandleBuff")).DisplayName;
            TranquilityCandleButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "TranquilityCandleBuff")).DisplayName;
            VigorousCandleButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "PinkCandleBuff")).DisplayName;
            WeightlessCandleButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "BlueCandleBuff")).DisplayName;
            //POTIONS
            AnechoicCoatingButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "AnechoicCoatingBuff")).DisplayName;
            AstralInjectionButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "AstralInjectionBuff")).DisplayName;
            BaguetteButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "BaguetteBuff")).DisplayName;
            BloodfinButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "BloodfinBoost")).DisplayName;
            BoundingButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "BoundingBuff")).DisplayName;
            CalciumButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "CalciumBuff")).DisplayName;
            CeaselessHungerButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "CeaselessHunger")).DisplayName;
            GravityNormalizerButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "GravityNormalizerBuff")).DisplayName;
            OmniscienceButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "Omniscience")).DisplayName;
            PhotosynthesisButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "PhotosynthesisBuff")).DisplayName;
            ShadowButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "ShadowBuff")).DisplayName;
            SoaringButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "Soaring")).DisplayName;
            SulphurskinButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "SulphurskinBuff")).DisplayName;
            TeslaButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "TeslaBuff")).DisplayName;
            ZenButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "Zen")).DisplayName;
            ZergButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "Zerg")).DisplayName;
            //ADDONS
            //CATALYST
            if (ModConditions.catalystLoaded)
            {
                AstraJellyButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.catalystMod, "AstralJellyBuff")).DisplayName;
                AstracolaButton.ModTooltip = ItemLoader.GetItem(Common.GetModItem(ModConditions.catalystMod, "Lean")).DisplayName;
            }
            //CLAMITY
            if (ModConditions.clamityAddonLoaded)
            {
                ExoBaguetteButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.clamityAddonMod, "ExoBaguetteBuff")).DisplayName;
                SupremeLuckButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.clamityAddonMod, "SupremeLucky")).DisplayName;
                TitanScaleButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.clamityAddonMod, "TitanScalePotionBuff")).DisplayName;
            }
            //CALAMITY ENTROPY
            if (ModConditions.calamityEntropyLoaded)
            {
                VoidCandleButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityEntropyMod, "VoidCandleBuff")).DisplayName;
                SoyMilkButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityEntropyMod, "SoyMilkBuff")).DisplayName;
                YharimsStimulantsButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityEntropyMod, "YharimPower")).DisplayName;
            }

            //SPRITES
            //ARENA
            ChaosCandleButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "ChaosCandleBuff")));
            CorruptionEffigyButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "CorruptionEffigyBuff")));
            CrimsonEffigyButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "CrimsonEffigyBuff")));
            EffigyOfDecayButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "EffigyOfDecayBuff")));
            ResilientCandleButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "PurpleCandleBuff")));
            SpitefulCandleButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "YellowCandleBuff")));
            TranquilityCandleButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "TranquilityCandleBuff")));
            VigorousCandleButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "PinkCandleBuff")));
            WeightlessCandleButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "BlueCandleBuff")));
            //POTIONS
            AnechoicCoatingButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "AnechoicCoatingBuff")));
            AstralInjectionButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "AstralInjectionBuff")));
            BaguetteButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "BaguetteBuff")));
            BloodfinButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "BloodfinBoost")));
            BoundingButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "BoundingBuff")));
            CalciumButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "CalciumBuff")));
            CeaselessHungerButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "CeaselessHunger")));
            GravityNormalizerButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "GravityNormalizerBuff")));
            OmniscienceButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "Omniscience")));
            PhotosynthesisButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "PhotosynthesisBuff")));
            ShadowButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "ShadowBuff")));
            SoaringButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "Soaring")));
            SulphurskinButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "SulphurskinBuff")));
            TeslaButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "TeslaBuff")));
            ZenButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "Zen")));
            ZergButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "Zerg")));
            //ADDONS
            //CATALYST
            if (ModConditions.catalystLoaded)
            {
                AstraJellyButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.catalystMod, "AstralJellyBuff")));
                AstracolaButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.catalystMod, "AstralJellyBuff")));
            }
            //CLAMITY
            if (ModConditions.clamityAddonLoaded)
            {
                ExoBaguetteButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.clamityAddonMod, "ExoBaguetteBuff")));
                SupremeLuckButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.clamityAddonMod, "SupremeLucky")));
                TitanScaleButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.clamityAddonMod, "TitanScalePotionBuff")));
            }
            //CALAMITY ENTROPY
            if (ModConditions.calamityEntropyLoaded)
            {
                VoidCandleButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityEntropyMod, Common.GetModBuff(ModConditions.calamityEntropyMod, "VoidCandleBuff")));
                SoyMilkButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityEntropyMod, Common.GetModBuff(ModConditions.calamityEntropyMod, "SoyMilkBuff")));
                YharimsStimulantsButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.calamityEntropyMod, Common.GetModBuff(ModConditions.calamityEntropyMod, "YharimPower")));
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (!visible)
                return;

            for (int i = 0; i < Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentCalamityBuffsBools.Length; i++)
            {
                allBuffButtons.ElementAt(i).disabled = Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentCalamityBuffsBools[i];
                allBuffButtons.ElementAt(i).moddedBuff = true;
            }
        }

        public static void BuffClick(int buff, PermanentBuffButton button)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentCalamityBuffsBools[buff] = !Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentCalamityBuffsBools[buff];
                button.disabled = Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentCalamityBuffsBools[buff];
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
