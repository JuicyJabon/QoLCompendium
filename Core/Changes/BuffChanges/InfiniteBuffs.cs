using QoLCompendium.Content.Items.Tools.Usables;
using Terraria.DataStructures;

namespace QoLCompendium.Core.Changes.BuffChanges
{
    public class BuffPlayer : ModPlayer
    {
        private bool hasLuckyLesser;
        private bool hasLucky;
        private bool hasLuckyGreater;
        private bool hasGardenGnome;
        public byte oldLuckPotion;

        private readonly Dictionary<int, List<ItemInfo>> infoByItemType = [];

        private readonly HashSet<int> infiniteStackedItems = [];

        public static BuffPlayer Get(Player player) => player.GetModPlayer<BuffPlayer>();

        public override void PreUpdateBuffs()
        {
            hasLuckyLesser = hasLucky = hasLuckyGreater = false;
            oldLuckPotion = Player.oldLuckPotion;
            infoByItemType.Clear();
            infiniteStackedItems.Clear();

            if (QoLCompendium.mainConfig.EndlessPotionBuffs || QoLCompendium.mainConfig.EndlessStationBuffs)
                CheckInventory(Common.GetAllInventoryItemsList(Player).ToArray());

            InfiniteBannerBuffs.CheckBannerTooltips(Common.GetAllInventoryItemsList(Player));
        }

        public override void PostUpdateBuffs()
        {
            int luckLevel = hasLuckyGreater ? 3 : hasLucky ? 2 : hasLuckyLesser ? 1 : 0;
            if (Player.whoAmI == Main.myPlayer && Player.luckPotion != luckLevel)
            {
                if (Player.luckPotion < luckLevel)
                {
                    Player.luckNeedsSync = true;
                    Player.luckPotion = (byte)luckLevel;
                }
            }
            else if (Player.luckNeedsSync)
                Player.luckNeedsSync = false;
            Player.oldLuckPotion = oldLuckPotion = Player.luckPotion;
        }

        public override void ModifyLuck(ref float luck)
        {
            if (hasGardenGnome)
                luck += 0.2f;
            hasGardenGnome = false;
        }

        public void CheckInventory(Item[] inventory)
        {
            infoByItemType.Clear();
            foreach (Item val in inventory)
            {
                if (!val.IsAir)
                    CheckItemForInfiniteBuffs(val);
            }
        }

        public void CheckItemForInfiniteBuffs(Item item)
        {
            if (!item.IsAir)
            {
                CheckPotion(item);
                CheckEnvironment(item);
                CheckStation(item);
                CheckHoney(item);
                CheckExtras(item);
            }
        }

        private void CheckExtras(Item item)
        {
            if (item.ModItem is PotionCrate potionCrate)
            {
                Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(item.type);
                for (int i = 0; i < potionCrate.BuffIDList.Count; i++)
                {
                    Player.AddBuff(potionCrate.BuffIDList[i], 2, true, false);
                    if (!Player.GetModPlayer<QoLCPlayer>().activeBuffs.Contains(potionCrate.BuffIDList[i]))
                        Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(potionCrate.BuffIDList[i]);
                    if (potionCrate.ItemIDList.Contains(ItemID.LuckPotionLesser))
                        hasLuckyLesser = true;
                    if (potionCrate.ItemIDList.Contains(ItemID.LuckPotion))
                        hasLucky = true;
                    if (potionCrate.ItemIDList.Contains(ItemID.LuckPotionGreater))
                        hasLuckyGreater = true;
                }
            }
            if (item.type == ItemID.RedPotion && Main.getGoodWorld && QoLCompendium.mainConfig.EndlessPotionBuffs)
            {
                Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(item.type);
                for (int i = 0; i < Common.RedPotionBuffs.Count; i++)
                {
                    Player.AddBuff(Common.RedPotionBuffs.ElementAt(i), 2, true, false);
                    if (!Player.GetModPlayer<QoLCPlayer>().activeBuffs.Contains(Common.RedPotionBuffs.ElementAt(i)))
                        Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(Common.RedPotionBuffs.ElementAt(i));
                }
            }
            if (item.type == ItemID.HoneyBucket || item.type == ItemID.BottomlessHoneyBucket && QoLCompendium.mainConfig.EndlessStationBuffs)
            {
                Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(item.type);
                Player.AddBuff(BuffID.Honey, 2, true, false);
                if (!Player.GetModPlayer<QoLCPlayer>().activeBuffs.Contains(BuffID.Honey))
                    Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.Honey);
            }
            if (item.type == ItemID.GardenGnome && QoLCompendium.mainConfig.EndlessStationBuffs)
            {
                Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(item.type);
                hasGardenGnome = true;
            }
        }

