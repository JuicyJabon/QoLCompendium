using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.UI.Buttons;

namespace QoLCompendium.Core.UI.Panels
{
    public class PermanentThoriumBuffUI : UIState
    {
        public UIPanel BuffPanel;
        public static bool visible = false;
        public static uint timeStart;

        //ARENA
        public static PermanentBuffButton MistletoeButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));

        //POTIONS
        public static PermanentBuffButton AquaAffinityButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton ArcaneButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton ArtilleryButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton AssassinButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton BloodRushButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton BouncingFlameButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton CactusFruitButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton ConflagrationButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton CreativityButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton EarwormButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton FrenzyButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton GlowingButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton HolyButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton HydrationButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton InspirationalReachButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton KineticButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton WarmongerButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));

        //REPELLENTS
        public static PermanentBuffButton BatRepellentButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton FishRepellentButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton InsectRepellentButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton SkeletonRepellentButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton ZombieRepellentButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));

        //STATIONS
        public static PermanentBuffButton AltarButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton ConductorsStandButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton NinjaRackButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));

        //ADDONS
        public static PermanentBuffButton DeathsingerButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));
        public static PermanentBuffButton InspirationRegenerationButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentBuff"));

        public static HashSet<PermanentBuffButton> allBuffButtons = new();

        public override void OnInitialize()
        {
            BuffPanel = new UIPanel();
            BuffPanel.SetPadding(0);
            BuffPanel.Left.Set(575f, 0f);
            BuffPanel.Top.Set(275f, 0f);
            BuffPanel.Width.Set(352f, 0f);
            BuffPanel.Height.Set(368f, 0f);
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

            UIText repellentText = new(UISystem.RepellentText);
            repellentText.Left.Set(16f, 0f);
            repellentText.Top.Set(168f, 0f);
            repellentText.Width.Set(64f, 0f);
            repellentText.Height.Set(32f, 0f);
            BuffPanel.Append(repellentText);

            UIText stationsText = new(UISystem.StationText);
            stationsText.Left.Set(16f, 0f);
            stationsText.Top.Set(232f, 0f);
            stationsText.Width.Set(64f, 0f);
            stationsText.Height.Set(32f, 0f);
            BuffPanel.Append(stationsText);

            UIText addonsText = new(UISystem.AddonText);
            addonsText.Left.Set(16f, 0f);
            addonsText.Top.Set(296f, 0f);
            addonsText.Width.Set(64f, 0f);
            addonsText.Height.Set(32f, 0f);
            BuffPanel.Append(addonsText);

            #region Arena
            //Mistletoe
            CreateBuffButton(MistletoeButton, 16f, 32f);
            MistletoeButton.OnLeftClick += MistletoeClicked;
            BuffPanel.Append(MistletoeButton);
            #endregion

            #region Potions
            //Aqua Affinity
            CreateBuffButton(AquaAffinityButton, 16f, 96f);
            AquaAffinityButton.OnLeftClick += AquaAffinityClicked;
            BuffPanel.Append(AquaAffinityButton);

            //Arcane
            CreateBuffButton(ArcaneButton, 48f, 96f);
            ArcaneButton.OnLeftClick += ArcaneClicked;
            BuffPanel.Append(ArcaneButton);

            //Artillery
            CreateBuffButton(ArtilleryButton, 80f, 96f);
            ArtilleryButton.OnLeftClick += ArtilleryClicked;
            BuffPanel.Append(ArtilleryButton);

            //Assassin
            CreateBuffButton(AssassinButton, 112f, 96f);
            AssassinButton.OnLeftClick += AssassinClicked;
            BuffPanel.Append(AssassinButton);

            //Blood Rush
            CreateBuffButton(BloodRushButton, 144f, 96f);
            BloodRushButton.OnLeftClick += BloodRushClicked;
            BuffPanel.Append(BloodRushButton);

            //Bouncing Flame
            CreateBuffButton(BouncingFlameButton, 176f, 96f);
            BouncingFlameButton.OnLeftClick += BouncingFlameClicked;
            BuffPanel.Append(BouncingFlameButton);

            //Cactus Fruit
            CreateBuffButton(CactusFruitButton, 208f, 96f);
            CactusFruitButton.OnLeftClick += CactusFruitClicked;
            BuffPanel.Append(CactusFruitButton);

            //Conflagration
            CreateBuffButton(ConflagrationButton, 240f, 96f);
            ConflagrationButton.OnLeftClick += ConflagrationClicked;
            BuffPanel.Append(ConflagrationButton);

            //Creativity
            CreateBuffButton(CreativityButton, 272f, 96f);
            CreativityButton.OnLeftClick += CreativityClicked;
            BuffPanel.Append(CreativityButton);

            //Earworm
            CreateBuffButton(EarwormButton, 304f, 96f);
            EarwormButton.OnLeftClick += EarwormClicked;
            BuffPanel.Append(EarwormButton);

            //10

            //Frenzy
            CreateBuffButton(FrenzyButton, 16f, 128f);
            FrenzyButton.OnLeftClick += FrenzyClicked;
            BuffPanel.Append(FrenzyButton);

            //Glowing
            CreateBuffButton(GlowingButton, 48f, 128f);
            GlowingButton.OnLeftClick += GlowingClicked;
            BuffPanel.Append(GlowingButton);

            //Holy
            CreateBuffButton(HolyButton, 80f, 128f);
            HolyButton.OnLeftClick += HolyClicked;
            BuffPanel.Append(HolyButton);

            //Hydration
            CreateBuffButton(HydrationButton, 112f, 128f);
            HydrationButton.OnLeftClick += HydrationClicked;
            BuffPanel.Append(HydrationButton);

            //Inspirational Reach
            CreateBuffButton(InspirationalReachButton, 144f, 128f);
            InspirationalReachButton.OnLeftClick += InspirationalReachClicked;
            BuffPanel.Append(InspirationalReachButton);

            //Kinetic
            CreateBuffButton(KineticButton, 176f, 128f);
            KineticButton.OnLeftClick += KineticClicked;
            BuffPanel.Append(KineticButton);

            //Warmonger
            CreateBuffButton(WarmongerButton, 208f, 128f);
            WarmongerButton.OnLeftClick += WarmongerClicked;
            BuffPanel.Append(WarmongerButton);
            #endregion

            #region Repellents
            //Bat Repellent
            CreateBuffButton(BatRepellentButton, 16f, 192f);
            BatRepellentButton.OnLeftClick += BatRepellentClicked;
            BuffPanel.Append(BatRepellentButton);

            //Fish Repellent
            CreateBuffButton(FishRepellentButton, 48f, 192f);
            FishRepellentButton.OnLeftClick += FishRepellentClicked;
            BuffPanel.Append(FishRepellentButton);

            //Insect Repellent
            CreateBuffButton(InsectRepellentButton, 80f, 192f);
            InsectRepellentButton.OnLeftClick += InsectRepellentClicked;
            BuffPanel.Append(InsectRepellentButton);

            //Skeleton Repellent
            CreateBuffButton(SkeletonRepellentButton, 112f, 192f);
            SkeletonRepellentButton.OnLeftClick += SkeletonRepellentClicked;
            BuffPanel.Append(SkeletonRepellentButton);

            //Zombie Repellent
            CreateBuffButton(ZombieRepellentButton, 144f, 192f);
            ZombieRepellentButton.OnLeftClick += ZombieRepellentClicked;
            BuffPanel.Append(ZombieRepellentButton);
            #endregion

            #region Stations
            //Altar
            CreateBuffButton(AltarButton, 16f, 256f);
            AltarButton.OnLeftClick += AltarClicked;
            BuffPanel.Append(AltarButton);

            //Conductors Stand
            CreateBuffButton(ConductorsStandButton, 48f, 256f);
            ConductorsStandButton.OnLeftClick += ConductorsStandClicked;
            BuffPanel.Append(ConductorsStandButton);

            //Ninja Rack
            CreateBuffButton(NinjaRackButton, 80f, 256f);
            NinjaRackButton.OnLeftClick += NinjaRackClicked;
            BuffPanel.Append(NinjaRackButton);
            #endregion

            #region Addons
            //Deathsinger
            CreateBuffButton(DeathsingerButton, 16f, 320f);
            DeathsingerButton.OnLeftClick += DeathsingerClicked;
            DeathsingerButton.ModTooltip = UISystem.UnloadedText;
            BuffPanel.Append(DeathsingerButton);

            //Inspiration Regeneration
            CreateBuffButton(InspirationRegenerationButton, 48f, 320f);
            InspirationRegenerationButton.OnLeftClick += InspirationRegenerationClicked;
            InspirationRegenerationButton.ModTooltip = UISystem.UnloadedText;
            BuffPanel.Append(InspirationRegenerationButton);
            #endregion

            HashSet<PermanentBuffButton> buttons = new()
            {
                //arena
                MistletoeButton,
                //potion
                AquaAffinityButton,
                ArcaneButton,
                ArtilleryButton,
                AssassinButton,
                BloodRushButton,
                BouncingFlameButton,
                CactusFruitButton,
                ConflagrationButton,
                CreativityButton,
                EarwormButton,
                FrenzyButton,
                GlowingButton,
                HolyButton,
                HydrationButton,
                InspirationalReachButton,
                KineticButton,
                WarmongerButton,
                //repellent
                BatRepellentButton,
                FishRepellentButton,
                InsectRepellentButton,
                SkeletonRepellentButton,
                ZombieRepellentButton,
                //station
                AltarButton,
                ConductorsStandButton,
                NinjaRackButton,
                //addon
                DeathsingerButton,
                InspirationRegenerationButton
            };
            allBuffButtons.UnionWith(buttons);

            Append(BuffPanel);
        }

        #region Arena
        private void MistletoeClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.Mistletoe, MistletoeButton);
        #endregion

        #region Potions
        private void AquaAffinityClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.AquaAffinity, AquaAffinityButton);
        private void ArcaneClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.Arcane, ArcaneButton);
        private void ArtilleryClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.Artillery, ArtilleryButton);
        private void AssassinClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.Assassin, AssassinButton);
        private void BloodRushClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.BloodRush, BloodRushButton);
        private void BouncingFlameClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.BouncingFlame, BouncingFlameButton);
        private void CactusFruitClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.CactusFruit, CactusFruitButton);
        private void ConflagrationClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.Conflagration, ConflagrationButton);
        private void CreativityClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.Creativity, CreativityButton);
        private void EarwormClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.Earworm, EarwormButton);
        private void FrenzyClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.Frenzy, FrenzyButton);
        private void GlowingClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.Glowing, GlowingButton);
        private void HolyClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.Holy, HolyButton);
        private void HydrationClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.Hydration, HydrationButton);
        private void InspirationalReachClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.InspirationalReach, InspirationalReachButton);
        private void KineticClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.Kinetic, KineticButton);
        private void WarmongerClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.Warmonger, WarmongerButton);
        #endregion

        #region Repellents
        private void BatRepellentClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.BatRepellent, BatRepellentButton);
        private void FishRepellentClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.FishRepellent, FishRepellentButton);
        private void InsectRepellentClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.InsectRepellent, InsectRepellentButton);
        private void SkeletonRepellentClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.SkeletonRepellent, SkeletonRepellentButton);
        private void ZombieRepellentClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.ZombieRepellent, ZombieRepellentButton);

        #endregion

        #region Stations
        private void AltarClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.Altar, AltarButton);
        private void ConductorsStandClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.ConductorsStand, ConductorsStandButton);
        private void NinjaRackClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.NinjaRack, NinjaRackButton);
        #endregion

        #region Addons
        private void DeathsingerClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.Deathsinger, DeathsingerButton);
        private void InspirationRegenerationClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentThoriumBuffs.InspirationRegeneration, InspirationRegenerationButton);
        #endregion

        public static void GetThoriumBuffData()
        {
            if (!ModConditions.thoriumLoaded)
                return;

            //TOOLTIPS
            //ARENA
            MistletoeButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "MistletoeBuff")).DisplayName;
            //POTIONS
            AquaAffinityButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "AquaAffinity")).DisplayName;
            ArcaneButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "ArcanePotionBuff")).DisplayName;
            ArtilleryButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "ArtilleryBuff")).DisplayName;
            AssassinButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "AssassinPotionBuff")).DisplayName;
            BloodRushButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "BloodRush")).DisplayName;
            BouncingFlameButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "BouncingFlamePotionBuff")).DisplayName;
            CactusFruitButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "CactusFruitBuff")).DisplayName;
            ConflagrationButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "ConflagrationPotionBuff")).DisplayName;
            CreativityButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "CreativityPotionBuff")).DisplayName;
            EarwormButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "EarwormPotionBuff")).DisplayName;
            FrenzyButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "FrenzyPotionBuff")).DisplayName;
            GlowingButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "GlowingPotionBuff")).DisplayName;
            HolyButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "HolyPotionBuff")).DisplayName;
            HydrationButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "HydrationBuff")).DisplayName;
            InspirationalReachButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "InspirationReachPotionBuff")).DisplayName;
            KineticButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "KineticPotionBuff")).DisplayName;
            WarmongerButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "WarmongerBuff")).DisplayName;
            //REPELLENTS
            BatRepellentButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "BatRepellentBuff")).DisplayName;
            FishRepellentButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "FishRepellentBuff")).DisplayName;
            InsectRepellentButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "InsectRepellentBuff")).DisplayName;
            SkeletonRepellentButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "SkeletonRepellentBuff")).DisplayName;
            ZombieRepellentButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "ZombieRepellentBuff")).DisplayName;
            //STATIONS
            AltarButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "AltarBuff")).DisplayName;
            ConductorsStandButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "ConductorsStandBuff")).DisplayName;
            NinjaRackButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "NinjaBuff")).DisplayName;
            //ADDONS
            //THORIUM BOSS REWORK
            if (ModConditions.thoriumBossReworkLoaded)
            {
                DeathsingerButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumBossReworkMod, "Deathsinger")).DisplayName;
                InspirationRegenerationButton.ModTooltip = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumBossReworkMod, "Inspired")).DisplayName;
            }

            //SPRITES
            //ARENA
            MistletoeButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumMod, Common.GetModBuff(ModConditions.thoriumMod, "MistletoeBuff")));
            //POTIONS
            AquaAffinityButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumMod, Common.GetModBuff(ModConditions.thoriumMod, "AquaAffinity")));
            ArcaneButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumMod, Common.GetModBuff(ModConditions.thoriumMod, "ArcanePotionBuff")));
            ArtilleryButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumMod, Common.GetModBuff(ModConditions.thoriumMod, "ArtilleryBuff")));
            AssassinButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumMod, Common.GetModBuff(ModConditions.thoriumMod, "AssassinPotionBuff")));
            BloodRushButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumMod, Common.GetModBuff(ModConditions.thoriumMod, "BloodRush")));
            BouncingFlameButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumMod, Common.GetModBuff(ModConditions.thoriumMod, "BouncingFlamePotionBuff")));
            CactusFruitButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumMod, Common.GetModBuff(ModConditions.thoriumMod, "CactusFruitBuff")));
            ConflagrationButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumMod, Common.GetModBuff(ModConditions.thoriumMod, "ConflagrationPotionBuff")));
            CreativityButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumMod, Common.GetModBuff(ModConditions.thoriumMod, "CreativityPotionBuff")));
            EarwormButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumMod, Common.GetModBuff(ModConditions.thoriumMod, "EarwormPotionBuff")));
            FrenzyButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumMod, Common.GetModBuff(ModConditions.thoriumMod, "FrenzyPotionBuff")));
            GlowingButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumMod, Common.GetModBuff(ModConditions.thoriumMod, "GlowingPotionBuff")));
            HolyButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumMod, Common.GetModBuff(ModConditions.thoriumMod, "HolyPotionBuff")));
            HydrationButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumMod, Common.GetModBuff(ModConditions.thoriumMod, "HydrationBuff")));
            InspirationalReachButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumMod, Common.GetModBuff(ModConditions.thoriumMod, "InspirationReachPotionBuff")));
            KineticButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumMod, Common.GetModBuff(ModConditions.thoriumMod, "KineticPotionBuff")));
            WarmongerButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumMod, Common.GetModBuff(ModConditions.thoriumMod, "WarmongerBuff")));
            //REPELLENTS
            BatRepellentButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumMod, Common.GetModBuff(ModConditions.thoriumMod, "BatRepellentBuff")));
            FishRepellentButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumMod, Common.GetModBuff(ModConditions.thoriumMod, "FishRepellentBuff")));
            InsectRepellentButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumMod, Common.GetModBuff(ModConditions.thoriumMod, "InsectRepellentBuff")));
            SkeletonRepellentButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumMod, Common.GetModBuff(ModConditions.thoriumMod, "SkeletonRepellentBuff")));
            ZombieRepellentButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumMod, Common.GetModBuff(ModConditions.thoriumMod, "ZombieRepellentBuff")));
            //STATIONS
            AltarButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumMod, Common.GetModBuff(ModConditions.thoriumMod, "AltarBuff")));
            ConductorsStandButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumMod, Common.GetModBuff(ModConditions.thoriumMod, "ConductorsStandBuff")));
            NinjaRackButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumMod, Common.GetModBuff(ModConditions.thoriumMod, "NinjaBuff")));
            //ADDONS
            //THORIUM BOSS REWORK
            if (ModConditions.thoriumBossReworkLoaded)
            {
                DeathsingerButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumBossReworkMod, Common.GetModBuff(ModConditions.thoriumBossReworkMod, "Deathsinger")));
                InspirationRegenerationButton.drawTexture = ModContent.Request<Texture2D>(Common.ModBuffAsset(ModConditions.thoriumBossReworkMod, Common.GetModBuff(ModConditions.thoriumBossReworkMod, "Inspired")));
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (!visible)
                return;

            for (int i = 0; i < Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentThoriumBuffsBools.Length; i++)
            {
                allBuffButtons.ElementAt(i).disabled = Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentThoriumBuffsBools[i];
                allBuffButtons.ElementAt(i).moddedBuff = true;
            }
        }

        public static void BuffClick(int buff, PermanentBuffButton button)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentThoriumBuffsBools[buff] = !Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentThoriumBuffsBools[buff];
                button.disabled = Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentThoriumBuffsBools[buff];
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
