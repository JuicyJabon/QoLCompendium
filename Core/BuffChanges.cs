using QoLCompendium.Content.Items.Tools.Usables;
using ReLogic.Utilities;
using System;
using Terraria.DataStructures;

namespace QoLCompendium.Core
{
    public class SliceOfCakeIsInfinite : GlobalBuff
    {
        public override void SetStaticDefaults()
        {
            if (QoLCompendium.mainConfig.InfiniteSliceOfCake)
            {
                BuffID.Sets.TimeLeftDoesNotDecrease[BuffID.SugarRush] = true;
                Main.buffNoTimeDisplay[BuffID.SugarRush] = true;
                Main.buffNoSave[BuffID.SugarRush] = true;
            }
        }
    }

    public class BuffItemTweaks : GlobalItem
    {
        public override bool ConsumeItem(Item item, Player player)
        {
            if (QoLCompendium.mainConfig.EndlessBuffs)
            {
                if (item.buffTime > 0 && item.stack >= QoLCompendium.mainConfig.EndlessBuffAmount)
                {
                    return false;
                }
                else if ((item.type == ItemID.RecallPotion || item.type == ItemID.TeleportationPotion || item.type == ItemID.WormholePotion || item.type == ItemID.PotionOfReturn || item.type == ItemID.GenderChangePotion || item.type == ItemID.RedPotion) && item.stack >= QoLCompendium.mainConfig.EndlessBuffAmount)
                {
                    return false;
                }
            }

            if (QoLCompendium.mainConfig.EndlessHealing)
            {
                if ((item.healLife > 0 || item.healMana > 0) && item.stack >= QoLCompendium.mainConfig.EndlessHealingAmount)
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
            hasLuckyLesser = (hasLucky = (hasLuckyGreater = false));
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
            int num = (hasLuckyGreater ? 3 : (hasLucky ? 2 : (hasLuckyLesser ? 1 : 0)));
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
            Player.oldLuckPotion = (oldLuckPotion = Player.luckPotion);
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
                        Main.LocalPlayer.HasNPCBannerBuff(bItem);
                        Main.LocalPlayer.AddBuff(BuffID.MonsterBanner, 2);
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
                    if (!QoLCompendium.mainConfig.EndlessBuffsOnlyFromCrate)
                        Player.AddBuff(AvailableRedPotionBuffs[i], 2, true, false);
                }
            }
            if (item.type == ItemID.HoneyBucket)
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
                if (QoLCompendium.mainConfig.EndlessBuffAmount > 0 && item.stack >= QoLCompendium.mainConfig.EndlessBuffAmount)
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
            