        private void CheckPotion(Item item)
        {
            if (CheckPotion_IsBuffPotion(item) && QoLCompendium.mainConfig.EndlessPotionBuffs)
            {
                if (!infoByItemType.ContainsKey(item.type))
                {
                    infoByItemType.Add(item.type, []);
                }
                ItemInfo itemInfo = new(item);
                infoByItemType[item.type].Add(itemInfo);
                if (QoLCompendium.mainConfig.EndlessBuffAmount > 0 && item.stack >= QoLCompendium.mainConfig.EndlessBuffAmount)
                {
                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(item.type);
                    infiniteStackedItems.Add(item.type);
                    CheckPotion_AddBuff(itemInfo);
                }
            }
        }

        private static bool CheckPotion_IsBuffPotion(Item item)
        {
            if (item.healLife <= 0 && item.healMana <= 0 && item.buffType > 0)
                return item.buffTime > 0;
            return false;
        }

        private void CheckPotion_AddBuff(ItemInfo info)
        {
            Player.AddBuff(info.buffType, 2);
            if (!Player.GetModPlayer<QoLCPlayer>().activeBuffs.Contains(info.buffType))
                Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(info.buffType);

            if (info.type == ItemID.LuckPotionLesser)
                hasLuckyLesser = true;
            else if (info.type == ItemID.LuckPotion)
                hasLucky = true;
            else if (info.type == ItemID.LuckPotionGreater)
                hasLuckyGreater = true;
        }

        private void CheckEnvironment(Item item)
        {
            if (CheckEnvironment_ItemIsValidPlaceableTile(item) && QoLCompendium.mainConfig.EndlessStationBuffs)
            {
                if (!infoByItemType.ContainsKey(item.type))
                {
                    infoByItemType.Add(item.type, []);
                }
                ItemInfo itemInfo = new(item);
                infoByItemType[item.type].Add(itemInfo);
                int stackTarget = GetStackTarget(item, QoLCompendium.mainConfig.EndlessStationAmount);
                if (stackTarget > 0 && item.stack >= stackTarget)
                {
                    infiniteStackedItems.Add(item.type);
                    CheckEnvironment_AddBuffs(itemInfo);
                }
            }
        }

        private void CheckEnvironment_AddBuffs(ItemInfo info)
        {
            switch (info.createTile)
            {
                case TileID.Campfire:
                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(info.type);
                    CheckEnvironment_Campfire();
                    break;
                case TileID.Sunflower:
                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(info.type);
                    CheckEnvironment_Sunflower();
                    break;
                case TileID.HangingLanterns:
                    if (info.placeStyle == 9)
                    {
                        Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(info.type);
                        CheckEnvironment_HeartLantern();
                    }
                    else if (info.placeStyle == 7)
                    {
                        Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(info.type);
                        CheckEnvironment_StarInABottle();
                    }
                    break;
                case TileID.WaterCandle:
                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(info.type);
                    CheckEnvironment_WaterCandle(info.stack);
                    break;
                case TileID.PeaceCandle:
                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(info.type);
                    CheckEnvironment_PeaceCandle(info.stack);
                    break;
                case TileID.ShadowCandle:
                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(info.type);
                    CheckEnvironment_ShadowCandle(info.stack);
                    break;
                case TileID.CatBast:
                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(info.type);
                    CheckEnvironment_CatBast();
                    break;
            }
            HashSet<int> nearbyEffects =
            [
                TileID.Campfire,
                TileID.Sunflower,
                //TileID.HangingLanterns,
                TileID.WaterCandle,
                TileID.PeaceCandle,
                TileID.ShadowCandle,
                TileID.CatBast
            ];
            if (info.createTile == TileID.HangingLanterns && (info.placeStyle == 7 || info.placeStyle == 9) || nearbyEffects.Contains(info.createTile))
            {
                Point16 val = Player.Center.ToTileCoordinates16();
                TileLoader.NearbyEffects(val.X, val.Y, info.createTile, false);
            }
        }

