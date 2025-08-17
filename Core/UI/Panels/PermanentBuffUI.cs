using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.UI.Buttons;
using Terraria;

namespace QoLCompendium.Core.UI.Panels
{
    public class PermanentBuffUI : UIState
    {
        public UIPanel BuffPanel;
        public static bool visible = false;
        public static uint timeStart;

        //ARENA
        PermanentBuffButton BastStatueButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.CatBast));
        PermanentBuffButton CampfireButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Campfire));
        PermanentBuffButton GardenGnomeButton = new(ModContent.Request<Texture2D>("QoLCompendium/Assets/Items/PermanentGardenGnome"));
        PermanentBuffButton HeartLanternButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.HeartLamp));
        PermanentBuffButton HoneyButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Honey));
        PermanentBuffButton PeaceCandleButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.PeaceCandle));
        PermanentBuffButton ShadowCandleButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.ShadowCandle));
        PermanentBuffButton StarInABottleButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.StarInBottle));
        PermanentBuffButton SunflowerButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Sunflower));
        PermanentBuffButton WaterCandleButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.WaterCandle));

        //POTIONS
        PermanentBuffButton AmmoReservationButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.AmmoReservation));
        PermanentBuffButton ArcheryButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Archery));
        PermanentBuffButton BattleButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Battle));
        PermanentBuffButton BiomeSightButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.BiomeSight));
        PermanentBuffButton BuilderButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Builder));
        PermanentBuffButton CalmButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Calm));
        PermanentBuffButton CrateButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Crate));
        PermanentBuffButton DangersenseButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Dangersense));
        PermanentBuffButton EnduranceButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Endurance));
        PermanentBuffButton ExquisitelyStuffedButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.WellFed3));
        PermanentBuffButton FeatherfallButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Featherfall));
        PermanentBuffButton FishingButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Fishing));
        PermanentBuffButton FlipperButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Flipper));
        PermanentBuffButton GillsButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Gills));
        PermanentBuffButton GravitationButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Gravitation));
        PermanentBuffButton HeartreachButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Heartreach));
        PermanentBuffButton HunterButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Hunter));
        PermanentBuffButton InfernoButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Inferno));
        PermanentBuffButton InvisibilityButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Invisibility));
        PermanentBuffButton IronskinButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Ironskin));
        PermanentBuffButton LifeforceButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Lifeforce));
        PermanentBuffButton LuckyButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Lucky));
        PermanentBuffButton MagicPowerButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.MagicPower));
        PermanentBuffButton ManaRegenerationButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.ManaRegeneration));
        PermanentBuffButton MiningButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Mining));
        PermanentBuffButton NightOwlButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.NightOwl));
        PermanentBuffButton ObsidianSkinButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.ObsidianSkin));
        PermanentBuffButton PlentySatisfiedButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.WellFed2));
        PermanentBuffButton RageButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Rage));
        PermanentBuffButton RegenerationButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Regeneration));
        PermanentBuffButton ShineButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Shine));
        PermanentBuffButton SonarButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Sonar));
        PermanentBuffButton SpelunkerButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Spelunker));
        PermanentBuffButton SummoningButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Summoning));
        PermanentBuffButton SwiftnessButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Swiftness));
        PermanentBuffButton ThornsButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Thorns));
        PermanentBuffButton TipsyButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Tipsy));
        PermanentBuffButton TitanButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Titan));
        PermanentBuffButton WarmthButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Warmth));
        PermanentBuffButton WaterWalkingButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.WaterWalking));
        PermanentBuffButton WellFedButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.WellFed));
        PermanentBuffButton WrathButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Wrath));

        //STATIONS
        PermanentBuffButton AmmoBoxButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.AmmoBox));
        PermanentBuffButton BewitchingTableButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Bewitched));
        PermanentBuffButton CrystalBallButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Clairvoyance));
        PermanentBuffButton SharpeningStationButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.Sharpened));
        PermanentBuffButton SliceOfCakeButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.SugarRush));
        PermanentBuffButton WarTableButton = new(ModContent.Request<Texture2D>("Terraria/Images/Buff_" + BuffID.WarTable));

        public static HashSet<PermanentBuffButton> allBuffButtons = new();

        public override void OnInitialize()
        {
            BuffPanel = new UIPanel();
            BuffPanel.SetPadding(0);
            BuffPanel.Left.Set(575f, 0f);
            BuffPanel.Top.Set(275f, 0f);
            BuffPanel.Width.Set(352f, 0f);
            BuffPanel.Height.Set(336f, 0f);
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

            UIText stationText = new(UISystem.StationText);
            stationText.Left.Set(16f, 0f);
            stationText.Top.Set(264f, 0f);
            stationText.Width.Set(64f, 0f);
            stationText.Height.Set(32f, 0f);
            BuffPanel.Append(stationText);

            #region Arena
            //Bast Statue
            CreateBuffButton(BastStatueButton, 16f, 32f);
            BastStatueButton.OnLeftClick += BastStatueClicked;
            BastStatueButton.Tooltip = Lang.GetBuffName(BuffID.CatBast);
            BuffPanel.Append(BastStatueButton);

            //Campfire
            CreateBuffButton(CampfireButton, 48f, 32f);
            CampfireButton.OnLeftClick += CampfireClicked;
            CampfireButton.Tooltip = Lang.GetBuffName(BuffID.Campfire);
            BuffPanel.Append(CampfireButton);

            //Garden Gnome
            CreateBuffButton(GardenGnomeButton, 80f, 32f);
            GardenGnomeButton.OnLeftClick += GardenGnomeClicked;
            GardenGnomeButton.Tooltip = Lang.GetItemName(ItemID.GardenGnome).ToString();
            BuffPanel.Append(GardenGnomeButton);

            //Heart Lantern
            CreateBuffButton(HeartLanternButton, 112f, 32f);
            HeartLanternButton.OnLeftClick += HeartLanternClicked;
            HeartLanternButton.Tooltip = Lang.GetBuffName(BuffID.HeartLamp);
            BuffPanel.Append(HeartLanternButton);

            //Honey
            CreateBuffButton(HoneyButton, 144f, 32f);
            HoneyButton.OnLeftClick += HoneyClicked;
            HoneyButton.Tooltip = Lang.GetBuffName(BuffID.Honey);
            BuffPanel.Append(HoneyButton);

            //Peace Candle
            CreateBuffButton(PeaceCandleButton, 176f, 32f);
            PeaceCandleButton.OnLeftClick += PeaceCandleClicked;
            PeaceCandleButton.Tooltip = Lang.GetBuffName(BuffID.PeaceCandle);
            BuffPanel.Append(PeaceCandleButton);

            //Shadow Candle
            CreateBuffButton(ShadowCandleButton, 208f, 32f);
            ShadowCandleButton.OnLeftClick += ShadowCandleClicked;
            ShadowCandleButton.Tooltip = Lang.GetBuffName(BuffID.ShadowCandle);
            BuffPanel.Append(ShadowCandleButton);

            //Star in a Bottle
            CreateBuffButton(StarInABottleButton, 240f, 32f);
            StarInABottleButton.OnLeftClick += StarInABottleClicked;
            StarInABottleButton.Tooltip = Lang.GetBuffName(BuffID.StarInBottle);
            BuffPanel.Append(StarInABottleButton);

            //Sunflower
            CreateBuffButton(SunflowerButton, 272f, 32f);
            SunflowerButton.OnLeftClick += SunflowerClicked;
            SunflowerButton.Tooltip = Lang.GetBuffName(BuffID.Sunflower);
            BuffPanel.Append(SunflowerButton);

            //Water Candle
            CreateBuffButton(WaterCandleButton, 304f, 32f);
            WaterCandleButton.OnLeftClick += WaterCandleClicked;
            WaterCandleButton.Tooltip = Lang.GetBuffName(BuffID.WaterCandle);
            BuffPanel.Append(WaterCandleButton);
            #endregion

            #region Potions
            //Ammo Reservation
            CreateBuffButton(AmmoReservationButton, 16f, 96f);
            AmmoReservationButton.OnLeftClick += AmmoReservationClicked;
            AmmoReservationButton.Tooltip = Lang.GetBuffName(BuffID.AmmoReservation);
            BuffPanel.Append(AmmoReservationButton);

            //Archery
            CreateBuffButton(ArcheryButton, 48f, 96f);
            ArcheryButton.OnLeftClick += ArcheryClicked;
            ArcheryButton.Tooltip = Lang.GetBuffName(BuffID.Archery);
            BuffPanel.Append(ArcheryButton);

            //Battle
            CreateBuffButton(BattleButton, 80f, 96f);
            BattleButton.OnLeftClick += BattleClicked;
            BattleButton.Tooltip = Lang.GetBuffName(BuffID.Battle);
            BuffPanel.Append(BattleButton);

            //Biome Sight
            CreateBuffButton(BiomeSightButton, 112f, 96f);
            BiomeSightButton.OnLeftClick += BiomeSightClicked;
            BiomeSightButton.Tooltip = Lang.GetBuffName(BuffID.BiomeSight);
            BuffPanel.Append(BiomeSightButton);

            //Builder
            CreateBuffButton(BuilderButton, 144f, 96f);
            BuilderButton.OnLeftClick += BuilderClicked;
            BuilderButton.Tooltip = Lang.GetBuffName(BuffID.Builder);
            BuffPanel.Append(BuilderButton);

            //Calm
            CreateBuffButton(CalmButton, 176f, 96f);
            CalmButton.OnLeftClick += CalmClicked;
            CalmButton.Tooltip = Lang.GetBuffName(BuffID.Calm);
            BuffPanel.Append(CalmButton);

            //Crate
            CreateBuffButton(CrateButton, 208f, 96f);
            CrateButton.OnLeftClick += CrateClicked;
            CrateButton.Tooltip = Lang.GetBuffName(BuffID.Crate);
            BuffPanel.Append(CrateButton);

            //Dangersense
            CreateBuffButton(DangersenseButton, 240f, 96f);
            DangersenseButton.OnLeftClick += DangersenseClicked;
            DangersenseButton.Tooltip = Lang.GetBuffName(BuffID.Dangersense);
            BuffPanel.Append(DangersenseButton);

            //Endurance
            CreateBuffButton(EnduranceButton, 272f, 96f);
            EnduranceButton.OnLeftClick += EnduranceClicked;
            EnduranceButton.Tooltip = Lang.GetBuffName(BuffID.Endurance);
            BuffPanel.Append(EnduranceButton);

            //Exquisitely Stuffed
            CreateBuffButton(ExquisitelyStuffedButton, 304f, 96f);
            ExquisitelyStuffedButton.OnLeftClick += ExquisitelyStuffedClicked;
            ExquisitelyStuffedButton.Tooltip = Lang.GetBuffName(BuffID.WellFed3);
            BuffPanel.Append(ExquisitelyStuffedButton);

            //10

            //Featherfall
            CreateBuffButton(FeatherfallButton, 16f, 128f);
            FeatherfallButton.OnLeftClick += FeatherfallClicked;
            FeatherfallButton.Tooltip = Lang.GetBuffName(BuffID.Featherfall);
            BuffPanel.Append(FeatherfallButton);

            //Fishing
            CreateBuffButton(FishingButton, 48f, 128f);
            FishingButton.OnLeftClick += FishingClicked;
            FishingButton.Tooltip = Lang.GetBuffName(BuffID.Fishing);
            BuffPanel.Append(FishingButton);

            //Flipper
            CreateBuffButton(FlipperButton, 80f, 128f);
            FlipperButton.OnLeftClick += FlipperClicked;
            FlipperButton.Tooltip = Lang.GetBuffName(BuffID.Flipper);
            BuffPanel.Append(FlipperButton);

            //Gills
            CreateBuffButton(GillsButton, 112f, 128f);
            GillsButton.OnLeftClick += GillsClicked;
            GillsButton.Tooltip = Lang.GetBuffName(BuffID.Gills);
            BuffPanel.Append(GillsButton);

            //Gravitation
            CreateBuffButton(GravitationButton, 144f, 128f);
            GravitationButton.OnLeftClick += GravitationClicked;
            GravitationButton.Tooltip = Lang.GetBuffName(BuffID.Gravitation);
            BuffPanel.Append(GravitationButton);

            //Heartreach
            CreateBuffButton(HeartreachButton, 176f, 128f);
            HeartreachButton.OnLeftClick += HeartreachClicked;
            HeartreachButton.Tooltip = Lang.GetBuffName(BuffID.Heartreach);
            BuffPanel.Append(HeartreachButton);

            //Hunter
            CreateBuffButton(HunterButton, 208f, 128f);
            HunterButton.OnLeftClick += HunterClicked;
            HunterButton.Tooltip = Lang.GetBuffName(BuffID.Hunter);
            BuffPanel.Append(HunterButton);

            //Inferno
            CreateBuffButton(InfernoButton, 240f, 128f);
            InfernoButton.OnLeftClick += InfernoClicked;
            InfernoButton.Tooltip = Lang.GetBuffName(BuffID.Inferno);
            BuffPanel.Append(InfernoButton);

            //Invisibility
            CreateBuffButton(InvisibilityButton, 272f, 128f);
            InvisibilityButton.OnLeftClick += InvisibilityClicked;
            InvisibilityButton.Tooltip = Lang.GetBuffName(BuffID.Invisibility);
            BuffPanel.Append(InvisibilityButton);

            //Ironskin
            CreateBuffButton(IronskinButton, 304f, 128f);
            IronskinButton.OnLeftClick += IronskinClicked;
            IronskinButton.Tooltip = Lang.GetBuffName(BuffID.Ironskin);
            BuffPanel.Append(IronskinButton);

            //20

            //Lifeforce
            CreateBuffButton(LifeforceButton, 16f, 160f);
            LifeforceButton.OnLeftClick += LifeforceClicked;
            LifeforceButton.Tooltip = Lang.GetBuffName(BuffID.Lifeforce);
            BuffPanel.Append(LifeforceButton);

            //Lucky
            CreateBuffButton(LuckyButton, 48f, 160f);
            LuckyButton.OnLeftClick += LuckyClicked;
            LuckyButton.Tooltip = Lang.GetBuffName(BuffID.Lucky);
            BuffPanel.Append(LuckyButton);

            //Magic Power
            CreateBuffButton(MagicPowerButton, 80f, 160f);
            MagicPowerButton.OnLeftClick += MagicPowerClicked;
            MagicPowerButton.Tooltip = Lang.GetBuffName(BuffID.MagicPower);
            BuffPanel.Append(MagicPowerButton);

            //Mana Regeneration
            CreateBuffButton(ManaRegenerationButton, 112f, 160f);
            ManaRegenerationButton.OnLeftClick += ManaRegenerationClicked;
            ManaRegenerationButton.Tooltip = Lang.GetBuffName(BuffID.ManaRegeneration);
            BuffPanel.Append(ManaRegenerationButton);

            //Mining
            CreateBuffButton(MiningButton, 144f, 160f);
            MiningButton.OnLeftClick += MiningClicked;
            MiningButton.Tooltip = Lang.GetBuffName(BuffID.Mining);
            BuffPanel.Append(MiningButton);

            //Night Owl
            CreateBuffButton(NightOwlButton, 176f, 160f);
            NightOwlButton.OnLeftClick += NightOwlClicked;
            NightOwlButton.Tooltip = Lang.GetBuffName(BuffID.NightOwl);
            BuffPanel.Append(NightOwlButton);

            //Obsidian Skin
            CreateBuffButton(ObsidianSkinButton, 208f, 160f);
            ObsidianSkinButton.OnLeftClick += ObsidianSkinClicked;
            ObsidianSkinButton.Tooltip = Lang.GetBuffName(BuffID.ObsidianSkin);
            BuffPanel.Append(ObsidianSkinButton);

            //Plenty Satisfied
            CreateBuffButton(PlentySatisfiedButton, 240f, 160f);
            PlentySatisfiedButton.OnLeftClick += PlentySatisfiedClicked;
            PlentySatisfiedButton.Tooltip = Lang.GetBuffName(BuffID.WellFed2);
            BuffPanel.Append(PlentySatisfiedButton);

            //Rage
            CreateBuffButton(RageButton, 272f, 160f);
            RageButton.OnLeftClick += RageClicked;
            RageButton.Tooltip = Lang.GetBuffName(BuffID.Rage);
            BuffPanel.Append(RageButton);

            //Regeneration
            CreateBuffButton(RegenerationButton, 304f, 160f);
            RegenerationButton.OnLeftClick += RegenerationClicked;
            RegenerationButton.Tooltip = Lang.GetBuffName(BuffID.Regeneration);
            BuffPanel.Append(RegenerationButton);

            //30

            //Shine
            CreateBuffButton(ShineButton, 16f, 192f);
            ShineButton.OnLeftClick += ShineClicked;
            ShineButton.Tooltip = Lang.GetBuffName(BuffID.Shine);
            BuffPanel.Append(ShineButton);

            //Sonar
            CreateBuffButton(SonarButton, 48f, 192f);
            SonarButton.OnLeftClick += SonarClicked;
            SonarButton.Tooltip = Lang.GetBuffName(BuffID.Sonar);
            BuffPanel.Append(SonarButton);

            //Spelunker
            CreateBuffButton(SpelunkerButton, 80f, 192f);
            SpelunkerButton.OnLeftClick += SpelunkerClicked;
            SpelunkerButton.Tooltip = Lang.GetBuffName(BuffID.Spelunker);
            BuffPanel.Append(SpelunkerButton);

            //Summoning
            CreateBuffButton(SummoningButton, 112f, 192f);
            SummoningButton.OnLeftClick += SummoningClicked;
            SummoningButton.Tooltip = Lang.GetBuffName(BuffID.Summoning);
            BuffPanel.Append(SummoningButton);

            //Swiftness
            CreateBuffButton(SwiftnessButton, 144f, 192f);
            SwiftnessButton.OnLeftClick += SwiftnessClicked;
            SwiftnessButton.Tooltip = Lang.GetBuffName(BuffID.Swiftness);
            BuffPanel.Append(SwiftnessButton);

            //Thorns
            CreateBuffButton(ThornsButton, 176f, 192f);
            ThornsButton.OnLeftClick += ThornsClicked;
            ThornsButton.Tooltip = Lang.GetBuffName(BuffID.Thorns);
            BuffPanel.Append(ThornsButton);

            //Tipsy
            CreateBuffButton(TipsyButton, 208f, 192f);
            TipsyButton.OnLeftClick += TipsyClicked;
            TipsyButton.Tooltip = Lang.GetBuffName(BuffID.Tipsy);
            BuffPanel.Append(TipsyButton);

            //Titan
            CreateBuffButton(TitanButton, 240f, 192f);
            TitanButton.OnLeftClick += TitanClicked;
            TitanButton.Tooltip = Lang.GetBuffName(BuffID.Titan);
            BuffPanel.Append(TitanButton);

            //Warmth
            CreateBuffButton(WarmthButton, 272f, 192f);
            WarmthButton.OnLeftClick += WarmthClicked;
            WarmthButton.Tooltip = Lang.GetBuffName(BuffID.Warmth);
            BuffPanel.Append(WarmthButton);

            //Water Walking
            CreateBuffButton(WaterWalkingButton, 304f, 192f);
            WaterWalkingButton.OnLeftClick += WaterWalkingClicked;
            WaterWalkingButton.Tooltip = Lang.GetBuffName(BuffID.WaterWalking);
            BuffPanel.Append(WaterWalkingButton);

            //40

            //Well Fed
            CreateBuffButton(WellFedButton, 16f, 224f);
            WellFedButton.OnLeftClick += WellFedClicked;
            WellFedButton.Tooltip = Lang.GetBuffName(BuffID.WellFed);
            BuffPanel.Append(WellFedButton);

            //Wrath
            CreateBuffButton(WrathButton, 48f, 224f);
            WrathButton.OnLeftClick += WrathClicked;
            WrathButton.Tooltip = Lang.GetBuffName(BuffID.Wrath);
            BuffPanel.Append(WrathButton);
            #endregion

            #region Stations
            //Ammo Box
            CreateBuffButton(AmmoBoxButton, 16f, 288f);
            AmmoBoxButton.OnLeftClick += AmmoBoxClicked;
            AmmoBoxButton.Tooltip = Lang.GetBuffName(BuffID.AmmoBox);
            BuffPanel.Append(AmmoBoxButton);

            //Bewitching Table
            CreateBuffButton(BewitchingTableButton, 48f, 288f);
            BewitchingTableButton.OnLeftClick += BewitchingTableClicked;
            BewitchingTableButton.Tooltip = Lang.GetBuffName(BuffID.Bewitched);
            BuffPanel.Append(BewitchingTableButton);

            //Crystal Ball
            CreateBuffButton(CrystalBallButton, 80f, 288f);
            CrystalBallButton.OnLeftClick += CrystalBallClicked;
            CrystalBallButton.Tooltip = Lang.GetBuffName(BuffID.Clairvoyance);
            BuffPanel.Append(CrystalBallButton);

            //Sharpening Station
            CreateBuffButton(SharpeningStationButton, 112f, 288f);
            SharpeningStationButton.OnLeftClick += SharpeningStationClicked;
            SharpeningStationButton.Tooltip = Lang.GetBuffName(BuffID.Sharpened);
            BuffPanel.Append(SharpeningStationButton);

            //Slice of Cake
            CreateBuffButton(SliceOfCakeButton, 144f, 288f);
            SliceOfCakeButton.OnLeftClick += SliceOfCakeClicked;
            SliceOfCakeButton.Tooltip = Lang.GetBuffName(BuffID.SugarRush);
            BuffPanel.Append(SliceOfCakeButton);

            //War Table
            CreateBuffButton(WarTableButton, 176f, 288f);
            WarTableButton.OnLeftClick += WarTableClicked;
            WarTableButton.Tooltip = Lang.GetBuffName(BuffID.WarTable);
            BuffPanel.Append(WarTableButton);
            #endregion

            HashSet<PermanentBuffButton> buttons = new()
            {
                //arena
                BastStatueButton,
                CampfireButton,
                GardenGnomeButton,
                HeartLanternButton,
                HoneyButton,
                PeaceCandleButton,
                ShadowCandleButton,
                StarInABottleButton,
                SunflowerButton,
                WaterCandleButton,
                //potion
                AmmoReservationButton,
                ArcheryButton,
                BattleButton,
                BiomeSightButton,
                BuilderButton,
                CalmButton,
                CrateButton,
                DangersenseButton,
                EnduranceButton,
                ExquisitelyStuffedButton,
                FeatherfallButton,
                FishingButton,
                FlipperButton,
                GillsButton,
                GravitationButton,
                HeartreachButton,
                HunterButton,
                InfernoButton,
                InvisibilityButton,
                IronskinButton,
                LifeforceButton,
                LuckyButton,
                MagicPowerButton,
                ManaRegenerationButton,
                MiningButton,
                NightOwlButton,
                ObsidianSkinButton,
                PlentySatisfiedButton,
                RageButton,
                RegenerationButton,
                ShineButton,
                SonarButton,
                SpelunkerButton,
                SummoningButton,
                SwiftnessButton,
                ThornsButton,
                TipsyButton,
                TitanButton,
                WarmthButton,
                WaterWalkingButton,
                WellFedButton,
                WrathButton,
                //stations
                AmmoBoxButton,
                BewitchingTableButton,
                CrystalBallButton,
                SharpeningStationButton,
                SliceOfCakeButton,
                WarTableButton
            };
            allBuffButtons.UnionWith(buttons);

            Append(BuffPanel);
        }

        #region Arena
        private void BastStatueClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.BastStatue, BastStatueButton, Lang.GetBuffName(BuffID.CatBast));
        private void CampfireClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Campfire, CampfireButton, Lang.GetBuffName(BuffID.Campfire));
        private void GardenGnomeClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.GardenGnome, GardenGnomeButton, Lang.GetItemName(ItemID.GardenGnome).ToString());
        private void HeartLanternClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.HeartLantern, HeartLanternButton, Lang.GetBuffName(BuffID.HeartLamp));
        private void HoneyClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Honey, HoneyButton, Lang.GetBuffName(BuffID.Honey));
        private void PeaceCandleClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.PeaceCandle, PeaceCandleButton, Lang.GetBuffName(BuffID.PeaceCandle));
        private void ShadowCandleClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.ShadowCandle, ShadowCandleButton, Lang.GetBuffName(BuffID.ShadowCandle));
        private void StarInABottleClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.StarInABottle, StarInABottleButton, Lang.GetBuffName(BuffID.StarInBottle));
        private void SunflowerClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Sunflower, SunflowerButton, Lang.GetBuffName(BuffID.Sunflower));
        private void WaterCandleClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.WaterCandle, WaterCandleButton, Lang.GetBuffName(BuffID.WaterCandle));
        #endregion

        #region Potions
        private void AmmoReservationClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.AmmoReservation, AmmoReservationButton, Lang.GetBuffName(BuffID.AmmoReservation));
        private void ArcheryClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Archery, ArcheryButton, Lang.GetBuffName(BuffID.Archery));
        private void BattleClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Battle, BattleButton, Lang.GetBuffName(BuffID.Battle));
        private void BiomeSightClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.BiomeSight, BiomeSightButton, Lang.GetBuffName(BuffID.BiomeSight));
        private void BuilderClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Builder, BuilderButton, Lang.GetBuffName(BuffID.Builder));
        private void CalmClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Calm, CalmButton, Lang.GetBuffName(BuffID.Calm));
        private void CrateClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Crate, CrateButton, Lang.GetBuffName(BuffID.Crate));
        private void DangersenseClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Dangersense, DangersenseButton, Lang.GetBuffName(BuffID.Dangersense));
        private void EnduranceClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Endurance, EnduranceButton, Lang.GetBuffName(BuffID.Endurance));
        private void ExquisitelyStuffedClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.ExquisitelyStuffed, ExquisitelyStuffedButton, Lang.GetBuffName(BuffID.WellFed3));
        private void FeatherfallClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Featherfall, FeatherfallButton, Lang.GetBuffName(BuffID.Featherfall));
        private void FishingClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Fishing, FishingButton, Lang.GetBuffName(BuffID.Fishing));
        private void FlipperClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Flipper, FlipperButton, Lang.GetBuffName(BuffID.Flipper));
        private void GillsClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Gills, GillsButton, Lang.GetBuffName(BuffID.Gills));
        private void GravitationClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Gravitation, GravitationButton, Lang.GetBuffName(BuffID.Gravitation));
        private void HeartreachClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Heartreach, HeartreachButton, Lang.GetBuffName(BuffID.Heartreach));
        private void HunterClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Hunter, HunterButton, Lang.GetBuffName(BuffID.Hunter));
        private void InfernoClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Inferno, InfernoButton, Lang.GetBuffName(BuffID.Inferno));
        private void InvisibilityClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Invisibility, InvisibilityButton, Lang.GetBuffName(BuffID.Invisibility));
        private void IronskinClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Ironskin, IronskinButton, Lang.GetBuffName(BuffID.Ironskin));
        private void LifeforceClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Lifeforce, LifeforceButton, Lang.GetBuffName(BuffID.Lifeforce));
        private void LuckyClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Lucky, LuckyButton, Lang.GetBuffName(BuffID.Lucky));
        private void MagicPowerClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.MagicPower, MagicPowerButton, Lang.GetBuffName(BuffID.MagicPower));
        private void ManaRegenerationClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.ManaRegeneration, ManaRegenerationButton, Lang.GetBuffName(BuffID.ManaRegeneration));
        private void MiningClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Mining, MiningButton, Lang.GetBuffName(BuffID.Mining));
        private void NightOwlClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.NightOwl, NightOwlButton, Lang.GetBuffName(BuffID.NightOwl));
        private void ObsidianSkinClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.ObsidianSkin, ObsidianSkinButton, Lang.GetBuffName(BuffID.ObsidianSkin));
        private void PlentySatisfiedClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.PlentySatisfied, PlentySatisfiedButton, Lang.GetBuffName(BuffID.WellFed2));
        private void RageClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Rage, RageButton, Lang.GetBuffName(BuffID.Rage));
        private void RegenerationClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Regeneration, RegenerationButton, Lang.GetBuffName(BuffID.Regeneration));
        private void ShineClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Shine, ShineButton, Lang.GetBuffName(BuffID.Shine));
        private void SonarClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Sonar, SonarButton, Lang.GetBuffName(BuffID.Sonar));
        private void SpelunkerClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Spelunker, SpelunkerButton, Lang.GetBuffName(BuffID.Spelunker));
        private void SummoningClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Summoning, SummoningButton, Lang.GetBuffName(BuffID.Summoning));
        private void SwiftnessClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Swiftness, SwiftnessButton, Lang.GetBuffName(BuffID.Swiftness));
        private void ThornsClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Thorns, ThornsButton, Lang.GetBuffName(BuffID.Thorns));
        private void TipsyClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Tipsy, TipsyButton, Lang.GetBuffName(BuffID.Tipsy));
        private void TitanClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Titan, TitanButton, Lang.GetBuffName(BuffID.Titan));
        private void WarmthClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Warmth, WarmthButton, Lang.GetBuffName(BuffID.Warmth));
        private void WaterWalkingClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.WaterWalking, WaterWalkingButton, Lang.GetBuffName(BuffID.WaterWalking));
        private void WellFedClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.WellFed, WellFedButton, Lang.GetBuffName(BuffID.WellFed));
        private void WrathClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.Wrath, WrathButton, Lang.GetBuffName(BuffID.Wrath));
        #endregion

        #region Stations
        private void AmmoBoxClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.AmmoBox, AmmoBoxButton, Lang.GetBuffName(BuffID.AmmoBox));
        private void BewitchingTableClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.BewitchingTable, BewitchingTableButton, Lang.GetBuffName(BuffID.Bewitched));
        private void CrystalBallClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.CrystalBall, CrystalBallButton, Lang.GetBuffName(BuffID.Clairvoyance));
        private void SharpeningStationClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.SharpeningStation, SharpeningStationButton, Lang.GetBuffName(BuffID.Sharpened));
        private void SliceOfCakeClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.SliceOfCake, SliceOfCakeButton, Lang.GetBuffName(BuffID.SugarRush));
        private void WarTableClicked(UIMouseEvent evt, UIElement listeningElement) => BuffClick((int)PermanentBuffPlayer.PermanentBuffs.WarTable, WarTableButton, Lang.GetBuffName(BuffID.WarTable));
        #endregion

        public override void Update(GameTime gameTime)
        {
            if (!visible)
                return;

            for (int i = 0; i < Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools.Length; i++)
                allBuffButtons.ElementAt(i).disabled = Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools[i];
        }

        public static void BuffClick(int buff, PermanentBuffButton button, string name)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools[buff] = !Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools[buff];
                button.disabled = Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentBuffsBools[buff];
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
