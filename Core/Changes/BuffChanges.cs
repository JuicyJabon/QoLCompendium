using QoLCompendium.Content.Items.Tools.Usables;
using ReLogic.Utilities;
using Terraria.DataStructures;

namespace QoLCompendium.Core.Changes
{
    public class SliceOfCakeIsInfinite : GlobalBuff
    {
        public bool defaultTimeLeft = BuffID.Sets.TimeLeftDoesNotDecrease[BuffID.SugarRush];
        public bool defaultTimeDisplay = Main.buffNoTimeDisplay[BuffID.SugarRush];
        public bool defaultNoSave = Main.buffNoSave[BuffID.SugarRush];

        public override void SetStaticDefaults()
        {
            if (QoLCompendium.mainServerConfig.InfiniteSliceOfCake)
            {
                BuffID.Sets.TimeLeftDoesNotDecrease[BuffID.SugarRush] = true;
                Main.buffNoTimeDisplay[BuffID.SugarRush] = true;
                Main.buffNoSave[BuffID.SugarRush] = true;
            }
            else
            {
                BuffID.Sets.TimeLeftDoesNotDecrease[BuffID.SugarRush] = defaultTimeLeft;
                Main.buffNoTimeDisplay[BuffID.SugarRush] = defaultTimeDisplay;
                Main.buffNoSave[BuffID.SugarRush] = defaultNoSave;
            }
        }
    }