        private static int GetStackTarget(Item item, int defaultStackConfig)
        {
            if (item.IsAir)
            {
                return defaultStackConfig;
            }
            if (item.type == ItemID.BottledHoney)
            {
                return QoLCompendium.mainConfig.EndlessBuffAmount;
            }
            switch (item.createTile)
            {
                case TileID.Campfire:
                    return QoLCompendium.mainConfig.EndlessStationAmount;
                case TileID.Sunflower:
                    return QoLCompendium.mainConfig.EndlessStationAmount;
                case TileID.HangingLanterns:
                    if (item.placeStyle == 9)
                    {
                        return QoLCompendium.mainConfig.EndlessStationAmount;
                    }
                    if (item.placeStyle == 7)
                    {
                        return QoLCompendium.mainConfig.EndlessStationAmount;
                    }
                    break;
                case TileID.WaterCandle:
                    return QoLCompendium.mainConfig.EndlessStationAmount;
                case TileID.PeaceCandle:
                    return QoLCompendium.mainConfig.EndlessStationAmount;
                case TileID.ShadowCandle:
                    return QoLCompendium.mainConfig.EndlessStationAmount;
                case TileID.CatBast:
                    return QoLCompendium.mainConfig.EndlessStationAmount;
                case TileID.AmmoBox:
                    return QoLCompendium.mainConfig.EndlessStationAmount;
                case TileID.BewitchingTable:
                    return QoLCompendium.mainConfig.EndlessStationAmount;
                case TileID.CrystalBall:
                    return QoLCompendium.mainConfig.EndlessStationAmount;
                case TileID.SharpeningStation:
                    return QoLCompendium.mainConfig.EndlessStationAmount;
                case TileID.WarTable:
                    return QoLCompendium.mainConfig.EndlessStationAmount;
                case TileID.SliceOfCake:
                    return QoLCompendium.mainConfig.EndlessStationAmount;
            }
            return defaultStackConfig;
        }

        private static bool CheckEnvironment_ItemIsValidPlaceableTile(Item item)
        {
            if (item.createTile >= TileID.Dirt && item.type != ItemID.DirtBlock)
                return Main.tileFrameImportant[item.createTile];
            return false;
        }

