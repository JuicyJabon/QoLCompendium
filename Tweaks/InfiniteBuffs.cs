using QoLCompendium.Items.FavoriteEffectItems;
using QoLCompendium.Items.Tools;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Default;
using Terraria.Social.Base;

namespace QoLCompendium.Tweaks
{
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
        #pragma warning disable CA2211
        public static float LuckPotionBoost = 0;
        #pragma warning restore CA2211

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

        public override void PostUpdateBuffs()
        {
            if (Player.whoAmI != Main.myPlayer)
                return;

            if (QoLCompendium.mainConfig.EndlessBuffs)
            {
                ApplyAvailableBuffs(Player.inventory);
                ApplyAvailableBuffs(Player.bank.item);
                ApplyAvailableBuffs(Player.bank2.item);
                ApplyAvailableBuffs(Player.bank3.item);
                ApplyAvailableBuffs(Player.bank4.item);
            }
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
                if (item.createTile is TileID.GardenGnome)
                {
                    LuckPotionBoost += 0.2f;
                }

                if (item.type == ItemID.RedPotion && Main.getGoodWorld)
                {
                    for (int i = 0; i < AvailableRedPotionBuffs.Count; i++)
                    {
                        Main.LocalPlayer.AddBuff(AvailableRedPotionBuffs[i], 2);
                    }
                }

                if (item.type == ModContent.ItemType<PotionCrate>())
                {
                    for (int i = 0; i < PotionCrate.BuffIDList.Count; i++)
                    {
                        Main.LocalPlayer.AddBuff(PotionCrate.BuffIDList[i], 2);

                        if (PotionCrate.ItemIDList.Contains(ItemID.LuckPotionLesser))
                        {
                            Math.Max(LuckPotionBoost, 0.1f);
                        }
                        if (PotionCrate.ItemIDList.Contains(ItemID.LuckPotion))
                        {
                            Math.Max(LuckPotionBoost, 0.2f);
                        }
                        if (PotionCrate.ItemIDList.Contains(ItemID.LuckPotionGreater))
                        {
                            Math.Max(LuckPotionBoost, 0.3f);
                        }
                    }
                }

                int buffType = BuffItem.GetItemBuffType(item);

                bool wellFed3Enabled = Main.LocalPlayer.FindBuffIndex(BuffID.WellFed3) != -1;
                bool wellFed2Enabled = Main.LocalPlayer.FindBuffIndex(BuffID.WellFed2) != -1;

                switch (buffType)
                {
                    case BuffID.WellFed when wellFed2Enabled || wellFed3Enabled:
                    case BuffID.WellFed2 when wellFed3Enabled:
                        continue;
                    case -1:
                        break;
                    default:
                        Main.LocalPlayer.AddBuff(buffType, 2);
                        LuckPotionBoost = item.type switch
                        {
                            ItemID.LuckPotionLesser => Math.Max(LuckPotionBoost, 0.1f),
                            ItemID.LuckPotion => Math.Max(LuckPotionBoost, 0.2f),
                            ItemID.LuckPotionGreater => Math.Max(LuckPotionBoost, 0.3f),
                            _ => LuckPotionBoost
                        };
                        break;
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

        private static void DoSpiritIntegration()
        {
            if (!ModLoader.TryGetMod("SpiritMod", out Mod spirit))
            {
                return;
            }

            AddBuffIntegration(spirit, "SunPot", "SunPotBuff", true);
            AddBuffIntegration(spirit, "CoilEnergizerItem", "OverDrive", true);
            AddBuffIntegration(spirit, "TheCouch", "CouchPotato", true);
        }

        private static void DoRedemptionIntegration()
        {
            if (!ModLoader.TryGetMod("Redemption", out Mod redemption))
            {
                return;
            }

            AddBuffIntegration(redemption, "EnergyStation", "EnergyStationBuff", true);
        }

        private static void DoSOTSIntegration()
        {
            if (!ModLoader.TryGetMod("SOTS", out Mod sots))
            {
                return;
            }

            AddBuffIntegration(sots, "DigitalDisplay", "CyberneticEnhancements", true);
        }

        private static void DoFargosIntegration()
        {
            if (!ModLoader.TryGetMod("Fargowiltas", out Mod fargos))
            {
                return;
            }

            AddBuffIntegration(fargos, "Semistation", "Semistation", true);
            AddBuffIntegration(fargos, "Omnistation", "Omnistation", true);
            AddBuffIntegration(fargos, "Omnistation2", "Omnistation", true);
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
            DoSpiritIntegration();
            DoRedemptionIntegration();
            DoSOTSIntegration();
            DoFargosIntegration();
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
            if (QoLCompendium.mainConfig.EndlessBuffs)
            {
                if (item.stack >= QoLCompendium.mainConfig.EndlessBuffAmount && item.active)
                {
                    if (item.buffType > 0)
                        return item.buffType;
                }

                IsBuffTileItem(item, out int buffType);
                if (buffType is not -1)
                    return buffType;

                if (item.type == ItemID.HoneyBucket)
                {
                    return BuffID.Honey;
                }
            }
            return -1;
        }
    }
}