    public class BuffItemTweaks : GlobalItem
    {
        public override bool ConsumeItem(Item item, Player player)
        {
            if (QoLCompendium.mainServerConfig.EndlessBuffs)
            {
                if (item.buffTime > 0 && item.stack >= QoLCompendium.mainServerConfig.EndlessBuffAmount)
                {
                    return false;
                }
                else if ((item.type == ItemID.RecallPotion || item.type == ItemID.TeleportationPotion || item.type == ItemID.WormholePotion || item.type == ItemID.PotionOfReturn || item.type == ItemID.GenderChangePotion || item.type == ItemID.RedPotion) && item.stack >= QoLCompendium.mainServerConfig.EndlessBuffAmount)
                {
                    return false;
                }
            }

            if (QoLCompendium.mainServerConfig.EndlessHealing)
            {
                if ((item.healLife > 0 || item.healMana > 0) && item.stack >= QoLCompendium.mainServerConfig.EndlessHealingAmount)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class BuffPlayer : ModPlayer
    {
        public bool hasLuckyLesser;

        public bool hasLucky;

        public bool hasLuckyGreater;

        public bool hasGardenGnome;

        public byte oldLuckPotion;

        public static readonly List<int> AvailableRedPotionBuffs = new() {
            BuffID.ObsidianSkin,
            BuffID.Regeneration,
            BuffID.Swiftness,
            BuffID.Ironskin,
            BuffID.ManaRegeneration,
            BuffID.MagicPower,
            BuffID.Featherfall,
            BuffID.Spelunker,
            BuffID.Archery,
            BuffID.Heartreach,
            BuffID.Hunter,
            BuffID.Endurance,
            BuffID.Lifeforce,
            BuffID.Inferno,
            BuffID.Mining,
            BuffID.Rage,
            BuffID.Wrath,
            BuffID.Dangersense
        };
        private readonly Dictionary<int, List<ItemInfo>> infoByItemType = new Dictionary<int, List<ItemInfo>>();

        private readonly HashSet<int> infiniteStackedItems = new HashSet<int>();

        public override void PreUpdateBuffs()
        {
            hasLuckyLesser = hasLucky = hasLuckyGreater = false;
            oldLuckPotion = Player.oldLuckPotion;
            infoByItemType.Clear();
            infiniteStackedItems.Clear();
            if (QoLCompendium.mainServerConfig.EndlessBuffs)
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
            int num = hasLuckyGreater ? 3 : hasLucky ? 2 : hasLuckyLesser ? 1 : 0;
            if (Player.whoAmI == Main.myPlayer && Player.luckPotion != num)
            {
                if (Player.luckPotion < num)
                {
                    Player.luckNeedsSync = true;
                    Player.luckPotion = (byte)num;
                }
            }
            else if (Player.luckNeedsSync)
            {
                Player.luckNeedsSync = false;
            }
            Player.oldLuckPotion = oldLuckPotion = Player.luckPotion;
        }

        public override void ModifyLuck(ref float luck)
        {
            if (hasGardenGnome)
            {
                luck += 0.2f;
            }
            hasGardenGnome = false;
        }

        public void CheckInventory(Item[] inventory)
        {
            infoByItemType.Clear();
            foreach (Item val in inventory)
            {
                if (!val.IsAir)
                {
                    CheckItemForInfiniteBuffs(val);
                }
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
                for (int i = 0; i < PotionCrate.BuffIDList.Count; i++)
                {
                    Player.AddBuff(PotionCrate.BuffIDList[i], 2, true, false);
                    if (PotionCrate.ItemIDList.Contains(ItemID.LuckPotionLesser))
                    {
                        hasLuckyLesser = true;
                    }
                    if (PotionCrate.ItemIDList.Contains(ItemID.LuckPotion))
                    {
                        hasLucky = true;
                    }
                    if (PotionCrate.ItemIDList.Contains(ItemID.LuckPotionGreater))
                    {
                        hasLuckyGreater = true;
                    }
                }
            }
            if (item.type == ModContent.ItemType<BannerBox>())
            {
                for (int i = 0; i < NPCLoader.NPCCount; i++)
                {
                    int bItem = ContentSamples.NpcsByNetId[i].BannerID();
                    if (NPC.killCount[i] >= ItemID.Sets.KillsToBanner[Item.BannerToItem(bItem)])
                    {
                        Player.HasNPCBannerBuff(bItem);
                        Player.AddBuff(BuffID.MonsterBanner, 2);
                        Main.buffNoTimeDisplay[BuffID.MonsterBanner] = true;
                        Main.SceneMetrics.NPCBannerBuff[bItem] = true;
                        Main.SceneMetrics.hasBanner = true;
                    }
                }
            }
            if (item.type == ItemID.RedPotion && Main.getGoodWorld)
            {
                for (int i = 0; i < AvailableRedPotionBuffs.Count; i++)
                {
                    if (!QoLCompendium.mainServerConfig.EndlessBuffsOnlyFromCrate)
                        Player.AddBuff(AvailableRedPotionBuffs[i], 2, true, false);
                }
            }
            if (item.type == ItemID.HoneyBucket || item.type == ItemID.BottomlessHoneyBucket)
            {
                Player.AddBuff(BuffID.Honey, 2, true, false);
            }
            if (item.type == ItemID.GardenGnome)
            {
                hasGardenGnome = true;
            }
        }

        private void CheckPotion(Item item)
        {
            if (CheckPotion_IsBuffPotion(item))
            {
                if (!infoByItemType.ContainsKey(item.type))
                {
                    infoByItemType.Add(item.type, new List<ItemInfo>());
                }
                ItemInfo itemInfo = new ItemInfo(item);
                infoByItemType[item.type].Add(itemInfo);
                if (QoLCompendium.mainServerConfig.EndlessBuffAmount > 0 && item.stack >= QoLCompendium.mainServerConfig.EndlessBuffAmount)
                {
                    infiniteStackedItems.Add(item.type);
                    CheckPotion_AddBuff(itemInfo);
                }
            }
        }

        private bool CheckPotion_IsBuffPotion(Item item)
        {
            if (item.healLife <= 0 && item.healMana <= 0 && item.buffType > 0)
            {
                return item.buffTime > 0;
            }
            return false;
        }

        private void CheckPotion_AddBuff(ItemInfo info)
        {
            if (ModConditions.calamityLoaded && info.buffType == Common.GetModBuff(ModConditions.calamityMod, "TeslaBuff") && !QoLCompendium.mainServerConfig.EndlessBuffsOnlyFromCrate)
            {
                Player.AddBuff(info.buffType, 10, true, false);
                Main.buffNoTimeDisplay[info.buffType] = true;
            }
            else
            {
                if (ModConditions.calamityLoaded)
                    Main.buffNoTimeDisplay[Common.GetModBuff(ModConditions.calamityMod, "TeslaBuff")] = false;
            }
            if (!QoLCompendium.mainServerConfig.EndlessBuffsOnlyFromCrate)
            {
                Player.AddBuff(info.buffType, 2, true, false);
            }
            if (info.type == ItemID.LuckPotionLesser)
            {
                hasLuckyLesser = true;
            }
            else if (info.type == ItemID.LuckPotion)
            {
                hasLucky = true;
            }
            else if (info.type == ItemID.LuckPotionGreater)
            {
                hasLuckyGreater = true;
            }
        }

        private void CheckEnvironment(Item item)
        {
            if (CheckEnvironment_ItemIsValidPlaceableTile(item))
            {
                if (!infoByItemType.ContainsKey(item.type))
                {
                    infoByItemType.Add(item.type, new List<ItemInfo>());
                }
                ItemInfo itemInfo = new ItemInfo(item);
                infoByItemType[item.type].Add(itemInfo);
                int stackTarget = GetStackTarget(item, QoLCompendium.mainServerConfig.EndlessStationAmount);
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
                    CheckEnvironment_Campfire();
                    break;
                case TileID.Sunflower:
                    CheckEnvironment_Sunflower();
                    break;
                case TileID.HangingLanterns:
                    if (info.placeStyle == 9)
                    {
                        CheckEnvironment_HeartLantern();
                    }
                    else if (info.placeStyle == 7)
                    {
                        CheckEnvironment_StarInABottle();
                    }
                    break;
                case TileID.WaterCandle:
                    CheckEnvironment_WaterCandle(info.stack);
                    break;
                case TileID.PeaceCandle:
                    CheckEnvironment_PeaceCandle(info.stack);
                    break;
                case TileID.ShadowCandle:
                    CheckEnvironment_ShadowCandle(info.stack);
                    break;
                case TileID.CatBast:
                    CheckEnvironment_CatBast();
                    break;
            }
            Point16 val = Player.Center.ToTileCoordinates16();
            TileLoader.NearbyEffects(val.X, val.Y, info.createTile, false);
        }

        private static int GetStackTarget(Item item, int defaultStackConfig)
        {
            if (item.IsAir)
            {
                return defaultStackConfig;
            }
            if (item.type == ItemID.BottledHoney)
            {
                return QoLCompendium.mainServerConfig.EndlessBuffAmount;
            }
            switch (item.createTile)
            {
                case TileID.Campfire:
                    return QoLCompendium.mainServerConfig.EndlessStationAmount;
                case TileID.Sunflower:
                    return QoLCompendium.mainServerConfig.EndlessStationAmount;
                case TileID.HangingLanterns:
                    if (item.placeStyle == 9)
                    {
                        return QoLCompendium.mainServerConfig.EndlessStationAmount;
                    }
                    if (item.placeStyle == 7)
                    {
                        return QoLCompendium.mainServerConfig.EndlessStationAmount;
                    }
                    break;
                case TileID.WaterCandle:
                    return QoLCompendium.mainServerConfig.EndlessStationAmount;
                case TileID.PeaceCandle:
                    return QoLCompendium.mainServerConfig.EndlessStationAmount;
                case TileID.ShadowCandle:
                    return QoLCompendium.mainServerConfig.EndlessStationAmount;
                case TileID.CatBast:
                    return QoLCompendium.mainServerConfig.EndlessStationAmount;
                case TileID.AmmoBox:
                    return QoLCompendium.mainServerConfig.EndlessStationAmount;
                case TileID.BewitchingTable:
                    return QoLCompendium.mainServerConfig.EndlessStationAmount;
                case TileID.CrystalBall:
                    return QoLCompendium.mainServerConfig.EndlessStationAmount;
                case TileID.SharpeningStation:
                    return QoLCompendium.mainServerConfig.EndlessStationAmount;
                case TileID.WarTable:
                    return QoLCompendium.mainServerConfig.EndlessStationAmount;
                case TileID.SliceOfCake:
                    return QoLCompendium.mainServerConfig.EndlessStationAmount;
            }
            return defaultStackConfig;
        }

        private static bool CheckEnvironment_ItemIsValidPlaceableTile(Item item)
        {
            if (item.createTile >= TileID.Dirt && item.type != ItemID.DirtBlock)
            {
                return Main.tileFrameImportant[item.createTile];
            }
            return false;
        }

        private void CheckEnvironment_Campfire()
        {
            Main.SceneMetrics.HasCampfire = true;
            Player.AddBuff(BuffID.Campfire, 2, false, false);
        }

        private void CheckEnvironment_Sunflower()
        {
            if (Main.SceneMetrics.GraveyardTileCount <= SceneMetrics.GraveyardTileMin)
            {
                Main.SceneMetrics.HasSunflower = true;
                Player.AddBuff(BuffID.Sunflower, 2, false, false);
            }
        }

        private void CheckEnvironment_HeartLantern()
        {
            Main.SceneMetrics.HasHeartLantern = true;
            Player.AddBuff(BuffID.HeartLamp, 2, false, false);
        }

        private void CheckEnvironment_StarInABottle()
        {
            Main.SceneMetrics.HasStarInBottle = true;
            Player.AddBuff(BuffID.StarInBottle, 2, false, false);
        }

        private void CheckEnvironment_WaterCandle(int count)
        {
            SceneMetrics sceneMetrics = Main.SceneMetrics;
            sceneMetrics.WaterCandleCount += count;
            Player.AddBuff(BuffID.WaterCandle, 2, false, false);
            Player.ZoneWaterCandle = true;
        }

        private void CheckEnvironment_PeaceCandle(int count)
        {
            SceneMetrics sceneMetrics = Main.SceneMetrics;
            sceneMetrics.PeaceCandleCount += count;
            Player.AddBuff(BuffID.PeaceCandle, 2, false, false);
            Player.ZonePeaceCandle = true;
        }

        private void CheckEnvironment_ShadowCandle(int count)
        {
            SceneMetrics sceneMetrics = Main.SceneMetrics;
            sceneMetrics.ShadowCandleCount += count;
            Player.AddBuff(BuffID.ShadowCandle, 2, false, false);
            Player.ZoneShadowCandle = true;
        }

        private void CheckEnvironment_CatBast()
        {
            Main.SceneMetrics.HasCatBast = true;
            Player.AddBuff(BuffID.CatBast, 2, false, false);
        }

        private void CheckStation(Item item)
        {
            if (CheckEnvironment_ItemIsValidPlaceableTile(item))
            {
                if (!infoByItemType.ContainsKey(item.type))
                {
                    infoByItemType.Add(item.type, new List<ItemInfo>());
                }
                ItemInfo itemInfo = new ItemInfo(item);
                infoByItemType[item.type].Add(itemInfo);
                int stackTarget = GetStackTarget(item, QoLCompendium.mainServerConfig.EndlessStationAmount);
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
                    Player.AddBuff(BuffID.AmmoBox, 2, true, false);
                    return;
                case TileID.BewitchingTable:
                    Player.AddBuff(BuffID.Bewitched, 2, true, false);
                    return;
                case TileID.CrystalBall:
                    Player.AddBuff(BuffID.Clairvoyance, 2, true, false);
                    return;
                case TileID.SharpeningStation:
                    Player.AddBuff(BuffID.Sharpened, 2, true, false);
                    return;
                case TileID.SliceOfCake:
                    Player.AddBuff(BuffID.SugarRush, 2, true, false);
                    return;
                case TileID.WarTable:
                    Player.AddBuff(BuffID.WarTable, 2, true, false);
                    return;
            }
            /*
            BlockSounds.DontCreateSound = true;
            Point16 val = Player.Center.ToTileCoordinates16();
            ModTile tile = TileLoader.GetTile(info.createTile);
            if (tile != null && ModdedStationSupport.multitileAddsBuffsOnRightClick.Contains(info.createTile))
            {
                tile.RightClick(val.X, val.Y);
            }
            BlockSounds.DontCreateSound = false;
            */
            foreach (var moddedBuff in BuffSystem.ModdedPlaceableItemBuffs)
            {
                if (info.type == moddedBuff.Key)
                {
                    Player.AddBuff(moddedBuff.Value, 2);
                }
            }
        }

        private void CheckHoney(Item item)
        {
            if (item.type == ItemID.BottledHoney)
            {
                if (!infoByItemType.ContainsKey(item.type))
                {
                    infoByItemType.Add(item.type, new List<ItemInfo>());
                }
                ItemInfo item2 = new ItemInfo(item);
                infoByItemType[item.type].Add(item2);
                if (QoLCompendium.mainServerConfig.EndlessBuffAmount > 0 && item.stack >= QoLCompendium.mainServerConfig.EndlessBuffAmount)
                {
                    infiniteStackedItems.Add(item.type);
                    CheckHoney_AddBuff();
                }
            }
        }

        private void CheckHoney_AddBuff()
        {
            Player.AddBuff(BuffID.Honey, 2, true, false);
        }
    }

    public class BuffSystem : ModSystem
    {
        internal static Dictionary<int, int> ModdedPlaceableItemBuffs = new();

        public static void DoBuffIntegration()
        {
            //BLOCKS THROWER
            AddBuffIntegration(ModConditions.blocksThrowerMod, "ThrowingBoard", "DeadlyPrecision", true);
            //CALAMITY
            AddBuffIntegration(ModConditions.calamityMod, "WeightlessCandle", "CirrusBlueCandleBuff", true);
            AddBuffIntegration(ModConditions.calamityMod, "VigorousCandle", "CirrusPinkCandleBuff", true);
            AddBuffIntegration(ModConditions.calamityMod, "SpitefulCandle", "CirrusYellowCandleBuff", true);
            AddBuffIntegration(ModConditions.calamityMod, "ResilientCandle", "CirrusPurpleCandleBuff", true);
            AddBuffIntegration(ModConditions.calamityMod, "ChaosCandle", "ChaosCandleBuff", true);
            AddBuffIntegration(ModConditions.calamityMod, "TranquilityCandle", "TranquilityCandleBuff", true);
            AddBuffIntegration(ModConditions.calamityMod, "EffigyOfDecay", "EffigyOfDecayBuff", true);
            AddBuffIntegration(ModConditions.calamityMod, "CrimsonEffigy", "CrimsonEffigyBuff", true);
            AddBuffIntegration(ModConditions.calamityMod, "CorruptionEffigy", "CorruptionEffigyBuff", true);
            //CALAMITY COMMUNITY REMIX
            AddBuffIntegration(ModConditions.calamityCommunityRemixMod, "AstralEffigy", "AstralEffigyBuff", true);
            AddBuffIntegration(ModConditions.calamityCommunityRemixMod, "HallowEffigy", "HallowEffigyBuff", true);
            //CLICKER CLASS
            AddBuffIntegration(ModConditions.clickerClassMod, "DesktopComputer", "DesktopComputerBuff", true);
            //CLASSICAL
            AddBuffIntegration(ModConditions.classicalMod, "TrinketRack", "SleightOfHand", true);
            //FARGOS
            AddBuffIntegration(ModConditions.fargosMutantMod, "Semistation", "Semistation", true);
            AddBuffIntegration(ModConditions.fargosMutantMod, "Omnistation", "Omnistation", true);
            AddBuffIntegration(ModConditions.fargosMutantMod, "Omnistation2", "Omnistation", true);
            //HOMEWARD JOURNEY
            AddBuffIntegration(ModConditions.homewardJourneyMod, "BushOfLife", "BushOfLifeBuff", true);
            AddBuffIntegration(ModConditions.homewardJourneyMod, "LifeLantern", "LifeLanternBuff", true);
            //REDEMPTION
            AddBuffIntegration(ModConditions.redemptionMod, "EnergyStation", "EnergyStationBuff", true);
            //SECRETS OF THE SHADOWS
            AddBuffIntegration(ModConditions.secretsOfTheShadowsMod, "DigitalDisplay", "CyberneticEnhancements", true);
            //SHADOWS OF ABADDON
            AddBuffIntegration(ModConditions.shadowsOfAbaddonMod, "FruitLantern", "FruitBuff", true);
            //SPIRIT
            AddBuffIntegration(ModConditions.spiritMod, "SunPot", "SunPotBuff", true);
            AddBuffIntegration(ModConditions.spiritMod, "CoilEnergizerItem", "OverDrive", true);
            AddBuffIntegration(ModConditions.spiritMod, "TheCouch", "CouchPotato", true);
            //THORIUM
            AddBuffIntegration(ModConditions.thoriumMod, "Altar", "AltarBuff", true);
            AddBuffIntegration(ModConditions.thoriumMod, "ConductorsStand", "ConductorsStandBuff", true);
            AddBuffIntegration(ModConditions.thoriumMod, "Mistletoe", "MistletoeBuff", true);
            AddBuffIntegration(ModConditions.thoriumMod, "NinjaRack", "NinjaBuff", true);
        }

        public static void AddBuffIntegration(Mod mod, string itemName, string buffName, bool isPlaceable)
        {
            if (isPlaceable)
                ModdedPlaceableItemBuffs[Common.GetModItem(mod, itemName)] = Common.GetModBuff(mod, buffName);
        }
    }

    public class BuffItem : GlobalItem
    {
        public static bool IsBuffTileItem(Item item, out int buffType)
        {
            foreach (var moddedBuff in BuffSystem.ModdedPlaceableItemBuffs)
            {
                if (item.type == moddedBuff.Key)
                {
                    buffType = moddedBuff.Value;
                    return true;
                }
            }
            buffType = -1;
            return false;
        }
    }

    internal struct ItemInfo
    {
        public readonly int type;

        public readonly int buffType;

        public readonly int stack;

        public readonly int createTile;

        public readonly int placeStyle;

        public ItemInfo(Item item)
        {
            type = item.type;
            buffType = item.buffType;
            stack = item.stack;
            createTile = item.createTile;
            placeStyle = item.placeStyle;
        }
    }

    public class BlockSounds : ModSystem
    {
        internal static bool DontCreateSound;

        public override void Load()
        {
            On_SoundEngine.PlaySound_refSoundStyle_Nullable1_SoundUpdateCallback += new On_SoundEngine.hook_PlaySound_refSoundStyle_Nullable1_SoundUpdateCallback(Hook_SoundEngine_PlaySound_refSoundStyle_Nullable1);
        }

        private SlotId Hook_SoundEngine_PlaySound_refSoundStyle_Nullable1(On_SoundEngine.orig_PlaySound_refSoundStyle_Nullable1_SoundUpdateCallback orig, ref SoundStyle style, Vector2? position, SoundUpdateCallback updateCallback)
        {
            if (!DontCreateSound)
            {
                return orig.Invoke(ref style, position, updateCallback);
            }
            return SlotId.Invalid;
        }
    }
}
