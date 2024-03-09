using QoLCompendium.Content.Items.Tools.Usables;

namespace QoLCompendium.Core
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

                if (item.type == ItemID.RedPotion && Main.getGoodWorld && !QoLCompendium.mainConfig.EndlessBuffsOnlyFromCrate)
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

                if (item.type == ModContent.ItemType<BannerBox>())
                {
                    for (int i = 0; i < NPCLoader.NPCCount; i++)
                    {
                        int bItem = ContentSamples.NpcsByNetId[i].BannerID();
                        if (NPC.killCount[i] >= ItemID.Sets.KillsToBanner[bItem])
                        {
                            Main.LocalPlayer.HasNPCBannerBuff(bItem);
                            Main.LocalPlayer.AddBuff(BuffID.MonsterBanner, 2);
                            Main.buffNoTimeDisplay[BuffID.MonsterBanner] = true;
                            Main.SceneMetrics.NPCBannerBuff[bItem] = true;
                            Main.SceneMetrics.hasBanner = true;
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
                        if (!QoLCompendium.mainConfig.EndlessBuffsOnlyFromCrate)
                        {
                            Main.LocalPlayer.AddBuff(buffType, 2);
                            LuckPotionBoost = item.type switch
                            {
                                ItemID.LuckPotionLesser => Math.Max(LuckPotionBoost, 0.1f),
                                ItemID.LuckPotion => Math.Max(LuckPotionBoost, 0.2f),
                                ItemID.LuckPotionGreater => Math.Max(LuckPotionBoost, 0.3f),
                                _ => LuckPotionBoost
                            };
                        }
                        break;
                }
            }
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
