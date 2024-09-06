using static Terraria.ModLoader.ModContent;

namespace QoLCompendium.Core.UI
{
    class BossUI : UIState
    {
        public UIPanel BossPanel;
        public static bool visible = false;
        public static uint timeStart;

        public override void OnInitialize()
        {
            BossPanel = new UIPanel();
            BossPanel.SetPadding(0);
            BossPanel.Left.Set(575f, 0f);
            BossPanel.Top.Set(275f, 0f);
            BossPanel.Width.Set(390f, 0f);
            BossPanel.Height.Set(510f, 0f);
            BossPanel.BackgroundColor = new Color(204, 43, 43);

            BossPanel.OnLeftMouseDown += new MouseEvent(DragStart);
            BossPanel.OnLeftMouseUp += new MouseEvent(DragEnd);

            UIText BossText = new("Bosses");
            BossText.Left.Set(10f, 0f);
            BossText.Top.Set(10f, 0f);
            BossText.Width.Set(50f, 0f);
            BossText.Height.Set(22f, 0f);
            BossPanel.Append(BossText);

            Asset<Texture2D> KingSlimeTexture = Request<Texture2D>("QoLCompendium/Assets/Bosses/KingSlime");
            Asset<Texture2D> EyeOfCthulhuTexture = Request<Texture2D>("QoLCompendium/Assets/Bosses/EyeOfCthulhu");
            Asset<Texture2D> EaterOfWorldsTexture = Request<Texture2D>("QoLCompendium/Assets/Bosses/EaterOfWorlds");
            Asset<Texture2D> BrainOfCthulhuTexture = Request<Texture2D>("QoLCompendium/Assets/Bosses/BrainOfCthulhu");
            Asset<Texture2D> QueenBeeTexture = Request<Texture2D>("QoLCompendium/Assets/Bosses/QueenBee");
            Asset<Texture2D> SkeletronTexture = Request<Texture2D>("QoLCompendium/Assets/Bosses/Skeletron");
            Asset<Texture2D> DeerclopsTexture = Request<Texture2D>("QoLCompendium/Assets/Bosses/Deerclops");
            Asset<Texture2D> WallOfFleshTexture = Request<Texture2D>("QoLCompendium/Assets/Bosses/WallOfFlesh");
            Asset<Texture2D> QueenSlimeTexture = Request<Texture2D>("QoLCompendium/Assets/Bosses/QueenSlime");
            Asset<Texture2D> TwinsTexture = Request<Texture2D>("QoLCompendium/Assets/Bosses/Twins");
            Asset<Texture2D> DestroyerTexture = Request<Texture2D>("QoLCompendium/Assets/Bosses/Destroyer");
            Asset<Texture2D> SkeletronPrimeTexture = Request<Texture2D>("QoLCompendium/Assets/Bosses/SkeletronPrime");
            Asset<Texture2D> PlanteraTexture = Request<Texture2D>("QoLCompendium/Assets/Bosses/Plantera");
            Asset<Texture2D> GolemTexture = Request<Texture2D>("QoLCompendium/Assets/Bosses/Golem");
            Asset<Texture2D> DukeFishronTexture = Request<Texture2D>("QoLCompendium/Assets/Bosses/DukeFishron");
            Asset<Texture2D> EmpressOfLightTexture = Request<Texture2D>("QoLCompendium/Assets/Bosses/EmpressOfLight");
            Asset<Texture2D> LunaticCultistTexture = Request<Texture2D>("QoLCompendium/Assets/Bosses/LunaticCultist");
            Asset<Texture2D> MoonLordTexture = Request<Texture2D>("QoLCompendium/Assets/Bosses/MoonLord");
            
            Asset<Texture2D> buttonDeleteTexture = Request<Texture2D>("Terraria/Images/UI/ButtonDelete");

            UIImageButton KingSlime = new(KingSlimeTexture);
            KingSlime.Left.Set(10, 0f);
            KingSlime.Top.Set(50, 0f);
            KingSlime.Width.Set(30, 0f);
            KingSlime.Height.Set(30, 0f);
            KingSlime.OnLeftClick += new MouseEvent(KingSlimeClicked);
            BossPanel.Append(KingSlime);

            UIImageButton EyeOfCthulhu = new(EyeOfCthulhuTexture);
            EyeOfCthulhu.Left.Set(60, 0f);
            EyeOfCthulhu.Top.Set(50, 0f);
            EyeOfCthulhu.Width.Set(26, 0f);
            EyeOfCthulhu.Height.Set(28, 0f);
            EyeOfCthulhu.OnLeftClick += new MouseEvent(EyeOfCthulhuClicked);
            BossPanel.Append(EyeOfCthulhu);

            UIImageButton EaterOfWorlds = new(EaterOfWorldsTexture);
            EaterOfWorlds.Left.Set(110, 0f);
            EaterOfWorlds.Top.Set(50, 0f);
            EaterOfWorlds.Width.Set(24, 0f);
            EaterOfWorlds.Height.Set(30, 0f);
            EaterOfWorlds.OnLeftClick += new MouseEvent(EaterOfWorldsClicked);
            BossPanel.Append(EaterOfWorlds);

            UIImageButton BrainOfCthulhu = new(BrainOfCthulhuTexture);
            BrainOfCthulhu.Left.Set(160, 0f);
            BrainOfCthulhu.Top.Set(50, 0f);
            BrainOfCthulhu.Width.Set(30, 0f);
            BrainOfCthulhu.Height.Set(30, 0f);
            BrainOfCthulhu.OnLeftClick += new MouseEvent(BrainOfCthulhuClicked);
            BossPanel.Append(BrainOfCthulhu);
            
            UIImageButton QueenBee = new(QueenBeeTexture);
            QueenBee.Left.Set(210, 0f);
            QueenBee.Top.Set(50, 0f);
            QueenBee.Width.Set(30, 0f);
            QueenBee.Height.Set(30, 0f);
            QueenBee.OnLeftClick += new MouseEvent(QueenBeeClicked);
            BossPanel.Append(QueenBee);
            
            UIImageButton Skeletron = new(SkeletronTexture);
            Skeletron.Left.Set(260, 0f);
            Skeletron.Top.Set(50, 0f);
            Skeletron.Width.Set(26, 0f);
            Skeletron.Height.Set(30, 0f);
            Skeletron.OnLeftClick += new MouseEvent(SkeletronClicked);
            BossPanel.Append(Skeletron);
            
            UIImageButton Deerclops = new(DeerclopsTexture);
            Deerclops.Left.Set(310, 0f);
            Deerclops.Top.Set(50, 0f);
            Deerclops.Width.Set(48, 0f);
            Deerclops.Height.Set(40, 0f);
            Deerclops.OnLeftClick += new MouseEvent(DeerclopsClicked);
            BossPanel.Append(Deerclops);
            
            UIImageButton WallOfFlesh = new(WallOfFleshTexture);
            WallOfFlesh.Left.Set(10, 0f);
            WallOfFlesh.Top.Set(100, 0f);
            WallOfFlesh.Width.Set(30, 0f);
            WallOfFlesh.Height.Set(30, 0f);
            WallOfFlesh.OnLeftClick += new MouseEvent(WallOfFleshClicked);
            BossPanel.Append(WallOfFlesh);
            
            UIImageButton QueenSlime = new(QueenSlimeTexture);
            QueenSlime.Left.Set(60, 0f);
            QueenSlime.Top.Set(100, 0f);
            QueenSlime.Width.Set(28, 0f);
            QueenSlime.Height.Set(30, 0f);
            QueenSlime.OnLeftClick += new MouseEvent(QueenSlimeClicked);
            BossPanel.Append(QueenSlime);
            
            UIImageButton Twins = new(TwinsTexture);
            Twins.Left.Set(110, 0f);
            Twins.Top.Set(100, 0f);
            Twins.Width.Set(30, 0f);
            Twins.Height.Set(28, 0f);
            Twins.OnLeftClick += new MouseEvent(TwinsClicked);
            BossPanel.Append(Twins);
            
            UIImageButton Destroyer = new(DestroyerTexture);
            Destroyer.Left.Set(160, 0f);
            Destroyer.Top.Set(100, 0f);
            Destroyer.Width.Set(24, 0f);
            Destroyer.Height.Set(30, 0f);
            Destroyer.OnLeftClick += new MouseEvent(DestroyerClicked);
            BossPanel.Append(Destroyer);
            
            UIImageButton SkeletronPrime = new(SkeletronPrimeTexture);
            SkeletronPrime.Left.Set(210, 0f);
            SkeletronPrime.Top.Set(100, 0f);
            SkeletronPrime.Width.Set(26, 0f);
            SkeletronPrime.Height.Set(30, 0f);
            SkeletronPrime.OnLeftClick += new MouseEvent(SkeletronPrimeClicked);
            BossPanel.Append(SkeletronPrime);
            
            UIImageButton Plantera = new(PlanteraTexture);
            Plantera.Left.Set(260, 0f);
            Plantera.Top.Set(100, 0f);
            Plantera.Width.Set(30, 0f);
            Plantera.Height.Set(30, 0f);
            Plantera.OnLeftClick += new MouseEvent(PlanteraClicked);
            BossPanel.Append(Plantera);

            UIImageButton Golem = new(GolemTexture);
            Golem.Left.Set(310, 0f);
            Golem.Top.Set(100, 0f);
            Golem.Width.Set(28, 0f);
            Golem.Height.Set(30, 0f);
            Golem.OnLeftClick += new MouseEvent(GolemClicked);
            BossPanel.Append(Golem);

            UIImageButton DukeFishron = new(DukeFishronTexture);
            DukeFishron.Left.Set(10, 0f);
            DukeFishron.Top.Set(150, 0f);
            DukeFishron.Width.Set(30, 0f);
            DukeFishron.Height.Set(30, 0f);
            DukeFishron.OnLeftClick += new MouseEvent(DukeFishronClicked);
            BossPanel.Append(DukeFishron);

            UIImageButton EmpressOfLight = new(EmpressOfLightTexture);
            EmpressOfLight.Left.Set(60, 0f);
            EmpressOfLight.Top.Set(150, 0f);
            EmpressOfLight.Width.Set(30, 0f);
            EmpressOfLight.Height.Set(32, 0f);
            EmpressOfLight.OnLeftClick += new MouseEvent(EmpressOfLightClicked);
            BossPanel.Append(EmpressOfLight);

            UIImageButton LunaticCultist = new(LunaticCultistTexture);
            LunaticCultist.Left.Set(110, 0f);
            LunaticCultist.Top.Set(150, 0f);
            LunaticCultist.Width.Set(30, 0f);
            LunaticCultist.Height.Set(30, 0f);
            LunaticCultist.OnLeftClick += new MouseEvent(LunaticCultistClicked);
            BossPanel.Append(LunaticCultist);

            UIImageButton MoonLord = new(MoonLordTexture);
            MoonLord.Left.Set(160, 0f);
            MoonLord.Top.Set(150, 0f);
            MoonLord.Width.Set(34, 0f);
            MoonLord.Height.Set(36, 0f);
            MoonLord.OnLeftClick += new MouseEvent(MoonLordClicked);
            BossPanel.Append(MoonLord);

            UIText EventText = new("Events");
            EventText.Left.Set(10f, 0f);
            EventText.Top.Set(190f, 0f);
            EventText.Width.Set(50f, 0f);
            EventText.Height.Set(22f, 0f);
            BossPanel.Append(EventText);

            Asset<Texture2D> RainTexture = Request<Texture2D>("QoLCompendium/Assets/Events/Rain");
            Asset<Texture2D> WindTexture = Request<Texture2D>("QoLCompendium/Assets/Events/Wind");
            Asset<Texture2D> SandstormTexture = Request<Texture2D>("QoLCompendium/Assets/Events/Sandstorm");
            Asset<Texture2D> PartyTexture = Request<Texture2D>("QoLCompendium/Assets/Events/Party");
            Asset<Texture2D> SlimeRainTexture = Request<Texture2D>("QoLCompendium/Assets/Events/SlimeRain");
            Asset<Texture2D> BloodMoonTexture = Request<Texture2D>("QoLCompendium/Assets/Events/BloodMoon");
            Asset<Texture2D> GoblinArmyTexture = Request<Texture2D>("QoLCompendium/Assets/Events/GoblinArmy");
            Asset<Texture2D> FrostLegionTexture = Request<Texture2D>("QoLCompendium/Assets/Events/FrostLegion");
            Asset<Texture2D> PiratesTexture = Request<Texture2D>("QoLCompendium/Assets/Events/Pirates");
            Asset<Texture2D> EclipseTexture = Request<Texture2D>("QoLCompendium/Assets/Events/Eclipse");
            Asset<Texture2D> PumpkinMoonTexture = Request<Texture2D>("QoLCompendium/Assets/Events/PumpkinMoon");
            Asset<Texture2D> FrostMoonTexture = Request<Texture2D>("QoLCompendium/Assets/Events/FrostMoon");
            Asset<Texture2D> MartiansTexture = Request<Texture2D>("QoLCompendium/Assets/Events/Martians");
            Asset<Texture2D> NebulaPillarTexture = Request<Texture2D>("QoLCompendium/Assets/Events/NebulaPillar");
            Asset<Texture2D> SolarPillarTexture = Request<Texture2D>("QoLCompendium/Assets/Events/SolarPillar");
            Asset<Texture2D> StardustPillarTexture = Request<Texture2D>("QoLCompendium/Assets/Events/StardustPillar");
            Asset<Texture2D> VortexPillarTexture = Request<Texture2D>("QoLCompendium/Assets/Events/VortexPillar");

            UIImageButton Rain = new(RainTexture);
            Rain.Left.Set(10, 0f);
            Rain.Top.Set(230, 0f);
            Rain.Width.Set(26, 0f);
            Rain.Height.Set(22, 0f);
            Rain.OnLeftClick += new MouseEvent(RainClicked);
            BossPanel.Append(Rain);

            UIImageButton Wind = new(WindTexture);
            Wind.Left.Set(60, 0f);
            Wind.Top.Set(230, 0f);
            Wind.Width.Set(28, 0f);
            Wind.Height.Set(26, 0f);
            Wind.OnLeftClick += new MouseEvent(WindClicked);
            BossPanel.Append(Wind);

            UIImageButton Sandstorm = new(SandstormTexture);
            Sandstorm.Left.Set(110, 0f);
            Sandstorm.Top.Set(230, 0f);
            Sandstorm.Width.Set(24, 0f);
            Sandstorm.Height.Set(24, 0f);
            Sandstorm.OnLeftClick += new MouseEvent(SandstormClicked);
            BossPanel.Append(Sandstorm);

            UIImageButton Party = new(PartyTexture);
            Party.Left.Set(160, 0f);
            Party.Top.Set(230, 0f);
            Party.Width.Set(22, 0f);
            Party.Height.Set(28, 0f);
            Party.OnLeftClick += new MouseEvent(PartyClicked);
            BossPanel.Append(Party);

            UIImageButton SlimeRain = new(SlimeRainTexture);
            SlimeRain.Left.Set(210, 0f);
            SlimeRain.Top.Set(230, 0f);
            SlimeRain.Width.Set(20, 0f);
            SlimeRain.Height.Set(26, 0f);
            SlimeRain.OnLeftClick += new MouseEvent(SlimeRainClicked);
            BossPanel.Append(SlimeRain);

            UIImageButton BloodMoon = new(BloodMoonTexture);
            BloodMoon.Left.Set(260, 0f);
            BloodMoon.Top.Set(230, 0f);
            BloodMoon.Width.Set(22, 0f);
            BloodMoon.Height.Set(22, 0f);
            BloodMoon.OnLeftClick += new MouseEvent(BloodMoonClicked);
            BossPanel.Append(BloodMoon);
            
            UIImageButton GoblinArmy = new(GoblinArmyTexture);
            GoblinArmy.Left.Set(310, 0f);
            GoblinArmy.Top.Set(230, 0f);
            GoblinArmy.Width.Set(26, 0f);
            GoblinArmy.Height.Set(24, 0f);
            GoblinArmy.OnLeftClick += new MouseEvent(GoblinArmyClicked);
            BossPanel.Append(GoblinArmy);

            UIImageButton FrostLegion = new(FrostLegionTexture);
            FrostLegion.Left.Set(10, 0f);
            FrostLegion.Top.Set(280, 0f);
            FrostLegion.Width.Set(20, 0f);
            FrostLegion.Height.Set(24, 0f);
            FrostLegion.OnLeftClick += new MouseEvent(FrostLegionClicked);
            BossPanel.Append(FrostLegion);

            UIImageButton Pirates = new(PiratesTexture);
            Pirates.Left.Set(60, 0f);
            Pirates.Top.Set(280, 0f);
            Pirates.Width.Set(24, 0f);
            Pirates.Height.Set(24, 0f);
            Pirates.OnLeftClick += new MouseEvent(PiratesClicked);
            BossPanel.Append(Pirates);
            
            UIImageButton Eclipse = new(EclipseTexture);
            Eclipse.Left.Set(110, 0f);
            Eclipse.Top.Set(280, 0f);
            Eclipse.Width.Set(24, 0f);
            Eclipse.Height.Set(24, 0f);
            Eclipse.OnLeftClick += new MouseEvent(EclipseClicked);
            BossPanel.Append(Eclipse);

            UIImageButton PumpkinMoon = new(PumpkinMoonTexture);
            PumpkinMoon.Left.Set(160, 0f);
            PumpkinMoon.Top.Set(280, 0f);
            PumpkinMoon.Width.Set(22, 0f);
            PumpkinMoon.Height.Set(22, 0f);
            PumpkinMoon.OnLeftClick += new MouseEvent(PumpkinMoonClicked);
            BossPanel.Append(PumpkinMoon);

            UIImageButton FrostMoon = new(FrostMoonTexture);
            FrostMoon.Left.Set(210, 0f);
            FrostMoon.Top.Set(280, 0f);
            FrostMoon.Width.Set(22, 0f);
            FrostMoon.Height.Set(22, 0f);
            FrostMoon.OnLeftClick += new MouseEvent(FrostMoonClicked);
            BossPanel.Append(FrostMoon);

            UIImageButton Martians = new(MartiansTexture);
            Martians.Left.Set(260, 0f);
            Martians.Top.Set(280, 0f);
            Martians.Width.Set(26, 0f);
            Martians.Height.Set(24, 0f);
            Martians.OnLeftClick += new MouseEvent(MartiansClicked);
            BossPanel.Append(Martians);

            UIImageButton NebulaPillar = new(NebulaPillarTexture);
            NebulaPillar.Left.Set(310, 0f);
            NebulaPillar.Top.Set(280, 0f);
            NebulaPillar.Width.Set(24, 0f);
            NebulaPillar.Height.Set(26, 0f);
            NebulaPillar.OnLeftClick += new MouseEvent(NebulaPillarClicked);
            BossPanel.Append(NebulaPillar);

            UIImageButton SolarPillar = new(SolarPillarTexture);
            SolarPillar.Left.Set(10, 0f);
            SolarPillar.Top.Set(330, 0f);
            SolarPillar.Width.Set(24, 0f);
            SolarPillar.Height.Set(26, 0f);
            SolarPillar.OnLeftClick += new MouseEvent(SolarPillarClicked);
            BossPanel.Append(SolarPillar);

            UIImageButton StardustPillar = new(StardustPillarTexture);
            StardustPillar.Left.Set(60, 0f);
            StardustPillar.Top.Set(330, 0f);
            StardustPillar.Width.Set(24, 0f);
            StardustPillar.Height.Set(26, 0f);
            StardustPillar.OnLeftClick += new MouseEvent(StardustPillarClicked);
            BossPanel.Append(StardustPillar);

            UIImageButton VortexPillar = new(VortexPillarTexture);
            VortexPillar.Left.Set(110, 0f);
            VortexPillar.Top.Set(330, 0f);
            VortexPillar.Width.Set(24, 0f);
            VortexPillar.Height.Set(26, 0f);
            VortexPillar.OnLeftClick += new MouseEvent(VortexPillarClicked);
            BossPanel.Append(VortexPillar);

            UIText MinibossesText = new("Minibosses");
            MinibossesText.Left.Set(10f, 0f);
            MinibossesText.Top.Set(370f, 0f);
            MinibossesText.Width.Set(50f, 0f);
            MinibossesText.Height.Set(22f, 0f);
            BossPanel.Append(MinibossesText);

            Asset<Texture2D> DarkMageTexture = Request<Texture2D>("QoLCompendium/Assets/Minibosses/DarkMage");
            Asset<Texture2D> DreadnautilusTexture = Request<Texture2D>("QoLCompendium/Assets/Minibosses/Dreadnautilus");
            Asset<Texture2D> FlyingDutchmanTexture = Request<Texture2D>("QoLCompendium/Assets/Minibosses/FlyingDutchman");
            Asset<Texture2D> OgreTexture = Request<Texture2D>("QoLCompendium/Assets/Minibosses/Ogre");
            Asset<Texture2D> MourningWoodTexture = Request<Texture2D>("QoLCompendium/Assets/Minibosses/MourningWood");
            Asset<Texture2D> PumpkingTexture = Request<Texture2D>("QoLCompendium/Assets/Minibosses/Pumpking");
            Asset<Texture2D> EverscreamTexture = Request<Texture2D>("QoLCompendium/Assets/Minibosses/Everscream");
            Asset<Texture2D> SantankTexture = Request<Texture2D>("QoLCompendium/Assets/Minibosses/Santank");
            Asset<Texture2D> IceQueenTexture = Request<Texture2D>("QoLCompendium/Assets/Minibosses/IceQueen");
            Asset<Texture2D> MartianSaucerTexture = Request<Texture2D>("QoLCompendium/Assets/Minibosses/MartianSaucer");
            Asset<Texture2D> BetsyTexture = Request<Texture2D>("QoLCompendium/Assets/Minibosses/Betsy");

            UIImageButton DarkMage = new(DarkMageTexture);
            DarkMage.Left.Set(10, 0f);
            DarkMage.Top.Set(410, 0f);
            DarkMage.Width.Set(32, 0f);
            DarkMage.Height.Set(32, 0f);
            DarkMage.OnLeftClick += new MouseEvent(DarkMageClicked);
            BossPanel.Append(DarkMage);

            UIImageButton Dreadnautilus = new(DreadnautilusTexture);
            Dreadnautilus.Left.Set(60, 0f);
            Dreadnautilus.Top.Set(410, 0f);
            Dreadnautilus.Width.Set(40, 0f);
            Dreadnautilus.Height.Set(34, 0f);
            Dreadnautilus.OnLeftClick += new MouseEvent(DreadnautilusClicked);
            BossPanel.Append(Dreadnautilus);

            UIImageButton FlyingDutchman = new(FlyingDutchmanTexture);
            FlyingDutchman.Left.Set(110, 0f);
            FlyingDutchman.Top.Set(410, 0f);
            FlyingDutchman.Width.Set(30, 0f);
            FlyingDutchman.Height.Set(28, 0f);
            FlyingDutchman.OnLeftClick += new MouseEvent(FlyingDutchmanClicked);
            BossPanel.Append(FlyingDutchman);
            
            UIImageButton Ogre = new(OgreTexture);
            Ogre.Left.Set(160, 0f);
            Ogre.Top.Set(410, 0f);
            Ogre.Width.Set(26, 0f);
            Ogre.Height.Set(30, 0f);
            Ogre.OnLeftClick += new MouseEvent(OgreClicked);
            BossPanel.Append(Ogre);
            
            UIImageButton MourningWood = new(MourningWoodTexture);
            MourningWood.Left.Set(210, 0f);
            MourningWood.Top.Set(410, 0f);
            MourningWood.Width.Set(30, 0f);
            MourningWood.Height.Set(30, 0f);
            MourningWood.OnLeftClick += new MouseEvent(MourningWoodClicked);
            BossPanel.Append(MourningWood);
            
            UIImageButton Pumpking = new(PumpkingTexture);
            Pumpking.Left.Set(260, 0f);
            Pumpking.Top.Set(410, 0f);
            Pumpking.Width.Set(30, 0f);
            Pumpking.Height.Set(30, 0f);
            Pumpking.OnLeftClick += new MouseEvent(PumpkingClicked);
            BossPanel.Append(Pumpking);

            UIImageButton Everscream = new(EverscreamTexture);
            Everscream.Left.Set(310, 0f);
            Everscream.Top.Set(410, 0f);
            Everscream.Width.Set(30, 0f);
            Everscream.Height.Set(30, 0f);
            Everscream.OnLeftClick += new MouseEvent(EverscreamClicked);
            BossPanel.Append(Everscream);

            UIImageButton Santank = new(SantankTexture);
            Santank.Left.Set(10, 0f);
            Santank.Top.Set(460, 0f);
            Santank.Width.Set(30, 0f);
            Santank.Height.Set(30, 0f);
            Santank.OnLeftClick += new MouseEvent(SantankClicked);
            BossPanel.Append(Santank);

            UIImageButton IceQueen = new(IceQueenTexture);
            IceQueen.Left.Set(60, 0f);
            IceQueen.Top.Set(460, 0f);
            IceQueen.Width.Set(30, 0f);
            IceQueen.Height.Set(30, 0f);
            IceQueen.OnLeftClick += new MouseEvent(IceQueenClicked);
            BossPanel.Append(IceQueen);
            
            UIImageButton MartianSaucer = new(MartianSaucerTexture);
            MartianSaucer.Left.Set(110, 0f);
            MartianSaucer.Top.Set(460, 0f);
            MartianSaucer.Width.Set(30, 0f);
            MartianSaucer.Height.Set(30, 0f);
            MartianSaucer.OnLeftClick += new MouseEvent(MartianSaucerClicked);
            BossPanel.Append(MartianSaucer);

            UIImageButton Betsy = new(BetsyTexture);
            Betsy.Left.Set(160, 0f);
            Betsy.Top.Set(460, 0f);
            Betsy.Width.Set(30, 0f);
            Betsy.Height.Set(30, 0f);
            Betsy.OnLeftClick += new MouseEvent(BetsyClicked);
            BossPanel.Append(Betsy);

            UIImageButton closeButton = new(buttonDeleteTexture);
            closeButton.Left.Set(360, 0f);
            closeButton.Top.Set(10, 0f);
            closeButton.Width.Set(22, 0f);
            closeButton.Height.Set(22, 0f);
            closeButton.OnLeftClick += new MouseEvent(CloseButtonClicked);
            BossPanel.Append(closeButton);
            Append(BossPanel);
        }

