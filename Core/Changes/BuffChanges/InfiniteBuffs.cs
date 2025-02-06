using QoLCompendium.Content.Items.Tools.Usables;
using ReLogic.Utilities;
using Terraria.DataStructures;

namespace QoLCompendium.Core.Changes.BuffChanges
{
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
                        Main.buffNoTimeDisplay[BuffID.MonsterBanner] = true;
                        Main.SceneMetrics.NPCBannerBuff[bItem] = true;
                        Main.SceneMetrics.hasBanner = true;
                    }
                }
            }
            if (item.type == ItemID.RedPotion && Main.getGoodWorld)
            {
                Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(item.type);
                for (int i = 0; i < AvailableRedPotionBuffs.Count; i++)
                {
                    if (!QoLCompendium.mainConfig.EndlessBuffsOnlyFromCrate)
                        Player.AddBuff(AvailableRedPotionBuffs[i], 2, true, false);
                }
            }
            if (item.type == ItemID.HoneyBucket || item.type == ItemID.BottomlessHoneyBucket)
            {
                Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(item.type);
                Player.AddBuff(BuffID.Honey, 2, true, false);
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
                    infoByItemType.Add(item.type, new List<ItemInfo>());
                }
                ItemInfo itemInfo = new ItemInfo(item);
                infoByItemType[item.type].Add(itemInfo);
                if (QoLCompendium.mainConfig.EndlessBuffAmount > 0 && item.stack >= QoLCompendium.mainConfig.EndlessBuffAmount)
                {
                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(item.type);
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
            if (ModConditions.calamityLoaded && info.buffType == Common.GetModBuff(ModConditions.calamityMod, "TeslaBuff") && !QoLCompendium.mainConfig.EndlessBuffsOnlyFromCrate)
            {
                Player.AddBuff(info.buffType, 10, true, false);
            }
            if (!QoLCompendium.mainConfig.EndlessBuffsOnlyFromCrate)
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
            List<int> nearbyEffects = new()
            {
                TileID.Campfire,
                TileID.Sunflower,
                //TileID.HangingLanterns,
                TileID.WaterCandle,
                TileID.PeaceCandle,
                TileID.ShadowCandle,
                TileID.CatBast
            };
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
                    return;
                case TileID.BewitchingTable:
                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(info.type);
                    Player.AddBuff(BuffID.Bewitched, 2, true, false);
                    return;
                case TileID.CrystalBall:
                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(info.type);
                    Player.AddBuff(BuffID.Clairvoyance, 2, true, false);
                    return;
                case TileID.SharpeningStation:
                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(info.type);
                    Player.AddBuff(BuffID.Sharpened, 2, true, false);
                    return;
                case TileID.SliceOfCake:
                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(info.type);
                    Player.AddBuff(BuffID.SugarRush, 2, true, false);
                    return;
                case TileID.WarTable:
                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(info.type);
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
                    Player.GetModPlayer<QoLCPlayer>().activeBuffItems.Add(info.type);
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
        }
    }

    public class BuffSystem : ModSystem
    {
        internal static Dictionary<int, int> ModdedPlaceableItemBuffs = new();

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
            AddBuffIntegration(ModConditions.classicalMod, "TrinketRack", "SleightOfHand");
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
