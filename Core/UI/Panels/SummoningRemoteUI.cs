using Humanizer;
using QoLCompendium.Core.UI.Buttons;
using static Terraria.ModLoader.ModContent;

namespace QoLCompendium.Core.UI.Panels
{
    public class SummoningRemoteUI : UIState
    {
        public UIPanel BossPanel;
        public static bool visible = false;
        public static uint timeStart;
        public Color color = new(156, 37, 37);

        internal static string GetUIText(string key, string category = "SummoningRemoteUI") => QoLCUISystem.GetUIText(category, key);

        public override void OnInitialize()
        {
            BossPanel = new UIPanel();
            BossPanel.SetPadding(5);
            BossPanel.HAlign = 0.647f;
            BossPanel.VAlign = 0.4f;
            BossPanel.Width.Set(565f, 0f);
            BossPanel.Height.Set(200f, 0f);
            BossPanel.BackgroundColor *= 0f;
            BossPanel.BorderColor *= 0f;

            #region Pre-Hardmode Bosses
            ImageButton kingSlime = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_7"));
            kingSlime.Left.Set(0f, 0f);
            kingSlime.Top.Set(0f, 0f);
            kingSlime.Width.Set(50f, 0f);
            kingSlime.Height.Set(50f, 0f);
            kingSlime.OnLeftClick += KingSlimeClicked;
            kingSlime.TooltipText = Lang.GetNPCName(NPCID.KingSlime).Value;
            BossPanel.Append(kingSlime);

            ImageButton eyeOfCthulhu = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_0"));
            eyeOfCthulhu.Left.Set(50f, 0f);
            eyeOfCthulhu.Top.Set(0f, 0f);
            eyeOfCthulhu.Width.Set(50f, 0f);
            eyeOfCthulhu.Height.Set(50f, 0f);
            eyeOfCthulhu.OnLeftClick += EyeOfCthulhuClicked;
            eyeOfCthulhu.TooltipText = Lang.GetNPCName(NPCID.EyeofCthulhu).Value;
            BossPanel.Append(eyeOfCthulhu);

            ImageButton eaterOfWorlds = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_2"));
            eaterOfWorlds.Left.Set(100f, 0f);
            eaterOfWorlds.Top.Set(0f, 0f);
            eaterOfWorlds.Width.Set(50f, 0f);
            eaterOfWorlds.Height.Set(50f, 0f);
            eaterOfWorlds.OnLeftClick += EaterOfWorldsClicked;
            eaterOfWorlds.TooltipText = Lang.GetNPCName(NPCID.EaterofWorldsHead).Value;
            BossPanel.Append(eaterOfWorlds);

            ImageButton brainOfCthulhu = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_23"));
            brainOfCthulhu.Left.Set(150f, 0f);
            brainOfCthulhu.Top.Set(0f, 0f);
            brainOfCthulhu.Width.Set(50f, 0f);
            brainOfCthulhu.Height.Set(50f, 0f);
            brainOfCthulhu.OnLeftClick += BrainOfCthulhuClicked;
            brainOfCthulhu.TooltipText = Lang.GetNPCName(NPCID.BrainofCthulhu).Value;
            BossPanel.Append(brainOfCthulhu);

            ImageButton queenBee = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_14"));
            queenBee.Left.Set(200f, 0f);
            queenBee.Top.Set(0f, 0f);
            queenBee.Width.Set(50f, 0f);
            queenBee.Height.Set(50f, 0f);
            queenBee.OnLeftClick += QueenBeeClicked;
            queenBee.TooltipText = Lang.GetNPCName(NPCID.QueenBee).Value;
            BossPanel.Append(queenBee);

            ImageButton deerclops = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_39"));
            deerclops.Left.Set(250f, 0f);
            deerclops.Top.Set(0f, 0f);
            deerclops.Width.Set(50f, 0f);
            deerclops.Height.Set(50f, 0f);
            deerclops.OnLeftClick += DeerclopsClicked;
            deerclops.TooltipText = Lang.GetNPCName(NPCID.Deerclops).Value;
            BossPanel.Append(deerclops);

            ImageButton skeletron = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_19"));
            skeletron.Left.Set(300f, 0f);
            skeletron.Top.Set(0f, 0f);
            skeletron.Width.Set(50f, 0f);
            skeletron.Height.Set(50f, 0f);
            skeletron.OnLeftClick += SkeletronClicked;
            skeletron.TooltipText = Lang.GetNPCName(NPCID.SkeletronHead).Value;
            BossPanel.Append(skeletron);

            ImageButton wallOfFlesh = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_22"));
            wallOfFlesh.Left.Set(350f, 0f);
            wallOfFlesh.Top.Set(0f, 0f);
            wallOfFlesh.Width.Set(50f, 0f);
            wallOfFlesh.Height.Set(50f, 0f);
            wallOfFlesh.OnLeftClick += WallOfFleshClicked;
            wallOfFlesh.TooltipText = Lang.GetNPCName(NPCID.WallofFlesh).Value;
            BossPanel.Append(wallOfFlesh);
            #endregion

            #region Hardmode Bosses
            ImageButton queenSlime = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_38"));
            queenSlime.Left.Set(0f, 0f);
            queenSlime.Top.Set(50f, 0f);
            queenSlime.Width.Set(50f, 0f);
            queenSlime.Height.Set(50f, 0f);
            queenSlime.OnLeftClick += QueenSlimeClicked;
            queenSlime.TooltipText = Lang.GetNPCName(NPCID.QueenSlimeBoss).Value;
            BossPanel.Append(queenSlime);

            ImageButton twins = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_16"));
            twins.Left.Set(50f, 0f);
            twins.Top.Set(50f, 0f);
            twins.Width.Set(50f, 0f);
            twins.Height.Set(50f, 0f);
            twins.OnLeftClick += TwinsClicked;
            twins.TooltipText = GetUIText("TwinsText");
            BossPanel.Append(twins);

            ImageButton destroyer = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_25"));
            destroyer.Left.Set(100f, 0f);
            destroyer.Top.Set(50f, 0f);
            destroyer.Width.Set(50f, 0f);
            destroyer.Height.Set(50f, 0f);
            destroyer.OnLeftClick += DestroyerClicked;
            destroyer.TooltipText = Lang.GetNPCName(NPCID.TheDestroyer).Value;
            BossPanel.Append(destroyer);

            ImageButton skeletronPrime = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_18"));
            skeletronPrime.Left.Set(150f, 0f);
            skeletronPrime.Top.Set(50f, 0f);
            skeletronPrime.Width.Set(50f, 0f);
            skeletronPrime.Height.Set(50f, 0f);
            skeletronPrime.OnLeftClick += SkeletronPrimeClicked;
            skeletronPrime.TooltipText = Lang.GetNPCName(NPCID.SkeletronPrime).Value;
            BossPanel.Append(skeletronPrime);

            ImageButton plantera = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_11"));
            plantera.Left.Set(200f, 0f);
            plantera.Top.Set(50f, 0f);
            plantera.Width.Set(50f, 0f);
            plantera.Height.Set(50f, 0f);
            plantera.OnLeftClick += PlanteraClicked;
            plantera.TooltipText = Lang.GetNPCName(NPCID.Plantera).Value;
            BossPanel.Append(plantera);

            ImageButton golem = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_5"));
            golem.Left.Set(250f, 0f);
            golem.Top.Set(50f, 0f);
            golem.Width.Set(50f, 0f);
            golem.Height.Set(50f, 0f);
            golem.OnLeftClick += GolemClicked;
            golem.TooltipText = Lang.GetNPCName(NPCID.Golem).Value;
            BossPanel.Append(golem);

            ImageButton dukeFishron = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_4"));
            dukeFishron.Left.Set(300f, 0f);
            dukeFishron.Top.Set(50f, 0f);
            dukeFishron.Width.Set(50f, 0f);
            dukeFishron.Height.Set(50f, 0f);
            dukeFishron.OnLeftClick += DukeFishronClicked;
            dukeFishron.TooltipText = Lang.GetNPCName(NPCID.DukeFishron).Value;
            BossPanel.Append(dukeFishron);

            ImageButton empressOfLight = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_37"));
            empressOfLight.Left.Set(350f, 0f);
            empressOfLight.Top.Set(50f, 0f);
            empressOfLight.Width.Set(50f, 0f);
            empressOfLight.Height.Set(50f, 0f);
            empressOfLight.OnLeftClick += EmpressOfLightClicked;
            empressOfLight.TooltipText = Lang.GetNPCName(NPCID.HallowBoss).Value;
            BossPanel.Append(empressOfLight);

            ImageButton lunaticCultist = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_24"));
            lunaticCultist.Left.Set(400f, 0f);
            lunaticCultist.Top.Set(50f, 0f);
            lunaticCultist.Width.Set(50f, 0f);
            lunaticCultist.Height.Set(50f, 0f);
            lunaticCultist.OnLeftClick += LunaticCultistClicked;
            lunaticCultist.TooltipText = Lang.GetNPCName(NPCID.CultistBoss).Value;
            BossPanel.Append(lunaticCultist);

            ImageButton moonLord = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_8"));
            moonLord.Left.Set(450f, 0f);
            moonLord.Top.Set(50f, 0f);
            moonLord.Width.Set(50f, 0f);
            moonLord.Height.Set(50f, 0f);
            moonLord.OnLeftClick += MoonLordClicked;
            moonLord.TooltipText = GetUIText("MoonLordText");
            BossPanel.Append(moonLord);
            #endregion

            #region Minibosses
            ImageButton darkMage = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_32"));
            darkMage.Left.Set(0f, 0f);
            darkMage.Top.Set(100f, 0f);
            darkMage.Width.Set(50f, 0f);
            darkMage.Height.Set(50f, 0f);
            darkMage.OnLeftClick += DarkMageClicked;
            darkMage.TooltipText = Lang.GetNPCName(NPCID.DD2DarkMageT1).Value;
            BossPanel.Append(darkMage);

            ImageButton dreadnautilus = new(Common.GetAsset("NPCs", "Dreadnautilus_Head"));
            dreadnautilus.Left.Set(50f, 0f);
            dreadnautilus.Top.Set(100f, 0f);
            dreadnautilus.Width.Set(50f, 0f);
            dreadnautilus.Height.Set(50f, 0f);
            dreadnautilus.OnLeftClick += DreadnautilusClicked;
            dreadnautilus.TooltipText = Lang.GetNPCName(NPCID.BloodNautilus).Value;
            BossPanel.Append(dreadnautilus);

            ImageButton flyingDutchman = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_26"));
            flyingDutchman.Left.Set(100f, 0f);
            flyingDutchman.Top.Set(100f, 0f);
            flyingDutchman.Width.Set(50f, 0f);
            flyingDutchman.Height.Set(50f, 0f);
            flyingDutchman.OnLeftClick += FlyingDutchmanClicked;
            flyingDutchman.TooltipText = Lang.GetNPCName(NPCID.PirateShip).Value;
            BossPanel.Append(flyingDutchman);

            ImageButton ogre = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_33"));
            ogre.Left.Set(150f, 0f);
            ogre.Top.Set(100f, 0f);
            ogre.Width.Set(50f, 0f);
            ogre.Height.Set(50f, 0f);
            ogre.OnLeftClick += OgreClicked;
            ogre.TooltipText = Lang.GetNPCName(NPCID.DD2OgreT2).Value;
            BossPanel.Append(ogre);

            ImageButton mourningWood = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_10"));
            mourningWood.Left.Set(200f, 0f);
            mourningWood.Top.Set(100f, 0f);
            mourningWood.Width.Set(50f, 0f);
            mourningWood.Height.Set(50f, 0f);
            mourningWood.OnLeftClick += MourningWoodClicked;
            mourningWood.TooltipText = Lang.GetNPCName(NPCID.MourningWood).Value;
            BossPanel.Append(mourningWood);

            ImageButton pumpking = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_13"));
            pumpking.Left.Set(250f, 0f);
            pumpking.Top.Set(100f, 0f);
            pumpking.Width.Set(50f, 0f);
            pumpking.Height.Set(50f, 0f);
            pumpking.OnLeftClick += PumpkingClicked;
            pumpking.TooltipText = Lang.GetNPCName(NPCID.Pumpking).Value;
            BossPanel.Append(pumpking);

            ImageButton everscream = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_3"));
            everscream.Left.Set(300f, 0f);
            everscream.Top.Set(100f, 0f);
            everscream.Width.Set(50f, 0f);
            everscream.Height.Set(50f, 0f);
            everscream.OnLeftClick += EverscreamClicked;
            everscream.TooltipText = Lang.GetNPCName(NPCID.Everscream).Value;
            BossPanel.Append(everscream);

            ImageButton santank = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_17"));
            santank.Left.Set(350f, 0f);
            santank.Top.Set(100f, 0f);
            santank.Width.Set(50f, 0f);
            santank.Height.Set(50f, 0f);
            santank.OnLeftClick += SantankClicked;
            santank.TooltipText = Lang.GetNPCName(NPCID.SantaNK1).Value;
            BossPanel.Append(santank);

            ImageButton iceQueen = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_6"));
            iceQueen.Left.Set(400f, 0f);
            iceQueen.Top.Set(100f, 0f);
            iceQueen.Width.Set(50f, 0f);
            iceQueen.Height.Set(50f, 0f);
            iceQueen.OnLeftClick += IceQueenClicked;
            iceQueen.TooltipText = Lang.GetNPCName(NPCID.IceQueen).Value;
            BossPanel.Append(iceQueen);

            ImageButton martianSaucer = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_9"));
            martianSaucer.Left.Set(450f, 0f);
            martianSaucer.Top.Set(100f, 0f);
            martianSaucer.Width.Set(50f, 0f);
            martianSaucer.Height.Set(50f, 0f);
            martianSaucer.OnLeftClick += MartianSaucerClicked;
            martianSaucer.TooltipText = Lang.GetNPCName(NPCID.MartianSaucer).Value;
            BossPanel.Append(martianSaucer);

            ImageButton betsy = new(Request<Texture2D>("Terraria/Images/NPC_Head_Boss_34"));
            betsy.Left.Set(500f, 0f);
            betsy.Top.Set(100f, 0f);
            betsy.Width.Set(50f, 0f);
            betsy.Height.Set(50f, 0f);
            betsy.OnLeftClick += BetsyClicked;
            betsy.TooltipText = Lang.GetNPCName(NPCID.DD2Betsy).Value;
            BossPanel.Append(betsy);
            #endregion

            #region Events
            ImageButton party = new(Common.GetAsset("Events", "Event_", (int)UIEnums.EventTypes.Party));
            party.Left.Set(0f, 0f);
            party.Top.Set(150f, 0f);
            party.Width.Set(25f, 0f);
            party.Height.Set(25f, 0f);
            party.OnLeftClick += PartyClicked;
            party.TooltipText = GetUIText("PartyText");
            BossPanel.Append(party);

            ImageButton lanternNight = new(Common.GetAsset("Events", "Event_", (int)UIEnums.EventTypes.LanternNight));
            lanternNight.Left.Set(25f, 0f);
            lanternNight.Top.Set(150f, 0f);
            lanternNight.Width.Set(25f, 0f);
            lanternNight.Height.Set(25f, 0f);
            lanternNight.OnLeftClick += LanternNightClicked;
            lanternNight.TooltipText = GetUIText("LanternNightText");
            BossPanel.Append(lanternNight);

            ImageButton rain = new(Common.GetAsset("Events", "Event_", (int)UIEnums.EventTypes.Rain));
            rain.Left.Set(50f, 0f);
            rain.Top.Set(150f, 0f);
            rain.Width.Set(25f, 0f);
            rain.Height.Set(25f, 0f);
            rain.OnLeftClick += RainClicked;
            rain.TooltipText = GetUIText("RainText");
            BossPanel.Append(rain);

            ImageButton sandstorm = new(Common.GetAsset("Events", "Event_", (int)UIEnums.EventTypes.Sandstorm));
            sandstorm.Left.Set(75f, 0f);
            sandstorm.Top.Set(150f, 0f);
            sandstorm.Width.Set(25f, 0f);
            sandstorm.Height.Set(25f, 0f);
            sandstorm.OnLeftClick += SandstormClicked;
            sandstorm.TooltipText = GetUIText("SandstormText");
            BossPanel.Append(sandstorm);

            ImageButton windyDay = new(Common.GetAsset("Events", "Event_", (int)UIEnums.EventTypes.WindyDay));
            windyDay.Left.Set(100f, 0f);
            windyDay.Top.Set(150f, 0f);
            windyDay.Width.Set(25f, 0f);
            windyDay.Height.Set(25f, 0f);
            windyDay.OnLeftClick += WindyDayClicked;
            windyDay.TooltipText = GetUIText("WindyDayText");
            BossPanel.Append(windyDay);

            ImageButton bloodMoon = new(Common.GetAsset("Events", "Event_", (int)UIEnums.EventTypes.BloodMoon));
            bloodMoon.Left.Set(125f, 0f);
            bloodMoon.Top.Set(150f, 0f);
            bloodMoon.Width.Set(25f, 0f);
            bloodMoon.Height.Set(25f, 0f);
            bloodMoon.OnLeftClick += BloodMoonClicked;
            bloodMoon.TooltipText = GetUIText("BloodMoonText");
            BossPanel.Append(bloodMoon);

            ImageButton slimeRain = new(Common.GetAsset("Events", "Event_", (int)UIEnums.EventTypes.SlimeRain));
            slimeRain.Left.Set(150f, 0f);
            slimeRain.Top.Set(150f, 0f);
            slimeRain.Width.Set(25f, 0f);
            slimeRain.Height.Set(25f, 0f);
            slimeRain.OnLeftClick += SlimeRainClicked;
            slimeRain.TooltipText = GetUIText("SlimeRainText");
            BossPanel.Append(slimeRain);

            ImageButton goblinArmy = new(Common.GetAsset("Events", "Event_", (int)UIEnums.EventTypes.GoblinArmy));
            goblinArmy.Left.Set(175f, 0f);
            goblinArmy.Top.Set(150f, 0f);
            goblinArmy.Width.Set(25f, 0f);
            goblinArmy.Height.Set(25f, 0f);
            goblinArmy.OnLeftClick += GoblinArmyClicked;
            goblinArmy.TooltipText = GetUIText("GoblinArmyText");
            BossPanel.Append(goblinArmy);

            ImageButton frostLegion = new(Common.GetAsset("Events", "Event_", (int)UIEnums.EventTypes.FrostLegion));
            frostLegion.Left.Set(200f, 0f);
            frostLegion.Top.Set(150f, 0f);
            frostLegion.Width.Set(25f, 0f);
            frostLegion.Height.Set(25f, 0f);
            frostLegion.OnLeftClick += FrostLegionClicked;
            frostLegion.TooltipText = GetUIText("FrostLegionText");
            BossPanel.Append(frostLegion);

            ImageButton pirateInvasion = new(Common.GetAsset("Events", "Event_", (int)UIEnums.EventTypes.PirateInvasion));
            pirateInvasion.Left.Set(225f, 0f);
            pirateInvasion.Top.Set(150f, 0f);
            pirateInvasion.Width.Set(25f, 0f);
            pirateInvasion.Height.Set(25f, 0f);
            pirateInvasion.OnLeftClick += PirateInvasionClicked;
            pirateInvasion.TooltipText = GetUIText("PirateInvasionText");
            BossPanel.Append(pirateInvasion);

            ImageButton solarEclipse = new(Common.GetAsset("Events", "Event_", (int)UIEnums.EventTypes.SolarEclipse));
            solarEclipse.Left.Set(250f, 0f);
            solarEclipse.Top.Set(150f, 0f);
            solarEclipse.Width.Set(25f, 0f);
            solarEclipse.Height.Set(25f, 0f);
            solarEclipse.OnLeftClick += SolarEclipseClicked;
            solarEclipse.TooltipText = GetUIText("SolarEclipseText");
            BossPanel.Append(solarEclipse);

            ImageButton pumpkinMoon = new(Common.GetAsset("Events", "Event_", (int)UIEnums.EventTypes.PumpkinMoon));
            pumpkinMoon.Left.Set(275f, 0f);
            pumpkinMoon.Top.Set(150f, 0f);
            pumpkinMoon.Width.Set(25f, 0f);
            pumpkinMoon.Height.Set(25f, 0f);
            pumpkinMoon.OnLeftClick += PumpkinMoonClicked;
            pumpkinMoon.TooltipText = GetUIText("PumpkinMoonText");
            BossPanel.Append(pumpkinMoon);

            ImageButton frostMoon = new(Common.GetAsset("Events", "Event_", (int)UIEnums.EventTypes.FrostMoon));
            frostMoon.Left.Set(300f, 0f);
            frostMoon.Top.Set(150f, 0f);
            frostMoon.Width.Set(25f, 0f);
            frostMoon.Height.Set(25f, 0f);
            frostMoon.OnLeftClick += FrostMoonClicked;
            frostMoon.TooltipText = GetUIText("FrostMoonText");
            BossPanel.Append(frostMoon);

            ImageButton martianMadness = new(Common.GetAsset("Events", "Event_", (int)UIEnums.EventTypes.MartianMadness));
            martianMadness.Left.Set(325f, 0f);
            martianMadness.Top.Set(150f, 0f);
            martianMadness.Width.Set(25f, 0f);
            martianMadness.Height.Set(25f, 0f);
            martianMadness.OnLeftClick += MartianMadnessClicked;
            martianMadness.TooltipText = GetUIText("MartianMadnessText");
            BossPanel.Append(martianMadness);

            ImageButton lunarEvent = new(Common.GetAsset("Events", "Event_", (int)UIEnums.EventTypes.LunarEvent));
            lunarEvent.Left.Set(350f, 0f);
            lunarEvent.Top.Set(150f, 0f);
            lunarEvent.Width.Set(25f, 0f);
            lunarEvent.Height.Set(25f, 0f);
            lunarEvent.OnLeftClick += LunarEventClicked;
            lunarEvent.TooltipText = GetUIText("LunarEventText");
            BossPanel.Append(lunarEvent);
            #endregion

            ImageButton closeButton = new(Common.GetAsset("Buttons", "Button_Small_", 3));
            closeButton.Left.Set(530f, 0f);
            closeButton.Top.Set(5f, 0f);
            closeButton.Width.Set(20f, 0f);
            closeButton.Height.Set(20f, 0f);
            closeButton.OnLeftClick += CloseButtonClicked;
            closeButton.TooltipText = Language.GetTextValue("LegacyInterface.52");
            BossPanel.Append(closeButton);

            Append(BossPanel);
        }