        private void KingSlimeClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.KingSlime;
                Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                visible = false;
            }
        }
        
        private void EyeOfCthulhuClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.EyeofCthulhu;
                Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                visible = false;
            }
        }

        private void EaterOfWorldsClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (NPC.downedBoss1)
                {
                    Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.EaterofWorldsHead;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                    visible = false;
                }
            }
        }

        private void BrainOfCthulhuClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (NPC.downedBoss1)
                {
                    Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.BrainofCthulhu;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                    visible = false;
                }
            }
        }

        private void QueenBeeClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (NPC.downedBoss2)
                {
                    Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.QueenBee;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                    visible = false;
                }
            }
        }

        private void SkeletronClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (NPC.downedBoss2)
                {
                    Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.SkeletronHead;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                    visible = false;
                }
            }
        }

        private void DeerclopsClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (NPC.downedBoss3)
                {
                    Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.Deerclops;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                    visible = false;
                }
            }
        }

        private void WallOfFleshClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (NPC.downedBoss3)
                {
                    Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.WallofFlesh;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                    visible = false;
                }
            }
        }

        private void QueenSlimeClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (Main.hardMode)
                {
                    Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.QueenSlimeBoss;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                    visible = false;
                }
            }
        }

        private void TwinsClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (Main.hardMode)
                {
                    Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.Retinazer;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                    visible = false;
                }
            }
        }

        private void DestroyerClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (Main.hardMode)
                {
                    Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.TheDestroyer;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                    visible = false;
                }
            }
        }

        private void SkeletronPrimeClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (Main.hardMode)
                {
                    Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.SkeletronPrime;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                    visible = false;
                }
            }
        }

        private void PlanteraClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
                {
                    Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.Plantera;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                    visible = false;
                }
                
            }
        }
        
        private void GolemClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (NPC.downedPlantBoss)
                {
                    Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.Golem;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                    visible = false;
                }
            }
        }

        private void DukeFishronClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (Main.hardMode)
                {
                    Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.DukeFishron;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                    visible = false;
                }
            }
        }

        private void EmpressOfLightClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (NPC.downedPlantBoss)
                {
                    Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.HallowBoss;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                    visible = false;
                }
            }
        }

        private void LunaticCultistClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (NPC.downedGolemBoss)
                {
                    Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.CultistBoss;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                    visible = false;
                }
            }
        }

        private void MoonLordClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (NPC.downedAncientCultist)
                {
                    Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.MoonLordCore;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                    visible = false;
                }
            }
        }

        private void DarkMageClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (NPC.downedBoss2)
                {
                    Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.DD2DarkMageT1;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                    visible = false;
                }
            }
        }

        private void DreadnautilusClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (Main.hardMode)
                {
                    Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.BloodNautilus;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                    visible = false;
                }
            }
        }

        private void FlyingDutchmanClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (Main.hardMode)
                {
                    Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.PirateShip;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                    visible = false;
                }
            }
        }
        
        private void OgreClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (NPC.downedMechBossAny)
                {
                    Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.DD2OgreT2;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                    visible = false;
                }
            }
        }
        
        private void MourningWoodClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (NPC.downedPlantBoss)
                {
                    Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.MourningWood;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                    visible = false;
                }
            }
        }

        private void PumpkingClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (NPC.downedPlantBoss)
                {
                    Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.Pumpking;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                    visible = false;
                }
            }
        }

        private void EverscreamClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (NPC.downedPlantBoss)
                {
                    Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.Everscream;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                    visible = false;
                }
            }
        }

        private void SantankClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (NPC.downedPlantBoss)
                {
                    Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.SantaNK1;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                    visible = false;
                }
            }
        }

        private void IceQueenClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (NPC.downedPlantBoss)
                {
                    Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.IceQueen;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                    visible = false;
                }
            }
        }

        private void MartianSaucerClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (NPC.downedGolemBoss)
                {
                    Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.MartianSaucerCore;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                    visible = false;
                }
            }
        }

        private void BetsyClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (NPC.downedGolemBoss)
                {
                    Main.LocalPlayer.GetQoLCPlayer().bossToSpawn = NPCID.DD2Betsy;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = true;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = false;
                    visible = false;
                }
            }
        }

        private void RainClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.LocalPlayer.GetQoLCPlayer().eventToSpawn = 1;
                Main.LocalPlayer.GetQoLCPlayer().bossSpawn = false;
                Main.LocalPlayer.GetQoLCPlayer().eventSpawn = true;
                visible = false;
            }
        }

        private void WindClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.LocalPlayer.GetQoLCPlayer().eventToSpawn = 2;
                Main.LocalPlayer.GetQoLCPlayer().bossSpawn = false;
                Main.LocalPlayer.GetQoLCPlayer().eventSpawn = true;
                visible = false;
            }
        }

        private void SandstormClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.LocalPlayer.GetQoLCPlayer().eventToSpawn = 3;
                Main.LocalPlayer.GetQoLCPlayer().bossSpawn = false;
                Main.LocalPlayer.GetQoLCPlayer().eventSpawn = true;
                visible = false;
            }
        }

        private void PartyClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.LocalPlayer.GetQoLCPlayer().eventToSpawn = 4;
                Main.LocalPlayer.GetQoLCPlayer().bossSpawn = false;
                Main.LocalPlayer.GetQoLCPlayer().eventSpawn = true;
                visible = false;
            }
        }

        private void SlimeRainClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.LocalPlayer.GetQoLCPlayer().eventToSpawn = 5;
                Main.LocalPlayer.GetQoLCPlayer().bossSpawn = false;
                Main.LocalPlayer.GetQoLCPlayer().eventSpawn = true;
                visible = false;
            }
        }

        private void BloodMoonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.LocalPlayer.GetQoLCPlayer().eventToSpawn = 6;
                Main.LocalPlayer.GetQoLCPlayer().bossSpawn = false;
                Main.LocalPlayer.GetQoLCPlayer().eventSpawn = true;
                visible = false;
            }
        }

        private void GoblinArmyClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                Main.LocalPlayer.GetQoLCPlayer().eventToSpawn = 7;
                Main.LocalPlayer.GetQoLCPlayer().bossSpawn = false;
                Main.LocalPlayer.GetQoLCPlayer().eventSpawn = true;
                visible = false;
            }
        }

        private void FrostLegionClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (Main.hardMode)
                {
                    Main.LocalPlayer.GetQoLCPlayer().eventToSpawn = 8;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = false;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = true;
                    visible = false;
                }
            }
        }

        private void PiratesClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (Main.hardMode)
                {
                    Main.LocalPlayer.GetQoLCPlayer().eventToSpawn = 9;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = false;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = true;
                    visible = false;
                }
            }
        }

        private void EclipseClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (NPC.downedMechBossAny)
                {
                    Main.LocalPlayer.GetQoLCPlayer().eventToSpawn = 10;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = false;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = true;
                    visible = false;
                }
            }
        }

        private void PumpkinMoonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (NPC.downedPlantBoss)
                {
                    Main.LocalPlayer.GetQoLCPlayer().eventToSpawn = 11;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = false;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = true;
                    visible = false;
                }
            }
        }

        private void FrostMoonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (NPC.downedPlantBoss)
                {
                    Main.LocalPlayer.GetQoLCPlayer().eventToSpawn = 12;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = false;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = true;
                    visible = false;
                }
            }
        }

        private void MartiansClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (NPC.downedGolemBoss)
                {
                    Main.LocalPlayer.GetQoLCPlayer().eventToSpawn = 13;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = false;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = true;
                    visible = false;
                }
            }
        }

        private void NebulaPillarClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (NPC.downedAncientCultist)
                {
                    Main.LocalPlayer.GetQoLCPlayer().eventToSpawn = 14;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = false;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = true;
                    visible = false;
                }
            }
        }

        private void SolarPillarClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (NPC.downedAncientCultist)
                {
                    Main.LocalPlayer.GetQoLCPlayer().eventToSpawn = 15;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = false;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = true;
                    visible = false;
                }
            }
        }

        private void StardustPillarClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if(NPC.downedAncientCultist)
                {
                    Main.LocalPlayer.GetQoLCPlayer().eventToSpawn = 16;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = false;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = true;
                    visible = false;
                }
            }
        }

        private void VortexPillarClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (NPC.downedAncientCultist)
                {
                    Main.LocalPlayer.GetQoLCPlayer().eventToSpawn = 17;
                    Main.LocalPlayer.GetQoLCPlayer().bossSpawn = false;
                    Main.LocalPlayer.GetQoLCPlayer().eventSpawn = true;
                    visible = false;
                }
            }
        }

        private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                SoundEngine.PlaySound(SoundID.MenuOpen);
                visible = false;
            }
        }

        Vector2 offset;
        public bool dragging = false;
        private void DragStart(UIMouseEvent evt, UIElement listeningElement)
        {
            offset = new Vector2(evt.MousePosition.X - BossPanel.Left.Pixels, evt.MousePosition.Y - BossPanel.Top.Pixels);
            dragging = true;
        }

        private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            dragging = false;

            BossPanel.Left.Set(end.X - offset.X, 0f);
            BossPanel.Top.Set(end.Y - offset.Y, 0f);

            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 MousePosition = new(Main.mouseX, Main.mouseY);
            if (BossPanel.ContainsPoint(MousePosition))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
            if (dragging)
            {
                BossPanel.Left.Set(MousePosition.X - offset.X, 0f);
                BossPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
                Recalculate();
            }
        }
    }
}
