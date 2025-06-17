using QoLCompendium.Content.Items.Tools.Usables;
using Redemption.Globals;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using tModPorter;

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

        public override void PreUpdateBuffs()
        {
            hasLuckyLesser = hasLucky = hasLuckyGreater = false;
            oldLuckPotion = Player.oldLuckPotion;
            infoByItemType.Clear();
            infiniteStackedItems.Clear();
            if (QoLCompendium.mainConfig.EndlessBuffs)
            {
                CheckInventory(Player.inventory);
                CheckInventory(Player.bank.item);
                CheckInventory(Player.bank2.item);
                CheckInventory(Player.bank3.item);
                CheckInventory(Player.bank4.item);
            }
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
            if (item.type == ModContent.ItemType<PotionCrate>())
            {
                Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(item.type);
                for (int i = 0; i < PotionCrate.BuffIDList.Count; i++)
                {
                    Player.AddBuff(PotionCrate.BuffIDList[i], 2, true, false);
                    Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(PotionCrate.BuffIDList[i]);
                    if (PotionCrate.ItemIDList.Contains(ItemID.LuckPotionLesser))
                        hasLuckyLesser = true;
                    if (PotionCrate.ItemIDList.Contains(ItemID.LuckPotion))
                        hasLucky = true;
                    if (PotionCrate.ItemIDList.Contains(ItemID.LuckPotionGreater))
                        hasLuckyGreater = true;
                }
            }
            if (item.type == ModContent.ItemType<BannerBox>())
            {
                Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(item.type);
                for (int i = 0; i < NPCLoader.NPCCount; i++)
                {
                    int bItem = ContentSamples.NpcsByNetId[i].BannerID();
                    if (NPC.killCount[i] >= ItemID.Sets.KillsToBanner[Item.BannerToItem(bItem)])
                    {
                        Player.HasNPCBannerBuff(bItem);
                        Player.AddBuff(BuffID.MonsterBanner, 2);
                        Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.MonsterBanner);
                        Main.buffNoTimeDisplay[BuffID.MonsterBanner] = true;
                        Main.SceneMetrics.NPCBannerBuff[bItem] = true;
                        Main.SceneMetrics.hasBanner = true;
                    }
                }
            }
            if (item.type == ItemID.RedPotion && Main.getGoodWorld)
            {
                Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(item.type);
                for (int i = 0; i < Common.RedPotionBuffs.Count; i++)
                {
                    if (!QoLCompendium.mainConfig.EndlessBuffsOnlyFromCrate)
                    {
                        Player.AddBuff(Common.RedPotionBuffs.ElementAt(i), 2, true, false);
                        Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(Common.RedPotionBuffs.ElementAt(i));
                    }
                }
            }
            if (item.type == ItemID.HoneyBucket || item.type == ItemID.BottomlessHoneyBucket)
            {
                Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(item.type);
                Player.AddBuff(BuffID.Honey, 2, true, false);
                Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.Honey);
            }
            if (item.type == ItemID.GardenGnome)
            {
                Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(item.type);
                hasGardenGnome = true;
            }
        }

        private void CheckPotion(Item item)
        {
            if (CheckPotion_IsBuffPotion(item))
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
            if (!QoLCompendium.mainConfig.EndlessBuffsOnlyFromCrate && !Player.buffImmune[info.buffType])
            {
                if (ModConditions.calamityLoaded && info.buffType == Common.GetModBuff(ModConditions.calamityMod, "TeslaBuff"))
                    Player.AddBuff(info.buffType, 10, true, false);
                else
                    Player.AddBuff(info.buffType, 2, true, false);
                Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(info.buffType);
            }

            if (info.type == ItemID.LuckPotionLesser)
                hasLuckyLesser = true;
            else if (info.type == ItemID.LuckPotion)
                hasLucky = true;
            else if (info.type == ItemID.LuckPotionGreater)
                hasLuckyGreater = true;
        }

        private void CheckEnvironment(Item item)
        {
            if (CheckEnvironment_ItemIsValidPlaceableTile(item))
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
            Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.Campfire);
        }

        private void CheckEnvironment_Sunflower()
        {
            if (Main.SceneMetrics.GraveyardTileCount <= SceneMetrics.GraveyardTileMin)
            {
                Main.SceneMetrics.HasSunflower = true;
                Player.AddBuff(BuffID.Sunflower, 2, false, false);
                Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.Sunflower);
            }
        }

        private void CheckEnvironment_HeartLantern()
        {
            Main.SceneMetrics.HasHeartLantern = true;
            Player.AddBuff(BuffID.HeartLamp, 2, false, false);
            Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.HeartLamp);
        }

        private void CheckEnvironment_StarInABottle()
        {
            Main.SceneMetrics.HasStarInBottle = true;
            Player.AddBuff(BuffID.StarInBottle, 2, false, false);
            Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.StarInBottle);
        }

        private void CheckEnvironment_WaterCandle(int count)
        {
            Main.SceneMetrics.WaterCandleCount += count;
            Player.AddBuff(BuffID.WaterCandle, 2, false, false);
            Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.WaterCandle);
            Player.ZoneWaterCandle = true;
        }

        private void CheckEnvironment_PeaceCandle(int count)
        {
            Main.SceneMetrics.PeaceCandleCount += count;
            Player.AddBuff(BuffID.PeaceCandle, 2, false, false);
            Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.PeaceCandle);
            Player.ZonePeaceCandle = true;
        }

        private void CheckEnvironment_ShadowCandle(int count)
        {
            Main.SceneMetrics.ShadowCandleCount += count;
            Player.AddBuff(BuffID.ShadowCandle, 2, false, false);
            Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.ShadowCandle);
            Player.ZoneShadowCandle = true;
        }

        private void CheckEnvironment_CatBast()
        {
            Main.SceneMetrics.HasCatBast = true;
            Player.AddBuff(BuffID.CatBast, 2, false, false);
            Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.CatBast);
        }

        private void CheckStation(Item item)
        {
            if (CheckEnvironment_ItemIsValidPlaceableTile(item))
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
                    Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.AmmoBox);
                    return;
                case TileID.BewitchingTable:
                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(info.type);
                    Player.AddBuff(BuffID.Bewitched, 2, true, false);
                    Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.Bewitched);
                    return;
                case TileID.CrystalBall:
                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(info.type);
                    Player.AddBuff(BuffID.Clairvoyance, 2, true, false);
                    Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.Clairvoyance);
                    return;
                case TileID.SharpeningStation:
                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(info.type);
                    Player.AddBuff(BuffID.Sharpened, 2, true, false);
                    Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.Sharpened);
                    return;
                case TileID.SliceOfCake:
                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(info.type);
                    Player.AddBuff(BuffID.SugarRush, 2, true, false);
                    Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.SugarRush);
                    return;
                case TileID.WarTable:
                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(info.type);
                    Player.AddBuff(BuffID.WarTable, 2, true, false);
                    Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.WarTable);
                    return;
            }
            foreach (var moddedBuff in BuffSystem.ModdedPlaceableItemBuffs)
            {
                Item electroDeterrent = new();
                if (ModConditions.secretsOfTheShadowsLoaded)
                    electroDeterrent.type = Common.GetModItem(ModConditions.secretsOfTheShadowsMod, "ElectromagneticDeterrent");

                if (info.type == moddedBuff.Key)
                {
                    if (ModConditions.secretsOfTheShadowsLoaded && info.type == electroDeterrent.type && Player.HasItem(electroDeterrent.type) && !Player.inventory[Common.GetSlotItemIsIn(electroDeterrent, Player.inventory)].favorited)
                        return;

                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(info.type);
                    Player.AddBuff(moddedBuff.Value, 2);
                    Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(moddedBuff.Value);
                }
            }
        }

        private void CheckHoney(Item item)
        {
            if (item.type == ItemID.BottledHoney)
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
            Player.GetModPlayer<QoLCPlayer>().activeBuffs.Add(BuffID.Honey);
        }
    }

    public class BuffSystem : ModSystem
    {
        public static bool[] BuffTypesToHide = new bool[BuffLoader.BuffCount];
        internal static Dictionary<int, int> ModdedPlaceableItemBuffs = [];

        public override void PostSetupContent()
        {
            Array.Resize(ref BuffTypesToHide, BuffLoader.BuffCount);
        }

        public override void PostDrawInterface(SpriteBatch spriteBatch)
        {
            Array.Clear(BuffTypesToHide, 0, BuffTypesToHide.Length);
            SetupHideArray();
        }


        private static void SetupHideArray()
        {
            foreach (int buff in Main.LocalPlayer.GetModPlayer<QoLCPlayer>().activeBuffs)
            {
                BuffTypesToHide[buff] = true;
            }
        }

        public static void DoBuffIntegration()
        {
            //AFKPETS
            AddBuffIntegration(ModConditions.afkpetsMod, "ChaosAmplifier", "ChaosAmplifier");
            AddBuffIntegration(ModConditions.afkpetsMod, "PortableRocketLauncher", "Dispenser");
            AddVanillaBuffIntegration(ModConditions.afkpetsMod, "DruidicArtifact", BuffID.DryadsWard);
            AddBuffIntegration(ModConditions.afkpetsMod, "EchoFlower", "EchoFlower");
            AddBuffIntegration(ModConditions.afkpetsMod, "FallenSoulContainer", "FallenSoul");
            AddBuffIntegration(ModConditions.afkpetsMod, "SacrificialAltar", "SacrificialAltar");
            //BLOCKS THROWER
            AddBuffIntegration(ModConditions.blocksThrowerMod, "ThrowingBoard", "DeadlyPrecision");
            //CALAMITY
            AddBuffIntegration(ModConditions.calamityMod, "WeightlessCandle", "CirrusBlueCandleBuff");
            AddBuffIntegration(ModConditions.calamityMod, "VigorousCandle", "CirrusPinkCandleBuff");
            AddBuffIntegration(ModConditions.calamityMod, "SpitefulCandle", "CirrusYellowCandleBuff");
            AddBuffIntegration(ModConditions.calamityMod, "ResilientCandle", "CirrusPurpleCandleBuff");
            AddBuffIntegration(ModConditions.calamityMod, "ChaosCandle", "ChaosCandleBuff");
            AddBuffIntegration(ModConditions.calamityMod, "TranquilityCandle", "TranquilityCandleBuff");
            AddBuffIntegration(ModConditions.calamityMod, "EffigyOfDecay", "EffigyOfDecayBuff");
            AddBuffIntegration(ModConditions.calamityMod, "CrimsonEffigy", "CrimsonEffigyBuff");
            AddBuffIntegration(ModConditions.calamityMod, "CorruptionEffigy", "CorruptionEffigyBuff");
            //CALAMITY COMMUNITY REMIX
            AddBuffIntegration(ModConditions.calamityCommunityRemixMod, "AstralEffigy", "AstralEffigyBuff");
            AddBuffIntegration(ModConditions.calamityCommunityRemixMod, "HallowEffigy", "HallowEffigyBuff");
            //CALAMITY ENTROPY
            AddBuffIntegration(ModConditions.calamityEntropyMod, "VoidCandle", "VoidCandleBuff");
            //CAPTURE DISCS CLASS
            AddBuffIntegration(ModConditions.captureDiscsClassMod, "DiscCharger", "ChargedDisc");
            //CLICKER CLASS
            AddBuffIntegration(ModConditions.clickerClassMod, "DesktopComputer", "DesktopComputerBuff");
            //CLASSICAL
            AddBuffIntegration(ModConditions.ruptureMod, "TrinketRack", "SleightOfHand");
            //FARGOS
            AddBuffIntegration(ModConditions.fargosMutantMod, "Semistation", "Semistation");
            AddBuffIntegration(ModConditions.fargosMutantMod, "Omnistation", "Omnistation");
            AddBuffIntegration(ModConditions.fargosMutantMod, "Omnistation2", "Omnistation");
            //HOMEWARD JOURNEY
            AddBuffIntegration(ModConditions.homewardJourneyMod, "BushOfLife", "BushOfLifeBuff");
            AddBuffIntegration(ModConditions.homewardJourneyMod, "LifeLantern", "LifeLanternBuff");
            //MARTAIN'S ORDER
            AddBuffIntegration(ModConditions.martainsOrderMod, "ArcheologyTable", "ReschBuff");
            AddBuffIntegration(ModConditions.martainsOrderMod, "SporeFarm", "SporeSave");
            //REDEMPTION
            AddBuffIntegration(ModConditions.redemptionMod, "EnergyStation", "EnergyStationBuff");
            //SECRETS OF THE SHADOWS
            AddBuffIntegration(ModConditions.secretsOfTheShadowsMod, "DigitalDisplay", "CyberneticEnhancements");
            AddBuffIntegration(ModConditions.secretsOfTheShadowsMod, "ElectromagneticDeterrent", "DEFEBuff");
            //SHADOWS OF ABADDON
            AddBuffIntegration(ModConditions.shadowsOfAbaddonMod, "FruitLantern", "FruitBuff");
            //SPIRIT
            AddBuffIntegration(ModConditions.spiritMod, "SunPot", "SunPotBuff");
            AddBuffIntegration(ModConditions.spiritMod, "CoilEnergizerItem", "OverDrive");
            AddBuffIntegration(ModConditions.spiritMod, "TheCouch", "CouchPotato");
            AddBuffIntegration(ModConditions.spiritMod, "KoiTotem", "KoiTotemBuff");
            //THORIUM
            AddBuffIntegration(ModConditions.thoriumMod, "Altar", "AltarBuff");
            AddBuffIntegration(ModConditions.thoriumMod, "ConductorsStand", "ConductorsStandBuff");
            AddBuffIntegration(ModConditions.thoriumMod, "Mistletoe", "MistletoeBuff");
            AddBuffIntegration(ModConditions.thoriumMod, "NinjaRack", "NinjaBuff");
        }

        public static void AddBuffIntegration(Mod mod, string itemName, string buffName)
        {
            ModdedPlaceableItemBuffs[Common.GetModItem(mod, itemName)] = Common.GetModBuff(mod, buffName);
        }

        public static void AddVanillaBuffIntegration(Mod mod, string itemName, int buffID)
        {
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