        private void KingSlimeClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.KingSlime);

        private void EyeOfCthulhuClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.EyeofCthulhu);

        private void EaterOfWorldsClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.EaterofWorldsHead, Condition.DownedEyeOfCthulhu);

        private void BrainOfCthulhuClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.BrainofCthulhu, Condition.DownedEyeOfCthulhu);

        private void QueenBeeClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.QueenBee, Condition.DownedEowOrBoc);

        private void SkeletronClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.SkeletronHead, Condition.DownedEowOrBoc);

        private void DeerclopsClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.Deerclops);

        private void WallOfFleshClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.WallofFlesh, Condition.DownedSkeletron);

        private void QueenSlimeClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.QueenSlimeBoss, Condition.Hardmode);

        private void TwinsClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.Retinazer, Condition.Hardmode);

        private void DestroyerClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.TheDestroyer, Condition.Hardmode);

        private void SkeletronPrimeClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.SkeletronPrime, Condition.Hardmode);

        private void PlanteraClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.Plantera, Condition.Hardmode, Condition.DownedMechBossAll);

        private void GolemClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.Golem, Condition.Hardmode, Condition.DownedPlantera);

        private void DukeFishronClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.DukeFishron, Condition.Hardmode);

        private void EmpressOfLightClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.HallowBoss, Condition.Hardmode, Condition.DownedPlantera);

        private void LunaticCultistClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.CultistBoss, Condition.Hardmode, Condition.DownedGolem);

        private void MoonLordClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.MoonLordCore, Condition.Hardmode, Condition.DownedCultist);

        private void DarkMageClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.DD2DarkMageT1, Condition.DownedOldOnesArmyAny);

        private void DreadnautilusClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.BloodNautilus, Condition.Hardmode);

        private void FlyingDutchmanClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.PirateShip, Condition.Hardmode, Condition.DownedPirates);

        private void OgreClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.DD2OgreT2, Condition.Hardmode, Condition.DownedOldOnesArmyT2);

        private void MourningWoodClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.MourningWood, Condition.Hardmode, Condition.DownedPlantera);

        private void PumpkingClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.Pumpking, Condition.Hardmode, Condition.DownedPlantera);

        private void EverscreamClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.Everscream, Condition.Hardmode, Condition.DownedPlantera);

        private void SantankClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.SantaNK1, Condition.Hardmode, Condition.DownedPlantera);

        private void IceQueenClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.IceQueen, Condition.Hardmode, Condition.DownedPlantera);

        private void MartianSaucerClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.MartianSaucerCore, Condition.Hardmode, Condition.DownedGolem);

        private void BetsyClicked(UIMouseEvent evt, UIElement listeningElement) => BossClick(NPCID.DD2Betsy, Condition.Hardmode, Condition.DownedOldOnesArmyT3);

        private void PartyClicked(UIMouseEvent evt, UIElement listeningElement) => EventClick((int)UIEnums.EventTypes.Party);

        private void LanternNightClicked(UIMouseEvent evt, UIElement listeningElement) => EventClick((int)UIEnums.EventTypes.LanternNight);

        private void RainClicked(UIMouseEvent evt, UIElement listeningElement) => EventClick((int)UIEnums.EventTypes.Rain);

        private void SandstormClicked(UIMouseEvent evt, UIElement listeningElement) => EventClick((int)UIEnums.EventTypes.Sandstorm);

        private void WindyDayClicked(UIMouseEvent evt, UIElement listeningElement) => EventClick((int)UIEnums.EventTypes.WindyDay);

        private void BloodMoonClicked(UIMouseEvent evt, UIElement listeningElement) => EventClick((int)UIEnums.EventTypes.BloodMoon);

        private void SlimeRainClicked(UIMouseEvent evt, UIElement listeningElement) => EventClick((int)UIEnums.EventTypes.SlimeRain);

        private void GoblinArmyClicked(UIMouseEvent evt, UIElement listeningElement) => EventClick((int)UIEnums.EventTypes.GoblinArmy);

        private void FrostLegionClicked(UIMouseEvent evt, UIElement listeningElement) => EventClick((int)UIEnums.EventTypes.FrostLegion, Condition.Hardmode);

        private void PirateInvasionClicked(UIMouseEvent evt, UIElement listeningElement) => EventClick((int)UIEnums.EventTypes.PirateInvasion, Condition.Hardmode);

        private void SolarEclipseClicked(UIMouseEvent evt, UIElement listeningElement) => EventClick((int)UIEnums.EventTypes.SolarEclipse, Condition.Hardmode, Condition.DownedMechBossAny);

        private void PumpkinMoonClicked(UIMouseEvent evt, UIElement listeningElement) => EventClick((int)UIEnums.EventTypes.PumpkinMoon, Condition.Hardmode, Condition.DownedPlantera);

        private void FrostMoonClicked(UIMouseEvent evt, UIElement listeningElement) => EventClick((int)UIEnums.EventTypes.FrostMoon, Condition.Hardmode, Condition.DownedPlantera);

        private void MartianMadnessClicked(UIMouseEvent evt, UIElement listeningElement) => EventClick((int)UIEnums.EventTypes.MartianMadness, Condition.Hardmode, Condition.DownedGolem);

        private void LunarEventClicked(UIMouseEvent evt, UIElement listeningElement) => EventClick((int)UIEnums.EventTypes.LunarEvent, Condition.Hardmode, Condition.DownedCultist);

        public static void BossClick(int bossID, params Condition[] conditions)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (conditions != null && conditions.Length > 0)
                {
                    if (conditions.All(x => x.IsMet()))
                    {
                        SoundEngine.PlaySound(SoundID.MenuOpen);
                        QoLCPlayer player = QoLCPlayer.Get(Main.LocalPlayer);
                        player.bossToSpawn = bossID;
                        player.bossSpawn = true;
                        player.eventSpawn = false;
                        visible = false;
                    }
                    else
                    {
                        SoundEngine.PlaySound(SoundID.Tink);
                        string descriptions = "";
                        if (conditions.Length > 1)
                        {
                            for (int i = 0; i < conditions.Length; i++)
                            {
                                string temp = "";
                                for (int j = 0; j < conditions[i].Description.Value.Length; j++)
                                {
                                    if (j == 0 && char.IsUpper(conditions[i].Description.Value[j]))
                                        temp += conditions[i].Description.Value[j].ToString().ToLower();
                                    else
                                        temp += conditions[i].Description.Value[j].ToString();
                                }

                                if (i < conditions.Length - 1)
                                    descriptions += temp + ", ";
                                else
                                    descriptions += temp;
                            }
                        }
                        else
                        {
                            string temp = "";
                            for (int j = 0; j < conditions[0].Description.Value.Length; j++)
                            {
                                if (j == 0 && char.IsUpper(conditions[0].Description.Value[j]))
                                    temp += conditions[0].Description.Value[j].ToString().ToLower();
                                else
                                    temp += conditions[0].Description.Value[j].ToString();
                            }

                            descriptions += temp;
                        }
                        TextHelper.PrintText(Language.GetTextValue("Mods.QoLCompendium.Messages.Locked").FormatWith(descriptions), new Color(255, 240, 20), true);
                    }
                }
                else
                {
                    SoundEngine.PlaySound(SoundID.MenuOpen);
                    QoLCPlayer player = QoLCPlayer.Get(Main.LocalPlayer);
                    player.bossToSpawn = bossID;
                    player.bossSpawn = true;
                    player.eventSpawn = false;
                    visible = false;
                }
            }
        }

        public static void EventClick(int eventID, params Condition[] conditions)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                if (conditions != null && conditions.Length > 0)
                {
                    if (conditions.All(x => x.IsMet()))
                    {
                        SoundEngine.PlaySound(SoundID.MenuOpen);
                        QoLCPlayer player = QoLCPlayer.Get(Main.LocalPlayer);
                        player.eventToSpawn = eventID;
                        player.bossSpawn = false;
                        player.eventSpawn = true;
                        visible = false;
                    }
                    else
                    {
                        SoundEngine.PlaySound(SoundID.Tink);
                        string descriptions = "";
                        if (conditions.Length > 1)
                        {
                            for (int i = 0; i < conditions.Length; i++)
                            {
                                string temp = "";
                                for (int j = 0; j < conditions[i].Description.Value.Length; j++)
                                {
                                    if (j == 0 && char.IsUpper(conditions[i].Description.Value[j]))
                                        temp += conditions[i].Description.Value[j].ToString().ToLower();
                                    else
                                        temp += conditions[i].Description.Value[j].ToString();
                                }

                                if (i < conditions.Length - 1)
                                    descriptions += temp + ", ";
                                else
                                    descriptions += temp;
                            }
                        }
                        else
                        {
                            string temp = "";
                            for (int j = 0; j < conditions[0].Description.Value.Length; j++)
                            {
                                if (j == 0 && char.IsUpper(conditions[0].Description.Value[j]))
                                    temp += conditions[0].Description.Value[j].ToString().ToLower();
                                else
                                    temp += conditions[0].Description.Value[j].ToString();
                            }

                            descriptions += temp;
                        }
                        TextHelper.PrintText(Language.GetTextValue("Mods.QoLCompendium.Messages.Locked").FormatWith(descriptions), new Color(255, 240, 20), true);
                    }
                }
                else
                {
                    SoundEngine.PlaySound(SoundID.MenuOpen);
                    QoLCPlayer player = QoLCPlayer.Get(Main.LocalPlayer);
                    player.eventToSpawn = eventID;
                    player.bossSpawn = false;
                    player.eventSpawn = true;
                    visible = false;
                }
            }
        }

        private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= 10)
            {
                SoundEngine.PlaySound(SoundID.MenuClose);
                visible = false;
            }
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Rectangle target = new((int)BossPanel.GetDimensions().X, (int)BossPanel.GetDimensions().Y, (int)BossPanel.GetDimensions().Width, (int)BossPanel.GetDimensions().Height);
            BackgroundDrawing.DrawBackground(spriteBatch, target, color);
            BackgroundDrawing.DrawBorder(spriteBatch, target, color);
        }
    }
}