        private void CheckEnvironment_Campfire()
        {
            Main.SceneMetrics.HasCampfire = true;
            Player.AddBuff(BuffID.Campfire, 2, false, false);
            if (!Player.GetModPlayer<QoLCPlayer>().activeBuffs.Contains(BuffID.Campfire))
                Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.Campfire);
        }

        private void CheckEnvironment_Sunflower()
        {
            if (Main.SceneMetrics.GraveyardTileCount <= SceneMetrics.GraveyardTileMin)
            {
                Main.SceneMetrics.HasSunflower = true;
                Player.AddBuff(BuffID.Sunflower, 2, false, false);
                if (!Player.GetModPlayer<QoLCPlayer>().activeBuffs.Contains(BuffID.Sunflower))
                    Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.Sunflower);
            }
        }

        private void CheckEnvironment_HeartLantern()
        {
            Main.SceneMetrics.HasHeartLantern = true;
            Player.AddBuff(BuffID.HeartLamp, 2, false, false);
            if (!Player.GetModPlayer<QoLCPlayer>().activeBuffs.Contains(BuffID.HeartLamp))
                Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.HeartLamp);
        }

        private void CheckEnvironment_StarInABottle()
        {
            Main.SceneMetrics.HasStarInBottle = true;
            Player.AddBuff(BuffID.StarInBottle, 2, false, false);
            if (!Player.GetModPlayer<QoLCPlayer>().activeBuffs.Contains(BuffID.StarInBottle))
                Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.StarInBottle);
        }

        private void CheckEnvironment_WaterCandle(int count)
        {
            Main.SceneMetrics.WaterCandleCount += count;
            Player.AddBuff(BuffID.WaterCandle, 2, false, false);
            if (!Player.GetModPlayer<QoLCPlayer>().activeBuffs.Contains(BuffID.WaterCandle))
                Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.WaterCandle);
            Player.ZoneWaterCandle = true;
        }

        private void CheckEnvironment_PeaceCandle(int count)
        {
            Main.SceneMetrics.PeaceCandleCount += count;
            Player.AddBuff(BuffID.PeaceCandle, 2, false, false);
            if (!Player.GetModPlayer<QoLCPlayer>().activeBuffs.Contains(BuffID.PeaceCandle))
                Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.PeaceCandle);
            Player.ZonePeaceCandle = true;
        }

        private void CheckEnvironment_ShadowCandle(int count)
        {
            Main.SceneMetrics.ShadowCandleCount += count;
            Player.AddBuff(BuffID.ShadowCandle, 2, false, false);
            if (!Player.GetModPlayer<QoLCPlayer>().activeBuffs.Contains(BuffID.ShadowCandle))
                Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.ShadowCandle);
            Player.ZoneShadowCandle = true;
        }

        private void CheckEnvironment_CatBast()
        {
            Main.SceneMetrics.HasCatBast = true;
            Player.AddBuff(BuffID.CatBast, 2, false, false);
            if (!Player.GetModPlayer<QoLCPlayer>().activeBuffs.Contains(BuffID.CatBast))
                Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.CatBast);
        }

        private void CheckStation(Item item)
        {
            if (CheckEnvironment_ItemIsValidPlaceableTile(item) && QoLCompendium.mainConfig.EndlessStationBuffs)
            {
                if (!infoByItemType.TryGetValue(item.type, out List<ItemInfo> value))
                {
                    value = [];
                    infoByItemType.Add(item.type, value);
                }
                ItemInfo itemInfo = new(item);
                value.Add(itemInfo);
                int stackTarget = GetStackTarget(item, QoLCompendium.mainConfig.EndlessStationAmount);
                if (stackTarget > 0 && item.stack >= stackTarget)
                {
                    infiniteStackedItems.Add(item.type);
                    CheckStation_AddBuffs(itemInfo);
                }
            }
        }

        private void CheckStation_AddBuffs(ItemInfo info)
        {
            switch (info.createTile)
            {
                case TileID.AmmoBox:
                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(info.type);
                    Player.AddBuff(BuffID.AmmoBox, 2, true, false);
                    if (!Player.GetModPlayer<QoLCPlayer>().activeBuffs.Contains(BuffID.AmmoBox))
                        Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.AmmoBox);
                    return;
                case TileID.BewitchingTable:
                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(info.type);
                    Player.AddBuff(BuffID.Bewitched, 2, true, false);
                    if (!Player.GetModPlayer<QoLCPlayer>().activeBuffs.Contains(BuffID.Bewitched))
                        Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.Bewitched);
                    return;
                case TileID.CrystalBall:
                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(info.type);
                    Player.AddBuff(BuffID.Clairvoyance, 2, true, false);
                    if (!Player.GetModPlayer<QoLCPlayer>().activeBuffs.Contains(BuffID.Clairvoyance))
                        Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.Clairvoyance);
                    return;
                case TileID.SharpeningStation:
                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(info.type);
                    Player.AddBuff(BuffID.Sharpened, 2, true, false);
                    if (!Player.GetModPlayer<QoLCPlayer>().activeBuffs.Contains(BuffID.Sharpened))
                        Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.Sharpened);
                    return;
                case TileID.SliceOfCake:
                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(info.type);
                    Player.AddBuff(BuffID.SugarRush, 2, true, false);
                    if (!Player.GetModPlayer<QoLCPlayer>().activeBuffs.Contains(BuffID.SugarRush))
                        Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.SugarRush);
                    return;
                case TileID.WarTable:
                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(info.type);
                    Player.AddBuff(BuffID.WarTable, 2, true, false);
                    if (!Player.GetModPlayer<QoLCPlayer>().activeBuffs.Contains(BuffID.WarTable))
                        Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.WarTable);
                    return;
            }
            foreach (var moddedBuff in BuffSystem.ModdedPlaceableItemBuffs)
            {
                Item electroDeterrent = new();
                if (CrossModSupport.SecretsOfTheShadows.Loaded)
                    electroDeterrent.type = Common.GetModItem(CrossModSupport.SecretsOfTheShadows.Mod, "ElectromagneticDeterrent");

                if (info.type == moddedBuff.Key)
                {
                    if (CrossModSupport.SecretsOfTheShadows.Loaded && info.type == electroDeterrent.type && Player.HasItem(electroDeterrent.type) && !Player.inventory[Common.GetSlotItemIsIn(electroDeterrent, Player.inventory)].favorited)
                        return;

                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(info.type);
                    Player.AddBuff(moddedBuff.Value, 2);
                    if (!Player.GetModPlayer<QoLCPlayer>().activeBuffs.Contains(moddedBuff.Value))
                        Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(moddedBuff.Value);
                }
            }
        }

        private void CheckHoney(Item item)
        {
            if (item.type == ItemID.BottledHoney && QoLCompendium.mainConfig.EndlessPotionBuffs)
            {
                if (!infoByItemType.TryGetValue(item.type, out List<ItemInfo> value))
                {
                    value = [];
                    infoByItemType.Add(item.type, value);
                }
                ItemInfo item2 = new(item);
                value.Add(item2);
                if (QoLCompendium.mainConfig.EndlessBuffAmount > 0 && item.stack >= QoLCompendium.mainConfig.EndlessBuffAmount)
                {
                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(item.type);
                    infiniteStackedItems.Add(item.type);
                    CheckHoney_AddBuff();
                }
            }
        }

        private void CheckHoney_AddBuff()
        {
            Player.AddBuff(BuffID.Honey, 2, true, false);
            if (!Player.GetModPlayer<QoLCPlayer>().activeBuffs.Contains(BuffID.Honey))
                Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.Honey);
        }
    }

    public class BuffSystem : ModSystem
    {
        internal static Dictionary<int, int> ModdedPlaceableItemBuffs = [];

        public static void DoBuffIntegration()
        {
            //AFKPETS
            if (CrossModSupport.AFKPets.Loaded)
            {
                AddBuffIntegration(CrossModSupport.AFKPets.Mod, "ChaosAmplifier", "ChaosAmplifier");
                AddBuffIntegration(CrossModSupport.AFKPets.Mod, "PortableRocketLauncher", "Dispenser");
                AddVanillaBuffIntegration(CrossModSupport.AFKPets.Mod, "DruidicArtifact", BuffID.DryadsWard);
                AddBuffIntegration(CrossModSupport.AFKPets.Mod, "EchoFlower", "EchoFlower");
                AddBuffIntegration(CrossModSupport.AFKPets.Mod, "FallenSoulContainer", "FallenSoul");
                AddBuffIntegration(CrossModSupport.AFKPets.Mod, "SacrificialAltar", "SacrificialAltar");
            }

            //BLOCKS THROWER
            if (CrossModSupport.BlocksThrower.Loaded)
            {
                AddBuffIntegration(CrossModSupport.BlocksThrower.Mod, "ThrowingBoard", "DeadlyPrecision");
            }
            
            //CALAMITY
            if (CrossModSupport.Calamity.Loaded)
            {
                AddBuffIntegration(CrossModSupport.Calamity.Mod, "WeightlessCandle", "BlueCandleBuff");
                AddBuffIntegration(CrossModSupport.Calamity.Mod, "VigorousCandle", "PinkCandleBuff");
                AddBuffIntegration(CrossModSupport.Calamity.Mod, "SpitefulCandle", "YellowCandleBuff");
                AddBuffIntegration(CrossModSupport.Calamity.Mod, "ResilientCandle", "PurpleCandleBuff");
                AddBuffIntegration(CrossModSupport.Calamity.Mod, "ChaosCandle", "ChaosCandleBuff");
                AddBuffIntegration(CrossModSupport.Calamity.Mod, "TranquilityCandle", "TranquilityCandleBuff");
                AddBuffIntegration(CrossModSupport.Calamity.Mod, "EffigyOfDecay", "EffigyOfDecayBuff");
                AddBuffIntegration(CrossModSupport.Calamity.Mod, "CrimsonEffigy", "CrimsonEffigyBuff");
                AddBuffIntegration(CrossModSupport.Calamity.Mod, "CorruptionEffigy", "CorruptionEffigyBuff");
            }

            //CALAMITY COMMUNITY REMIX
            if (CrossModSupport.CalamityCommunityRemix.Loaded)
            {
                AddBuffIntegration(CrossModSupport.CalamityCommunityRemix.Mod, "AstralEffigy", "AstralEffigyBuff");
                AddBuffIntegration(CrossModSupport.CalamityCommunityRemix.Mod, "HallowEffigy", "HallowEffigyBuff");
            }

            //CALAMITY ENTROPY
            if (CrossModSupport.CalamityEntropy.Loaded)
            {
                AddBuffIntegration(CrossModSupport.CalamityEntropy.Mod, "VoidCandle", "VoidCandleBuff");
            }

            //CAPTURE DISCS CLASS
            if (CrossModSupport.CaptureDiscClass.Loaded)
            {
                AddBuffIntegration(CrossModSupport.CaptureDiscClass.Mod, "DiscCharger", "ChargedDisc");
            }

            //CLICKER CLASS
            if (CrossModSupport.ClickerClass.Loaded)
            {
                AddBuffIntegration(CrossModSupport.ClickerClass.Mod, "DesktopComputer", "DesktopComputerBuff");
            }

            //DEMOLISHER CLASS
            if (CrossModSupport.DemolisherClass.Loaded)
            {
                AddBuffIntegration(CrossModSupport.DemolisherClass.Mod, "BlastingSupplyBoxItem", "BlastingSupplyBoxBuff");
            }

            //FARGOS
            if (CrossModSupport.Fargowiltas.Loaded)
            {
                AddBuffIntegration(CrossModSupport.Fargowiltas.Mod, "Semistation", "Semistation");
                AddBuffIntegration(CrossModSupport.Fargowiltas.Mod, "Omnistation", "Omnistation");
                AddBuffIntegration(CrossModSupport.Fargowiltas.Mod, "Omnistation2", "Omnistation");
            }

            //HOMEWARD JOURNEY
            if (CrossModSupport.HomewardJourney.Loaded)
            {
                AddBuffIntegration(CrossModSupport.HomewardJourney.Mod, "BushOfLife", "BushOfLifeBuff");
                AddBuffIntegration(CrossModSupport.HomewardJourney.Mod, "LifeLantern", "LifeLanternBuff");
            }

            //MARTIN'S ORDER
            if (CrossModSupport.MartinsOrder.Loaded)
            {
                AddBuffIntegration(CrossModSupport.MartinsOrder.Mod, "ArcheologyTable", "ReschBuff");
                AddBuffIntegration(CrossModSupport.MartinsOrder.Mod, "SporeFarm", "SporeSave");
            }

            //REDEMPTION
            if (CrossModSupport.Redemption.Loaded)
            {
                AddBuffIntegration(CrossModSupport.Redemption.Mod, "EnergyStation", "EnergyStationBuff");
                AddBuffIntegration(CrossModSupport.Redemption.Mod, "MoonflareCandle", "MoonflareCandleBuff");
                AddBuffIntegration(CrossModSupport.Redemption.Mod, "SoulCandle", "SoulboundBuff");
            }

            //RUPTURE
            if (CrossModSupport.Rupture.Loaded)
            {
                AddBuffIntegration(CrossModSupport.Rupture.Mod, "TrinketRack", "SleightOfHandBuff");
            }

            //SECRETS OF THE SHADOWS
            if (CrossModSupport.SecretsOfTheShadows.Loaded)
            {
                AddBuffIntegration(CrossModSupport.SecretsOfTheShadows.Mod, "DigitalDisplay", "CyberneticEnhancements");
                AddBuffIntegration(CrossModSupport.SecretsOfTheShadows.Mod, "ElectromagneticDeterrent", "DEFEBuff");
            }

            //SHADOWS OF ABADDON
            if (CrossModSupport.ShadowsOfAbaddon.Loaded)
            {
                AddBuffIntegration(CrossModSupport.ShadowsOfAbaddon.Mod, "FruitLantern", "FruitBuff");
            }

            //SPIRIT CLASSIC
            if (CrossModSupport.SpiritClassic.Loaded)
            {
                AddBuffIntegration(CrossModSupport.SpiritClassic.Mod, "SunPot", "SunPotBuff");
                AddBuffIntegration(CrossModSupport.SpiritClassic.Mod, "CoilEnergizerItem", "OverDrive");
                AddBuffIntegration(CrossModSupport.SpiritClassic.Mod, "TheCouch", "CouchPotato");
                AddBuffIntegration(CrossModSupport.SpiritClassic.Mod, "KoiTotem", "KoiTotemBuff");
            }

            //SPIRIT REFORGED
            if (CrossModSupport.SpiritReforged.Loaded)
            {
                AddBuffIntegration(CrossModSupport.SpiritReforged.Mod, "AncientKoiTotem", "KoiTotemBuff");
                AddBuffIntegration(CrossModSupport.SpiritReforged.Mod, "KoiTotem", "KoiTotemBuff");
            }

            //THORIUM
            if (CrossModSupport.Thorium.Loaded)
            {
                AddBuffIntegration(CrossModSupport.Thorium.Mod, "Altar", "AltarBuff");
                AddBuffIntegration(CrossModSupport.Thorium.Mod, "ConductorsStand", "ConductorsStandBuff");
                AddBuffIntegration(CrossModSupport.Thorium.Mod, "Mistletoe", "MistletoeBuff");
                AddBuffIntegration(CrossModSupport.Thorium.Mod, "NinjaRack", "NinjaBuff");
            }
        }

        public static void AddBuffIntegration(Mod mod, string itemName, string buffName)
        {
            if (mod != null)
                ModdedPlaceableItemBuffs[Common.GetModItem(mod, itemName)] = Common.GetModBuff(mod, buffName);
        }

        public static void AddVanillaBuffIntegration(Mod mod, string itemName, int buffID)
        {
            if (mod != null)
                ModdedPlaceableItemBuffs[Common.GetModItem(mod, itemName)] = buffID;
        }
    }

    internal readonly struct ItemInfo(Item item)
    {
        public readonly int type = item.type;

        public readonly int buffType = item.buffType;

        public readonly int stack = item.stack;

        public readonly int createTile = item.createTile;

        public readonly int placeStyle = item.placeStyle;
    }
}