            if (info.buffType == Common.GetModBuff(ModConditions.calamityMod, "TeslaBuff") && !QoLCompendium.mainConfig.EndlessBuffsOnlyFromCrate)
            {
                Player.AddBuff(info.buffType, 10, true, false);
                Main.buffNoTimeDisplay[info.buffType] = true;
            }
            else
            {
                if (!QoLCompendium.mainConfig.EndlessBuffsOnlyFromCrate)
                {
                    Player.AddBuff(info.buffType, 2, true, false);
                }
            }
            if (info.type == 4477)
            {
                hasLuckyLesser = true;
            }
            else if (info.type == 4478)
            {
                hasLucky = true;
            }
            else if (info.type == 4479)
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
                int stackTarget = GetStackTarget(item, 1);
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
                case 215:
                    CheckEnvironment_Campfire();
                    break;
                case 27:
                    CheckEnvironment_Sunflower();
                    break;
                case 42:
                    if (info.placeStyle == 9)
                    {
                        CheckEnvironment_HeartLantern();
                    }
                    else if (info.placeStyle == 7)
                    {
                        CheckEnvironment_StarInABottle();
                    }
                    break;
                case 49:
                    CheckEnvironment_WaterCandle(info.stack);
                    break;
                case 372:
                    CheckEnvironment_PeaceCandle(info.stack);
                    break;
                case 506:
                    CheckEnvironment_CatBast();
                    break;
            }
            Point16 val = Utils.ToTileCoordinates16(Player.Center);
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
                return QoLCompendium.mainConfig.EndlessBuffAmount;
            }
            switch (item.createTile)
            {
                case 215:
                    return 1;
                case 27:
                    return 1;
                case 42:
                    if (item.placeStyle == 9)
                    {
                        return 1;
                    }
                    if (item.placeStyle == 7)
                    {
                        return 1;
                    }
                    break;
                case 49:
                    return 1;
                case 372:
                    return 1;
                case 506:
                    return 1;
                case 287:
                    return 1;
                case 354:
                    return 1;
                case 125:
                    return 1;
                case 377:
                    return 1;
                case 621:
                    return 1;
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
            Player.AddBuff(87, 2, false, false);
        }

        private void CheckEnvironment_Sunflower()
        {
            if (Main.SceneMetrics.GraveyardTileCount <= SceneMetrics.GraveyardTileMin)
            {
                Main.SceneMetrics.HasSunflower = true;
                Player.AddBuff(146, 2, false, false);
            }
        }

        private void CheckEnvironment_HeartLantern()
        {
            Main.SceneMetrics.HasHeartLantern = true;
            Player.AddBuff(89, 2, false, false);
        }

        private void CheckEnvironment_StarInABottle()
        {
            Main.SceneMetrics.HasStarInBottle = true;
            Player.AddBuff(158, 2, false, false);
        }

        private void CheckEnvironment_WaterCandle(int count)
        {
            SceneMetrics sceneMetrics = Main.SceneMetrics;
            sceneMetrics.WaterCandleCount += count;
            Player.AddBuff(86, 2, false, false);
            Player.ZoneWaterCandle = true;
        }

        private void CheckEnvironment_PeaceCandle(int count)
        {
            SceneMetrics sceneMetrics = Main.SceneMetrics;
            sceneMetrics.PeaceCandleCount += count;
            Player.AddBuff(157, 2, false, false);
            Player.ZonePeaceCandle = true;
        }

        private void CheckEnvironment_CatBast()
        {
            Main.SceneMetrics.HasCatBast = true;
            Player.AddBuff(215, 2, false, false);
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
                int stackTarget = GetStackTarget(item, 1);
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
                case 287:
                    Player.AddBuff(93, 2, true, false);
                    return;
                case 354:
                    Player.AddBuff(150, 2, true, false);
                    return;
                case 125:
                    Player.AddBuff(29, 2, true, false);
                    return;
                case 377:
                    Player.AddBuff(159, 2, true, false);
                    return;
                case 621:
                    Player.AddBuff(192, 2, true, false);
                    return;
            }
            BlockSounds.DontCreateSound = true;
            Point16 val = Utils.ToTileCoordinates16(Player.Center);
            ModTile tile = TileLoader.GetTile(info.createTile);
            if (tile != null && ModdedStationSupport.multitileAddsBuffsOnRightClick.Contains(info.createTile))
            {
                tile.RightClick(val.X, val.Y);
            }
            BlockSounds.DontCreateSound = false;

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
                if (QoLCompendium.mainConfig.EndlessBuffAmount > 0 && item.stack >= QoLCompendium.mainConfig.EndlessBuffAmount)
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

        public static void DoCalamityModIntegration()
        {
            if (!ModConditions.calamityLoaded)
            {
                return;
            }

            AddBuffIntegration(ModConditions.calamityMod, "WeightlessCandle", "CirrusBlueCandleBuff", true);
            AddBuffIntegration(ModConditions.calamityMod, "VigorousCandle", "CirrusPinkCandleBuff", true);
            AddBuffIntegration(ModConditions.calamityMod, "SpitefulCandle", "CirrusYellowCandleBuff", true);
            AddBuffIntegration(ModConditions.calamityMod, "ResilientCandle", "CirrusPurpleCandleBuff", true);
            AddBuffIntegration(ModConditions.calamityMod, "ChaosCandle", "ChaosCandleBuff", true);
            AddBuffIntegration(ModConditions.calamityMod, "TranquilityCandle", "TranquilityCandleBuff", true);
            AddBuffIntegration(ModConditions.calamityMod, "EffigyOfDecay", "EffigyOfDecayBuff", true);
            AddBuffIntegration(ModConditions.calamityMod, "CrimsonEffigy", "CrimsonEffigyBuff", true);
            AddBuffIntegration(ModConditions.calamityMod, "CorruptionEffigy", "CorruptionEffigyBuff", true);
        }

        public static void DoCalamityRemixModIntegration()
        {
            if (!ModConditions.calamityCommunityRemixLoaded)
            {
                return;
            }

            AddBuffIntegration(ModConditions.calamityCommunityRemixMod, "AstralEffigy", "AstralEffigyBuff", true);
            AddBuffIntegration(ModConditions.calamityCommunityRemixMod, "HallowEffigy", "HallowEffigyBuff", true);
        }

        public static void DoThoriumIntegration()
        {
            if (!ModConditions.thoriumLoaded)
            {
                return;
            }

            AddBuffIntegration(ModConditions.thoriumMod, "Altar", "AltarBuff", true);
            AddBuffIntegration(ModConditions.thoriumMod, "ConductorsStand", "ConductorsStandBuff", true);
            AddBuffIntegration(ModConditions.thoriumMod, "Mistletoe", "MistletoeBuff", true);
            AddBuffIntegration(ModConditions.thoriumMod, "NinjaRack", "NinjaBuff", true);
        }

        public static void DoSpiritIntegration()
        {
            if (!ModConditions.spiritLoaded)
            {
                return;
            }

            AddBuffIntegration(ModConditions.spiritMod, "SunPot", "SunPotBuff", true);
            AddBuffIntegration(ModConditions.spiritMod, "CoilEnergizerItem", "OverDrive", true);
            AddBuffIntegration(ModConditions.spiritMod, "TheCouch", "CouchPotato", true);
        }

        public static void DoRedemptionIntegration()
        {
            if (!ModConditions.redemptionLoaded)
            {
                return;
            }

            AddBuffIntegration(ModConditions.redemptionMod, "EnergyStation", "EnergyStationBuff", true);
        }

        public static void DoSOTSIntegration()
        {
            if (!ModConditions.secretsOfTheShadowsLoaded)
            {
                return;
            }

            AddBuffIntegration(ModConditions.secretsOfTheShadowsMod, "DigitalDisplay", "CyberneticEnhancements", true);
        }

        public static void DoFargosIntegration()
        {
            if (!ModConditions.fargosMutantLoaded)
            {
                return;
            }

            AddBuffIntegration(ModConditions.fargosMutantMod, "Semistation", "Semistation", true);
            AddBuffIntegration(ModConditions.fargosMutantMod, "Omnistation", "Omnistation", true);
            AddBuffIntegration(ModConditions.fargosMutantMod, "Omnistation2", "Omnistation", true);
        }

        public static void DoHomewardIntegration()
        {
            if (!ModConditions.homewardJourneyLoaded)
            {
                return;
            }

            AddBuffIntegration(ModConditions.homewardJourneyMod, "BushOfLife", "BushOfLifeBuff", true);
            AddBuffIntegration(ModConditions.homewardJourneyMod, "LifeLantern", "LifeLanternBuff", true);
        }

        public static void AddBuffIntegration(Mod mod, string itemName, string buffName, bool isPlaceable)
        {
            if (isPlaceable)
                ModdedPlaceableItemBuffs[mod.Find<ModItem>(itemName).Type] = mod.Find<ModBuff>(buffName).Type;
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

    internal class ModdedStationSupport : ModSystem
    {
        internal static readonly HashSet<int> multitileAddsBuffsOnRightClick = new HashSet<int>();

        public override void PostSetupContent()
        {
            if (ModConditions.redemptionLoaded)
            {
                multitileAddsBuffsOnRightClick.Add(Common.GetModTile(ModConditions.redemptionMod, "EnergyStationTile"));
            }
            if (ModConditions.secretsOfTheShadowsLoaded)
            {
                multitileAddsBuffsOnRightClick.Add(Common.GetModTile(ModConditions.secretsOfTheShadowsMod, "DigitalDisplayTile"));
            }
            if (ModConditions.thoriumLoaded)
            {
                multitileAddsBuffsOnRightClick.Add(Common.GetModTile(ModConditions.thoriumMod, "Altar"));
                multitileAddsBuffsOnRightClick.Add(Common.GetModTile(ModConditions.thoriumMod, "ConductorsStand"));
                multitileAddsBuffsOnRightClick.Add(Common.GetModTile(ModConditions.thoriumMod, "NinjaRack"));
            }
        }

        public override void Unload()
        {
            multitileAddsBuffsOnRightClick.Clear();
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
