using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    public class BuffItemTweaks : GlobalItem
    {
        public override bool ConsumeItem(Item item, Player player)
        {
            if (item.buffTime > 0 && item.stack >= 30)
            {
                return false;
            }
            else if ((item.type == ItemID.RecallPotion || item.type == ItemID.TeleportationPotion || item.type == ItemID.WormholePotion || item.type == ItemID.PotionOfReturn) && item.stack >= 30)
            {
                return false;
            }
            else if ((item.healLife > 0 || item.healMana > 0) && item.stack >= 30)
            {
                return false;
            }
            return true;
        }
    }

    public struct EndlessBuffSource
    {
        public EndlessBuffSource(Item item, string key)
        {
            Item = item;
            Key = key;
        }

        public Item Item;

        public string Key;
    }

    public static class BuffHelper
    {
        public static List<(T, string)> FromArray<T>(T[] items, string key) => items.Select(t => (t, key)).ToList();
    }

    public class BuffPlayer : ModPlayer
    {
        public Dictionary<int, EndlessBuffSource> EndlessBuffSources = new();

        public List<ValueTuple<Item, string>> ItemsToCountForEndlessBuffs = new();

        public int InventoryItemsStart;

        public int PiggyBankItemsStart;

        public int SafeItemsStart;

        public int DefendersForgeItemsStart;

        public int VoidVaultItemsStart;

        public static float LuckPotionBoost = 0;

        public override void PreUpdateBuffs()
        {
            if (Main.GameUpdateCount % 1.5 == 0.0)
            {
                ItemsToCountForEndlessBuffs.Clear();
                ItemsToCountForEndlessBuffs.AddRange(BuffHelper.FromArray(Player.inventory, "Inventory"));
                InventoryItemsStart = ItemsToCountForEndlessBuffs.Count - 1;
                ItemsToCountForEndlessBuffs.AddRange(BuffHelper.FromArray(Player.bank.item, "PiggyBank"));
                PiggyBankItemsStart = ItemsToCountForEndlessBuffs.Count - 1;
                ItemsToCountForEndlessBuffs.AddRange(BuffHelper.FromArray(Player.bank2.item, "Safe"));
                SafeItemsStart = ItemsToCountForEndlessBuffs.Count - 1;
                ItemsToCountForEndlessBuffs.AddRange(BuffHelper.FromArray(Player.bank3.item, "DefendersForge"));
                DefendersForgeItemsStart = ItemsToCountForEndlessBuffs.Count - 1;
                ItemsToCountForEndlessBuffs.AddRange(BuffHelper.FromArray(Player.bank4.item, "VoidVault"));
                VoidVaultItemsStart = ItemsToCountForEndlessBuffs.Count - 1;
            }
            EndlessBuffSources.Clear();
            foreach ((Item, string) val in ItemsToCountForEndlessBuffs)
            {
                (Item item, string key) = val;
                if (item.buffType <= 0)
                    continue;

                if (item.stack >= 30)
                {
                    EndlessBuffSources.Add(item.buffType, new EndlessBuffSource(item, key));
                    Player.AddBuff(item.buffType, 20);
                    Main.buffNoTimeDisplay[item.buffType] = true;
                }
            }

            ApplyAvailableBuffs(Player.inventory);
            ApplyAvailableBuffs(Player.bank.item);
            ApplyAvailableBuffs(Player.bank2.item);
            ApplyAvailableBuffs(Player.bank3.item);
            ApplyAvailableBuffs(Player.bank4.item);
        }

        public override void ModifyLuck(ref float luck)
        {
            luck += LuckPotionBoost;
            LuckPotionBoost = 0;
        }

        private static void ApplyAvailableBuffs(IEnumerable<Item> items)
        {
            foreach (Item item in items)
            {
                int buffType = BuffItem.GetItemBuffType(item);
                if (item != null)
                {
                    if (item.type == ItemID.LuckPotionLesser)
                    {
                        LuckPotionBoost += 0.1f;
                    }
                    if (item.type == ItemID.LuckPotion)
                    {
                        LuckPotionBoost += 0.2f;
                    }
                    if (item.type == ItemID.LuckPotionGreater)
                    {
                        LuckPotionBoost += 0.3f;
                    }
                    if (item.type == ItemID.GardenGnome)
                    {
                        LuckPotionBoost += 0.2f;
                    }

                    switch (buffType)
                    {
                        case -1:
                            break;
                        default:
                            Main.LocalPlayer.AddBuff(buffType, 2);
                            break;
                    }
                }
            }
        }
    }

    public class BuffSystem : ModSystem
    {
        internal static Dictionary<int, int> ModdedPlaceableItemBuffs = new();

        private static void DoCalamityModIntegration()
        {
            if (!ModLoader.TryGetMod("CalamityMod", out Mod calamityMod))
            {
                return;
            }

            AddBuffIntegration(calamityMod, "WeightlessCandle", "CirrusBlueCandleBuff", true);
            AddBuffIntegration(calamityMod, "VigorousCandle", "CirrusPinkCandleBuff", true);
            AddBuffIntegration(calamityMod, "SpitefulCandle", "CirrusYellowCandleBuff", true);
            AddBuffIntegration(calamityMod, "ResilientCandle", "CirrusPurpleCandleBuff", true);
            AddBuffIntegration(calamityMod, "ChaosCandle", "ChaosCandleBuff", true);
            AddBuffIntegration(calamityMod, "TranquilityCandle", "TranquilityCandleBuff", true);
            AddBuffIntegration(calamityMod, "EffigyOfDecay", "EffigyOfDecayBuff", true);
            AddBuffIntegration(calamityMod, "CrimsonEffigy", "CrimsonEffigyBuff", true);
            AddBuffIntegration(calamityMod, "CorruptionEffigy", "CorruptionEffigyBuff", true);
        }

        private static void DoThoriumIntegration()
        {
            if (!ModLoader.TryGetMod("ThoriumMod", out Mod thoriumMod))
            {
                return;
            }

            AddBuffIntegration(thoriumMod, "Altar", "AltarBuff", true);
            AddBuffIntegration(thoriumMod, "ConductorsStand", "ConductorsStandBuff", true);
            AddBuffIntegration(thoriumMod, "Mistletoe", "MistletoeBuff", true);
            AddBuffIntegration(thoriumMod, "NinjaRack", "NinjaBuff", true);
        }

        public static void AddBuffIntegration(Mod mod, string itemName, string buffName, bool isPlaceable)
        {
            if (isPlaceable)
                ModdedPlaceableItemBuffs[mod.Find<ModItem>(itemName).Type] = mod.Find<ModBuff>(buffName).Type;
        }

        public override void PostSetupContent()
        {
            DoCalamityModIntegration();
            DoThoriumIntegration();
        }
    }

    public class BuffItem : GlobalItem
    {
        public static readonly List<List<int>> BuffTiles = new() {
            new() { TileID.CatBast, -1, BuffID.CatBast },
            new() { TileID.Campfire, -1, BuffID.Campfire },
            new() { TileID.Fireplace, -1, BuffID.Campfire },
            new() { TileID.HangingLanterns, 9, BuffID.HeartLamp },
            new() { TileID.HangingLanterns, 7, BuffID.StarInBottle },
            new() { TileID.Sunflower, -1, BuffID.Sunflower },
            new() { TileID.AmmoBox, -1, BuffID.AmmoBox },
            new() { TileID.BewitchingTable, -1, BuffID.Bewitched },
            new() { TileID.CrystalBall, -1, BuffID.Clairvoyance },
            new() { TileID.SliceOfCake, -1, BuffID.SugarRush },
            new() { TileID.SharpeningStation, -1, BuffID.Sharpened },
            new() { TileID.WaterCandle, -1, BuffID.WaterCandle },
            new() { TileID.PeaceCandle, -1, BuffID.PeaceCandle },
            new() { TileID.ShadowCandle, -1, BuffID.ShadowCandle },
            new() { TileID.WarTable, -1, BuffID.WarTable }
        };

        public static bool IsBuffTileItem(Item item, out int buffType)
        {
            for (int i = 0; i < BuffTiles.Count; i++)
            {
                if (item.createTile == BuffTiles[i][0] && (item.placeStyle == BuffTiles[i][1] || BuffTiles[i][1] == -1))
                {
                    buffType = BuffTiles[i][2];
                    return true;
                }
            }
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

        public static int GetItemBuffType(Item item)
        {
            IsBuffTileItem(item, out int buffType);
            if (buffType is not -1)
                return buffType;
            if (item.type == ItemID.HoneyBucket)
            {
                return BuffID.Honey;
            }
            return -1;
        }
    }
}
